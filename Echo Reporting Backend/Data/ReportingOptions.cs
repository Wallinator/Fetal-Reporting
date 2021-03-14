using FetalReporting.Data.Results;
using System.Collections.Generic;

namespace FetalReporting.Data {
    public class ReportingOptions {
        //Situs
        public MultipleChoiceResult Situs = new MultipleChoiceResult("", new List<string>() {   "Usual atrial arrangement (situs solitus)",
                                                                                                "Mirror image arrangement (situs inversus)",
                                                                                                "Left atrial isomerism",
                                                                                                "Right atrial isomerism",
                                                                                                "Situs ambiguous",
                                                                                                "Not evaluated" });

        //Systemic Veins
        public MultipleChoiceResult SystemicVeins = new MultipleChoiceResult("", new List<string>() {   "Normal systemic venous connections",
                                                                                                        "Bilateral SVC's with LSVC to coronary sinus",
                                                                                                        "Isolated left SVC draining to the coronary sinus",
                                                                                                        "Interrupted IVC with azygous continuation",
                                                                                                        "Not evaluated" });

        //Atria
        public BoolResult AtriaSize = new BoolResult("Normally sized atria", "", true);

        public MultipleChoiceResult DilatedAtriaLeft = new MultipleChoiceResult("", new List<string>() {   "",
                                                                                                    "Mildly",
                                                                                                    "Moderately",
                                                                                                    "Severely" }, "dilated left atrium");

        public MultipleChoiceResult DilatedAtriaRight = new MultipleChoiceResult("", new List<string>() {  "",
                                                                                                    "Mildly",
                                                                                                    "Moderately",
                                                                                                    "Severely" }, "dilated right atrium");

        public MultipleChoiceResult HypoplasticAtriaLeft = new MultipleChoiceResult("", new List<string>() {   "",
                                                                                                    "Mildly",
                                                                                                    "Moderately",
                                                                                                    "Severely" }, "hypoplastic left atrium");

        public MultipleChoiceResult HypoplasticAtriaRight = new MultipleChoiceResult("", new List<string>() {  "",
                                                                                                    "Mildly",
                                                                                                    "Moderately",
                                                                                                    "Severely" }, "hypoplastic right atrium");


        //AV Valves
        public MultipleChoiceResult AVConnection = new MultipleChoiceResult("", new List<string>() {   "Atrioventricular concordance",
                                                                                                            "Atrioventricular discordance" });


        public MultipleChoiceResult MitralValve1 = new MultipleChoiceResult("", new List<string>() {"Normal mitral valve",
                                                                                                    "",
                                                                                                    "Cleft in the anterior leaflet of the mitral valve",
                                                                                                    "Prolapse of the anterior leaflet of the mitral valve"});

        public MultipleChoiceResult MitralValve2 = new MultipleChoiceResult(" with", new List<string>() {"no regurgitation",
                                                                                                        "trivial regurgitation",
                                                                                                        "mild regurgitation",
                                                                                                        "moderate regurgitation",
                                                                                                        "severe regurgitation" });

        public MultipleChoiceResult MitralValve3 = new MultipleChoiceResult(" and", new List<string>() {    "",
                                                                                                            "no stenosis",
                                                                                                            "mild stenosis",
                                                                                                            "moderate stenosis",
                                                                                                            "severe stenosis" });
        public BoolResult MitralValveAtresia = new BoolResult("Mitral valve atresia");


        public MultipleChoiceResult TriscupidValve1 = new MultipleChoiceResult("", new List<string>() {     "Normal tricuspid valve",
                                                                                                            "",
                                                                                                            "Tethered tricuspid valve septal leaflet",
                                                                                                            "Dysplastic tricuspid valve leaflets"});

        public MultipleChoiceResult TriscupidValve2 = new MultipleChoiceResult(" with", new List<string>() {  "no regurgitation",
                                                                                                            "trivial regurgitation",
                                                                                                            "mild regurgitation",
                                                                                                            "moderate regurgitation",
                                                                                                            "severe regurgitation" });

        public MultipleChoiceResult TriscupidValve3 = new MultipleChoiceResult(" and", new List<string>() { "",
                                                                                                            "no stenosis",
                                                                                                            "mild stenosis",
                                                                                                            "moderate stenosis",
                                                                                                            "severe stenosis" });
        public BoolResult TriscupidValveAtresia = new BoolResult("Triscupid valve atresia");




