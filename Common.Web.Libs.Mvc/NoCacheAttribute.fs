namespace Common.Web.Libs

open System
open System.IO
open System.Linq
open System.Globalization
open System.IO.Compression
open System.Collections
open System.Text
open System.Web.Mvc
open System.Web

type NoCacheAttribute=
    inherit ActionFilterAttribute

    override this.OnActionExecuting(filterContext) =

        filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1.0))
        filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false)
        filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches)
        filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        filterContext.HttpContext.Response.Cache.SetNoStore()

        ()
