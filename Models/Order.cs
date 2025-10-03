using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint2Activity2.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Número de Pedido")]
        public int Order_Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Status { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}