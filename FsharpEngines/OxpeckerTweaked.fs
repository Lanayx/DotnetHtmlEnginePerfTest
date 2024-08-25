namespace FsharpEngines

open System.Text
open Oxpecker.ViewEngine

module OxpeckerHelpers =
    let prerenderedParentN n (view: HtmlElement[] -> HtmlElement) =
        let sb = StringBuilder()
        let mutable strings = Array.zeroCreate (n+1)
        let fakeHoles =
            [|
                for i=0 to n-1 do
                    { new HtmlElement with
                         member this.Render(sb) =
                             strings[i] <- sb.ToString()
                             sb.Clear() |> ignore
                         }
            |]
        let readyView = view fakeHoles
        readyView.Render(sb)
        strings[n] <- sb.ToString()
        strings

    let combineN (parentParts: string[]) (holes: HtmlElement[]) =
        { new HtmlElement with
            member this.Render(sb) =
                for i in 0..holes.Length-1 do
                    sb.Append(parentParts[i]) |> ignore
                    holes[i].Render(sb)
                sb.Append(parentParts[parentParts.Length-1]) |> ignore
        }

module OxpeckerTweakedCommon =

    let getView =
        let parent =
           (fun [| header: HtmlElement; children: HtmlElement |] ->
                html() {
                    body(style="width: 800px; margin: 0 auto") {
                        h1(style="text-align: center; color: red") { header }
                        ul(id="list", class'="myList", lang="en", translate=false, spellcheck=false) {
                            children
                        }
                    }
                } :> HtmlElement
           ) |> OxpeckerHelpers.prerenderedParentN 2
        let innards =
            (fun [| trustedHtml: HtmlElement; untrustedHtml: HtmlElement |] ->
                li() {
                    p(class'="goodItem")
                        .attr("data-value", "12345")
                        .attr("onclick", "alert('Hello')") {
                            trustedHtml
                        }
                    br()
                    span(class'="badItem") { untrustedHtml }
                } :> HtmlElement
            ) |> OxpeckerHelpers.prerenderedParentN 2

        fun num (header: string) (trustedHtml: string) (untrustedHtml: string) ->
            OxpeckerHelpers.combineN parent [|
                RegularTextNode header
                __(){
                    for _ in 1..num do
                        OxpeckerHelpers.combineN innards [|
                            RawTextNode trustedHtml
                            RegularTextNode untrustedHtml
                        |]
                }
            |]


module OxpeckerTweakedDynamic =

    let renderToString () =
        OxpeckerTweakedCommon.getView 3 "Header" "<h2>Raw HTML</h2>" "<script>alert('Danger!')</script>" |> Render.toString