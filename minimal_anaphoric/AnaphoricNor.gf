concrete AnaphoricNor of Anaphoric = open SyntaxNor, (P=ParadigmsNor) in {

  lincat Kind,Name,Ref,Prop = {s:Str};

  -- lincat

  lin Pron k _ = {s = "he"};
  lin Def k _ = {s = "the" ++ k.s};
  lin Univ k p = {s = "it holds for every " ++ k.s ++ p.$0 ++ "that" ++ p.s};
  lin MkKind = {s = "k"};
  lin EoO k p = {s = k.s ++ "is either even or odd"};
}
