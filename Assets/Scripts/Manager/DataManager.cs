#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:DataManager.cs
// 创建时间:2024年1月31日 22:16
#endregion

using Module.Data;
using Module.Interface;
using UnityEngine.UIElements;
using Util;

namespace Manager
{
    public class DataManager:Singleton<DataManager>
    {
        private IDataMemory mDataMemory = null;

        public DataManager()
        {
            mDataMemory = new PlayerPrefsData();
        }

        public T Get<T>(string key)
        {
           return mDataMemory.Get<T>(key);
        }

        public void Set<T>(string key, T value)
        {
            mDataMemory.Set<T>(key,value);
        }

        public void Remove(string key)
        {
            mDataMemory.Remove(key);
        }

        public void RemoveAll()
        {
            mDataMemory.RemoveAll();
        }
    }
}