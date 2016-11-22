abstract Anaphoric = {
flags startcat = Prop;
  cat

   Kind ; Name Kind ; Ref Kind ;  Prop; 

  fun
   Pron, Def : (k:Kind) -> Ref k -> Name k;
   Univ :      (k:Kind) -> (Ref k -> Prop) -> Prop;
   EoO :       (k:Kind) -> Name k -> Prop;

   MkKind : Kind;
}
