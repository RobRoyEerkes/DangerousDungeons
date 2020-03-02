using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrakenBaas : MonoBehaviour
{
    private int timer;
    public int Health = 25;
    public PlayerCombat PlayerC;
    private int draakHoofd;
    public int damage;
    public bool Is_in_Fire;
    public Animator Anim;
    private BoxCollider2D[] Fires;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Fires = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D Fire in Fires)
        {
            Fire.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (timer > 300)
        {
            timer = 0;
            BlowFire();
        }
        timer++;
    }

    private void BlowFire()
    {
        draakHoofd = Mathf.RoundToInt(Random.value * 3);
        Anim.SetInteger("vuur maakt niet uit", draakHoofd);
        Fires[draakHoofd].enabled = true;
    }

    public void damagePlayer()
    {
        if (Is_in_Fire)
        {
            PlayerC.DamagePlayer(damage);
        }
        else
            Debug.Log("Missed");
    }

    public void OnFireComplete()
    {
        Fires[draakHoofd].enabled = false;
        Is_in_Fire = false;
        Anim.SetInteger("vuur maakt niet uit", 0);
    }

}
