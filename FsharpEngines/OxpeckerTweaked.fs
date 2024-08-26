namespace FsharpEngines

open System.Text
open Oxpecker.ViewEngine

module OxpeckerHelpers =
    let prerender (view: 'T) =
        let handlerType = view.GetType()
        let handlerMethod = handlerType.GetMethods()[0]
        let parameters = handlerMethod.GetParameters()
        let n = parameters.Length

        let sb = StringBuilder()
        let mutable strings = Array.zeroCreate (n+1)
        let fakeHoles =
            [|
                for i=0 to n-1 do
                    { new HtmlElement with
                         member this.Render(sb) =
                             strings[i] <- sb.ToString()
                             sb.Clear() |> ignore
                         } |> box
            |]
        let readyView = handlerMethod.Invoke(view, fakeHoles) :?> HtmlElement
        readyView.Render(sb)
        strings[n] <- sb.ToString()
        strings

    let combine (prerenderedParts: string[]) (holes: HtmlElement[]) =
        { new HtmlElement with
            member this.Render(sb) =
                for i in 0..holes.Length-1 do
                    sb.Append(prerenderedParts[i]) |> ignore
                    holes[i].Render(sb)
                sb.Append(prerenderedParts[prerenderedParts.Length-1]) |> ignore
        }

module OxpeckerTweakedCommon =

    open OxpeckerHelpers

    let getView =
        let prerenderedHead =
           (fun (header: HtmlElement) (children: HtmlElement) ->
                html() {
                    body(style="width: 800px; margin: 0 auto") {
                        h1(style="text-align: center; color: red") { header }
                        ul(id="list", class'="myList", lang="en", translate=false, spellcheck=false) {
                            children
                        }
                    }
                } :> HtmlElement
           ) |> prerender
        let prerenderedLi =
            (fun (trustedHtml: HtmlElement) (untrustedHtml: HtmlElement) ->
                li() {
                    p(class'="goodItem")
                        .attr("data-value", "12345")
                        .attr("onclick", "alert('Hello')") {
                            trustedHtml
                        }
                    br()
                    span(class'="badItem") { untrustedHtml }
                } :> HtmlElement
            ) |> prerender

        fun (num: int) (header: string) (trustedHtml: string) (untrustedHtml: string) ->
            combine prerenderedHead [|
                RegularTextNode header
                __(){
                    for _ in 1..num do
                        combine prerenderedLi [|
                            RawTextNode trustedHtml
                            RegularTextNode untrustedHtml
                        |]
                }
            |]

module OxpeckerTweakedDynamic =

    let renderToString () =
        OxpeckerTweakedCommon.getView 3 "Header" "<h2>Raw HTML</h2>" "<script>alert('Danger!')</script>" |> Render.toString