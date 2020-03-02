using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    DrakenBaas DB;

    void Start()
    {
        DB = GetComponentInParent<DrakenBaas>();
        DB.Is_in_Fire = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DB.Is_in_Fire = true;
        Debug.Log("in fire");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DB.Is_in_Fire = false;
    }
}
