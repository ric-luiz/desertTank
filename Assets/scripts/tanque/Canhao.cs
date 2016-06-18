using UnityEngine;
using System.Collections;

public class Canhao: MonoBehaviour
{
    private Vector3 position;
    private float angularSpeed = 100.0f;
    private Transform pontaCanhao;
    private static RaycastHit hit;

    void Start()
    {
        pontaCanhao = transform.GetChild(0).GetChild(0);
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        
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
        Debug.DrawLine(ray.origin, hit.point);
    }

    //Seta a rotacao para a base do canhao
    void setarRotacaoBase(Vector3 position)
    {
        position.y = 0;
        Quaternion rotation = Quaternion.LookRotation(position);
        if (verificarRotacaoAtingiuDestino(transform.eulerAngles.y, rotation.eulerAngles.y))
        {

            if (verificarMelhorLadoVirar(transform.eulerAngles.y, rotation.eulerAngles.y))
            {
                transform.Rotate(Vector3.up * angularSpeed * Time.deltaTime);
            }
            else {
                transform.Rotate(-Vector3.up * angularSpeed * Time.deltaTime);
            }

        }
    }

    //Seta a rotacao da ponta do canhao
    void setarRotacaoCanhao(Vector3 position)
    {
        position.x = 0;
        position.z += 150.0f;
        Quaternion rotation = Quaternion.LookRotation(position);

        if (verificarRotacaoAtingiuDestino(pontaCanhao.eulerAngles.x, rotation.eulerAngles.x))
        {

            if (verificarMelhorLadoVirar(pontaCanhao.eulerAngles.x, rotation.eulerAngles.x))
            {
                pontaCanhao.Rotate(Vector3.right * angularSpeed * Time.deltaTime);

                //Limita o quanto a ponta pode ir para baixo
                if (pontaCanhao.eulerAngles.x >= 10.0f && pontaCanhao.eulerAngles.x <= 180.0f)
                {
                    pontaCanhao.Rotate(-Vector3.right * angularSpeed * Time.deltaTime, Space.Self);
                }
            }
            else {
                pontaCanhao.Rotate(-Vector3.right * angularSpeed * Time.deltaTime);
            }

        }
    }

    //Verifica se os angulos da origem e destinos sao praticamente iguais
    bool verificarRotacaoAtingiuDestino(float anguloOrigem, float anguloDestino)
    {
        if (anguloOrigem >= anguloDestino - 2.0f && anguloOrigem <= anguloDestino + 2.0f)
        {
            return false;
        }
        return true;
    }

    //Verifica qual o melhor lado Rodar a base para encontrar o ponto.
    bool verificarMelhorLadoVirar(float anguloOrigem, float anguloDestino)
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

    void manterModulo()
    {

    }
}
