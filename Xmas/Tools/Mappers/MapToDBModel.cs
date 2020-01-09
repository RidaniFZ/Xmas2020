using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Areas.Membre.Models;
using Xmas.DAL.Models;
using Xmas.Models;

namespace Xmas.Tools.Mappers
{

    /// <summary>
    /// Use to define function for mapping models
    /// </summary>
    public static class MapToDBModel
    {
        public static Membre LoginToMembre(LoginModel lm)
        {
            return new Membre()
            {
                Courriel = lm.Email,
                MotDePasse = lm.Password
            };
        }

        public static MembreModel MembreToMembreModel(Membre membre)
        {
            if (membre == null) return null;
            return new MembreModel()
            {
                Nom = membre.Nom
            };
        }

        public static Membre RegisterToMembre(RegisterModel rm)
        {
            return new Membre()
            { Nom=rm.Nom,
             Prenom=rm.Prenom,
              Surnom=rm.Surnom,
                Courriel = rm.Email,
                MotDePasse = rm.MotDePasse
            };
        }

        internal static ProfileModel MemberToProfile(Membre mmodel)
        {
            return new ProfileModel()
            {
                Id= mmodel.Id,
                Nom = mmodel.Nom,
                Prenom = mmodel.Prenom,
                Surnom = mmodel.Surnom,
                Email = mmodel.Courriel
            };
        }

        public static GroupeModel GroupeToGroupeModel(Groupe g)
        {
            return new GroupeModel()
            {
                IdGroupe = g.IdGroupe,
                Nom = g.Nom,
                Description = g.Description,

            };
        }

        public static CadeauModel CadeauToCadeauModel(Cadeau C)
        {
            return new CadeauModel()
            {
                IdCadeau = C.IdCadeau,
                Nom = C.Nom,
                Description = C.Description,

            };
        }
    }
}