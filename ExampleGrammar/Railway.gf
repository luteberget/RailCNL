abstract Railway = {
  cat Object; Length; Restriction; Statement; 
  fun
    Signal, Switch, Detector : Object;
    LengthMeters : Int -> Length;
    GreaterThan, LessThan : Restriction;
    ObjectSpacing : Object -> Object -> Restriction -> Length -> Statement;
}
