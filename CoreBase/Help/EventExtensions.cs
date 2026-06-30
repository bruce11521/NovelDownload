using System;
using System.Linq;
using System.Reflection;

namespace CoreBase.Help
{
    public static class EventExtensions
    {
        /// <summary>
        /// 是否有任意註冊事件存在
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsEventSubscriptions(this object o)
        {
            Type t= o.GetType();
            var events = t.GetEvents();
            if (events.Length == 0)
            {
                return false;
            }


            foreach (var item in events)
            {
                var eventDelegate = t.GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic);
                if (eventDelegate != null)
                {
                    var delegateState = eventDelegate.GetValue(o) as Delegate;
                    if (delegateState != null)
                    {
                        var delegateInvocationList = delegateState.GetInvocationList();
                        if (delegateInvocationList.Length != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 是否有在EVENT中找到 相同註冊名稱
        /// </summary>
        /// <param name="o"></param>
        /// <param name="EventName">註冊名稱</param>
        /// <returns></returns>
        public static bool GetEventSubscriptions(this object o, string EventName)
        {
            Type t = o.GetType();
            var events = t.GetEvents();
            if (events.Length == 0)
            {
                return false;
            }

            foreach (var item in events)
            {
                
                var eventDelegate = t.GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
                if (eventDelegate != null)
                {
                    var delegateState = eventDelegate.GetValue(o) as Delegate;
                    if (delegateState != null)
                    {
                        var delegateInvocationList = delegateState.GetInvocationList();
                        if (delegateInvocationList.Length != 0)
                        {
                            if (delegateInvocationList.Any(x => x.Method.Name == (EventName ?? string.Empty)))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
