using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Build Data", menuName = "Build Data")]
public class BuildData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject BuildPref;
    public GameObject TemplatePref;
    public bool IsCollectMoney;
    public int Price;
}
