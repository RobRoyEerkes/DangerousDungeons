using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public Kraken kraken;

    public void AnimEvent1()
    {
        kraken.Attack();
    }
    
    public void AnimEvent2()
    {
        kraken.RegainMovement();
    }
    
}
