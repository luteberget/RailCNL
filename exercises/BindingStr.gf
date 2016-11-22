concrete BindingStr of Binding =  {

  lincat Prop, Identifier = {s:Str};

  lin All b = { s = "(" ++ "All" ++ b.$0 ++ ")" ++ b.s} ;
  lin Eq a b = {s = "("++a.s ++ "=" ++ b.s ++ ")" } ; 
  lin AnIdentifier = {s = "defaultId"};

  lindef Identifier = \s -> {s = s};
}
