using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidadeMobile.Controls
{
    public class LabelTapGesture: Label
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand", typeof(ICommand), typeof(LabelTapGesture), null);

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public LabelTapGesture() : base()
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
