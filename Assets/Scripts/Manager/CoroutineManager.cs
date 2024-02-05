#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:CoroutineManager.cs
// 创建时间:2024年2月1日 2:30
#endregion

using System.Collections;
using System.Collections.Generic;
using Module.Coroutine;
using UnityEngine;
using Util;

namespace Manager
{
    
    public class CoroutineManager:UnitySingleton<CoroutineManager>
    {
        private readonly Dictionary<int, CoroutineController>
            mCoroutineDic = new Dictionary<int, CoroutineController>();
        public override void Awake()
        {
            base.Awake();
            
        }
        
        public int AddCoroutineController(IEnumerator enumerator,bool autoStart = true)
        {
            CoroutineController coroutineController = new CoroutineController(this,enumerator);
            mCoroutineDic.Add(coroutineController.Id,coroutineController);

            if (autoStart == true)
            {
                Execute(coroutineController.Id);
            }
            return coroutineController.Id;
        }
        /// <summary>
        /// 执行一次
        /// </summary>
        /// <param name="enumerator"></param>
        public void DoExecute(IEnumerator enumerator)
        {
            CoroutineController coroutineController = new CoroutineController(this,enumerator);
            coroutineController.Start();
        }

        public void Execute(int id)
        {
            if (TryGetContorller(id, out var controller))
            {
                controller.Start();
            }
        
        }

        public void Stop(int id)
        {
            if (TryGetContorller(id, out var controller))
            {
                controller.Stop();
            }
          
        }
        public void Pause(int id)
        {
            if (TryGetContorller(id, out var controller))
            {
                controller.Pause();
            }
          
        }
        public void Continue(int id)
        {
            if (TryGetContorller(id, out var controller) )
            {
                controller.Continue();
            }
         
        }
        private bool  TryGetContorller(int id,out CoroutineController controller)
        {
            if (mCoroutineDic.TryGetValue(id, out controller))
            {
                return true;
            }
            Debug.LogError($"当前id = {id}不存在");
            return false;
        }
    }
}