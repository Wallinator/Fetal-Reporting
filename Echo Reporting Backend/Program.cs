using FetalReporting.Data;
using FetalReporting.Data.Results;
using System.Diagnostics;

namespace FetalReporting {
    internal static class Program {
        private static void Main() {
            var pd = new PatientData();
            pd.GestationalAge.Value = 22.42857143;
            pd.FemurLength.Value = 59;
            var list = ResultsHelper.GetEmptyResults(pd);
            foreach(var r in list) {
                if(r.ZScoreable) {
                    //System.Console.WriteLine(r.Name + ": " + r.Formula.GetZScore(3.2));
                    r.Formula.UseFL = true;
                    Debug.WriteLine(r.Formula.GetZScore(3.2));
                }
            }
        }
    }
}
