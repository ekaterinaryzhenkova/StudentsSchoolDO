using DbModels;
using Provider;
using System.Globalization;

namespace CLient
{
    public class MasseurCommand
    {
        MasseurRepository _masseurRepository = new();

        public void AddMasseur(string name, string typeMassage)
        {
            var Masseur = new DbMasseur
            {
                Id = Guid.NewGuid(),
                Name = name,
                Specialization = typeMassage,
            };

            _masseurRepository.CreateMasseur(Masseur);
        }

        public void RemoveMasseur(Guid id)
        {
            _masseurRepository.DeleteMasseur(id);
        }

        public string GetMasseur(Guid id)
        {
            DbMasseur dbMasseur = _masseurRepository.GetMasseur(id);

            string strMasseur = $"{dbMasseur.Id} - {dbMasseur.Name} - {dbMasseur.Specialization}";

            Console.WriteLine(strMasseur);

            return strMasseur;
        }

        public List<string> GetMasseurs()
        {
            List<string> _strMasseurs = new();

            List<DbMasseur> _masseurs = _masseurRepository.GetMasseurs();

            foreach (DbMasseur masseur in _masseurs)
            {
                Console.WriteLine($"{masseur.Id} - {masseur.Name} - {masseur.Specialization}");
                _strMasseurs.Add($"{masseur.Id} - {masseur.Name} - {masseur.Specialization}");
            }

            return _strMasseurs;
        }

        public void UpdateMasseur(Guid id, string name)
        {
            _masseurRepository.EditMasseur(id, name);
        }
    }
}
