using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player vars

    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;

    //Camera vars
    private Camera Cam;
    private Vector3 CamChange;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cam = Camera.main;

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

            //if (Vec3.x != 0 && Vec3.y != 0)
            //{
            //    rb.MovePosition(transform.position + Vec3 * speed/2 * Time.deltaTime);
            // }
            // else
            //  {
            rb.MovePosition(transform.position + Vec3 * speed * Time.deltaTime);
            //}
        }
    }
}
