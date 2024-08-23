using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FsharpEngines;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ViewEngineStaticBytes>();
    }
}

[MemoryDiagnoser]
public class ViewEngineStaticBytes
{
    [Benchmark]
    public void OxpeckerToBytes()
    {
        OxpeckerStatic.renderToBytes();
    }

    [Benchmark]
    public void GiraffeToBytes()
    {
        OxpeckerStatic.renderToBytes();
    }
}

[MemoryDiagnoser]
public class ViewEngineStaticString
{
    [Benchmark]
    public void OxpeckerToString()
    {
        OxpeckerStatic.renderToString();
    }

    [Benchmark]
    public void GiraffeToString()
    {
        OxpeckerStatic.renderToString();
    }
}