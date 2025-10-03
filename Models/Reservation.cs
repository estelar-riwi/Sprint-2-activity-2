using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint2Activity2.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan Hour { get; set; }

        [Display(Name = "Número de personas")]
        [Range(1, 50, ErrorMessage = "Debe ingresar al menos una persona.")]
        public int Num_People { get; set; }

        [Display(Name = "Notas")]
        public string? Notes { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}