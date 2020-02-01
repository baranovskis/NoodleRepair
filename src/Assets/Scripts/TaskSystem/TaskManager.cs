using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        float modifier = 89f;

        if (TaskObject != null)
        {
            foreach (var task in CurrentTasks)
            {
                var taskObject = Instantiate(TaskObject,
                    gameObject.transform.position
                    + transform.up * modifier,
                    Quaternion.identity, gameObject.transform);

                for (int i = 0; i < taskObject.transform.childCount; i++)
                {
                    Transform child = taskObject.transform.GetChild(i);
                    if (child.tag == "TaskText")
                    {
                        var textComponent = child.GetComponent<Text>();
                        textComponent.text = task.TaskText;
                    }

                    if (child.tag == "TaskCheck")
                    {
                        var imageComponent = child.GetComponent<Image>();
                        imageComponent.enabled = task.IsFinished();
                    }
                }

                        modifier -= 35f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}