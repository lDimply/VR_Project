using UnityEngine;

public class CrouchDetector : MonoBehaviour
{
    public Transform xrCamera;        // La cámara del jugador (CenterEyeAnchor)
    public float crouchThreshold = 1.2f; // Altura debajo de la cual se considera agachado (ajustar según el juego)
    public bool isCrouching;

    void Update()
    {
        float headHeight = xrCamera.localPosition.y;

        isCrouching = headHeight < crouchThreshold;

        if (isCrouching)
        {
            Debug.Log("Jugador agachado");
            // Podés activar animaciones, reducir velocidad, colisionadores más bajos, etc.
        }
    }
}
