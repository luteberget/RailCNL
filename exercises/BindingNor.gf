concrete BindingNor of Binding = open Prelude, (D=DiffNor), SyntaxNor, (P=ParadigmsNor) in {
  lincat
    Prop = S;
    Identifier = NP;

  oper
    forall : NP -> S -> Cl
      = \var,cl ->  mkCl (mkAdv for_Prep (mkNP all_Predet var)) cl;
    mkPN_x : Str -> PN
     = \s -> lin PN {s = \\_ =>  s ; g = D.ngen2gen P.masculine } ;
    strNP : Str -> NP
      = \s -> mkNP (mkPN_x s);

  lin
    All b = mkS (forall (strNP b.$0) b);
    Eq x y = mkS (mkCl x y);
    AnIdentifier = mkNP (P.mkN "defX");

   lindef Identifier = \s -> strNP s;
}
