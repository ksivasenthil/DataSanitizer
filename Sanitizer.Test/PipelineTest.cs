using System;
using Xunit;
using Sanitizer;
using Sanitizer.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Sanitizer.Test
{
    public class PipelineTest
    {
        private Pipeline TestSubject;
        public PipelineTest()
        {
            TestSubject = new Pipeline();
        }

        [Fact]
        public void AddProcessorSwellsTheProcessingChainBy1()
        {
            string pattern1 = "\r\n";
            IProcessor sample1 = new StringProcessor(pattern1, 0);

            TestSubject.AddProcessor(sample1);

            Assert.True(1 == TestSubject.SequentialProcessor.Count);
        }

        [Fact]
        public void RemoveProcessorDeflatesTheProcessingChainBy1()
        {
            string pattern1 = "\r\n";
            IProcessor sample1 = new StringProcessor(pattern1, 0);

            TestSubject.AddProcessor(sample1);

            TestSubject.RemoveProcessor(0);

            Assert.True(0 == TestSubject.SequentialProcessor.Count);
        }


        [Fact]
        public void RemoveProcessorRemovesAtCorrectIndex()
        {
            string pattern1 = "\r\n";
            string pattern2 = "\\$";

            IProcessor sample1 = new StringProcessor(pattern1, 0);
            IProcessor sample2 = new StringProcessor(pattern2, 1);

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);

            TestSubject.RemoveProcessor(1);

            Assert.Same(sample1, TestSubject.SequentialProcessor[0]);
        }

        [Fact]
        public void CallAllHandlersSequentially()
        {
            string input = "\r\n Hello$World \r\n";
            string pattern1 = "\r\n";
            string pattern2 = "\\$";
            IProcessor sample1 = new StringProcessor(pattern1, 0);
            IProcessor sample2 = new StringProcessor(pattern2, 1);

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);

            string resultOfProcessing = TestSubject.Process(input);

            List<int> numbers = new List<int>() { 0, 1 };

            List<int> processingOrder = TestSubject
                .Results
                .Select(r => r.ProcessIndex).ToList();

            Assert.Equal(numbers, processingOrder);
        }

        [Fact]
        public void AbortEntirePipelineOnFailure()
        {
            string input = "\r\n This is a &quot; setup &quot; \r\n";
            string pattern1 = "\r\n";
            string pattern2 = "*";

            IProcessor sample1 = new StringProcessor(pattern1, 0);
            IProcessor sample2 = new StringProcessor(pattern2, 1);

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);

            Assert.Throws<ArgumentException>(() => TestSubject.Process(input));
            Assert.True(0 == TestSubject.Results.Count);
        }

        [Fact]
        public void ResultOfAllHandlersAreAvailable()
        {
            string input = "\r\n &quot;Hello$World&quot; \r\n";
            string pattern1 = "\r\n";
            string pattern2 = "\\$";
            string pattern3 = "\\&quot;";

            IProcessor sample1 = new StringProcessor(pattern1, 0);
            IProcessor sample2 = new StringProcessor(pattern2, 1);
            IProcessor sample3 = new StringProcessor(pattern3, 2);

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);
            TestSubject.AddProcessor(sample3);

            TestSubject.Process(input);
            Assert.True(3 == TestSubject.Results.Count);
        }

        [Fact]
        public void PipelineResultIsAsExpected()
        {
            string input = "\r\n Hello$World \r\n";
            string pattern1 = "\\r\\n";
            string pattern2 = "\\$";
            IProcessor sample1 = new StringProcessor(pattern1, 0);
            IProcessor sample2 = new StringProcessor(pattern2, 1);

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);

            string resultOfProcessing = TestSubject.Process(input);

            Assert.Equal(" Hello World ", resultOfProcessing);
        }
    }
}
