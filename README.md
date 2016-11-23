% RailCons CNL at Chalmers
% Bjørnar Luteberget
% 2016-11-02

# Formalizing "Teknisk regelverk"

The Norwegian railway authority has a comprehensive set of technical regulations ("Teknisk regelverk") for design/planning ("prosjektering"), construction, and maintenance of railway infrastructure. 
The text is also subdivided into 12 disciplines, such as electric, track works, tunnels, and signalling.

## Goal
The RailCons project would like to formalize relevant parts of the technical regulations for use in the on-the-fly type of verification which can be used within railway construction design software (specifically the RailCOMPLETE software). This type of verification will probably be limited to static infrastructure analysis, leaving the more heavy-weight analysis of e.g. the implementation of control systems to specialized analysis software such as Prover AB (Sweden) or Systerel (France). However, it could still be beneficial for the method for formalizing the technical regulations to include more dynamic and logically more complex kinds of information, as this could be used to analyse the regulations in themselves, or as input to other types of analysis software.

The suggested use cases are listed here by priority:

 1. On-the-fly verification inside the design tool for **static infrastructure**, probably 
    based on the Datalog logic. Related sub-goals are:
    1. Engineers can understand what the verification engine is doing. (CNL + CAD)
    2. Produce reports on how/what is verified. (CNL + CAD with report generator)
    3. Regulations are changing, so regulations database needs to be maintained. (CNL editor)
    4. Expert knowledge, rules of thumb, local company knowledge base. (CNL editor)
 2. Control system **implementation verification**, typically more computationally expensive, and based on other formalisms, such as timed automata, first order logic, etc. 
 3. Verification of human **activities and processes**, such as regulations for
    maintenance scheduling, or regulations for design *considerations*. (For example, 
    a non-standard design choice for infrastructure could be acceptable only when
    reasoning has been given for abandoning the standard choice.)
 4. Analysis of the regulations in themselves, for example exposing inconsistencies.
 5. Tranforming the regulations into a simpler, unambiguous text for human readers.

## Regulations overview
The technical regulations (*"Teknisk regelverk"*) can be found at <https://trv.jbv.no/> and consists of the following books:

 * **Common regulations**: 501 Common regulations
 * **Common electrical**: 510 Design and construction
 * **Signs**: 515 Placement of signs along the track
 * **Superstructure (tracks)**: 530 Design, 531 Construction, 532 Maintenance
 * **Substructure**: 520 Design and construction, 522 Maintenance
 * **Tunnels**: 521 Design and construction, 523 Maintenance
 * **Bridges**: 525 Design and construction, 527 Maintenance
 * **Overhead line**: 540 Design, 541 Construction, 542 Maintenance
 * **Low voltage and 22 kV**: 543 Design, 544 Construction, 545 Maintenance
 * **Power supply**: 546 Design, 547 Construction, 548 Maintenance
 * **Signalling**: 550 Design, 551 Construction, 552 Maintenance, 553 Assessment
 * **Telecommunications**: 560 Design and construction, 562 Maintenance

Structure of each book:

 * Each book repeats the *common regulations* as the first three chapters. 
 * Following this will typically be a *general* section containing:
    * declaration of the scope of the book, 
    * references to relevant standards,
    * definitions of relevant techincal terms,
    * qualitative classifications, such as quality classes, risk classes, etc.
 * The main part of a book consists typically of 5 to 10 chapters, each detailing a 
   specific technical topic within the discipline. The text consists of:
    * Scope declarations
    * Definitions
    * Non-normative statements
    * Comments
    * Regulations (including tables and figures), with exceptions
    * Examples


## Scope and focus

The technical regulations contain a lot of generalities  which are not 
necessarily normative, nor directly useful in a design setting.
Based on the prioritized use case list, the following parts of the regulations
should be considered first in designing and testing the formalization procedure:

 1. Superstructure design (track design / *Overbygning: 530 Prosjektering*), especially
    regulations and formulas regarding 
    - track geometry: curvature, gradients, etc.
    - switches: types, maximum speeds, naming (numbering), etc.
 2. Signalling design (*Signal: 550 Prosjektering*), especially
    - signal placement, functions, sighting distance
    - train detector placement, classification
    - switch motors requirements and control system components
    - automatic train protection system (ATC) placement and functions
    - interlocking (control system) routes, conflicts, detection sections,
      safety classes, flank protection, overlaps, etc.


