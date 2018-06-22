using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "genaralskar/Current Player State")]
public class SO_CurrentPlayerState : ScriptableObject {

	public enum CurrentPlayerState{ Plane, Robot, Car }

	public CurrentPlayerState playerState;

}
