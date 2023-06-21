using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EqOff.Models
{
    public class WriteOff
    {
        public int WriteOffId { get; set; }

        [Display(Name = "Оборудование")]
        public int? EquipmentId { get; set; }

        [Required(ErrorMessage = "Обязательно укажите причину списания")]
        [Display(Name = "Причина списания")]
        public string? Reason { get; set; }

        [Required(ErrorMessage = "Обязательно укажите дату списания")]
        [Display(Name = "Дата списания")]
        public DateTime? DateOff { get; set; }

        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }

        [Required(ErrorMessage = "Обязательно укажите номер документа")]
        [Display(Name = "Номер документа")]
        public int? Number { get; set; }

        [Required(ErrorMessage = "Обязательно укажите дату регистрации")]
        [Display(Name = "Дата регистрации")]
        public DateTime? DateReg { get; set; }

        [Display(Name = "Оборудование")]
        public virtual Equipment? Equipment { get; set; }

        [Display(Name = "Сотрудник")]
        public virtual Employee? Employee { get; set; }
    }
}
