using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnableAIPath : MonoBehaviour
{

    public AIPath AIPath;
    public AIDestinationSetter aiDS;
    Transform target;
    float DistancePlayer;
    public float RadiusForPath;
    Transform Enemy;

    void Start()
    {
        Enemy = GetComponent<Transform>();
        AIPath.canMove = false;
        target = aiDS.target;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsRange(RadiusForPath))
        {
            AIPath.canMove = true;
            this.enabled = false;
        }
    }


    public bool PlayerIsRange(float distance)
    {
        DistancePlayer = (target.position.x - Enemy.position.x) * (target.position.x - Enemy.position.x) + (target.position.y - Enemy.position.y) * (target.position.y - Enemy.position.y);
        return (DistancePlayer <= distance * distance);
    }

}
