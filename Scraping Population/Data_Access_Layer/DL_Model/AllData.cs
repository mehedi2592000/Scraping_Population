using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DL_Model
{
    public class AllData
    {
        [Key]
        public int Id { get; set; }

        public string? Country  { get; set; }

        public string? Population  { get; set; }

        public string? Percentage  { get; set; }

        public DateTime? Date  { get; set; }

        public string? Source  { get; set; }


    }
}
