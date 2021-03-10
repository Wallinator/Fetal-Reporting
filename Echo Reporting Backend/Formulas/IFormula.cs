namespace FetalReporting.Formulas {
    public interface IFormula {
        double GetZScore(double measurement);
        string ReportAnomaly(double measurement);
        bool ZScoreable();
    }
}
