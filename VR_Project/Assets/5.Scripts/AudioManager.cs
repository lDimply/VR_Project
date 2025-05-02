using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip soundEffect;  // El clip de audio que quieres reproducir
    private AudioSource audioSource;

    public Transform player;  // Referencia al jugador
    private BoxCollider triggerArea;

    void Start()
    {
        // Obtén el AudioSource en el mismo objeto o crea uno si no existe
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Si no hay AudioSource, añade uno
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Obtén el BoxCollider que usaremos para el área de detección
        triggerArea = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Verifica si el jugador está dentro del área
        if (IsPlayerInside())
        {
            // Si no ha sonado antes, reproduce el sonido
            if (!audioSource.isPlaying && soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);  // Reproduce el clip de audio solo una vez
            }
        }
    }

    // Comprueba si el jugador está dentro del área del BoxCollider
    private bool IsPlayerInside()
    {
        // Verifica si la posición del jugador está dentro del bounds del BoxCollider
        return triggerArea.bounds.Contains(player.position);
    }
}
