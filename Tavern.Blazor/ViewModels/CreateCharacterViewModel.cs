using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavern.Blazor.Validation;

namespace Tavern.Blazor.ViewModels
{
    public class CreateCharacterViewModel
    {
        internal CustomValidator _customValidator;

        public int Weight { get; set; }

        public void HandleValidSubmit()
        {
            _customValidator.ClearErrors();

            var errors = new Dictionary<string, List<string>>();

            if (Weight < 0)
            {
                errors.Add(nameof(Weight).ToString(),
                    new List<string>()
                    {
                        "Oh no, an error"
                    });
            }

            if (errors.Count() > 0)
            {
                _customValidator.DisplayErrors(errors);
            }

            //do the thing
        }
    }
}
