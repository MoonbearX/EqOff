using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace EqOff.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        [Required(ErrorMessage = "Обязательно укажите название")]
        [Display(Name = "Название оборудования")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? EqName { get; set; }

        [Required(ErrorMessage = "Обязательно укажите тип")]
        [Display(Name = "Тип оборудования")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Обязательно укажите дату поступления в прокат")]
        [Display(Name = "Дата поступления в прокат")]
        public DateTime? DateIn { get; set; }

        public virtual ICollection<WriteOff>? WriteOffs { get; set; }
    }
}
