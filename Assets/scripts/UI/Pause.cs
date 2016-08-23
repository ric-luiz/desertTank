using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject canvas;
	public GameObject miniMapa;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){			
			if(miniMapa.activeSelf){ //Caso o minimapa esteja aberto
				miniMapa.SetActive (false);
			} else {
				setarPause ();
			}
		}

		if(Input.GetKeyDown(KeyCode.M)){
			setarMapa ();
		}
	}

	public void continuar(){
		setarPause ();
	}

	public void mapa(){
		setarMapa ();
	}

	public void sair(){
		Time.timeScale = 1.0f;	//Seta para o jogo continuar funcionando mesmo depois de sair para o menu principal
		SceneManager.LoadScene ("menuPrincipal",LoadSceneMode.Single);
	}

	//Seta propriedades correspondete ao estado do jogo pausado ou não
	void setarPause(){
		if (canvas.activeSelf) { //Não pausado
			canvas.SetActive (false);
			Time.timeScale = 1.0f;
			AudioListener.pause = false;
			miniMapa.SetActive (false);
		} else { //Pausado
			canvas.SetActive (true);
			Time.timeScale = 0.0f;
			AudioListener.pause = true;
		}
	}

	void setarMapa(){
		if (miniMapa.activeSelf) { //Não aparece
			miniMapa.SetActive (false);
		} else { //aparece
			miniMapa.SetActive (true);
		}
	}
}
