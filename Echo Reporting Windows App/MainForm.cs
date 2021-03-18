using FetalReporting.Data;
using FetalReporting.Data.Results;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Fetal_Reporting_Windows_App {
    public partial class MainForm : Form {
        private StructuredReport report = new StructuredReport();
        private ReportForm reportForm = null;

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
        private ResultControl GestAgeControl;
        private void ShowAllResults(bool showNotFoundError) {
            panel3.Visible = false;
            // Patient Data
            #region
            ResultControl FemurLengthControl = new ResultControl(report.PatientData.FemurLength, showNotFoundError, this);
            GestAgeControl = new ResultControl(report.PatientData.GestationalAge, showNotFoundError, this, FemurLengthControl);
            GestationAgePanel.Controls.Add(GestAgeControl);
            PatientIDPanel.Controls.Add(new StringFieldControl(report.PatientData.PatientID));
            PatientNamePanel.Controls.Add(new StringFieldControl(report.PatientData.PatientName));
            DOBPanel.Controls.Add(new StringFieldControl(report.PatientData.PatientDOB));
            StudyDatePanel.Controls.Add(new DateFieldControl(report.PatientData.StudyDate, UpdateGAge));
            FemurLengthPanel.Controls.Add(FemurLengthControl);
            AgePanel.Controls.Add(new ResultControl(report.PatientData.PatientAge, showNotFoundError, this));

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

            MVAnnulusPanel.Controls.Add(new ResultControl(report.Results["Mitral valve annulus"], showNotFoundError, this, GestAgeControl));

            Tri1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.TriscupidValve1));
            Tri2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.TriscupidValve2));
            Tri3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.TriscupidValve3));
            TriscuspidAtresiaPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.TriscupidValveAtresia));
            RAVV1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RAVV1));
            RAVV2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RAVV2));

            TVAnnulusPanel.Controls.Add(new ResultControl(report.Results["Tricuspid valve annulus"], showNotFoundError, this));
            TVRegurgGradPanel.Controls.Add(new ResultControl(report.Results["Tricuspid valve regurgitation peak gradient"], showNotFoundError, this));
            #endregion
            // Ventricles
            #region
            VentricleSizeFunctionPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VentricleFunction));
            VentricularHypertrophyPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.VentricularHypertrophy));

            HeartRatePanel.Controls.Add(new ResultControl(report.Results["Heart Rate"], showNotFoundError, this));

            DilatedLVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DilatedLV));
            HypertrophyLVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypertrophiedLV));
            ReducedLVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.ReducedLVFunction));
            LVHypoplasticPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypoplasticAtriaLeft));



            LVWallPanel.Controls.Add(new ResultControl(report.Results["LV wall thickness"], showNotFoundError, this));
            SeptalWallPanel.Controls.Add(new ResultControl(report.Results["Septal wall thickness"], showNotFoundError, this));
            LVEDDPanel.Controls.Add(new ResultControl(report.Results["LV EDD"], showNotFoundError, this));
            LVLengthPanel.Controls.Add(new ResultControl(report.Results["LV length"], showNotFoundError, this));
            LVIVRTPanel.Controls.Add(new ResultControl(report.Results["LV IVRT"], showNotFoundError, this));
            MyoPIPanel.Controls.Add(new ResultControl(report.Results["Myocardial performance index"], showNotFoundError, this));


            DilatedRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DilatedRV));
            HypertrophyRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypertrophiedRV));
            ReducedRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.ReducedRVFunction));
            HypoplasticRVPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.HypoplasticAtriaRight));

            RVWallPanel.Controls.Add(new ResultControl(report.Results["RV wall thickness"], showNotFoundError, this));
            RVEDDPanel.Controls.Add(new ResultControl(report.Results["RV EDD"], showNotFoundError, this));
            RVLengthPanel.Controls.Add(new ResultControl(report.Results["RV length"], showNotFoundError, this));

            VentricularSeptumPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.IntactVentricularSeptum));

            VSD1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VSD1));
            VSD2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VSD2));
            VSD3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.VSD3));

            VSDDimensionPanel.Controls.Add(new ResultControl(report.Results["Ventricular septal defect dimension"], showNotFoundError, this));
            CardioCircumferencePanel.Controls.Add(new ResultControl(report.Results["Cardiothoracic circumference ratio"], showNotFoundError, this));
            CardioAreaPanel.Controls.Add(new ResultControl(report.Results["Cardiothoracic area ratio"], showNotFoundError, this));
            MechPRPanel.Controls.Add(new ResultControl(report.Results["Mechanical PR interval"], showNotFoundError, this));
            #endregion
            // Outlets
            #region
            VentriculoarterialPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.Ventriculoarterial));
            OutflowTractsPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.OutflowTracts));


            AorticValve1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AorticValve1));
            AorticValve2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AorticValve2));
            AorticValve3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.AorticValve3));

            AVAnnulusPanel.Controls.Add(new ResultControl(report.Results["Aortic valve annulus"], showNotFoundError, this));
            AVVelocityPanel.Controls.Add(new ResultControl(report.Results["Aortic valve peak velocity"], showNotFoundError, this));
            AVPeakGradPanel.Controls.Add(new ResultControl(report.Results["Aortic valve peak gradient"], showNotFoundError, this));


            AortaVSDPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.AortaVSDOvveride));
            LossSinotubularPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.LossSinotubularJunction));

            PV1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryValve1));
            PV2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryValve2));
            PV3Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryValve3));

            PVAnnulusPanel.Controls.Add(new ResultControl(report.Results["Pulmonary valve annulus"], showNotFoundError, this));
            PVVelocityPanel.Controls.Add(new ResultControl(report.Results["Pulmonary valve peak velocity"], showNotFoundError, this));
            PVPeakGradPanel.Controls.Add(new ResultControl(report.Results["Pulmonary valve peak gradient"], showNotFoundError, this));

            #endregion
            // Great Arteries
            #region
            LeftAorticArch1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LeftAorticArch1));
            LeftAorticArch2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.LeftAorticArch2));

            AscendingAortaPanel.Controls.Add(new ResultControl(report.Results["Ascending aorta"], showNotFoundError, this));
            AorticIsthmus3VVPanel.Controls.Add(new ResultControl(report.Results["Aortic isthmus 3VV"], showNotFoundError, this));
            AorticIsthmusSaggitalPanel.Controls.Add(new ResultControl(report.Results["Aortic isthmus sagittal"], showNotFoundError, this));

            RightAorticArch1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RightAorticArch1));
            RightAorticArch2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.RightAorticArch2));


            BranchPulmArteryPanel.Controls.Add(new BoolCheckControl(report.ReportingOptions.BranchPulmonaryArteries));

            MainPulmArteryPanel.Controls.Add(new ResultControl(report.Results["Main pulmonary artery"], showNotFoundError, this));
            RightPulmArteryPanel.Controls.Add(new ResultControl(report.Results["Right pulmonary artery"], showNotFoundError, this));
            LeftPulmArteryPanel.Controls.Add(new ResultControl(report.Results["Left pulmonary artery"], showNotFoundError, this));

            DuctusArteriosus1Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DuctusArteriosus1));
            DuctusArteriosus2Panel.Controls.Add(new StringDropDownControl(report.ReportingOptions.DuctusArteriosus2));

            DuctusArteriosus3VVPanel.Controls.Add(new ResultControl(report.Results["Ductus arteriosus 3VV"], showNotFoundError, this));
            DuctusArteriosusSaggitalPanel.Controls.Add(new ResultControl(report.Results["Ductus arteriosus sagittal"], showNotFoundError, this));
            DuctusArteriosusVelPanel.Controls.Add(new ResultControl(report.Results["Ductus arteriosus peak velocity"], showNotFoundError, this));
            DescendingAortaPanel.Controls.Add(new ResultControl(report.Results["Descending aorta"], showNotFoundError, this));

            #endregion
            // Pulmonary Veins
            #region
            PulmonaryVeinsPanel.Controls.Add(new StringDropDownControl(report.ReportingOptions.PulmonaryVeins));

            //PulmVeinSWavePanel.Controls.Add(new ResultControl(report.Results["Pulm vein S wave"], showNotFoundError, this));
            //PulmVeinDWavePanel.Controls.Add(new ResultControl(report.Results["Pulm vein D wave"], showNotFoundError, this));
            //PulmVeinAWavePanel.Controls.Add(new ResultControl(report.Results["Pulm vein A wave"], showNotFoundError, this));
            //PulmVeinWaveDurationPanel.Controls.Add(new ResultControl(report.Results["Pulmonary vein A wave duration"], showNotFoundError, this));

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
