using UnityEngine;

[CreateAssetMenu(fileName = "New Warrior Data",menuName = "Warrior Data")]
public class WarriorData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject WarriorPref;
    public int Price;
}
