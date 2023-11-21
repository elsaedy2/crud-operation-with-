using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElsaedyDemo.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(50)]
        public string RoomName { get; set; }


    }
}
