abstract Binding =  {
  -- flags startcat=Prop;
  cat
   Identifier; Prop;

  fun
   All : (Identifier -> Prop) -> Prop;
   Eq  : Identifier -> Identifier -> Prop;
   AnIdentifier : Identifier;
}
