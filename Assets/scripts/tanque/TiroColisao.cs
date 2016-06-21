using UnityEngine;
using System.Collections;

public class TiroColisao : MonoBehaviour {
    private static bool Colidiu;

    void Start() {
        Colidiu = false;
    }

    //Verifica se o Tiro pegou em alguma coisa
    void OnCollisionEnter(Collision collision) {        
        Colidiu = true;
    }

    public bool getColidiu() {
        return Colidiu;
    }

    public void setColidiu(bool estadoColisao) {
        Colidiu = estadoColisao;
    }
}
