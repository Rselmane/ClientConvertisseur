using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Devise> devises = new ObservableCollection<Devise>();
        private Double resultat;
        private Double nb1;
        private Devise unedevise;
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            getDataOnLoadAsync();
            Console.WriteLine(Devises.Count);
        }

        public ObservableCollection<Devise> Devises
        {
            get { return devises;}

            set
            {
                devises = value;
                OnPropertyChanged("Devises");
            }
        }

        public Double Resultat
        { //Property Resultat
            get { return resultat; }
            set
            {
                resultat = value;
                OnPropertyChanged("Resultat");
            }
        }

        public Double Nb1
        { //Property Resultat
            get { return nb1; }
            set
            {
                nb1 = value;
                OnPropertyChanged("Nb1");
            }
        }

        public Devise UneDevise
        { //Property Resultat
            get { return unedevise; }
            set
            {
                unedevise = value;
                OnPropertyChanged("UneDevise");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private async void getDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7232/api/");
            List <Devise> result = await service.GetDevisesAsync("Devises");
            if (result == null)
                MessageAsync("Api non disponible", "Erreur");
            else
                Devises = new ObservableCollection<Devise>(result);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ConvertButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if(UneDevise ==  null)
            {

                MessageAsync("Erreur", "Vous devez selectionner une devise !");
                return;
            }
            Resultat = Nb1*UneDevise.Taux;

        }
        private async void MessageAsync(string title,string content)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };
            noWifiDialog.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
    }
    
}
