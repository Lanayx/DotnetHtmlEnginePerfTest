using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FsharpEngines;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ViewEngineStatic>();
    }
}

[MemoryDiagnoser]
public class ViewEngineStatic
{
    [Benchmark]
    public void OxpeckerToBytes()
    {
        OxpeckerStatic.renderToBytes();
    }
    [Benchmark]
    public void OxpeckerToString()
    {
        OxpeckerStatic.renderToString();
    }
}