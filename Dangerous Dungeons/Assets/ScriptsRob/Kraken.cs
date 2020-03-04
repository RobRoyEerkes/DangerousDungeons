using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{
    public GameObject  player;
    private PlayerMovement PlayerM;
    private BoxCollider2D Playerbc;
    private PlayerCombat PlayerC;
    Transform[] hitbox;
    private int timer;
    public Vector2[] hitboxes;
    Animator[] Anims;

    void Start()
    {
        timer = 0;
        Playerbc = player.GetComponent<BoxCollider2D>();
        PlayerM = player.GetComponent<PlayerMovement>();
        PlayerC = player.GetComponent<PlayerCombat>();
        hitbox = GetComponentsInChildren<Transform>();
        Anims = GetComponentsInChildren<Animator>();

        for (int i = 1; i < 9; i++)
        {
            if (i % 2 == 0)
            {
                Vector2 place = hitbox[i].position;
                hitboxes[i / 2 - 1] = place;
            }
        }
    }
    
    public void ImpairMovement()
    {
        Playerbc.enabled = false;
        PlayerM.enabled = false;
    } 

    public void RegainMovement()
    {
        Playerbc.enabled = true;
        PlayerM.enabled = true;
    }

    private Vector2 BoxDimensie(Vector2 behh)
    {
        behh.x += .66f;
        behh.y -= 1.5f;
        return behh;
    }

    public void Attack(int tentacleNum)
    {
        //turn animator on
        Collider2D hitPlayer = Physics2D.OverlapArea(hitboxes[tentacleNum], BoxDimensie(hitboxes[tentacleNum]));
        
        if (hitPlayer != null)
        {
            if (hitPlayer.name == "Player")
            {
                ImpairMovement();
                PlayerC.DamagePlayer(1);
                Debug.Log(tentacleNum);
            }
            else
            {
                Debug.Log("bla");
            }
        }    
    }

    private void OnDrawGizmos()
    {
        if (hitboxes == null)
            return;
        Gizmos.DrawLine(hitboxes[1], BoxDimensie(hitboxes[1]));
    }

    private void turnAnimationOn(int tentacleNum)
    {
        Anims[tentacleNum].enabled = true;
    }


    void FixedUpdate()
    {
        if (timer > 300)
        {
            timer = 0;
            Attack(Mathf.RoundToInt(Random.value * 3));
        }
        timer++;
    }

}

