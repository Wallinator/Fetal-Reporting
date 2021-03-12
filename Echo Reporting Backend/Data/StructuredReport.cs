using Echo_Reporting_Backend.Data;
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
        public StructuredReport(PatientData patientData, Dictionary<string, Result> results, ReportingOptions options) {
            ReportingOptions = options;
            PatientData = patientData;
            Results = results;
        }
        public StructuredReport() : this(new PatientData(), new Dictionary<string, Result>(), new ReportingOptions()) {
        }
        public StructuredReport(PatientData patientData) : this(patientData, new Dictionary<string, Result>(), new ReportingOptions()) {
        }
        public StructuredReport(PatientData patientData, Dictionary<string, Result> results) : this(patientData, results, new ReportingOptions()) {
        }
        public void GenerateSections() {
            Sections = new ReportSections(this);
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
