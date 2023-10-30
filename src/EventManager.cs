using System;
using System.Collections.Generic;

namespace Game
{
    public class EventManager : Singleton<EventManager>
    {
        private readonly Dictionary<int, Delegate> m_eventDict;

        public EventManager()
        {
            m_eventDict = new Dictionary<int, Delegate>();
        }

        private void AddEvent(int eventType, Delegate action)
        {
            if (action == null)
            {
                return;
            }

            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                m_eventDict[eventType] = Delegate.Combine(deg, action);
            }
            else
            {
                m_eventDict[eventType] = action;
            }
        }

        private void RemoveEvent(int eventType, Delegate action)
        {
            if (action == null)
            {
                return;
            }
            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                deg = Delegate.Remove(deg, action);
                if (deg == null)
                {
                    m_eventDict.Remove(eventType);
                }
                else
                {
                    m_eventDict[eventType] = deg;
                }
            }
        }

        #region No Args
        public void RegisterEvent(int eventType, Action action)
        {
            AddEvent(eventType, action);
        }

        public void UnregisterEvent(int eventType, Action action)
        {
            RemoveEvent(eventType, action);
        }

        public void PushEvent(int eventType)
        {
            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                foreach (Delegate func in deg.GetInvocationList())
                {
                    Action action = (Action)func;
                    action.Invoke();
                }
            }
        }
        #endregion
        #region 1 Arg
        public void RegisterEvent<T>(int eventType, Action<T> action)
        {
            AddEvent(eventType, action);
        }

        public void UnregisterEvent<T>(int eventType, Action<T> action)
        {
            RemoveEvent(eventType, action);
        }

        public void PushEvent<T>(int eventType, T arg1)
        {
            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                foreach (Delegate func in deg.GetInvocationList())
                {
                    Action<T> action = (Action<T>)func;
                    action.Invoke(arg1);
                }
            }
        }
        #endregion
        #region 2 Args
        public void RegisterEvent<T1, T2>(int eventType, Action<T1, T2> action)
        {
            AddEvent(eventType, action);
        }

        public void UnregisterEvent<T1, T2>(int eventType, Action<T1, T2> action)
        {
            RemoveEvent(eventType, action);
        }

        public void PushEvent<T1, T2>(int eventType, T1 arg1, T2 arg2)
        {
            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                foreach (Delegate func in deg.GetInvocationList())
                {
                    Action<T1, T2> action = (Action<T1, T2>)func;
                    action.Invoke(arg1, arg2);
                }
            }
        }
        #endregion
        #region 3 Args
        public void RegisterEvent<T1, T2, T3>(int eventType, Action<T1, T2, T3> action)
        {
            AddEvent(eventType, action);
        }

        public void UnregisterEvent<T1, T2, T3>(int eventType, Action<T1, T2, T3> action)
        {
            RemoveEvent(eventType, action);
        }

        public void PushEvent<T1, T2, T3>(int eventType, T1 arg1, T2 arg2, T3 arg3)
        {
            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                foreach (Delegate func in deg.GetInvocationList())
                {
                    Action<T1, T2, T3> action = (Action<T1, T2, T3>)func;
                    action.Invoke(arg1, arg2, arg3);
                }
            }
        }
        #endregion
        #region 4 Args
        public void RegisterEvent<T1, T2, T3, T4>(int eventType, Action<T1, T2, T3, T4> action)
        {
            AddEvent(eventType, action);
        }

        public void UnregisterEvent<T1, T2, T3, T4>(int eventType, Action<T1, T2, T3, T4> action)
        {
            RemoveEvent(eventType, action);
        }

        public void PushEvent<T1, T2, T3, T4>(int eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (m_eventDict.TryGetValue(eventType, out var deg))
            {
                foreach (Delegate func in deg.GetInvocationList())
                {
                    Action<T1, T2, T3, T4> action = (Action<T1, T2, T3, T4>)func;
                    action.Invoke(arg1, arg2, arg3, arg4);
                }
            }
        }
        #endregion

    }
}
