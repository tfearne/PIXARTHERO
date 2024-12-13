using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin4 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject bw4 = GameObject.Find("bw4");
            if (bw4 != null)
            {
                Destroy(bw4);
            }
        }
    }
}
