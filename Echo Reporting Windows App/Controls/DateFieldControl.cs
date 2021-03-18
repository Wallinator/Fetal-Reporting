using FetalReporting.Data.Results;
using System;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class DateFieldControl : UserControl {
        public  DateResult Result;
        private DatePickerPopupForm d;
        private Action OnUpdate;
        public DateFieldControl(DateResult result, Action onUpdate = null) {
            InitializeComponent();
            OnUpdate = onUpdate;
            d = new DatePickerPopupForm(this);
            d.TopMost = true;
            Result = result;
            ResultTitleLabel.Text = result.Name;
            UpdateText();
        }
        private void ResultValueTextBox_Click(object sender, EventArgs e) {
            d.ShowDialog();
        }

        private void DateFieldControl_Load(object sender, EventArgs e) {

        }
        public void UpdateText() {
            OnUpdate?.Invoke();
            ResultValueTextBox.Text = Result.Value.ToShortDateString();
        }
    }
}
