using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "genaralskar/Robot Part Base")]
public class RobotPartBase : ScriptableObject
{
	public GameObject part;
	protected GameObject instancePart;

	public float weight = 1;
	public float armor = 1;

	public PartType partType;

	public virtual void Construct(Robot robot, Transform snapPoint)
	{	
		GameObject newObj = Instantiate(part);
		Transform partT = newObj.transform;
		Debug.Log(snapPoint);

		partT.SetParent(snapPoint);
		partT.localPosition = Vector3.zero;
		partT.localRotation = Quaternion.identity;
		partT.localScale = Vector3.one;
		instancePart = newObj;

		robot.weight += weight;
		robot.armor += armor;
		
		robot.UpdatePart(newObj, partType);
	}
}
