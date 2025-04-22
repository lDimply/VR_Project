using UnityEngine;

public class MultiGestureMover : MonoBehaviour
{
    public OVRHand rightHand;         // Mano derecha
    public Transform rigTransform;    // OVRCameraRig
    public Camera xrCamera;           // CenterEyeAnchor (la cámara del jugador)

    public float normalSpeed = 1.5f;      // Velocidad normal
    public float crouchSpeed = 0.5f;      // Velocidad al agacharse
    public float turnSpeed = 60f;         // Velocidad de giro (grados/segundo)
    public float crouchThreshold = 1.2f;  // Altura en la que se considera agachado

    private float currentSpeed;

    void Update()
    {
        if (rightHand == null || xrCamera == null || rigTransform == null)
            return;

        // Detectar si está agachado
        float headHeight = xrCamera.transform.localPosition.y;
        bool isCrouching = headHeight < crouchThreshold;
        currentSpeed = isCrouching ? crouchSpeed : normalSpeed;

        // Movimiento hacia adelante con pinch del índice
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Vector3 forward = xrCamera.transform.forward;
            forward.y = 0;
            rigTransform.position += forward.normalized * currentSpeed * Time.deltaTime;
        }

        // Movimiento hacia atrás con pinch del medio
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            Vector3 back = -xrCamera.transform.forward;
            back.y = 0;
            rigTransform.position += back.normalized * currentSpeed * Time.deltaTime;
        }

        // Giro a la derecha con pinch del anular
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
        {
            rigTransform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Giro a la izquierda con pinch del meñique
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
        {
            rigTransform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        // Detener movimiento con pinch del pulgar
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb))
        {
            Debug.Log("Pulgar detectado: acción personalizada.");
        }

        // Debug opcional
        Debug.Log(isCrouching ? "Jugador agachado (velocidad reducida)" : "Jugador de pie (velocidad normal)");
    }
}
