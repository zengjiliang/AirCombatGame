#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ReaderConfig.cs
// 创建时间:2024年2月1日 2:0
#endregion

using System;
using System.Collections.Generic;
using Module.Interface;
using Module.Reader;
using UnityEngine;
using Util;

namespace Config
{
    public class ReaderConfig:Singleton<ReaderConfig>
    {
        private readonly Dictionary<string, Func<IReader>> mReaderDictionary = new Dictionary<string, Func<IReader>>()
        {
            {".json",()=>new JsonReader()},
        };

        public IReader GetReader(string path)
        {
            foreach (var pair in mReaderDictionary)
            {
                if (path.Contains(pair.Key))
                {
                    return pair.Value.Invoke();
                }
            }
            Debug.LogError($"未找到{path}对应文件的读取器");
            return default;
        }
    }
}