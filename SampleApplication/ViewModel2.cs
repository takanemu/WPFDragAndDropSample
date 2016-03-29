
namespace SampleApplication.ViewModel
{
    using SampleApplication.Behaviors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public class ViewModel2 : Livet.ViewModel
    {
        public ViewModel2()
        {
            this.Description = new DropAcceptDescription();
            this.Description.DragOver += Description_DragOver;
            this.Description.DragDrop += Description_DragDrop;
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
            if (!args.Data.GetDataPresent(typeof(ViewModel1))) return;
            var data = args.Data.GetData(typeof(ViewModel1)) as ViewModel1;
            if (data == null) return;
            var fe = args.OriginalSource as FrameworkElement;
            if (fe == null) return;
            var target = fe.DataContext as ViewModel2;
            if (target == null) return;
        }

        private void Description_DragOver(System.Windows.DragEventArgs args)
        {
            if (args.AllowedEffects.HasFlag(DragDropEffects.Move) &&
                args.Data.GetDataPresent(typeof(String)))
            {
                args.Effects = DragDropEffects.Move;
            }
        }
    }
}
