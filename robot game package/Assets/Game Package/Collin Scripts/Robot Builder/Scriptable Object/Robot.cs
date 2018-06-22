using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(menuName = "genaralskar/Robot")]
public class Robot : ScriptableObject 
{

	public List<RobotPartBase> robotParts;

	public RobotBuilder builder;
	public RobotMakerV2 robotMaker;

	public float weight;
	public float armor;
	
	private List<CurrentGameObject> currentParts = new List<CurrentGameObject>(); //keeps track of currently instantiated parts

	public void BuildRobot()
	{
		if (builder != null)
		{
			weight = 0;
			armor = 0;

			foreach (var part in robotParts)
			{
				part.Construct(this, robotMaker.SnapPointOfPartType(part.partType));
			}
		}
	}

	public void UpdatePart(GameObject newPart, PartType partType)
	{
		foreach (var part in currentParts)
		{
			if (part.partType == partType) //if there is a part with the same part type
			{
				Debug.Log("Replacing " + part.currentObject + " with " + newPart);
				Destroy(part.currentObject);
				part.currentObject = newPart;
				Debug.Log("New part is " + part.currentObject);
				return;
			}
		}
		Debug.Log("Adding new entry of " + newPart + " to CurrentGameObjects");
		currentParts.Add(new CurrentGameObject(newPart, partType)); //if no matching part type, add to list of current parts
	}

	public void SwapPart(RobotPartBase newPart)
	{
		for (int i = 0; i < robotParts.Count; i++)
		{
			if (robotParts[i].partType == newPart.partType)
			{
				robotParts[i] = newPart;
				robotParts[i].Construct(this, robotMaker.SnapPointOfPartType(newPart.partType));
			}
		}
	}

	public RobotPartBase FindPartOfType(PartType type)
	{
		foreach (var part in robotParts)
		{
			if (part.partType == type)
			{
				return part;
			}
		}

		Debug.Log("No part of type " + type + " found");
		return null;
	}
	
}

public class CurrentGameObject
{
	public GameObject currentObject;
	public PartType partType;

	public CurrentGameObject(GameObject obj, PartType part)
	{
		this.currentObject = obj;
		this.partType = part;
	}
}