using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WarriorsButtonsCreator : ButtonsCreator<WarriorData>
{
    [SerializeField] WarriorsDataHandler warriorsDataHandler; //unity can't work with DataHandler<T>(T is reason)
    private void Start()
    {
        base.dataHandler = warriorsDataHandler;
        GenerateButtons();
    }    
}
