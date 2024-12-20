using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPlayerPosition : MonoBehaviour
{
    [SerializeField] InputActionAsset actions;

    [Space]
    [SerializeField] Transform cameraTransform;

    Vector3 initialPosition;

    private void Awake() 
    {
        initialPosition = transform.position;

        actions.FindActionMap("XRI LeftHand Interaction").FindAction("Reposition").performed += (x) => ResetPosition();
    }

    private void Start() 
    {
        Invoke("ResetPosition", 0.5f);
    }

    public void ResetPosition()
    {
        var posOffset = initialPosition - cameraTransform.position;
        posOffset.y = 0;

        var fwd = Vector3.forward;
        fwd.y = 0;
        var camFwd = cameraTransform.forward;
        camFwd.y = 0;
        var angle = Vector3.SignedAngle(camFwd, fwd, Vector3.up);

        transform.RotateAround(cameraTransform.position, Vector3.up, angle);
        transform.position += posOffset;
    }
}
