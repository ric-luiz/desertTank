using UnityEngine;
using System.Collections;

public class CriadorInimigo : MonoBehaviour {

	private static int maximoInimigosMapa;
	private static int inimigosMapa;
	public GameObject inimigoPrefab;
	public float criadorTempo;
	private float timeRate;

	void Start () {
		maximoInimigosMapa = 4; 
	}

	void Update () {
		if(inimigosMapa < maximoInimigosMapa && timeRate >= criadorTempo){			
			Instantiate (inimigoPrefab, 
				         new Vector3 (Random.Range(100.0f,2900.0f),35.0f,Random.Range(100.0f,2900.0f)),
						 Quaternion.identity);
			inimigosMapa++;
			timeRate = 0.0f;
		}
		timeRate += Time.deltaTime;
	}
}
