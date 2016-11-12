concrete DatalogDatalog of Datalog = {
  lincat
    Rule, Compound, Literal, Term, Predicate = {s : Str} ;

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

    Negation l = {s = "!" ++ l.s } ; 
    Conjunction l1 l2 = {s = l1.s ++ "," ++ l2.s } ;
    SimpleCompound l = {s = l.s } ; 
    Fact l = {s = l.s ++ "." } ;
    Implies head body = {s = head.s ++ " :- " ++ body.s ++ "." };

    CustomLiteral0 p = p;
    CustomLiteral1 p a = { s = p.s ++ "(" ++ a.s ++ ")" } ;
    CustomLiteral2 p a b = { s = p.s ++ "(" ++ a.s ++"," ++ b.s ++ ")" } ;

    StringPredicate s = s;
    StringTerm s = s;
}
