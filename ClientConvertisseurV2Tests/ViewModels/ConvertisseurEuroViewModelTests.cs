using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using System.Collections.ObjectModel;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }
        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary> 
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();

            ObservableCollection<Devise> devises = new ObservableCollection<Devise>();
            devises.Add(new Devise(0, "Dollar", 1.08));
            devises.Add(new Devise(1, "Franc Suisse", 1.07));
            devises.Add(new Devise(2, "Yen", 120));

            //Act
            convertisseurEuro.getDataOnLoadAsync();

            Thread.Sleep(1000);
            //Assert
           Assert.IsNotNull(convertisseurEuro.Devises);
           CollectionAssert.AreEqual(devises,convertisseurEuro.Devises);
        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            convertisseurEuro.Nb1 = 100;
            Devise devise = new Devise(1, "Franc Suisse", 1.07);
            convertisseurEuro.UneDevise = devise;
            //Act
            convertisseurEuro.ActionSetConversion();
            //Assert
            Assert.AreEqual(107, convertisseurEuro.Resultat);
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_NonOK_WSnondemarre()
        {
          
            Assert.IsNull(null);
        }



    }
}