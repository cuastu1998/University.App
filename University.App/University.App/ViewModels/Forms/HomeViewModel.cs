using University.App.Views.Menu;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class HomeViewModel : BaseViewModel
    {

        #region Commands
        public Command MenuCommand { get; set; }
        #endregion

        #region Methods
        async void Menu()
        {
            Application.Current.MainPage = new MenuPage();
        }
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            this.MenuCommand = new Command(Menu);
        }
        #endregion

    }
}