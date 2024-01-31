#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:UIUtils.cs
// 创建时间:2024年1月31日 3:9
#endregion

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using View.Data;

namespace Util
{
    public class UIUtils
    {
        private readonly  Dictionary<string, UIData> mDatas = new Dictionary<string, UIData>();

        private MonoBehaviour mMono = null;
        public  UIUtils(RectTransform rects,MonoBehaviour mono)
        {
            mMono = mono;
            foreach (RectTransform rect in rects)
            {
                mDatas.Add(rect.name,new UIData(rect));
            }
        }

        public UIData GetData(string name)
        {
            if (TryGetData(name, out var data))
            {
                return data;
            }
            else
            {
                Transform trf = mMono.transform.Find(name);
                if(trf == null)
                {
                    
                    Debug.LogError($"数据{name}不存在");
                }
                else
                {
                    mDatas.Add(name,new UIData(trf.GetComponent<RectTransform>()));
                    return mDatas[name];
                }
                
            }
            return null;
        }

        public bool TryGetData(string name, out UIData data)
        {
            return mDatas.TryGetValue(name, out data);
        }
    }
}