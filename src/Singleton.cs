
namespace Game
{
    public class Singleton<T> where T : class, new()
    {
        private static T singleton;
        public static T Instance
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new T();
                }
                return singleton;
            }
        }
    }

}
