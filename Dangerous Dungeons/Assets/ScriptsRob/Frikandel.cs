using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frikandel : MonoBehaviour
{
    private PlayerCombat PlayerC;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerC = collision.gameObject.GetComponent<PlayerCombat>();
            PlayerC.Health = 5;
            Destroy(this.gameObject);
            this.enabled = false;
        }
    }
    
}

