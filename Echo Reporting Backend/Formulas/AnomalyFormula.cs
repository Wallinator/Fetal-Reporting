using FetalReporting.Formulas;
using System;

namespace Echo_Reporting_Backend.Formulas {
    public class AnomalyFormula : Formula {
        private Constants constants;
        public override string ReportAnomaly(double measurement) {
            int bracket;
            if (measurement < 0.5) {
                bracket = 0;
            }
            else if (measurement < 0.55) {
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
        public override double GetZScore(double observed_y) {
            throw new NotImplementedException();
        }
        public override bool ZScoreable() => false;
        public static AnomalyFormula LVBiplaneEF() {
            return new AnomalyFormula(new Constants("left ventricular biplane EF", new[] { "Reduced", "Borderline", "Normal" }));
        }
        public static AnomalyFormula LV4ChamberEF() {
            return new AnomalyFormula(new Constants("left ventricular 4 chamber EF", new[] { "Reduced", "Borderline", "Normal" }));
        }

        private AnomalyFormula(Constants constants) {
            this.constants = constants;
        }
        private struct Constants {
            public string MeasurementName {
                get; set;
            }
            public string[] Anomalies {
                get; private set;
            }
            public bool AnomalyPrefix {
                get; private set;
            }
            public Constants(string name, string[] anomalies, bool prefix = true) {
                AnomalyPrefix = prefix;
                MeasurementName = name;
                Anomalies = anomalies;
            }
        }
    }
}
