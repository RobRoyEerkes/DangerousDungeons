using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCombat : MonoBehaviour
{
    public int Health;
    public int Damage;
    public PlayerCombat Player;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Enemy = collision.gameObject;
        if (Enemy.tag == "Player")
        {
            Player.DamagePlayer(Damage);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
