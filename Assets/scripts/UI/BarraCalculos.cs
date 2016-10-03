using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarraCalculos : MonoBehaviour {

	private int[] parCalculos;
	private GameObject texto;

	void Start () {
		parCalculos = gameObject.GetComponentInParent<Bandeira> ().getParCalculos();
		texto = transform.GetChild (0).Find ("textoCalculo").gameObject;
		inserirTexto ();
	}

	void inserirTexto(){
		texto.GetComponent<Text> ().text = parCalculos[0]+"+"+parCalculos[1];
	}

}
