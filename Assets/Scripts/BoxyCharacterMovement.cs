using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyCharacterMovement : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    #endregion

    #region PRIVATE_PROPERTIES
    private Animator anim;
    private bool facingRight = true;
    private Vector3 initalScale;
    #endregion

    #region UNITY_CALLBACKS


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        initalScale = transform.localScale;
    }
    void Update()
    {
        // Get horizontal input
        //float move = Input.GetAxis("Horizontal");
        //movement = new Vector2(move * speed, rb.velocity.y);
        Move();
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
    }

    #endregion

    #region PUBLIC_METHODS
    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        movement = new Vector2(move * speed, rb.velocity.y);
        //transform.position is used to store the position of the player
        //here vector temp is equal to tranform.position which means vector3 hold the x,y,z coordinates of the player


        if (move > 0 && !facingRight)
        {
            //going to the right side

            anim.SetBool("Walk", true);
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            //going to the left side

            anim.SetBool("Walk", true);
            Flip();
        }
        else if (move == 0)
        {
            anim.SetBool("Walk", false);
        }

    }
    #endregion

    #region PRIVATE_METHODS
    public void Flip()
    {
        // Flip the character by inverting the x scale
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    #endregion

    #region DELEGTE_CALLBACKS
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Optional: You can handle collision-specific logic here
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Example: Stop the player
            rb.velocity = Vector2.zero;
            //rb.gravityScale = 0;
            // Get the GameObject that the player collided with
            //GameObject collidedObject = collision.gameObject;
            transform.rotation = Quaternion.Euler(0, -180, 0);
            //transform.loca = initalScale;
            //GameObject current = collision.gameObject;
            //GameObject aboveCurrent = current.transform.parent.gameObject;
            //transform.SetParent(aboveCurrent.transform.parent);
        }
        if (collision.gameObject.CompareTag("Fall"))
        {
            BoxyUiManager.Instance.boxyMainView.SetStartingPoint();
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            BoxyManager.Instance.starCollected++;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("End"))
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            BoxyManager.Instance.OnLevelComplete();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gate"))
        {
            rb.gravityScale = 0;
        }
        BoxyRoomMovementNew room;
        if (collision.gameObject.CompareTag("Room"))
        {
            if (BoxyUiManager.Instance.boxyMainView.prevRoom == null)
            {
                room = collision.gameObject.GetComponent<BoxyRoomMovementNew>();
                BoxyUiManager.Instance.boxyMainView.prevRoom = room;
            }
            else
            {
                BoxyUiManager.Instance.boxyMainView.prevRoom.isEntered = false;
                room = collision.gameObject.GetComponent<BoxyRoomMovementNew>();
                BoxyUiManager.Instance.boxyMainView.prevRoom = room;
            }
            room.isEntered = true;
            transform.SetParent(collision.gameObject.transform);
        }
    }
    #endregion

    #region Coroutines
    #endregion
}
