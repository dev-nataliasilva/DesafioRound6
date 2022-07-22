using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; protected set; }

    public float VelJogador = 6.0f;
    public bool FlagPerdeu = false;
    public int Rodada;
    public List<GameObject> VidroA;
    public List<GameObject> VidroB;
    public GameObject Jogador;
    public Vector3 posicaoDestino;
    public bool rodadaEmAndamento = true;
    public GameObject VidroEscolhido;
    public GameObject GameOver;
    public GameObject Vitoria;
    public GameObject ButtonTouch;

    public void HandleKeyboardEvents()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            posicaoDestino = new Vector3(GameController.Instance.VidroA[GameController.Instance.Rodada].transform.position.x, GameController.Instance.Jogador.transform.position.y, GameController.Instance.VidroA[GameController.Instance.Rodada].transform.position.z);
            GameController.Instance.Jogador.GetComponent<Movimento>().enabled = true;

            VidroEscolhido = GameController.Instance.VidroA[GameController.Instance.Rodada];
            PlayRodada(1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            posicaoDestino = new Vector3(GameController.Instance.VidroB[GameController.Instance.Rodada].transform.position.x, GameController.Instance.Jogador.transform.position.y, GameController.Instance.VidroB[GameController.Instance.Rodada].transform.position.z);
            GameController.Instance.Jogador.GetComponent<Movimento>().enabled = true;

            VidroEscolhido = GameController.Instance.VidroB[GameController.Instance.Rodada];
            PlayRodada(2);
        }
    }

    public void A_BottonEvent()
    {
        GameController.Instance.posicaoDestino = new Vector3(GameController.Instance.VidroA[GameController.Instance.Rodada].transform.position.x, GameController.Instance.Jogador.transform.position.y, GameController.Instance.VidroA[GameController.Instance.Rodada].transform.position.z);
        GameController.Instance.Jogador.GetComponent<Movimento>().enabled = true;

        GameController.Instance.VidroEscolhido = GameController.Instance.VidroA[GameController.Instance.Rodada];
        GameController.Instance.PlayRodada(1);
    }
    public void B_BottonEvent()
    {
        GameController.Instance.posicaoDestino = new Vector3(GameController.Instance.VidroB[GameController.Instance.Rodada].transform.position.x, GameController.Instance.Jogador.transform.position.y, GameController.Instance.VidroB[GameController.Instance.Rodada].transform.position.z);
        GameController.Instance.Jogador.GetComponent<Movimento>().enabled = true;

        GameController.Instance.VidroEscolhido = GameController.Instance.VidroB[GameController.Instance.Rodada];
        GameController.Instance.PlayRodada(2);
    }

    public void PlayRodada(int escolha)
    {
        GameController.Instance.ButtonTouch.SetActive(false);
        
        var sorteado = Random.Range(1, 3);
        print(sorteado);

        if (escolha == sorteado)
        {
            GameController.Instance.FlagPerdeu = true;
            print("perdeu");
        }
            
    }

    public void PerdeuJogo()
    {
        GameController.Instance.VidroEscolhido.gameObject.GetComponent<Rigidbody>().useGravity = true;
        GameController.Instance.Jogador.GetComponent<Rigidbody>().useGravity = true;
        GameController.Instance.GameOver.SetActive(true);
        GameController.Instance.ButtonTouch.SetActive(false);
    }

    public void GameVitoria()
    {
        GameController.Instance.Vitoria.SetActive(true);
        GameController.Instance.ButtonTouch.SetActive(false);
    }


    private void Update()
    {
        HandleKeyboardEvents();
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
         Time.timeScale = 1;

        GameController.Instance.Rodada = 0;
        StartCoroutine(AguardaRodada());   
    }

    public IEnumerator AguardaRodada()
    {
        yield return new WaitWhile(() => GameController.Instance.rodadaEmAndamento == true);
        if(GameController.Instance.FlagPerdeu == false)
        {
            GameController.Instance.ButtonTouch.SetActive(true);
            GameController.Instance.Rodada++;
            GameController.Instance.rodadaEmAndamento = true;
            StartCoroutine(AguardaRodada());
        }
        
    }
}
