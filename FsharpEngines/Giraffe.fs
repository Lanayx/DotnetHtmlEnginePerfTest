﻿namespace FsharpEngines

open Giraffe.ViewEngine

module GiraffeStatic =
    let staticView =
        html [] [
            body [ _style "width: 800px; margin: 0 auto" ] [
                h1 [ _style "text-align: center; color: red" ] [ str "Header" ]
                ul [ _id "list"; _class "myList"; _lang "en"; _translate "no"; _spellcheck "false" ] [
                    for _ in 1..5 do
                        li [] [
                            p [ _class "goodItem"
                                _data "value" "12345"
                                _onclick "alert('Hello')" ] [
                                rawText "<h2>Raw HTML</h2>"
                            ]
                            br []
                            span [ _class "badItem" ] [ str "<script>alert('Danger!')</script>" ]
                        ]
                ]
            ]
        ]

    let renderToString () =
        staticView |> RenderView.AsString.htmlNode

    let renderToBytes () =
        staticView |> RenderView.AsBytes.htmlNode