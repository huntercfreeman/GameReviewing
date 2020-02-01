using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.ViewModels
{
    public class GameFormViewModel
    {
        [Required]
        public string Title { get; set; }
        public byte[] Picture { get; set; }
    }
}
