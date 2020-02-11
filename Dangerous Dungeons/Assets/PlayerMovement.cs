using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player vars

    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    public int Dir;

    //Camera vars
    public Camera Cam;
    private Vector3 CamChange;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        Move(change);
        //camera moving with the player
        CamChange = rb.transform.position;
        CamChange.z = -10;
        Cam.transform.position = CamChange;

    }
    
    //funcion to move the player
    private void Move(Vector3 Vec3)
    {
        if (Vec3 != Vector3.zero)
        {
            if (Vec3.x != 0 && Vec3.y != 0)
                rb.MovePosition(transform.position + Vec3 * speed/Mathf.Sqrt(2) * Time.deltaTime);
            else
                rb.MovePosition(transform.position + Vec3 * speed * Time.deltaTime);
           
            //setting direction value.
            if (Vec3.x == 1)
                Dir = 1;
            else if (Vec3.x == -1)
                Dir = 3;
            else if (Vec3.y == 1)
                Dir = 0;
            else
                Dir = 2;
        }
    }
}
