using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WarriorDataSetter : MonoBehaviour, IDataSetter<WarriorData>
{
    [SerializeField] Text name;
    [SerializeField] Image icon;
    [SerializeField] Text price;
    public void SetData(WarriorData data)
    {
        name.text = data.Name;
        icon.sprite = data.Icon;
        price.text = data.Price + "$";
    }
}

