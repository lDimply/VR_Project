using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public static Cronometro Instancia;

    public float tiempoRestante = 300f; // 5 minutos en segundos
    public bool estaCorriendo = true;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    private void Update()
    {
        if (estaCorriendo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                estaCorriendo = false;
                // Aquí puedes llamar a algo cuando el tiempo se acabe
                Debug.Log("¡Tiempo agotado!");
            }
        }
    }

    // Para obtener minutos y segundos, útil para UI
    public int Minutos => Mathf.FloorToInt(tiempoRestante / 60f);
    public int Segundos => Mathf.FloorToInt(tiempoRestante % 60f);
}
