using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Enums
{
    public enum LanguageEnums
    {
        [Display(Name ="Hindi Language")]
        Hindi,
        English,
        German,
        Chinese,
        Urdu
    }
}
