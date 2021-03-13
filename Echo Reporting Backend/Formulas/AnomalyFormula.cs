using FetalReporting.Formulas;
using System;

namespace FetalReporting.Formulas {
    public class AnomalyFormula : Formula {
        private Constants constants;
        public override string ReportAnomaly(double measurement) {
            int bracket;
            if (measurement <= constants.Limit) {
                bracket = 0;
            }
            else {
                bracket = 1;
            }

            if (constants.AnomalyPrefix && constants.Anomalies[bracket].Length != 0) {
                return constants.Anomalies[bracket] + " " + constants.MeasurementName;
            }
            else {
                return constants.Anomalies[bracket];
            }
        }
        public override double GetZScore(double observed_y) {
            throw new NotImplementedException();
        }
        public override bool ZScoreable() => false;
        public static AnomalyFormula HeartRate() {
            return new AnomalyFormula(new Constants("Heart Rate", 99.999, new[] { "Fetal bradycardia", "Normal fetal heart rate" }, false));
        }
        public static AnomalyFormula MyocardialPerformanceIndex() {
            return new AnomalyFormula(new Constants("Myocardial performance index", 0.5, new[] { "Normal", "Increased" }));
        }
        public static AnomalyFormula CardiothoracicCircumferenceRatio() {
            return new AnomalyFormula(new Constants("Cardiothoracic circumference ratio", 0.6, new[] { "Normal Cardiothoracic circumference ratio", "Cardiomegaly" }, false));
        }
        public static AnomalyFormula CardiothoracicAreaRatio() {
            return new AnomalyFormula(new Constants("Cardiothoracic area ratio", 0.35, new[] { "Normal Cardiothoracic area ratio", "Cardiomegaly" }, false));
        }
        public static AnomalyFormula DuctusArteriosusPeakVelocity() {
            return new AnomalyFormula(new Constants("Ductus arteriosus velocity", 150.0, new[] { "Normal", "Increased" }));
        }

        private AnomalyFormula(Constants constants) {
            this.constants = constants;
        }
        private struct Constants {
            public string MeasurementName {
                get; set;
            }
            public double Limit {
                get; set;
            }
            public string[] Anomalies {
                get; private set;
            }
            public bool AnomalyPrefix {
                get; private set;
            }
            public Constants(string name, double limit, string[] anomalies, bool prefix = true) {
                AnomalyPrefix = prefix;
                MeasurementName = name;
                Limit = limit;
                Anomalies = anomalies;
            }
        }
    }
}
