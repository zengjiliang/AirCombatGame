#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:JsonKey.cs
// 创建时间:2024年2月1日 0:43
#endregion

using System;
using Module.Interface;
using UnityEngine.UIElements;

namespace Module.Reader
{
    public class JsonKey:IKey
    {
        private object mKey;
        public void Set<T>(T key)
        {
            mKey = key;
        }

        public object Get()
        {
            return mKey;
        }

        public Type KeyType { get; private set; }
    }
}