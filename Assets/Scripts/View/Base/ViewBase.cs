#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ViewBase.cs
// 创建时间:2024年1月31日 2:44
#endregion

using Module.Interface;
using UnityEngine;
using UnityEngine.TestTools;
using Util;

namespace View.Base
{
    public abstract class ViewBase:MonoBehaviour, IView
    {
        private UIUtils mUtil = null;

        protected UIUtils Util
        {
            get
            {
                if (mUtil == null)
                {
                    mUtil = new UIUtils(this.GetComponent<RectTransform>(),this);
                }

                return mUtil;
            }
        } 
        public virtual void Show()
        {
            SetActive(true);
        }

        public virtual void Hide()
        { 
            SetActive(false);
        }

        public virtual void Init()
        { 
            
        }

        public void SetActive(bool value)
        {
            if (gameObject.activeSelf.Equals(value) == false)
            {
                gameObject.SetActive(value);
            }
        }
    }
}