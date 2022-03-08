using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyViwer : MonoBehaviour // int or T viewer in future
{
    [SerializeField] Text moneyText;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void UpdateMoney(int num)
    {
        moneyText.text = num.ToString();
    }
}
