abstract TracksideObject = Ontology ** {
  cat
    Vector;
  fun
     TrackTangent : Vector;
     OrientationAngleTo : Vector -> Property;
}