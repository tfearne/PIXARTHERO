using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject blackWhiteFirst = GameObject.Find("BlackWhiteFirst");
            if (blackWhiteFirst != null)
            {
                Destroy(blackWhiteFirst);
            }
        }
    }
}


