using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    int tentacleNum;
    public LayerMask layermask;
    BoxCollider2D[] TenColliders;
    public int Health = 10;


    void Start()
    {
        timer = 0;
        TenColliders = GetComponentsInChildren<BoxCollider2D>();
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
        TenColliders[tentacleNum].enabled = false;
        Playerbc.enabled = true;
        PlayerM.enabled = true;
    }

    private Vector2 BoxDimensie(Vector2 behh)
    {
        behh.x += .66f;
        behh.y -= 2.4f;
        return behh;
    }

    public void Attack()
    {
        TenColliders[tentacleNum].enabled = true;
        Collider2D hitPlayer = Physics2D.OverlapArea(hitboxes[tentacleNum], BoxDimensie(hitboxes[tentacleNum]), layermask);
        
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

    public void takeDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);
        if (Health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    private void turnAnimationOn()
    {
        tentacleNum = Mathf.RoundToInt(Random.value * 3);
        Anims[tentacleNum].SetTrigger("Slap");
    }


    void FixedUpdate()
    {
        if (timer > 300)
        {
            timer = 0;
            turnAnimationOn();
        }
        timer++;
    }

}

