# RailCNL

## Modules

 * RailCNL (main) 
 * Datalog

 * Ontology
   * Classes
   * Properties (=, != <, >)
   * Combine these into selections (subject, object, condition)
   * Constr./obl./rec. that selections have properties.

 * Graph
   * All/exists path from SEL to (first) SEL must/should pass SEL
    (SEL is a selection from the Ontology grammar)
   * Distance from SEL to SEL must be RESTR


### Other modules/features

 * Object placement
   * On bridge, in tunnel, etc.
   * "Where freight trains brake"

 * Sighting

 * Static driving constraints
   * Must not pass more than 4 balise groups per second
     (Define static velocities (sign, atc, max static, max dynamic))
   * Safety zones, residual energy, potential consequences

 * Track design

 * Constructions (geometry)
   * Platforms (relate signalling to constructions)
   * "Things in the way".

 * Catenary design (+ return power, grounding/earthing)

 * Availability, robustness in components
