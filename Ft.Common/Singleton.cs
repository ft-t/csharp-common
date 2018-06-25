using System;
using System.Reflection;

namespace Ft.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => typeof(T).InvokeMember(typeof(T).Name,
            BindingFlags.CreateInstance |
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic,
            null, null, null) as T);

        /// <summary>
        /// Gets the instance of the singleton
        /// </summary>
        public static T Instance => _instance.Value;

        /// <summary>
        /// 
        /// </summary>
        protected Singleton()
        {
        }
    }
}