#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:SwitchPlayer.cs
// 创建时间:2024年2月14日 22:26
#endregion

using System;
using System.Collections.Generic;
using Const;
using Manager;
using UnityEngine;
using Util;
using View.Base;

namespace View.Auto
{
    public class SwitchPlayer:ViewBase
    {
        private int mId;
        private readonly  Dictionary<int, List<Sprite>> mPlaneSprites = new Dictionary<int, List<Sprite>>();
        protected override void InitChild()
        {
            Util.GetData("Left").AddListener(()=>Switch(ref mId,-1));
            Util.GetData("Right").AddListener(()=>Switch(ref mId,1));
            LoadSprites(GamePaths.PLAYER_PICTURE_FOLDER);
        }

        private void Switch(ref int id,int value)
        {
            UpdateId(ref id,value);
            UpdateSprite(id);
        }

        public override void Show()
        {
            base.Show();
            mId = DataManager.Instance.Get<int>(DataKeys.PLANE_ID);
            UpdateSprite(mId);
        }

        private void LoadSprites(string path)
        {
            Sprite[] sps = LoadManager.Instance.LoadSprites(path);
            if (sps == null)
            {
                Debug.LogError("");
            }

            foreach (var sprite in sps )
            {
                string[] strs = GameUtils.Instance.Split(sprite.name, '_');
                if(GameUtils.Instance.String2Int(strs[0],out int planeId))
                {
                    if (mPlaneSprites.TryGetValue(planeId, out var sprites))
                    {
                        sprites.Add(sprite);
                    }
                    else
                    {
                        mPlaneSprites[planeId] = new List<Sprite>(){sprite};
                    }
                }
            }
        }
        private void UpdateId(ref int id,int value)
        {
            int min = 0;
            int max = mPlaneSprites.Count;
            id += value;
            id = id < 0 ? 0 : id >= max ? id = max - 1 : id;
        }

        private void UpdateSprite(int id)
        {
            int level = DataManager.Instance.Get<int>(DataKeys.LEVEL);
            Debug.Log(level);
            Util.GetData("Icon").SetSprite(mPlaneSprites[id][level]);
        }
    }
}