using UnityEngine;
using System.Collections;

public class EnemyController : Corpo {
	private GameObject guia;
	private Quaternion rotacaoPosicao;
	private Vector3 posicao;
	private Transform target;

	public override void Start(){		
		guia = transform.Find("guia").gameObject;
		base.Start ();
	}

	protected override void controlador(){		

		target = guia.GetComponent<moveTo> ().goal.transform;
		posicao = target.position - transform.position;
		posicao.y = 0;

		rotacaoPosicao = Quaternion.LookRotation (posicao);
		transform.rotation = Quaternion.Slerp (transform.rotation,rotacaoPosicao, Time.deltaTime * rotacao);

		if(Vector3.Distance(transform.position,target.position) >= guia.GetComponent<NavMeshAgent>().stoppingDistance){
			rb.AddForce (transform.forward * speed * Time.deltaTime);	
		}			
	}
}
