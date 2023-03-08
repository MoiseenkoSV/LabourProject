using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using Application = UnityEngine.Device.Application;

public class GodSaveUs : MonoBehaviour
{
    private string _dataPath = Application.dataPath;
    private string _persistantPath = Application.persistentDataPath;
    private string _streamingPath = Application.streamingAssetsPath;
    private string _cachePath = Application.temporaryCachePath;
    public interface IData<T> //интерфейс с методами сохранения и загрузки данных
    {
        void Save(T data, string path = null);
        T Load(string path = null);
    }
    
    [Serializable] //Класс для работы с сохраняемыми данными.
    public sealed class SaveData
    {
    public string Name;
    public Vector3Serializable Position;
    public bool IsEnabled;

    public override string ToString() => $"Name {Name} Position {Position} IsVisible {IsEnabled}";
    }
    
    [Serializable]
    public struct Vector3Serializable //Создаем структуру с операторами для Vector3 для последующей сериализации. 
    {
        public float X;
        public float Y;
        public float Z;

        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $"(X={X} Y={Y} Z={Z} )";
    }
    
    public sealed class StreamData : IData<SaveData>
    {
        public void Save(SaveData saveData, string path = null)
        {
            if (path == null) return;
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(saveData.Name);
                sw.WriteLine(saveData.Position.X);
                sw.WriteLine(saveData.Position.Y);
                sw.WriteLine(saveData.Position.Z);
                sw.WriteLine(saveData.IsEnabled);
            }
        }

        public SaveData Load(string path)
        {
            var result = new SaveData();
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    result.Name = sr.ReadLine();
                    result.Position.X = sr.ReadLine().Single();
                    result.Position.Y = sr.ReadLine().Single();
                    result.Position.Z = sr.ReadLine().Single();
                    result.IsEnabled = bool.TryParse(sr.ReadLine(), out bool result1);
                }
            }

            return result;
        }
    }
    
    public class PlayerPrefsData : IData<SaveData>
    {
        public void Save(SaveData saveData, string path = null)
        {
            PlayerPrefs.SetString("Name", saveData.Name);
            PlayerPrefs.SetFloat("PosX", saveData.Position.X);
            PlayerPrefs.SetFloat("PosY", saveData.Position.X);
            PlayerPrefs.SetFloat("PosZ", saveData.Position.X);
            PlayerPrefs.SetString("IsEnable", saveData.IsEnabled.ToString());
            
            PlayerPrefs.Save();
        }

        public SaveData Load(string path = null)
        {
            var result = new SaveData();

            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = "PosX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }
            
            key = "PosY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }
            
            key = "PosZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }

            key = "IsEnabled";
            if (PlayerPrefs.HasKey(key))
            {
                result.IsEnabled = bool.TryParse(PlayerPrefs.GetString(key), out bool pp);
            }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
    
}
