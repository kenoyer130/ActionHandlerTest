using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MvcModel
{
    public class Patient
    {
        [Required]
        public int PatientID { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public Patient()
        {
        }

        public string GetCacheKey()
        {
            return GetCacheKey(PatientID);
        }

        public static string GetCacheKey(int patientID)
        {
            return string.Format("patient_{0}", patientID);
        }
    }
}
