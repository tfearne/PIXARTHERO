using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    // Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        // Smoothly move the camera along the X-axis
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(currentPosX, transform.position.y, transform.position.z),
            ref velocity,
            speed
        );

        // Update lookAhead based on player's movement
        if (player != null)
        {
            lookAhead = Mathf.Lerp(lookAhead, (player.position.x - transform.position.x) * aheadDistance, Time.deltaTime * cameraSpeed);
            transform.position = new Vector3(
                player.position.x + lookAhead,
                transform.position.y,
                transform.position.z
            );
        }
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }

    // New method to reset camera to the player's respawn position
    public void ResetCameraToPlayer()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                player.position.x,
                transform.position.y,
                transform.position.z
            );
            currentPosX = player.position.x; // Update the room position reference
        }
    }
}

