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

    [Header("Collectables")]
    [SerializeField] Inventory inventory;
    [SerializeField]bool canTakeResource;
    string actualResource;
    [SerializeField] GameObject inventoryUI;
    bool isNearToHouse;
    [SerializeField]bool canSeeInventory;

    [Space]

    [Header("Sound")]
    [SerializeField] AudioClip Walk;

    void Start()
    {
        inventoryUI = GameObject.Find("ObjectsStored");
        inventoryUI.SetActive(false);
        canSeeInventory = false;
        inventory = GetComponent<Inventory>();  
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
        if(Input.GetMouseButtonDown(0) && canTakeResource)
        {
            switch (actualResource)
            {
                case "Water":

                    if(CanCatchResource())
                        inventory.water += 1;

                    break;
                
                case "Wood":

                    if (CanCatchResource())
                        inventory.wood += 1;

                    break;
                
                case "Food":

                    if (CanCatchResource())
                        inventory.food += 1;

                    break;

                case "Stone":

                    if (CanCatchResource())
                        inventory.stone += 1;

                    break;
            }
        }
        if(Input.GetButtonDown("Storage") && isNearToHouse)
        {
            canSeeInventory = !canSeeInventory;
            inventoryUI.SetActive(canSeeInventory);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Water":
                canTakeResource = true;
                actualResource = collision.tag;
                break;

            case "Wood":
                canTakeResource = true;
                actualResource = collision.tag;
                break;

            case "Food":
                canTakeResource = true;
                actualResource = collision.tag;
                break;

            case "Stone":
                canTakeResource = true;
                actualResource = collision.tag;
                break;
        }
        if (collision.gameObject.CompareTag("House"))
        { 
            isNearToHouse = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canTakeResource = false;
        isNearToHouse = false;
        canSeeInventory = false;
        inventoryUI.SetActive(false);
    }
    bool CanCatchResource()
    {
        int dice;
        dice = Random.Range(1, 7);
        if (dice == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
