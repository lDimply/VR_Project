using UnityEngine;

public class ExtintorPickup : MonoBehaviour
{
    public OVRHand hand;             // Mano con tracking
    public Transform handTransform;  // Transform de la mano (HandAnchor)
    public float grabDistance = 0.15f;

    private bool isHeld = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hand == null || handTransform == null || rb == null)
            return;

        float distance = Vector3.Distance(transform.position, handTransform.position);

        bool isFist =
            hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) > 0.8f &&
            hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring) > 0.8f &&
            hand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky) > 0.8f;

        if (!isHeld && isFist && distance < grabDistance)
        {
            isHeld = true;
            transform.SetParent(handTransform);
            rb.isKinematic = true;
        }
        else if (isHeld && !isFist)
        {
            isHeld = false;
            transform.SetParent(null);
            rb.isKinematic = false;
        }
    }
}
