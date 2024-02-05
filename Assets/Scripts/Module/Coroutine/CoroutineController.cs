#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:CoroutineController.cs
// 创建时间:2024年2月1日 2:36
#endregion

using System.Collections;
using UnityEngine;

namespace Module.Coroutine
{
    public class CoroutineController
    {
        private CoroutineItem mItem;
        private MonoBehaviour mMono;
        private IEnumerator mEnumerator;
        private static int mId;
        private UnityEngine.Coroutine mCoroutine;
        public int Id { get; private set; }

        public CoroutineController(MonoBehaviour monoBehaviour,IEnumerator enumerator)
        {
            mItem = new CoroutineItem();
            mMono = monoBehaviour;
            mEnumerator = enumerator;
            ResetData();
        }
        public void Start()
        {
            mItem.State = CoroutineItem.CoroutineState.RUNNING;
            mCoroutine = mMono.StartCoroutine(mItem.Body(mEnumerator));
        }

        public void Pause()
        {
            mItem.State = CoroutineItem.CoroutineState.PAUSED;
        }

        public void Stop()
        {
            mItem.State = CoroutineItem.CoroutineState.STOP;
        }

        public void Continue()
        {
            mItem.State = CoroutineItem.CoroutineState.RUNNING;
        }

        public void ResetStart()
        {
            if (mCoroutine != null)
            {
                mMono.StopCoroutine(mCoroutine);
            }
            Start();
        }

        private void ResetData()
        {
            Id = mId++;
        }
    }
}