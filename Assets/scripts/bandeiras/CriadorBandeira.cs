using UnityEngine;
using System.Collections;

public class CriadorBandeira : MonoBehaviour {

	public GameObject[] bandeirasPrefab;

	void Start () {
		for (int i = 0; i < bandeirasPrefab.Length; i++) {					
			Instantiate (bandeirasPrefab[i],
				                  new Vector3 (Random.Range(200.0f,2800.0f),35.0f,Random.Range(200.0f,2800.0f)), 
				                  Quaternion.identity);		
		}
	}

}
