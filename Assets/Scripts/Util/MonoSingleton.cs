#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:MonoSingleton.cs
// 创建时间:2024年1月30日 23:55
#endregion

using UnityEngine;

namespace Util
{
    public class UnitySingleton<T> : MonoBehaviour
        where T : Component {
        private static T mInstance = null;
        public static T Instance {
            get {
                if (mInstance == null) {
                    mInstance = FindObjectOfType(typeof(T)) as T;
                    if (mInstance == null) {
                        GameObject obj = new GameObject();
                        mInstance = (T)obj.AddComponent(typeof(T));
                        obj.hideFlags = HideFlags.DontSave;
                        // obj.hideFlags = HideFlags.HideAndDontSave;
                        obj.name = typeof(T).Name;
                    }
                }
                return mInstance;
            }
        }

        public virtual void Awake() {
            DontDestroyOnLoad(this.gameObject);
            if (mInstance == null) {
                mInstance = this as T;
            }
            else {
                GameObject.Destroy(this.gameObject);
            }
        }
    }

}