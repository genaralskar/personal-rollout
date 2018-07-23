using UnityEngine;

[CreateAssetMenu(fileName = "GameBrain")]
public class GameBrain : ScriptableObject
{
    public GameStateBase CurrentState;
}