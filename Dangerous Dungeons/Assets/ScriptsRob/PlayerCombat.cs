﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int Health;
    public Transform attackPoint;
    public LayerMask EnemyLayers;
    private Animator animator;
    public SpriteRenderer[] hartjes;

    public Canvas BlueScreenOfDeath;

    public float attackRange;
    public int attackDamage;
    public float coolDownTime;
    private float nextUpTime;
    
    void Update()
    {
        if (Time.time > nextUpTime)
        {
            if (Input.GetMouseButtonDown(0))
                Attack();
        }
        //heathbar stuff
        int i = 0;
        foreach (SpriteRenderer hartje in hartjes)
        {
            if (i > Health)
                hartje.enabled = false;
            else
                hartje.enabled = true;
            i++;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        hartjes = GetComponentsInChildren<SpriteRenderer>();
    }

    //called when player wants to atack 
    //deals damage to enemies in range of the attackpoint
    private void Attack()
    {
        animator.SetTrigger("Attack");
        if (this.GetComponent<PlayerMovement>().Dir == 3)
            attackPoint.position *= -1;
        else if (this.GetComponent<PlayerMovement>().Dir != 1)
            attackPoint.position.Set(0, attackPoint.position.x, 0);
        else if (this.GetComponent<PlayerMovement>().Dir == 2)
            attackPoint.position.Set(0, -1 * attackPoint.position.x, 0);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            if (enemy.name == "Draak")
            {
                Debug.Log("draak");
                enemy.GetComponent<DrakenBaas>().takeDamage(attackDamage);
            }else if(enemy.tag == "Tentacle")
            {
                enemy.GetComponentInParent<Kraken>().takeDamage(attackDamage);
                Debug.Log("hit");
            }
            else
            {
                enemy.GetComponent<EnemyCombat>().takeDamage(attackDamage);
            } 
        }
        // Cooldown timer
        nextUpTime = Time.time + coolDownTime;

    }
    
    //debug for seeing the range of the attack (only in the editor)
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
    //damages the player (takes health away)
    public void DamagePlayer(int Damage)
    {
        Health -= Damage;
        
        Debug.Log(Health);
        if (Health < 1)
        {
            Debug.Log("You Died");
            animator.SetTrigger("Death");
            BlueScreenOfDeath.GetComponent<Canvas>().enabled = true;
        }
    }
}
