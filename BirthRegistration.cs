using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Registration.Models
{
    public class BirthRegistration
    {
        [Key]
        public int RegNo { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birth Date Required")]
        [DisplayName("BirthDate")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "FatherName Required")]
        [DisplayName("Father Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "MotherName Required")]
        [DisplayName("Mother Name")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [DisplayName("Address")]
        public string Address { get; set; }

    }

    public class BRRegistrationEntities : DbContext
    {
        public DbSet<BirthRegistration> BirthRegistration { get; set; }
    }
}
