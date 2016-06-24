using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	/* 
	 	Playlist:
		0:ligarMotor;
		2:motorParado;
	*/
	private AudioClip[] sfxMotor;

	private AudioSource source;
	private float passo=1.0f;

	public Audio (AudioClip[] sfxMotor, AudioSource source)
	{
		this.sfxMotor = sfxMotor;
		this.source = source;
		source.clip = sfxMotor [0];
		source.Play ();
	
	}

    public void motorLigado()
    {

        if (!source.isPlaying)
        {
            source.loop = true;
            source.clip = sfxMotor[1];
            source.Play();
		 }
    }

	public void acelerar(){
		if (passo < 1.3f) {
			passo += 0.1f*Time.deltaTime;
			source.pitch = passo;
		}
	}

	public void desacelerar(){
		if (passo < 1.5f && passo >0.9f) {
			passo -= 0.35f*Time.deltaTime;
			source.pitch = passo;
		}
		
	}

}