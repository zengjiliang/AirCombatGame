#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:AssetBundleLoader.cs
// 创建时间:2024年1月31日 0:19
#endregion

using System;
using Module.Interface;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Module.Loader
{
    public class AssetBundleLoader:ILoader
    {
        public GameObject LoadPrefab(string path, Transform parent = null)
        {
            //throw new System.NotImplementedException();
            return null;
        }

        public void LoadConfig(string path, Action<object> complete)
        {
            //throw new NotImplementedException();
        }

        public T Load<T>(string path) where T : Object
        {
            throw new NotImplementedException();
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            throw new NotImplementedException();
        }

        public Sprite LoadSprite(string path)
        {
            throw new NotImplementedException();
        }

        public Sprite[] LoadSprites(string path)
        {
            throw new NotImplementedException();
        }
    }
}