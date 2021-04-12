using FetalReporting.Data.Results;
using System;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class DateFieldControl : UserControl {
        public  DateResult Result;
        //private DatePickerPopupForm d;
        private Action OnUpdate;
        public DateFieldControl(DateResult result, Action onUpdate = null) {
            InitializeComponent();
            OnUpdate = onUpdate;
            //d = new DatePickerPopupForm(this);
            //d.TopMost = true;
            Result = result;
            ResultTitleLabel.Text = result.Name;
            ValidateValue(null, null);
        }
        public void ValidateValue(object sender, EventArgs e) {
            DateTime dt;
            var valid = DateTime.TryParse(ResultValueTextBox.Text.Trim(), out dt);
            if (valid) {
                Result.Value = dt;
            }
            ResultValueTextBox.Text = Result.Value.ToShortDateString();
            OnUpdate?.Invoke();
        }
    }
}
