using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Mo.TeamCityScreensaver.classes
{
    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        private bool mSuppressOnCollectionChanged;

        public void AddRange(IEnumerable<T> items)
        {
            if (null == items)
            {
                throw new ArgumentNullException("items");
            }
            if (!items.Any()) return;
            try
            {
                mSuppressOnCollectionChanged = true;
                foreach (T item in items)
                {
                    Add(item);
                }
            }
            finally
            {
                mSuppressOnCollectionChanged = false;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        public void BeginUpdate()
        {
            mSuppressOnCollectionChanged = true;
        }

        public void EndUpdate()
        {
            mSuppressOnCollectionChanged = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (mSuppressOnCollectionChanged) return;
            base.OnCollectionChanged(e);
        }
    }
}