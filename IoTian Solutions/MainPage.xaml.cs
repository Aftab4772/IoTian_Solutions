using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IoTian_Solutions
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            appLogo.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("MainIcon230.png")
                : ImageSource.FromFile("Images/MainIcon230.png");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainSearchWindow());
        }


    }
}
