namespace Sanitizer
{
    using Sanitizer.Contract;
    public class StringProcessor : IProcessor
    {
        private string PatternToFind;
        public StringProcessor(string pattern)
        {
            (this as IProcessor).Init(pattern);
        }

        void IProcessor.Init(string pattern)
        {
            this.PatternToFind = pattern;
        }

        void IProcessor.Next(IProcessor nextInChain)
        {
            throw new System.NotImplementedException();
        }

        string IProcessor.Process(string source)
        {
            throw new System.NotImplementedException();
        }
    }
}