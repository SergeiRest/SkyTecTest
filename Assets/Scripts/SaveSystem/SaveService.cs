using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.SaveSystem
{
    public class SaveService
    {
        public T Load<T>(string key) where T : ISaveLoad, new()
        {
            string value = PlayerPrefs.GetString(key, "");

            T objectValue;
            
            if (value == "")
            {
                objectValue = new T();
                string saveObject = JsonUtility.ToJson(objectValue);
                PlayerPrefs.SetString(key, saveObject);
            }
            else
                objectValue = JsonUtility.FromJson<T>(value);

            objectValue.Update += Save;

            return objectValue;
        }

        public void Save(ISaveLoad model, string key)
        {
            string saveObject = JsonUtility.ToJson(model);
            Debug.Log(saveObject);
            PlayerPrefs.SetString(key, saveObject);
        }
    }
}