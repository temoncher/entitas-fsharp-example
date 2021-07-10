namespace Scripts

open UnityEngine
open Entitas

type HelloWorldInitializeSystem() =
    interface IInitializeSystem with
        member this.Initialize() : unit = Debug.Log("Hello from F#")
