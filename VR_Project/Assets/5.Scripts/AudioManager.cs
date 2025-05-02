using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip soundEffect;  // El clip de audio que quieres reproducir
    private AudioSource audioSource;

    public Transform player;  // Referencia al jugador
    private BoxCollider triggerArea;

    void Start()
    {
        // Obt�n el AudioSource en el mismo objeto o crea uno si no existe
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Si no hay AudioSource, a�ade uno
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Obt�n el BoxCollider que usaremos para el �rea de detecci�n
        triggerArea = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Verifica si el jugador est� dentro del �rea
        if (IsPlayerInside())
        {
            // Si no ha sonado antes, reproduce el sonido
            if (!audioSource.isPlaying && soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);  // Reproduce el clip de audio solo una vez
            }
        }
    }

    // Comprueba si el jugador est� dentro del �rea del BoxCollider
    private bool IsPlayerInside()
    {
        // Verifica si la posici�n del jugador est� dentro del bounds del BoxCollider
        return triggerArea.bounds.Contains(player.position);
    }
}
