namespace Sanitizer
{
    using Sanitizer.Contract;
    public class StringProcessor : IProcessor
    {
        private string PatternToFind;
        private IProcessor NextInChain;
        private ProcessorResult CurrentResult;

        public StringProcessor(string pattern, int index)
        {
            (this as IProcessor).Init(pattern, index);
        }

        ProcessorResult IProcessor.Result
        {
            get => CurrentResult;
        }

        void IProcessor.Init(string pattern, int index)
        {
            CurrentResult = new ProcessorResult()
            {
                ProcessIndex = index,
                StageResult = default(string)
            };
            this.PatternToFind = pattern;
        }

        void IProcessor.Next(IProcessor nextInChain)
        {
            this.NextInChain = nextInChain;
        }

        string IProcessor.Process(string source)
        {
            string processOutput = default(string);
            bool thereAreMoreProcessor = null != this.NextInChain;
            if (thereAreMoreProcessor)
            {
                processOutput = this.NextInChain.Process(source);
            }
            return processOutput;
        }
    }
}