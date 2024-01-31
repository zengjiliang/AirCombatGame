#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:UIManager.cs
// 创建时间:2024年1月31日 2:39
#endregion

using System.Collections.Generic;
using Module.Interface;
using UnityEngine;
using Util;

namespace Manager
{
    public class UIManager:Singleton<UIManager>
    {
        private Canvas mCanvas;
        private Stack<string> mUIStack = new Stack<string>();
        private readonly Dictionary<string, IView> mViews = new Dictionary<string, IView>();

        public Canvas Canvas
        {
            get
            {
                if (mCanvas == null)
                {
                    mCanvas = GameObject.FindObjectOfType<Canvas>();
                    if (mCanvas == null)
                    {
                        Debug.LogError("canvas is not found");
                    }
                }

                return mCanvas;
            }
        }

        public IView Show(string path)
        {
            if (mUIStack.Count > 0)
            {
                string name = mUIStack.Peek();
                mViews[name].Hide();
            }

            IView view = InitView(path);
            view.Show();
            mViews[path] = view;
            mUIStack.Push(path);
            return view;
        }

        private IView InitView(string path)
        {
            IView iv = null;
            if (mViews.TryGetValue(path, out iv))
            {
                return iv;
            }
            else
            {
                GameObject viewObject = LoadManager.Instance.LoadPrefab(path,Canvas.transform);
                if (PrefabBindUtil.TryGetType(path, out var type))
                {
                    var component = viewObject.AddComponent(type);
                    if (component is IView view)
                    {
                        view.Init();
                        mViews.Add(path,view);
                        return view;
                    }
                    else
                    {
                        Debug.LogError("当前添加脚本未继承viewBase");
                    }
                 
                 
                 
                }
                return iv;
            }

        }
        public void Back()
        {
            if (mUIStack.Count <= 1)
            {
                return;
            }

            string name = mUIStack.Pop();
            mViews[name].Hide();
            name = mUIStack.Peek();
            mViews[name].Show();
        }
    }
}