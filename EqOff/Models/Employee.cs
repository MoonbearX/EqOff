using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace EqOff.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Обязательно укажите фамилию")]
        [Display(Name = "Фамилия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Обязательно укажите имя")]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Обязательно укажите отчество")]
        [Display(Name = "Отчество")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Обязательно укажите должность")]
        [Display(Name = "Должность")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Post { get; set; }

        [Required(ErrorMessage = "Обязательно укажите дату приема на работу")]
        [Display(Name = "Дата приема на работу")]
        public DateTime? DateIn { get; set; }

        public virtual ICollection<WriteOff>? WriteOffs { get; set; }
    }
}
