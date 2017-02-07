abstract Running = Graph** {
  flags startcat=Statement;

  cat 
    VelocitySpec;
    -- Velocity;
    -- TimeInterval; -- Or just String?

  fun

    NominalSpeed : VelocitySpec;

    RunningTimeObligation : VelocitySpec -> Subject -> GoalObject -> Restriction -> Statement;
}
