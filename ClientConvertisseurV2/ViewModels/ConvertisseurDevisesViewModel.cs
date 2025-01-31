using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDevisesViewModel:CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private ObservableCollection<Devise> devises = new ObservableCollection<Devise>();
        private Double resultat;
        private Double nb1;
        private Devise unedevise;

        public Double Resultat
        { //Property Resultat
            get { return resultat; }
            set
            {
                resultat = value;
                OnPropertyChanged();
            }
        }

        public Double Nb1
        { //Property Resultat
            get { return nb1; }
            set
            {
                nb1 = value;
                OnPropertyChanged();
            }
        }

        public Devise UneDevise
        { //Property Resultat
            get { return unedevise; }
            set
            {
                unedevise = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Devise> Devises
        {
            get { return devises; }

            set
            {
                devises = value;
                OnPropertyChanged();
            }
        }
        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurDevisesViewModel()
        {
            getDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public async void getDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7232/api/");
            List<Devise> result = await service.GetDevisesAsync("Devises");
            Devises = new ObservableCollection<Devise>(result);
        }

        public void ActionSetConversion()
        {
            if (UneDevise == null)
            {

                MessageAsync("Erreur", "Vous devez selectionner une devise !");
                return;
            }
            Resultat = Nb1 / UneDevise.Taux;
        }
        private async void MessageAsync(string title, string content)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };
            noWifiDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

    }
}
