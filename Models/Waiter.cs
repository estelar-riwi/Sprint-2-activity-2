using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint2Activity2.Models
{
    [Table("Waiters")]
    public class Waiter
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Shift { get; set; }
        public int Years_Experience { get; set; }
    }
}