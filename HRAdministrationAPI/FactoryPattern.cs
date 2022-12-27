namespace HRAdministrationAPI
{
    public static class FactoryPattern<K, T> where T : class, K, new()
    {
        public static K GetInstance()
        {
            return new T();
        }
    }
}