# Rule classification

This is an attempt to classify rule types, and could 
help determine what the language needs to support, and
how the railway language is distinguished from 
other CNLs and general
ontology languages.

 - **Classes and properties**, descriptions of objects with 
 (complex) classification and properties. Properties are
 typically
     - Picked from enumeration (enumerations defined by an ontology)
     - Integers or floating point numbers
     - String operations (not so important so far, not directly supported in Datalog).
  
    See the RAINS CNL or any other ontology-based CNL.

 - **Formulas** mathematical type, usually also supported by ontology-like languages.

 - **Topology** specifies graph searches using the (somewhat expensive) 
    built-in predicates such as *connected*, *following*, *between*, *overlap*.
    
 - **Geometry** constraint language (as suggested by Gerardo).

 - *Future:* **LTL/CTL** style model checking properties. Any examples of CNLs for this?

 - *Future:* 

Tables are not a class of rules, only syntactic sugar for facts.

# Translation

The technique of controlled natural language will be investigated to allow
the input of regulations, especially those translatable into the 
static infrastructure verification being developed in the RailCons project.

## Non-textual information

It could be beneficial to keep tables and figures from the regulations when
transitioning to the CNL, so that the CNL interfaces can use these kinds 
of rich text.

Specifically, referring to figures and referring to the contents of tables 
based on column and row headers, could be useful.


## Examples and relevance
The following table lists some example excerpts from the regulations along with a translation into English, and a comment about use cases and relevance.

\input{examples}

# Translation toolchain

Suggest the following steps in transferring *teknisk regelverk* into Datalog.

 1. **Original**: *Teknisk regelverk* in its original form
 2. **Categorization**: Non-automatic or assisted transfer from 
    original text to a categorization of each part (sentence?) of the text into 
    the following:
     * Definitions
     * Scopes
     * Rules
     * Figures
     * Tables
 3. **High level CNL**: Non-automatic or assisted transfer of the 
    definitions and rules in the categorized text into a high-level CNL,
    with Norwegian-like and/or English-like concrete syntax, supporting 
    the kind of modalities and logic in the target (Datalog) language, with
    special constructs for the railway domain. 
 4. **Low-level CNL**: Fully automatic transfer from the high-level CNL into a 
    format which is specially suited for transfer to Datalog. Rules can be in the following form:

        Given "FACT_1" and "FACT_2" ..., then
        "COND_1" and "COND_2" ..., should be satisfied.
    
 5. **Datalog**: final output format of the translation

## High level CNL

The high level CNL should:

 * have Norwegian-like and/or English-like concrete syntax, 
 * recognize several types of top-level sentence types: 
    * definition, obligation, constraint, suggestion, heuristic, etc.
 * allow logic which is easily translatable to the target (Datalog) language 
    * conjunction, negation, arithmetic, implication(?)
 * support special constructs for the railway domain. 


### Top-level sentence types

Several kinds of sentences:

  * **Definition** defines something which can be referred to by other sentences. Example:

        The minimum radius R_min for use in formulas is 200 m.
        
  * **Obligation** is a 
 
  * **Constraint** is an absolute demand, possibly on the static infrastructure. Example:
 
        The minimum radius for any track on a new station is R_min.
        
  * **Suggestion** is a *"should"* statement.
  
        A main signal should not be placed in tunnels.
 
  * **Heuristic** might be used to give a suggestion for missing information, but should not
    override any specified information.
  
  * **Comments** are maybe not worth representing?
  
### Low-level logic

The top-level sentence types define which parts the sentence is made up of, while the 
low-level logic can be

 * **Conjunction**, example:

        A signal shall belong to a track and have a direction.
        
 * **Negation**, example:

        A signal shall not be taller than 9 m.
        
 * **Arithmetic**:
         
 * **Implication**.

### Railway constructs

