namespace FlavorsOfMagma.Interfaces
{
    interface IMagma<T>
    {
        T Invoke(T a, T b);
    }
}