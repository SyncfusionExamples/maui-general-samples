
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Inputs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToleratingTyposMAUI
{
    public class CustomFiltering : IAutocompleteFilterBehavior
    {
        public CustomFiltering()
        {
            items.Add("Carrots");
            items.Add("Broccoli");
            items.Add("Cauliflower");
            items.Add("Spinach");
            items.Add("Tomatoes");
            items.Add("Bell peppers");
            items.Add("Onions");
            items.Add("Potatoes");
            items.Add("Cabbage");
            items.Add("Zucchini");
        }
       
        List<String> items =    new List<String>();

        ToleratingTyposHelper toleratingTyposHelper = new ToleratingTyposHelper();

        public Task<object> GetMatchingItemsAsync(SfAutocomplete source, AutocompleteFilterInfo filterInfo)
        {
            return PossibleItems(filterInfo.Text);
        }

        private async Task<object> PossibleItems(string query)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                return new List<string>();
            }


            // this.toleratingTyposHelper.

            List<String> filteredItems = new List<string>();

            foreach (var item in items)
            {
              var result =  AutoCompleteSearch(query, item);

                if(!string.IsNullOrWhiteSpace(result))
                {
                    filteredItems.Add(result);
                }
            }
            return filteredItems;
          //  return suggestions.ToList();
        }

        public new string AutoCompleteSearch(object value1, object value2)
        {
            var string1 = value1.ToString().ToLower();
            var string2 = value2.ToString().ToLower();
            if (string1.Length > 0 && string2.Length > 0)
                if (string1[0] != string2[0])
                    return null;
            var originalString1 = string.Empty;
            var originalString2 = string.Empty;

            if (string1.Length < string2.Length)
            {
                originalString2 = string2.Remove(string1.Length);
                originalString1 = string1;

            }

            if (string2.Length < string1.Length)
            {
                return null;
            }
            if (string2.Length == string1.Length)
            {
                originalString1 = string1;
                originalString2 = string2;
            }

            bool IsMatchSoundex = this.toleratingTyposHelper.ProcessOnSoundexAlgorithmn(originalString1) == this.toleratingTyposHelper.ProcessOnSoundexAlgorithmn(originalString2);
            int Distance = this.toleratingTyposHelper.GetDamerauLevenshteinDistance(originalString1, originalString2);

            if (IsMatchSoundex || Distance <= 2)
            {
                return value2.ToString();
            }
            return String.Empty;

        }
    }
}
