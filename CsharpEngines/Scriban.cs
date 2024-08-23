using Scriban;

namespace CsharpEngines;

public class ScribanCommon
{
    public static Template GetTemplate()
    {
        return Template.Parse(
"""
<html>
  <body style="width: 800px; margin: 0 auto">
    <h1 style="text-align: center; color: red">Header</h1>
    <ul id="list" class="myList" lang="en" translate="yes" spellcheck="false">
      {{- for _ in 1..num -}}
        <li>
          <p class="goodItem" data-value="12345" onclick="alert('Hello')">
            {{- "<h2>Raw HTML</h2>" -}}
          </p>
          <br>
          <span class="badItem">
            {{- "<script>alert('Danger!')</script>" | html.escape -}}
          </span>
        </li>
      {{- end -}}
    </ul>
  </body>
</html>
""");
    }
}

public class ScribanDynamic
{
    public static Template template = ScribanCommon.GetTemplate();

    public static string RenderToString()
    {
        return template.Render(new { Num = 3 });
    }
}