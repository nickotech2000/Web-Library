namespace Common.Web.Libs

open System
open System.IO
open System.Linq
open System.Globalization
open System.IO.Compression
open System.Collections
open System.Text
open System.Web.Mvc

type CompressAttribute =
    inherit ActionFilterAttribute
    override this.OnActionExecuting(filterContext) =
        let encodingAccepted = filterContext.HttpContext.Request.Headers.GetValues("Accept-Encoding").FirstOrDefault()
        let response = filterContext.HttpContext.Response
        match encodingAccepted with
        | (enc) when String.IsNullOrWhiteSpace(enc) -> ()
        | (enc) when String.Compare(enc.ToLowerInvariant(), "gzip", true, CultureInfo.InvariantCulture) = 0 ->
            response.AppendHeader("Content-encoding", "gzip")
            let filter = response.Filter
            let outputFilter = new GZipStream(filter, CompressionMode.Compress)
            response.Filter <- outputFilter :> Stream
            ()
        | (enc) when String.Compare(enc.ToLowerInvariant(), "deflate", true, CultureInfo.InvariantCulture) = 0 ->
            response.AppendHeader("Content-encoding", "defalte")
            let filter = response.Filter
            let outputFilter = new DeflateStream(filter, CompressionMode.Compress)
            response.Filter <- outputFilter :> Stream
            ()

        | _ -> ()

        ()
