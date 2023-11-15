using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMonitor : MonoBehaviour
{
    [SerializeField] int maxAmountWater;
    [SerializeField] int maxAmountWood;
    [SerializeField] int maxAmountFood;
    [SerializeField] int maxAmountStone;
    [SerializeField] ResourcesStorage storage;
    [SerializeField] TextMeshProUGUI[] elements;
    [SerializeField] TextMeshProUGUI timeLeft;
    [SerializeField] bool waterComplete, woodComplete, foodComplete, stoneComplete;
    [SerializeField] GameObject winUI, loseUI;
    [SerializeField] float limitTime, maxTime, timeToLose;
    public bool canCountTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        maxAmountWater = Random.Range(10,20);
        maxAmountWood = Random.Range(10,20);
        maxAmountFood = Random.Range(10,20);
        maxAmountStone = Random.Range(10,20);
        maxTime = Random.Range(120, 300);
        waterComplete = false;
        woodComplete = false;
        foodComplete = false;
        stoneComplete = false;
        elements[0].text = "" + maxAmountWater;
        elements[1].text = "" + maxAmountWood;
        elements[2].text = "" + maxAmountStone;
        elements[3].text = "" + maxAmountFood;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToLose = maxTime - limitTime;
        timeLeft.text = timeToLose.ToString("f0"); 

        if (maxAmountWater <= storage.waterStored)
        {
            waterComplete = true;
        }

        if (maxAmountWood <= storage.woodStored)
        {
            woodComplete = true;
        }

        if (maxAmountFood <= storage.foodStored)
        {
            foodComplete = true;
        }

        if (maxAmountStone <= storage.stoneStored)
        {
            stoneComplete = true;
        }

        if(waterComplete && woodComplete && foodComplete && stoneComplete)
        {
            winUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(limitTime >= maxTime)
        {
            loseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void FixedUpdate()
    {
        if (canCountTime)
        {
            limitTime += Time.deltaTime;
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        canCountTime = true;
    }
}
