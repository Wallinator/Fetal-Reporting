using UnitsNet;

namespace FetalReporting.Data.Measurements.Units {
    public class UnitHeaderAdapter : IMeasurementHeader {
        public IQuantity Quantity;
        public UnitHeaderAdapter(string name, IQuantity quantity) {
            Name = name;
            Quantity = quantity;
            UnitShorthand = SupportedUnitsHelpers.GetUnitShortHand(quantity);
        }

        public string Name { get; set; }

        public double Value => Quantity.Value;

        public string UnitName => Quantity.Unit.ToString();

        public string UnitShorthand {
            get;
            set;
        }


        public override string ToString() {
            return Name + ": " + Value + " " + UnitShorthand;
        }

    }
}
