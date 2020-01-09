using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xmas.Areas.Membre.Models
{
    public class GroupeModel
    {
        private int _idGroupe;
        private string _nom;
        private string _description;
        private string _NomEvenement;

        public int IdGroupe
        {
            get
            {
                return _idGroupe;
            }

            set
            {
                _idGroupe = value;
            }
        }



        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public string NomEvenement
        {
            get
            {
                return _NomEvenement;
            }

            set
            {
                _NomEvenement = value;
            }
        }

    }
}