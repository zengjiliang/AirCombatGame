#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:Singleton.cs
// 创建时间:2024年1月30日 23:47
#endregion

using UnityEngine;

namespace Util
{
    public class Singleton<T> where T:class,new()
    {
        private static T mInstance;
        private static object mutx  = new object();
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mutx)
                    {
                        if (mInstance == null)
                        {
                            mInstance = new T();
                            if (mInstance is MonoBehaviour)
                            {
                                Debug.LogError("instance is MonoBehaviour");
                                return null;
                            }

                            
                        }
                    }
                   
                }
                return mInstance;
            }
        }
        
    }
}