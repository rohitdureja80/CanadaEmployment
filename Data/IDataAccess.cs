using CanadaEmployment.Model;

namespace CanadaEmployment.Data
{
    public interface IDataAccess
    {
        public List<UnemploymentModel> GetUnemploymentData();
        public List<UnemploymentModel> GetUnemploymentData(string location);
    }
}
