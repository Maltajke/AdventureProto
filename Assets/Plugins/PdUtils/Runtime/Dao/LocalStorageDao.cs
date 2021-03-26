using System.IO;
using UnityEngine;

namespace PdUtils.Dao
{
    public class LocalStorageDao<T> : IDao<T> where T : class
    {
        private readonly string _filename;
        private readonly string _filePath;

        public LocalStorageDao(string filename)
        {
            _filename = filename;
            _filePath = GetPath();
        }

        public void Save(T vo)
        {
            var json = JsonUtility.ToJson(vo);
            var serialized = json.Base64Encode();
            FileHandling.CreateDirectoryIfDoesntExistAndWriteAllText(_filePath, serialized);
        }

        public T Load()
        {
            if (!File.Exists(_filePath))
                return null;
            var json = File.ReadAllText(_filePath).Base64Decode();
            return JsonUtility.FromJson<T>(json);
        }

        public void Remove()
        {
            if (File.Exists(_filePath))
            {
                FileHandling.DeleteIfExists(_filePath);
            }
        }

        private string GetPath()
        {
            return Application.persistentDataPath + _filename;
        }
    }
}