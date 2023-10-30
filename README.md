# Event Manger

## Description

- Easy to use. Simple interfaces and easy core code.（简单易用，接口和源码简单）

- Efficient. Use Generics to avoid unnecessary boxing and unboxing.（高效，使用泛型避免不必要的装箱和拆箱）
- Global singleton. The manager is achieve by  global singleton to decoupl different modules.（以全局单例实现，使各模块间解耦）

- Non-thread-safe.  Run in single thread. I use it in Unity.（适用于单线程）
- No dependencies. Usage in any c# project.（无需其它依赖，任意c#项目即可）

## Installation

Copy ’EventManager.cs‘ and 'Singleton.cs'  to your project, or just copy the code.

（复制EventManager.cs和Singleton.cs到你的项目中，或者仅复制代码）

## Usage

Use **RegisterEvent** and **UnregisterEvent** interface to subscribe and unsubscribe event, use **PushEvent** to notify observer run.

（使用**RegisterEvent**和 **UnregisterEvent** 接口来订阅和取消订阅事件，使用 **PushEvent** 通知观察者运行）

if observer's function is none arguments: 

（如果观察者的方法没有参数）

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

if observer's function is four arguments:

（如果观察者的方法有4个参数）

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

if observer's function is more than four arguments, can use instance of class:

（如果观察者的方法超过4个参数，以类的实例作为参数）

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

More examples in 'Example.cs'.

（更详细示例见Example.cs）

**Note**: Not recommended using temp instance of class as arguments, using data on the heap or basic data type is more efficient. 

（注意：使用堆内数据或者基础数据类型，相比与重复创建类对象更为高效）