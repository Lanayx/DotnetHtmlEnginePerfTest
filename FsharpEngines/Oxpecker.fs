namespace FsharpEngines

open Oxpecker.ViewEngine

module OxpeckerStatic =
    let staticView =
        html() {
            body(style = "width: 800px; margin: 0 auto") {
                h1(style = "text-align: center; color: red") { "Error" }
                p() { "Some long error text" }
                p() { raw "<h2>Raw HTML</h2>" }
                ul(id="list", class'="myList", lang="en", translate=false, hidden=false) {
                    for _ in 1..10 do
                        li().data("value", "12345") {
                            span() { "Test" }
                        }
                }
            }
        }

    let renderToString () =
        staticView |> Render.toString

    let renderToBytes () =
        staticView |> Render.toBytes