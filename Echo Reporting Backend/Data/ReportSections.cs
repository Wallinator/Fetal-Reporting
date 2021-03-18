using FetalReporting.Data.Results;
using System;
using System.Collections.Generic;

namespace FetalReporting.Data {
    public class ReportSections {
        public string Situs = "";
        public string SystemicVeins = "";
        public string Atria = "";
        public string AVValves = "";
        public string Ventricles = "";
        public string Outlets = "";
        public string GreatArteries = "";
        public string PulmonaryVeins = "";
        public string CoronaryArteries = "";
        public string Other = "";
        public string Conclusion = "";
        public string SignOff = "";

        internal ReportSections(StructuredReport sr) {
            Situs = OptionsToString(sr.ReportingOptions.Situs);
            SystemicVeins = OptionsToString(sr.ReportingOptions.SystemicVeins);
            SetAtriaText(sr);
            SetAVValvesText(sr);
            SetVentriclesText(sr);
            SetOutletsText(sr);
            SetGreatArteriesText(sr);
            PulmonaryVeins = OptionsToString(sr.ReportingOptions.PulmonaryVeins);
            SetOtherText(sr);
            if (!sr.ReportingOptions.NoPerciardialEffusion.Value) {
                Other += OptionsToString(sr.ReportingOptions.PerciardialEffusion);
            }
            Conclusion = Conclusions(sr.ReportingOptions.Conclusion.Value);
            SignOff = SignOffs(sr.PatientData.ReportingDoctor.Value);
        }

