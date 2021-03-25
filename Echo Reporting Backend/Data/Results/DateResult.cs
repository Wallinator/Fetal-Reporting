using System;
using System.Collections.Generic;

namespace FetalReporting.Data.Results {
    public class DateResult {
        public string Name {
            get;
            set;
        }
        public DateTime Value {
            get;
            set;
        }
        public DateResult(string name, DateTime value = new DateTime()) {
            Name = name;
            Value = value;
        }
        public string AsString() {
            return Value.Date.ToShortDateString();
        }
        public List<string> TableString() {
            return new List<string>() { Name, AsString() + "" + "" };
        }
    }
}
