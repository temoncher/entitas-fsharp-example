namespace Scripts

open UnityEngine
open Entitas

type GameController() =
    inherit MonoBehaviour()

    let createSystems () : Systems =
        Feature("Game").Add(HelloWorldInitializeSystem())

    member this.Start() : unit = createSystems().Initialize()
