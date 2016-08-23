using UnityEngine;
using System.Collections;

public class Canhao: MonoBehaviour
{
	protected Vector3 position;
	protected float angularSpeed = 100.0f;
	protected Transform pontaCanhao;
	protected RaycastHit hit;
	protected float[] direcaoCorpo;
	public GameObject corpo;

	public virtual void Start()
    {		
        pontaCanhao = transform.GetChild(0).GetChild(0);	//Pega o objeto que corresponde a ponta do canhão
    }

    protected virtual void FixedUpdate()
    {								
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Pega o ponto em que o ponteiro do mouse está apontando. Já convertido para Ray    
        if (Physics.Raycast(ray, out hit))
        {
            //Pega o ponteiro do mouse para qualquer lugar que contenha objetos
            position = hit.point - transform.position;
            setarRotacaoBase(position);
            setarRotacaoCanhao(position);            
        }
        else
        {
            //Caso nao esteja pegando em algo solido, coloca-se para pegar o ponteiro do mouse fora do plano
            position = new Vector3(
                             Input.mousePosition.x - Screen.width / 2,
                             Input.mousePosition.y - Screen.height / 2,
                             Camera.main.transform.position.z - 10.0f
                         );
            setarRotacaoBase(position);
            setarRotacaoCanhao(position);            
        }
        Debug.DrawLine(ray.origin, hit.point);	//Desenha a linha do raycast. Somente para fins de desenvolvimento
    }

    /// <summary>
	/// Seta a rotacao para a base do canhao
    /// </summary>
    /// <param name="position">Recebe um Vector3 que contem o ponto em que o mouse está apontando.</param>
    protected virtual void setarRotacaoBase(Vector3 position)
    {	
		offSetRotacao ();	//Compensão da rotacao herdada pelo elemento pai
        position.y = 0;		//Isso evita que a rotação mexa no eixo y da baseCanhao
        Quaternion rotation = Quaternion.LookRotation(position);
		if (verificarRotacaoAtingiuDestino (transform.eulerAngles.y, rotation.eulerAngles.y)) {

			if (verificarMelhorLadoVirar (transform.eulerAngles.y, rotation.eulerAngles.y)) {
				transform.Rotate (Vector3.up * angularSpeed * Time.deltaTime);
			} else {
				transform.Rotate (-Vector3.up * angularSpeed * Time.deltaTime);
			}

		} else {
			atingiuRotacaoBase ();
		}
    }

	/// <summary>
	/// O metodo serve para ser sobreescrito pelos filhos da classe. 
	/// Usa-se para realizar algo apos a base atingir o fim de sua rotação (Como um callback)
	/// </summary>
	protected virtual void atingiuRotacaoBase(){}
	/// <summary>
	/// O metodo serve para ser sobreescrito pelos filhos da classe. 
	/// Usa-se para realizar algo apos a ponta do canhão atingir o fim de sua rotação (Como um callback)
	/// </summary>
	protected virtual void atingiuRotacaoPonta(){}

	/// <summary>
	/// Faz a compensasão da rotação do pai para o filho. Aqui evitamos que a herança da rotação do eixo y do elemento pai para o filho
	/// </summary>
	protected void offSetRotacao(){		
			setarDirecaoRotacao ();
			if(direcaoCorpo[0] != 0){
				float rotacaoOffSet = direcaoCorpo[0] * direcaoCorpo[1];	//Pega valores da classe Corpo
				transform.Rotate (Vector3.up * rotacaoOffSet * Time.deltaTime);
			}	
	}

	/// <summary>
	/// Usado para ser sobreescrito no filho para setar a rotação de acordo com o corpo do objeto
	/// </summary>
	protected virtual void setarDirecaoRotacao(){}

    /// <summary>
	/// Seta a rotacao da ponta do canhao
    /// </summary>
	/// <param name="position">Recebe um Vector3 que contem o ponto em que o mouse está apontando.</param>
	protected void setarRotacaoCanhao(Vector3 position)
    {
        position.x = 0;	//Evitamos que o eixo x seja alterado no processo
        //position.z += 150.0f;
        Quaternion rotation = Quaternion.LookRotation(position);

		if (verificarRotacaoAtingiuDestino (pontaCanhao.eulerAngles.x, rotation.eulerAngles.x)) {

			if (verificarMelhorLadoVirar (pontaCanhao.eulerAngles.x, rotation.eulerAngles.x)) {
				pontaCanhao.Rotate (Vector3.right * angularSpeed * Time.deltaTime);

				//Limita o quanto a ponta pode ir para baixo
				if (pontaCanhao.eulerAngles.x >= 10.0f && pontaCanhao.eulerAngles.x <= 180.0f) {
					pontaCanhao.Rotate (-Vector3.right * angularSpeed * Time.deltaTime);
				}
			} else {
				pontaCanhao.Rotate (-Vector3.right * angularSpeed * Time.deltaTime);
			}

		} else {
			atingiuRotacaoPonta ();
		}
    }

    //Verifica se os angulos da origem e destinos sao praticamente iguais
	protected bool verificarRotacaoAtingiuDestino(float anguloOrigem, float anguloDestino)
    {
        if (anguloOrigem >= anguloDestino - 2.0f && anguloOrigem <= anguloDestino + 2.0f)
        {
            return false;
        }
        return true;
    }

    //Verifica qual o melhor lado Rodar a base para encontrar o ponto.
	protected bool verificarMelhorLadoVirar(float anguloOrigem, float anguloDestino)
    {
        int n1 = (int)anguloOrigem;
        int i = 0, j = 0;

        while (n1 != (int)anguloDestino)
        {
            n1++;
            i++;
            n1 = n1 % 360;
        }

        n1 = (int)anguloOrigem;
        while (n1 != (int)anguloDestino)
        {
            n1--;
            j++;
            if (n1 < 0)
            {
                n1 = 359;
            }
            n1 = n1 % 360;

        }
        return i < j ? true : false;
    }
}
