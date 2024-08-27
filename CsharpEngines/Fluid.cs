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
    <h1 style="text-align: center; color: red">{{ header | escape }}</h1>
    <ul id="list" class="myList" lang="en" translate="no" spellcheck="false">
      {%- for _ in (1..num) -%}
        <li>
          <p class="goodItem" data-value="12345" onclick="alert('Hello')">
            {{- trustedHtml -}}
          </p>
          <br>
          <span class="badItem">
            {{- untrustedHtml | escape -}}
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
        var context = new TemplateContext(new { num = 3, header = "Header",
          trustedHtml = "<h2>Raw HTML</h2>", untrustedHtml = "<script>alert('Danger!')</script>" });
        return template.Render(context);
    }
}