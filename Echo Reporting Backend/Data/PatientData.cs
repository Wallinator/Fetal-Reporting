
using FetalReporting.Data.Results;
using System;
using System.Collections.Generic;
using UnitsNet;
using UnitsNet.Units;

namespace FetalReporting.Data {
    public class PatientData {
        public StringResult PatientID;
        public StringResult PatientName;
        public DateResult PatientDOB;
        public DateResult StudyDate;
        public DateResult EstimatedDueDate;
        public StringResult ReasonForStudy;
        public StringResult ReferringPhysician;
        public MultipleChoiceResult EchoType;
        public MultipleChoiceResult ReportingDoctor;
        public Result PatientAge;
        public Result FemurLength;
        public Result GestationalAge;


        public void UpdateGestationalAgeResult() {
            GestationalAge.Value = (280 - (EstimatedDueDate.Value - StudyDate.Value).TotalDays) / 7.0;
            GestationalAge.Empty = false;
        }
        public void UpdateAgeResult() {
            PatientAge.Value = (DateTime.Now - PatientDOB.Value).TotalDays / 365.0;
            PatientAge.Empty = false;
        }
        public PatientData() {

            PatientAge = new Result("Age", "years");

            GestationalAge = new Result("Gestational Age", "weeks");

            FemurLength = new Result("Femur Length", "mm");

            PatientName = new StringResult("Patient Name");

            PatientID = new StringResult("Patient ID");

            PatientDOB = new DateResult("DOB");

            StudyDate = new DateResult("Study Date");

            EstimatedDueDate = new DateResult("Estimated Due Date");

            ReasonForStudy = new StringResult("Reason For Study");

            ReferringPhysician = new StringResult("Referring Physician");

            EchoType = new MultipleChoiceResult("Echo Type", new List<string>() { "Transthoracic echo" });

            ReportingDoctor = new MultipleChoiceResult("Reporting Doctor", new List<string>() { "Dr Paul Brooks" });

            UpdateGestationalAgeResult();
        }
    }
}
