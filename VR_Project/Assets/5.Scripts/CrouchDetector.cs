using UnityEngine;

public class CrouchDetector : MonoBehaviour
{
    public Transform xrCamera;        // La c�mara del jugador (CenterEyeAnchor)
    public float crouchThreshold = 1.2f; // Altura debajo de la cual se considera agachado (ajustar seg�n el juego)
    public bool isCrouching;

    void Update()
    {
        float headHeight = xrCamera.localPosition.y;

        isCrouching = headHeight < crouchThreshold;

        if (isCrouching)
        {
            Debug.Log("Jugador agachado");
            // Pod�s activar animaciones, reducir velocidad, colisionadores m�s bajos, etc.
        }
    }
}
