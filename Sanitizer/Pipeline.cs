namespace Sanitizer
{
    using System;
    using System.Collections.Generic;
    using Sanitizer.Contract;
    public class Pipeline
    {
        public List<IProcessor> SequentialProcessor { get; }
        public List<ProcessorResult> Results { get; private set;}
        public Pipeline()
        {
            throw new NotImplementedException();
        }

        public void AddProcessor(IProcessor processor)
        {
            throw new NotImplementedException();
        }

        public void RemoveProcessor(int id)
        {
            throw new NotImplementedException();
        }

        public string Process(string input)
        {
            throw new NotImplementedException();
        }

    }
}