using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApICoreLearn.Model
{
    public class TblEmployee
    {
        [Key]  // Make Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //Auto Generate Id 
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }
        public string LastName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime Doj { get; set; }
        public string Gender { get; set; }
        public int IsMarried { get; set; }
        public int IsActive { get; set; }
        public int DesignationID { get; set; }

        [NotMapped] //Will not create column in this table
        public string Designation { get; set; }

    }
}
