using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frikandel : MonoBehaviour
{
    private PlayerCombat PlayerC;
  //private void OnTriggerEnter2D(Collider2D collision)
  //{
  //    if (collision.gameObject.name == "player")
  //    {
  //        PlayerC = collision.gameObject.GetComponent<PlayerCombat>();
  //        PlayerC.Health = 5;
  //        Debug.Log(PlayerC.Health);
  //        Destroy(this.gameObject);
  //        this.enabled = false;
  //    }
  //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            PlayerC = collision.gameObject.GetComponent<PlayerCombat>();
            PlayerC.Health = 5;
            Debug.Log(PlayerC.Health);
            Destroy(this.gameObject);
            this.enabled = false;
        }
    }
    
}

