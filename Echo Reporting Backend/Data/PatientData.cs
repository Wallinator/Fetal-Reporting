using FetalReporting.Data.Measurements;
using FetalReporting.Data.Measurements.Units;
using FetalReporting.Data.Results;
using System;
using System.Collections.Generic;
using UnitsNet;
using UnitsNet.Units;

namespace FetalReporting.Data {
    public class PatientData {
        public StringResult PatientID;
        public StringResult PatientName;
        public StringResult PatientDOB;
        public DateResult StudyDate;
        public DateResult EstimatedDueDate;
        public StringResult ReasonForStudy;
        public StringResult ReferringPhysician;
        public MultipleChoiceResult EchoType;
        public MultipleChoiceResult ReportingDoctor;
        public Result PatientAge;
        public Result GestationalAge;


        public void UpdateGestationalAgeResult() {
            GestationalAge.Value = 280 - (EstimatedDueDate.Value - StudyDate.Value).Days;
        }
        public PatientData() {

            IMeasurementHeader temp;

            temp = new UnitHeaderAdapter("Age", new Duration(0, DurationUnit.Year365));
            PatientAge = new Result(temp, true);

            temp = new UnitHeaderAdapter("Gestational Age", new Duration(0, DurationUnit.Day));
            GestationalAge = new Result(temp, true);

            PatientName = new StringResult("Patient Name");

            PatientID = new StringResult("Patient ID");

            PatientDOB = new StringResult("DOB");

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
