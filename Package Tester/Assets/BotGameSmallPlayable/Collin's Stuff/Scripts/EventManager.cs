using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RoboRyanTron.Unite2017.Events;

namespace genaralskar
{
	public class EventManager : MonoBehaviour
	{
		[SerializeField]
		private GameEvent[] gameEvents;

		[SerializeField]
		private SO_CurrentPlayerState currentPlayerState; //change this when state changes

		public void ChangePlayerHeightState(string newState)
		{
			switch (newState)
			{
				case "Car":
					gameEvents[0].Raise();
					currentPlayerState.playerState = SO_CurrentPlayerState.CurrentPlayerState.Car;
					break;
				case "Robot":
					gameEvents[1].Raise();
					currentPlayerState.playerState = SO_CurrentPlayerState.CurrentPlayerState.Robot;
					break;
				case "Plane":
					gameEvents[2].Raise();
					currentPlayerState.playerState = SO_CurrentPlayerState.CurrentPlayerState.Plane;
					break;
				default:
					break;
			}

			gameEvents[3].Raise(); //calls PlayerChangeState event
		}

		public void RaiseEventByName(string name)
		{
			foreach(GameEvent i in gameEvents)
			{
				if(i.name == name)
				{
					i.Raise();
					return;
				}
			}
		}
	}
}

