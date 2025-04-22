using UnityEngine;

public class MultiGestureMover : MonoBehaviour
{
    public OVRHand rightHand;         // Asignar el componente OVRHand (mano derecha)
    public Transform rigTransform;    // El OVRCameraRig (el objeto que representa al jugador)
    public Camera xrCamera;           // El CenterEyeAnchor (la c�mara dentro del rig)
    public float moveSpeed = 1.5f;    // Velocidad de movimiento
    public float turnSpeed = 60f;     // Velocidad de rotaci�n (grados por segundo)

    void Update()
    {
        if (rightHand == null || xrCamera == null || rigTransform == null)
            return;

        // Movimiento hacia adelante con pinch del �ndice
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Vector3 forward = xrCamera.transform.forward;
            forward.y = 0;
            rigTransform.position += forward.normalized * moveSpeed * Time.deltaTime;
        }

        // Movimiento hacia atr�s con pinch del medio
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            Vector3 back = -xrCamera.transform.forward;
            back.y = 0;
            rigTransform.position += back.normalized * moveSpeed * Time.deltaTime;
        }

        // Giro a la derecha con pinch del anular
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
        {
            rigTransform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Giro a la izquierda con pinch del me�ique
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
        {
            rigTransform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        // Detener movimiento con pinch del pulgar
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb))
        {
            // Pod�s poner una pausa, detener movimiento u otra acci�n
            Debug.Log("Pulgar detectado: Acci�n personalizada");
        }
    }
}
