using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public enum TaskType
    {
        Pickup,
        Fix,
        Open
    };

    public TaskType Type;
    public string Name;
    public int Count;
    public int TotalCount;
    public bool IsChecked
    {
        get
        {
            return Count >= TotalCount;
        }
    }
}
