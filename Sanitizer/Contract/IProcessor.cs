namespace Sanitizer.Contract
{
    public interface IProcessor
    {
        ProcessorResult Result { get; }

        void Init(string pattern, int index);

        string Process(string source);

        void Next(IProcessor nextInChain);

    }
}