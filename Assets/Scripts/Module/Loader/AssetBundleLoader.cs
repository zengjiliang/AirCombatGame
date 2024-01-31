#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:AssetBundleLoader.cs
// 创建时间:2024年1月31日 0:19
#endregion

using Module.Interface;
using UnityEngine;

namespace Module.Loader
{
    public class AssetBundleLoader:ILoader
    {
        public GameObject LoadPrefab(string path, Transform parent = null)
        {
            throw new System.NotImplementedException();
        }
    }
}