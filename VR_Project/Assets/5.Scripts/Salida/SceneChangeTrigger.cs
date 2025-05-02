using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public string sceneToLoad = "NombreDeTuEscena";  // Nombre de la escena a cargar
    public Transform player;  // El transform del muñeco
    private BoxCollider triggerArea;  // El área de colisión

    void Start()
    {
        // Obtener el BoxCollider del objeto actual
        triggerArea = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Verificar si el muñeco está dentro del área del BoxCollider
        if (IsPlayerInside())
        {
            // Cambiar de escena
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Función para verificar si el muñeco está dentro del BoxCollider
    private bool IsPlayerInside()
    {
        // Comprobar si la posición del muñeco está dentro de los límites del BoxCollider
        return triggerArea.bounds.Contains(player.position);
    }
}
