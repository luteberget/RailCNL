# RailCNL

A controlled natural language (CNL) for representing railway regulations,
 implemented in Grammatical Framework

This work is funded by the [RailCons project](http://www.mn.uio.no/ifi/english/research/projects/railcons/).

## Grammar
A shortened Backus-Naur form (BNF) grammar is presented here as an overview
for approaching the language. Note however that the full grammar
is defined in Grammatical Framework code, which has some advantages over classical
BNF parser generator tools, namely
 (i) separation of abstract syntax and concrete syntax,
 (ii) resource grammar library for natural languages, allowing us to compose
      sentences in natural language while abstracting away from morphological details
      the target language, 
 (iii) the system encourages modularity and extensibility, which we need for handling
       a domain-specific language which must grow alongside its application, 
 (iv) tool support for managing text (editors, predictive parsing, visualization).

The full grammar is available in the repository (see Appendix).

```ebnf
Statement ::= OntologyAssertion | OntologyRestriction 
  | DistanceRestriction | PathRestriction
  | PlacementRestriction | (...) // partial grammar

// Statements
OntologyAssertion ::= Subject "is" Condition
OntologyRestriction ::= Subject Modality Condition
DistanceRestriction ::= "the distance from" Subject 
  "to" GoalObject Modality Restriction 
PathRestriction ::= PathQuantifier "from" Subject
  "to" GoalObject Modality PathCondition
PlacementRestriction ::= Subject Modality 
  "placed in" Area

// Modality
Modality ::= "must" | "shall not" 
           | "should" | "should not"

// Path
PathQuantifier ::= "all paths" | "no paths"
 | "a unique path" | "at least one path"
PathCondition ::= "pass" DirectionalObject

// Area
Area ::= BaseArea 
  | BaseArea "which has" PropertyRestriction
  | Area "or" Area | Area "and" Area
BaseArea :: = "tunnel" | "bridge"
  | "local release area" | Identifier

// Graph search
GoalObject ::= DirectionalObject 
  | "the first" DirectionalObject
DirectionalObject ::= "facing switch" 
  | "trailing switch" | SearchSubject 
  | SearchSubject "facing the same direction"
  | SearchSubject "facing the opposite direction"
SearchSubject ::= "a" Subject | "another"

// Ontology
Subject ::= "a" Class 
  | "a" Class "which" Condition
Condition ::= "is a" ClassRestriction 
  | "has" PropertyRestriction
  | "is a" Class "which has" PropertyRestriction
PropertyRestriction ::= Property ValueRestriction 
  | PropertyRestriction "or" PropertyRestriction
  | PropertyRestriction "and" PropertyRestriction
ClassRestriction ::= Class
  | ClassRestriction "or" ClassRestriction
  | ClassRestriction "and" ClassRestriction
ValueRestriction ::= Value // Equality
  | "not equal to" Value
  | "less than" Value | (...)
  | ValueRestriction "or" ValueRestriction
  | ValueRestriction "and" ValueRestriction

Value    ::= Identifier
Property ::= Identifier
Class    ::= Identifier
```