To give more natural-ness to sentences, a vocabulary of railway terms will be "baked in" to the 
language. Some suggestions:

 * Any object type known in the object model for static infrastructure should be a recognized *noun* in 
   the natural language, and the presence an instance of this noun (`a signal`) is translated
   into an "individual" with the corresponding classification. I.e., `a signal` will be 
   translated into the unary predicate `signal(`$\__0$`)` in the final representation.
   
 * Known relations should be complemented with specific natural language, such as:
     * `distance(a,b,l)` 

         ---> `the distance from a to b is l`
     * `distance(a,b,l), l < 50` 

         ---> `the distance from a to b is less than 50 m`
     * `track(X)` 

         ---> `X is a track  ` (for any known object type)
     * `track(X), trackQualityClass(X,A)` 

         ---> `X is a track of quality class A`
     * `boundary(B), firstSameDirSwitch(B,Sw), facingSwitch(B,Sw), controlled(Sw)`

         ---> `The first facing, controlled switch after a station boundary`
 
### Other natural-ness considerations

 * Reflection from facts to conditions, for example:
        
      * `If X is a track with quality class A, then X must have a radius higher than 500 m in all segments` 

     is written as 
   
      * `Tracks of quality class A must have radius higher than 500 m in all segments`

 * From the GF book, chapter 6, semantic actions:
    * *Anaphroric* expressions: 

            If a man walks he talks

    * *Aggregation* transfer:
    
            John runs or John walks --> John runs or walks
        
 * From the GF book, chapter 8, interfacing formal and natural languages:
    * Natural language generation to/from logic can in general require
      steps that are outside of the grammar. However, some possibilities 
      exist for improving naturalness using GF directly.

The fact that Datalog disallows nested predicates (function symbols), simplifies
some aspects of linearization into natural language. For example, the 
negation of arbitrary sentences (as presented on p. 190 in the GF book)
is not necessary, as negation is only possible in body literals, which 
cannot be nested. More specifically, since literals can have the clause type 
`Cl` instead of the sentence type `S`, natural expressions of negation are
available directly from the resource grammar.

These considerations have led to the comparison section below.

## Strategies for translating HL to LL

The **low level** (LL) language has a grammar which is close to Datalog, adding only the
distinction between rules (definition, constraint, etc.), and metadata about rules (name,
ID, extended description, severity, etc.), which was organized as *structured comments* 
in the prototype (from iFM). It linearizes either directly to Datalog, or to a (somewhat less
natural) CNL.

The **high level** (HL) language adds constructs as described in the sections above. The translation 
from HL language to LL language should be deterministic.

A few strategies have come to mind:

### Basic GF resource grammar use
 - CNL : "`if X is a macroscopic_node, then X is a station_boundary`".
 - Write resource grammar linearization (natural language AST is only implicit).
 - AST : "`ifthen(macroscopic_node(X),station_boundary(X)).`"
 
It is not directly possible to make variables implicit in this approach. (From chapter 8 of the GF book: 
*Natural language generation to/from logic can in general require
steps that are outside of the grammar.*)
 
### Montague grammars in GF
Approach described in *Aarne Ranta, "Computational Semantics in Type Theory"*.

 - CNL : "``all women walk``".
 - Use resource grammar to convert sentence into natural language AST (explicit resource grammar AST).
 
    `Cl(Pred VP (Det CN woman_N [....]))`

 - Use a transfer function to *interpret* the sentence into a logic.
    `All (\x -> If (iN woman_N x) (iV walk_x)).`

Requires higher-order types in GF, and writing a transfer function. Not necessarily a two-way approach.

### AST transfer functions
Generalizing the above.

 - HL CNL : "`A macroscopic node is [also] a station boundary.`".
 - Write an AST and resource grammar linearization which supports all of the 
   interesting constructs. Here:
   
    `SubClass(NounModifier(macroscopic, node), NounModifier(station, boundary)).`
    
 - Write transfer functions from HL to LL, optionally back again.
 
    `macroscopic_node(X) -> station_boundary(X).`

 - Linearize to LL.
    
### AST rewriting system

Converting from LL to HL might be complicated. Straight-forwardly writing an explicit
transfer function from LL to HL might not be feasible.
Also, if we consider the HL grammar an (extensible) extension of the LL grammar, then 
there might be several *stages of refinement* going from the LL language to the HL language.
These factors suggest that a term rewriting system (rule-based) might be suitable.
In this case, we should be able to show that the LL language is a normal form.

It might not be a top priority to convert from LL to HL, but it could 
also be used to illustrate how extending the HL with better constructs
improves the naturalness of the language.

