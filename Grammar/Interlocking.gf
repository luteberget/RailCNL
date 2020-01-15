abstract Interlocking = Area ** {

  cat 
   SafeDistanceFrom;
   SafeDistanceApproach;
   RouteType;
   ApproachType;
   

  fun 
    TrainRoute, ShuntingRoute : RouteType ;
    FromFlankOr : RouteType ->  SafeDistanceFrom;
    FromArea : Area -> SafeDistanceFrom;
    FromParallell: RouteType -> SafeDistanceFrom;

    ApproachEndPoint,  -- Bak sluttpunkt ved togvei (NSS)
    ApproachEndPointWatchedOnSight, -- Bak sluttpunkt ved kjøring med full overvåkning og kjøring med sikthastighet (FS/OS) (L2)
    ApproachEndPointShunt,  -- Bak sluttpunkt ved skiftebevegelser
    ApproachSR  -- Bak sluttpuntk ved kjøring med særlig ansvar (SR) (L2)
    : ApproachType;

    MkSafeDistanceApproach : ApproachType -> SafeDistanceApproach;
    MkSafeDistanceApproachArea : ApproachType -> Area -> SafeDistanceApproach;
    MkSafeDistanceApproachReleaseSpeed : ApproachType -> Restriction -> SafeDistanceApproach;

    -- Safe distance
    SafeDistance : SafeDistanceApproach -> SafeDistanceFrom -> Restriction -> Statement;
};
