using UnityEngine;
using System.Collections;

public class Bandeira : MonoBehaviour {

	private int[] parCalculos;	//variavel guarda os 2 numeros do calculo de adição

	void Start (){
		parCalculos = new int[2];
		criarCalculos ();
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
		
}
