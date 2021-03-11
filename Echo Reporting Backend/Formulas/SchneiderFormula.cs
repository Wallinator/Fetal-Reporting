using FetalReporting.Data;
using System;

namespace FetalReporting.Formulas {
    public class SchneiderFormula : Formula {
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

            double predCardDim;
            if (UseFL) {
                predCardDim = constants.FLMultiplier * Math.Log(constants.Pd.FemurLength.Value/10) + constants.FLIntercept;
                return (Math.Log(measurement / 10) - predCardDim) / constants.FLMSE;
            }
            else {
                predCardDim = constants.GAMultiplier * Math.Log(constants.Pd.GestationalAge.Value) + constants.GAIntercept;
                return (Math.Log(measurement / 10) - predCardDim) / constants.GAMSE;
            }
        }
        public override bool ZScoreable() => constants.Pd.PatientAge.Value >= 3;
        public static SchneiderFormula AorticValve(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.274, 0.8972, 0.1103, -5.019, 1.263, 0.1282, pd, name, new[] { "a" }));
        }
        public static SchneiderFormula PulmonaryValve(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.148, 0.9437, 0.111, -5.114, 1.352, 0.1208, pd, name, new[] { "" }));
        }
        public static SchneiderFormula AscendingAorta(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.141, 0.8968, 0.1225, -4.886, 1.261, 0.133, pd, name, new[] { "" }));
        }
        public static SchneiderFormula MainPulmonaryArtery(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.072, 0.9465, 0.1645, -5.025, 1.347, 0.157, pd, name, new[] { "" }));
        }
        public static SchneiderFormula TricuspidValveAnnulus(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-1.735, 0.9937, 0.1386, -4.766, 1.395, 0.1394, pd, name, new[] { "" }));
        }
        public static SchneiderFormula MitralValveAnnulus(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-1.55, 0.8473, 0.1202, -4.084, 1.173, 0.1315, pd, name, new[] { "" }));
        }
        public static SchneiderFormula RVEDD(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-1.485, 0.9625, 0.1435, -4.455, 1.363, 0.1442, pd, name, new[] { "" }));
        }
        public static SchneiderFormula LVEDD(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-1.516, 0.9554, 0.1403, -4.292, 1.298, 0.156, pd, name, new[] { "" }));
        }
        public static SchneiderFormula RVLength(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-0.8249, 0.9305, 0.152, -3.566, 1.277, 0.1658, pd, name, new[] { "" }));
        }
        public static SchneiderFormula LVLength(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-0.6751, 0.8772, 0.1216, -3.231, 1.193, 0.1376, pd, name, new[] { "" }));
        }
        public static SchneiderFormula DescendingAorta(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.368, 0.9415, 0.1224, -5.365, 1.36, 0.1216, pd, name, new[] { "" }));
        }
        public static SchneiderFormula RightPulmonaryArtery(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.623, 0.8685, 0.178, -5.307, 1.23, 0.1802, pd, name, new[] { "" }));
        }
        public static SchneiderFormula LeftPulmonaryArtery(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.785, 0.9219, 0.1935, -5.39, 1.231, 0.1966, pd, name, new[] { "" }));
        }
        public static SchneiderFormula DuctusArteriosusSagittal(PatientData pd, string name) {
            return new SchneiderFormula(new Constants(-2.251, 0.737, 0.183, -4.44, 1.013, 0.1913, pd, name, new[] { "" }));
        }
        private SchneiderFormula(Constants constants) {
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
            public double GAMSE {
                get; private set;
            }
            public double GAMultiplier {
                get; private set;
            }
            public double GAIntercept {
                get; private set;
            }
            public double FLMSE {
                get; private set;
            }
            public double FLMultiplier {
                get; private set;
            }
            public double FLIntercept {
                get; private set;
            }
            public Constants(double FLintercept, double FLmultiplier, double FLmse, double GAintercept, double GAmultiplier, double GAmse, PatientData pd, string name, string[] anomalies, bool prefix = true) {
                AnomalyPrefix = prefix;
                MeasurementName = name;
                Anomalies = anomalies;
                Pd = pd;
                GAMSE = GAmse;
                GAMultiplier = GAmultiplier;
                GAIntercept = GAintercept;
                FLMSE = FLmse;
                FLMultiplier = FLmultiplier;
                FLIntercept = FLintercept;
            }
        }
    }
}
