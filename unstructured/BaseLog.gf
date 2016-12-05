abstract BaseLog = {
  flags startcat=Context;

  cat 
    Context;  -- Top-level

    Definition; [Definition] {1};
    Concept; [Concept] {1}; -- Declaration? Things like:  
    Constraint; [Constraint] {1};
    Symbol;  -- Mathematical symbol, example:  R_min.

    ClassName;
    Class;

    PropertyName;
    Property;

    AssociationName;
    Association;

    ObjectReference;
    PropertyValue;

 -- Datalog
    Literal; [Literal] {1};
    Term; [Term] {1};
    Predicate;

    Conjunction;


  fun

    ClassLiteral : Class -> Literal;
    PropertyLiteral : Property -> Literal;
    AssociationLiteral : Association -> Literal;

    MkAssociation : AssociationName -> ObjectReference -> ObjectReference -> Association;
    MkClass : ClassName -> ObjectReference -> Class;
    MkProperty : PropertyName -> ObjectReference -> PropertyValue -> Property;
    
    Negation : Literal -> Literal;

    MkCustomTerm : String -> Term;
    MkCustomPredicate : String -> Predicate;
    MkLiteral : Predicate -> [Term] -> Literal;
    MkConjunction : [Literal] -> Conjunction;

    MkConstraint : Conjunction -> Conjunction -> Constraint;
    MkContext : [Definition] -> [Concept] -> [Constraint] -> Context;
}
