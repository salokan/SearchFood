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
    
    public partial class Commentaire
    {
        public int Id_Commentaire { get; set; }
        public int Id_Restaurant { get; set; }
        public int Id_Utilisateur { get; set; }
        public string Commentaire1 { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
