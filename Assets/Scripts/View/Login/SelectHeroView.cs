#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:SelectHeroView.cs
// 创建时间:2024年1月31日 4:32
#endregion

using Attribute;
using Const;
using Manager;
using UnityEngine;
using View.Base;

namespace View.Login
{
    [BindPrefab(GamePaths.SELECT_HERO_VIEW)]
    public class SelectHeroView:ViewBase
    {
        protected override void InitChild()
        {
            Util.GetData("Heros").GameObject.AddComponent<SelectHero>();
            Util.GetData("StartGame").AddListener(() =>
            {
                //TODO:StartGame
                Debug.Log("StartGame");
            });
            Util.GetData("Exit").AddListener(() =>
            {
                //TODO:ExitGame
                Debug.Log("Exit");
            });
            Util.GetData("Strengthen").AddListener(() =>
            {
                //TODO:Strengthen
                Debug.Log("Strengthen");
                UIManager.Instance.Show(GamePaths.STRENGTHEN_VIEW);
            });
        }

   
    }
}