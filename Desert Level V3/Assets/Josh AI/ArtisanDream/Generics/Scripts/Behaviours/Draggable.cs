using UnityEngine;

//Made By Anthony Romrell
public class Draggable : MonoBehaviour, IDrag
{
    private Vector3 offsetPosition;

    public void OnMouseDown()
    {
        offsetPosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
    }
}