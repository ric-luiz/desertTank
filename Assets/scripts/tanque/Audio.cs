using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
	/* 
	 	Playlist:
		0:ligarMotor;
		1:motorParado;
	*/
	private AudioClip[] sfxMotor;

	private AudioSource source;
	private float passo = 1;

	public Audio (AudioClip[] sfxMotor, AudioSource source)
	{
		this.sfxMotor = sfxMotor;
		this.source = source;
		source.clip = sfxMotor [0];
		source.volume = 0.10f;
		source.Play ();
	}

	public void motorLigado ()
	{
		if (!source.isPlaying) {
			source.loop = true;
			source.clip = sfxMotor [1];
			source.volume = 0.10f;
			source.Play ();
		}
	}

	public void acelerar ()
	{
		if (passo < 1.3f) {
			passo += 0.1f * Time.deltaTime;
			source.pitch = passo;
		}
	}

	public void desacelerar ()
	{
		if (passo < 1.5f && passo > 0.99f) {
			passo -= 0.35f * Time.deltaTime;
			source.pitch = passo;
		}
		
	}

}