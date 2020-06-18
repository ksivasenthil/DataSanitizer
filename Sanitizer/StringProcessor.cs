namespace Sanitizer
{
    using Sanitizer.Contract;
    public class StringProcessor : IProcessor
    {
        private string PatternToFind;
        public StringProcessor(string pattern)
        {

        }
        void IProcessor.Next(IProcessor nextInChain)
        {
            throw new System.NotImplementedException();
        }

        string IProcessor.Process(string source, string pattern)
        {
            throw new System.NotImplementedException();
        }
    }
}