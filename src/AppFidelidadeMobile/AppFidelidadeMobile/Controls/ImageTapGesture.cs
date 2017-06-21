using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidadeMobile.Controls
{
    public class ImageTapGesture: Image
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand", typeof(ICommand), typeof(ImageTapGesture), null);

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public ImageTapGesture() : base()
        {
            _Inicialize();
        }

        private void _Inicialize()
        {
            var gestureRecognizer = new TapGestureRecognizer();

            gestureRecognizer.Tapped += (sender, e) =>
            {
                if (ItemTappedCommand == null || !IsEnabled)
                {
                    return;
                }
                Opacity = 0.6;
                if (ItemTappedCommand.CanExecute(e))
                    ItemTappedCommand.Execute(sender);

                this.FadeTo(1);
            };
            GestureRecognizers.Add(gestureRecognizer);
        }
    }
}
