using System.Collections;
using System.Threading;
using UnityEngine;
using Cinemachine;

public class CameraZoomScript : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Transform finishLineTransform; // Reference to the finishing line's transform
    public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine virtual camera

    private void Start()
    {
        StartCoroutine(ZoomToPlayer());
    }

    IEnumerator ZoomToPlayer()
    {
        // Set the virtual camera's LookAt to the finish line
        //virtualCamera.LookAt = finishLineTransform;

        yield return null;

        // Set the virtual camera's LookAt and Follow to the player
        //Thread.Sleep(3000);
        virtualCamera.LookAt = playerTransform;
        virtualCamera.Follow = playerTransform;
    }
}

