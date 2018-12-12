using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Settings : IValidatable
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        //Only valid settings can be saved in the database
        public bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(this.UserName) && this.Id != 0);
            }
        }


        //public event EventHandler SavingChanges;

        //MyEntities entities = (MyEntities)user;


        //foreach (var item in
        //    entities.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified | System.Data.EntityState.Added)
        //        .Where(entry => (entry.Entity is IValidatable) && (!entry.IsRelationship))
        //        .Select(entry => entry.Entity as IValidatable))
        //{
        //    if (!Settings.IsValid)
        //    {
        // throw some exception
        //    }
        //}

        //        Entity is created belonging to a user
        //User model updated
        //Repository is created
        //Database migration is created

        //Only valid settings can be saved in the database

        //Test for checking validity of the settings



    }
}


