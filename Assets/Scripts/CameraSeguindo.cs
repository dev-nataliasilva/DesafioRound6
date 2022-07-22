using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguindo : MonoBehaviour
{
    public Transform Personagem;
    public Transform Camera;

    private void Update()
    {
        Camera.transform.position = new Vector3(0, 11.12f, Personagem.position.z - 15);
    }
}
