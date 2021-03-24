using FetalReporting.Data;
using FetalReporting.Data.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class MainForm : Form {
        private StructuredReport report = new StructuredReport();
        private ReportForm reportForm = null;
        public Dictionary<string, List<ResultControl>> ResultControls = new Dictionary<string, List<ResultControl>>();

        public MainForm() {
            InitializeComponent();
            foreach (var control in panel3.Controls) {
                if (control is GroupBox g) {
                    var font = g.Font;
                    g.Font = new Font(Font.FontFamily, 12, Font.Style | FontStyle.Bold | FontStyle.Underline);
                    foreach (var child in g.Controls) {
                        if (child is Panel p) {
                            p.Font = font;
                        }
                    }
                }
            }
            ShowAllResults();
        }
        private void ShowAllResults() {
            ShowAllResults(false);
        }
        public void UpdateGAge() {
            report.PatientData.UpdateGestationalAgeResult();
            GestAgeControl.UpdateValue();
        }
        public void UpdateAge() {
            report.PatientData.UpdateAgeResult();
            AgeControl.UpdateValue();
        }
        private ResultControl GestAgeControl, AgeControl;
        private ResultControl MVAnnulusControl, TVAnnulusControl, TVRegurgGradControl, HeartRateControl;
        private void ShowAllResults(bool showNotFoundError) {
            panel3.Visible = false;
            // Patient Data
            #region
            ResultControl FemurLengthControl = new ResultControl(report.PatientData.FemurLength, showNotFoundError, this);

            GestAgeControl = new ResultControl(report.PatientData.GestationalAge, showNotFoundError, this, FemurLengthControl);
            GestationAgePanel.Controls.Add(GestAgeControl);

            PatientIDPanel.Controls.Add(new StringFieldControl(report.PatientData.PatientID));
            PatientNamePanel.Controls.Add(new StringFieldControl(report.PatientData.PatientName));

            StudyDatePanel.Controls.Add(new DateFieldControl(report.PatientData.StudyDate, UpdateGAge));
            FemurLengthPanel.Controls.Add(FemurLengthControl);

            AgeControl = new ResultControl(report.PatientData.PatientAge, showNotFoundError, this);
            AgePanel.Controls.Add(AgeControl);

            DOBPanel.Controls.Add(new DateFieldControl(report.PatientData.PatientDOB, UpdateAge));
            EstimatedDueDatePanel.Controls.Add(new DateFieldControl(report.PatientData.EstimatedDueDate, UpdateGAge));

            ReasonForStudyPanel.Controls.Add(new StringFieldControl(report.PatientData.ReasonForStudy));
            ReferringPhysicianPanel.Controls.Add(new StringFieldControl(report.PatientData.ReferringPhysician));
            EchoTypePanel.Controls.Add(new StringDropDownControl(report.PatientData.EchoType));
            ReportingDoctorPanel.Controls.Add(new StringDropDownControl(report.PatientData.ReportingDoctor));
            #endregion
            // Situs and Systemic Veins
            #region
            SitusPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.Situs));
            SystemicVeinsPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.SystemicVeins));
            #endregion
            // Atria
            #region
            NormalAtriaPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.AtriaSize));
            DilatedLeftAtriumPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DilatedAtriaLeft));
            DilatedRightAtriumPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DilatedAtriaRight));
            HypoplasticLeftAtriumPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypoplasticAtriaLeft));
            HypoplasticRightAtriumPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypoplasticAtriaRight));
            #endregion
            // AV Valves

            #region
            AVConnectionPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AVConnection));
            MV1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.MitralValve1));
            MV2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.MitralValve2));
            MV3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.MitralValve3));
            MitralAtresiaPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.MitralValveAtresia));

            LAVV1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LAVV1));
            LAVV2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LAVV2));
            LAVV3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LAVV3));

            MVAnnulusControl = new ResultControl(report.Results["Mitral valve annulus"], showNotFoundError, this, GestAgeControl);
            MVAnnulusPanel.Controls.Add(MVAnnulusControl);
            TVAnnulusControl = new ResultControl(report.Results["Tricuspid valve annulus"], showNotFoundError, this, GestAgeControl);
            TVAnnulusPanel.Controls.Add(TVAnnulusControl);
            TVRegurgGradControl = new ResultControl(report.Results["Tricuspid valve regurgitation peak gradient"], showNotFoundError, this, GestAgeControl);
            TVRegurgGradPanel.Controls.Add(TVRegurgGradControl);

            Tri1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.TriscupidValve1));
            Tri2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.TriscupidValve2));
            Tri3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.TriscupidValve3));
            TriscuspidAtresiaPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.TriscupidValveAtresia));
            RAVV1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RAVV1));
            RAVV2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RAVV2));

            #endregion
            // Ventricles
            #region
            VentricleSizeFunctionPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VentricleFunction));
            VentricularHypertrophyPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.VentricularHypertrophy));

            HeartRateControl = new ResultControl(report.Results["Heart Rate"], showNotFoundError, this, GestAgeControl);
            HeartRatePanel.Controls.Add(HeartRateControl);

            DilatedLVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DilatedLV));
            HypertrophyLVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypertrophiedLV));
            ReducedLVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.ReducedLVFunction));
            LVHypoplasticPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypoplasticAtriaLeft));



            LVWallPanel.Controls.Add(new ResultControl(report.Results["LV wall thickness"], showNotFoundError, this, GestAgeControl));
            SeptalWallPanel.Controls.Add(new ResultControl(report.Results["Septal wall thickness"], showNotFoundError, this, GestAgeControl));
            LVEDDPanel.Controls.Add(new ResultControl(report.Results["LV EDD"], showNotFoundError, this, GestAgeControl));
            LVLengthPanel.Controls.Add(new ResultControl(report.Results["LV length"], showNotFoundError, this, GestAgeControl));
            LVIVRTPanel.Controls.Add(new ResultControl(report.Results["LV IVRT"], showNotFoundError, this, GestAgeControl));
            MyoPIPanel.Controls.Add(new ResultControl(report.Results["Myocardial performance index"], showNotFoundError, this, GestAgeControl));


            DilatedRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DilatedRV));
            HypertrophyRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypertrophiedRV));
            ReducedRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.ReducedRVFunction));
            HypoplasticRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypoplasticAtriaRight));

            RVWallPanel.Controls.Add(new ResultControl(report.Results["RV wall thickness"], showNotFoundError, this, GestAgeControl));
            RVEDDPanel.Controls.Add(new ResultControl(report.Results["RV EDD"], showNotFoundError, this, GestAgeControl));
            RVLengthPanel.Controls.Add(new ResultControl(report.Results["RV length"], showNotFoundError, this, GestAgeControl));

            VentricularSeptumPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.IntactVentricularSeptum));

            VSD1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VSD1));
            VSD2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VSD2));
            VSD3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VSD3));

            VSDDimensionPanel.Controls.Add(new ResultControl(report.Results["Ventricular septal defect dimension"], showNotFoundError, this, GestAgeControl));
            CardioCircumferencePanel.Controls.Add(new ResultControl(report.Results["Cardiothoracic circumference ratio"], showNotFoundError, this, GestAgeControl));
            CardioAreaPanel.Controls.Add(new ResultControl(report.Results["Cardiothoracic area ratio"], showNotFoundError, this, GestAgeControl));
            MechPRPanel.Controls.Add(new ResultControl(report.Results["Mechanical PR interval"], showNotFoundError, this, GestAgeControl));
            #endregion
            // Outlets
            #region
            VentriculoarterialPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.Ventriculoarterial));
            OutflowTractsPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.OutflowTracts));


            AorticValve1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AorticValve1));
            AorticValve2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AorticValve2));
            AorticValve3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AorticValve3));

            AVAnnulusPanel.Controls.Add(new ResultControl(report.Results["Aortic valve annulus"], showNotFoundError, this, GestAgeControl));
            AVVelocityPanel.Controls.Add(new ResultControl(report.Results["Aortic valve peak velocity"], showNotFoundError, this, GestAgeControl));
            AVPeakGradPanel.Controls.Add(new ResultControl(report.Results["Aortic valve peak gradient"], showNotFoundError, this, GestAgeControl));


            AortaVSDPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.AortaVSDOvveride));
            LossSinotubularPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.LossSinotubularJunction));

            PV1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryValve1));
            PV2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryValve2));
            PV3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryValve3));

            PVAnnulusPanel.Controls.Add(new ResultControl(report.Results["Pulmonary valve annulus"], showNotFoundError, this, GestAgeControl));
            PVVelocityPanel.Controls.Add(new ResultControl(report.Results["Pulmonary valve peak velocity"], showNotFoundError, this, GestAgeControl));
            PVPeakGradPanel.Controls.Add(new ResultControl(report.Results["Pulmonary valve peak gradient"], showNotFoundError, this, GestAgeControl));

            #endregion
            // Great Arteries
            #region
            LeftAorticArch1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LeftAorticArch1));
            LeftAorticArch2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LeftAorticArch2));

            AscendingAortaPanel.Controls.Add(new ResultControl(report.Results["Ascending aorta"], showNotFoundError, this, GestAgeControl));
            AorticIsthmus3VVPanel.Controls.Add(new ResultControl(report.Results["Aortic isthmus 3VV"], showNotFoundError, this, GestAgeControl));
            AorticIsthmusSaggitalPanel.Controls.Add(new ResultControl(report.Results["Aortic isthmus sagittal"], showNotFoundError, this, GestAgeControl));

            RightAorticArch1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RightAorticArch1));
            RightAorticArch2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RightAorticArch2));


            BranchPulmArteryPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.BranchPulmonaryArteries));

            MainPulmArteryPanel.Controls.Add(new ResultControl(report.Results["Main pulmonary artery"], showNotFoundError, this, GestAgeControl));
            RightPulmArteryPanel.Controls.Add(new ResultControl(report.Results["Right pulmonary artery"], showNotFoundError, this, GestAgeControl));
            LeftPulmArteryPanel.Controls.Add(new ResultControl(report.Results["Left pulmonary artery"], showNotFoundError, this, GestAgeControl));

            DuctusArteriosus1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DuctusArteriosus1));
            DuctusArteriosus2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DuctusArteriosus2));

            DuctusArteriosus3VVPanel.Controls.Add(new ResultControl(report.Results["Ductus arteriosus 3VV"], showNotFoundError, this, GestAgeControl));
            DuctusArteriosusSaggitalPanel.Controls.Add(new ResultControl(report.Results["Ductus arteriosus sagittal"], showNotFoundError, this, GestAgeControl));
            DuctusArteriosusVelPanel.Controls.Add(new ResultControl(report.Results["Ductus arteriosus peak velocity"], showNotFoundError, this, GestAgeControl));
            DescendingAortaPanel.Controls.Add(new ResultControl(report.Results["Descending aorta"], showNotFoundError, this, GestAgeControl));

            #endregion
            // Pulmonary Veins
            #region
            PulmonaryVeinsPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryVeins));

            #endregion
            // Other
            #region
            NoPerciardialEffusionPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.NoPerciardialEffusion));
            PerciardialEffusionPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PerciardialEffusion));
            FetalHydropsPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.NoFetalHydrops));
            PleuralEffusionPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.PleuralEffusion));
            AscitesPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.Ascites));

            #endregion
            // Conclusion	
            #region
            ConclusionPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.Conclusion));
            #endregion
            panel3.AutoScrollPosition = new Point(0, 0);
            panel3.Visible = true;
        }
        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void publishToolStripMenuItem_Click(object sender, EventArgs e) {
            report.GenerateSections();
            if (reportForm == null) {
                reportForm = new ReportForm(report);
                reportForm.FormClosed += (x, y) => { this.reportForm = null; };
                reportForm.ShowDialog(this);
            }
            else {
                reportForm.Activate();
            }
        }
    }
}
