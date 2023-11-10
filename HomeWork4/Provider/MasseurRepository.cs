using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    internal class MasseurRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbMasseur> GetMasseurs()
        {
            return _dbContext.Masseurs.ToList();
        }

        public DbMasseur GetMasseur(Guid masseurId)
        {
            return _dbContext.Masseurs
              .AsNoTracking()
              .Where(u => u.Id == masseurId)
              .FirstOrDefault();
        }

        public void CreateMasseur(DbMasseur masseur)
        {
            _dbContext.Add(masseur);

            _dbContext.SaveChanges();
        }

        public void EditMasseur(Guid masseurId)
        {
            var masseur = _dbContext.Clients.FirstOrDefault(u => u.Id == masseurId);

            masseur.Name = "Anna Medvedeva";

            _dbContext.SaveChanges();
        }

        public void DeleteMasseur(Guid masseurId)
        {
            var masseur = _dbContext.Clients.FirstOrDefault(u => u.Id == masseurId);

            _dbContext.Remove(masseur);

            _dbContext.SaveChanges();
        }
    }
}
