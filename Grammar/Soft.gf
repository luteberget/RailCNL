abstract Soft = Ontology ** {

  cat 
   ConceptRelationType;

  fun 
   RelatedTo : ConceptRelationType;
   DefinedBy : ConceptRelationType;
   RelatedConcept :  ConceptRelationType -> Class -> Class -> Statement;
};