        private void SetAtriaText(StructuredReport sr) {
            Atria += BoolResultToString(sr.ReportingOptions.AtriaSize);
            Atria += OptionsToString(sr.ReportingOptions.DilatedAtriaLeft);
            Atria += OptionsToString(sr.ReportingOptions.DilatedAtriaRight);
            Atria += OptionsToString(sr.ReportingOptions.HypoplasticAtriaLeft);
            Atria += OptionsToString(sr.ReportingOptions.HypoplasticAtriaRight);
        }
        private void SetAVValvesText(StructuredReport sr) {
            AVValves += OptionsToString(sr.ReportingOptions.AVConnection);
            AVValves += OptionsToString(sr.ReportingOptions.MitralValve1,
                                        sr.ReportingOptions.MitralValve2,
                                        sr.ReportingOptions.MitralValve3);
            AVValves += BoolResultToString(sr.ReportingOptions.MitralValveAtresia);
            AVValves += OptionsToString(sr.ReportingOptions.LAVV1,
                                        sr.ReportingOptions.LAVV2,
                                        sr.ReportingOptions.LAVV3);
            AVValves += ResultToString(sr.Results["Mitral valve annulus"]);
            AVValves += OptionsToString(sr.ReportingOptions.TriscupidValve1,
                                        sr.ReportingOptions.TriscupidValve2,
                                        sr.ReportingOptions.TriscupidValve3);
            AVValves += BoolResultToString(sr.ReportingOptions.TriscupidValveAtresia);
            AVValves += OptionsToString(sr.ReportingOptions.RAVV1,
                                        sr.ReportingOptions.RAVV2);
            AVValves += ResultToString(sr.Results["Tricuspid valve annulus"]);
            AVValves += ResultToString(sr.Results["Tricuspid valve regurgitation peak velocity"]);
            AVValves += ResultToString(sr.Results["Tricuspid valve regurgitation peak gradient"]);
        }
        private void SetVentriclesText(StructuredReport sr) {
            Ventricles += OptionsToString(sr.ReportingOptions.VentricleFunction);
            Ventricles += BoolResultToString(sr.ReportingOptions.VentricularHypertrophy);
            Ventricles += ResultToString(sr.Results["Heart Rate"]);


            Ventricles += OptionsToString(sr.ReportingOptions.DilatedLV);
            Ventricles += OptionsToString(sr.ReportingOptions.HypertrophiedLV);
            Ventricles += OptionsToString(sr.ReportingOptions.ReducedLVFunction);
            Ventricles += OptionsToString(sr.ReportingOptions.HypoplasticLV);

            Ventricles += ResultToString(sr.Results["LV wall thickness"]);
            Ventricles += ResultToString(sr.Results["Septal wall thickness"]);
            Ventricles += ResultToString(sr.Results["LV EDD"]);

            Ventricles += ResultToString(sr.Results["LV length"]);
            Ventricles += ResultToString(sr.Results["LV IVRT"]);
            Ventricles += ResultToString(sr.Results["Myocardial performance index"]);

            Ventricles += OptionsToString(sr.ReportingOptions.DilatedRV);
            Ventricles += OptionsToString(sr.ReportingOptions.HypertrophiedRV);
            Ventricles += OptionsToString(sr.ReportingOptions.ReducedRVFunction);
            Ventricles += OptionsToString(sr.ReportingOptions.HypoplasticRV);

            Ventricles += ResultToString(sr.Results["RV wall thickness"]);
            Ventricles += ResultToString(sr.Results["RV EDD"]);
            Ventricles += ResultToString(sr.Results["RV length"]);

            Ventricles += BoolResultToString(sr.ReportingOptions.IntactVentricularSeptum);

            Ventricles += OptionsToString(sr.ReportingOptions.VSD1,
                                          sr.ReportingOptions.VSD2,
                                          sr.ReportingOptions.VSD3);
            Ventricles += BoolResultToString(sr.ReportingOptions.VSDDescription);
            Ventricles += ResultToString(sr.Results["Ventricular septal defect dimension"]);
            Ventricles += HighestResultToString(sr.Results["Cardiothoracic circumference ratio"], sr.Results["Cardiothoracic area ratio"]);
            Ventricles += ResultToString(sr.Results["Mechanical PR interval"]);
        }
        private void SetOutletsText(StructuredReport sr) {
            Outlets += OptionsToString(sr.ReportingOptions.Ventriculoarterial);
            Outlets += BoolResultToString(sr.ReportingOptions.OutflowTracts);

            Outlets += OptionsToString(sr.ReportingOptions.AorticValve1,
                                       sr.ReportingOptions.AorticValve2,
                                       sr.ReportingOptions.AorticValve3);

            Outlets += ResultToString(sr.Results["Aortic valve annulus"]);
            Outlets += ResultToString(sr.Results["Aortic valve peak velocity"]);
            Outlets += ResultToString(sr.Results["Aortic valve peak gradient"]);

            Outlets += BoolResultToString(sr.ReportingOptions.AortaVSDOvveride);
            Outlets += BoolResultToString(sr.ReportingOptions.LossSinotubularJunction);

            Outlets += OptionsToString(sr.ReportingOptions.PulmonaryValve1,
                                       sr.ReportingOptions.PulmonaryValve2,
                                       sr.ReportingOptions.PulmonaryValve3);

            Outlets += ResultToString(sr.Results["Pulmonary valve annulus"]);
            Outlets += ResultToString(sr.Results["Pulmonary valve peak velocity"]);
            Outlets += ResultToString(sr.Results["Pulmonary valve peak gradient"]);

        }
        private void SetGreatArteriesText(StructuredReport sr) {
            GreatArteries += OptionsToString(sr.ReportingOptions.LeftAorticArch1,
                                             sr.ReportingOptions.LeftAorticArch2);

            GreatArteries += ResultToString(sr.Results["Ascending aorta"]);
            GreatArteries += HighestResultToString(sr.Results["Aortic isthmus 3VV"], sr.Results["Aortic isthmus sagittal"]);

            GreatArteries += OptionsToString(sr.ReportingOptions.RightAorticArch1,
                                             sr.ReportingOptions.RightAorticArch2);

            GreatArteries += BoolResultToString(sr.ReportingOptions.BranchPulmonaryArteries);

            GreatArteries += ResultToString(sr.Results["Main pulmonary artery"]);
            GreatArteries += ResultToString(sr.Results["Right pulmonary artery"]);
            GreatArteries += ResultToString(sr.Results["Left pulmonary artery"]);

            GreatArteries += OptionsToString(sr.ReportingOptions.DuctusArteriosus1,
                                             sr.ReportingOptions.DuctusArteriosus2);

            GreatArteries += HighestResultToString(sr.Results["Ductus arteriosus 3VV"], sr.Results["Ductus arteriosus sagittal"]);
            GreatArteries += ResultToString(sr.Results["Ductus arteriosus peak velocity"]);
            GreatArteries += ResultToString(sr.Results["Descending aorta"]);
        }
        private void SetOtherText(StructuredReport sr) {
            Other = BoolResultToString(sr.ReportingOptions.NoPerciardialEffusion);
            Other = OptionsToString(sr.ReportingOptions.PerciardialEffusion);
            Other = BoolResultToString(sr.ReportingOptions.NoFetalHydrops);
            Other = BoolResultToString(sr.ReportingOptions.PleuralEffusion);
            Other = BoolResultToString(sr.ReportingOptions.Ascites);
        }
        private string BoolResultToString(BoolResult r) {
            string final = r.Value ? r.TrueText : r.FalseText;
            return final.Length == 0 ? final : final + ". ";
        }

