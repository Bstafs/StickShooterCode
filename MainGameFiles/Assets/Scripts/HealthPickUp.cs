using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth healthPickup = collision.GetComponent<PlayerHealth>();
        if (collision.gameObject.tag == "Player")
        {
           
                healthPickup.currentHealth += 25;
                Destroy(gameObject);
                 
            

        }





    }
}

