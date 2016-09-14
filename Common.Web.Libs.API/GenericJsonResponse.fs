namespace Common.Web.Libs.API

open System
open System.IO
open System.Collections
open System.Net
open System.Threading
open System.Threading.Tasks
open System.Text

type GenericJsonResponse<'T when 'T : null>() =
    member this.DescriptionClass = "Generic Response for Json"
    member val Code = 0 with get, set
    member val IsSuccess = false with get, set
    member val Result : 'T = null with get, set
    member val Message = String.Empty with get, set
    member val ErrorStackTrace = String.Empty with get, set
    member val DetailDescription = String.Empty with get, set
    member val DetailLog = String.Empty with get, set
