using System.Collections.Generic;

namespace HelloAKS.Databases
{
    public class InMemoryDatabase : IDatabase
    {
        private Dictionary<string, string> _db = new Dictionary<string, string>();

        public IEnumerable<KeyValuePair<string, string>> GetAllData()
        {
            return _db;
        }
        
        public bool TryGetData(string key, out string value)
        {
            return _db.TryGetValue(key, out value);
        }

        public void PutData(string key, string value)
        {
            _db[key] = value;
        }

        public void DeleteData(string key)
        {
            _db.Remove(key);
        }
    }
}