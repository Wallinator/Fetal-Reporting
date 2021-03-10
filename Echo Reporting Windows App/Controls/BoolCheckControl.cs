using FetalReporting.Data.Results;
using System;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class BoolCheckControl : UserControl {
        private readonly BoolResult Result;
        public BoolCheckControl(BoolResult result) {
            InitializeComponent();
            Result = result;
            ResultTitleLabel.Text = result.Name;
            ResultCheckBox.Text = result.OptionName;
            ResultCheckBox.Checked = result.Value;
        }

        private void ResultCheckBox_CheckedChanged(object sender, EventArgs e) {
            Result.Value = ResultCheckBox.Checked;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
