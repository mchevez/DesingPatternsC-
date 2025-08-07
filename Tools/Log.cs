namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;
        private static object _protect = new object();
        public static Log GetInstance(string path) 
        {
            lock (_protect)// protecion para cuando se trabaja con hilos
            {
                if (_instance == null)
                {
                    _instance = new Log(path);
                }
            }
            return _instance;
        }
        private Log(string path) { 
            _path = path;
        }

        public void Save(string message) {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
