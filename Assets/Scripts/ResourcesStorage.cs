using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesStorage : MonoBehaviour
{
    public int waterStored;
    public int woodStored;
    public int foodStored;
    public int stoneStored;
    [SerializeField] TextMeshProUGUI[] elements;
    void LateUpdate()
    {
        elements[0].text = "" + waterStored;
        elements[1].text = "" + woodStored;
        elements[2].text = "" + stoneStored;
        elements[3].text = "" + foodStored;
    }

}
