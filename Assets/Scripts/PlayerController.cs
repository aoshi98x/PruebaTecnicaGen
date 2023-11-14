using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rigidPlayer;
    Animator animatorControl;
    
    [Space]

    [Header("Movement")]
    [SerializeField, Range(0, 10)] float speedMov;
    [SerializeField] private float movX, movY;
    Vector2 moveInput;

    [Space]

    [Header("Sound")]
    [SerializeField] AudioClip Walk;

    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        rigidPlayer.gravityScale = 0;
        animatorControl = GetComponent<Animator>();
    }


    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(movX, movY);
        if(Input.GetButton("Run"))
        {
            speedMov = 4;
        }
        else
        {
            speedMov = 2;
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal")!= 0 && Input.GetAxisRaw("Vertical")!= 0)
        {
            animatorControl.SetFloat("speed", 0.0f);
            rigidPlayer.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            animatorControl.SetFloat("speed", moveInput.sqrMagnitude);
            animatorControl.SetFloat("horizontal", movX);
            animatorControl.SetFloat("vertical", movY);
            rigidPlayer.bodyType = RigidbodyType2D.Dynamic;
            Movement();
        }
    }
    void Movement()
    {
        rigidPlayer.MovePosition(rigidPlayer.position + moveInput.normalized * speedMov * Time.fixedDeltaTime);
    }
}
