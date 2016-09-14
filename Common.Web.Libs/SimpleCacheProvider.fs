
namespace Common.Web.Libs

open System
open System.Collections
open System.Collections.Generic
open System.Runtime.Caching


type SimpleCacheProvider() =
    member this.X = "Caching in F#"


    member this.Add<'T>(key : string, valuex :'T)  =
        let cacheInstance = System.Runtime.Caching.MemoryCache.Default

        let cache = if (cacheInstance.Contains(key))
                    then cacheInstance.Item (key) =  (valuex :> System.Object)
                    else cacheInstance.Add(key, (valuex :> System.Object),new DateTimeOffset(DateTime.Now.AddDays(float 1)))
        ()


    member this.Get<'T>(key: string) : 'T =
        let cacheInstance = System.Runtime.Caching.MemoryCache.Default
        let obj = cacheInstance.Get(key) :?> 'T
        obj


    member this.CacheValueType(key: string) : Type =
        let cacheInstance = System.Runtime.Caching.MemoryCache.Default
        let obj = cacheInstance.Get(key)
        obj.GetType()

    member this.Contains(key: string) : bool =
        System.Runtime.Caching.MemoryCache.Default.Contains(key)