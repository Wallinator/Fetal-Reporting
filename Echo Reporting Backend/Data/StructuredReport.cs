﻿using FetalReporting.Data.Measurements;
using FetalReporting.Data.Results;
using Echo_Reporting_Backend.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FetalReporting.Data {
	public class StructuredReport {
		public Dictionary<string, Result> Results = new Dictionary<string, Result>();
		public PatientData PatientData {
			get;
			set;
		}
		public ReportingOptions ReportingOptions {
			get;
			set;
		}

		public ReportSections Sections {
			get;
			set;
		}
		public void WriteGeneratedReport(Stream stream, string html) {
			var writer = new StreamWriter(stream);
			writer.WriteLine(html);
			writer.Close();
		}
		/*public void WriteGeneratedReport(Stream stream) {
				var writer = new StreamWriter(stream);
				var pd = PatientData;
			List<string> l1, l2, l3;
			writer.WriteLine("Patient Data - ");
			l1 = pd.PatientID.TableString();
			string age = pd.PatientAge.Value.ToString("N0");
			if (pd.PatientAge.Value < 1) {
				age = (pd.PatientAge.Value * 12).ToString("N0") + " mo";
			}
			l2 = new List<string>() { pd.PatientAge.Name, age };
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,10}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			l1 = pd.PatientName.TableString();
			l2 = pd.PatientHeight.TableString();
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,10}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			l1 = pd.PatientSex.TableString();
			l2 = pd.PatientWeight.TableString();
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,10}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			l1 = pd.PatientDOB.TableString();
			l2 = pd.BSA.TableString();
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,10}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			l1 = new List<string>() { "", "" };
			string bp = "";
			if (!pd.SystolicBloodPressure.Empty && !pd.DiastolicBloodPressure.Empty) {
				bp = pd.SystolicBloodPressure.Value.ToString("N0") + "/" + pd.DiastolicBloodPressure.Value.ToString("N0") + " mmHg";
			}
			l2 = new List<string>() { "Blood Pressure", bp };
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,10}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			writer.WriteLine("");

			l1 = pd.ReferringPhysician.TableString();
			l2 = pd.EchoType.TableString();
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,20}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			l1 = pd.ReasonForStudy.TableString();
			l2 = new List<string>() { "", "" };
			writer.WriteLine(string.Format("{0,-20} - {1,20}{5,9}{2,-20} - {3,20}", l1[0], l1[1], l2[0], l2[1], " - ", ""));
			writer.WriteLine("");
			writer.WriteLine("");

			writer.WriteLine("Findings - ");

			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", "Measure", "(cm)", "Z Score", "Measure", "", "Calculation", ""));
			l1 = Results["IVSd"].AsString();
			l2 = Results["Mitral valve E wave"].AsString();
			l3 = Results["Fractional Shortening"].AsString();
			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", l1[0], l1[1], l1[3], "MV Peak E", l2[1] + " " + l2[2], "FS%", l3[1] + " " + l3[2]));
			l1 = Results["LVIDd"].AsString();
			l2 = Results["Mitral valve A wave"].AsString();
			l3 = Results["Left Ventricular Teichholz EF"].AsString();
			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", l1[0], l1[1], l1[3], "MV Peak A", l2[1] + " " + l2[2], "EF (Teich)", l3[1] + " " + l3[2]));
			l1 = Results["LVPWd"].AsString();
			l2 = Results["MV decel time"].AsString();
			l3 = Results["LV mass index"].AsString();
			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", l1[0], l1[1], l1[3], "MV decel time", l2[1] + " " + l2[2], "LV Mass Index (Cubed)", l3[1] + " " + l3[2]));
			l1 = Results["IVSs"].AsString();
			l2 = Results["Mitral annulus E'"].AsString();
			l3 = Results["Heart Rate"].AsString();
			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", l1[0], l1[1], l1[3], "LV E'", l2[1] + " " + l2[2], "HR", l3[1] + " " + l3[2]));
			l1 = Results["LVIDs"].AsString();
			l2 = Results["Septal annulus E'"].AsString();
			l3 = Results["MVCFc"].AsString();
			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", l1[0], l1[1], l1[3], "Septal E'", l2[1] + " " + l2[2], "MVCFc", l3[1] + " " + l3[2]));
			l1 = Results["LVPWs"].AsString();
			l2 = new List<string>() { "", "", "", "" };
			l3 = Results["Left ventricular cardiac output"].AsString();
			writer.WriteLine(string.Format("{0,-10}{1,-8}{2,7}     {3,-15}{4,-13}{5,-25}{6,-10}", l1[0], l1[1], l1[3], "", l2[1] + " " + l2[2], "LV output", l3[1] + " " + l3[2]));


			writer.WriteLine("");
			writer.WriteLine("");

			writer.WriteLine("Situs - " + Sections.Situs);
			writer.WriteLine("Systemic Veins - " + Sections.SystemicVeins);
			writer.WriteLine("Atria - " + Sections.Atria);
			writer.WriteLine("AV Valves - " + Sections.AVValves);
			writer.WriteLine("Ventricles - " + Sections.Ventricles);
			writer.WriteLine("Outlets - " + Sections.Outlets);
			writer.WriteLine("Great Arteries - " + Sections.GreatArteries);
			writer.WriteLine("Pulmonary Veins - " + Sections.PulmonaryVeins);
			writer.WriteLine("Coronary Arteries - " + Sections.CoronaryArteries);
			writer.WriteLine("Other - " + Sections.Other);
			writer.WriteLine("");
			writer.WriteLine("");
			writer.WriteLine("Conclusions -");
			writer.WriteLine(Sections.Conclusion);
			writer.WriteLine("");
			writer.WriteLine("");
			writer.WriteLine("Reporting - " + Sections.SignOff);
			writer.Close();
		}
*/
		public StructuredReport(PatientData patientData, Dictionary<string, List<MeasurementGroup>> findings, ReportingOptions options) {
			ReportingOptions = options;
			PatientData = patientData;
			ResultsFromFindings(findings);
		}
		public StructuredReport() : this(new PatientData(), new Dictionary<string, List<MeasurementGroup>>(), new ReportingOptions()) {
		}
		public StructuredReport(PatientData patientData) : this(patientData, new Dictionary<string, List<MeasurementGroup>>(), new ReportingOptions()) {
		}
		public StructuredReport(PatientData patientData, Dictionary<string, List<MeasurementGroup>> findings) : this(patientData, findings, new ReportingOptions()) {
		}
		public void GenerateSections() {
			Sections = new ReportSections(this);
		}

		private void ResultsFromFindings(Dictionary<string, List<MeasurementGroup>> findings) {
			Dictionary<string, List<MeasurementSpecification>> specsbysite = SpecificationHelper.SpecsBySite(PatientData);
			foreach (var sitename in specsbysite.Keys) {
				if (findings.ContainsKey(sitename)) {
					ResultsFromGroups(findings[sitename], specsbysite[sitename]);
				}
				else {
					ResultsFromGroups(new List<MeasurementGroup>(), specsbysite[sitename]);
				}
			}
			AddCalculatedValues();
		}

		private void ResultsFromGroups(List<MeasurementGroup> groups, List<MeasurementSpecification> specs) {
			foreach (var spec in specs) {
				Result r = spec.FindAndRemoveFromGroups(groups);
				Results.Add(r.Name, r);
				Debug.WriteLine(r.DebugString());
			}
		}

		private void AddCalculatedValues() {
			var r1 = Results["Pulmonary valve end diastolic velocity"];
			Result final1;
			if (!r1.Empty) {
				final1 = new Result("Pulmonary valve end diastolic peak gradient", "mmHg", empty: false, value: 4 * Math.Pow(r1.Value, 2));
			}
			else {
				final1 = new Result("Pulmonary valve end diastolic peak gradient", "mmHg");
			}
			Results["Pulmonary valve end diastolic peak gradient"] = final1;


			var r2 = Results["Patent Ductus Arteriosus peak velocity systole"];
			Result final2;
			if (!r2.Empty) {
				final2 = new Result("Patent Ductus Arteriosus peak gradient", "mmHg", empty: false, value: 4 * Math.Pow(r2.Value, 2));
			}
			else {
				final2 = new Result("Patent Ductus Arteriosus peak gradient", "mmHg");
			}
			Results["Patent Ductus Arteriosus peak gradient"] = final2;
		}
	}
}
