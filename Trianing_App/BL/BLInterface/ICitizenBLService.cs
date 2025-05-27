using DAL.ModelsDAL;

namespace Trianing_App.BL.BLInterface
{
    public interface ICitizenBLService
    {
        List<Citizen> GetAllCitizens();
        Citizen GetCitizenById(int id);
        bool AddCitizen(Citizen citizen);
        bool UpdateCitizen(Citizen citizen);
        bool DeleteCitizen(int id);
        
    }
}
