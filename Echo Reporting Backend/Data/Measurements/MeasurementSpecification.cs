﻿using FetalReporting.Data.Measurements.Units;
using FetalReporting.Data.Results;
using FetalReporting.Formulas;
using System;
using System.Collections.Generic;

namespace FetalReporting.Data.Measurements {
    public class MeasurementSpecification {
        public string Name;
        public string RawMeasurementName;
        public Dictionary<string, string> Properties;
        public string DefaultUnitShorthand;
        public bool IncludeImageMode;
        public Enum UnitEnum;
        public IFormula Formula;
        public string AltName;
        //public bool NonMean;

        //public MeasurementSpecification(string name, string rawMeasurementName, Dictionary<string, string> properties, string defaultUnitShorthand, IFormula formula = null, bool includeImageMode = false, Enum unitEnum = null/*, bool nonMean = false*/) {
        public MeasurementSpecification(string name, string rawMeasurementName, Dictionary<string, string> properties, string defaultUnitShorthand, IFormula formula = null, bool includeImageMode = false, Enum unitEnum = null, string altName = "") {
            Name = name;
            RawMeasurementName = rawMeasurementName;
            Properties = properties;
            DefaultUnitShorthand = defaultUnitShorthand;
            Formula = formula;
            IncludeImageMode = includeImageMode;
            UnitEnum = unitEnum;
            AltName = altName;
            //NonMean = nonMean;
        }

        public Result FindAndRemoveFromGroups(List<MeasurementGroup> groups) {
            if (groups.Count == 0) {
                return MeasurementToResult(null);
            }
            if (IncludeImageMode) {
                Properties.Add("Image Mode", "M mode");
            }

            var groupIndex = groups.FindIndex(g => g.Name.Equals(RawMeasurementName) && MeasurementHelpers.CompareProperties(Properties, g));
            if (groupIndex > -1) {
                var group = groups[groupIndex];
                groups.RemoveAt(groupIndex);

                return MeasurementToResult(group.SelectMean());
                //return NonMean ? MeasurementToResult(group.SelectNonMean()) : MeasurementToResult(group.SelectMean());
            }

            else {
                if (IncludeImageMode) {
                    Properties["Image Mode"] = "2D mode";
                    IncludeImageMode = false;
                    return FindAndRemoveFromGroups(groups);
                }
                return MeasurementToResult(null);
            }
        }
        private Result MeasurementToResult(Measurement measurement) {
            if (measurement == null) {
                return new Result(Name, DefaultUnitShorthand, Formula, altName: AltName);
            }
            if (UnitEnum != null) {
                SupportedUnitsHelpers.Convert(measurement.Header, UnitEnum);
            }
            return new Result(Name, DefaultUnitShorthand, Formula, empty: false, value: measurement.Header.Value, altName: AltName);

        }
    }

}
