using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour {
	public void novoJogo(){		
		SceneManager.LoadScene ("desert",LoadSceneMode.Single);
	}

	public void opcoes(){
		Debug.Log ("Opcoes");
	}

	public void creditos(){
		Debug.Log ("Creditos");
	}

	public void sair(){		
		Application.Quit ();
	}
}
