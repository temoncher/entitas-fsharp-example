namespace Scripts

open UnityEngine
open Entitas

type GameController() =
    inherit MonoBehaviour()

    [<DefaultValue>]
    [<SerializeField>]
    val mutable private globalConfig: GlobalConfig

    member this.CreateSystems (contexts: Contexts) : Systems =
        Feature("Game").Add(HelloWorldInitializeSystem(contexts))

    member this.SetGlobals (contexts: Contexts): unit =
      contexts.game.SetGlobalConfig(this.globalConfig) |> ignore

    member this.Start() : unit =
        let contexts = Contexts.sharedInstance

        this.SetGlobals(contexts)
        this.CreateSystems(contexts).Initialize()
