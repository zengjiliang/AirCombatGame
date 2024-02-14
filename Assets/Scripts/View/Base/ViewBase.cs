#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:ViewBase.cs
// 创建时间:2024年1月31日 2:44
#endregion

using System.Collections.Generic;
using Module.Interface;
using UnityEngine;
using UnityEngine.TestTools;
using Util;

namespace View.Base
{
    public abstract class ViewBase:MonoBehaviour, IView
    {
        private UIUtils mUtil = null;
        private readonly HashSet<ViewBase> mSubViewBaseSet = new HashSet<ViewBase>();
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

        protected abstract void InitChild();
        private void InitSubViews()
        {
            ViewBase vb = null;
            foreach (Transform trans in transform)
            {
                vb = trans.GetComponent<ViewBase>();
                if (vb != null)
                {
                    mSubViewBaseSet.Add(vb);
                }
            }
        }
        public virtual void Show()
        {
            SetActive(true);
            foreach (var viewBase in mSubViewBaseSet)
            {
                viewBase.Show();
            }
        }

        public virtual void Hide()
        { 
            foreach (var viewBase in mSubViewBaseSet)
            {
                viewBase.Hide();
            }
            SetActive(false);
        }

        public virtual void Init()
        { 
            InitChild();
            InitSubViews();
            foreach (var viewBase in mSubViewBaseSet)
            {
                viewBase.Init();
            }
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