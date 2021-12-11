using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Dude its not that hard.... Just paste some Profile Pic!")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "OK, i understand that u don't want to tell us something about yourself, but common Enter your name!")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //RelationShips
        public List<Car> Cars { get; set; }
    }
}
