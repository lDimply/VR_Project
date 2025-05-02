using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public string sceneToLoad = "NombreDeTuEscena";  // Nombre de la escena a cargar
    public Transform player;  // El transform del mu�eco
    private BoxCollider triggerArea;  // El �rea de colisi�n

    void Start()
    {
        // Obtener el BoxCollider del objeto actual
        triggerArea = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Verificar si el mu�eco est� dentro del �rea del BoxCollider
        if (IsPlayerInside())
        {
            // Cambiar de escena
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Funci�n para verificar si el mu�eco est� dentro del BoxCollider
    private bool IsPlayerInside()
    {
        // Comprobar si la posici�n del mu�eco est� dentro de los l�mites del BoxCollider
        return triggerArea.bounds.Contains(player.position);
    }
}
