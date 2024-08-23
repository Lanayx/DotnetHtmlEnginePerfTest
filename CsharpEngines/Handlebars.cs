using HandlebarsDotNet;

namespace CsharpEngines;

public class HandlebarsCommon
{
    public static HandlebarsTemplate<object, string> GetTemplate()
    {
        return Handlebars.Compile(
"""
<html>
  <body style="width: 800px; margin: 0 auto">
    <h1 style="text-align: center; color: red">{{ header }}</h1>
    <ul id="list" class="myList" lang="en" translate="no" spellcheck="false">
      {{~ #each num ~}}
        <li>
          <p class="goodItem" data-value="12345" onclick="alert('Hello')">
            {{{~ @root.rawHtml ~}}}
          </p>
          <br>
          <span class="badItem">
            {{~ @root.dangerous ~}}
          </span>
        </li>
      {{~ /each ~}}
    </ul>
  </body>
</html>
""");
    }
}

public class HandlebarsDynamic
{
    public static HandlebarsTemplate<object, string> template = HandlebarsCommon.GetTemplate();
    public static int[] fakeArray = new int[3];

    public static string RenderToString()
    {
        return template(new { header = "Header", num = fakeArray, rawHtml = "<h2>Raw HTML</h2>",
          dangerous = "<script>alert('Danger!')</script>" });
    }
}