using UnityEngine;
using TMPro; // Importante

public class UI_Cronometro : MonoBehaviour
{
    public TextMeshProUGUI textoCronometro;

    void Update()
    {
        if (Cronometro.Instancia != null)
        {
            int minutos = Cronometro.Instancia.Minutos;
            int segundos = Cronometro.Instancia.Segundos;
            textoCronometro.text = $"{minutos:00}:{segundos:00}";
        }
    }
}

