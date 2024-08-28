namespace FsharpEngines

open Falco.Markup
open Falco.Markup.Elem
open Falco.Markup.Attr

module FalcoCommon =
    let getView num (header: string) (trustedHtml: string) (untrustedHtml: string) =
        html [] [
            body [ style "width: 800px; margin: 0 auto" ] [
                h1 [ style "text-align: center; color: red" ] [ Text.enc header ]
                ul [ id "list"; class' "myList"; lang "en"; translate "no"; spellcheck "false" ] [
                    for _ in 1..num do
                        li [] [
                            p [ class' "goodItem"
                                create "data-value" "12345"
                                create "onclick" "alert('Hello')" ] [
                                Text.raw trustedHtml
                            ]
                            br []
                            Elem.span [ class' "badItem" ] [ Text.enc untrustedHtml ]
                        ]
                ]
            ]
        ]

module FalcoDynamic =

    let renderToString () =
        FalcoCommon.getView 3 "Header" "<h2>Raw HTML</h2>" "<script>alert('Danger!')</script>" |> renderNode