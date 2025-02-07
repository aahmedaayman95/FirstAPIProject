using System.ComponentModel.DataAnnotations;

namespace FirstAPIProject.Validators
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value) 
        {
            if (value is not DateTime enteredDate)
            {
                return false; // Invalid type
            }

            DateTime now = DateTime.Now;
            return enteredDate >= now; // Ensures the date is in the future or present
        }
    }
}
