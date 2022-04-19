using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPlayer;
    public Vector3 cameraOffset;
    [Range(1,10)]
    public float smoothFactor;

    // sets camera to follow the position of the player
    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = targetPlayer.position + cameraOffset;
        
        // smoothes camera position to work with low fps to high
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }
}
