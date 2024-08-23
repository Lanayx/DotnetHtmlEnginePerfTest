namespace FsharpEngines

open Oxpecker.ViewEngine

module OxpeckerStatic =
    let staticView =
        html() {
            body(style = "width: 800px; margin: 0 auto") {
                h1(style = "text-align: center; color: red") { "Header" }
                ul(id="list", class'="myList", lang="en", translate=false, spellcheck=false) {
                    for _ in 1..5 do
                        li() {
                            p(class'="goodItem")
                                .data("value", "12345")
                                .on("click", "alert('Hello')") {
                                    raw "<h2>Raw HTML</h2>"
                                }
                            br()
                            span(class'="badItem") { "<script>alert('Danger!')</script>" }
                        }
                }
            }
        }

    let renderToString () =
        staticView |> Render.toString

    let renderToBytes () =
        staticView |> Render.toBytes