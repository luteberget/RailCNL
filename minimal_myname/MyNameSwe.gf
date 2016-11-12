concrete MyNameSwe of MyName = open TryNor, (D=DiffNor) in {
  lincat
     Name = PN;
     Sentence = Utt;
  oper
    mkPN_x : Str -> PN
     = \s -> {s = \\_ =>  s ; g = D.ngen2gen neutrum } ** {lock_PN = <>} ;
  lin
    MyNameSentence name = mkUtt (mkS (mkCl (mkNP name))) ;
    CustomName cn = mkPN_x (cn.s) ;
}
