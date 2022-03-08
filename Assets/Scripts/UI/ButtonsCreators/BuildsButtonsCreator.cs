using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildsButtonsCreator : ButtonsCreator<BuildData>
{
    [SerializeField] BuildsDataHandler buildsDataHandler;
    private void Start()
    {
        base.dataHandler = buildsDataHandler;
        GenerateButtons();
    }
}
