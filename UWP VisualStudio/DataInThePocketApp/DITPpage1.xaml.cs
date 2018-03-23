using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Text;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataInThePocketApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DITPpage1 : Page
    {
        public static int j = 1;
        Thickness TextMargin = new Thickness(20, 20, 20, 0);
        Library library = new Library();
        public static int i = 1;
        public DITPpage1()
        {

            this.InitializeComponent();
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            MyStack.Children.Add(new TextBox() { Name = "ApporSiteName" + i.ToString(), PlaceholderText = "App or Site Name", Margin = TextMargin });
            MyStack.Children.Add(new TextBox() { Name = "Username" + i.ToString(), PlaceholderText = "Username", Margin = TextMargin });
            MyStack.Children.Add(new TextBox() { Name = "Email" + i.ToString(), PlaceholderText = "Email", Margin = TextMargin });
            MyStack.Children.Add(new TextBox() { Name = "Password" + i.ToString(), PlaceholderText = "Password", Margin = TextMargin });
            MyStack.Children.Add(new TextBox() { Name = "Url" + i.ToString(), PlaceholderText = "Url", Margin = TextMargin });
            MyStack.Children.Add(new Line() { X1 = 0, Y1 = 10, StrokeThickness = 3 });
            i++;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            library.SaveSettings("ivalue", i.ToString());
            library.SaveSettings("ApporSiteName", ApporSiteName.Text);
            library.SaveSettings("Username", Username.Text);
            library.SaveSettings("Email", Email.Text);
            library.SaveSettings("Password", Password.Text);
            library.SaveSettings("Url", Url.Text);
            for (j = 1; j < i; j++)
            {
                TextBox Value1 = FindName("ApporSiteName" + j.ToString()) as TextBox;
                TextBox Value2 = FindName("Username" + j.ToString()) as TextBox;
                TextBox Value3 = FindName("Email" + j.ToString()) as TextBox;
                TextBox Value4 = FindName("Password" + j.ToString()) as TextBox;
                TextBox Value5 = FindName("Url" + j.ToString()) as TextBox;
                library.SaveSettings("ApporSiteName" + j, Value1.Text);
                library.SaveSettings("Username" + j, Value2.Text);
                library.SaveSettings("Email" + j, Value3.Text);
                library.SaveSettings("Password" + j, Value4.Text);
                library.SaveSettings("Url" + j, Value5.Text);
            }
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {

            ApporSiteName.Text = library.LoadSetting("ApporSiteName");
            Username.Text = library.LoadSetting("Username");
            Email.Text = library.LoadSetting("Email");
            Password.Text = library.LoadSetting("Password");
            Url.Text = library.LoadSetting("Url");
            MyStack.Children.Add(new Line() { X1 = 0, Y1 = 10, StrokeThickness = 3 });
            if (library.LoadSetting("ivalue") != null)
            {
                string OldIvalue;
                OldIvalue = library.LoadSetting("ivalue");
                bool res = int.TryParse(OldIvalue, out i);
                if (res == false)
                {
                    //nothing!! :D
                }
            }
            for (j = 1; j < i; j++)
            {
                MyStack.Children.Add(new TextBox() { Text = library.LoadSetting("ApporSiteName" + j.ToString()), Name = "ApporSiteName" + j.ToString(), PlaceholderText = "App or Site Name", Margin = TextMargin });
                MyStack.Children.Add(new TextBox() { Text = library.LoadSetting("Username" + j.ToString()), Name = "Username" + j.ToString(), PlaceholderText = "Username", Margin = TextMargin });
                MyStack.Children.Add(new TextBox() { Text = library.LoadSetting("Email" + j.ToString()), Name = "Email" + j.ToString(), PlaceholderText = "Email", Margin = TextMargin });
                MyStack.Children.Add(new TextBox() { Text = library.LoadSetting("Password" + j.ToString()), Name = "Password" + j.ToString(), PlaceholderText = "Password", Margin = TextMargin });
                MyStack.Children.Add(new TextBox() { Text = library.LoadSetting("Url" + j.ToString()), Name = "Url" + j.ToString(), PlaceholderText = "Url", Margin = TextMargin });
                MyStack.Children.Add(new Line() { X1 = 0, Y1 = 10, StrokeThickness = 3 });
            }
        }
        private async void Export_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker();


            picker.SuggestedFileName = "My Data File";
            picker.DefaultFileExtension = ".txt";
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeChoices.Add("Text", new List<string>() { ".txt" });
            StorageFile ExportedFile = await picker.PickSaveFileAsync();
            if (ExportedFile == null)
            {
                return;
            }
            await FileIO.AppendTextAsync(ExportedFile, "ApporSiteName: " + ApporSiteName.Text + "\r\n");
            await FileIO.AppendTextAsync(ExportedFile, "Username: " + Username.Text + "\r\n");
            await FileIO.AppendTextAsync(ExportedFile, "Email: " + Email.Text + "\r\n");
            await FileIO.AppendTextAsync(ExportedFile, "Password: " + Password.Text + "\r\n");
            await FileIO.AppendTextAsync(ExportedFile, "Url: " + Url.Text + "\r\n");
            for (int Ex = 1; Ex < i; Ex++)
            {
                TextBox Value1 = FindName("ApporSiteName" + Ex.ToString()) as TextBox;
                TextBox Value2 = FindName("Username" + Ex.ToString()) as TextBox;
                TextBox Value3 = FindName("Email" + Ex.ToString()) as TextBox;
                TextBox Value4 = FindName("Password" + Ex.ToString()) as TextBox;
                TextBox Value5 = FindName("Url" + Ex.ToString()) as TextBox;
                await FileIO.AppendTextAsync(ExportedFile, "\r\nApporSiteName: " + Value1.Text + "\r\n");
                await FileIO.AppendTextAsync(ExportedFile, "Username: " + Value2.Text + "\r\n");
                await FileIO.AppendTextAsync(ExportedFile, "Email: " + Value3.Text + "\r\n");
                await FileIO.AppendTextAsync(ExportedFile, "Password: " + Value4.Text + "\r\n");
                await FileIO.AppendTextAsync(ExportedFile, "Url: " + Value5.Text + "\r\n");
            }
        }
    }
}
