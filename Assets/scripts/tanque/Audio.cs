using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	/* 
	 	Playlist:
		0:ligarMotor;
		1:celeraçãoMotor;
		2:motorParado;
	*/

	private AudioClip[] sfxMotor;


	private AudioSource source;
	private float tempoTransicao;

	public Audio (AudioClip[] sfxMotor, AudioSource fonte)
	{
		this.sfxMotor = sfxMotor;
		source = fonte;
		source.clip = sfxMotor [0];
		source.Play ();
	
	}

    public void motorLigado()
    {

        if (!source.isPlaying)
        {
            source.loop = true;
            source.clip = sfxMotor[2];
            source.Play();
        }
    }

    public void acelerar()
    {
        source.loop = false;
        source.clip = sfxMotor[1];
        if (!source.isPlaying)
        {
            source.Play();
        }
        if (!source.isPlaying)
        {
            source.loop = true;
            source.clip = sfxMotor[0];
            source.Play();
        }
    }
}
