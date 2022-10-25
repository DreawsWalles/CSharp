using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskFour;

namespace StopOperationLibrary
{
    public interface IBus : IMoveObject
    {
        PictureBox picture { get; set; }
        Point CurrentLocation { get; set; }
    }
}
