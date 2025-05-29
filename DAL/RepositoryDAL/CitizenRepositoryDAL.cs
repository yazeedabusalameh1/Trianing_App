using DAL.Dependencies.DatabaseSetting;
using DAL.Interface;
using DAL.ModelsDAL;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL.RepositoryDAL
{
    public class CitizenRepositoryDAL : ICitizenRepositoryDAL
    {
        private readonly IMongoCollection<Citizen> _citizens;

        public CitizenRepositoryDAL(IOptions<MongoDBSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _citizens = database.GetCollection<Citizen>("Citizen");
        }

        public List<Citizen> GetAllCitizens()
        {
            return _citizens.Find(_ => true).ToList();
        }

        public Citizen GetCitizenById(string id)
        {
            return _citizens.Find(c => c.CitizenID == id).FirstOrDefault();
        }

        public bool AddCitizen(Citizen citizen)
        {
            try
            {
                _citizens.InsertOne(citizen);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCitizen(Citizen citizen)
        {
            var result = _citizens.ReplaceOne(c => c.CitizenID == citizen.CitizenID, citizen);
            return result.ModifiedCount > 0;
        }

        public bool DeleteCitizen(string id)
        {
            var result = _citizens.DeleteOne(c => c.CitizenID == id);
            return result.DeletedCount > 0;
        }
    }
}
