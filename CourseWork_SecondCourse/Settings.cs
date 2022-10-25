using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace project
{
    [Serializable]
    public struct SettingsNode
    {
        public bool IsEnglish;
        public int DesignIsDefault;
        public SettingsNode(bool isEnglish, int designIsDefault)
        {
            IsEnglish = isEnglish;
            DesignIsDefault = designIsDefault;
        }

        public void Write(FileStream fileStream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, this);
        }

        public SettingsNode Read(FileStream fileStream)
        {
            if (fileStream.Position != fileStream.Length)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                SettingsNode toLoad = (SettingsNode)binaryFormatter.Deserialize(fileStream);
                IsEnglish = toLoad.IsEnglish;
                DesignIsDefault = toLoad.DesignIsDefault;
            }
            return this;
        }
    };
    public class Settings
    {
        public SettingsNode Node { get; set; }
        public bool isFirstRun { get; private set; }

        public Settings()
        {
            isFirstRun = true;
            if (!Directory.Exists("System"))
            {
                Directory.CreateDirectory("System");
                File.Create("System/Settings.bin");
            }
            if (!File.Exists("System/Settings.bin"))
                File.Create("System/Settings.bin");
            else
            {
                FileStream file = new FileStream("System/Settings.bin", FileMode.Open);
                if (file.Position != file.Length)
                {
                    Node = new SettingsNode();
                    Node = Node.Read(file);
                    isFirstRun = false;
                }
                file.Close();
            }
        }
        public void Refresh(SettingsNode node)
        {
            FileStream file = new FileStream("System/Settings.bin", FileMode.Create);
            node.Write(file);
            Node = node;
            file.Close();
        }
        public void Refresh()
        {
            FileStream file = new FileStream("System/Settings.bin", FileMode.Create);
            if (file.Position != file.Length)
            {
                Node = new SettingsNode();
                Node = Node.Read(file);
                isFirstRun = false;
            }
            file.Close();
        }
    }
}
