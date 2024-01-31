#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:IKey.cs
// 创建时间:2024年2月1日 0:33
#endregion

using System;

namespace Module.Interface
{
    public interface IKey
    {
        void Set<T>(T key);
        object Get();
        Type KeyType { get; }
    }
}