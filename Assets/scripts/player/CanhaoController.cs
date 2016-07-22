using UnityEngine;
using System.Collections;

public class CanhaoController : Canhao {
	protected override void setarDirecaoRotacao ()
	{
		direcaoCorpo = Camera.main.GetComponent<CameraController> ().getDirecaoRotacao();
	}
}
