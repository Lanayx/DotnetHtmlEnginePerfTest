using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CsharpEngines;
using FsharpEngines;

public class Program
{
    public static int Main(string[] args)
    {
        // var summary = T4Dynamic.RenderToString();
        BenchmarkRunner.Run<ViewEngineDynamicString>();
        return 0;
    }
}

[MemoryDiagnoser]
public class ViewEngineDynamicString {

    [Benchmark(Baseline = true)]
    public void InterpolationToString()
    {
        InterpolationDynamic.renderToString();
    }

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

    [Benchmark]
    public void T4ToString()
    {
        T4Dynamic.RenderToString();
    }

    [Benchmark]
    public void HandlebarsToString()
    {
        HandlebarsDynamic.RenderToString();
    }

    [Benchmark]
    public void OxpeckerTweakedToString()
    {
        OxpeckerTweakedDynamic.renderToString();
    }
}