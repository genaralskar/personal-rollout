using UnityEngine;

public class ClickRunActionBehaviour : MonoBehaviour
{
    public GameAction GameAction;

    private void OnMouseDown()
    {
        GameAction.Call(transform);
    }
}