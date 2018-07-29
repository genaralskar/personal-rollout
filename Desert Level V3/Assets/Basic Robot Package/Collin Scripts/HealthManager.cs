using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace genaralskar
{
	[CreateAssetMenu(menuName = "genaralskar/Health Manager")]
	public class HealthManager : ScriptableObject
	{
		public FloatConstant currentHealth;
	
		public UnityAction<float> healthUpdate = delegate {  };
		public UnityAction healthAtZero = delegate {  };
	
		public void AddHealth(float amount)
		{
		//	Debug.Log("Adding " + amount + " Health");
			currentHealth.FloatValue += amount;
			Debug.Log("CurrentHealth = " + currentHealth.FloatValue);
			currentHealth.FloatValue = Mathf.Clamp(currentHealth.FloatValue, 0, 1);
	
			if (currentHealth.FloatValue <= 0f)
			{
				healthAtZero();
				return;
			}
			
			healthUpdate(currentHealth.FloatValue);
//			Debug.Log("Sending Health Update Action");	
		}
	
		public void SetHealth(float amount)
		{
			currentHealth.FloatValue = amount;
			currentHealth.FloatValue = Mathf.Clamp(currentHealth.FloatValue, 0, 1);
			
			if (currentHealth.FloatValue < .1f)
			{
				Debug.Log("health enough to kill");
				currentHealth.FloatValue = 0;
				healthAtZero();
			}
			
			healthUpdate(currentHealth.FloatValue);
		//	Debug.Log("Sending Health Update Action");
		}
		
		public void AddHealth(int amount)
		{
			AddHealth((float)amount / 100);
		}
		
		public void SetHealth(int amount)
		{
			SetHealth((float)amount / 100);
		}

		
	}
}


