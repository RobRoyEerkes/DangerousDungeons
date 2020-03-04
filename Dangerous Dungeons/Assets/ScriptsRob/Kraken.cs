using System;
using System.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{
    public Player  player;
    private PlayerMovement PlayerM;
    
    void Start()
    {
        PlayerM = player.GetComponent<PlayerMovement>();
    }
    
    public void ImpairMovement()
    {
        
        PlayerM.enabled = false;
    } 


}
