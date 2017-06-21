using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidadeMobile.Controls
{
    public class GridTapGesture: Grid
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand", typeof(ICommand), typeof(GridTapGesture), null);

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public GridTapGesture() : base()
        {
            _Inicialize();
        }

        private void _Inicialize()
        {
            var gestureRecognizer = new TapGestureRecognizer();

            gestureRecognizer.Tapped += (sender, e) =>
            {
                if (ItemTappedCommand == null)
                {
                    return;
                }
                if (ItemTappedCommand.CanExecute(e))
                    ItemTappedCommand.Execute(sender);
            };
            this.GestureRecognizers.Add(gestureRecognizer);
        }
    }
}
