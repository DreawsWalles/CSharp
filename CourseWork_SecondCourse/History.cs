using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace project
{
    [Serializable]
    public struct DataHistory
    {
        public string Name;
        public string Path;
        public string Date;
        public DataHistory(string name, string path, string date)
        {
            Name = name;
            Path = path;
            Date = date;
        }
        public DataHistory Read(ref FileStream fileStream)
        {
            try
            //if (fileStream.Position != fileStream.Length)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                DataHistory toLoad = (DataHistory)binaryFormatter.Deserialize(fileStream);
                Name = toLoad.Name;
                Path = toLoad.Path;
                Date = toLoad.Date;
            }
            catch { }
            return this;
        }
        public void Write(ref FileStream fileStream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, this);
        }
    };
    class History
    {
        List<DataHistory> List;
        bool IsEnglish;
        public int Count { get => List.Count; private set { } }
        public History(bool isEnglish)
        {
            List = new List<DataHistory>();
            IsEnglish = isEnglish;
            if (!Directory.Exists("System"))
            {
                Directory.CreateDirectory("System");
                File.Create("System/History.bin");
            }
            if (!File.Exists("System/History.bin"))
                File.Create("System/History.bin");
            else
            {
                FileStream file = new FileStream("System/History.bin", FileMode.Open);
                while (file.Position != file.Length)
                {
                    DataHistory Node = new DataHistory();
                    Node = Node.Read(ref file);
                    List.Add(Node);
                }
                file.Close();
            }
        }

        public DataHistory this[int index]
        {
            get
            {
                return List[index];
            }
            private set { }
        }
        public void Update(DataHistory node)
        {
            List.Remove(node);
            List.Insert(0, node);
        }
        public void Add(DataHistory node)
        {
            FileStream file = new FileStream("System/History.bin", FileMode.Append);
            List.Add(node);
            node.Write(ref file);
            file.Close();
        }
        public void LoadListBox(ref ListBox listBox)
        {
            listBox.Items.Clear();
            if (List.Count == 0)
                if (!IsEnglish)
                    listBox.Items.Add("--История пуста--");
                else
                    listBox.Items.Add("--History is empty--");
            else
                foreach (DataHistory element in List)
                    AddToListBox(element, ref listBox);
        }
        public void AddToListBox(DataHistory element, ref ListBox listBox)
        {
            string space;
            element.Date = element.Date.Insert(8, "                   ");
            space = "".PadRight(listBox.Size.Width / 20 - element.Name.Length);
            listBox.Items.Add(element.Name + space + element.Date);
        }
    }
}
