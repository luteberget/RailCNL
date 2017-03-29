abstract RailCNLChunked = RailCNL**{
  flags startcat = Statement;
  cat Chunks; Chunk;

  fun
   OneChunk : Chunk -> Chunks;
   PlusChunk : Chunk -> Chunks -> Chunks;
   
   StatementChunk : Statement -> Chunk;
   SubjectChunk : Subject -> Chunk;
   AreaChunk : Area -> Chunk;
   GoalObjectChunk : GoalObject -> Chunk;
   PathConditionChunk : PathCondition -> Chunk;
   ClassChunk : Class -> Chunk;
   PropertyChunk : Property -> Chunk;
   RestrictionChunk : Restriction -> Chunk;

   UnknownChunk : String -> Chunk;
}
