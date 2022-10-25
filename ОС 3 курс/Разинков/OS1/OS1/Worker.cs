using System.Windows.Forms;

public abstract class Worker
{
    protected string name;

    /// <summary>
    /// Имя работника
    /// </summary>
    public string Name
    {
        get { return name; }
    }

    protected int countActionsToDo;

    /// <summary>
    /// Количество действий, которое должен сделать работник
    /// </summary>
    public int CountActionsToDo
    {
        get { return countActionsToDo; }
    }

    protected bool stop;

    protected int performedActions;

    public int PerformedActions
    {
        get { return performedActions; }
    }

    protected TextBox log;

    protected delegate void Logger();

    /// <summary>
    /// Создание работника, выполняющего какое-то действие в количестве, равном ActionsCount
    /// </summary>
	public Worker(string WorkerName, int CountActions, TextBox Log)
	{
        name = WorkerName;
        countActionsToDo = CountActions;
        performedActions = 0;
        stop = false;
        log = Log;
	}

    public abstract void DoWork();

    public void Stop()
    {
        stop = true;
    }
}
