using UnityEngine;
using System.Collections;

public class Corpo : MonoBehaviour
{
    private Rigidbody rb;
    public int potencia;
    public int speed;
    public int rotacao;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed *= potencia;
    }

    void Update()
    {
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
