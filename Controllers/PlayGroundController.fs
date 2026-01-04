namespace apitest.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Http
// open apitest


[<ApiController>]
[<Route("[controller]")>]
type PlayGroundController (logger : ILogger<PlayGroundController>) =
    inherit ControllerBase()

    [<HttpGet("list")>]
    [<ProducesResponseType(typeof<float array>, StatusCodes.Status200OK)>]
    member this.List(n: int) : IActionResult =
        let rng = System.Random()
        let res =
            [|
            for index in 0..n ->
                (index, rng.NextDouble() * 100.0)
            |]

        logger.LogInformation($"Generating {n} random weather data.")

        this.Ok(res) :> IActionResult

    [<HttpGet("echo")>]
    [<ProducesResponseType(typeof<string>, StatusCodes.Status200OK)>]
    member this.Echo(message: string) : Task<IActionResult> =
        task {
            do! Task.Delay(500)
            logger.LogInformation($"Echoing message: {message}")
            return this.Ok(message) :> IActionResult
        }
