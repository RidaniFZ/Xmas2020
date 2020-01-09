using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public class GroupeRepository : BaseRepository<Groupe, int>
    {
        public GroupeRepository(string Cnstr) : base(Cnstr)
        { 
            SelectAllCommand = "SELECT * FROM Groupe";
            SelectOneCommand = "SELECT * FROM Groupe WHERE IdGroupe=@IdGroupe ";
            InsertCommand = "INSERT INTO Groupe(Nom,Description,IdEvenement) OUTPUT inserted.IdGroupe VALUES (@Nom,@Description,@IdEvenement)";
            UpdateCommand = "UPDATE Groupe SET Nom=@Nom,Description=@Description,IdEvenement=@IdEvenement WHERE IdGroupe=@IdGroupe";
            DeleteCommand = "DELETE FROM  Groupe WHERE IdGroupe=@IdGroupe";
        }

        public override IEnumerable<Groupe> GetAll()
        {
            return base.getAll(Map);
        }


        public override Groupe GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("IdGroupe", id);
            return base.getOne(Map, QueryParameters);
        }

        public IEnumerable<Groupe> GetGroupeMembre(int id, bool  IsAdmin=false)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            SelectAllCommand = @"SELECT  Groupe.IdGroupe, Groupe.Nom, Groupe.Description, Groupe.IdEvenement,
                         Evenement.Nom AS NomEvenement FROM Membre INNER JOIN MembreGroupe ON Membre.IdMembre = MembreGroupe.IdMembre INNER JOIN Groupe
                        ON MembreGroupe.IdGroupe = Groupe.IdGroupe INNER JOIN Evenement ON Groupe.IdEvenement = Evenement.IdEvenement WHERE (Membre.IdMembre = @IdMembre)";
            QueryParameters.Add("IdMembre", id);
            if(IsAdmin)
            {
                SelectAllCommand += "AND (MembreGroupe.Admin = 1)";
            }
            return base.GetGroupes(Map, QueryParameters);      
        }

        public override Groupe Insert(Groupe toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdGroupe = id;
            return toInsert;
        }

        public override bool Update(Groupe toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("IdGroupe", id);
            return base.Delete( QueryParameters);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Groupe toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["Nom"] =  toInsert.Nom;
            p["IdGroupe"] = toInsert.IdGroupe;
            p["IdEvenement"] = toInsert.IdEvenement;
            return p;
        }

        private Groupe Map(SqlDataReader p)
        {
            return new Groupe()
            {
                Nom = p["Nom"].ToString(),
                IdEvenement = (int)p["IdEvenement"],
                IdGroupe = (int)p["IdGroupe"],
                Description = p["Description"].ToString()

            };
        }

        #endregion
    }
}
