using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CostManager : MonoBehaviour
{
    public static int Cost;
    public int startCost = 0;
    public Text costText;
    // Start is called before the first frame update
    void Start()
    {
        Cost = startCost;
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = "Total Bill: $" + Cost.ToString();
    }
}
