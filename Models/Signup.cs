using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace memberDatabasetest.Models
{
    public class Signup
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Year in School")]
        public string SchoolYear { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "E-mail Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }
        [Required]
        [Display(Name = "Choose 3 of the following specialties you are interested in")]
        public string Specialty { get; set; }
        [Required]
        [Display(Name = "Do you have a car?")]
        public bool HasCar { get; set; }
        [Required]
        [Display(Name = "What days of the week can you shadow? (e.g. Monday morning, Friday afternoon)")]
        public string Availability { get; set; }
        [Required]
        [Display(Name = "Can you shadow physicians in Broward County?")]
        public bool BrowardAvailable { get; set; }
        [Required]
        [Display(Name = "What volunteer activity(s) will you participate in?")]
        public string VolunteerActivity { get; set; }

    }

    public class SignupDBContext : DbContext
    {
        public DbSet<Signup> Signups { get; set; }
    }



}