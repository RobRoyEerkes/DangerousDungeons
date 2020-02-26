using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SlimeAnim : MonoBehaviour
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


        if (aiPath.desiredVelocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (aiPath.desiredVelocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

}
