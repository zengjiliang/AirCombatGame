#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ResourcesLoader.cs
// 创建时间:2024年1月31日 0:13
#endregion

using System;
using Module.Interface;
using UnityEngine;
using Util;

namespace Module.Loader
{
    public class ResourcesLoader:ILoader
    {
        public GameObject LoadPrefab(string path, Transform parent = null)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject obj = GameObject.Instantiate(prefab, parent);
            obj.name = prefab.name;
   
            //obj.AddComponent(Type.GetType(GameUtils.Path2Namespace(path)));
            return obj;
        }
    }
}