using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;

    public bool Dead => dead;
    public float StartingHealth => startingHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Logic for when health is above 0 (e.g., invincibility frames)
        }
        else
        {
            if (!dead)
            {
                dead = true;
                HandleDeath();
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

  private void HandleDeath()
{
    gameObject.SetActive(false); // Hide the player
    playerRespawn respawnScript = FindObjectOfType<playerRespawn>();
    if (respawnScript != null)
    {
        respawnScript.RespawnPlayer(gameObject);
    }
}

    public void ResetHealth()
    {
        currentHealth = startingHealth;
        dead = false;
    }
}


