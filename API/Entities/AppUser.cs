using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using API.Extensions;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        //default is zero
       

        public DateOnly DateOfBirth {get; set;}

        public string KnownAs{get; set;}

        public DateTime Created {get; set;} = DateTime.UtcNow;

        public DateTime LastActive {get; set;} = DateTime.UtcNow;

        public string Gender {get; set;}

        public string Introduction {get; set;}
                     

        public string LookingFor {get; set;}

        public string Intersets {get; set;}

        public string City {get; set;}

        public string Country {get; set;}

        public List<Photo> Photos {get; set;} = new();// moze i samo new() da napisham ke raboti.

        public List<UserLike> LikedByUsers {get; set;}

        public List<UserLike> LikedUsers { get; set; } 

        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesReceived { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }

        // public int GetAge(){
        //     return DateOfBirth.CalculateAge();
        // }
    }
}