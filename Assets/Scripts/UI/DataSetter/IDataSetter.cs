using UnityEngine;

public interface IDataSetter<T> where T : ScriptableObject//maybe better name is DataViewer
{
    public void SetData(T data);
}

