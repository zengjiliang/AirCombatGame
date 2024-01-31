#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:UIData.cs
// 创建时间:2024年1月31日 2:54
#endregion

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace View.Data
{
    public class UIData
    {
        public GameObject GameObject { get; private set; }
        public RectTransform RectTrans { get; private set; }
        public Button Btn { get; private set; }
        public Image Img { get; private set; }
        public Text Txt { get; private set; }

        public UIData(RectTransform rect)
        {
            RectTrans = rect;

            GameObject = RectTrans.gameObject;
            Btn = RectTrans.GetComponent<Button>();
            Img = RectTrans.GetComponent<Image>();
            Txt = RectTrans.GetComponent<Text>();
        }

        public void AddListener(Action action)
        {
            if (Btn != null)
            {
                Btn.onClick.AddListener(()=>action());
            }
            else
            {
                Debug.LogError($"当前物体{GameObject.name}没有button组件");
            }
        }

        public void SetSprite(Sprite sp)
        {
            if (Img != null)
            {
                Img.sprite = sp;
            }
            else
            {
                Debug.LogError($"当前物体{GameObject.name}没有Image组件");
            }
        }
    }
}