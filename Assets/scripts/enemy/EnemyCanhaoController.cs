using UnityEngine;
using System.Collections;

public class EnemyCanhaoController : Canhao {
	private GameObject target;
	private bool[] verificarRotacoes; //quando o canhao e a base atingirem a rotação vai ser setado para tru as 2 posições desse array

	public override void Start ()
	{
		angularSpeed = 20.0f;
		verificarRotacoes = new bool[2];
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

	//Seta para true caso a base tenha atingido o seu destino, ou seja, estã parada
	protected override void atingiuRotacaoBase ()
	{
		verificarRotacoes [0] = true;
	}

	//Seta para true caso o canhão tenha atingido o seu destino, ou seja, estã parado
	protected override void atingiuRotacaoPonta ()
	{
		verificarRotacoes [1] = true;
	}

	public bool[] getVerificarRotacoes(){
		return verificarRotacoes;
	}

	public void setVerificarRotacoes(bool verificarRotacoes){
		this.verificarRotacoes[0] = verificarRotacoes;
		this.verificarRotacoes[1] = verificarRotacoes;
	}
}
