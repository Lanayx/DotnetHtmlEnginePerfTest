namespace FsharpEngines

open Giraffe.ViewEngine

module GiraffeCommon =
    let getView num (header: string) (trustedHtml: string) (untrustedHtml: string) =
        html [] [
            body [ _style "width: 800px; margin: 0 auto" ] [
                h1 [ _style "text-align: center; color: red" ] [ str header ]
                ul [ _id "list"; _class "myList"; _lang "en"; _translate "no"; _spellcheck "false" ] [
                    for _ in 1..num do
                        li [] [
                            p [ _class "goodItem"
                                attr "data-value" "12345"
                                attr "onclick" "alert('Hello')" ] [
                                rawText trustedHtml
                            ]
                            br []
                            span [ _class "badItem" ] [ str untrustedHtml ]
                        ]
                ]
            ]
        ]

module GiraffeDynamic =

    let renderToString () =
        GiraffeCommon.getView 3 "Header" "<h2>Raw HTML</h2>" "<script>alert('Danger!')</script>" |> RenderView.AsString.htmlNode
