namespace Sanitizer
{
    using System;
    using System.Collections.Generic;
    using Sanitizer.Contract;
    public class Pipeline
    {
        public List<IProcessor> SequentialProcessor { get; }
        public List<ProcessorResult> Results { get; private set; }
        public Pipeline()
        {
            SequentialProcessor = new List<IProcessor>();
        }

        public void AddProcessor(IProcessor processor)
        {
            SequentialProcessor.Add(processor);
        }

        public void RemoveProcessor(int index)
        {
            SequentialProcessor.RemoveAt(index);
        }

        public string Process(string input)
        {
            throw new NotImplementedException();
        }

    }
}