using DAL.Interface;
using DAL.ModelsDAL;
using Trianing_App.BL.BLInterface;

namespace Trianing_App.BL
{
    public class CitizenBLService : ICitizenBLService
    {
        private readonly ICitizenRepositoryDAL _citizenRepository;

        public CitizenBLService(ICitizenRepositoryDAL citizenRepository)
        {
            _citizenRepository = citizenRepository;
        }

        public List<Citizen> GetAllCitizens() => _citizenRepository.GetAllCitizens();

        public Citizen GetCitizenById(string id) => _citizenRepository.GetCitizenById(id);

        public bool AddCitizen(Citizen citizen) => _citizenRepository.AddCitizen(citizen);

        public bool UpdateCitizen(Citizen citizen) => _citizenRepository.UpdateCitizen(citizen);

        public bool DeleteCitizen(string id) => _citizenRepository.DeleteCitizen(id);
    }
}
