using FetalReporting.Data;
using FetalReporting.Data.Results;
using FetalReporting.Formulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo_Reporting_Backend.Data.Results {
    public static class ResultsHelper {
        public static List<Result> GetEmptyResults(PatientData Pd) {
            var list = new List<Result>();
            list.Add(new Result("Aortic valve", "mm", SchneiderFormula.AorticValve(Pd, "Aortic valve")));
            list.Add(new Result("Pulmonary valve", "mm", SchneiderFormula.AorticValve(Pd, "Pulmonary valve")));
            list.Add(new Result("Ascending aorta", "mm", SchneiderFormula.AorticValve(Pd, "Ascending aorta")));
            list.Add(new Result("Main pulmonary artery", "mm", SchneiderFormula.AorticValve(Pd, "Main pulmonary artery")));
            list.Add(new Result("Tricuspid valve annulus", "mm", SchneiderFormula.AorticValve(Pd, "Tricuspid valve annulus")));
            list.Add(new Result("Mitral valve annulus", "mm", SchneiderFormula.AorticValve(Pd, "Mitral valve annulus")));
            list.Add(new Result("RV EDD", "mm", SchneiderFormula.AorticValve(Pd, "RV EDD")));
            list.Add(new Result("LV EDD", "mm", SchneiderFormula.AorticValve(Pd, "LV EDD")));
            list.Add(new Result("RV length", "mm", SchneiderFormula.AorticValve(Pd, "RV length")));
            list.Add(new Result("LV length", "mm", SchneiderFormula.AorticValve(Pd, "LV length")));
            list.Add(new Result("Descending aorta", "mm", SchneiderFormula.AorticValve(Pd, "Descending aorta")));
            list.Add(new Result("Right pulmonary artery", "mm", SchneiderFormula.AorticValve(Pd, "Right pulmonary artery")));
            list.Add(new Result("Left Pulmonary artery", "mm", SchneiderFormula.AorticValve(Pd, "Left Pulmonary artery")));
            list.Add(new Result("Ductus arteriosus sagittal", "mm", SchneiderFormula.AorticValve(Pd, "Ductus arteriosus sagittal")));

            list.Add(new Result("Ductus arteriosus 3VV", "mm", SchneiderFormula.AorticValve(Pd, "Ductus arteriosus 3VV")));
            list.Add(new Result("Aortic isthmus 3VV", "mm", SchneiderFormula.AorticValve(Pd, "Aortic isthmus 3VV")));
            list.Add(new Result("Aortic isthmus sagittal", "mm", SchneiderFormula.AorticValve(Pd, "Aortic isthmus sagittal")));

            list.Add(new Result("RV wall thickness", "mm", SchneiderFormula.AorticValve(Pd, "RV wall thickness")));
            list.Add(new Result("LV wall thickness", "mm", SchneiderFormula.AorticValve(Pd, "LV wall thickness")));
            list.Add(new Result("Septal wall thickness", "mm", SchneiderFormula.AorticValve(Pd, "Septal wall thickness")));

            list.Add(new Result("Aortic valve peak velocity", "cm/sec", SchneiderFormula.AorticValve(Pd, "Aortic valve peak velocity")));
            list.Add(new Result("Pulmonary valve peak velocity", "cm/sec", SchneiderFormula.AorticValve(Pd, "Pulmonary valve peak velocity")));
        }
    }
}
