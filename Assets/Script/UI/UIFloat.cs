using UnityEngine;

/// <summary>
/// Keep a UI canvas floating in front of the HMD, Facebook-style.
/// </summary>
public class VRBillboard : MonoBehaviour {
    [Tooltip("Reference to the XR camera (usually Main Camera).")]
    public Transform head;

    [Tooltip("Meters in front of the face.")]
    public float distance = 1.5f;

    [Tooltip("Smoothness – higher = snappier.")]
    public float followSpeed = 5f;

    void LateUpdate() {
        if (!head) return;  // Safety check

        // Desired position = a point 'distance' meters in front of the head
        Vector3 targetPos = head.position + head.forward * distance;

        // Lerp for smooth motion
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * followSpeed
        );

        // Face the player straight-on
        transform.rotation = Quaternion.LookRotation(
            head.forward,            // forward vector
            Vector3.up               // world up
        );
    }
}
