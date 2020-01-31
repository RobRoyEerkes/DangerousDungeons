using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCombat : MonoBehaviour
{
    public int MaxHealth = 50;
    public int currentHealth;
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
    
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("hit enemy" + damage);
        if (currentHealth < 1)
            Die();
    }

    public void Die()
    {
        Debug.Log(this.name + " Died.");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
