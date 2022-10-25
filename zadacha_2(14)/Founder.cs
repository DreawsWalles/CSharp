using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadacha_2
{
    public class Founder
    {
        private readonly RichTextBox _tb;
        private readonly string _path;

        public Founder(string path, RichTextBox tb)
        {
            _path = path;
            _tb = tb;
        }

        public void AppendToTextBox(string value)
        {
            if (_tb.InvokeRequired)
            {
                _tb.Invoke(new Action<string>(AppendToTextBox), value + "\r\n");
                return;
            }
            _tb.AppendText(value + "\r\n");
        }

        private void ClearTextBox()
        {
            if (_tb.InvokeRequired)
            {
                _tb.Invoke(new Action(ClearTextBox));
                return;
            }
            _tb.Clear();
        }

        public void ChangeAttributes()
        {
            RsdnDirectory.ChangeFileAttributes(_path);
            GetDetailInfo();
        }

        public void GetDetailInfo()
        {
            ClearTextBox();
            foreach (var item in RsdnDirectory.GetFilesAttributes(_path))
            {
                AppendToTextBox(item.ToString());
            }
        }
    }
}
