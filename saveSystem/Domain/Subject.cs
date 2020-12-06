using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace saveSystem.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва предмета")]
        public string SubjectName { get; set; }
        [Required]
        [Display(Name = "Курс")]
        public int Course { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile SubjectFile { get; set; }
        //public string SubjectFileName { get; set; }
        public string SubjectFileName { get; set; }
        public string SubjectFileLocation { get; set; }
        public bool isFavorite { get; set; }
    }
}
