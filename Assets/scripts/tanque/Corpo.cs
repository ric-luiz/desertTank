using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Corpo : MonoBehaviour
{
    private Rigidbody rb;
    public int potencia;
    public int speed;
    public int rotacao;

	public AudioClip[] sfxMotor;
	private Audio audio;

    void Start()
    {
		audio = new Audio (sfxMotor,GetComponent<AudioSource>());
        rb = GetComponent<Rigidbody>();
        speed *= potencia;
    }

    void Update()
    {
		audio.motorLigado ();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotacao * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotacao * Time.deltaTime);
        }
    }
}
