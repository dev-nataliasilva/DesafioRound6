using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public bool girando;
    public bool movendo;

    void Update()
    {       
        PersonagemMovimento();
    }

    private void OnEnable()
    {
        StartCoroutine(tempo());        
    }
    public void PersonagemMovimento()
    {
       if(girando == true)
        {
            Vector3 direcao = GameController.Instance.posicaoDestino - GameController.Instance.Jogador.transform.position;
            Quaternion rotacao = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Lerp(GameController.Instance.Jogador.transform.rotation, rotacao, GameController.Instance.VelJogador * Time.deltaTime);
        }

       if(movendo == true)
       {
            if (GameController.Instance.Jogador.transform.position.z > GameController.Instance.posicaoDestino.z)
            {
                girando = true;
                movendo = false;
                GameController.Instance.rodadaEmAndamento = false;

                if (GameController.Instance.FlagPerdeu == true)
                    GameController.Instance.PerdeuJogo();
                else if(GameController.Instance.Rodada == 4)
                    GameController.Instance.GameVitoria();
                GameController.Instance.Jogador.GetComponent<Movimento>().enabled = false;
            }
            GameController.Instance.Jogador.transform.Translate(new Vector3(0, 0, GameController.Instance.VelJogador * Time.deltaTime));
        }
    }

    

    public IEnumerator tempo()
    {
        girando = true;
        yield return new WaitForSeconds(1.0f);
        girando = false;
        movendo = true;
    }
    
}
