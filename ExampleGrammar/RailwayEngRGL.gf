concrete RailwayEngRGL of Railway = open SyntaxEng, ParadigmsEng, SymbolicEng, (Res=ResEng) in {
  lincat Object = N; Length = NP; 
         Restriction = A2; Statement = S;

  lin
    Signal = mkN "signal";
    Switch = mkN "switch";
    Detector = mkN "detector";
    LengthMeters i = symb (i.s ++ "m");
    GreaterThan = mkA2 (mkA "more") (mkPrep "than");
    LessThan = mkA2 (mkA "less") (mkPrep "than");
    ObjectSpacing obj1 obj2 restriction length = 
     mkS (mkCl (mkNP a_Det obj1) 
(mkVP  (mkVP must_VV (mkVP (mkAP restriction length)))
  (SyntaxEng.mkAdv from_Prep (mkNP a_Det obj2))));




--               (mkVP 
--		  (mkVP 
--
--(mkAP (mkAP (mkA "placed")) 
--(mkVP (mkV "") (mkAP restriction length)))
--
--) 
--
--                  (SyntaxEng.mkAdv from_Prep (mkNP a_Det obj2)))
--     );
}
