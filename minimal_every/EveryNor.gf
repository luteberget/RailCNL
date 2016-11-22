concrete EveryNor of Every = open Prelude, SyntaxNor, (P=ParadigmsNor) in {
 lincat
   Object = N;
   Predicate = N;
   Literal = { s: Cl ; isClass : Bool };
   Body = { s: S; isSingleClass : Bool };
   Statement = S;

 param 
   IsClassification = Classification | Other;

 oper
   then_Adv : Adv = P.mkAdv "så";
   ifthen : Cl -> S -> S = \cl,s -> mkS (mkAdv if_Subj s) (mkS then_Adv (mkS cl)) ;

   classYes : Cl -> Literal = \cl -> lin Literal { s = cl; isClass = True };
   classNo : Cl -> Literal = \cl -> lin Literal { s = cl; isClass = False };

 lin
   CustomObject x = P.mkN "{something}";
   CustomPredicate x = P.mkN "{property}";

   Negation l = { s = mkS presentTense negativePol l.s ; isSingleClass = False };

   Literal0 pred = classNo (mkCl pred);
   Literal1 pred a = classYes (mkCl (mkNP pred) (mkNP a));
   Literal2 pred a b = classNo (mkCl (mkNP (mkCN (P.mkN2 pred (P.mkPrep "av")) (mkNP a))) (mkNP b));

   Body0 l = { s = mkS l.s; isSingleClass = l.isClass};
   Conjunction a b = { s = mkS and_Conj a.s b.s; isSingleClass = False} ;

   Fact l = mkS l.s;

   -- Rule (Body0 (Literal1 pa a)) (Literal1 pb b) = mkS (mkCl pa);
   Rule body head = case <body.isSingleClass, head.isClass> of {
         <True,True> => mkS (mkCl (mkNP every_Det (P.mkN "objX")) (mkNP (P.mkN "objY"))) ;
         _ => ifthen head.s body.s
   };
}
