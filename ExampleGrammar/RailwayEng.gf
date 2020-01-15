concrete RailwayEng of Railway = {
  lincat Object = Str; Length = Str; 
         Restriction = Str; Statement = Str;
  lin
    Signal = "signal";
    Switch = "switch";
    Detector = "detector";
    LengthMeters i = i.s ++ "m";
    GreaterThan = "greater than";
    LessThan = "less than";
    ObjectSpacing o1 o2 r l = "a" ++ o1 ++ "must be" ++ r ++ l ++ "from a" ++ o2;
}
