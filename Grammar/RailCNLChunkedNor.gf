concrete RailCNLChunkedNor of RailCNLChunked = RailCNLNor ** open
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  RailCNLParadigmsNor,
  (RailLex = RailCNLLexiconNor), RailCNLLexiconNor
in {

  lincat 
    Chunk = {s: Str};
    Chunks = {s: Str};

  lin 
    StatementChunk s = s;
    SubjectChunk s = mkUtt(mkNP a_Det s);
    AreaChunk s = Syn.mkAdv in_Prep s;

    UnknownChunk s = s;

    OneChunk s = s;
    PlusChunk a b = {s= a.s ++ b.s};
}
