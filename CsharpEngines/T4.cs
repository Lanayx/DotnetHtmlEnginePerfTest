namespace CsharpEngines;


public class T4Dynamic
{
    public static string RenderToString()
    {
        var view = new T4View
        {
            Num = 3,
            Header = "Header",
            TrustedHtml = "<h2>Raw HTML</h2>",
            UntrustedHtml = "<script>alert('Danger!')</script>"
        };
        return view.TransformText();
    }
}