using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCombat : MonoBehaviour
{
    public int MaxHealth = 50;
    public int currentHealth;
    public int Damage;
    public PlayerCombat Player;
    Destroy parent;

    

    //damages the playeur when it is in the enemy
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Enemy = collision.gameObject;
        if (Enemy.tag == "Player")
        {
            Player.DamagePlayer(Damage);
        }
    }
    
    //does damage to the enemy fuckboi and when health is below 0 it dies
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("hit enemy" + damage);
        if (currentHealth < 1)
            Die();
    }
    
    //destroyes enemy gameobect and script plays death animation 
    public void Die()
    {
        Debug.Log(this.name + " Died.");
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
        parent.destroyGameObject();
        this.enabled = false;
    }
    
    void Start()
    {
        currentHealth = MaxHealth;
        parent = GetComponentInParent<Destroy>();
    }
}
