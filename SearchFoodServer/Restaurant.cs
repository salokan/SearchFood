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
    
    public partial class Restaurant
    {
        public Restaurant()
        {
            this.Commentaire = new HashSet<Commentaire>();
            this.Historique = new HashSet<Historique>();
        }
    
        public int Id_Restaurant { get; set; }
        public string Nom { get; set; }
        public string Site_Web { get; set; }
        public string Mail { get; set; }
        public string Adresse { get; set; }
        public string Code_Postal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<int> Duree_repas { get; set; }
        public Nullable<double> Prix { get; set; }
        public int Id_Categorie { get; set; }
        public int Id_Type_Cuisine { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        public virtual ICollection<Historique> Historique { get; set; }
        public virtual Type_Cuisine Type_Cuisine { get; set; }
    }
}
