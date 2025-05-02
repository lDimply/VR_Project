using UnityEngine;

public class AguaDetector : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"Partícula impactó con: {other.name}");

        // Intentamos obtener el script del fuego
        FuegoInteractivo fuego = other.GetComponent<FuegoInteractivo>();
        if (fuego != null)
        {
            Debug.Log("¡Fuego detectado! Aplicando agua...");
            fuego.AplicarAgua(1f); // Se activa el apagado
        }
        else
        {
            Debug.Log("No es fuego o falta el script FuegoInteractivo.");
        }
    }
}
