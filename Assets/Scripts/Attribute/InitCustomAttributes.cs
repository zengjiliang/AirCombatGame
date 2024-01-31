#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:InitCustomAttributes.cs
// 创建时间:2024年1月31日 1:14
#endregion

using System;
using System.Reflection;
using UnityEngine;
using Util;

namespace Attribute
{
    public class InitCustomAttributes
    {
        public void Init(Type t)
        {
            Assembly assembly = Assembly.GetAssembly(t);
            var types = assembly.GetExportedTypes();
            foreach (var type in types)
            {
                if (type.GetCustomAttribute(t, true) is BindPrefab attribute)
                {
                    PrefabBindUtil.Bind(attribute.Path,type);
                }
            }
        }
    }
}