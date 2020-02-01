using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public GameObject TaskObject;

    public List<RepairTask> CurrentTasks { get; set; }

    public bool AreAllTasksFinished()
    {
        bool allTasksFinished = true;

        foreach (var task in CurrentTasks)
        {
            if (!task.IsFinished())
            {
                allTasksFinished = false;
            }
        }

        return allTasksFinished;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentTasks = new List<RepairTask>
        {
            new RepairTask{ TaskText = "Test 1" },
            new RepairTask{ TaskText = "Test 2" },
            new RepairTask{ TaskText = "Test 3" }
        };

        foreach(var task in CurrentTasks)
        {
            if (TaskObject != null)
            {
                Instantiate(TaskObject, gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}