#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:GamePaths.cs
// 创建时间:2024年1月31日 3:52
#endregion

using UnityEngine;

namespace Const
{
    public class GamePaths
    {
        public const string START_VIEW = "View/Login/StartView";
        public const string SELECT_HERO_VIEW = "View/Login/SelectHeroView";
        public const string STRENGTHEN_VIEW = "View/StrengthenView";
        
        public const string PLAYER_PICTURE_FOLDER = "Picture/Player";

        private static readonly string CONFIG_FOLDER = $"{Application.streamingAssetsPath}/Config";
        public static readonly string INIT_PLANE_CONFIG = $"{CONFIG_FOLDER}/InitPlane.json";
    }
}