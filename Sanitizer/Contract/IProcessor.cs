namespace Sanitizer.Contract
{
    public interface IProcessor
    {
        void Process(string source, string pattern);

        void Next();

    }
}