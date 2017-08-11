using Xamarin.Forms;

namespace AppFidelidade_App_Client.Views
{
    public partial class CreditosPage : BasePage
    {
        public CreditosPage()
        {
            InitializeComponent();
            listView.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}
