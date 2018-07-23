using UnityEngine;

[CreateAssetMenu(fileName = "RunGame")]
public class RunGame : GameStateBase
{
    public override void StartState()
    {
        Debug.Log("Start Playing Game");
    }

    public override void RunState()
    {
        Debug.Log("Playing Game");
    }
}