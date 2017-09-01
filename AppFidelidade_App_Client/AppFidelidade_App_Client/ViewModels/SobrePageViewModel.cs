using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.ViewModels
{
    public class SobrePageViewModel : BaseViewModel
    {
        public ICommand ClickLogoCommand { get;}

        private bool _easterEggsVisibility;

        public bool EasterEggsVisibility
        {
            get { return _easterEggsVisibility; }
            set { SetProperty(ref _easterEggsVisibility, value); }
        }

        private int _countClickImage;
        public SobrePageViewModel()
        {
            ClickLogoCommand = new Command(ClickLogo);
            _countClickImage = 0;
            EasterEggsVisibility = false;
        }

        private async void ClickLogo(object obj)
        {
            _countClickImage++;
            var img = (Image)obj;
            await img.ScaleTo(0.98, 50, Easing.CubicOut);
            await img.ScaleTo(1, 50, Easing.CubicIn);
            if (_countClickImage >= 10)
            {
                var finish = await img.FadeTo(0, 500);
                if (finish == true)
                    EasterEggsVisibility = true;
            }
        }
    }
}
