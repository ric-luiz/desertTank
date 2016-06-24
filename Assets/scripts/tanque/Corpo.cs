<<<<<<< HEAD
﻿	using UnityEngine;
	using System.Collections;
	using UnityEngine.Audio;

	public class Corpo : MonoBehaviour
	{
		
	    private Rigidbody rb;
	    public int potencia;
	    public int speed;
	    public int rotacao;
		private static int[] rotacaoDirecao;	//Recebe o valor da rotacao e a direcao da rotacao

		public AudioClip[] sfxMotor;
		private Audio audio;

	    void Start()
	    {
			audio = new Audio (sfxMotor,GetComponent<AudioSource>());
	        rb = GetComponent<Rigidbody>();
	        speed *= potencia;
			rotacaoDirecao = new int[2];
			rotacaoDirecao[1] = rotacao;	//recebendo o valor da rotacao
	    }


	    void FixedUpdate()
	        
	    {
	        audio.motorLigado();

			if (Input.GetKey(KeyCode.W))
	        {
				rb.AddForce (transform.forward * speed * Time.deltaTime);
				audio.acelerar ();
	        }

			else if (Input.GetKey(KeyCode.S))
	        {
	            rb.AddForce(-transform.forward * speed * Time.deltaTime);
				audio.acelerar ();
	        }

			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (Vector3.up * -rotacao * Time.deltaTime);
				rotacaoDirecao[0] = 1;
			} else if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (Vector3.up * rotacao * Time.deltaTime);
				rotacaoDirecao[0] = -1;
			} else {
				rotacaoDirecao[0] = 0;
			}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
				audio.desacelerar ();
			}
	    }

		public static int[] getDirecaoRotacao(){
			return rotacaoDirecao;
		}		
	}
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Corpo : MonoBehaviour
{
    private Rigidbody rb;
    public int potencia;
    public int speed;
    public int rotacao;
	private static int[] rotacaoDirecao;	//Recebe o valor da rotacao e a direcao da rotacao

	public AudioClip[] sfxMotor;
	private Audio audio;

    void Start()
    {
		audio = new Audio (sfxMotor,GetComponent<AudioSource>());
        rb = GetComponent<Rigidbody>();
        speed *= potencia;
		rotacaoDirecao = new int[2];
		rotacaoDirecao[1] = rotacao;	//recebendo o valor da rotacao
    }
		
    void FixedUpdate()        
    {
        audio.motorLigado();
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime);
            audio.acelerar();                        
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
        }

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up * -rotacao * Time.deltaTime);
			rotacaoDirecao[0] = 1;
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up * rotacao * Time.deltaTime);
			rotacaoDirecao[0] = -1;
		} else {
			rotacaoDirecao[0] = 0;
		}
    }

	/// <summary>
	/// Recupera um array de int que contem na primeira posição a velovidade de rotação e no segundo a direção dessa rotação.
	/// </summary>
	/// <returns>Um int[] com 2 posições, contendo a rotação e a direção da rotação</returns>
	public static int[] getDirecaoRotacao(){
		return rotacaoDirecao;
	}		
}
>>>>>>> 436ad3ed633c45ee455d644dc4fbafb1e1d6d14d
