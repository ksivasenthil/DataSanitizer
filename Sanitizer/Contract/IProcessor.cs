namespace Sanitizer.Contract
{
    public interface IProcessor
    {
        string Process(string source, string pattern);

        void Next(IProcessor nextInChain);

    }
}