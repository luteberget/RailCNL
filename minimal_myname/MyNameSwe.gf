concrete MyNameSwe of MyName = open TryNor, (D=DiffNor) in {
  lincat
     Name = PN;
     Sentence = Utt;
  oper
    mkPN_x : Str -> PN
     = \s -> lin PN {s = \\_ =>  s ; g = D.ngen2gen neutrum } ;
  lin
    MyNameSentence name = mkUtt (mkS (mkCl (mkNP name))) ;
    CustomName cn = mkPN_x (cn.s) ;
}