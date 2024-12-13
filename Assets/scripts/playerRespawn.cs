using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    private Transform lastDoor; // Tracks the last door the player collided with

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Update lastDoor when the player collides with a door
        if (collision.CompareTag("Door"))
        {
            lastDoor = collision.transform;
            Debug.Log("Last door updated: " + lastDoor.name); // Debug log for testing
        }
    }

    public void RespawnPlayer(GameObject player)
    {
        if (lastDoor != null)
        {
            // Move the player to the last door's position
            player.transform.position = lastDoor.position;

            // Reset health
            Health health = player.GetComponent<Health>();
            if (health != null)
            {
                health.ResetHealth();
            }

            // Reactivate the player
            player.SetActive(true);

            // Re-enable movement
            player.GetComponent<playerMovement>().enabled = true;

            // Reset camera to follow the player at the respawn position
            CameraController cameraController = FindObjectOfType<CameraController>();
            if (cameraController != null)
            {
                cameraController.ResetCameraToPlayer();
            }

            Debug.Log("Player respawned at the last door.");
        }
        else
        {
            Debug.LogWarning("No last door found! Respawning at the initial spawn position.");
            RespawnAtInitialPosition(player);
        }
    }

    private void RespawnAtInitialPosition(GameObject player)
    {
        // Optional: Set a fallback position if no doors have been passed
        Vector3 initialPosition = Vector3.zero; // Replace with your actual initial spawn point
        player.transform.position = initialPosition;

        // Reset health and re-enable the player
        Health health = player.GetComponent<Health>();
        if (health != null)
        {
            health.ResetHealth();
        }
        player.SetActive(true);
        player.GetComponent<playerMovement>().enabled = true;

        // Reset camera
        CameraController cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null)
        {
            cameraController.ResetCameraToPlayer();
        }
    }
}



