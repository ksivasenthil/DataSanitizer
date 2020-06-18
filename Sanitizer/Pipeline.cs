namespace Sanitizer
{
    using System;
    using System.Collections.Generic;
    using Sanitizer.Contract;
    public class Pipeline
    {
        public List<IProcessor> SequentialProcessor { get; }
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

        public void Process()
        {

        }

    }
}