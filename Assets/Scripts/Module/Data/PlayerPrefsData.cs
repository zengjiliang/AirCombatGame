#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:PlayerPrefsData.cs
// 创建时间:2024年1月31日 22:22
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Module.Interface;
using UnityEngine;
using Util;

namespace Module.Data
{
    public class PlayerPrefsData:IDataMemory
    {
        private readonly Dictionary<Type, Func<string, object>> mDataGetter =
            new Dictionary<Type, Func<string, object>>()
            {
                {typeof(int),key=>PlayerPrefs.GetInt(key,-1)},
                {typeof(float),key=>PlayerPrefs.GetFloat(key,-1.0f)},
                {typeof(string),key=>PlayerPrefs.GetString(key,String.Empty)},
            };
        private readonly Dictionary<Type, Action<string, object>> mDataSetter =
            new Dictionary<Type, Action<string, object>>()
            {
                {typeof(int),(key,value)=>PlayerPrefs.SetInt(key, (int)value)},
                {typeof(float),(key,value)=>PlayerPrefs.SetFloat(key, (float)value)},
                {typeof(string),(key,value)=>PlayerPrefs.SetString(key, (string)value)},
            };
        public T Get<T>(string key)
        {
            Type type = typeof(T);
            if (mDataGetter.TryGetValue(type, out var func))
            {
                return (T)TypeDescriptor.GetConverter(type).ConvertTo(func(key),type);
            }
            Debug.LogError($"当前{type.Name}类型数据不存在");
            return default;
        }

        public void Set<T>(string key, T value)
        {
            Type type = typeof(T);
            if (mDataSetter.TryGetValue(type, out var func))
            {
                func(key, value);
            }
            Debug.LogError($"当前{type.Name}类型数据不存在");
        }

        public void Remove(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public void RemoveAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}