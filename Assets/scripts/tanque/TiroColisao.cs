using UnityEngine;
using System.Collections;

public class TiroColisao : MonoBehaviour {
    private bool Colidiu;	//o tiro colidiu com algo?

    void Start() {
        Colidiu = false;
    }

    /// <summary>
	/// Verifica se o Tiro pegou em alguma coisa
    /// </summary>
    /// <param name="collision">Recebe o objeto com o qual o tiro colidiu</param>
    void OnCollisionEnter(Collision collision) {        
        Colidiu = true;

		//collision.gameObject.tag
		if(collision.gameObject.tag == "Player"){
			collision.gameObject.GetComponent<PlayerController> ().BarraRecursos.GetComponent<BarraRecursos>().retirarVida(); //Pega: GameObject:BarraRecursos -> Script:BarraRecursos
		} else if(collision.gameObject.tag == "inimigo"){
			collision.gameObject.GetComponent<EnemyController> ().BarraRecursos.GetComponent<BarraRecursos>().retirarVida(); //Pega: GameObject:BarraRecursos -> Script:BarraRecursos
		}
    }

	/// <summary>
	/// Recupera a variavel que sabe se o tiro colidiu com algo
	/// </summary>
	/// <returns><c>true</c>, se o tiro pegou em algo, <c>false</c> outro caso.</returns>
    public bool getColidiu() {
        return Colidiu;
    }

	/// <summary>
	/// Seta a variavel colidiu com true ou false.
	/// </summary>
	/// <param name="estadoColisao">Recebe um bool para setar estadoColisao.</param>
    public void setColidiu(bool estadoColisao) {
        Colidiu = estadoColisao;
    }
}
