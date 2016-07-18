using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Corpo : MonoBehaviour
{
		
	protected Rigidbody rb;
	public int potencia;
	public int speed;
	public float rotacao;
	protected int[] rotacaoDirecao;
	//Recebe o valor da rotacao e a direcao da rotacao

	public AudioClip[] sfxMotor;
	public Audio audio;

	public virtual void Start ()
	{
		audio = new Audio (sfxMotor, GetComponent<AudioSource> ());
		rb = GetComponent<Rigidbody> ();
		speed *= potencia;
		rotacaoDirecao = new int[2];
		rotacaoDirecao [1] = (int)rotacao;	//recebendo o valor da rotacao
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
			rotacaoDirecao [0] = 1;
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up * rotacao * Time.deltaTime);
			rotacaoDirecao [0] = -1;
		} else {
			rotacaoDirecao [0] = 0;
		}
	}

	public int[] getDirecaoRotacao ()
	{
		return rotacaoDirecao;
	}
}
