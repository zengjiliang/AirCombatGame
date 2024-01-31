#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:JsonReader.cs
// 创建时间:2024年2月1日 0:0
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using LitJson;
using Module.Interface;
using UnityEngine;
using Util;

namespace Module.Reader
{
    public class JsonReader : IReader
    {
        public IReader this[string key] {
            get
            {
                if (SetKey(key) == false)
                {
                    mCacheData = mCacheData[key];
                }
                return this;
            }
        }

        public IReader this[int key]
        {
            get
            {
                if (SetKey(key) == false)
                {
                    mCacheData = mCacheData[key];
                }
                return this;
            }
        }

        public void Get<T>(Action<T> callBack)
        {
            if (mKeys != null)
            {
                mKeys.OnComplete((json) =>
                {
                    T data =  GetValue<T>(json);
                    callBack.Invoke(data);
                    ResetData();
                });
                mKeyQueue.Enqueue(mKeys);
                mKeys = null;
                ExecuteKeysQueue();
                return;
            }
            if (callBack == null)
            {
                Debug.LogWarning("当前回调方法为空!!!");
                ResetData();
                return;
            }

            T data =  GetValue<T>(mCacheData);
            callBack.Invoke(data);
            ResetData();
        }

        public void SetData(object data)
        {
            if (data is string str)
            {
                Debug.LogError(str);
                mJsonData =  JsonMapper.ToObject(str);
                ResetData();
                ExecuteKeysQueue();
            }
            else
            {
                Debug.LogError("传入数据类型错误,当前类只能解析json数据!");
            }
            
        }

        private void ExecuteKeysQueue()
        {
            if(mJsonData == null)
            { 
                return;
            }

            IReader reader = null;
            foreach (var keyQueue in mKeyQueue)
            {
                foreach (var key in keyQueue)
                {
                    if (key is string str)
                    {
                        reader = this[str];
                    }
                    else if(key is int num)
                    {
                        reader = this[num];
                    }
                    else
                    {
                        Debug.LogError("当前键值类型错误❌");
                    }
                   
                }
                keyQueue.Complete(mCacheData);
            }
        }
        private T GetValue<T>(JsonData data)
        {
            Type type = typeof(T);
            return (T)GameUtils.Instance.TypeConverter(type).ConvertTo(data.ToJson(), type);
        }

        private bool SetKey<T>(T key)
        {
            if ( mJsonData == null || mKeys != null )
            {
                if ( mKeys == null )
                {
                    mKeys = new KeyQueue();
                }
                IKey jsonKey = new JsonKey();
                jsonKey.Set(key);
                mKeys.Enqueue(jsonKey);
                return true;
            }
            return false;
        }
        private void ResetData()
        {
            if (mCacheData == null)
            {
                mCacheData = mJsonData;
            }
        }
        private JsonData mJsonData = null;
        private JsonData mCacheData = null;
        private KeyQueue mKeys = null;
        private Queue<KeyQueue> mKeyQueue = new Queue<KeyQueue>();
    }
}