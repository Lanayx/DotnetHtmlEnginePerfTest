namespace FsharpEngines

open Oxpecker.ViewEngine

module OxpeckerCommon =
    let getView num (header: string) (trustedHtml: string) (untrustedHtml: string) =
        html() {
            body(style="width: 800px; margin: 0 auto") {
                h1(style="text-align: center; color: red") { header }
                ul(id="list", class'="myList", lang="en", translate=false, spellcheck=false) {
                    for _ in 1..num do
                        li() {
                            p(class'="goodItem")
                                .attr("data-value", "12345")
                                .attr("onclick", "alert('Hello')") {
                                    raw trustedHtml
                                }
                            br()
                            span(class'="badItem") { untrustedHtml }
                        }
                }
            }
        }

module OxpeckerDynamic =

    let renderToString () =
        OxpeckerCommon.getView 3 "Header" "<h2>Raw HTML</h2>" "<script>alert('Danger!')</script>" |> Render.toString