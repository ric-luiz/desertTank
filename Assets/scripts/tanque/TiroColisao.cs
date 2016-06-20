using UnityEngine;
using System.Collections;

public class TiroColisao : MonoBehaviour {
    private static bool Colidiu;
    private static Transform posicaoColisao;

    void Start() {
        Colidiu = false;
        posicaoColisao = null;
    }

    //Verifica se o Tiro pegou em alguma coisa
    void OnCollisionEnter(Collision collision) {        
        posicaoColisao = transform;
        Colidiu = true;
    }

    public bool getColidiu() {
        return Colidiu;
    }

    public void setColidiu(bool estadoColisao) {
        Colidiu = estadoColisao;
    }
}
