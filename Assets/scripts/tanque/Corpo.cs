using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Corpo : MonoBehaviour
{
		
	protected Rigidbody rb;
	public int potencia;
	public int speed;
	public float rotacao;
	protected float[] rotacaoDirecao;
	//Recebe o valor da rotacao e a direcao da rotacao

	public AudioClip[] sfxMotor;
	public Audio audio;

	public virtual void Start ()
	{
		audio = new Audio (sfxMotor, GetComponent<AudioSource> ());
		rb = GetComponent<Rigidbody> ();
		speed *= potencia;
		rotacaoDirecao = new float[2];
		rotacaoDirecao [1] = rotacao;	//recebendo o valor da rotacao
	}


	public void FixedUpdate ()
	{
		audios ();
		controlador ();
	}

	public void audios(){
		audio.motorLigado ();
	}

	protected virtual void controlador(){
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (transform.forward * speed * Time.deltaTime);
			audio.acelerar ();
		} else if (Input.GetKey (KeyCode.S)) {
			rb.AddForce (-transform.forward * speed * Time.deltaTime);
			audio.acelerar ();
		} else {
			audio.desacelerar ();
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up * -rotacao * Time.deltaTime);
			rotacaoDirecao [0] = 1.0f;
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up * rotacao * Time.deltaTime);
			rotacaoDirecao [0] = -1.0f;
		} else {
			rotacaoDirecao [0] = 0;
		}
	}

	public float[] getDirecaoRotacao ()
	{
		return rotacaoDirecao;
	}
}
