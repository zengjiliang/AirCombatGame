#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:HeroItem.cs
// 创建时间:2024年1月31日 4:43
#endregion

using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace View.Login.Item
{
    public class HeroItem:MonoBehaviour
    {
        private Image mImg;
        private Color mDefultColor = Color.gray;
        private Color mCurrentSelectColor = Color.white;
        private float mTime = .5f;
        private Action mCallBack;
        private void Awake()
        {
            mImg = transform.GetComponent<Image>();
        }

        private void Start()
        {
            UnSelect();
            GetComponent<Button>().onClick.AddListener(Clicked);
        }

        private void Clicked()
        {
            if (mCallBack != null)
            {
                mCallBack.Invoke();
            }
            mImg.DOKill();
            mImg.DOColor(mCurrentSelectColor, mTime);
        }

        public void UnSelect()
        {
            mImg.DOKill();
            mImg.DOColor(mDefultColor, mTime);
        }

        public void AddCallBack(Action action)
        {
            mCallBack = action;
        }
    }
}