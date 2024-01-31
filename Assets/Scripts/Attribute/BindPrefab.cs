#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:BindPrefab.cs
// 创建时间:2024年1月31日 1:8
#endregion

using System;

namespace Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BindPrefab:System.Attribute
    {
        public string Path { get; private set; }

        public BindPrefab(string path)
        {
            Path = path;
        }
    }
}