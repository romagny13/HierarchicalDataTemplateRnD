using System.Windows;
using System.Windows.Controls;

namespace HierarchicalDataTemplateRnD
{
    public class MyCustomControl : HeaderedItemsControl
    {
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(MyCustomControl), new PropertyMetadata(null));

        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyCustomControl();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is MyCustomControl;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
