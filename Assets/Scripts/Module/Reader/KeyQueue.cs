#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:KeyQueue.cs
// 创建时间:2024年2月1日 0:34
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Module.Interface;
using UnityEngine;

namespace Module.Reader
{
    public class KeyQueue:IEnumerable
    {
        private Queue<IKey> mKeys = new Queue<IKey>();
        private Action<JsonData> mComplete = null;

        public void Enqueue(IKey key)
        {
            mKeys.Enqueue(key);
        }

        public void Dequeue()
        {
            mKeys.Dequeue();
        }

        public void Clear()
        {
            mKeys.Clear();
        }

        public void Complete(JsonData data)
        {
            if (mComplete != null)
            {
                mComplete.Invoke(data);
            }
        }
        public void OnComplete(Action<JsonData> complete)
        {
            if (complete == null)
            {
                Debug.LogError("complete is null");
                return;
            }
            mComplete = complete;
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var key in mKeys)
            {
                yield return key.Get();
            }
        }
    }
}