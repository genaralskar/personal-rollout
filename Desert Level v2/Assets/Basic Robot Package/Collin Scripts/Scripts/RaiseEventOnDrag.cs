using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace genaralskar
{
	public class RaiseEventOnDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
	
		public GameEvent[] Events;
		
		public void OnPointerDown(PointerEventData eventData)
		{
			StartCoroutine(RaiseLoop());
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			StopAllCoroutines();
		}

		private IEnumerator RaiseLoop()
		{
			while (true)
			{
				foreach (var e in Events)
				{
					e.Raise();
				}
				
				yield return new WaitForEndOfFrame();
			}
		}

		
	}
	
}

