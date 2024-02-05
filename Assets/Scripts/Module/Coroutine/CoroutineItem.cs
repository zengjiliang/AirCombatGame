#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:CoroutineItem.cs
// 创建时间:2024年2月1日 2:36
#endregion

using System.Collections;
using Unity.IO.LowLevel.Unsafe;

namespace Module.Coroutine
{
    public class CoroutineItem
    {
        public enum CoroutineState
        {
            WAITTING,RUNNING,PAUSED,STOP
        }
        public CoroutineState State { get; set; }

        public IEnumerator Body(IEnumerator enumerator)
        {
            while (State == CoroutineState.WAITTING)
            {
                yield return null;
            }

            while (State == CoroutineState.RUNNING)
            {
                if (State == CoroutineState.PAUSED)
                {
                    yield return null;
                }
                else
                {
                    if (enumerator != null && enumerator.MoveNext())
                    {
                        yield return enumerator.Current;
                    }
                    else
                    {
                        State = CoroutineState.STOP;
                    }
                }
            }
        }
    }
}