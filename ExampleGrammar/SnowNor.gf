concrete SnowNor of Snow = open SyntaxNor, ParadigmsNor, (Try=TryNor) in {
  lincat 
   Subject = CN;
   Modifier = AP;
   Sentence = S;

   lin
     Snow = mkCN (mkN "snø");
     First = mkAP (mkA "først");

    -- This file was a test of Norwegian gender marking on both
    -- article and noun (den første snøen).
    -- The last one produces correctly "hun ser den første snøen"
    -- 

     SentenceUndet subj = mkS (mkCl (Try.she_NP)
      (mkVP Try.see_V2 (mkNP subj)));
     SentenceDet subj = mkS (mkCl (Try.she_NP)
      (mkVP Try.see_V2 (mkNP the_Det subj)));
     SentenceMod mod subj = mkS (mkCl (Try.she_NP)
      (mkVP Try.see_V2 (mkNP the_Det (mkCN mod subj))));


};
