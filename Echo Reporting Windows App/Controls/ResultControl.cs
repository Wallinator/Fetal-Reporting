using FetalReporting.Data.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class ResultControl : UserControl {
        public delegate void Updated();
        public event Updated OnUpdate;
        private readonly Result Result = new Result("", "");
        private readonly MainForm Form;

        //public ResultControl(string name, string unitShortHand, double value = 0, bool showNotFoundError = true, Action OnUpdate = null) : this(new Result(name, unitShortHand, value: value), showNotFoundError, OnUpdate) {
        //}
        public ResultControl(Result result, bool showNotFoundError, MainForm form = null, ResultControl hook = null) {
            InitializeComponent();
            FLorGABox.Items.AddRange(new[] { "GA", "FL" });
            if(result.Formula != null) {
                FLorGABox.SelectedIndex = 0;
                FLorGABox.Visible = result.Formula.HasFLGASwitch();
            }
            else {
                FLorGABox.Visible = false;
            }
            FLorGABox.Enabled = FLorGABox.Visible;
            if(hook != null) {
                hook.OnUpdate += UpdateValue;
            }
            this.Result = result;
            this.Form = form;
            if (result.AltName.Length != 0) {
                ResultTitleLabel.Text = result.AltName;
            }
            else {
                ResultTitleLabel.Text = result.Name;
            }
            ResultUnitLabel.Text = result.UnitShorthand;
            ZScoreLabel.Text = "";
            Anomaly.Text = "";

            if(Form.ResultControls.TryGetValue(Result.Name, out var x)) {
                x.Add(this);
            }
            else {
                Form.ResultControls.Add(Result.Name, new List<ResultControl>() { this });
            }
            UpdateValue(result.Value);
        }

        private void ValidateValue(object sender, EventArgs e) {
            try {
                double value = double.Parse(ResultValueTextBox.Text.Trim());
                errorProvider1.Clear();
                errorProvider1.SetError(ResultUnitLabel, "");
                Result.Empty = false;
                UpdateValue(value);
            }
            catch (Exception) {
                errorProvider1.SetError(ResultUnitLabel, "Not a decimal value.");
                Result.Empty = true;
                UpdateValue();
            }
        }
        public void UpdateValue() {
            UpdateValue(Result.Value, true);
        }
        public void UpdateValue(bool updateClones) {
            UpdateValue(Result.Value, updateClones);
        }
        private void UpdateValue(double value, bool updateClones = true) {
            Result.Value = value;
            if(updateClones) {
                foreach(var r in Form.ResultControls[Result.Name]) {
                    r.UpdateValue(false);
                }
                return;
            }
            Anomaly.Text = Result.AnomalyText;
            if (Result.Empty) {
                ResultValueTextBox.Text = "";
            }
            else {
                if (Result.UnitShorthand.Equals("mmHg") ||
                    Result.UnitShorthand.Equals("cm/s") ||
                    Result.UnitShorthand.Equals("m/s")) {
                    ResultValueTextBox.Text = Math.Round(value, 1).ToString();
                }
                else {
                    ResultValueTextBox.Text = Math.Round(value, 3).ToString();
                }
            }
            if (Result.ZScoreable) {
                if (Result.Empty) {
                    ZScoreLabel.Text = "Z Score: N/A.";
                }
                else {
                    ZScoreLabel.Text = "Z Score: " + Math.Round(Result.ZScore, 2).ToString();
                }
            }

            if(Result.Formula != null) {
                if(Result.Formula.HasFLGASwitch()) {
                    FLorGABox.SelectedIndex = Result.Formula.UseFL ? 1 : 0;
                }
            }
            OnUpdate?.Invoke();
        }
        private void TextBoxKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ValidateValue(sender, e);
                e.Handled = true;
            }
        }

        private void ResultControl_Load(object sender, EventArgs e) {

        }

        private void FLorGABox_SelectedIndexChanged(object sender, EventArgs e) {
            Debug.WriteLine("beepbe bpep");
            if(Result.Formula != null) {
                Result.Formula.UseFL = FLorGABox.SelectedIndex != 0;
                UpdateValue();
                Debug.WriteLine(Result.Formula.UseFL);
            }

        }
    }
}
