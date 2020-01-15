concrete RailwayEngRGL of Railway = open SyntaxEng, ParadigmsEng, SymbolicEng, (Res=ResEng), Prelude in {
  lincat Object = N; Length = NP; 
         Restriction = A2; Statement = S;

  oper
    passVP : VP -> VP = \vp -> 
       lin VP (Res.insertObj (\\a => vp.ad ! a ++ vp.ptp ++ vp.p ++ vp.s2 ! a) (Res.predAux Res.auxBe)) ;


  lin
    Signal = mkN "signal";
    Switch = mkN "switch";
    Detector = mkN "detector";
    LengthMeters i = symb (i.s ++ "m");
    GreaterThan = mkA2 (mkA "more") (mkPrep "than");
    LessThan = mkA2 (mkA "less") (mkPrep "than");
    ObjectSpacing obj1 obj2 restriction length = 
     mkS (mkCl (mkNP a_Det obj1) 
               must_VV
               (mkVP (passVP (mkVP (mkVA (mkV "place"))  (mkAP restriction length)))
                     (SyntaxEng.mkAdv from_Prep (mkNP a_Det obj2)))
     );
}
