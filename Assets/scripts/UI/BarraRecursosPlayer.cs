using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BarraRecursosPlayer : BarraRecursos {
	public GameObject canvas;

	void Update(){
		if(vida <= 0 || combustivel <=0 && canvas != null){
			canvas.SetActive (true);
			Time.timeScale = 0.0f;
			AudioListener.pause = true;
		}
	}
}
