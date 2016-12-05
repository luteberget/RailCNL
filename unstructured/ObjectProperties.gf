abstract HighLevel = LowLevel** {
  flags startcat=Constraint;
  cat

    Restriction;
    Class; Property;
    -- ImplicitSubjectCompound;
    -- ImplicitSubjectLiteral;

    ImplicitSubject;
    LiteralWithImplicitSubject;
    CompoundWithImplicitSubject;

    PropertySpec;

  fun

    


    MkImplicitSubjectClass : Class -> ImplicitSubject;
    MkImplicitSubjectProperty : ImplicitSubject -> PropertySpec -> ImplicitSubject;
    MkImplicitSubjectOtherClass : ImplicitSubject -> Class -> ImplicitSubject;
    -- MkImplicitSubjectPropertyRestriction : ImplicitSubject -> Property -> Restriction -> ImplicitSubject;

    MkPropertySpec : Property -> Term -> PropertySpec;
    MkPropertyRestriction : Property -> Restriction -> PropertySpec;
    MkCompoundProperty : PropertySpec -> PropertySpec -> PropertySpec;

MkPropertyConstraintWImplSubj : ImplicitSubject -> PropertySpec -> Constraint;
    -- MkPredicate3WithImplSubj : Predicate -> Term -> Term -> LiteralWithImplicitSubject;

    -- MkSimpleCompoundWImplSubj : LiteralWithImplicitSubject -> CompoundWithImplicitSubject;
    -- MkCompoundWImplSubj : CompoundWithImplicitSubject -> CompoundWithImplicitSubject -> CompoundWithImplicitSubject;

    -- MkImplicitConstraint : ImplicitSubject -> LiteralWithImplicitSubject -> Constraint;

    -- MkImplSubjSimpleCompound : ImplicitSubjectLiteral -> ImplicitSubjectCompound;
    -- MkImplSubjCompound : ImplicitSubjectCompound -> ImplicitSubjectCompound -> ImplicitSubjectCompound;

 -- implicit subject + properties (a track with quality class X)
 -- has property

    MkProperty : Predicate -> Property;
    MkClass : Predicate -> Class;

    -- Specific utterances (sentences)
    -- MkSubClass : Class -> Class -> Constraint;

    -- Specific predicates
    Distance : Term -> Term -> Term -> Literal;
    DistanceRestriction : Term -> Term -> Restriction -> Literal;

    -- Anonymous terms with clause
   AnonArithmeticLessThan : Term -> Restriction;
   AnonArithmeticGreaterThan : Term -> Restriction;

   -- Specific nouns
    Track : Class;
    Signal : Class;
    Balise : Class;

   -- Specific 

   -- Specific adjectives (?)
}
