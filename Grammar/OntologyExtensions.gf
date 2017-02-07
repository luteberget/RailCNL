abstract OntologyExtensions = Graph ** {

  -- Playing around with extensions to the ontology
  -- language. These might be a bit more messy than the 
  -- base language. Searching for a nice abstraction here.

  flags startcat=Statement;

  cat
    RelatedSubjects;
    TwoRelations;

  fun

   -- ""Et hovedsignal og dets påfølgende hovedsignal bør
   --   være startpunkt og sluttpunkt for en togvei.""
    -- RelatedObjectsToRelatedObjects : Modality -> Subject -> Class -> Class -> Class -> Statement;

    RelatedObjectsToRelatedObjects : Modality -> RelatedSubjects -> TwoRelations -> Statement;

    -- startpunkt og sluttpunkt for en togvei (som har farge rød)
    TwoRelationsOfSubject : Class -> Class -> Subject -> TwoRelations;
    MkRelatedSubjects : Subject -> SearchSubject -> RelatedSubjects;
}
