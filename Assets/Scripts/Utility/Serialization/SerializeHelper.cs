using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace P2Playworks.ModularFrameworks
{
    public static class SerializeHelper
    {
        public static readonly string DirPath =
            (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer ?
            Application.persistentDataPath :
            Application.dataPath) + "/SaveDatas";

        public static void ReadFromDisk<T> (string filePath, ref T data)
        {
            var dataPath = DirPath + filePath;

            try
            {
                var jsonStr = File.ReadAllText(dataPath);

                data = JsonUtility.FromJson<T>(jsonStr);

                Debug.Log("Success :: Load Data");
            }
            catch (System.Exception e)
            {
                Debug.Log("Fail :: Load Data");
                Debug.Log($"Exception :: {e}");
            }
        }

        public static void WriteToDisk<T> (string filePath, ref T data)
        {
            var dataPath = DirPath + filePath;
            
            //Create Directory
            try
            {
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                    Debug.Log("Success :: Create Directory");
                    Debug.Log($"Path :: {DirPath}");
                }
            }
            catch(System.Exception e)
            {
                Debug.Log("Fail :: Create Directory");
                Debug.Log($"Exception :: {e}");
            }

            //Create File
            try
            {
                if (!File.Exists(dataPath))
                {
                    File.Create(dataPath).Close();
                    Debug.Log("Success :: Create File");
                    Debug.Log($"Path :: {dataPath}");
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("Fail :: Create File");
                Debug.Log($"Exception :: {e}");
            }

            //Write File
            try
            {
                var jsonStr = JsonUtility.ToJson(data, true).ToString();

                File.WriteAllText(dataPath, jsonStr);

                Debug.Log("Success :: Save Data");

                //Threading
                /*var jsonStr = JsonUtility.ToJson(data, true).ToString();

                System.Threading.Tasks.Task t = System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    File.WriteAllText(dataPath, jsonStr);
                });*/

                //File Operation Should be Threaded or Task
            }
            catch (System.Exception e)
            {
                Debug.Log("Fail :: Save Data");
                Debug.Log($"Exception :: {e}");
            }
        }
    }
}
