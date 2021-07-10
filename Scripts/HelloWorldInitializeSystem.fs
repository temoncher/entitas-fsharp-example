namespace Scripts

open UnityEngine
open Entitas

type HelloWorldInitializeSystem(contexts: Contexts) =
    interface IInitializeSystem with
        member this.Initialize() : unit =
            let message =
                contexts.game.globalConfig.value.initialMessage

            Debug.Log(message)
