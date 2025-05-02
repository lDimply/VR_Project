using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string sceneToLoad = "NombreDeTuEscena";
    public Transform player; // Arrástralo desde el editor
    private BoxCollider triggerArea;

    void Start()
    {
        triggerArea = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (IsPlayerInside())
        {
            Debug.Log("Jugador dentro del área, cambiando escena...");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private bool IsPlayerInside()
    {
        Vector3 localPos = transform.InverseTransformPoint(player.position);
        return triggerArea.bounds.Contains(player.position);
    }
}
