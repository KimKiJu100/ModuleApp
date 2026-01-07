using System.ComponentModel;

namespace App.MVP.Presenter
{
    public class CustomPropertyChangedEventArgs<T> : PropertyChangedEventArgs
    {
        public T Value { get; }
        public CustomPropertyChangedEventArgs(string propertyName, T propertyValue) : base(propertyName)
        {
            Value = propertyValue;
        }
    }
}
