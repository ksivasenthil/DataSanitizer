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
            Results = new List<ProcessorResult>();
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
            for (int index = 0;
                this.SequentialProcessor.Count > index;
                index++)
            {
                IProcessor current = this.SequentialProcessor[index];
                IProcessor next = default(IProcessor);
                bool notAtEndOfChain = this.SequentialProcessor.Count > index + 1;
                if (notAtEndOfChain)
                {
                    next = this.SequentialProcessor[index + 1];
                }
                current.Next(next);
            }
            string response = this.SequentialProcessor[0].Process(input);
            this.HarvestResult();
            return response;
        }

        private void HarvestResult()
        {
            foreach (IProcessor processor
             in this.SequentialProcessor)
            {
                Results.Add(processor.Result);
            }
        }
    }
}