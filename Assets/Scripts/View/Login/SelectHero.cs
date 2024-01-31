#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:SelectHero.cs
// 创建时间:2024年1月31日 4:44
#endregion

using System;
using UnityEngine;
using View.Login.Item;

namespace View.Login
{
    public class SelectHero:MonoBehaviour
    {
        private HeroItem[] mItems;

        private void Awake()
        {
            mItems = new HeroItem[transform.childCount];
            int index = 0;
            foreach (Transform child in transform)
            {
                var item = child.gameObject.AddComponent<HeroItem>();
                mItems[index++] = item;
                item.AddCallBack(ResetBtn);
                Debug.Log(child.name);
            }
        }

        private void ResetBtn()
        {
            foreach (var item in mItems)
            {
               item.UnSelect();
            }
        }
    }
}