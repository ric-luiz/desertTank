using UnityEngine;
using System.Collections;

public class Bandeira : MonoBehaviour {

	private int[] parCalculos;	//variavel guarda os 2 numeros do calculo de adição
	private GameObject criadorBandeira;
	private GameObject barraRecursos;

	//As bandeiras devem ser inicializadas primeiro que outros elementos devido aos calculos
	void Awake (){
		parCalculos = new int[2];
		criarCalculos ();
	}

	void Start(){
		criadorBandeira = GameObject.FindWithTag ("criadorBandeira");
		barraRecursos = GameObject.FindWithTag ("barraRecursosPlayer");
	}

	public int[] getParCalculos(){
		return this.parCalculos;
	}

	//Somente calculos de somas são feitos e associados as bandeiras
	void criarCalculos(){
		int n1 = Random.Range (1, 21);
		int n2 = Random.Range (21, 41);
		parCalculos [0] = n1;
		parCalculos [1] = n2;
	}

	void OnCollisionEnter(Collision collision){		
		//Faz com que a bandeira fique parada no local sem gravidade atuando nela
		if(collision.gameObject.name.Equals("mapa")){
			gameObject.GetComponent<Rigidbody> ().useGravity = false; //retira gravidade
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			//Ativa o isTrigger dos filhos da bandeira
			gameObject.transform.GetChild (0).GetComponent<MeshCollider> ().isTrigger = true;
			gameObject.transform.GetChild (1).GetComponent<MeshCollider> ().isTrigger = true;
			gameObject.transform.GetChild (2).GetComponent<MeshCollider> ().isTrigger = true;
			gameObject.isStatic = true;	//Seta como estatico
		}
	}

	void OnTriggerEnter(Collider collision){		
		GameObject bandeira = criadorBandeira.GetComponent<CriadorBandeira> ().getBandeiraTarget ();
		if(collision.gameObject.name.Equals("tanque") && gameObject.Equals (bandeira)){			
			gameObject.SetActive (false);
			criadorBandeira.GetComponent<CriadorBandeira> ().inserirCalculoCanvas ();
			entregarPowerUps ();
		}
	}

	//Aumentar combustivel e vida do tanque quando ele enconstar na bandeira correta
	void entregarPowerUps(){
		barraRecursos.GetComponent<BarraRecursos>().incrementarVida();
		barraRecursos.GetComponent<BarraRecursos>().incrementarCombustivel();
	}
		
}
