using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {
    public GameObject tiro;
    private Rigidbody rbTiro;   //RigidBody do Tiro
    public int ImpulsoTiro;     //Forca instantanea que será aplicada no tiro
    public GameObject explosao;
    //Usado para os intervalos entre um tiro e outro
    private double fireRate;    //Variavel para contar o tempo
    public int timeFire;        //Quantos segundos entre um tiro e outro

    void Start() {
        rbTiro = tiro.GetComponent<Rigidbody>();
    }
        
	void FixedUpdate () {
        atingiu();
        fireRate += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeFire < fireRate)
        {
            tiro.SetActive(true);
            Atirar();
            fireRate = 0;
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
