using System.ComponentModel.DataAnnotations;

namespace OnlineTiffinSystem.Models
{
    public class TblMessDetail
    {
         
            public int MessId { get; set; }

            public string MessName { get; set; }

            public string OwnerName { get; set; }

            public string Address { get; set; }

            public string EmailAddress { get; set; }

            public string Password { get; set; }

            public string MobileNo { get; set; }

            public string AlternativeNo { get; set; }

            public DateTime CreatedAt { get; set; }
        }
    }

