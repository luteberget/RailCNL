abstract Graph = Ontology ** {
  -- Graph property language.


  cat
    DirectionalSubject;

  fun 

    Distance : Term -> Term -> PropertyRestriction -> Literal; -- Avstanden fra X til Y er Z.

    DistanceToCond : Subject -> PropertyRestriction -> Condition; 
      -- Avstanden fra {implisitt subjekt} til {gitt subjekt} er {restriksjon}.

    DistanceSubj : Subject -> Subject -> PropertyRestriction -> Subject; -- Trenger vi denne?


    -- First balise from signal.
    -- First {balise which is red} from {signal which is blue}.
    FirstSubjFrom : DirectionalSubject -> Subject;


    -- Ignore direction, i.e. use FirstSubjFrom with 
    --    "Subject" instead of "DirectionalSubject".
    NonDirectionalSubject : Subject -> DirectionalSubject;
    ForwardFromSubject : Subject -> DirectionalSubject;
    SameDirectionSubject : Subject -> DirectionalSubject;
    SearchDirectionSubject : Subject -> DirectionalSubject;

    AllFirstSubjFrom : DirectionalSubject -> Subject;
    ExistFirstSubjFrom : DirectionalSubject -> Subject;
   

}
