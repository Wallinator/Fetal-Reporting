using FetalReporting.Data;
using FetalReporting.Data.Results;

namespace FetalReporting.Formulas {
    public abstract class Formula {
        public abstract double GetZScore(double measurement);
        public abstract string ReportAnomaly(double measurement);
        public abstract bool ZScoreable();
        public bool UseFL { get; set; } = false;

    }
}
