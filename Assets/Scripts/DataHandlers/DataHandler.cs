using System.Collections.Generic;
using UnityEngine;

public abstract class DataHandler<T> : MonoBehaviour
{
    [SerializeField] List<T> datas;
    public List<T> GetData()
    {
        return datas;
    }
}