namespace Panzar.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}