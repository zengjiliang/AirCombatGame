#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ResourcesLoader.cs
// 创建时间:2024年1月31日 0:13
#endregion

using System;
using System.Collections;
using Manager;
using Module.Interface;
using UnityEngine;
using UnityEngine.Networking;
using Util;
using Object = UnityEngine.Object;

namespace Module.Loader
{
    public class ResourcesLoader:ILoader
    {
        public GameObject LoadPrefab(string path, Transform parent = null)
        {
            GameObject prefab = Load<GameObject>(path);
            GameObject obj = GameObject.Instantiate(prefab, parent);
            obj.name = prefab.name;
   
            //obj.AddComponent(Type.GetType(GameUtils.Path2Namespace(path)));
            return obj;
        }

        public Sprite LoadSprite(string path)
        {
            Sprite sprite = Load<Sprite>(path);
            if (sprite == null)
            {
                Debug.LogError($"未找到对应图片,路径:{path}");
                return null;
            }
            
            return sprite;
        }

        public Sprite[] LoadSprites(string path)
        {
            Sprite[] sprites = LoadAll<Sprite>(path);
            if (sprites == null || sprites.Length.Equals(0) == true)
            {
                Debug.LogError($"未找到对应图片,路径:{path}");
                return null;
            }
            
            return sprites;
        }

   
        public T Load<T>(string path)where T : Object
        {
            return Resources.Load<T>(path);
        }
        public T[] LoadAll<T>(string path)where T : Object
        {
            return Resources.LoadAll<T>(path);
        }
        public void LoadConfig(string path, Action<object> complete)
        {
            CoroutineManager.Instance.DoExecute(Config(path, complete));
        }

        private IEnumerator Config(string path, Action<object> complete)
        {
            UnityWebRequest unityWebRequest = new UnityWebRequest(new Uri(path));
            unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
            yield return unityWebRequest.SendWebRequest();
            if (unityWebRequest.isDone)
            {
                if (unityWebRequest.result == UnityWebRequest.Result.Success)
                {
                    complete.Invoke(unityWebRequest.downloadHandler.text);
                }
                else
                {
                    Debug.LogError(unityWebRequest.error);
                }
            }
            yield return null;
        }
    }
}