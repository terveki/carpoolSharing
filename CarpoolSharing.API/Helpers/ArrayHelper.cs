namespace CarpoolSharing.API.Helpers
{
    public class ArrayHelper
    {
        public ArrayHelper()
        {
            
        }
        public T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
    }
}