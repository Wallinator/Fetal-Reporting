using FetalReporting.Data;
using System;

namespace FetalReporting.Formulas {
    public class PasquiniFormula : IFormula {
        private Constants constants;
        public string ReportAnomaly(double measurement) {
            double ZScore = GetZScore(measurement);
            int bracket;
            if (ZScore < -2) {
                bracket = 0;
            }
            else if (ZScore <= 2) {
                bracket = 1;
            }
            else {
                bracket = 2;
            }

            if (constants.AnomalyPrefix && constants.Anomalies[bracket].Length != 0) {
                return constants.Anomalies[bracket] + " " + constants.MeasurementName;
            }
            else {
                return constants.Anomalies[bracket];
            }
        }
        public double GetZScore(double measurement) {
            double predCardDim = constants.Multiplier * Math.Log(constants.Pd.GestationalAge.Value) + constants.Intercept;
            return (Math.Log(measurement) - predCardDim) / constants.MSE;
        }
        public bool ZScoreable() => constants.Pd.PatientAge.Value >= 3;
        public static PasquiniFormula MVDecelTime(PatientData pd, string name) {
            double[] averages = { 145, 157, 172 };
            double[] sds = { 18, 19, 22 };
            return new PasquiniFormula(new Constants(averages, sds, pd, name, new[] { "Shortened", "", "Prolonged" }));
        }
        public static PasquiniFormula LVIVRT(PatientData pd, string name) {
            double[] averages = { 62, 67, 74 };
            double[] sds = { 10, 10, 13 };
            return new PasquiniFormula(new Constants(averages, sds, pd, name, new[] { "Shortened", "Normal", "Prolonged" }));
        }
        private PasquiniFormula(Constants constants) {
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
            public double MSE {
                get; private set;
            }
            public double Multiplier {
                get; private set;
            }
            public double Intercept {
                get; private set;
            }
            public Constants(double intercept, double multiplier, double mse, PatientData pd, string name, string[] anomalies, bool prefix = true) {
                AnomalyPrefix = prefix;
                MeasurementName = name;
                Anomalies = anomalies;
                Pd = pd;
                MSE = mse;
                Multiplier = multiplier;
                Intercept = intercept;
            }
        }
    }
}
