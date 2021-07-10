namespace Scripts

open UnityEngine
open Entitas

type LogSystem() =
    interface IExecuteSystem with
        member this.Execute() : unit = Debug.Log("Hello from F#")
