
namespace SampleApplication.ViewModel
{
    using SampleApplication.Behaviors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public class ListControlViewModel : Livet.ViewModel
    {
        private System.Collections.Generic.IEnumerable<ListItemViewModel> _itemsSource;
        public System.Collections.Generic.IEnumerable<ListItemViewModel> ItemsSource
        {
            get { return this._itemsSource; }
            set
            {
                if (this._itemsSource == value)
                {
                    return;
                }
                this._itemsSource = value;

                this.RaisePropertyChanged(() => this.ItemsSource);
            }
        }

        private DropAcceptDescription _description;
        public DropAcceptDescription Description
        {
            get { return this._description; }
            set
            {
                if (this._description == value)
                {
                    return;
                }
                this._description = value;

                this.RaisePropertyChanged(() => this.Description);
            }
        }

        private void Description_DragDrop(System.Windows.DragEventArgs args)
        {
            if (args.Data.GetDataPresent(typeof(ListItemViewModel)))
            {
                var data = args.Data.GetData(typeof(ListItemViewModel)) as ListItemViewModel;
                var fe = args.OriginalSource as FrameworkElement;

                if (fe != null)
                {
                    if (fe.DataContext is ListControlViewModel)
                    {
                        // リスト本体へドロップ
                    }
                    else if (fe.DataContext is ListItemViewModel)
                    {
                        // リスト項目へドロップ
                    }
                }
            }
        }

        private void Description_DragOver(System.Windows.DragEventArgs args)
        {
            if (args.AllowedEffects.HasFlag(DragDropEffects.Copy))
            {
                if (args.Data.GetDataPresent(typeof(ListItemViewModel)))
                {
                    return;
                }
            }
            args.Effects = DragDropEffects.None;
        }

        public ListControlViewModel()
        {
            this.Description = new DropAcceptDescription();
            this.Description.DragOver += Description_DragOver;
            this.Description.DragDrop += Description_DragDrop;

            var list = new List<ListItemViewModel>();

            list.Add(new ListItemViewModel
            {
            });
            list.Add(new ListItemViewModel
            {
            });
            list.Add(new ListItemViewModel
            {
            });
            this.ItemsSource = list;
        }
    }
}
