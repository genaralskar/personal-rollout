using UnityEngine;

public abstract class GameStateBase : ScriptableObject, IGameState
{
    //public GameAction GameStateAction;
    public GameBrain Brain;

    public abstract void StartState();
    public abstract void RunState();
}

public interface IGameState
{
    void StartState();
    void RunState();
}