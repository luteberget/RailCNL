using System;
using System.Collections.Generic;
using System.Linq;

namespace RailCNL2Datalog.OptimizationPasses
{
	public class InlineNegation
	{
		public static string LiteralPredicateName(RailCNL.Literal l) {
			Func<RailCNL.Predicate,string> getName = p => p.Accept (new RailCNL.Predicate.Visitor<string> (s => s));
			return l.Accept(new RailCNL.Literal.Visitor<string>(
				p => getName(p),
				(p,t1) => getName(p),
				(p,t1,t2) => getName(p),
				(p,t1,t2,t3) => getName(p),
				(p,t1,t2,t3,t4) => getName(p)
			));
		}

		public static bool HasNegatedClause(RailCNL.Conjunction conj) {
			return conj.Accept(new RailCNL.Conjunction.Visitor<bool>(
				(c1,c2) => HasNegatedClause(c1) || HasNegatedClause(c2),
				(t1,t2) => false, // Eq
				(t1,t2) => false, // Gt
				(t1,t2) => false, // Gte
				(t1,t2) => false, // Lt
				(t1,t2) => false, // Lte
				(neg) => true,
				(t1,t2) => false, // Neq
				(lit) => false
			));
		}

		public static bool ContainsPositivePredicateName(RailCNL.Conjunction conj, string predicate) {
			return conj.Accept(new RailCNL.Conjunction.Visitor<bool>(
				(c1,c2) => ContainsPositivePredicateName(c1, predicate) || ContainsPositivePredicateName(c2, predicate),
				(t1,t2) => false, // Eq
				(t1,t2) => false, // Gt
				(t1,t2) => false, // Gte
				(t1,t2) => false, // Lt
				(t1,t2) => false, // Lte
				(neg) => false,
				(t1,t2) => false, // Neq
				(lit) => LiteralPredicateName(lit) == predicate
			));
		}

		public static bool ContainsNegatedPredicateName(RailCNL.Conjunction conj, string predicate) {
			return conj.Accept(new RailCNL.Conjunction.Visitor<bool>(
				(c1,c2) => ContainsNegatedPredicateName(c1, predicate) || ContainsNegatedPredicateName(c2, predicate),
				(t1,t2) => false, // Eq
				(t1,t2) => false, // Gt
				(t1,t2) => false, // Gte
				(t1,t2) => false, // Lt
				(t1,t2) => false, // Lte
				(neg) => LiteralPredicateName(neg) == predicate,
				(t1,t2) => false, // Neq
				(lit) => false
			));
		}

		public static IList<RailCNL.Literal> CollectConjLiterals(RailCNL.Conjunction conj) {
			return conj.Accept (new RailCNL.Conjunction.Visitor<IList<RailCNL.Literal>> (
				(c1,c2) => CollectConjLiterals(c1).Concat(CollectConjLiterals(c2)).ToList(),
				(t1,t2) => new List<RailCNL.Literal>() { new RailCNL.Literal2(new RailCNL.StringPredicate("__eq"), t1, t2) }, // Eq
				(t1,t2) => new List<RailCNL.Literal>() { new RailCNL.Literal2(new RailCNL.StringPredicate("__gt"), t1, t2) }, // Gt
				(t1,t2) => new List<RailCNL.Literal>() { new RailCNL.Literal2(new RailCNL.StringPredicate("__gte"), t1, t2) }, // Gte
				(t1,t2) => new List<RailCNL.Literal>() { new RailCNL.Literal2(new RailCNL.StringPredicate("__lt"), t1, t2) }, // Lt
				(t1,t2) => new List<RailCNL.Literal>() { new RailCNL.Literal2(new RailCNL.StringPredicate("__lte"), t1, t2) }, // Lte
				(neg) => new List<RailCNL.Literal>() { neg },
				(t1,t2) => new List<RailCNL.Literal>() { new RailCNL.Literal2(new RailCNL.StringPredicate("__neq"), t1, t2) }, // Neq
				(lit) => new List<RailCNL.Literal>() { lit }
			));
		}

