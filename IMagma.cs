namespace FlavorsOfMagma
{
    interface IMagma<T>
    {
        T Invoke(T a, T b);
    }
}