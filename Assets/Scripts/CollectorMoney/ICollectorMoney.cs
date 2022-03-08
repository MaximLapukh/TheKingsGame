using System;

public interface ICollectorMoney
{
    public void AddCollectMoneyListener(Action<int> listener);
    public void AddProduceMoney(IProduceMoney produce);
    public void CollectMoneyFrom(int money);
}

