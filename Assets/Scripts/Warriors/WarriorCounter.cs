using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCounter : MonoBehaviour
{
    [SerializeField] MoneyHandler moneyHandler;
    public void BuyWarrior(WarriorData warrior_data)
    {
        if (moneyHandler.CanSpend(warrior_data.Price))
        {
            Debug.Log($"{warrior_data.Name} was hired for {warrior_data.Price}");
            moneyHandler.TrySpend(warrior_data.Price);
        }
    }
}
