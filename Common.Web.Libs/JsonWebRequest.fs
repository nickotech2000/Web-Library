namespace Common.Web.Libs

open System
open System.IO
open System.Collections
open System.Net
open System.Threading
open System.Threading.Tasks
open System.Text

type JsonWebRequest() =
    member this.LangSpec = "F# 4.0"
    static member Instance = new JsonWebRequest()

    member this.GetRaw(jsonUrl : string) =
        if String.IsNullOrWhiteSpace(jsonUrl) then raise (System.NullReferenceException(""))
        let request = HttpWebRequest.Create(jsonUrl) :?> HttpWebRequest
        let response = request.GetResponseAsync().Result :?> HttpWebResponse
        let responseStream = response.GetResponseStream()
        let reader = new StreamReader(responseStream, System.Text.Encoding.UTF8)
        reader.ReadToEndAsync()

    member this.PostRawWithPostedData(jsonUrl : string, postedJsonData : string) =
        if String.IsNullOrWhiteSpace(jsonUrl) then raise (System.NullReferenceException(""))
        let request = HttpWebRequest.Create(jsonUrl) :?> HttpWebRequest
        request.Method <- "POST"
        request.ContentType <- "application/json; charset=utf-8"
        request.MediaType <- "application/json"
        request.Accept <- "application/json"
        let streamWriter = new StreamWriter(request.GetRequestStream())
        streamWriter.Write(postedJsonData)
        streamWriter.Flush()
        let response = request.GetResponse()
        let responseStream = response.GetResponseStream()
        let reader = new StreamReader(responseStream, System.Text.Encoding.UTF8)
        reader.ReadToEndAsync()
