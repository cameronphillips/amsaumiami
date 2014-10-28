using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace memberDatabasetest.Models
{
    public class Member
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Years Paid")]
        public int yearsPaid { get; set; }
        [Display(Name = "Points")]
        public int points { get; set; }
        [Display(Name = "Inactive")]
        public bool inactive { get; set; }
    }
    public class MemberDBContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}