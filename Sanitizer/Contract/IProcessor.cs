namespace Sanitizer.Contract
{
    public interface IProcessor
    {
        void Init(string pattern);

        string Process(string source);

        void Next(IProcessor nextInChain);

    }
}