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
using Object = UnityEngine.Object;

namespace Manager
{
    public class LoadManager:Singleton<LoadManager>,ILoader
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

        public void LoadConfig(string path, Action<object> complete)
        {
            mLoader.LoadConfig(path,complete);
        }

        public T Load<T>(string path) where T : Object
        {
           return mLoader.Load<T>(path);
        }
        
        public T[] LoadAll<T>(string path) where T : Object
        {
            return mLoader.LoadAll<T>(path);
        }

        public Sprite LoadSprite(string path)
        {
            return mLoader.LoadSprite(path);
        }

        public Sprite[] LoadSprites(string path)
        {
            return mLoader.LoadSprites(path);
        }
    }
}