        private string HighestResultToString(Result r1, Result r2) {
            Result main, second;
            if(Math.Abs(r1.ZScore) > Math.Abs(r2.ZScore)) {
                main = r1;
                second = r2;
            }
            else {
                main = r2;
                second = r1;
            }
            return ResultToString(main);
        }
        private string ResultToString(Result r, bool includeZScore = true, bool includeComment = true) {
            if (r.Empty) {
                return "";
            }
            else {
                string final = r.ReportString(includeZScore, includeComment);
                return final.Length == 0 ? final : final + ". ";
            }
        }
        private string OptionsToString(MultipleChoiceResult result1) {
            return OptionsToString(new List<MultipleChoiceResult>() { result1 });
        }
        private string OptionsToString(MultipleChoiceResult result1, MultipleChoiceResult result2) {
            return OptionsToString(new List<MultipleChoiceResult>() { result1, result2 });
        }
        private string OptionsToString(MultipleChoiceResult result1, MultipleChoiceResult result2, MultipleChoiceResult result3) {
            return OptionsToString(new List<MultipleChoiceResult>() { result1, result2, result3 });
        }
        private string OptionsToString(List<MultipleChoiceResult> list) {
            string final = "";
            foreach (var result in list) {
                if (result.Value.Length == 0) {
                    break;
                }
                else {
                    final += result.AsString();
                }
            }
            final = final.Trim();
            return final.Length == 0 ? final : final + ". ";
        }
        private string Conclusions(string type) {
            switch (type) {
                case "Normal":
                    return "Structurally and functionally normal fetal heart";
                case "Muscular VSD":
                    return "Functionally normal fetal heart with muscular ventricular septal defect";

                case "Perimembranous VSD":
                    return "Functionally normal fetal heart with perimembranous ventricular septal defect";

                case "Aberrant right subclavian artery":
                    return "Functionally normal fetal heart with anatomical variant of a left sided aortic arch with aberrant right subclavian artery. This is not a vascular ring. ";

                case "Right aortic arch with aberrant left subclavian artery":
                    return "Functionally normal fetal heart with anatomical variant of a right sided aortic arch with aberrant left subclavian artery. With a left sided ductus arteriosus this is the setup for a vascular ring.";
                default:
                    return "";
            }
        }
        private string SignOffs(string doctor) {
            switch (doctor) {
                case "Dr Paul Brooks":
                    return "Dr Paul Brooks MBBS (Hons) FRACP. Provider number 223704PX. LSPN 0008492";
                default:
                    return "";
            }
        }
    }
}
