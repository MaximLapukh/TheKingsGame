using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour, IBuild, IProduceMoney
{
    [SerializeField] int moneyPerTick;
    private BuildData buildData;
    public void BuildUp(BuildData build_data, ICollectorMoney collector_money)
    {
        //todo: start animation
        buildData = build_data;

        if (build_data.IsCollectMoney)
        {
            //maybe - moneyPerTick = build_data.moneyPerTick;
            //если ты хочешь, чтобы фабрика приносила деньги за свое время,
            //то реализуй это здесь и вызывай collector_money.CollectMoneyFrom(money)
            collector_money.AddProduceMoney(this);            
        }
    }

    public int GetMoney()
    {
        return moneyPerTick;
    }
}
