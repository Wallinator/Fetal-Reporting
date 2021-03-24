using FetalReporting.Data.Results;
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
        public StructuredReport(PatientData patientData, ReportingOptions options) {
            ReportingOptions = options;
            PatientData = patientData;
            ResultsHelper.GetEmptyResults(patientData).ForEach(x => Results.Add(x.Name, x));
        }
        public StructuredReport() : this(new PatientData(), new ReportingOptions()) {
        }
        public StructuredReport(PatientData patientData) : this(patientData, new ReportingOptions()) {
        }
        public void GenerateSections() {
            AddCalculatedValues();
            Sections = new ReportSections(this);
        }


        private void AddCalculatedValues() {
            Result x;
            Result y;


            y = Results["Tricuspid valve regurgitation peak gradient"];
            if(Results.TryGetValue("Tricuspid valve regurgitation peak velocity", out x) && !x.Empty) {
                y.Value = 4 * x.Value * x.Value;
                y.Empty = false;
            }
            else {
                y.Value = 0;
                y.Empty = true;
            }

            y = Results["Pulmonary valve peak gradient"];
            if(Results.TryGetValue("Pulmonary valve peak velocity", out x) && !x.Empty) {
                y.Value = 4 * x.Value * x.Value;
                y.Empty = false;
            }
            else {
                y.Value = 0;
                y.Empty = true;
            }

            y = Results["Aortic valve peak gradient"];
            if(Results.TryGetValue("Aortic valve peak velocity", out x) && !x.Empty) {
                y.Value = 4 * x.Value * x.Value;
                y.Empty = false;
            }
            else {
                y.Value = 0;
                y.Empty = true;
            }

        }
    }
}
