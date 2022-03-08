using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectorMoneyBase : MonoBehaviour, ICollectorMoney
{
    private event Action<int> collectMoneyEvent = delegate { };

    [SerializeField] float timeTick;
    private float time;

    private List<IProduceMoney> produces;
    private void Awake()
    {
        produces = new List<IProduceMoney>();
    }
    private void Start()
    {
        time = timeTick;
    }

    private void Update()
    {
        if(time <= 0)
        {
            CollectMoney();
            time = timeTick;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    private void CollectMoney()
    {
        if (produces.Count == 0) return;

        var sum = 0;
        foreach (var produce_item in produces)
        {
            sum += produce_item.GetMoney();
        }
        collectMoneyEvent.Invoke(sum);
    }
    public void AddCollectMoneyListener(Action<int> listener)
    {
        collectMoneyEvent += listener;
    }
    public void AddProduceMoney(IProduceMoney produce)
    {
        produces.Add(produce);
    }

    public void CollectMoneyFrom(int money)
    {
        collectMoneyEvent.Invoke(money);
    }
}
