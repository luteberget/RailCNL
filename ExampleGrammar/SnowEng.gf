concrete SnowEng of Snow = open SyntaxEng, ParadigmsEng, (Try=TryEng) in {
  lincat 
   Subject = CN;
   Modifier = AP;
   Sentence = S;

   lin
     Snow = mkCN (mkN "snow");
     First = mkAP (mkA "first");

     SentenceUndet subj = mkS (mkCl (Try.she_NP)
      (mkVP Try.see_V2 (mkNP subj)));
     SentenceDet subj = mkS (mkCl (Try.she_NP)
      (mkVP Try.see_V2 (mkNP the_Det subj)));
     SentenceMod mod subj = mkS (mkCl (Try.she_NP)
      (mkVP Try.see_V2 (mkNP the_Det (mkCN mod subj))));
};
