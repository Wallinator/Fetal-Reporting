using FetalReporting.Data;
using System;

namespace FetalReporting.Formulas {
    public class MaoFormula : Formula {
        private Constants constants;
        public override string ReportAnomaly(double measurement) {
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
        public override double GetZScore(double measurement) {
            return (measurement - (constants.Multiplier1 * constants.Pd.GestationalAge.Value + constants.Intercept1))/(constants.Multiplier2 * constants.Pd.GestationalAge.Value + constants.Intercept2);
        }
        public override bool ZScoreable() => constants.Pd.PatientAge.Value >= 3;
        public static MaoFormula AorticValveVelocity(PatientData pd, string name) {
            return new MaoFormula(new Constants(38.089, 1.463, 4.227, 0.239, pd, name, new string[] { } ));
        }
        public static MaoFormula PulmonaryValveVelocity(PatientData pd, string name) {
            return new MaoFormula(new Constants(38.089, 1.463, 4.227, 0.239, pd, name, new string[] { }));
        }
        private MaoFormula(Constants constants) {
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
            public double Multiplier1 {
                get; private set;
            }
            public double Intercept1 {
                get; private set;
            }
            public double Multiplier2 {
                get; private set;
            }
            public double Intercept2 {
                get; private set;
            }
            public Constants(double intercept1, double multiplier1, double intercept2, double multiplier2, PatientData pd, string name, string[] anomalies, bool prefix = true) {
                AnomalyPrefix = prefix;
                MeasurementName = name;
                Anomalies = anomalies;
                Pd = pd;
                Multiplier1 = multiplier1;
                Intercept1 = intercept1;
                Multiplier2 = multiplier2;
                Intercept2 = intercept2;
            }
        }
    }
}
