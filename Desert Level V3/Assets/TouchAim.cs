using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class TouchAim : MonoBehaviour
{
	private Touch aimTouch;
	public LayerMask layerMask;
	public GameEvent Event;
	
	void Update () {
		if (Input.touchCount > 0 || Input.GetMouseButton(0))
		{

			if (!Input.GetMouseButton(0))
			{
				aimTouch = Input.GetTouch(Input.touchCount - 1);
			}		
//			Debug.Log("touching");
			//StartCoroutine(Aim());
			Vector3 worldPoint;
			if (Input.GetMouseButton(0) || aimTouch.phase != TouchPhase.Ended)
			{
				RaycastHit hit;
				Ray ray;
				if (Input.GetMouseButton(0))
				{
					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				}
				else
				{
					ray = Camera.main.ScreenPointToRay(aimTouch.position);
				}
				
				if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
				{
					worldPoint = hit.point;
					Vector3 touchPos = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
			
//					Debug.DrawLine(worldPoint, worldPoint + (Vector3.up * 10), Color.red);
//					Debug.Log(hit.collider.gameObject);
					//aim to new touch location
					transform.LookAt(touchPos);
				}
				
				if (!Input.GetMouseButton(0))
				{
					Debug.Log(aimTouch.phase);
				}
				
			}
			else
			{
//				Debug.Log("touch end");
				transform.rotation = Quaternion.identity;
			}

			if (Event != null)
			{
				Event.Raise();
			}
				
			
		}
	}

	private Vector3 CameraRay()
	{

		return Vector3.zero;
	}
}
