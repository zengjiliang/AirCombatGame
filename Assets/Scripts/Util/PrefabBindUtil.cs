#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:PrefabBindUtil.cs
// 创建时间:2024年1月31日 2:17
#endregion

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class PrefabBindUtil
    {
        private static  readonly Dictionary<string, Type> mPrefabBindMap = new Dictionary<string, Type>();
        public static void Bind(string path,Type type)
        {
            if (mPrefabBindMap.ContainsKey(path) == false)
            {
                mPrefabBindMap.Add(path,type);
            }
        }

        public static bool TryGetType(string path,out Type value)
        {
            return mPrefabBindMap.TryGetValue(path,out value);
        }

        public static Type GetType(string path)
        {
            if (TryGetType(path, out var value))
            {
                return value;
            }
            else
            {
                Debug.LogError($"脚本{path}不存在");
                return null;
            }
        }
    }
}