namespace FsharpEngines

open System.Net

module InterpolationCommon =
    let getView num (header: string) (trustedHtml: string) (untrustedHtml: string) =
      let liItem = $"""<li>
  <p class="goodItem" data-value="12345" onclick="alert('Hello')">
    %s{ trustedHtml }
  </p>
  <br>
  <span class="badItem">
    %s{ WebUtility.HtmlEncode(untrustedHtml) }
  </span>
</li>
"""

      $"""<html>
  <body style="width: 800px; margin: 0 auto">
    <h1 style="text-align: center; color: red">%s{ header }</h1>
    <ul id="list" class="myList" lang="en" translate="no" spellcheck="false">
      %s{ System.String.Concat(Array.init num (fun _ -> liItem))}
    </ul>
  </body>
</html>
"""

module InterpolationDynamic =

    let renderToString () =
        InterpolationCommon.getView 3 "Header" "<h2>Raw HTML</h2>" "<script>alert('Danger!')</script>"