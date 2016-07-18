using UnityEngine;
using System.Collections;

public class CanhaoController : Canhao {
	protected override void setarDirecaoRotacao ()
	{
		direcaoCorpo = corpo.GetComponent<PlayerController> ().getDirecaoRotacao ();
	}
}
