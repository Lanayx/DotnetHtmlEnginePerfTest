using DotLiquid;

namespace CsharpEngines;

public class DotLiquidCommon
{
    public static Template GetTemplate()
    {
        return Template.Parse(
"""
<html>
  <body style="width: 800px; margin: 0 auto">
    <h1 style="text-align: center; color: red">{{ header }}</h1>
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

public class DotLiquidDynamic
{
    public static Template template = DotLiquidCommon.GetTemplate();

    public static string RenderToString()
    {
        return template.Render(Hash.FromAnonymousObject(new { num = 3, header = "Header",
          trustedHtml = "<h2>Raw HTML</h2>", untrustedHtml = "<script>alert('Danger!')</script>" }));
    }
}