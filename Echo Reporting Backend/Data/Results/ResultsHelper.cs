using FetalReporting.Data;
using FetalReporting.Data.Results;
using FetalReporting.Formulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetalReporting.Data.Results {
    public static class ResultsHelper {
        public static List<Result> GetEmptyResults(PatientData Pd) {
            var list = new List<Result>();
            list.Add(new Result("Aortic valve annulus", "mm", SchneiderFormula.AorticValve(Pd, "Aortic valve")));
            list.Add(new Result("Pulmonary valve annulus", "mm", SchneiderFormula.PulmonaryValve(Pd, "Pulmonary valve")));
            list.Add(new Result("Ascending aorta", "mm", SchneiderFormula.AscendingAorta(Pd, "Ascending aorta")));
            list.Add(new Result("Main pulmonary artery", "mm", SchneiderFormula.MainPulmonaryArtery(Pd, "Main pulmonary artery")));
            list.Add(new Result("Tricuspid valve annulus", "mm", SchneiderFormula.TricuspidValveAnnulus(Pd, "Tricuspid valve annulus")));
            list.Add(new Result("Mitral valve annulus", "mm", SchneiderFormula.MitralValveAnnulus(Pd, "Mitral valve annulus")));
            list.Add(new Result("RV EDD", "mm", SchneiderFormula.RVEDD(Pd, "RV EDD")));
            list.Add(new Result("LV EDD", "mm", SchneiderFormula.LVEDD(Pd, "LV EDD")));
            list.Add(new Result("RV length", "mm", SchneiderFormula.RVLength(Pd, "RV length")));
            list.Add(new Result("LV length", "mm", SchneiderFormula.LVLength(Pd, "LV length")));
            list.Add(new Result("Descending aorta", "mm", SchneiderFormula.DescendingAorta(Pd, "Descending aorta")));
            list.Add(new Result("Right pulmonary artery", "mm", SchneiderFormula.RightPulmonaryArtery(Pd, "Right pulmonary artery")));
            list.Add(new Result("Left pulmonary artery", "mm", SchneiderFormula.LeftPulmonaryArtery(Pd, "Left Pulmonary artery")));
            list.Add(new Result("Ductus arteriosus sagittal", "mm", SchneiderFormula.DuctusArteriosusSagittal(Pd, "Ductus arteriosus sagittal")));

            list.Add(new Result("Ductus arteriosus 3VV", "mm", PasquiniFormula.DuctusArteriosus3VV(Pd, "Ductus arteriosus 3VV")));
            list.Add(new Result("Aortic isthmus 3VV", "mm", PasquiniFormula.AorticIsthmus3VV(Pd, "Aortic isthmus 3VV")));
            list.Add(new Result("Aortic isthmus sagittal", "mm", PasquiniFormula.AorticIsthmusSagittal(Pd, "Aortic isthmus sagittal")));

            list.Add(new Result("RV wall thickness", "mm", RochaFormula.RVWallThickness(Pd, "RV wall thickness")));
            list.Add(new Result("LV wall thickness", "mm", RochaFormula.LVWallThickness(Pd, "LV wall thickness")));
            list.Add(new Result("Septal wall thickness", "mm", RochaFormula.SeptalWallThickness(Pd, "Septal wall thickness")));

            list.Add(new Result("Aortic valve peak velocity", "cm/sec", MaoFormula.AorticValveVelocity(Pd, "Aortic valve peak velocity")));
            list.Add(new Result("Pulmonary valve peak velocity", "cm/sec", MaoFormula.PulmonaryValveVelocity(Pd, "Pulmonary valve peak velocity")));

            list.Add(new Result("Heart Rate", "bpm", AnomalyFormula.HeartRate()));
            list.Add(new Result("Myocardial performance index", "", AnomalyFormula.MyocardialPerformanceIndex()));
            list.Add(new Result("Cardiothoracic circumference ratio", "", AnomalyFormula.CardiothoracicCircumferenceRatio()));
            list.Add(new Result("Cardiothoracic area ratio", "", AnomalyFormula.CardiothoracicAreaRatio()));
            list.Add(new Result("Ductus arteriosus peak velocity", "cm/s", AnomalyFormula.DuctusArteriosusPeakVelocity()));

            list.Add(new Result("Tricuspid valve regurgitation peak velocity", "cm/s"));
            list.Add(new Result("LV IVRT", "ms"));
            list.Add(new Result("Mechanical PR interval", "ms"));
            list.Add(new Result("Ventricular septal defect dimension", "mm"));

            list.Add(new Result("Tricuspid valve regurgitation peak gradient", "mmHg"));
            list.Add(new Result("Pulmonary valve peak gradient", "mmHg"));
            list.Add(new Result("Aortic valve peak gradient", "mmHg"));
            return list;
        }
    }
}
