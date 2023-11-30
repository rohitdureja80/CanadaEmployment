using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace CanadaEmployment.Model
{
    public class UnemploymentModel
    {
        [Key]
        public string? ReferenceDate { get; set; }
        public string ReferenceMonth
        {
            get
            {
                return this.ReferenceDate.Split('-')[0].ToString();
            }
            set { this.ReferenceMonth = value; }
        }
        public int ReferenceYear
        {
            get
            {
                return Convert.ToInt32(this.ReferenceDate.Split('-')[1].ToString());
            }
            set { this.ReferenceYear = value; }
        }
        public string? GeoLocation { get; set; }
        public string? Sex { get; set; }
        public string? AgeGroup { get; set; }
        public int EmploymentNum { get; set; }
        public int FullTimeEmploymentNum { get; set; }
        public int LabourForce { get; set; }
        public int PartTimeEmploymentNum { get; set; }
        public int Population { get; set; }
        public int UnemploymentNum { get; set; }
        public decimal EmploymentRate { get; set; }
        public decimal ParticipationRate { get; set; }
        public decimal UnemploymentRate { get; set; }
    }
}
