concrete DatalogNor of Datalog = open Prelude in {
  lincat
    Rule,  Term, Terms, Predicate = { s : Str } ;
    Literal, Compound = { s : Rulepart => Str };

  param
    Rulepart = Antecedent | Consequent ;
  
  lin
    -- DistancePredicate a b l = ss ("avstanden fra" ++ a.s ++ "til" ++ b.s ++ "er" ++ l.s);

    DistancePredicate a b l = { s = table {
      Antecedent => "avstanden fra" ++ a.s ++ "til" ++ b.s ++ "er" ++ l.s;
      Consequent => "er avstanden fra" ++ a.s ++ "til" ++ b.s ++ l.s
    } } ;

    TrackQualityPredicate t q = { s = table {
      Antecedent => "sporet" ++ t.s ++ "sin kvalitetsklasse er" ++ q.s;
      Consequent => "er sporet" ++ t.s ++ "sin kvalitetsklasse" ++ q.s
   } }  ;


    TrackClassPredicate t = { s = table {
      Antecedent => t.s ++ "er et spor";
      Consequent => "er" ++ t.s ++ "et spor"
    }} ;

    UnknownPredicate = { s = table { _ =>  "predikat" } }  ;

    X = ss "X";
    Y = ss "Y";
    Z = ss "Z";
    a = ss "a";
    b = ss "b";
    c = ss "c";

    FloatTerm f = f ;
    IntTerm i = i; 
    
    CompoundTerms t ts =  ss (t.s ++ "og" ++ ts.s) ;
    SimpleTerm t = t;
    EmptyTerms = ss "";
    
    PredicateLiteral p t = { s= table { _ => p.s ++ "av" ++ t.s } };
    
    Negation l = { s = table { x => "ikke" ++ l.s!x } } ;

    Conjunction l1 l2 = { s = table {  x => l1.s!x ++ "," ++"og" ++ l2.s!x }} ;
    SimpleCompound l = l;
    --Fact l = { s = table { x => l.s!x ++  "." } }  ; 
    Fact l = ss (l.s!Antecedent  ++ ".");

    Implies head body = ss ("Hvis" ++ body.s!Antecedent ++  "," ++  "så" ++ head.s!Consequent ++  ".");

}
