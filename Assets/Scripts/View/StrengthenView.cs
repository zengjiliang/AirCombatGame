#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:StrengthenView.cs
// 创建时间:2024年2月14日 22:19
#endregion

using Attribute;
using Const;
using View.Auto;
using View.Base;

namespace View
{
    [BindPrefab(GamePaths.STRENGTHEN_VIEW)]
    public class StrengthenView:ViewBase
    {
        protected override void InitChild()
        {
            Util.GetData("SwitchPlayer").GameObject.AddComponent<SwitchPlayer>();
        }

    }
}