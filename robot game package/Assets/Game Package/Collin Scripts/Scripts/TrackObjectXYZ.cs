using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class TrackObjectXYZ : MonoBehaviour {
	
		public bool trackX;
		public bool trackY;
		public bool trackZ;
	
		public Transform objectToTrack;
		
		private Vector3 offset;
	
	
		// Use this for initialization
		private void Start ()
		{
			offset = objectToTrack.position - transform.position;
		}
		
		// Update is called once per frame
		private void Update ()
		{
	
			float trackXPos = transform.position.x;
			float trackYPos = transform.position.y;
			float trackZPos = transform.position.z;
			
			
			if (trackX)
			{
				trackXPos = objectToTrack.position.x - offset.x;
			}
	
			if (trackY)
			{
				trackYPos = objectToTrack.position.y - offset.y;
			}
	
			if (trackZ)
			{
				trackZPos = objectToTrack.position.z - offset.z;
			}
			
			Vector3 trackVector = new Vector3(trackXPos, trackYPos, trackZPos);
	
			transform.position = trackVector;
		}
	}
}

