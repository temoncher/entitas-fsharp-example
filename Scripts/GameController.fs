namespace Scripts

open UnityEngine
open Entitas

type GameController() =
    inherit MonoBehaviour()

    [<DefaultValue>]
    [<SerializeField>]
    val mutable private globalConfig: GlobalConfig

    [<DefaultValue>]
    val mutable private _systems: Systems;

    member this.CreateSystems (contexts: Contexts) : Systems =
        Feature("Game")
            .Add(HelloWorldInitializeSystem(contexts))
            .Add(LoggersSystem(contexts))

    member this.SetGlobals (contexts: Contexts): unit =
      contexts.game.SetGlobalConfig(this.globalConfig) |> ignore

    member this.Start() : unit =
        let contexts = Contexts.sharedInstance

        this.SetGlobals(contexts)
        this._systems <- this.CreateSystems(contexts)

        this._systems.Initialize()

    member this.Update() : unit =
        this._systems.Execute();
