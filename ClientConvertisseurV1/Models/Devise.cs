using System.ComponentModel.DataAnnotations;

namespace ClientConvertisseurV1.Models
{
    /// <summary>
    /// Représente une devise avec un identifiant, un nom et un taux de conversion.
    /// </summary>
    public class Devise
    {
        /// <summary>
        /// Identifiant unique de la devise.
        /// </summary>
        private int id;

        /// <summary>
        /// Nom de la devise (peut être nul).
        /// </summary>
        private string? nomDevise;

        /// <summary>
        /// Taux de conversion de la devise.
        /// </summary>
        private double taux;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Devise sans valeurs spécifiées.
        /// </summary>
        public Devise()
        {
            // Aucun code d'initialisation ici, les propriétés sont laissées avec leurs valeurs par défaut.
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Devise avec les valeurs spécifiées.
        /// </summary>
        /// <param name="id">L'identifiant unique de la devise.</param>
        /// <param name="nomDevise">Le nom de la devise.</param>
        /// <param name="taux">Le taux de conversion de la devise.</param>
        public Devise(int id, string? nomDevise, double taux)
        {
            this.Id = id;          // Initialise l'ID avec la valeur spécifiée.
            this.NomDevise = nomDevise;  // Initialise le nom de la devise.
            this.Taux = taux;      // Initialise le taux de conversion.
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la devise.
        /// </summary>
        /// <value>Identifiant de la devise.</value>
        public int Id
        {
            get
            {
                return this.id;  // Retourne la valeur de l'ID.
            }
            set
            {
                this.id = value;  // Définit la valeur de l'ID.
            }
        }

        /// <summary>
        /// Obtient ou définit le nom de la devise.
        /// </summary>
        /// <remarks>
        /// Cette propriété est obligatoire grâce à l'attribut [Required].
        /// </remarks>
        /// <value>Nom de la devise. Cette valeur ne peut être nulle.</value>
        public string? NomDevise
        {
            get
            {
                return this.nomDevise;  // Retourne le nom de la devise.
            }
            set
            {
                this.nomDevise = value;  // Définit le nom de la devise.
            }
        }

        /// <summary>
        /// Obtient ou définit le taux de conversion de la devise.
        /// </summary>
        /// <value>Taux de conversion de la devise.</value>
        public double Taux
        {
            get
            {
                return this.taux;  // Retourne le taux de conversion.
            }
            set
            {
                this.taux = value;  // Définit le taux de conversion.
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   this.Id == devise.Id &&
                   this.NomDevise == devise.NomDevise &&
                   this.Taux == devise.Taux;
        }

    }
}
