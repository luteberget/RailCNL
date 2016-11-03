concrete DatalogDatalog of Datalog = {
  lincat
    Rule, Compound, Literal, Term, Terms, Predicate = {s : Str} ;

  --def
  --  linP3 n a b c = { s = n.s ++ "(" ++ a.s ++ "," ++ b.s ++ "," ++ c.s ++ ")" } ;
  --  linP2 n a b = { s = n.s ++ "(" ++ a.s ++ "," ++ c.s ++ ")" } ;
  --  linP1 n a = { s = n.s ++ "(" ++ a.s ++ ")" } ;
  --  linP0 n = { s = n.s } ;
  
  lin
    DistancePredicate a b c = { s = "distance" ++ "(" ++ a.s ++ "," ++ b.s ++ "," ++ c.s ++ ")" } ;
    TrackClassPredicate t = {s = "track" ++ "(" ++ t.s ++ ")" } ;
    --TrackQualityPredicate = linP2 "trackQuality" ;
    TrackQualityPredicate t q = { s = "trackQuality" ++ "(" ++ t.s ++ "," ++ q.s ++ ")" } ;

    UnknownPredicate = {s = "predicate"} ;
    

    X = {s = "X" };
    Y = {s = "Y" };
    Z = {s = "Z" };
    a = {s = "a" };
    b = {s = "b" };
    c = {s = "c" };

    IntTerm i = i ;
    FloatTerm f = f ;
    
    CompoundTerms t ts = {s = t.s ++ "," ++ ts.s} ;
    SimpleTerm t = {s = t.s};
    EmptyTerms = {s = ""};
    
    PredicateLiteral  p t = {s = p.s ++ "(" ++ t.s ++ ")" } ;
    
    Negation l = {s = "!" ++ l.s } ; 

    Conjunction l1 l2 = {s = l1.s ++ "," ++ l2.s } ;
    SimpleCompound l = {s = l.s } ; 
    Fact l = {s = l.s ++ "." } ;
    Implies head body = {s = head.s ++ " :- " ++ body.s ++ "." };
}
