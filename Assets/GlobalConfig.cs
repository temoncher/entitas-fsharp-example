using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, CreateAssetMenu]
public class GlobalConfig : ScriptableObject {
  public string initialMessage = "Hello world!";
}