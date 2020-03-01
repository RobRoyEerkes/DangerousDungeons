using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SkeletAnim : MonoBehaviour
{
    public AIPath aiPath;
    Animator Anim;



    private void Start()
    {
        Anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (aiPath.desiredVelocity != Vector3.zero)
            Anim.SetBool("Moving", true);
        


        if (aiPath.desiredVelocity.x > 0.75f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Anim.SetInteger("Dir", 1);
        }
        else if (aiPath.desiredVelocity.x < -0.75f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Anim.SetInteger("Dir", 3);
        }
        else if (aiPath.desiredVelocity.y > 0.75f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Anim.SetInteger("Dir", 0);
        }
        else if (aiPath.desiredVelocity.y < -0.75f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Anim.SetInteger("Dir", 2);
        }
    }

}

