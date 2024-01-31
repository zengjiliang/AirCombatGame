#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:StartView.cs
// 创建时间:2024年1月31日 0:27
#endregion

using Attribute;
using Const;
using Manager;
using UnityEngine;
using View.Base;

namespace View.Login
{
    [BindPrefab(GamePaths.START_VIEW)]
    public class StartView:ViewBase
    {
        public override void Init()
        {
            base.Init();
            Util.GetData("StartBtn").AddListener(() =>
            {
                Debug.Log("click");
                UIManager.Instance.Show(GamePaths.SELECT_HERO_VIEW);
            });
        }
    }
}