//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SearchFoodServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            this.Commentaire = new HashSet<Commentaire>();
            this.Historique = new HashSet<Historique>();
        }
    
        public int Id_Utilisateur { get; set; }
        public string Pseudonyme { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Code_Postal { get; set; }
        public string Ville { get; set; }
    
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        public virtual ICollection<Historique> Historique { get; set; }
    }
}
