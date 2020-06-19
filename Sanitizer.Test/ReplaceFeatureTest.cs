namespace Sanitizer.Test
{
    using Xunit;
    using Sanitizer.Contract;

    public class ReplaceFeatureTest
    {
        private Pipeline TestSubject;
        public ReplaceFeatureTest()
        {
            TestSubject = new Pipeline();
        }
        [Fact]
        public void ReplacementStringIsNotMandatory()
        {
            string input = "\r\n Hello$World \r\n";
            string pattern1 = "\\r\\n";
            string pattern2 = "\\$";
            IProcessor sample1 = new StringProcessor(pattern1, 0);
            IProcessor sample2 = new StringProcessor(pattern2, 1);

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);

            string resultOfProcessing = TestSubject.Process(input);

            Assert.Equal(" HelloWorld ", resultOfProcessing);
        }

        [Fact]
        public void ReplacementStringIsUsed()
        {
            string input = "\r\n Hello$World&quot;You&quot;\r\n";
            string pattern1 = @"\r\n";
            string pattern2 = @"\$";
            string pattern3 = @"&quot;";
            IProcessor sample1 = new StringProcessor(pattern1, 0, "+");
            IProcessor sample2 = new StringProcessor(pattern2, 1, " ");
            IProcessor sample3 = new StringProcessor(pattern3, 2, " ' ");

            TestSubject.AddProcessor(sample1);
            TestSubject.AddProcessor(sample2);
            TestSubject.AddProcessor(sample3);

            string resultOfProcessing = TestSubject.Process(input);

            Assert.Equal("+ HelloWorld ' You ' +", resultOfProcessing);
        }
    }
}