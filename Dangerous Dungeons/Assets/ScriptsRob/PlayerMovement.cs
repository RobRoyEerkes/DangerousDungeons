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
    private Animator animator;
    private SpriteRenderer Sprite;

    //Camera vars
    public Camera Cam;
    private Vector3 CamChange;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
            Move(change);
        else
            animator.SetBool("Moving", false);

        //camera moving with the player
        CamChange = rb.transform.position;
        CamChange.z = -8;
        Cam.transform.position = CamChange;
        animator.SetInteger("Dir", Dir);

    }
    
    //funcion to move the player
    private void Move(Vector3 Vec3)
    {
        animator.SetBool("Moving", true);
     
     
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

        if (Dir == 3)
            Sprite.flipX = true;
        else
            Sprite.flipX = false;
     
    }
}
