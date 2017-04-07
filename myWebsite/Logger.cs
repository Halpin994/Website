using Microsoft.Owin;
using Owin;

public interface ILogger
{
    void Log(string input);
}

public class Logger : ILogger
{
    public void Log(string input)
    {
        throw new NotImplementedException();
    }
}