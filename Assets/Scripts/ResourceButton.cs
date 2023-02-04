using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Globals;

public class ResourceButton : MonoBehaviour
{
    public PlantResources plantType;
    public TextMeshProUGUI costText;

    private int cost;
    private void Start()
    {
        cost = ResourceCosts[plantType];
        costText.text = cost.ToString();
    }
}