        public MultipleChoiceResult LAVV1 = new MultipleChoiceResult("", new List<string>() {   "",
                                                                                                "Common atrioventricular valve",
                                                                                                "Partial AVSD with separate AV valve orifices"});

        public MultipleChoiceResult LAVV2 = new MultipleChoiceResult(" with", new List<string>() {   "no left AV valve regurgitation",
                                                                                                    "trivial left AV valve regurgitation",
                                                                                                    "mild left AV valve regurgitation",
                                                                                                    "moderate left AV valve regurgitation",
                                                                                                    "severe left AV valve regurgitation" });

        public MultipleChoiceResult LAVV3 = new MultipleChoiceResult(" and", new List<string>() {    "no left AV valve stenosis",
                                                                                                    "mild left AV valve stenosis",
                                                                                                    "moderate left AV valve stenosis",
                                                                                                    "severe left AV valve stenosis" });

        public MultipleChoiceResult RAVV1 = new MultipleChoiceResult("", new List<string>() {   "",
                                                                                                "No right AV valve regurgitation",
                                                                                                "Trivial right AV valve regurgitation",
                                                                                                "Mild right AV valve regurgitation",
                                                                                                "Moderate right AV valve regurgitation",
                                                                                                "Severe right AV valve regurgitation" });

        public MultipleChoiceResult RAVV2 = new MultipleChoiceResult(" and", new List<string>() {    "no right AV valve stenosis",
                                                                                                    "mild right AV valve stenosis",
                                                                                                    "moderate right AV valve stenosis",
                                                                                                    "severe right AV valve stenosis" });

        //Ventricles

        public MultipleChoiceResult VentricleFunction = new MultipleChoiceResult("", new List<string>() { "Normal biventricular size and function",
                                                                                                            "Normal LV function",
                                                                                                            "Normal RV function",
                                                                                                            "RV larger than LV"});
        public BoolResult VentricularHypertrophy = new BoolResult("No ventricular hypertrophy");


        public MultipleChoiceResult DilatedLV = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "dilated LV");

