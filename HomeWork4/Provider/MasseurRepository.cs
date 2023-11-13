using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    public class MasseurRepository
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

        public void EditMasseur(Guid masseurId, string name)
        {
            var masseur = _dbContext.Masseurs.FirstOrDefault(u => u.Id == masseurId);

            masseur.Name = name;

            _dbContext.SaveChanges();
        }

        public void DeleteMasseur(Guid masseurId)
        {
            var masseur = _dbContext.Masseurs.FirstOrDefault(u => u.Id == masseurId);

            _dbContext.Remove(masseur);

            _dbContext.SaveChanges();
        }
    }
}
