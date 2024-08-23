using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CsharpEngines;
using FsharpEngines;

public class Program
{
    public static int Main(string[] args)
    {
        // var summary = GiraffeDynamic.renderToString();
        // return summary.Length;
        BenchmarkRunner.Run<ViewEngineDynamicString>();
        return 0;
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

    [Benchmark]
    public void ScribanToString()
    {
        ScribanDynamic.RenderToString();
    }

    [Benchmark]
    public void DotLiquidToString()
    {
        DotLiquidDynamic.RenderToString();
    }

    [Benchmark]
    public void FluidToString()
    {
        FluidDynamic.RenderToString();
    }

    [Benchmark]
    public async Task RazorToString()
    {
        await RazorDynamic.RenderToString();
    }
}