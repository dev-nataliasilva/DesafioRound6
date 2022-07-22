using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIAtiva : MonoBehaviour
{
    public GameObject Inicio;
    public void DesativarInicio()
    {
        Inicio.gameObject.SetActive(false);
        GameController.Instance.ButtonTouch.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
