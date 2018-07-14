using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;

namespace genaralskar
{
	public class CameraShake : MonoBehaviour
    {
    	private float currentShake;
    	public CinemachineVirtualCamera cam;
	    private CinemachineBasicMultiChannelPerlin camNoise;
    	[Tooltip("Modifyier for the amount of shake")]
    	public float amplitudeMod = 1;
		[Tooltip("Camera shake will be clamped between 0 and this value")]
	    public float maxShake = 1;
		[Tooltip("Modifier for how long the shake will last")]
	    public float shakeDuration = 1;

	    private void Start()
	    {
			camNoise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		    if (camNoise == null)
		    {
			    Debug.Log("No noise profile set on the virtual camera");
		    }
	    }

	    public void AddShake(float shakeAmount)
    	{
    		currentShake += shakeAmount;
    		currentShake = Mathf.Clamp(currentShake, 0, maxShake);
    		StopAllCoroutines();
    		StartCoroutine(ShakeCounter());
    	}
    
    	public void SetShake(float shakeAmount)
    	{
    		currentShake = shakeAmount;
		    currentShake = Mathf.Clamp(currentShake, 0, maxShake);
    		StopAllCoroutines();
    		StartCoroutine(ShakeCounter());
    	}
    	
    	private IEnumerator ShakeCounter()
	    {
		    float shakeTimerStart = currentShake * shakeDuration;
		    currentShake *= shakeDuration;
		    float shakeTimer = shakeTimerStart;
    		while (shakeTimer > 0)
    		{
    			shakeTimer -= Time.deltaTime;
    			currentShake -= Time.deltaTime;
    			Shake(GetExponential(shakeTimer / shakeTimerStart) * currentShake / shakeTimerStart);
    			yield return new WaitForEndOfFrame();
    		}
    		currentShake = 0;
    		Shake(0);
    	}
    
    	private void Shake(float shakeAmount)
    	{
    		camNoise.m_AmplitudeGain = shakeAmount * amplitudeMod;
    	}
    
    	private float GetExponential(float num)
    	{
    		return num * num;
    	}
    }
}
