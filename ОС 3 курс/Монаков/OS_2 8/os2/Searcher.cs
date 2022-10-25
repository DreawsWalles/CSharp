using System.IO;

namespace os2
{
    class Searcher
    {
        private string _path;
        private int _hidden;
        private int _onlyHidden;
       
        public Searcher(string p)
        {
            _path = p;
            _hidden = _onlyHidden = 0;
        }

        public string GetResult()
        {
            return _hidden.ToString() + "(" + _onlyHidden.ToString() + ")";
        }

        private void SearchInDir(string path)
        {
            foreach (string file in RsdnDirectory.GetFilse(path))
            {
                FileAttributes fAttr;
                fAttr = File.GetAttributes(path + "\\" + file);
                if (fAttr.HasFlag(FileAttributes.Hidden))
                {
                    _hidden++;
                    if ((fAttr | FileAttributes.Hidden) == FileAttributes.Hidden)
                        _onlyHidden++;
                }

            }
        }
        public void CountHiddens()
        {
            SearchInDir(this._path);
            foreach (string dir in RsdnDirectory.GetAllDirectories(_path))
                SearchInDir(dir);                                                                                                                                          
        }
    }
}
