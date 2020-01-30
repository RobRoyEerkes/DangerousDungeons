using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int Health;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask EnemyLayers;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);
        //damage hitEnemies
    }

    public void DamagePlayer(int Damage)
    {
        Health -= Damage;
        Debug.Log(Health);
        if (Health < 1)
        {
            Debug.Log("You Died");
        }
    }
}
