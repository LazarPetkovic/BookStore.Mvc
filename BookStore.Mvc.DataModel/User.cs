using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.DataModel
{
    public class User : IdentityUser
    {
        private ICollection<ShoppingCart> shoppingCarts;

        public User()
        {
            this.shoppingCarts = new HashSet<ShoppingCart>();
        }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public decimal? CreditLimit { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Telephone { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get { return this.shoppingCarts; }
            set { this.shoppingCarts = value; }
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
