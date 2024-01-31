#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:LoadManager.cs
// 创建时间:2024年1月31日 0:12
#endregion

using System;
using Module.Interface;
using Module.Loader;
using UnityEngine;
using Util;

namespace Manager
{
    public class LoadManager:Singleton<LoadManager>
    {
        private ILoader mLoader;

        public void Init()
        {
            mLoader = new ResourcesLoader();
        }
        
        public GameObject LoadPrefab(string path, Transform parent = null)
        {
            return mLoader.LoadPrefab(path, parent);
        }
    }
}