abstract Formatting = Ontology** {

 cat 
   Dimension; 
   Unit;
   RoundingFactor;

 fun
   StringRoundingFactor : String -> RoundingFactor;
   LengthDimension, AreaDimension, TimeDimension : Dimension;
   MeterUnit, MillimeterUnit, KilometerUnit : Unit;
   DisplayQuantity : Class -> Dimension -> Unit -> RoundingFactor -> Statement;
};
