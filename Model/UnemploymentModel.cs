using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace CanadaEmployment.Model
{
    public class UnemploymentModel
    {
        [Key]
        [JsonPropertyName("referenceDate")]
        public string ReferenceDate { get; set; }

        [JsonPropertyName("referenceMonth")]
        public string ReferenceMonth
        {
            get
            {
                return this.ReferenceDate.Split('-')[0].ToString();
            }
            set { this.ReferenceMonth = value; } 
        }

        [JsonPropertyName("referenceYear")]
        public int ReferenceYear
        {
            get
            {
                return Convert.ToInt32(this.ReferenceDate.Split('-')[1].ToString());
            }
            set { this.ReferenceYear = value; }
        }
        
        [JsonPropertyName("location")] 
        public string GeoLocation { get; set; }
        
        [JsonPropertyName("sex")]
        public string Sex { get; set; }
        
        [JsonPropertyName("ageGroup")]
        public string AgeGroup { get; set; }

        [JsonPropertyName("employmentNum")]
        public int EmploymentNum { get; set; }
       
        [JsonPropertyName("fulltimeEmploymentNum")]
        public int FullTimeEmploymentNum { get; set; }
        
        [JsonPropertyName("labourForce")]
        public int LabourForce { get; set; }

        [JsonPropertyName("partimeEmploymentNum")]
        public int PartTimeEmploymentNum { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        [JsonPropertyName("unemploymentNum")]
        public int UnemploymentNum { get; set; }

        [JsonPropertyName("employmentRate")]
        public decimal EmploymentRate { get; set; }

        [JsonPropertyName("participationRate")]
        public decimal ParticipationRate { get; set; }

        [JsonPropertyName("unemploymentRate")]
        public decimal UnemploymentRate { get; set; }
    }
}
