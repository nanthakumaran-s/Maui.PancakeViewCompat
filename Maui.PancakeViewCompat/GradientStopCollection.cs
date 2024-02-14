using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace PancakeView
{
    public class GradientStopCollection : ObservableCollection<GradientStop>
    {
        protected override void InsertItem(int index, GradientStop item) => base.InsertItem(index, item ?? throw new ArgumentNullException(nameof(item)));
        protected override void SetItem(int index, GradientStop item) => base.SetItem(index, item ?? throw new ArgumentNullException(nameof(item)));

        protected override void ClearItems()
        {
            foreach (var item in this)
                if (item is INotifyPropertyChanged i)
                    i.PropertyChanged -= CollectionItem_PropertyChanged;

            var removed = new List<GradientStop>(this);
            base.ClearItems();
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= CollectionItem_PropertyChanged;

            if (e.NewItems != null)
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += CollectionItem_PropertyChanged;

            base.OnCollectionChanged(e);
        }

        void CollectionItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, null));
        }
    }
}