using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken : MonoBehaviour
{
    public GameObject  player;
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
