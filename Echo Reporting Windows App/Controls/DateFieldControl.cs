using FetalReporting.Data.Results;
using System;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class DateFieldControl : UserControl {
        private readonly StringResult Result;
        public DateFieldControl(StringResult result) {
            InitializeComponent();
            Result = result;
            ResultTitleLabel.Text = result.Name;
            ResultValueTextBox.Text = result.Value;
        }
        private void ResultValueTextBox_TextChanged(object sender, EventArgs e) {
            Result.Value = ResultValueTextBox.Text;
        }
    }
}