# Sentence translation case studies

## Object type constraints

Let's start with the following equivalent sentences:

 - Datalog:
 
    `error_trackquality(X) :- track(X), !trackQualityClass(X,k0)`.

 - Low level, in Datalog style 

        <constraint id="trackquality" params="X">
           track(X), !trackQualityClass(X,k0)
        </constraint>

 - Low level, in CNL style 

        <constraint id="trackquality" params="X">
           Given {X is a track}, then
           {quality class of X is k0} should be satisifed.
        </constraint>

 - High level CNL could be any of these:
     - `For any track X, the quality class of X must be k0`
     - `All tracks must have quality class k0`.
     - `Every track must have quality class k0`.
     - `A track shall have quality class k0`.
     - `A track must have quality class k0`.


A structure (AST) for this constraint could be 
       
       Constraint = Constraint [Clause] [Clause].
       Clause = Clause Predicate [Parameter].
       Predicate = Predicate String.
       Parameter = Constant String | Variable String.
       
The actual abstract representation we want to express is then the following:
       
       Constraint [Clause (Predicate "track") [Variable "X"]] 
                  [Clause (Predicate "trackQualityClass") [Variable "X", Constant "k0"]]

Instead of the very general "*predicate*", we could instead use
classification, property, association, etc. primitives, so that we get something like:

       Constraint [Class "track" (Variable "X")] 
                  [Property "qualityClass" (Variable "X") (Constant "k0")]

This could maybe help to restrict predicates to one and two parameters for 
user-defined concepts, while allowing special internally defined predicates,
like *distance*, *between*, etc. to have natural linearizations. This could be achieved
through specialization of the grammar for these concepts, instead of supporting arbitrary
higher-arity relations.

## Other examples
### Classification

     A *macroscopic node* is considered a *station boundary*.


### Definition (search)

     A *default train route* consists of two main signals Sa and Sb, 
     both oriented in the direction Dir, such that Sb follows Sa and
     there is a path without signals from Sa to Sb in direction Dir.


### Object properties

     All signal should have a type. / Alle signaler skal være av en signaltype.
     
     
\pagebreak

# Schedule

 - **1 Nov - 14 Dec** Learn GF, make LL CNL, start on HL CNL, before Dec 14, when John takes parental leave. 
 - **1 Jan - 1 Feb** Work with Gerardo when he is back after new year, on the assumptions about logic
   in the verification (Datalog).
 - **Feb 2017?** When CNL is well under way, start exploring 
    - Regulations which need more than Datalog, e.g. SAT solving.
    - Synthesis/constraint solving for railway signalling design.
 - **Mar 2017** Write paper for suitable publication venue. Gerardo will look for possibilities.
     
     
\pagebreak

# Literature list and links

## CNL
 - Thomas Kuhn survey
 - Aarne Ranta, Computational semantics in type theory - Mathématiques et sciences 
 - Hähnle, Johannisson, Ranta, An Authoring Tool for Informal and Formal Requirements Specification
 - Burke, Johannisson, Translating Formal Software Specifications to Natural Language
 - Ranta: translating between logic and language
 - Key Book chapter by Johannisson
 - Bringert, Ranta: A pattern for almost compositional functions

## Applications

 - Emani: An approach for automatic formalization of business rules

## GF
 - Web page 
 
      <http://www.grammaticalframework.org/>
 - Library synopsis 
 
      <http://www.grammaticalframework.org/lib/doc/synopsis.html>
 - MOLTO application grammar building ("best practices") 
 
      <http://www.molto-project.eu/sites/default/files/MOLTO_D2.3.pdf>
 - PhD thesis of Krasimir Angelov


## Tools
 - Minibar 
 
      <http://cloud.grammaticalframework.org/minibar/minibar.html>
 - Syntax editor (tree / linear) 
     
     <http://cloud.grammaticalframework.org/syntax-editor/editor.html>
 - CSE-ID splits sentences (shallow parsing) 

     <http://ad-wiki.informatik.uni-freiburg.de/research/Projects/CSDIE>
 - Illinois chunker also splits sentences (shallow parsing) 
 
     <https://cogcomp.cs.illinois.edu/page/software_view/Chunker>
 - Stanford parser gives complete parses 
 
     <http://nlp.stanford.org/>
