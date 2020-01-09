using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xmas.Areas.Membre.Models
{
    public class CadeauModel
    {
        private int _idCadeau;
        private string _nom;
        private string _description;

        public int IdCadeau
        {
            get
            {
                return _idCadeau;
            }

            set
            {
                _idCadeau = value;
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
    }
}