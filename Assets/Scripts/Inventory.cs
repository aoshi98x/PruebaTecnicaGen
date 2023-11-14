using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int water;
    public int wood;
    public int food;
    public int stone;
    [SerializeField] TextMeshProUGUI[] elements;
    [SerializeField] ResourcesStorage storage;
    bool canStorage;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && canStorage)
        {
            GiveResources();
        }
    }
    void LateUpdate()
    {
        elements[0].text = "" + water;
        elements[1].text = "" + wood;
        elements[2].text = "" + food;
        elements[3].text = "" + stone;
    }
    void GiveResources()
    {
        storage.waterStored += water;
        water = 0;
        storage.woodStored += wood;
        wood = 0;
        storage.foodStored += food;
        food = 0;
        storage.stoneStored += stone;
        stone = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("House"))
        {
            canStorage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canStorage = false;
    }
}
