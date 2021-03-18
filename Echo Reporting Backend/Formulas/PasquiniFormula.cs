using FetalReporting.Data;
using System;

namespace FetalReporting.Formulas {
    public class PasquiniFormula : Formula {
        private Constants constants;
        public override string ReportAnomaly(double measurement) {
            double ZScore = GetZScore(measurement);
            int bracket;
            if (ZScore < -2) {
                bracket = 0;
            }
            else if(ZScore <= 2) {
                bracket = 1;
            }
            else if(ZScore <= 3) {
                bracket = 2;
            }
            else if(ZScore <= 4) {
                bracket = 3;
            }
            else {
                bracket = 4;
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
                predCardDim = constants.FLMultiplier * Math.Log(constants.Pd.FemurLength.Value) + constants.FLIntercept;
                return (Math.Log(measurement) - predCardDim) / constants.FLMSE;
            }
            else {
                predCardDim = constants.GAMultiplier * Math.Log(constants.Pd.GestationalAge.Value) + constants.GAIntercept;
                return (Math.Log(measurement) - predCardDim) / constants.GAMSE;
            }
        }
        public override bool HasFLGASwitch() => true;
        public override bool ZScoreable() => true;
        public static PasquiniFormula DuctusArteriosus3VV(PatientData pd, string name) {
            return new PasquiniFormula(new Constants(-3.009, 1.09, 0.179, -3.359, 1.396, 0.176, pd, "ductus arteriosus", new[] { "Hypoplastic", "Normal", "Mildly dilated", "Moderately dilated", "Severely dilated" }));
        }
        public static PasquiniFormula AorticIsthmus3VV(PatientData pd, string name) {
            return new PasquiniFormula(new Constants(-2.56, 0.967, 0.163, -2.822, 1.224, 0.164, pd, "aortic isthmus", new[] { "Hypoplastic", "Normal", "Mildly dilated", "Moderately dilated", "Severely dilated" }));
        }
        public static PasquiniFormula AorticIsthmusSagittal(PatientData pd, string name) {
            return new PasquiniFormula(new Constants(-2.261, 0.879, 0.181, -2.489, 1.109, 0.182, pd, "aortic isthmus", new[] { "Hypoplastic", "Normal", "Mildly dilated", "Moderately dilated", "Severely dilated" }));
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
