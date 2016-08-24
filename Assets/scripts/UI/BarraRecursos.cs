using UnityEngine;
using System.Collections;

public class BarraRecursos : MonoBehaviour {

	public float MaxVida;
	public float MaxCombustivel;
	public float gastoCombustivelMin;
	public float gastoCombustivelMax;
	private float vida;
	private float combustivel;
	private GameObject lifeBar;
	private GameObject gasBar;

	void Start () {
		vida = MaxVida;
		combustivel = MaxCombustivel;
		lifeBar = transform.GetChild(0).Find("Vida").gameObject;	//Pega a barra de vida
		gasBar = transform.GetChild(1).Find("Combustivel").gameObject;	//Pega a barra de combustivel
	}

	public void retirarVida(){
		vida -= 10.0f;

		//Garante que a barra de vida não ultrapa-se os limites na escala e nos valores definidos. Min = 0; Max = MaxVida
		if(vida < 0){
			vida = 0;
		} else if(vida > MaxVida){
			vida = MaxVida;
		}

		float valor = vida / MaxVida;
		diminuirBarraVida (valor);
	}

	public void retirarCombustivel(float combustivel){
		this.combustivel -= combustivel;

		//Garante que a barra de combustivel não ultrapa-se os limites na escala e nos valores definidos. Min = 0; Max = MaxCombustivel
		if(this.combustivel < 0){
			this.combustivel = 0;
		} else if(this.combustivel > MaxCombustivel){
			this.combustivel = MaxCombustivel;
		}

		float valor = this.combustivel / MaxCombustivel;
		diminuirBarraCombustivel (valor);
	}

	void diminuirBarraVida(float valor){
		lifeBar.transform.localScale = new Vector3(valor,lifeBar.transform.localScale.y,lifeBar.transform.localScale.z);
	}

	void diminuirBarraCombustivel(float valor){
		gasBar.transform.localScale = new Vector3(valor,gasBar.transform.localScale.y,gasBar.transform.localScale.z);
	}
}
