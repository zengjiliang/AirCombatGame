#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ILoader.cs
// 创建时间:2024年1月31日 0:12
#endregion

using UnityEngine;

namespace Module.Interface
{
    public interface ILoader
    {
        GameObject LoadPrefab(string path, Transform parent = null);
        
    }
}