using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    private int jumpCount;
    [SerializeField] private int maxJumps = 2;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on player object.");
        }

        body.freezeRotation = true;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpCount++;
        }

        // Attack animation and damage
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");
                DealDamageToEnemy();
            }
        }
    }

    private void DealDamageToEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.0f);

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(10); // Assumes the Enemy script has a TakeDamage method
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpCount = 0; // Reset jump count when grounded
        }
    }
}




