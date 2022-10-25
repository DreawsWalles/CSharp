using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFour
{
    public enum MoveObject
    {
        Bus = 0,
        Passenger = 1
    };
    public interface IMoveObject : IDisposable
    {
        MoveObject MoveObject { get; }
        void Initialization(object location);
        void Move(object[] route);
        bool Loading(object obj);
        void Show();
        void Hide();
        new void Dispose();
    }
}
