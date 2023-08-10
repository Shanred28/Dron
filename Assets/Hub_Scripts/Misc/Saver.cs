using System;
using System.IO;
using UnityEngine;

namespace Hacaton
{
    [Serializable]
    public class Saver<T>
    {
        public T Data;
       
        public static void TryLoad(string filename, ref T data)
        {
            //data = default(T);
            var path = FileHandler.Path(filename);
            if (File.Exists(path))
            {
                //Debug.Log($"Loading from {filename}...");
                var dataString = File.ReadAllText(path);
                var saver = JsonUtility.FromJson<Saver<T>>(dataString);
                data = saver.Data;
            }
            else
            {
                //Debug.Log($"File {filename} not found in {Application.persistentDataPath}");
            }

        }

        public static void Save(string filename, T data)
        {
            var path = FileHandler.Path(filename);
            //Debug.Log($"Saving to {path}...");
            var wrapper = new Saver<T> { Data = data };
            var dataString = JsonUtility.ToJson(wrapper);
            File.WriteAllText(path, dataString);
        }
    }

    public static class FileHandler
    {
        public static string Path(string filename)
        {
            return $"{Application.persistentDataPath}/{filename}";
        }

        public static void Reset(string filename)
        {
            var path = Path(filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static bool CheckFile(string filename)
        {
            return File.Exists(Path(filename));
        }
    }
}