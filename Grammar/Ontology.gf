abstract Ontology = RailCNLStatement, Datalog ** {
  -- Partial grammar in the Railway CNL for expressing classes and
  -- properties of classes.

  flags startcat=Statement ;


  cat
    BaseClass;
    Class; 
    Property; Value;
    RelationMultiplicity;
    ConsequentCondition;

    OpenSubject;
    Subject; -- "a track", "a track of quality class X",
             -- "a track which has length greater than 200",
             -- "an object which is red".

    Condition; -- PropertyRestriction, ClassRestriction or Class + PropertyRestriction
               -- (not ClassRestriction+PropertyRestriction, because
               --  they are both arbitrarily complex using and/or, and 
               --  both need NP, which makes them hard to compose using the RGL)

    PropertyRestriction; -- "has a length which is less than 200 m"
                         -- "color red"
                         -- "color red or blue"
                         -- "color red or length 15.0"

    ClassRestriction; -- "... is a new_construction"

    Restriction;        -- "less than 200 m"
                        -- "red"
                        -- "red or blue"
    Modality;

  fun

  -- Classes, properties, values

    StringClassMasculine : String -> BaseClass;
    StringClassFeminine : String -> BaseClass;
    StringClassNeutrum : String -> BaseClass;
    StringClassAdjective : String -> BaseClass -> Class;
    StringClassNoAdjective : BaseClass -> Class;

    StringProperty : String -> Property;
    MkValue : Term -> Value; -- ConstTerm?

  -- Value restrictions
    Gt, Gte, Lt, Lte, Eq, Neq : Value -> Restriction;
    AndRestr, OrRestr : Restriction -> Restriction -> Restriction;

  -- Property value restrictions
   MkPropertyRestriction : Property -> Restriction -> PropertyRestriction;
   AndPropRestr, OrPropRestr : PropertyRestriction -> PropertyRestriction -> PropertyRestriction;

    MkClassRestriction : Class -> ClassRestriction;
    AndClassRestr, OrClassRestr : ClassRestriction -> ClassRestriction -> ClassRestriction;

    SubjectClass : Class -> OpenSubject;
    -- SubjectRelation : Class -> Class -> Subject; -- ??
    SubjectCondition : Class -> Condition -> OpenSubject;

    CloseSubject : OpenSubject -> Subject;

    ExistsRelation, ManyRelation, OneRelation : RelationMultiplicity;

    ConditionPropertyRestriction :         PropertyRestriction -> Condition;
    ConditionClassRestriction :            ClassRestriction -> Condition;
    ConditionClassAndPropertyRestriction : Class -> PropertyRestriction -> Condition;

    ConditionRelationRestriction : RelationMultiplicity -> Class -> Condition;
    ConditionRelationWithPropertyRestriction : RelationMultiplicity -> Class -> PropertyRestriction -> Condition;

    Obligation, NegativeObligation,
    Recommendation, NegativeRecommendation : Modality;

    MkConsequent : Condition -> ConsequentCondition;
    
    OntologyAssertion   : Subject -> ConsequentCondition -> Statement;
    OntologyRestriction : Modality -> Subject -> ConsequentCondition -> Statement;
}
