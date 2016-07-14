using UnityEngine;
using System.Collections;

public class EnemyController : Corpo {
	private GameObject guia;
	private Quaternion rotacaoPosicao;
	private Vector3 posicao;
	private Transform target;

	protected override void Start(){		
		guia = transform.Find("guia").gameObject;
		base.Start ();
	}

	protected override void controlador(){
		Debug.Log (rotacao);

		target = guia.GetComponent<moveTo> ().goal.transform;
		posicao = target.position - transform.position;
		posicao.y = 0;

		rotacaoPosicao = Quaternion.LookRotation (posicao);
		transform.rotation = Quaternion.Slerp (transform.rotation,rotacaoPosicao, Time.deltaTime * rotacao);
	}
}
