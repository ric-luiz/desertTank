using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {
    public GameObject tiro;
    private Rigidbody rbTiro;   //RigidBody do Tiro
    public int ImpulsoTiro;     //Forca instantanea que será aplicada no tiro
    public GameObject explosao;    

    void Start() {
        rbTiro = tiro.GetComponent<Rigidbody>();
    }

    void Update() {
        
    }
    
	void FixedUpdate () {
        atingiu();
        if (Input.GetMouseButtonDown(0))
        {
            tiro.SetActive(true);
            Atirar();            
        }                
    }

    //Posicionar o tiro corretamente e Atirar!
    void Atirar() {
        resetarForcaTiro();                
        rbTiro.MovePosition(transform.position);       
        tiro.GetComponent<Rigidbody>().AddForce(transform.forward*ImpulsoTiro,ForceMode.Impulse);
    }

    //Resetar as forças do rigidBody atuando sobre o tiro
    void resetarForcaTiro() {
        rbTiro.isKinematic = true;
        rbTiro.isKinematic = false;
    }

    void atingiu() {
        if (TiroColisao.getColidiu()) {            
            TiroColisao.setColidiu(false);            
            tiro.SetActive(false);           
            Instantiate(explosao, 
                        TiroColisao.getTransformColisao().position, 
                        TiroColisao.getTransformColisao().rotation);
        }
    }
}
