#region CreateInfo
// 
// 项目名称: AirCombatGame
// 程序集:Assembly-CSharp
// 文件名称:IDataMemory.cs
// 创建时间:2024年1月31日 22:17
#endregion

namespace Module.Interface
{
    public interface IDataMemory
    {
        T Get<T>(string key);
        void Set<T>(string key,T value);

        void Remove(string key);
        void RemoveAll();
    }
}