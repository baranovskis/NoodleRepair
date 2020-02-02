using Assets.Scripts.Interaction.Pickups;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TaskSystemUI : MonoBehaviour
{
    private TaskSystem _taskSystem;
    private Transform _taskContainer;
    private Transform _taskTemplate;

    public AudioSource AudioSource;
    public AudioClip SuccessClip;

    public float MergeY = -39.0f;
    public float ItemCellSize = 18.5f;

    private void Awake()
    {
        _taskContainer = transform.Find("TaskContainer");
        _taskTemplate = _taskContainer.Find("TaskTemplate");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _taskContainer.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _taskContainer.gameObject.SetActive(false);
        }
    }

    public void SetTaskSystem(TaskSystem task)
    {
        _taskSystem = task;

        DrawTasks();
    }

    public void CountItem(IPickupuble item)
    {
        var tasks = _taskSystem.GetTasks();

        if (tasks == null)
        {
            Debug.Log("CountItem == null");
            return;
        }

        var task = tasks.FirstOrDefault(e => e.Name == item.Name && e.Type == Task.TaskType.Pickup);

        if (tasks != null)
        {
            ++task.Count;
            DrawTasks();
        }
    }

    public void CountFix(FixableArea area)
    {
        var tasks = _taskSystem.GetTasks();

        if (tasks == null)
        {
            Debug.Log("CountFix == null");
            return;
        }

        var task = tasks.FirstOrDefault(e => e.Name == area.Name && e.Type == Task.TaskType.Fix);

        if (tasks != null)
        {
            ++task.Count;
            DrawTasks();
        }
    }

    private void DrawTasks()
    {
        if (_taskContainer == null)
            return;

        foreach (Transform child in _taskContainer)
        {
            if (child != _taskTemplate)
            {
                Destroy(child.gameObject);
            }
        }

        var tasks = _taskSystem.GetTasks();
        int pos = 0;

        foreach (var task in tasks)
        {
            var taskRect = Instantiate(_taskTemplate, _taskContainer).GetComponent<RectTransform>();

            taskRect.gameObject.SetActive(true);
            taskRect.anchoredPosition = new Vector2(0, MergeY + pos * ItemCellSize);

            var text = taskRect.Find("TaskText").GetComponent<Text>();

            switch (task.Type)
            {
                case Task.TaskType.Pickup:
                    text.text = $"Collected {task.Name}s {task.Count} of {task.TotalCount}";
                    break;
                case Task.TaskType.Fix:
                    text.text = $"Fix {task.Name}";
                    break;
            }

            if (task.IsChecked)
            {
                var check = taskRect.Find("Checked").GetComponent<Image>();
                check.gameObject.SetActive(true);
            }

            ++pos;
        }

        CheckTasks();
    }

    private void CheckTasks()
    {
        var task = _taskSystem.GetTasks().FirstOrDefault(e => !e.IsChecked);

        if (task != null)
            return;

        if (!AudioSource.isPlaying)
        {
            AudioSource.PlayOneShot(SuccessClip);
        }

        SceneSwitcher.instance.LoadNextScene();
    }
}
