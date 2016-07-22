using UnityEngine;
using System.Collections;

public class EnemyTiroController : Tiro {
	public GameObject canhaoObject;
	public float distanciaAtirar;
	private Transform PlayerObject;
	private EnemyCanhaoController canhaoScript;

	protected override void Start ()
	{
		canhaoScript = canhaoObject.GetComponent<EnemyCanhaoController> ();
		PlayerObject = GameObject.FindGameObjectWithTag ("Player").transform;
		base.Start ();
	}

	protected override void controller ()
	{		
		if (permissaoParaAtirar() && timeFire < fireRate)
		{
			tiro.SetActive(true);
			Atirar();
			audioTiro.atirar ();
			fireRate = 0;
		} 			
	}

	bool permissaoParaAtirar(){
		bool baseC = canhaoScript.getVerificarRotacoes()[0];
		bool canhao = canhaoScript.getVerificarRotacoes () [1];
		float distancia = Vector3.Distance (transform.position, PlayerObject.position);

		if(baseC && canhao && (distancia <= distanciaAtirar)){
			canhaoScript.setVerificarRotacoes (false);	//faz com que o programa tenha que verificar novamente se o canhão esta na posição correta para atirar
			return true;
		}

		return false;
	}
}
