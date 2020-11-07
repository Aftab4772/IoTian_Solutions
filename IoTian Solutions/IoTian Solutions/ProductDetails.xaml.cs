using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IoTian_Solutions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetails : ContentPage
	{
		public ProductDetails(string medName, string fileAssociated, string price)
		{
			InitializeComponent ();
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data", fileAssociated + ".xml");
            if (!System.IO.File.Exists(backingFile))
                return;
            List<System.Xml.Linq.XElement> xEleList = System.Xml.Linq.XElement.Load(backingFile).Descendants("Product").ToList();
            if (xEleList.Count == 0)
                return;
            lblMedName.Text = medName;
            imgMed.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile(fileAssociated + ".jpg")
                : ImageSource.FromFile("Images/" + fileAssociated + ".jpg");
            lblMedDetails.Text = xEleList[0].Element("Details").Value;
            lblMedInfoHead.Text = xEleList[0].Element("InfoHeader").Value;
            lblMedInfo.Text = xEleList[0].Element("Info").Value;
            txtPurchase.Text = "Buy for " + price;
        }

        private async void txtPurchase_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirm", "Would you buy " + lblMedName.Text + txtPurchase.Text, "Yes", "No");
            if(answer)
                await DisplayAlert("Order Placed Successfully", "Thank you for the puchase.", "OK");
        }
    }
}