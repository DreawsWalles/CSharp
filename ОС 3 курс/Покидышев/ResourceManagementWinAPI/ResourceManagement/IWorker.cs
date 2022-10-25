namespace ResourceManagement
{
    internal interface IWorker
    {
        int N { get; }
        string Name { get; set; }
        Resource Resource { get; }
        WorkerState State { get; }

        void Work();
    }
}