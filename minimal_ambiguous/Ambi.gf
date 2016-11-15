abstract Ambi =  {
  flags startcat=Top;
  cat Basic; Comb1; Comb2; Top;
  fun 
    BasicString : Basic ;
    Combo1 : Basic -> Comb1;
    Combo2 : Basic -> Comb2;
    Top11 : Comb1 -> Comb1 -> Top;
    Top12 : Comb1 -> Comb2 -> Top;
    Top21 : Comb2 -> Comb1 -> Top;
    Top22 : Comb2 -> Comb2 -> Top;
}
