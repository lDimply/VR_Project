using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarManguera : MonoBehaviour
{
    public GameObject agua;

    public void Activar_Agua()
    {
        agua.SetActive(true);
    }
}
