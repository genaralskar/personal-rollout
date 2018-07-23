using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioEvent/Play Random Audio")]
public class PlayRandomAudio : AudioEvent
{
	
	public AudioClip[] clips;
	
	public RangedFloat volume;
	public RangedFloat pitch;
	
	
	
	public override void Play(AudioSource source)
	{
		if (clips.Length == 0)
			return;

		source.clip = clips[Random.Range(0, clips.Length)];
		source.volume = Random.Range(volume.minValue, volume.maxValue);
		source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
		source.Play();
	}
}
