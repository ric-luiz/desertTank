using UnityEngine;
using System.Collections;

public class Bandeira : MonoBehaviour {

	public GameObject[] bandeiraPrefab;
	public int[,] calculos;

	void Start () {
		calculos = new int[bandeiraPrefab.Length,3];	//Para cada bandeira temos doi numeros associados aos calculos
		criarCalculos();
		for (int i = 0; i < bandeiraPrefab.Length; i++) {
			if(calculos[i,2]==0){
				Debug.Log (calculos[i,0]+" + "+calculos[i,1]);
			} else if(calculos[i,2]==1){
				Debug.Log (calculos[i,0]+" - "+calculos[i,1]);
			}
		}
	}

	void Update () {
	}

	void criarCalculos(){
		int[] numeros;
		for(int i=0;i<bandeiraPrefab.Length;i++){
			int aleatorio = Random.Range (0, 4);

			switch (aleatorio) {
				case 0:	//Adição
					numeros = adicao ();
					calculos[i,0] = numeros[0];
					calculos[i,1] = numeros[1];					
					calculos[i,2] = 0;
				break;
				
				case 1:	//Subtração
				numeros = subtracao ();
					calculos[i,0] = numeros[0];
					calculos[i,1] = numeros[1];
					calculos[i,2] = 1;
				break;

				case 2:	//Multiplicação

				break;

				case 3:	//Divisão

				break;
			}
		}
	}

	int[] adicao(){
		int n1 = Random.Range (1, 21);
		int n2 = Random.Range (21, 41);
		int[] numeros = new int[] { n1, n2 };

		return numeros;
	}

	int[] subtracao(){
		int n1 = Random.Range (21, 41);
		int n2 = Random.Range (1, 21);
		int[] numeros = new int[] { n1, n2 };

		return numeros;
	}
}
