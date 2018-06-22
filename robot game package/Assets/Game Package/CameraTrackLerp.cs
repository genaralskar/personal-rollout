using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackLerp : MonoBehaviour
{
	public Transform objectToTrack;
	[Range(0, 1)] public float lerpAmount = 0.5f;

	private Vector3 offset;

	private void Start()
	{
		offset = transform.position - objectToTrack.position;
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		//Vector3 newPos = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, objectToTrack.position.z + offset.z, lerpAmount * Time.deltaTime));
		Vector3 newPos = Vector3.Lerp(transform.position, objectToTrack.position + offset, lerpAmount);
		transform.position = newPos;
	}

	

}
