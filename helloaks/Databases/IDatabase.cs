using System.Collections.Generic;

namespace HelloAKS.Databases
{
    public interface IDatabase
    {
        IEnumerable<KeyValuePair<string ,string>> GetAllData();
        bool TryGetData(string key, out string value);
        void PutData(string key, string value);
        void DeleteData(string key);
    }
}