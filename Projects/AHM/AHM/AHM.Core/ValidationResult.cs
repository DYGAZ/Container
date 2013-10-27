using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHM.Core
{
    public class ValidationResult
    {
        public string ValidationMessage;

        public ValidationResult(string message)
        {
            ValidationMessage = message;
        }

    }

    public class ValidationResults
    {
        public List<ValidationResult> ValidationResultList;
        public bool IsValid
        {
            get
            {
                if (ValidationResultList.Count == 0) return true;
                return false;
            }
        }

        public ValidationResults()
        {
            ValidationResultList = new List<ValidationResult>();
        }

        public void AddResult(ValidationResult result)
        {
            if (result == null) return;
            ValidationResultList.Add(result);
        }

        public void AddAllResults(ValidationResults results)
        {
            if (results.ValidationResultList == null) return;

            foreach (var result in results.ValidationResultList)
                ValidationResultList.Add(result);
        }
    }
}
