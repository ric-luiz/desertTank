using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioTiro : MonoBehaviour {

	public AudioClip[] sfxTiro;
	private AudioSource source;
	private float pitch = 0.5f;

	public AudioTiro(AudioClip[] sfxTiro, AudioSource source){
		this.source = source;
		this.sfxTiro = sfxTiro;
	}

	public void atirar(){
		source.clip = sfxTiro [0];
		source.pitch = pitch;
		source.Play ();
	}

	public void tiroAtingido(){
		source.clip = sfxTiro [0];
		source.pitch=pitch;
		source.Play ();
	}
}
