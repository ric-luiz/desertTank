using UnityEngine;
using System.Collections;

public class MiniMapIcon : MonoBehaviour {
	
	void Update () {
		freezeRotationIcon ();
	}

	//Faz com que os icones não rotacionem no minimapa.
	void freezeRotationIcon(){
		this.transform.eulerAngles = new Vector3 (0,0,0);
	}
}
