using Game;

// Use Examples

Example example = new Example();
example.ExampleNoArg();
example.ExampleTwoArgs();
example.ExampleClassObjectArg();


internal class Example
{
    // use enum is a good habit
    private enum EventType
    {
        One = 0,
        Two,
        Three,
    }

    // Example 1：no arg fuction
    public void ExampleNoArg()
    {
        EventManager.Instance.RegisterEvent((int)EventType.One, Print1);
        EventManager.Instance.RegisterEvent((int)EventType.One, Print2);

        EventManager.Instance.PushEvent((int)EventType.One); // call Print1() and Print2()

        EventManager.Instance.UnregisterEvent((int)EventType.One, Print1);
        EventManager.Instance.UnregisterEvent((int)EventType.One, Print2);

        EventManager.Instance.PushEvent((int)EventType.One); // call nothing
    }

    private void Print1()
    {
        Console.WriteLine("Print1");
    }

    private void Print2()
    {
        Console.WriteLine("Print2");
    }

    // example 2: tow args function
    public void ExampleTwoArgs()
    {
        EventManager.Instance.RegisterEvent<int, string>((int)EventType.Two, Print3);
        EventManager.Instance.RegisterEvent<int, string>((int)EventType.Two, Print4);

        EventManager.Instance.PushEvent((int)EventType.Two, 999, "aaa"); // call Print3() and Print4()

        EventManager.Instance.UnregisterEvent<int, string>((int)EventType.Two, Print3);
        EventManager.Instance.UnregisterEvent<int, string>((int)EventType.Two, Print4);

        EventManager.Instance.PushEvent((int)EventType.Two); // call nothing
    }

    private void Print3(int x, string y)
    {
        Console.WriteLine($"Print3 {x} {y}");
    }

    private void Print4(int x, string y)
    {
        Console.WriteLine($"Print4 {x} {y}");
    }

    // example 3: a class instance arg
    public class EventData
    {
        public int id;
        public string name;

        public EventData(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    public void ExampleClassObjectArg()
    {
        EventManager.Instance.RegisterEvent<EventData>((int)EventType.Three, Print5);

        EventManager.Instance.PushEvent((int)EventType.Three, new EventData(999, "aaa")); // call Print5

        EventManager.Instance.UnregisterEvent<EventData>((int)EventType.Three, Print5);

        EventManager.Instance.PushEvent((int)EventType.Three, new EventData(999, "aaa")); // call nothing

    }

    private void Print5(EventData data)
    {
        Console.WriteLine($"Print5 {data.id} {data.name}");
    }

}





