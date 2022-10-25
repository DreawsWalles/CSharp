using System.Collections.Generic;

namespace Task4
{
    // Базовый интерфейс
    public interface IQueue<T> : IEnumerable<T>
    {
        // Число элементов
        int Count { get; }
        // Проверка на пустоту
        bool IsEmpty { get; }
        // Добавить элемент в очередь
        void Enqueue(T elem);
        // Очистить очередь
        void Clear();
        // Изъять элемент из очереди
        T Dequeue();
    }
}
