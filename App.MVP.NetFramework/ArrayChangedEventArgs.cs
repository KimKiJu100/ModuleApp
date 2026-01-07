using System.ComponentModel;

namespace BSRandWindNoise.AppCore
{
    public class ArrayChangedEventArgs<T> : PropertyChangedEventArgs
    {
        public int Index { get; }
        public T Value { get; }

        public ArrayChangedEventArgs(int index, string propertyName, T propertyValue) : base(propertyName)
        {
            Index = index;
            Value = propertyValue;
        }
    }
}
