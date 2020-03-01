using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCombat : MonoBehaviour
{
    public int MaxHealth = 2;
    public int currentHealth;
    public int Damage;
    public PlayerCombat Player;
    Destroy parent;
    EnableAIPath enableAIp;
    Animator Anim;
    bool is_skelet;


    //damages the playeur when it is in the enemy
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Enemy = collision.gameObject;
        if (Enemy.tag == "Player")
        {
            
            if (enableAIp.PlayerIsRange(2f))
                Player.DamagePlayer(Damage);
            Anim.SetTrigger("Attack");
     
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
        //play death anim
        parent.destroyGameObject();
        this.enabled = false;
    }
    
    void Start()
    {
        currentHealth = MaxHealth;
        parent = GetComponentInParent<Destroy>();
        enableAIp = GetComponentInParent<EnableAIPath>();
        Anim = GetComponent<Animator>();
    }

}
