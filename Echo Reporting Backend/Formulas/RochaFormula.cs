using FetalReporting.Data;
using System;
namespace FetalReporting.Formulas {
    public class RochaFormula : Formula {
        private Constants constants;
        public override string ReportAnomaly(double measurement) {
            double ZScore = GetZScore(measurement);
            int bracket;
            if (ZScore <= 2) {
                bracket = 0;
            }
            else if(ZScore <= 3) {
                bracket = 1;
            }
            else if(ZScore <= 4) {
                bracket = 2;
            }
            else {
                bracket = 3;
            }

            if (constants.AnomalyPrefix && constants.Anomalies[bracket].Length != 0) {
                return constants.Anomalies[bracket] + " " + constants.MeasurementName;
            }
            else {
                return constants.Anomalies[bracket];
            }
        }
        public override bool HasFLGASwitch() => false;
        public override double GetZScore(double measurement) {

            return (measurement - (constants.Multiplier * constants.Pd.GestationalAge.Value + constants.Intercept))/constants.Divisor;
        }
        public override bool ZScoreable() => true;

        public static RochaFormula RVWallThickness(PatientData pd, string name) {
            return new RochaFormula(new Constants(-1.001, 0.109, 0.4, pd, "RV wall thickness", new string[] { "Normal RV wall thickness", "Mild RV free wall hypertrophy", "Moderate RV free wall hypertrophy", "Severe RV free wall hypertrophy" }, false));
        }
        public static RochaFormula LVWallThickness(PatientData pd, string name) {
            return new RochaFormula(new Constants(-1.366, 0.12, 0.43, pd, "LV wall thickness", new string[] { "Normal LV wall thickness", "Mild LV free wall hypertrophy", "Moderate LV free wall hypertrophy", "Severe LV free wall hypertrophy" }, false));
        }
        public static RochaFormula SeptalWallThickness(PatientData pd, string name) {
            return new RochaFormula(new Constants(-1.113, 0.107, 0.4, pd, "septal wall thickness", new string[] { "Normal septal wall thickness", "Mild septal hypertrophy", "Moderate septal hypertrophy", "Severe septal hypertrophy" }, false));
        }
        private RochaFormula(Constants constants) {
            this.constants = constants;
        }
        private struct Constants {
            public PatientData Pd {
                get; private set;
            }
            public string MeasurementName {
                get; set;
            }
            public string[] Anomalies {
                get; private set;
            }
            public bool AnomalyPrefix {
                get; private set;
            }
            public double Divisor {
                get; private set;
            }
            public double Multiplier {
                get; private set;
            }
            public double Intercept {
                get; private set;
            }
            public Constants(double intercept, double multiplier, double divisor, PatientData pd, string name, string[] anomalies, bool prefix = true) {
                AnomalyPrefix = prefix;
                MeasurementName = name;
                Anomalies = anomalies;
                Pd = pd;
                Divisor = divisor;
                Multiplier = multiplier;
                Intercept = intercept;
            }
        }
    }
}
