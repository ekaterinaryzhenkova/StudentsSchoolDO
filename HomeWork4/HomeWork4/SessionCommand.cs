using DbModels;
using Provider;

namespace CLient
{
    public class SessionCommand
    {
        ClientRepository _clientRepository = new();
        MasseurRepository _masseurRepository = new();
        SessionRepository _sessionRepository = new();

        public void AddSession(Guid clientId, Guid masseurId, DateTime dateTime)
        {
            //var client = _clientRepository.GetClient(clientId);
            //var masseur = _masseurRepository.GetMasseur(masseurId);

            var Session = new DbSession
            {
                Id = Guid.NewGuid(),
                ClientId = clientId,
                MasseurId = masseurId,
                DateTime = dateTime,
                TypeOfMassage = "Thai massage"
                //Client = client,
                //Masseur = masseur,
            };

            _sessionRepository.CreateSession(Session);
        }

        public void RemoveSession(Guid id)
        {
            _sessionRepository.DeleteSession(id);
        }

        public string GetSession(Guid id)
        {
            DbSession dbSession = _sessionRepository.GetSession(id);

            string strSession = $"{dbSession.Id} - {dbSession.MasseurId} - {dbSession.ClientId} - {dbSession.DateTime} - {dbSession.TypeOfMassage}";

            Console.WriteLine(strSession);

            return strSession;
        }

        public List<string> GetSessions()
        {
            List<string> _strSessions = new();

            List<DbSession> _sessions = _sessionRepository.GetSessions();

            foreach (DbSession session in _sessions)
            {
                Console.WriteLine($"{session.Id} - {session.MasseurId} - {session.ClientId} - {session.DateTime} - {session.TypeOfMassage}");
                _strSessions.Add($"{session.Id} - {session.MasseurId} - {session.ClientId} - {session.DateTime} - {session.TypeOfMassage}");
            }

            return _strSessions;
        }

        public void UpdateSession(Guid id, DateTime dateTime, string massageType)
        {
            _sessionRepository.EditSession(id, dateTime, massageType);
        }
    }
}

