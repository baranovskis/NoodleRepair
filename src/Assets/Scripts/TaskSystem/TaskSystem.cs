using Assets.Scripts.Interaction.Fixing;
using Assets.Scripts.Interaction.Pickups;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskSystem 
{
	private readonly List<Task> _tasks;

	public TaskSystem()
	{
		_tasks = new List<Task>();
		FindObjects();
	}

	public void FindObjects()
	{
		var pickups = GameObject.FindGameObjectsWithTag("Pickup");

		foreach (var pickup in pickups)
		{
			var obj = pickup.GetComponent<IPickupuble>();

			if (obj != null)
			{
				var task = _tasks.FirstOrDefault(e => e.Name == obj.Name);

				if (task != null)
				{
					++task.TotalCount;
					continue;
				}

				_tasks.Add(new Task
				{
					Type = Task.TaskType.Pickup,
					Name = obj.Name,
					Count = 0,
					TotalCount = 1,
				});
			}
		}

		var fixables = GameObject.FindGameObjectsWithTag("FixableObject");

		foreach (var fixable in fixables)
		{
			var obj = fixable.GetComponent<IFixable>();

			if (obj != null)
			{
				var task = _tasks.FirstOrDefault(e => e.Name == obj.Name);

				if (task != null)
				{
					++task.TotalCount;
					continue;
				}

				_tasks.Add(new Task
				{
					Type = Task.TaskType.Fix,
					Name = obj.Name,
					Count = 0,
					TotalCount = 1,
				});
			}
		}
	}
	
	public List<Task> GetTasks()
	{
		return _tasks;
	}
}
