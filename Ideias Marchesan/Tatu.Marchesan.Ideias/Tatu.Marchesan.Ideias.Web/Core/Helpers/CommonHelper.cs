using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace Tatu.Marchesan.Ideias.App.Core.Helpers
{
    public static class CommonHelper
    {
        public static SelectList SelectList(IEnumerable items, string value = "Id", string text = "Descricao")
        {
            return new SelectList(items, value, text);
        }

        public static SelectList SelectList(IEnumerable items, string value, string text, object selectedValue)
        {
            return new SelectList(items, value, text, selectedValue);
        }
    }
}