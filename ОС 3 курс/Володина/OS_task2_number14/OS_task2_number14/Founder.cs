using System;
using System.Windows.Forms;

namespace OS_task2_number14
{
    public class Founder
    {
        private readonly TextBox _tb;
        private readonly string _path;

        public Founder(string path, TextBox tb)
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

        // меняем атрибуты файлов в соответсвии с условием задачи
        public void ChangeAttributes()
        {
            RsdnDirectory.ChangeFileAttributes(_path);
            GetDetailInfo();
        }

        // получаем информацию о файлах и печатаем ее
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
