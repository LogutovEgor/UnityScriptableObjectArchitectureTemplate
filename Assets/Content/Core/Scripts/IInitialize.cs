namespace Core
{
    public interface IInitialize<T1>
    {
        void Initialize(T1 param1);
    }
    public interface IInitialize<T1, T2>
    {
        void Initialize(T1 param1, T2 param2);
    }
}