using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAgua : MonoBehaviour
{
    public GameObject Agua;

    public void ACTIVAR_AGUA()
    {
        Agua.SetActive(true);
    }

    public void DESACTIVAR_AGUA()
    {
        Agua.SetActive(false);
    }
}