        public MultipleChoiceResult HypertrophiedLV = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "hypertrophied LV");

        public MultipleChoiceResult ReducedLVFunction = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "reduced LV function");

        public MultipleChoiceResult HypoplasticLV = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "hypoplastic LV");

        public MultipleChoiceResult DilatedRV = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "dilated RV");

        public MultipleChoiceResult HypertrophiedRV = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "hypertrophied RV");

        public MultipleChoiceResult ReducedRVFunction = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "reduced RV function");

        public MultipleChoiceResult HypoplasticRV = new MultipleChoiceResult("", new List<string>() { "",
                                                                                            "Mildly",
                                                                                            "Moderately",
                                                                                            "Severely" }, "hypoplastic RV");


        public BoolResult IntactVentricularSeptum = new BoolResult("Intact ventricular septum", "", true);


        public MultipleChoiceResult VSD1 = new MultipleChoiceResult("", new List<string>() {"",
                                                                                            "Small",
                                                                                            "Moderate",
                                                                                            "Large" });

        public MultipleChoiceResult VSD2 = new MultipleChoiceResult("", new List<string>() {    "perimembranous VSD",
                                                                                                "anterior muscular VSD",
                                                                                                "apical muscular VSD",
                                                                                                "inlet muscular VSD",
                                                                                                "outlet VSD",
                                                                                                "doubly committed VSD" });

        public MultipleChoiceResult VSD3 = new MultipleChoiceResult(" with", new List<string>() {"L-R shunt",
                                                                                                "R-L shunt",
                                                                                                "bidirectional shunt" });

        public BoolResult VSDDescription = new BoolResult("PMVSD partly closed", "", false, "", "VSD partly closed by a pouch of tricuspid valvular aneurysmal tissue.");

        //Outlets

        public MultipleChoiceResult Ventriculoarterial = new MultipleChoiceResult("", new List<string>() {  "Ventriculoarterial concordance",
                                                                                                            "Ventriculoarterial discordance" });

        public BoolResult OutflowTracts = new BoolResult("Unobstructed outflow tracts", "", true);


        public MultipleChoiceResult AorticValve1 = new MultipleChoiceResult("", new List<string>() {    "Thin mobile aortic valve leaflets",
                                                                                                        "Thickened dysplatic aortic valve leaflets"});

        public MultipleChoiceResult AorticValve2 = new MultipleChoiceResult(" with", new List<string>() {  "no stenosis",
                                                                                                            "mild stenosis",
                                                                                                            "moderate stenosis",
                                                                                                            "severe stenosis" });

        public MultipleChoiceResult AorticValve3 = new MultipleChoiceResult(" and", new List<string>() {    "",
                                                                                                            "no regurgitation",
                                                                                                            "trivial regurgitation",
                                                                                                            "mild regurgitation",
                                                                                                            "moderate regurgitation",
                                                                                                            "severe regurgitation" });

        public BoolResult AortaVSDOvveride = new BoolResult("Aorta overrides the VSD");
        public BoolResult LossSinotubularJunction = new BoolResult("Loss of the sinotubular junction");


        public MultipleChoiceResult PulmonaryValve1 = new MultipleChoiceResult("", new List<string>() { "Normal pulmonary valve",
                                                                                                        "Thickened and doming pulmonary valve leaflets"});

        public MultipleChoiceResult PulmonaryValve2 = new MultipleChoiceResult(" with", new List<string>() {  "no stenosis",
                                                                                                            "mild stenosis",
                                                                                                            "moderate stenosis",
                                                                                                            "severe stenosis" });

        public MultipleChoiceResult PulmonaryValve3 = new MultipleChoiceResult(" and", new List<string>() { "",
                                                                                                            "no regurgitation",
                                                                                                            "trivial regurgitation",
                                                                                                            "mild regurgitation",
                                                                                                            "moderate regurgitation",
                                                                                                            "severe regurgitation" });
        //Great Arteries
        public MultipleChoiceResult LeftAorticArch1 = new MultipleChoiceResult("", new List<string>() { "Unobstructed left sided aortic arch",
                                                                                                        "Left sided aortic arch",
                                                                                                        "" });

        public MultipleChoiceResult LeftAorticArch2 = new MultipleChoiceResult("", new List<string>() { "with normal branching",
                                                                                                        "",
                                                                                                        "with bovine trunk (common origin of the brachiocephalic and LCCA)",
                                                                                                        "with aberrant right subclavian artery (this is not a vascular ring)" });
        // right aortic arch label
        public MultipleChoiceResult RightAorticArch1 = new MultipleChoiceResult("", new List<string>() {"",
                                                                                                        "Unobstructed right sided aortic arch",
                                                                                                        "Right sided aortic arch"}, displayname: "Right aortic arch");

        public MultipleChoiceResult RightAorticArch2 = new MultipleChoiceResult("", new List<string>() {"",
                                                                                                        "with mirror image branching",
                                                                                                        "with aberrant left subclavian artery (with a left sided ductal ligament this is the setup for a vascular ring)" });


        public BoolResult BranchPulmonaryArteries = new BoolResult("Normal branch pulmonary arteries", "", true);

        public MultipleChoiceResult DuctusArteriosus1 = new MultipleChoiceResult("", new List<string>() {
                                                                                                        "Normal ductus arteriosus",
                                                                                                        "Tortuous ductus arteriosus",
                                                                                                        "Ductal constriction",
                                                                                                        "Aneurysmal dilatation of the ductus arteriosus"});

        public MultipleChoiceResult DuctusArteriosus2 = new MultipleChoiceResult(" with", new List<string>() {
                                                                                                        "antegrade flow",
                                                                                                        "retrograde flow" });

        //Pulmonary Veins

        public MultipleChoiceResult PulmonaryVeins = new MultipleChoiceResult("", new List<string>() {  "Normal pulmonary venous connection",
                                                                                                        "Partial anomalous pulmonary venous drainage",
                                                                                                        "Total anomalous pulmonary venous connection",
                                                                                                        "Not evaluated" });

        //Coronary Arteries

        //Other
        public BoolResult NoPerciardialEffusion = new BoolResult("No perciardial effusion");

        public MultipleChoiceResult PerciardialEffusion = new MultipleChoiceResult("", new List<string>() {  "",
                                                                                                            "Small",
                                                                                                            "Moderate",
                                                                                                            "Large" }, "perciardial effusion");

        public BoolResult NoFetalHydrops = new BoolResult("No fetal hydrops");
        public BoolResult PleuralEffusion = new BoolResult("Pleural effusion");
        public BoolResult Ascites = new BoolResult("Ascites");
        // Conclusion
        public MultipleChoiceResult Conclusion = new MultipleChoiceResult("Conclusion:", new List<string>() { "Normal",
                                                                                                                "Muscular VSD",
                                                                                                                "Perimembranous VSD",
                                                                                                                "Aberrant right subclavian artery",
                                                                                                                "Right aortic arch with aberrant left subclavian artery"});
    }
}
