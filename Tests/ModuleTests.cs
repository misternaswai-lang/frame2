using StudyTasksApi.Models;

namespace StudyTasksApi.Services;

public class TaskRepository
{
    private readonly List<StudyTask> _tasks = new();
    private int _nextId = 1;

    public List<StudyTask> GetAll()
    {
        return _tasks;
    }

    public StudyTask? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public StudyTask Add(StudyTask task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
        return task;
    }
}
