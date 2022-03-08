using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ButtonsCreator<T> : MonoBehaviour where T : ScriptableObject 
{
    [HideInInspector]
    public DataHandler<T> dataHandler;
    [SerializeField] Button buttonPref;
    [SerializeField] Transform parentButtons;
    public UnityEvent<T> ClickButton;
    public void GenerateButtons()
    {
        if (dataHandler != null)
        {
            foreach (var data_item in dataHandler.GetData())
            {
                var button = Instantiate(buttonPref);
                button.transform.SetParent(parentButtons);

                //Load data to button
                if (button.TryGetComponent<IDataSetter<T>>(out var data_setter))
                {
                    data_setter.SetData(data_item);
                }

                button.onClick.AddListener(() => { ClickButton.Invoke(data_item); });

            }
        }
    }
}
