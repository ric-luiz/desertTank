using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject guiaCamera;
	private float[] rotacaoDirecao;	//Diz para que lado esta rodando. Server para fazer a compensação da rotação do canhão
	
	void Start () {
		rotacaoDirecao = new float[2];
		rotacaoDirecao [1] = 25;
	}

	void FixedUpdate(){		
		if (Input.GetKey (KeyCode.Q)) {
			guiaCamera.transform.RotateAround (guiaCamera.transform.parent.position, guiaCamera.transform.up, 25.0f * Time.deltaTime);
			rotacaoDirecao [0] = 1.0f;
		} else if (Input.GetKey (KeyCode.E)) {
			guiaCamera.transform.RotateAround (guiaCamera.transform.parent.position, guiaCamera.transform.up, -25.0f * Time.deltaTime);
			rotacaoDirecao [0] = -1.0f;
		} else {			
			rotacaoDirecao [0] = 0;
		}
	}

	void LateUpdate () {		
		transform.eulerAngles = new Vector3 (
			transform.eulerAngles.x,
			guiaCamera.transform.eulerAngles.y,
			transform.eulerAngles.z);

		transform.position = guiaCamera.transform.position;
	}

	public float[] getDirecaoRotacao ()
	{
		return rotacaoDirecao;
	}
}
