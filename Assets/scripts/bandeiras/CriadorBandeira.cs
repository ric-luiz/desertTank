using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CriadorBandeira : MonoBehaviour {

	public GameObject[] bandeirasPrefab;
	private GameObject[] bandeirasModel;
	private GameObject bandeiraTarget;	//A bandeira que é alvo para o jogador pegar
	public Text texto;
	public GameObject canvas;

	void Start () {
		criarBandeiras ();
		inserirCalculoCanvas ();
	}

	//Instancia as bandeiras e coloca-as no mapa
	void criarBandeiras(){
		bandeirasModel = new GameObject[bandeirasPrefab.Length]; //Instancia as bandeiras reais com espaço para a quantidade de prefabs
		for (int i = 0; i < bandeirasPrefab.Length; i++) {					
			bandeirasModel[i] = Instantiate (bandeirasPrefab[i],
				new Vector3 (Random.Range(200.0f,2800.0f),35.0f,Random.Range(200.0f,2800.0f)), 
				Quaternion.identity) as GameObject;		
		}
	}

	//Insere dentro do texto do canvas qual bandeira o jogador deve ir. Escolhe qual a bandeira alvo
	public void inserirCalculoCanvas(){
		foreach(GameObject g in bandeirasModel){
			if(g.activeSelf){				
				int n1 = g.GetComponent<Bandeira> ().getParCalculos () [0];
				int n2 = g.GetComponent<Bandeira> ().getParCalculos () [1];
				texto.text = "Ir para soma "+(n1+n2);
				bandeiraTarget = g;
				break;
			}
		}
	}

	public GameObject getBandeiraTarget(){
		return bandeiraTarget;
	}

	void Update(){
		verificarBandeirasAtivas ();
	}

	//Se todas as bandeiras estiverem desativadas o jogo acaba com o jogador como vencedor
	void verificarBandeirasAtivas(){
		bool bandeiraAtiva = false;
		foreach(GameObject g in bandeirasModel){
			if(g.activeSelf){				
				bandeiraAtiva = true;
				break;
			}
		}

		if(!bandeiraAtiva){
			canvas.SetActive (true);
			Time.timeScale = 0.0f;
			AudioListener.pause = true;
		}
	}

}
