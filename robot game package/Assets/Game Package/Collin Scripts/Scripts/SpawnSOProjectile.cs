using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class SpawnSOProjectile : MonoBehaviour
    {
    	public SO_Projectile projectile;
    	private bool canSpawn = true; //used for cooldown

	    public int layerIndex = 1; //find a way to use layermasks and invert it
    
    	public void Spawn()
	    {
    		if (canSpawn)
    		{
    			StopAllCoroutines();
    			StartCoroutine(SpawnTimer());

			    //get from pool, set layer index, if parent, set parent
			    GameObject tempObj = projectile.PooledObject.GetObjectFromPool(this.transform.position, this.transform.rotation, layerIndex);
			    tempObj.GetComponent<ProjectileController>().LifetimeDisable(projectile.ProjectileLifetime);
			    if (projectile.Parent)
			    {
				    tempObj.transform.SetParent(transform);
			    }
				else
				{
					tempObj.transform.SetParent(null);
				}
		    }
    	}
    
    	private IEnumerator SpawnTimer()
    	{
    		canSpawn = false;
    		yield return new WaitForSeconds(projectile.Cooldown);
    		canSpawn = true;
    	}
    }
}

