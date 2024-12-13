using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject blackWhite2 = GameObject.Find("BlackWhite2");
            if (blackWhite2 != null)
            {
                Destroy(blackWhite2);
            }
        }
    }
}
