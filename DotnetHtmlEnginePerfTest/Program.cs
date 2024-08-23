using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FsharpEngines;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ViewEngineDynamicString>();
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
        GiraffeStatic.renderToBytes();
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
        GiraffeStatic.renderToString();
    }

    [Benchmark]
    public void FalcoToString()
    {
        FalcoStatic.renderToString();
    }
}

[MemoryDiagnoser]
public class ViewEngineDynamicString
{
    [Benchmark]
    public void OxpeckerToString()
    {
        OxpeckerDynamic.renderToString();
    }

    [Benchmark]
    public void GiraffeToString()
    {
        GiraffeDynamic.renderToString();
    }

    [Benchmark]
    public void FalcoToString()
    {
        FalcoDynamic.renderToString();
    }
}