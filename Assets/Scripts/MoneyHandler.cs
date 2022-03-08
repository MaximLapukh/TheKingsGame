using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] CollectorMoneyBase collectorMoney;//use better ICollectorMoney

    public UnityEvent<int> UpdateMoney;
    private void Start()
    {
        collectorMoney.AddCollectMoneyListener(AddMoney);
        UpdateMoney.Invoke(money);
    }
    private void AddMoney(int num)
    {
        money += num;
        UpdateMoney.Invoke(money);
    }
    private void TakeMoney(int num)
    {
        money -= num;
        UpdateMoney.Invoke(money);
    }
    public bool TrySpend(int num) 
    {
        if (num < 0)
        {
            Debug.LogError("Cannot spend sum that less zero!"); return false;
        }

        if(num <= money)
        {
            TakeMoney(num);
            return true;
        }

        return false;        
    }
    public bool CanSpend(int num)
    {
        if (num < 0)
        {
            Debug.LogError("Cannot spend sum that less zero!"); return false;
        }
        if (num <= money)
            return true;

        return false;
        
    }
    public int GetMoney()
    {
        return money;
    }
}
