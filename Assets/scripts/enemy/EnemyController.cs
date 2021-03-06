﻿using UnityEngine;
using System.Collections;

public class EnemyController : Corpo {
	private GameObject guia;
	private Quaternion rotacaoPosicao;
	private Vector3 rotacaoAUX;		//Variavel serve para testarmos para qual lado o tanque esta virando
	private Vector3 posicao;
	private Transform target;
	private GameObject barraRecursos;

	public override void Start(){		
		guia = transform.Find("guia").gameObject;
		barraRecursos = transform.GetChild (2).gameObject;
		base.Start ();
	}

	void Update(){
		if(barraRecursos.GetComponent<BarraRecursos>().getVida() <= 0){
			Destroy (gameObject,5);
			gameObject.SetActive(false);
		}

		if(this.speed != 0 && barraRecursos.GetComponent<BarraRecursos>().getCombustivel() <= 0){
			this.speed = 0;
		}
	}

	protected override void controlador(){		

		target = guia.GetComponent<moveTo> ().getGoal();
		posicao = target.position - transform.position;
		posicao.y = 0;

		rotacaoPosicao = Quaternion.LookRotation (posicao);
		transform.rotation = Quaternion.Slerp (transform.rotation,rotacaoPosicao, Time.deltaTime * rotacao);

		if (Vector3.Distance (transform.position, target.position) >= guia.GetComponent<NavMeshAgent> ().stoppingDistance) {
			rb.AddForce (transform.forward * speed * Time.deltaTime);
			recursos.retirarCombustivel (recursos.gastoCombustivelMax*Time.deltaTime);
		} else {
			recursos.retirarCombustivel (recursos.gastoCombustivelMin*Time.deltaTime);
		}

		verificarLadoRotacao (rotacaoAUX);
		rotacaoAUX = transform.eulerAngles;
	}

	private void verificarLadoRotacao(Vector3 rotacao)
	{
		if (rotacao.y >= transform.eulerAngles.y) {
			rotacaoDirecao [0] = 1.0f;
		} else if (rotacao.y <= transform.eulerAngles.y) {
			rotacaoDirecao [0] = -1.0f;
		} else {
			rotacaoDirecao [0] = 0;
		}
	}
}
