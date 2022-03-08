using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsToggler : MonoBehaviour
{
    [SerializeField] List<GameObject> panels;
    public void ChosePanel(int index)
    {
        HideAllPanels();
        panels[index].SetActive(true);
    }

    private void HideAllPanels()
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
    }
}
