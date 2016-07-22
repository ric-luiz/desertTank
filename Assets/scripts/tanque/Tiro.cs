using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {
    public GameObject tiro;
	protected Rigidbody rbTiro;   //RigidBody do Tiro    
    public int ImpulsoTiro;     //Forca instantanea que será aplicada no tiro
    public GameObject explosao;
    //Usado para os intervalos entre um tiro e outro
	protected double fireRate;    //Variavel para contar o tempo
    public int timeFire;        //Quantos segundos entre um tiro e outro

	public AudioTiro audioTiro;
	public AudioClip[] sfxTiro;

    protected virtual void Start() {
        tiro = Instantiate(tiro, transform.position, transform.rotation) as GameObject;
        tiro.SetActive(false);
        rbTiro = tiro.GetComponent<Rigidbody>();        

		audioTiro = new AudioTiro (sfxTiro,GetComponent<AudioSource> ());
    }
        
	void FixedUpdate () {        
        atingiu();
        fireRate += Time.deltaTime;  
		controller ();
    }

	protected virtual void controller(){
		if (Input.GetMouseButtonDown(0) && timeFire < fireRate)
		{
			tiro.SetActive(true);
			Atirar();
			audioTiro.atirar ();
			fireRate = 0;
		}   
	}

    /// <summary>
	/// /Posicionar o tiro corretamente e Atirar!
    /// </summary>
	protected void Atirar() {
        resetarForcaTiro();                
        rbTiro.MovePosition(transform.position);
        rbTiro.MoveRotation(transform.rotation);       
        tiro.GetComponent<Rigidbody>().AddForce(transform.forward*ImpulsoTiro,ForceMode.Impulse);
    }

    /// <summary>
	/// Resetar as forças do rigidBody atuando sobre o tiro
    /// </summary>
    void resetarForcaTiro() {
        rbTiro.isKinematic = true;
        rbTiro.isKinematic = false;
    }

	/// <summary>
	/// Verifica se o Tiro Atingiu alguma coisa. Faz todos os procedimento para desativar o tiro e gerar a explosão no local do tiro
	/// </summary>
    void atingiu() {
        if (tiro.GetComponent<TiroColisao>().getColidiu()) {
			audioTiro.tiroAtingido ();
            tiro.GetComponent<TiroColisao>().setColidiu(false);            
            tiro.SetActive(false);           
            Instantiate(explosao, 
                        tiro.transform.position, 
                        tiro.transform.rotation);
        }
    }

	/// <summary>
	/// Destroir os objetos explosões. Cada explosão é retirada em 5 segundos
	/// </summary>
    public void retirarExplosoes() {
		GameObject[] explosoes = GameObject.FindGameObjectsWithTag("explosao");        
        if (explosoes.Length > 0)
        {
            foreach (GameObject g in explosoes)
            {
                Destroy(g,5);
            }
        }
    }
}
