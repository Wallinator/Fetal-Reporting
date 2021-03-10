using System.Collections.Generic;

namespace FetalReporting.Data.Results {
    public class MultipleChoiceResult : StringResult {
        public bool MultiSelect;
        public string DisplayName;
        public List<string> Options;
        public MultipleChoiceResult(string name, List<string> options, string postfix = "", bool multiselect = false, string displayname = "") : base(name, options[0], postfix) {
            DisplayName = displayname;
            MultiSelect = multiselect;
            Options = options;
        }
    }
}
