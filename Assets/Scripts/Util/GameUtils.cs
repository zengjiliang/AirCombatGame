#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:GameUtils.cs
// 创建时间:2024年1月31日 0:56
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using View.Data;

namespace Util
{
    public  class GameUtils:Singleton<GameUtils>
    {
        public  string Path2Namespace(string path)
        {
            return path.Replace("/", ".");
        }

        public TypeConverter TypeConverter(Type type)
        {
            return TypeDescriptor.GetConverter(type);
        }

        public bool String2Int(string str, out int value)
        {
            return int.TryParse(str, out  value);
        }

        public string[] Split(string strs,char separator)
        {
            return strs.Split(separator);
        }
    }
}