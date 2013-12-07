using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BitEd.Validators
{
    class FileExist:ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string FilePath = Convert.ToString(value);
            if (File.Exists(FilePath))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Please enter a valid filepath");
            }
            
        }
    }
}
