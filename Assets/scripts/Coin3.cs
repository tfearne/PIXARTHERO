using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject blackWhite3 = GameObject.Find("blackWhite3");
            if (blackWhite3 != null)
            {
                Destroy(blackWhite3);
            }
        }
    }
}
