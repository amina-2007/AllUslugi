using System.ComponentModel.DataAnnotations;

namespace AllUslugi.Models
{
    public class Apeal
    {
        public int Id { get; set; }
        [Display(Name = "Название обращения")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Введите текст обращения")]
        [StringLength(30, ErrorMessage = "Не длиннее 30 символов")]
        [Display(Name = "Текст обращения")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Введите дату")]
        [Display(Name = "Дата обращения")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Apeal), nameof(ValidateDate))]
        public DateTime Date { get; set; } = DateTime.Today;
        [Required(ErrorMessage = "Выберите статус")]
        [Display(Name = "Статус обращения")]
        public string Status { get; set; }

        [Display(Name = "Оценка работы")]
        public string Rating { get; set; } = "OK";

        
        public static ValidationResult ValidateDate(DateTime date)
        {
            if (date.Date < DateTime.Today)
                return new ValidationResult("Дата не может быть раньше текущей");
            return ValidationResult.Success;
        }
    }
}
