using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int Health;
    public Transform attackPoint;
    public LayerMask EnemyLayers;

    public float attackRange;
    public int attackDamage;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
        
    }
    
    //called when player wants to atack 
    //deals damage to enemies in range of the attackpoint
    private void Attack()
    {
        if (this.GetComponent<PlayerMovement>().Dir == 3)
            attackPoint.position *= -1;
        else if (this.GetComponent<PlayerMovement>().Dir != 1)
            attackPoint.position.Set(0, attackPoint.position.x, 0);
        else if (this.GetComponent<PlayerMovement>().Dir == 2)
            attackPoint.position.Set(0, -1 * attackPoint.position.x, 0);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemies) 
            enemy.GetComponent<EnemyCombat>().takeDamage(attackDamage);
        
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
            Destroy(this.gameObject);
        }
    }
}
