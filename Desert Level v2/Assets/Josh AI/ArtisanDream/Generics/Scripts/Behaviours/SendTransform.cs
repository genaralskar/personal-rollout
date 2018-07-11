using UnityEngine;

public class SendTransform : MonoBehaviour
{
    public GameAction Send;

    private void Start()
    {
        Send.Call(transform);
    }
}