using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildDataSetter : MonoBehaviour, IDataSetter<BuildData>
{
    [SerializeField] Image icon;
    [SerializeField] Text price;
    public void SetData(BuildData data)
    {
        icon.sprite = data.Icon;
        price.text = data.Price + "$";
    }
}
