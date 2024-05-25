# Event Manager

## 描述

一个事件模块，用于在各模块间注册监听事件，使用泛型避免不必要的装箱和拆箱，无需其它依赖，任意c#项目即可。

## 用法

使用**RegisterEvent**和 **UnregisterEvent** 接口来监听和取消监听事件，使用 **PushEvent** 通知所有注册的事件运行。

如果方法没有参数

```c#
public void Example1()
{
    EventManager.Instance.RegisterEvent(0, FunctionNoArgs); // subscribe 
    EventManager.Instance.PushEvent(0); // notify 
    EventManager.Instance.UnregisterEvent(0, FunctionNoArgs); // unsubscribe if necessary
}
public void FunctionNoArgs()
{
    Console.WriteLine("This is no args function");
}
```

如果方法有多个参数

```c#
public void Example2()
{
    EventManager.Instance.RegisterEvent<int, string, float, bool>(1, FunctionFourArgs); // subscribe 
    EventManager.Instance.PushEvent(1, 9, "aaa", 7.1f, false); // notify 
    EventManager.Instance.UnregisterEvent<int, string, float, bool>(1, FunctionFourArgs); // unsubscribe if necessary
}
public void FunctionFourArgs(int x, string y, float z, bool w)
{
    Console.WriteLine($"This is four args function {x} {y} {z} {w}");
}
```

如果方法超过4个参数，可以用类对象传递参数（不推荐）

```c#
public class EventDataA
{
    public int id;
    public string name;
    public EventDataA(int id, string name) 
    {
        this.id = id;
        this.name = name;
    }
}
public class EventDataB
{
    public int id;
    public float x;
    public float y;
    public float z;
    public float w;
    public EventDataB(int id, float x, float y, float z, float w)
    {
        this.id = id;
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }
}
public void Example3()
{
    EventManager.Instance.RegisterEvent<EventDataA, EventDataB>(2, FunctionTowClassInstance); // subscribe
    EventManager.Instance.PushEvent(2, new EventDataA(99, "aaa"), new EventDataB(100, 101, 102, 103, 104)); // notify 
    EventManager.Instance.UnregisterEvent<EventDataA, EventDataB>(2, FunctionTowClassInstance); // unsubscribe if necessary
}
public void FunctionTowClassInstance(EventDataA dataA, EventDataB dataB)
{
    Console.WriteLine($"class instance args {dataA.id} {dataB.id}");
}
```

  更详细示例见Example.cs
