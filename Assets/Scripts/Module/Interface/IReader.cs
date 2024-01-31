#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:IReader.cs
// 创建时间:2024年1月31日 23:33
#endregion

using System;

namespace Module.Interface
{
    public interface IReader
    {
        IReader this[string key] { get; }
        IReader this[int key] { get; }

        void Get<T>(Action<T> callBack);
        void SetData(object data);
    }
}