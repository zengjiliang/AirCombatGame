#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ReaderManager.cs
// 创建时间:2024年2月1日 1:55
#endregion

using System.Collections.Generic;
using Config;
using Module.Interface;
using UnityEngine;
using Util;

namespace Manager
{
    public class ReaderManager:Singleton<ReaderManager>
    {
        private readonly Dictionary<string, IReader> mReaderDic = new Dictionary<string, IReader>();
        public IReader GetReader(string path)
        {
            IReader reader = null;
            if (mReaderDic.TryGetValue(path, out  reader))
            {
                return reader;
            }
            else
            {
                //从当前的配置总,获取一个新的reader
                reader = ReaderConfig.Instance.GetReader(path);
                LoadManager.Instance.LoadConfig(path, (data) =>
                {
                    Debug.Log(data);
                    reader.SetData(data);
                });
                if (reader != null)
                {
                    mReaderDic[path] = reader;
                }
                
                //读取当前路径配置数据,赋值reader
            }

            return reader;
        }
    }
}