		public static IList<Tuple<String, RailCNL.Term[]>> CollectConjTuple(RailCNL.Conjunction conj) {
			return conj.Accept (new RailCNL.Conjunction.Visitor<IList<Tuple<String, RailCNL.Term[]>>> (
				(c1,c2) => CollectConjTuple(c1).Concat(CollectConjTuple(c2)).ToList(),
				(t1,t2) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("__eq", new []{t1,t2 }) }, 
				(t1,t2) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("__gt", new []{t1,t2 }) }, 
				(t1,t2) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("__gte", new []{t1,t2 }) }, 
				(t1,t2) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("__lt", new []{t1,t2 }) }, 
				(t1,t2) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("__lte", new []{t1,t2 }) }, 
				(neg) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("!" + LiteralPredicateName(neg), LiteralTerms(neg)) },
				(t1,t2) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create("__neq", new []{t1,t2 }) }, 
				(lit) => new List<Tuple<String, RailCNL.Term[]>>() { Tuple.Create(LiteralPredicateName(lit), LiteralTerms(lit)) }
			));
		}

		public static RailCNL.Term[] LiteralTerms(RailCNL.Literal l) {
			return l.Accept (new RailCNL.Literal.Visitor<RailCNL.Term[]> (
				(p) => new RailCNL.Term[]{ },
				(p, t1) => new[]{ t1},
				(p, t1, t2) => new[]{ t1,t2},
				(p, t1, t2, t3) => new[]{t1,t2,t3 },
				(p, t1, t2, t3, t4) => new[]{t1,t2,t3,t4 }
			));

		}

		public static IList<RailCNL.Conjunction> CollectionConjConj(RailCNL.Conjunction conj) {
			if (conj is RailCNL.Conj) {
				var c = conj as RailCNL.Conj;
				return CollectionConjConj (c.x1).Concat (CollectionConjConj(c.x2)).ToList ();
			}
			else return new List<RailCNL.Conjunction>() { conj };
		}

		public static RailCNL.Literal RuleHead(RailCNL.Rule rule) {
			return rule.Accept (new RailCNL.Rule.Visitor<RailCNL.Literal> ((h, b) => h));
		}

		public static RailCNL.Conjunction RuleBody(RailCNL.Rule rule) {
			return rule.Accept (new RailCNL.Rule.Visitor<RailCNL.Conjunction> ((h, b) => b));
		}

		public static bool IsVariable(RailCNL.Term t) {
			return t.Accept (new RailCNL.Term.Visitor<bool> (
				_ => false,
				_ => false,
				s => s.Count () > 0 && Char.IsUpper (s.First ())
			));
		}

		public static string GetVariableString(RailCNL.Term t) {
			return t.Accept (new RailCNL.Term.Visitor<string> (
				_ => null,
				_ => null,
				s => (s.Count () > 0 && Char.IsUpper (s.First ())) ?
				s : null
			));
		}

		public static int CountBoundVariables(RailCNL.Term[] terms, IDictionary<string,string> map) {
			return terms.Select (GetVariableString)
				.Where (s => !String.IsNullOrEmpty (s))
				.Where (v => map.ContainsKey (v))
				.Count ();
		}

		public static bool TermEquals(RailCNL.Term t1, RailCNL.Term t2) {
			return t1.Accept (new RailCNL.Term.Visitor<bool> (
				f => f == (t2 as RailCNL.FloatTerm)?.x1,
				i => i == (t2 as RailCNL.IntTerm)?.x1,
				s => s == (t2 as RailCNL.StringTerm)?.x1
			));
		}

		public static RailCNL.Literal Substitute(Tuple<string,RailCNL.Term[]> newTerm, IDictionary<string,string> subst) {
			var pred = new RailCNL.StringPredicate (newTerm.Item1);
			List<RailCNL.Term> terms = new List<RailCNL.Term> ();
			foreach (var term in newTerm.Item2) {
				if (IsVariable (term)) {
					terms.Add (new RailCNL.StringTerm (subst [GetVariableString (term)]));
				} else {
					terms.Add (term);
				}
			}

			if (newTerm.Item2.Length == 0) {
				return new RailCNL.Literal0 (pred);
			} else if (newTerm.Item2.Length == 1) {
				return new RailCNL.Literal1 (pred, terms[0]);
			}else if (newTerm.Item2.Length == 2) {
				return new RailCNL.Literal2 (pred, terms[0], terms[1]);
			}else if (newTerm.Item2.Length == 3) {
				return new RailCNL.Literal3 (pred, terms[0], terms[1], terms[2]);
			}else if (newTerm.Item2.Length == 4) {
				return new RailCNL.Literal4 (pred, terms [0], terms [1], terms [2], terms [3]);
			} else {
				throw new ArgumentException ();
			}
		}

		public static RailCNL.Conjunction SubstituteBody(RailCNL.Conjunction body, string predicateName, RailCNL.Conjunction newClause) {
			return body.Accept(new RailCNL.Conjunction.Visitor<RailCNL.Conjunction>(
				(c1,c2) => new RailCNL.Conj(SubstituteBody(c1, predicateName, newClause), 
					SubstituteBody(c2, predicateName, newClause)),
				(t1,t2) => new RailCNL.EqLit(t1,t2),
				(t1,t2) => new RailCNL.GtLit(t1,t2),
				(t1,t2) => new RailCNL.GteLit(t1,t2),
				(t1,t2) => new RailCNL.LtLit(t1,t2),
				(t1,t2) => new RailCNL.LteLit(t1,t2),
				(neg) => LiteralPredicateName(neg) == predicateName ? newClause : new RailCNL.Negation(neg),
				(t1,t2) => new RailCNL.NeqLit(t1,t2),
				(lit) => new RailCNL.SimpleConj(lit)
			));
		}

		public static IList<RailCNL.Rule> InlineNegations(IList<RailCNL.Rule> rules) {

			bool foundInstance = true;
			while (foundInstance) {
				foundInstance = false;
				// Find candidate.

				// 1. Predicate with no negated body clauses.
				// 2. Predicate is not recursive
				// 3. Predicate has only one rule.
				// 3. Predicates from rule heads which only appear
				// negated in bodies.
				// 4. When it appears negated in bodies, the rule in which 
				// they appear share all but one body clause.
				// (Alternatively, the pos(x,y), y < 250. Maybe more
				//  generally: a set of clauses which can be inverted "inline" (?))
				//
				// Then replace the predicate with the single non-shared
				// body clause.

				List<RailCNL.Rule> newRules = null;
				foreach (var ruleToEliminate in rules) {
					// Discard rules which have negation in body.
					var headStr = LiteralPredicateName(RuleHead(ruleToEliminate));
					if(HasNegatedClause(RuleBody(ruleToEliminate))) continue;

					// Discard predicates which have several rules.
					var other_rules = rules.Where (r => r != ruleToEliminate);
					if (other_rules.Any (r => LiteralPredicateName (RuleHead (r)) == LiteralPredicateName(RuleHead(ruleToEliminate))))
						continue;

					// Discard recursive predicates. (recursion through other rules is 
					// covered by candiate_rules.Count != 1 below.)
					if (CollectConjLiterals (RuleBody (ruleToEliminate))
						.Select (l => LiteralPredicateName (l))
						.Contains (LiteralPredicateName(RuleHead(ruleToEliminate))))
						continue;

					var candidate_rules = other_rules
						.Where (r => ContainsNegatedPredicateName (RuleBody (r), 
							LiteralPredicateName(RuleHead(ruleToEliminate))));
					
					// Discard predicates which do not appear negatively in exactly one rule.
					if (candidate_rules.Count () != 1)
						continue;

					// Discard predicates which appear positive in other rules
					if (other_rules.Any (r => ContainsPositivePredicateName (RuleBody (r), 
						LiteralPredicateName(RuleHead(ruleToEliminate)))))
						continue;

					// Dsicard predicates which appear several times in a rule body
					if (other_rules.Any (r => CollectConjLiterals (RuleBody (r))
						.Select (l => LiteralPredicateName (l))
						.Where (n => n == LiteralPredicateName(RuleHead(ruleToEliminate)))
						.Count () > 1))
						continue;

					var containingRule = candidate_rules.Single ();

					// Try matching the rules.

					// Map of variables (from ruleToEliminate into containingRule).
					IDictionary<string,string> substitution = new Dictionary<string, string>();
					var elimClauses = CollectConjTuple (RuleBody (ruleToEliminate));
					var containingClauses = CollectConjTuple (RuleBody (containingRule));
					Tuple<string,RailCNL.Term[]> unmatchedTerm = null;

					bool termsMatch = true;
					foreach (var elimClause in elimClauses) {
						bool foundMatch = false;
						foreach (var containingClause in containingClauses) {
							if (containingClause.Item1 != elimClause.Item1)
								continue;

							if (containingClause.Item2.Length != elimClause.Item2.Length)
								continue;

							IDictionary<string,string> newSubstitutions = new Dictionary<string, string>();

							bool mismatchingTerms = false;
							for (int i = 0; i < containingClause.Item2.Length; i++) {
								var elimTerm = elimClause.Item2 [i];
								var containingTerm = containingClause.Item2 [i];
								if (IsVariable (elimTerm) != IsVariable (containingTerm))
									mismatchingTerms = true;

								if (IsVariable (elimTerm)) {
									if ( substitution.ContainsKey (GetVariableString (elimTerm))) {
										if (substitution [GetVariableString (elimTerm)] != GetVariableString (containingTerm)) {
											mismatchingTerms = true;
										}
									} else if ( newSubstitutions.ContainsKey (GetVariableString (elimTerm))) {
										if (newSubstitutions [GetVariableString (elimTerm)] != GetVariableString (containingTerm)) {
											mismatchingTerms = true;
										}
									} 
									else {
										newSubstitutions [GetVariableString (elimTerm)] = GetVariableString (containingTerm);
									}
								} else {
									if (!TermEquals (elimTerm, containingTerm)) {
										mismatchingTerms = true;
									}
								}
							}

							if (mismatchingTerms)
								continue;

							// Success
							foundMatch = true;

							// Add new substitutions.
							foreach (var kv in newSubstitutions)
								substitution [kv.Key] = kv.Value;
						}

						if (!foundMatch) {
							if (unmatchedTerm == null) {
								unmatchedTerm = elimClause;
							} else {
								break;
							}
						}
					}

					if (!termsMatch)
						continue;

					// Success: terms match
					foundInstance = true;

					// Copy rules, except the rule to be removed.
					newRules = new List<RailCNL.Rule> ();
					newRules.AddRange (rules);
					newRules.Remove (ruleToEliminate);

					var newClause = new RailCNL.Negation(Substitute (unmatchedTerm, substitution));
					var newRule = containingRule.Accept (new RailCNL.Rule.Visitor<RailCNL.Rule> (
						              (oldHead, oldBody) => new RailCNL.MkRule (oldHead,
							              SubstituteBody (oldBody, LiteralPredicateName (RuleHead (ruleToEliminate)), newClause)
						              )));

					newRules.Remove (containingRule);
					newRules.Add (newRule);
					break;
				}

				if (newRules != null) {
					rules = newRules;
					newRules = null;
					foundInstance = true;
				}
			}
			return rules;
		}

	}
}

