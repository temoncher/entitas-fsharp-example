namespace Scripts

open UnityEngine
open Entitas

type LoggersSystem(contexts: Contexts) =
    let loggersGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.LoggerData))

    interface IInitializeSystem with
        member this.Initialize() : unit =
            let e1 = contexts.game.CreateEntity()
            e1.AddLoggerData("Logger 1")
            let e2 = contexts.game.CreateEntity()
            e2.AddLoggerData("Logger 2")

    interface IExecuteSystem with
        member this.Execute() : unit =
            loggersGroup.GetEntities()
                |> Array.iter (fun logger -> Debug.Log($"{logger.loggerData.message}"))
