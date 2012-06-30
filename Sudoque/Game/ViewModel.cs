using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Sudoque.Game
{
    public class ViewModel : INotifyPropertyChanged
    {
        public void NotifyPropertyChanged<TValue>(params Expression<Func<TValue>>[] propertySelector)
        {
            Array.ForEach(propertySelector, NotifySinglePropertyChanged);
        }

        private void NotifySinglePropertyChanged<TValue>(Expression<Func<TValue>> propertySelector)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate {};
    }
}