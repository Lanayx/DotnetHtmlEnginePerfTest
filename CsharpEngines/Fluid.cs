using Fluid;

namespace CsharpEngines;

public class FluidCommon
{
    public static IFluidTemplate GetTemplate()
    {
        var parser = new FluidParser();
        return parser.Parse(
"""
<html>
  <body style="width: 800px; margin: 0 auto">
    <h1 style="text-align: center; color: red">Header</h1>
    <ul id="list" class="myList" lang="en" translate="yes" spellcheck="false">
      {%- for _ in (1..num) -%}
        <li>
          <p class="goodItem" data-value="12345" onclick="alert('Hello')">
            {{- "<h2>Raw HTML</h2>" -}}
          </p>
          <br>
          <span class="badItem">
            {{- "<script>alert('Danger!')</script>" | escape -}}
          </span>
        </li>
      {%- endfor -%}
    </ul>
  </body>
</html>
""");
    }
}

public class FluidDynamic
{
    public static IFluidTemplate template = FluidCommon.GetTemplate();

    public static string RenderToString()
    {
        var context = new TemplateContext(new { num = 3 });
        return template.Render(context);
    }
}