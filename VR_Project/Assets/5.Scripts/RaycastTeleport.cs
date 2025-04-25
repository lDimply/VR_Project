using UnityEngine;

public class RaycastTeleport : MonoBehaviour
{
    public OVRHand rightHand;
    public Transform rigTransform;     // OVRCameraRig
    public Camera xrCamera;           // CenterEyeAnchor
    public LineRenderer lineRenderer; // Para mostrar el rayo

    public float maxDistance = 10f;   // Distancia máxima del rayo
    public LayerMask teleportMask;    // Capas válidas para teleport

    private bool wasPinching = false;
    private Vector3 lastHitPoint;

    void Update()
    {
        if (rightHand == null || xrCamera == null || rigTransform == null || lineRenderer == null)
            return;

        bool isPinchingNow = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        // Mostrar el rayo mientras se hace pinch
        if (isPinchingNow)
        {
            lineRenderer.enabled = true;

            Vector3 rayOrigin = xrCamera.transform.position;
            Vector3 rayDirection = xrCamera.transform.forward;

            Ray ray = new Ray(rayOrigin, rayDirection);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance, teleportMask))
            {
                lastHitPoint = hit.point;

                // Dibujar línea hasta el punto de impacto
                lineRenderer.SetPosition(0, rayOrigin);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                // Dibujar línea hasta el máximo si no golpea nada
                lineRenderer.SetPosition(0, rayOrigin);
                lineRenderer.SetPosition(1, rayOrigin + rayDirection * maxDistance);
            }
        }

        // Al soltar el gesto, teletransportar si hubo hit válido
        if (!isPinchingNow && wasPinching)
        {
            lineRenderer.enabled = false;

            if (lastHitPoint != Vector3.zero)
            {
                rigTransform.position = new Vector3(lastHitPoint.x, rigTransform.position.y, lastHitPoint.z);
                Debug.Log("Teleport realizado a: " + lastHitPoint);
                lastHitPoint = Vector3.zero;
            }
        }

        wasPinching = isPinchingNow;
    }
}
