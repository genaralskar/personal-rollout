using System.Collections.Generic;
using UnityEngine;

public class RobotMakerV2 : MonoBehaviour
{

	public Robot robotToBuild;
	public List<SnapPointType> snapPoints;

	public void BuildRobot()
	{
		foreach (var point in snapPoints)  //check if snap points partType == a part's partType
		{
			foreach (var part in robotToBuild.robotParts)
			{
				if (part.partType == point.partType)
				{
					print("Constructing Part!");
					part.Construct(robotToBuild, point.snapPoint);
				}
			}
		}
	}

	public void SwapPart(RobotPartBase newPart)
	{
		robotToBuild.SwapPart(newPart);
	}
	
	public Transform SnapPointOfPartType(PartType part)
	{
		foreach (var point in snapPoints)
		{
			if (point.partType == part)
			{
				return point.snapPoint;
			}
		}
		Debug.Log("Not snap point of part type: " + part + " found.");
		return null;
	}

	

	private void Start()
	{
		robotToBuild.robotMaker = this;
		BuildRobot();
	}
}


[System.Serializable]
public class SnapPointType
{
	public Transform snapPoint;
	public PartType partType;
}
