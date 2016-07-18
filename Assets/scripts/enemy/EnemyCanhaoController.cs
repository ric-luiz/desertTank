using UnityEngine;
using System.Collections;

public class EnemyCanhaoController : Canhao {
	private GameObject target;

	public override void Start ()
	{
		angularSpeed = 20.0f;
		target = GameObject.FindGameObjectWithTag ("Player");
		base.Start ();
	}

	protected override void FixedUpdate ()
	{		
		position = target.transform.position - transform.position;
		setarRotacaoBase (position);
		setarRotacaoCanhao (position);
	}

	protected override void setarDirecaoRotacao ()
	{		
		direcaoCorpo = corpo.GetComponent<EnemyController> ().getDirecaoRotacao ();
	}
}
