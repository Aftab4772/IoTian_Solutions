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
	public partial class MainSearchWindow : ContentPage
	{

        public MainSearchWindow ()
		{
			InitializeComponent ();
            LoadData();
        }

        private void LoadData()
        {
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data", "productList.xml");
            System.Xml.Linq.XElement xEle = System.Xml.Linq.XElement.Load(backingFile);
            var dataFetch = xEle.Descendants("Product").OrderBy(x => Convert.ToString(x.Element("Name").Value)).Select(x => new
            {
                Name = Convert.ToString(x.Element("Name").Value),
                AssociatedFile = Convert.ToString(x.Element("AssociatedFile").Value),
                Price = Convert.ToString(x.Element("Price").Value)
            }).ToList();
            scrlGrid.RowDefinitions.Clear();
            scrlGrid.Children.Clear();
            int i = 0;
            dataFetch.ForEach(row =>
            {
                scrlGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                Grid grd = new Grid();

                grd.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                grd.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = 5
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Auto
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Star
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = 5
                });

                Label lblName = new Label();

                lblName.Text = row.Name;
                lblName.FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
                lblName.HorizontalOptions = LayoutOptions.End;
                lblName.VerticalOptions = LayoutOptions.Start;

                grd.Children.Add(lblName);
                Grid.SetRow(lblName, 0);
                Grid.SetColumn(lblName, 2);

                Label lblPrice = new Label();

                lblPrice.Text = row.Price;
                lblPrice.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                lblPrice.HorizontalOptions = LayoutOptions.End;
                lblPrice.VerticalOptions = LayoutOptions.End;

                grd.Children.Add(lblPrice);
                Grid.SetRow(lblPrice, 1);
                Grid.SetColumn(lblPrice, 2);

                Image img = new Image();
                img.Source = ImageSource.FromFile(row.AssociatedFile + ".jpg");
                img.WidthRequest = 80;
                img.HeightRequest = 80;
                img.VerticalOptions = LayoutOptions.Center;
                img.HorizontalOptions = LayoutOptions.Center;

                grd.Children.Add(img);
                Grid.SetRow(img, 0);
                Grid.SetColumn(img, 1);
                Grid.SetRowSpan(img, 2);

                var productTap = new TapGestureRecognizer();
                productTap.Tapped += async (s, e) =>
                {
                    var scaleUpAnimTask = grd.ScaleTo(0.9, 200);

                    var fadeOutAnimTask = grd.FadeTo(0.5, 200);

                    await Task.WhenAll(scaleUpAnimTask, fadeOutAnimTask);

                    var scaleDownAnimTask = grd.ScaleTo(1, 200);

                    var fadeInAnimTask = grd.FadeTo(1, 200);

                    await Task.WhenAll(scaleDownAnimTask, fadeInAnimTask);

                    await Navigation.PushAsync(new ProductDetails(row.Name, row.AssociatedFile, row.Price));
                };
                grd.GestureRecognizers.Add(productTap);

                scrlGrid.Children.Add(grd);
                Grid.SetRow(grd, i);

                i++;
            });
        }
        private void Enter_Medicine_TextChanged(object sender, TextChangedEventArgs e)
        {
            var backingFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data", "productList.xml");
            System.Xml.Linq.XElement xEle = System.Xml.Linq.XElement.Load(backingFile);
            var dataFetch = xEle.Descendants("Product").Where(x=> Convert.ToString(x.Element("Name").Value).ToUpper().Contains(Enter_Medicine.Text.ToUpper())).OrderBy(x => Convert.ToString(x.Element("Name").Value)).Select(x => new
            {
                Name = Convert.ToString(x.Element("Name").Value),
                AssociatedFile = Convert.ToString(x.Element("AssociatedFile").Value),
                Price = Convert.ToString(x.Element("Price").Value)
            }).ToList();
            scrlGrid.RowDefinitions.Clear();
            scrlGrid.Children.Clear();
            int i = 0;
            dataFetch.ForEach(row =>
            {
                scrlGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                Grid grd = new Grid();

                grd.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                grd.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = 5
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Auto
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Star
                });

                grd.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = 5
                });

                Label lblName = new Label();

                lblName.Text = row.Name;
                lblName.FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
                lblName.HorizontalOptions = LayoutOptions.End;
                lblName.VerticalOptions = LayoutOptions.Start;

                grd.Children.Add(lblName);
                Grid.SetRow(lblName, 0);
                Grid.SetColumn(lblName, 2);

                Label lblPrice = new Label();

                lblPrice.Text = row.Price;
                lblPrice.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                lblPrice.HorizontalOptions = LayoutOptions.End;
                lblPrice.VerticalOptions = LayoutOptions.End;

                grd.Children.Add(lblPrice);
                Grid.SetRow(lblPrice, 1);
                Grid.SetColumn(lblPrice, 2);

                Image img = new Image();
                img.Source = ImageSource.FromFile(row.AssociatedFile + ".jpg");
                img.WidthRequest = 80;
                img.HeightRequest = 80;
                img.VerticalOptions = LayoutOptions.Center;
                img.HorizontalOptions = LayoutOptions.Center;

                grd.Children.Add(img);
                Grid.SetRow(img, 0);
                Grid.SetColumn(img, 1);
                Grid.SetRowSpan(img, 2);

                var productTap = new TapGestureRecognizer();
                productTap.Tapped += async (s, ee) =>
                {
                    var scaleUpAnimTask = grd.ScaleTo(0.9, 200);

                    var fadeOutAnimTask = grd.FadeTo(0.5, 200);

                    await Task.WhenAll(scaleUpAnimTask, fadeOutAnimTask);

                    var scaleDownAnimTask = grd.ScaleTo(1, 200);

                    var fadeInAnimTask = grd.FadeTo(1, 200);

                    await Task.WhenAll(scaleDownAnimTask, fadeInAnimTask);

                    await Navigation.PushAsync(new ProductDetails(row.Name, row.AssociatedFile, row.Price));
                };
                grd.GestureRecognizers.Add(productTap);

                scrlGrid.Children.Add(grd);
                Grid.SetRow(grd, i);

                i++;
            });
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }
    }
}