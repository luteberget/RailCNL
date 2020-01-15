public abstract class Tree {
  public abstract PGF.Expression ToExpression();
}

namespace RailCNL {
  public abstract class Area : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAreaPropertyRestriction(RailCNL.NamedArea x1,RailCNL.PropertyRestriction x2);
      R VisitNoRestrictionArea(RailCNL.NamedArea x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.NamedArea,RailCNL.PropertyRestriction,R> _VisitAreaPropertyRestriction { get; set; }
      private System.Func<RailCNL.NamedArea,R> _VisitNoRestrictionArea { get; set; }
      public Visitor(System.Func<RailCNL.NamedArea,RailCNL.PropertyRestriction,R> VisitAreaPropertyRestriction, System.Func<RailCNL.NamedArea,R> VisitNoRestrictionArea) {
        this._VisitAreaPropertyRestriction = VisitAreaPropertyRestriction;
        this._VisitNoRestrictionArea = VisitNoRestrictionArea;
      }
      
      public R VisitAreaPropertyRestriction(RailCNL.NamedArea x1,RailCNL.PropertyRestriction x2) => _VisitAreaPropertyRestriction(x1, x2);
      public R VisitNoRestrictionArea(RailCNL.NamedArea x1) => _VisitNoRestrictionArea(x1);
    }
    
    public static Area FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Area>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AreaPropertyRestriction) && args.Length == 2)
            return new AreaPropertyRestriction(NamedArea.FromExpression(args[0]), PropertyRestriction.FromExpression(args[1]));
          if(fname == nameof(NoRestrictionArea) && args.Length == 1)
            return new NoRestrictionArea(NamedArea.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AreaPropertyRestriction : Area {
    public RailCNL.NamedArea x1 {get; set;}
    public RailCNL.PropertyRestriction x2 {get; set;}
    public AreaPropertyRestriction(RailCNL.NamedArea x1, RailCNL.PropertyRestriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAreaPropertyRestriction(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AreaPropertyRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class NoRestrictionArea : Area {
    public RailCNL.NamedArea x1 {get; set;}
    public NoRestrictionArea(RailCNL.NamedArea x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNoRestrictionArea(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(NoRestrictionArea), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class AreaConj : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAndArea(RailCNL.AreaConj x1,RailCNL.AreaConj x2);
      R VisitOrArea(RailCNL.AreaConj x1,RailCNL.AreaConj x2);
      R VisitSingleArea(RailCNL.Area x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.AreaConj,RailCNL.AreaConj,R> _VisitAndArea { get; set; }
      private System.Func<RailCNL.AreaConj,RailCNL.AreaConj,R> _VisitOrArea { get; set; }
      private System.Func<RailCNL.Area,R> _VisitSingleArea { get; set; }
      public Visitor(System.Func<RailCNL.AreaConj,RailCNL.AreaConj,R> VisitAndArea, System.Func<RailCNL.AreaConj,RailCNL.AreaConj,R> VisitOrArea, System.Func<RailCNL.Area,R> VisitSingleArea) {
        this._VisitAndArea = VisitAndArea;
        this._VisitOrArea = VisitOrArea;
        this._VisitSingleArea = VisitSingleArea;
      }
      
      public R VisitAndArea(RailCNL.AreaConj x1,RailCNL.AreaConj x2) => _VisitAndArea(x1, x2);
      public R VisitOrArea(RailCNL.AreaConj x1,RailCNL.AreaConj x2) => _VisitOrArea(x1, x2);
      public R VisitSingleArea(RailCNL.Area x1) => _VisitSingleArea(x1);
    }
    
    public static AreaConj FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<AreaConj>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AndArea) && args.Length == 2)
            return new AndArea(AreaConj.FromExpression(args[0]), AreaConj.FromExpression(args[1]));
          if(fname == nameof(OrArea) && args.Length == 2)
            return new OrArea(AreaConj.FromExpression(args[0]), AreaConj.FromExpression(args[1]));
          if(fname == nameof(SingleArea) && args.Length == 1)
            return new SingleArea(Area.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AndArea : AreaConj {
    public RailCNL.AreaConj x1 {get; set;}
    public RailCNL.AreaConj x2 {get; set;}
    public AndArea(RailCNL.AreaConj x1, RailCNL.AreaConj x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAndArea(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AndArea), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class OrArea : AreaConj {
    public RailCNL.AreaConj x1 {get; set;}
    public RailCNL.AreaConj x2 {get; set;}
    public OrArea(RailCNL.AreaConj x1, RailCNL.AreaConj x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOrArea(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OrArea), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class SingleArea : AreaConj {
    public RailCNL.Area x1 {get; set;}
    public SingleArea(RailCNL.Area x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSingleArea(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SingleArea), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class BaseArea : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitBridgeArea();
      R VisitLocalReleaseArea();
      R VisitMkNamedArea(string x1);
      R VisitTunnelArea();
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<R> _VisitBridgeArea { get; set; }
      private System.Func<R> _VisitLocalReleaseArea { get; set; }
      private System.Func<string,R> _VisitMkNamedArea { get; set; }
      private System.Func<R> _VisitTunnelArea { get; set; }
      public Visitor(System.Func<R> VisitBridgeArea, System.Func<R> VisitLocalReleaseArea, System.Func<string,R> VisitMkNamedArea, System.Func<R> VisitTunnelArea) {
        this._VisitBridgeArea = VisitBridgeArea;
        this._VisitLocalReleaseArea = VisitLocalReleaseArea;
        this._VisitMkNamedArea = VisitMkNamedArea;
        this._VisitTunnelArea = VisitTunnelArea;
      }
      
      public R VisitBridgeArea() => _VisitBridgeArea();
      public R VisitLocalReleaseArea() => _VisitLocalReleaseArea();
      public R VisitMkNamedArea(string x1) => _VisitMkNamedArea(x1);
      public R VisitTunnelArea() => _VisitTunnelArea();
    }
    
    public static BaseArea FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<BaseArea>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(BridgeArea) && args.Length == 0)
            return new BridgeArea();
          if(fname == nameof(LocalReleaseArea) && args.Length == 0)
            return new LocalReleaseArea();
          if(fname == nameof(MkNamedArea) && args.Length == 1)
            return new MkNamedArea(((PGF.LiteralString)args[0]).Value);
          if(fname == nameof(TunnelArea) && args.Length == 0)
            return new TunnelArea();
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class BridgeArea : BaseArea {
    public BridgeArea() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitBridgeArea();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(BridgeArea), new PGF.Expression[]{});
    }
    
  }
  
  public class LocalReleaseArea : BaseArea {
    public LocalReleaseArea() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLocalReleaseArea();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(LocalReleaseArea), new PGF.Expression[]{});
    }
    
  }
  
  public class MkNamedArea : BaseArea {
    public string x1 {get; set;}
    public MkNamedArea(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitMkNamedArea(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(MkNamedArea), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public class TunnelArea : BaseArea {
    public TunnelArea() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitTunnelArea();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(TunnelArea), new PGF.Expression[]{});
    }
    
  }
  
  public abstract class BaseClass : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitStringClassFeminine(string x1);
      R VisitStringClassMasculine(string x1);
      R VisitStringClassNeutrum(string x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<string,R> _VisitStringClassFeminine { get; set; }
      private System.Func<string,R> _VisitStringClassMasculine { get; set; }
      private System.Func<string,R> _VisitStringClassNeutrum { get; set; }
      public Visitor(System.Func<string,R> VisitStringClassFeminine, System.Func<string,R> VisitStringClassMasculine, System.Func<string,R> VisitStringClassNeutrum) {
        this._VisitStringClassFeminine = VisitStringClassFeminine;
        this._VisitStringClassMasculine = VisitStringClassMasculine;
        this._VisitStringClassNeutrum = VisitStringClassNeutrum;
      }
      
      public R VisitStringClassFeminine(string x1) => _VisitStringClassFeminine(x1);
      public R VisitStringClassMasculine(string x1) => _VisitStringClassMasculine(x1);
      public R VisitStringClassNeutrum(string x1) => _VisitStringClassNeutrum(x1);
    }
    
    public static BaseClass FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<BaseClass>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(StringClassFeminine) && args.Length == 1)
            return new StringClassFeminine(((PGF.LiteralString)args[0]).Value);
          if(fname == nameof(StringClassMasculine) && args.Length == 1)
            return new StringClassMasculine(((PGF.LiteralString)args[0]).Value);
          if(fname == nameof(StringClassNeutrum) && args.Length == 1)
            return new StringClassNeutrum(((PGF.LiteralString)args[0]).Value);
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class StringClassFeminine : BaseClass {
    public string x1 {get; set;}
    public StringClassFeminine(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringClassFeminine(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringClassFeminine), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public class StringClassMasculine : BaseClass {
    public string x1 {get; set;}
    public StringClassMasculine(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringClassMasculine(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringClassMasculine), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public class StringClassNeutrum : BaseClass {
    public string x1 {get; set;}
    public StringClassNeutrum(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringClassNeutrum(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringClassNeutrum), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public abstract class Class : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitStringClassAdjective(string x1,RailCNL.BaseClass x2);
      R VisitStringClassNoAdjective(RailCNL.BaseClass x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<string,RailCNL.BaseClass,R> _VisitStringClassAdjective { get; set; }
      private System.Func<RailCNL.BaseClass,R> _VisitStringClassNoAdjective { get; set; }
      public Visitor(System.Func<string,RailCNL.BaseClass,R> VisitStringClassAdjective, System.Func<RailCNL.BaseClass,R> VisitStringClassNoAdjective) {
        this._VisitStringClassAdjective = VisitStringClassAdjective;
        this._VisitStringClassNoAdjective = VisitStringClassNoAdjective;
      }
      
      public R VisitStringClassAdjective(string x1,RailCNL.BaseClass x2) => _VisitStringClassAdjective(x1, x2);
      public R VisitStringClassNoAdjective(RailCNL.BaseClass x1) => _VisitStringClassNoAdjective(x1);
    }
    
    public static Class FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Class>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(StringClassAdjective) && args.Length == 2)
            return new StringClassAdjective(((PGF.LiteralString)args[0]).Value, BaseClass.FromExpression(args[1]));
          if(fname == nameof(StringClassNoAdjective) && args.Length == 1)
            return new StringClassNoAdjective(BaseClass.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class StringClassAdjective : Class {
    public string x1 {get; set;}
    public RailCNL.BaseClass x2 {get; set;}
    public StringClassAdjective(string x1, RailCNL.BaseClass x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringClassAdjective(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringClassAdjective), new PGF.Expression[]{new PGF.LiteralString(x1), x2.ToExpression()});
    }
    
  }
  
  public class StringClassNoAdjective : Class {
    public RailCNL.BaseClass x1 {get; set;}
    public StringClassNoAdjective(RailCNL.BaseClass x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringClassNoAdjective(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringClassNoAdjective), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class ClassRestriction : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAndClassRestr(RailCNL.ClassRestriction x1,RailCNL.ClassRestriction x2);
      R VisitMkClassRestriction(RailCNL.Class x1);
      R VisitOrClassRestr(RailCNL.ClassRestriction x1,RailCNL.ClassRestriction x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.ClassRestriction,RailCNL.ClassRestriction,R> _VisitAndClassRestr { get; set; }
      private System.Func<RailCNL.Class,R> _VisitMkClassRestriction { get; set; }
      private System.Func<RailCNL.ClassRestriction,RailCNL.ClassRestriction,R> _VisitOrClassRestr { get; set; }
      public Visitor(System.Func<RailCNL.ClassRestriction,RailCNL.ClassRestriction,R> VisitAndClassRestr, System.Func<RailCNL.Class,R> VisitMkClassRestriction, System.Func<RailCNL.ClassRestriction,RailCNL.ClassRestriction,R> VisitOrClassRestr) {
        this._VisitAndClassRestr = VisitAndClassRestr;
        this._VisitMkClassRestriction = VisitMkClassRestriction;
        this._VisitOrClassRestr = VisitOrClassRestr;
      }
      
      public R VisitAndClassRestr(RailCNL.ClassRestriction x1,RailCNL.ClassRestriction x2) => _VisitAndClassRestr(x1, x2);
      public R VisitMkClassRestriction(RailCNL.Class x1) => _VisitMkClassRestriction(x1);
      public R VisitOrClassRestr(RailCNL.ClassRestriction x1,RailCNL.ClassRestriction x2) => _VisitOrClassRestr(x1, x2);
    }
    
    public static ClassRestriction FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<ClassRestriction>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AndClassRestr) && args.Length == 2)
            return new AndClassRestr(ClassRestriction.FromExpression(args[0]), ClassRestriction.FromExpression(args[1]));
          if(fname == nameof(MkClassRestriction) && args.Length == 1)
            return new MkClassRestriction(Class.FromExpression(args[0]));
          if(fname == nameof(OrClassRestr) && args.Length == 2)
            return new OrClassRestr(ClassRestriction.FromExpression(args[0]), ClassRestriction.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AndClassRestr : ClassRestriction {
    public RailCNL.ClassRestriction x1 {get; set;}
    public RailCNL.ClassRestriction x2 {get; set;}
    public AndClassRestr(RailCNL.ClassRestriction x1, RailCNL.ClassRestriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAndClassRestr(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AndClassRestr), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class MkClassRestriction : ClassRestriction {
    public RailCNL.Class x1 {get; set;}
    public MkClassRestriction(RailCNL.Class x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitMkClassRestriction(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(MkClassRestriction), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class OrClassRestr : ClassRestriction {
    public RailCNL.ClassRestriction x1 {get; set;}
    public RailCNL.ClassRestriction x2 {get; set;}
    public OrClassRestr(RailCNL.ClassRestriction x1, RailCNL.ClassRestriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOrClassRestr(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OrClassRestr), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public abstract class Condition : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitConditionClassAndPropertyRestriction(RailCNL.Class x1,RailCNL.PropertyRestriction x2);
      R VisitConditionClassRestriction(RailCNL.ClassRestriction x1);
      R VisitConditionPropertyRestriction(RailCNL.PropertyRestriction x1);
      R VisitConditionRelationRestriction(RailCNL.RelationMultiplicity x1,RailCNL.Class x2);
      R VisitConditionRelationWithPropertyRestriction(RailCNL.RelationMultiplicity x1,RailCNL.Class x2,RailCNL.PropertyRestriction x3);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Class,RailCNL.PropertyRestriction,R> _VisitConditionClassAndPropertyRestriction { get; set; }
      private System.Func<RailCNL.ClassRestriction,R> _VisitConditionClassRestriction { get; set; }
      private System.Func<RailCNL.PropertyRestriction,R> _VisitConditionPropertyRestriction { get; set; }
      private System.Func<RailCNL.RelationMultiplicity,RailCNL.Class,R> _VisitConditionRelationRestriction { get; set; }
      private System.Func<RailCNL.RelationMultiplicity,RailCNL.Class,RailCNL.PropertyRestriction,R> _VisitConditionRelationWithPropertyRestriction { get; set; }
      public Visitor(System.Func<RailCNL.Class,RailCNL.PropertyRestriction,R> VisitConditionClassAndPropertyRestriction, System.Func<RailCNL.ClassRestriction,R> VisitConditionClassRestriction, System.Func<RailCNL.PropertyRestriction,R> VisitConditionPropertyRestriction, System.Func<RailCNL.RelationMultiplicity,RailCNL.Class,R> VisitConditionRelationRestriction, System.Func<RailCNL.RelationMultiplicity,RailCNL.Class,RailCNL.PropertyRestriction,R> VisitConditionRelationWithPropertyRestriction) {
        this._VisitConditionClassAndPropertyRestriction = VisitConditionClassAndPropertyRestriction;
        this._VisitConditionClassRestriction = VisitConditionClassRestriction;
        this._VisitConditionPropertyRestriction = VisitConditionPropertyRestriction;
        this._VisitConditionRelationRestriction = VisitConditionRelationRestriction;
        this._VisitConditionRelationWithPropertyRestriction = VisitConditionRelationWithPropertyRestriction;
      }
      
      public R VisitConditionClassAndPropertyRestriction(RailCNL.Class x1,RailCNL.PropertyRestriction x2) => _VisitConditionClassAndPropertyRestriction(x1, x2);
      public R VisitConditionClassRestriction(RailCNL.ClassRestriction x1) => _VisitConditionClassRestriction(x1);
      public R VisitConditionPropertyRestriction(RailCNL.PropertyRestriction x1) => _VisitConditionPropertyRestriction(x1);
      public R VisitConditionRelationRestriction(RailCNL.RelationMultiplicity x1,RailCNL.Class x2) => _VisitConditionRelationRestriction(x1, x2);
      public R VisitConditionRelationWithPropertyRestriction(RailCNL.RelationMultiplicity x1,RailCNL.Class x2,RailCNL.PropertyRestriction x3) => _VisitConditionRelationWithPropertyRestriction(x1, x2, x3);
    }
    
    public static Condition FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Condition>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(ConditionClassAndPropertyRestriction) && args.Length == 2)
            return new ConditionClassAndPropertyRestriction(Class.FromExpression(args[0]), PropertyRestriction.FromExpression(args[1]));
          if(fname == nameof(ConditionClassRestriction) && args.Length == 1)
            return new ConditionClassRestriction(ClassRestriction.FromExpression(args[0]));
          if(fname == nameof(ConditionPropertyRestriction) && args.Length == 1)
            return new ConditionPropertyRestriction(PropertyRestriction.FromExpression(args[0]));
          if(fname == nameof(ConditionRelationRestriction) && args.Length == 2)
            return new ConditionRelationRestriction(RelationMultiplicity.FromExpression(args[0]), Class.FromExpression(args[1]));
          if(fname == nameof(ConditionRelationWithPropertyRestriction) && args.Length == 3)
            return new ConditionRelationWithPropertyRestriction(RelationMultiplicity.FromExpression(args[0]), Class.FromExpression(args[1]), PropertyRestriction.FromExpression(args[2]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class ConditionClassAndPropertyRestriction : Condition {
    public RailCNL.Class x1 {get; set;}
    public RailCNL.PropertyRestriction x2 {get; set;}
    public ConditionClassAndPropertyRestriction(RailCNL.Class x1, RailCNL.PropertyRestriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitConditionClassAndPropertyRestriction(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ConditionClassAndPropertyRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class ConditionClassRestriction : Condition {
    public RailCNL.ClassRestriction x1 {get; set;}
    public ConditionClassRestriction(RailCNL.ClassRestriction x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitConditionClassRestriction(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ConditionClassRestriction), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class ConditionPropertyRestriction : Condition {
    public RailCNL.PropertyRestriction x1 {get; set;}
    public ConditionPropertyRestriction(RailCNL.PropertyRestriction x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitConditionPropertyRestriction(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ConditionPropertyRestriction), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class ConditionRelationRestriction : Condition {
    public RailCNL.RelationMultiplicity x1 {get; set;}
    public RailCNL.Class x2 {get; set;}
    public ConditionRelationRestriction(RailCNL.RelationMultiplicity x1, RailCNL.Class x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitConditionRelationRestriction(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ConditionRelationRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class ConditionRelationWithPropertyRestriction : Condition {
    public RailCNL.RelationMultiplicity x1 {get; set;}
    public RailCNL.Class x2 {get; set;}
    public RailCNL.PropertyRestriction x3 {get; set;}
    public ConditionRelationWithPropertyRestriction(RailCNL.RelationMultiplicity x1, RailCNL.Class x2, RailCNL.PropertyRestriction x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitConditionRelationWithPropertyRestriction(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ConditionRelationWithPropertyRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public abstract class Conjunction : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitConj(RailCNL.Conjunction x1,RailCNL.Conjunction x2);
      R VisitEqLit(RailCNL.Term x1,RailCNL.Term x2);
      R VisitGtLit(RailCNL.Term x1,RailCNL.Term x2);
      R VisitGteLit(RailCNL.Term x1,RailCNL.Term x2);
      R VisitLtLit(RailCNL.Term x1,RailCNL.Term x2);
      R VisitLteLit(RailCNL.Term x1,RailCNL.Term x2);
      R VisitNegation(RailCNL.Literal x1);
      R VisitNeqLit(RailCNL.Term x1,RailCNL.Term x2);
      R VisitSimpleConj(RailCNL.Literal x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Conjunction,RailCNL.Conjunction,R> _VisitConj { get; set; }
      private System.Func<RailCNL.Term,RailCNL.Term,R> _VisitEqLit { get; set; }
      private System.Func<RailCNL.Term,RailCNL.Term,R> _VisitGtLit { get; set; }
      private System.Func<RailCNL.Term,RailCNL.Term,R> _VisitGteLit { get; set; }
      private System.Func<RailCNL.Term,RailCNL.Term,R> _VisitLtLit { get; set; }
      private System.Func<RailCNL.Term,RailCNL.Term,R> _VisitLteLit { get; set; }
      private System.Func<RailCNL.Literal,R> _VisitNegation { get; set; }
      private System.Func<RailCNL.Term,RailCNL.Term,R> _VisitNeqLit { get; set; }
      private System.Func<RailCNL.Literal,R> _VisitSimpleConj { get; set; }
      public Visitor(System.Func<RailCNL.Conjunction,RailCNL.Conjunction,R> VisitConj, System.Func<RailCNL.Term,RailCNL.Term,R> VisitEqLit, System.Func<RailCNL.Term,RailCNL.Term,R> VisitGtLit, System.Func<RailCNL.Term,RailCNL.Term,R> VisitGteLit, System.Func<RailCNL.Term,RailCNL.Term,R> VisitLtLit, System.Func<RailCNL.Term,RailCNL.Term,R> VisitLteLit, System.Func<RailCNL.Literal,R> VisitNegation, System.Func<RailCNL.Term,RailCNL.Term,R> VisitNeqLit, System.Func<RailCNL.Literal,R> VisitSimpleConj) {
        this._VisitConj = VisitConj;
        this._VisitEqLit = VisitEqLit;
        this._VisitGtLit = VisitGtLit;
        this._VisitGteLit = VisitGteLit;
        this._VisitLtLit = VisitLtLit;
        this._VisitLteLit = VisitLteLit;
        this._VisitNegation = VisitNegation;
        this._VisitNeqLit = VisitNeqLit;
        this._VisitSimpleConj = VisitSimpleConj;
      }
      
      public R VisitConj(RailCNL.Conjunction x1,RailCNL.Conjunction x2) => _VisitConj(x1, x2);
      public R VisitEqLit(RailCNL.Term x1,RailCNL.Term x2) => _VisitEqLit(x1, x2);
      public R VisitGtLit(RailCNL.Term x1,RailCNL.Term x2) => _VisitGtLit(x1, x2);
      public R VisitGteLit(RailCNL.Term x1,RailCNL.Term x2) => _VisitGteLit(x1, x2);
      public R VisitLtLit(RailCNL.Term x1,RailCNL.Term x2) => _VisitLtLit(x1, x2);
      public R VisitLteLit(RailCNL.Term x1,RailCNL.Term x2) => _VisitLteLit(x1, x2);
      public R VisitNegation(RailCNL.Literal x1) => _VisitNegation(x1);
      public R VisitNeqLit(RailCNL.Term x1,RailCNL.Term x2) => _VisitNeqLit(x1, x2);
      public R VisitSimpleConj(RailCNL.Literal x1) => _VisitSimpleConj(x1);
    }
    
    public static Conjunction FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Conjunction>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(Conj) && args.Length == 2)
            return new Conj(Conjunction.FromExpression(args[0]), Conjunction.FromExpression(args[1]));
          if(fname == nameof(EqLit) && args.Length == 2)
            return new EqLit(Term.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(GtLit) && args.Length == 2)
            return new GtLit(Term.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(GteLit) && args.Length == 2)
            return new GteLit(Term.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(LtLit) && args.Length == 2)
            return new LtLit(Term.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(LteLit) && args.Length == 2)
            return new LteLit(Term.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(Negation) && args.Length == 1)
            return new Negation(Literal.FromExpression(args[0]));
          if(fname == nameof(NeqLit) && args.Length == 2)
            return new NeqLit(Term.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(SimpleConj) && args.Length == 1)
            return new SimpleConj(Literal.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class Conj : Conjunction {
    public RailCNL.Conjunction x1 {get; set;}
    public RailCNL.Conjunction x2 {get; set;}
    public Conj(RailCNL.Conjunction x1, RailCNL.Conjunction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitConj(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Conj), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class EqLit : Conjunction {
    public RailCNL.Term x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public EqLit(RailCNL.Term x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitEqLit(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(EqLit), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class GtLit : Conjunction {
    public RailCNL.Term x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public GtLit(RailCNL.Term x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitGtLit(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(GtLit), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class GteLit : Conjunction {
    public RailCNL.Term x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public GteLit(RailCNL.Term x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitGteLit(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(GteLit), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class LtLit : Conjunction {
    public RailCNL.Term x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public LtLit(RailCNL.Term x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLtLit(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(LtLit), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class LteLit : Conjunction {
    public RailCNL.Term x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public LteLit(RailCNL.Term x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLteLit(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(LteLit), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class Negation : Conjunction {
    public RailCNL.Literal x1 {get; set;}
    public Negation(RailCNL.Literal x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNegation(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Negation), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class NeqLit : Conjunction {
    public RailCNL.Term x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public NeqLit(RailCNL.Term x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNeqLit(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(NeqLit), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class SimpleConj : Conjunction {
    public RailCNL.Literal x1 {get; set;}
    public SimpleConj(RailCNL.Literal x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSimpleConj(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SimpleConj), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class DirectionalObject : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAnyDirectionObject(RailCNL.SearchSubject x1);
      R VisitFacingSwitch();
      R VisitOppositeDirectionObject(RailCNL.SearchSubject x1);
      R VisitOppositeSearchDirecitonObject(RailCNL.SearchSubject x1);
      R VisitSameDirectionObject(RailCNL.SearchSubject x1);
      R VisitSearchDirectionObject(RailCNL.SearchSubject x1);
      R VisitTrailingSwitch();
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.SearchSubject,R> _VisitAnyDirectionObject { get; set; }
      private System.Func<R> _VisitFacingSwitch { get; set; }
      private System.Func<RailCNL.SearchSubject,R> _VisitOppositeDirectionObject { get; set; }
      private System.Func<RailCNL.SearchSubject,R> _VisitOppositeSearchDirecitonObject { get; set; }
      private System.Func<RailCNL.SearchSubject,R> _VisitSameDirectionObject { get; set; }
      private System.Func<RailCNL.SearchSubject,R> _VisitSearchDirectionObject { get; set; }
      private System.Func<R> _VisitTrailingSwitch { get; set; }
      public Visitor(System.Func<RailCNL.SearchSubject,R> VisitAnyDirectionObject, System.Func<R> VisitFacingSwitch, System.Func<RailCNL.SearchSubject,R> VisitOppositeDirectionObject, System.Func<RailCNL.SearchSubject,R> VisitOppositeSearchDirecitonObject, System.Func<RailCNL.SearchSubject,R> VisitSameDirectionObject, System.Func<RailCNL.SearchSubject,R> VisitSearchDirectionObject, System.Func<R> VisitTrailingSwitch) {
        this._VisitAnyDirectionObject = VisitAnyDirectionObject;
        this._VisitFacingSwitch = VisitFacingSwitch;
        this._VisitOppositeDirectionObject = VisitOppositeDirectionObject;
        this._VisitOppositeSearchDirecitonObject = VisitOppositeSearchDirecitonObject;
        this._VisitSameDirectionObject = VisitSameDirectionObject;
        this._VisitSearchDirectionObject = VisitSearchDirectionObject;
        this._VisitTrailingSwitch = VisitTrailingSwitch;
      }
      
      public R VisitAnyDirectionObject(RailCNL.SearchSubject x1) => _VisitAnyDirectionObject(x1);
      public R VisitFacingSwitch() => _VisitFacingSwitch();
      public R VisitOppositeDirectionObject(RailCNL.SearchSubject x1) => _VisitOppositeDirectionObject(x1);
      public R VisitOppositeSearchDirecitonObject(RailCNL.SearchSubject x1) => _VisitOppositeSearchDirecitonObject(x1);
      public R VisitSameDirectionObject(RailCNL.SearchSubject x1) => _VisitSameDirectionObject(x1);
      public R VisitSearchDirectionObject(RailCNL.SearchSubject x1) => _VisitSearchDirectionObject(x1);
      public R VisitTrailingSwitch() => _VisitTrailingSwitch();
    }
    
    public static DirectionalObject FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<DirectionalObject>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AnyDirectionObject) && args.Length == 1)
            return new AnyDirectionObject(SearchSubject.FromExpression(args[0]));
          if(fname == nameof(FacingSwitch) && args.Length == 0)
            return new FacingSwitch();
          if(fname == nameof(OppositeDirectionObject) && args.Length == 1)
            return new OppositeDirectionObject(SearchSubject.FromExpression(args[0]));
          if(fname == nameof(OppositeSearchDirecitonObject) && args.Length == 1)
            return new OppositeSearchDirecitonObject(SearchSubject.FromExpression(args[0]));
          if(fname == nameof(SameDirectionObject) && args.Length == 1)
            return new SameDirectionObject(SearchSubject.FromExpression(args[0]));
          if(fname == nameof(SearchDirectionObject) && args.Length == 1)
            return new SearchDirectionObject(SearchSubject.FromExpression(args[0]));
          if(fname == nameof(TrailingSwitch) && args.Length == 0)
            return new TrailingSwitch();
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AnyDirectionObject : DirectionalObject {
    public RailCNL.SearchSubject x1 {get; set;}
    public AnyDirectionObject(RailCNL.SearchSubject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAnyDirectionObject(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AnyDirectionObject), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class FacingSwitch : DirectionalObject {
    public FacingSwitch() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitFacingSwitch();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(FacingSwitch), new PGF.Expression[]{});
    }
    
  }
  
  public class OppositeDirectionObject : DirectionalObject {
    public RailCNL.SearchSubject x1 {get; set;}
    public OppositeDirectionObject(RailCNL.SearchSubject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOppositeDirectionObject(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OppositeDirectionObject), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class OppositeSearchDirecitonObject : DirectionalObject {
    public RailCNL.SearchSubject x1 {get; set;}
    public OppositeSearchDirecitonObject(RailCNL.SearchSubject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOppositeSearchDirecitonObject(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OppositeSearchDirecitonObject), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class SameDirectionObject : DirectionalObject {
    public RailCNL.SearchSubject x1 {get; set;}
    public SameDirectionObject(RailCNL.SearchSubject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSameDirectionObject(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SameDirectionObject), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class SearchDirectionObject : DirectionalObject {
    public RailCNL.SearchSubject x1 {get; set;}
    public SearchDirectionObject(RailCNL.SearchSubject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSearchDirectionObject(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SearchDirectionObject), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class TrailingSwitch : DirectionalObject {
    public TrailingSwitch() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitTrailingSwitch();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(TrailingSwitch), new PGF.Expression[]{});
    }
    
  }
  
  public abstract class Float : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
    }
    
    public class Visitor<R> : IVisitor<R> {
      public Visitor() {
      }
      
    }
    
    public static Float FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Float>() {
        fVisitApplication = (fname,args) =>  {
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public abstract class GoalObject : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAnyFound(RailCNL.DirectionalObject x1);
      R VisitFirstFound(RailCNL.DirectionalObject x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.DirectionalObject,R> _VisitAnyFound { get; set; }
      private System.Func<RailCNL.DirectionalObject,R> _VisitFirstFound { get; set; }
      public Visitor(System.Func<RailCNL.DirectionalObject,R> VisitAnyFound, System.Func<RailCNL.DirectionalObject,R> VisitFirstFound) {
        this._VisitAnyFound = VisitAnyFound;
        this._VisitFirstFound = VisitFirstFound;
      }
      
      public R VisitAnyFound(RailCNL.DirectionalObject x1) => _VisitAnyFound(x1);
      public R VisitFirstFound(RailCNL.DirectionalObject x1) => _VisitFirstFound(x1);
    }
    
    public static GoalObject FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<GoalObject>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AnyFound) && args.Length == 1)
            return new AnyFound(DirectionalObject.FromExpression(args[0]));
          if(fname == nameof(FirstFound) && args.Length == 1)
            return new FirstFound(DirectionalObject.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AnyFound : GoalObject {
    public RailCNL.DirectionalObject x1 {get; set;}
    public AnyFound(RailCNL.DirectionalObject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAnyFound(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AnyFound), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class FirstFound : GoalObject {
    public RailCNL.DirectionalObject x1 {get; set;}
    public FirstFound(RailCNL.DirectionalObject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitFirstFound(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(FirstFound), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class Int : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
    }
    
    public class Visitor<R> : IVisitor<R> {
      public Visitor() {
      }
      
    }
    
    public static Int FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Int>() {
        fVisitApplication = (fname,args) =>  {
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public abstract class Literal : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitLiteral0(RailCNL.Predicate x1);
      R VisitLiteral1(RailCNL.Predicate x1,RailCNL.Term x2);
      R VisitLiteral2(RailCNL.Predicate x1,RailCNL.Term x2,RailCNL.Term x3);
      R VisitLiteral3(RailCNL.Predicate x1,RailCNL.Term x2,RailCNL.Term x3,RailCNL.Term x4);
      R VisitLiteral4(RailCNL.Predicate x1,RailCNL.Term x2,RailCNL.Term x3,RailCNL.Term x4,RailCNL.Term x5);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Predicate,R> _VisitLiteral0 { get; set; }
      private System.Func<RailCNL.Predicate,RailCNL.Term,R> _VisitLiteral1 { get; set; }
      private System.Func<RailCNL.Predicate,RailCNL.Term,RailCNL.Term,R> _VisitLiteral2 { get; set; }
      private System.Func<RailCNL.Predicate,RailCNL.Term,RailCNL.Term,RailCNL.Term,R> _VisitLiteral3 { get; set; }
      private System.Func<RailCNL.Predicate,RailCNL.Term,RailCNL.Term,RailCNL.Term,RailCNL.Term,R> _VisitLiteral4 { get; set; }
      public Visitor(System.Func<RailCNL.Predicate,R> VisitLiteral0, System.Func<RailCNL.Predicate,RailCNL.Term,R> VisitLiteral1, System.Func<RailCNL.Predicate,RailCNL.Term,RailCNL.Term,R> VisitLiteral2, System.Func<RailCNL.Predicate,RailCNL.Term,RailCNL.Term,RailCNL.Term,R> VisitLiteral3, System.Func<RailCNL.Predicate,RailCNL.Term,RailCNL.Term,RailCNL.Term,RailCNL.Term,R> VisitLiteral4) {
        this._VisitLiteral0 = VisitLiteral0;
        this._VisitLiteral1 = VisitLiteral1;
        this._VisitLiteral2 = VisitLiteral2;
        this._VisitLiteral3 = VisitLiteral3;
        this._VisitLiteral4 = VisitLiteral4;
      }
      
      public R VisitLiteral0(RailCNL.Predicate x1) => _VisitLiteral0(x1);
      public R VisitLiteral1(RailCNL.Predicate x1,RailCNL.Term x2) => _VisitLiteral1(x1, x2);
      public R VisitLiteral2(RailCNL.Predicate x1,RailCNL.Term x2,RailCNL.Term x3) => _VisitLiteral2(x1, x2, x3);
      public R VisitLiteral3(RailCNL.Predicate x1,RailCNL.Term x2,RailCNL.Term x3,RailCNL.Term x4) => _VisitLiteral3(x1, x2, x3, x4);
      public R VisitLiteral4(RailCNL.Predicate x1,RailCNL.Term x2,RailCNL.Term x3,RailCNL.Term x4,RailCNL.Term x5) => _VisitLiteral4(x1, x2, x3, x4, x5);
    }
    
    public static Literal FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Literal>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(Literal0) && args.Length == 1)
            return new Literal0(Predicate.FromExpression(args[0]));
          if(fname == nameof(Literal1) && args.Length == 2)
            return new Literal1(Predicate.FromExpression(args[0]), Term.FromExpression(args[1]));
          if(fname == nameof(Literal2) && args.Length == 3)
            return new Literal2(Predicate.FromExpression(args[0]), Term.FromExpression(args[1]), Term.FromExpression(args[2]));
          if(fname == nameof(Literal3) && args.Length == 4)
            return new Literal3(Predicate.FromExpression(args[0]), Term.FromExpression(args[1]), Term.FromExpression(args[2]), Term.FromExpression(args[3]));
          if(fname == nameof(Literal4) && args.Length == 5)
            return new Literal4(Predicate.FromExpression(args[0]), Term.FromExpression(args[1]), Term.FromExpression(args[2]), Term.FromExpression(args[3]), Term.FromExpression(args[4]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class Literal0 : Literal {
    public RailCNL.Predicate x1 {get; set;}
    public Literal0(RailCNL.Predicate x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLiteral0(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Literal0), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class Literal1 : Literal {
    public RailCNL.Predicate x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public Literal1(RailCNL.Predicate x1, RailCNL.Term x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLiteral1(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Literal1), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class Literal2 : Literal {
    public RailCNL.Predicate x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public RailCNL.Term x3 {get; set;}
    public Literal2(RailCNL.Predicate x1, RailCNL.Term x2, RailCNL.Term x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLiteral2(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Literal2), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public class Literal3 : Literal {
    public RailCNL.Predicate x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public RailCNL.Term x3 {get; set;}
    public RailCNL.Term x4 {get; set;}
    public Literal3(RailCNL.Predicate x1, RailCNL.Term x2, RailCNL.Term x3, RailCNL.Term x4) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
      this.x4 = x4;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLiteral3(x1, x2, x3, x4);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Literal3), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression(), x4.ToExpression()});
    }
    
  }
  
  public class Literal4 : Literal {
    public RailCNL.Predicate x1 {get; set;}
    public RailCNL.Term x2 {get; set;}
    public RailCNL.Term x3 {get; set;}
    public RailCNL.Term x4 {get; set;}
    public RailCNL.Term x5 {get; set;}
    public Literal4(RailCNL.Predicate x1, RailCNL.Term x2, RailCNL.Term x3, RailCNL.Term x4, RailCNL.Term x5) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
      this.x4 = x4;
      this.x5 = x5;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLiteral4(x1, x2, x3, x4, x5);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Literal4), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression(), x4.ToExpression(), x5.ToExpression()});
    }
    
  }
  
  public abstract class Modality : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitNegativeObligation();
      R VisitNegativeRecommendation();
      R VisitObligation();
      R VisitRecommendation();
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<R> _VisitNegativeObligation { get; set; }
      private System.Func<R> _VisitNegativeRecommendation { get; set; }
      private System.Func<R> _VisitObligation { get; set; }
      private System.Func<R> _VisitRecommendation { get; set; }
      public Visitor(System.Func<R> VisitNegativeObligation, System.Func<R> VisitNegativeRecommendation, System.Func<R> VisitObligation, System.Func<R> VisitRecommendation) {
        this._VisitNegativeObligation = VisitNegativeObligation;
        this._VisitNegativeRecommendation = VisitNegativeRecommendation;
        this._VisitObligation = VisitObligation;
        this._VisitRecommendation = VisitRecommendation;
      }
      
      public R VisitNegativeObligation() => _VisitNegativeObligation();
      public R VisitNegativeRecommendation() => _VisitNegativeRecommendation();
      public R VisitObligation() => _VisitObligation();
      public R VisitRecommendation() => _VisitRecommendation();
    }
    
    public static Modality FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Modality>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(NegativeObligation) && args.Length == 0)
            return new NegativeObligation();
          if(fname == nameof(NegativeRecommendation) && args.Length == 0)
            return new NegativeRecommendation();
          if(fname == nameof(Obligation) && args.Length == 0)
            return new Obligation();
          if(fname == nameof(Recommendation) && args.Length == 0)
            return new Recommendation();
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class NegativeObligation : Modality {
    public NegativeObligation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNegativeObligation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(NegativeObligation), new PGF.Expression[]{});
    }
    
  }
  
  public class NegativeRecommendation : Modality {
    public NegativeRecommendation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNegativeRecommendation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(NegativeRecommendation), new PGF.Expression[]{});
    }
    
  }
  
  public class Obligation : Modality {
    public Obligation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitObligation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Obligation), new PGF.Expression[]{});
    }
    
  }
  
  public class Recommendation : Modality {
    public Recommendation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitRecommendation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Recommendation), new PGF.Expression[]{});
    }
    
  }
  
  public abstract class NamedArea : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitNonSpecificArea(RailCNL.BaseArea x1);
      R VisitSpecificArea(string x1,RailCNL.BaseArea x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.BaseArea,R> _VisitNonSpecificArea { get; set; }
      private System.Func<string,RailCNL.BaseArea,R> _VisitSpecificArea { get; set; }
      public Visitor(System.Func<RailCNL.BaseArea,R> VisitNonSpecificArea, System.Func<string,RailCNL.BaseArea,R> VisitSpecificArea) {
        this._VisitNonSpecificArea = VisitNonSpecificArea;
        this._VisitSpecificArea = VisitSpecificArea;
      }
      
      public R VisitNonSpecificArea(RailCNL.BaseArea x1) => _VisitNonSpecificArea(x1);
      public R VisitSpecificArea(string x1,RailCNL.BaseArea x2) => _VisitSpecificArea(x1, x2);
    }
    
    public static NamedArea FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<NamedArea>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(NonSpecificArea) && args.Length == 1)
            return new NonSpecificArea(BaseArea.FromExpression(args[0]));
          if(fname == nameof(SpecificArea) && args.Length == 2)
            return new SpecificArea(((PGF.LiteralString)args[0]).Value, BaseArea.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class NonSpecificArea : NamedArea {
    public RailCNL.BaseArea x1 {get; set;}
    public NonSpecificArea(RailCNL.BaseArea x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNonSpecificArea(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(NonSpecificArea), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class SpecificArea : NamedArea {
    public string x1 {get; set;}
    public RailCNL.BaseArea x2 {get; set;}
    public SpecificArea(string x1, RailCNL.BaseArea x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSpecificArea(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SpecificArea), new PGF.Expression[]{new PGF.LiteralString(x1), x2.ToExpression()});
    }
    
  }
  
  public abstract class PathCondition : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitPathContains(RailCNL.DirectionalObject x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.DirectionalObject,R> _VisitPathContains { get; set; }
      public Visitor(System.Func<RailCNL.DirectionalObject,R> VisitPathContains) {
        this._VisitPathContains = VisitPathContains;
      }
      
      public R VisitPathContains(RailCNL.DirectionalObject x1) => _VisitPathContains(x1);
    }
    
    public static PathCondition FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<PathCondition>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(PathContains) && args.Length == 1)
            return new PathContains(DirectionalObject.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class PathContains : PathCondition {
    public RailCNL.DirectionalObject x1 {get; set;}
    public PathContains(RailCNL.DirectionalObject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitPathContains(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(PathContains), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class PathQuantifier : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAllPaths();
      R VisitExistsPath();
      R VisitNoPath();
      R VisitUniquePath();
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<R> _VisitAllPaths { get; set; }
      private System.Func<R> _VisitExistsPath { get; set; }
      private System.Func<R> _VisitNoPath { get; set; }
      private System.Func<R> _VisitUniquePath { get; set; }
      public Visitor(System.Func<R> VisitAllPaths, System.Func<R> VisitExistsPath, System.Func<R> VisitNoPath, System.Func<R> VisitUniquePath) {
        this._VisitAllPaths = VisitAllPaths;
        this._VisitExistsPath = VisitExistsPath;
        this._VisitNoPath = VisitNoPath;
        this._VisitUniquePath = VisitUniquePath;
      }
      
      public R VisitAllPaths() => _VisitAllPaths();
      public R VisitExistsPath() => _VisitExistsPath();
      public R VisitNoPath() => _VisitNoPath();
      public R VisitUniquePath() => _VisitUniquePath();
    }
    
    public static PathQuantifier FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<PathQuantifier>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AllPaths) && args.Length == 0)
            return new AllPaths();
          if(fname == nameof(ExistsPath) && args.Length == 0)
            return new ExistsPath();
          if(fname == nameof(NoPath) && args.Length == 0)
            return new NoPath();
          if(fname == nameof(UniquePath) && args.Length == 0)
            return new UniquePath();
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AllPaths : PathQuantifier {
    public AllPaths() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAllPaths();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AllPaths), new PGF.Expression[]{});
    }
    
  }
  
  public class ExistsPath : PathQuantifier {
    public ExistsPath() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitExistsPath();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ExistsPath), new PGF.Expression[]{});
    }
    
  }
  
  public class NoPath : PathQuantifier {
    public NoPath() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNoPath();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(NoPath), new PGF.Expression[]{});
    }
    
  }
  
  public class UniquePath : PathQuantifier {
    public UniquePath() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitUniquePath();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(UniquePath), new PGF.Expression[]{});
    }
    
  }
  
  public abstract class Predicate : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitStringPredicate(string x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<string,R> _VisitStringPredicate { get; set; }
      public Visitor(System.Func<string,R> VisitStringPredicate) {
        this._VisitStringPredicate = VisitStringPredicate;
      }
      
      public R VisitStringPredicate(string x1) => _VisitStringPredicate(x1);
    }
    
    public static Predicate FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Predicate>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(StringPredicate) && args.Length == 1)
            return new StringPredicate(((PGF.LiteralString)args[0]).Value);
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class StringPredicate : Predicate {
    public string x1 {get; set;}
    public StringPredicate(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringPredicate(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringPredicate), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public abstract class Property : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitOrientationAngleTo(RailCNL.Vector x1);
      R VisitStringProperty(string x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Vector,R> _VisitOrientationAngleTo { get; set; }
      private System.Func<string,R> _VisitStringProperty { get; set; }
      public Visitor(System.Func<RailCNL.Vector,R> VisitOrientationAngleTo, System.Func<string,R> VisitStringProperty) {
        this._VisitOrientationAngleTo = VisitOrientationAngleTo;
        this._VisitStringProperty = VisitStringProperty;
      }
      
      public R VisitOrientationAngleTo(RailCNL.Vector x1) => _VisitOrientationAngleTo(x1);
      public R VisitStringProperty(string x1) => _VisitStringProperty(x1);
    }
    
    public static Property FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Property>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(OrientationAngleTo) && args.Length == 1)
            return new OrientationAngleTo(Vector.FromExpression(args[0]));
          if(fname == nameof(StringProperty) && args.Length == 1)
            return new StringProperty(((PGF.LiteralString)args[0]).Value);
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class OrientationAngleTo : Property {
    public RailCNL.Vector x1 {get; set;}
    public OrientationAngleTo(RailCNL.Vector x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOrientationAngleTo(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OrientationAngleTo), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class StringProperty : Property {
    public string x1 {get; set;}
    public StringProperty(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringProperty(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringProperty), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public abstract class PropertyRestriction : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAndPropRestr(RailCNL.PropertyRestriction x1,RailCNL.PropertyRestriction x2);
      R VisitMkPropertyRestriction(RailCNL.Property x1,RailCNL.Restriction x2);
      R VisitOrPropRestr(RailCNL.PropertyRestriction x1,RailCNL.PropertyRestriction x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.PropertyRestriction,RailCNL.PropertyRestriction,R> _VisitAndPropRestr { get; set; }
      private System.Func<RailCNL.Property,RailCNL.Restriction,R> _VisitMkPropertyRestriction { get; set; }
      private System.Func<RailCNL.PropertyRestriction,RailCNL.PropertyRestriction,R> _VisitOrPropRestr { get; set; }
      public Visitor(System.Func<RailCNL.PropertyRestriction,RailCNL.PropertyRestriction,R> VisitAndPropRestr, System.Func<RailCNL.Property,RailCNL.Restriction,R> VisitMkPropertyRestriction, System.Func<RailCNL.PropertyRestriction,RailCNL.PropertyRestriction,R> VisitOrPropRestr) {
        this._VisitAndPropRestr = VisitAndPropRestr;
        this._VisitMkPropertyRestriction = VisitMkPropertyRestriction;
        this._VisitOrPropRestr = VisitOrPropRestr;
      }
      
      public R VisitAndPropRestr(RailCNL.PropertyRestriction x1,RailCNL.PropertyRestriction x2) => _VisitAndPropRestr(x1, x2);
      public R VisitMkPropertyRestriction(RailCNL.Property x1,RailCNL.Restriction x2) => _VisitMkPropertyRestriction(x1, x2);
      public R VisitOrPropRestr(RailCNL.PropertyRestriction x1,RailCNL.PropertyRestriction x2) => _VisitOrPropRestr(x1, x2);
    }
    
    public static PropertyRestriction FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<PropertyRestriction>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AndPropRestr) && args.Length == 2)
            return new AndPropRestr(PropertyRestriction.FromExpression(args[0]), PropertyRestriction.FromExpression(args[1]));
          if(fname == nameof(MkPropertyRestriction) && args.Length == 2)
            return new MkPropertyRestriction(Property.FromExpression(args[0]), Restriction.FromExpression(args[1]));
          if(fname == nameof(OrPropRestr) && args.Length == 2)
            return new OrPropRestr(PropertyRestriction.FromExpression(args[0]), PropertyRestriction.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AndPropRestr : PropertyRestriction {
    public RailCNL.PropertyRestriction x1 {get; set;}
    public RailCNL.PropertyRestriction x2 {get; set;}
    public AndPropRestr(RailCNL.PropertyRestriction x1, RailCNL.PropertyRestriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAndPropRestr(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AndPropRestr), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class MkPropertyRestriction : PropertyRestriction {
    public RailCNL.Property x1 {get; set;}
    public RailCNL.Restriction x2 {get; set;}
    public MkPropertyRestriction(RailCNL.Property x1, RailCNL.Restriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitMkPropertyRestriction(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(MkPropertyRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class OrPropRestr : PropertyRestriction {
    public RailCNL.PropertyRestriction x1 {get; set;}
    public RailCNL.PropertyRestriction x2 {get; set;}
    public OrPropRestr(RailCNL.PropertyRestriction x1, RailCNL.PropertyRestriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOrPropRestr(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OrPropRestr), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public abstract class RelatedSubjects : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitMkRelatedSubjects(RailCNL.Subject x1,RailCNL.SearchSubject x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Subject,RailCNL.SearchSubject,R> _VisitMkRelatedSubjects { get; set; }
      public Visitor(System.Func<RailCNL.Subject,RailCNL.SearchSubject,R> VisitMkRelatedSubjects) {
        this._VisitMkRelatedSubjects = VisitMkRelatedSubjects;
      }
      
      public R VisitMkRelatedSubjects(RailCNL.Subject x1,RailCNL.SearchSubject x2) => _VisitMkRelatedSubjects(x1, x2);
    }
    
    public static RelatedSubjects FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<RelatedSubjects>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(MkRelatedSubjects) && args.Length == 2)
            return new MkRelatedSubjects(Subject.FromExpression(args[0]), SearchSubject.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class MkRelatedSubjects : RelatedSubjects {
    public RailCNL.Subject x1 {get; set;}
    public RailCNL.SearchSubject x2 {get; set;}
    public MkRelatedSubjects(RailCNL.Subject x1, RailCNL.SearchSubject x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitMkRelatedSubjects(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(MkRelatedSubjects), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public abstract class RelationMultiplicity : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitExistsRelation();
      R VisitManyRelation();
      R VisitOneRelation();
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<R> _VisitExistsRelation { get; set; }
      private System.Func<R> _VisitManyRelation { get; set; }
      private System.Func<R> _VisitOneRelation { get; set; }
      public Visitor(System.Func<R> VisitExistsRelation, System.Func<R> VisitManyRelation, System.Func<R> VisitOneRelation) {
        this._VisitExistsRelation = VisitExistsRelation;
        this._VisitManyRelation = VisitManyRelation;
        this._VisitOneRelation = VisitOneRelation;
      }
      
      public R VisitExistsRelation() => _VisitExistsRelation();
      public R VisitManyRelation() => _VisitManyRelation();
      public R VisitOneRelation() => _VisitOneRelation();
    }
    
    public static RelationMultiplicity FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<RelationMultiplicity>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(ExistsRelation) && args.Length == 0)
            return new ExistsRelation();
          if(fname == nameof(ManyRelation) && args.Length == 0)
            return new ManyRelation();
          if(fname == nameof(OneRelation) && args.Length == 0)
            return new OneRelation();
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class ExistsRelation : RelationMultiplicity {
    public ExistsRelation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitExistsRelation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ExistsRelation), new PGF.Expression[]{});
    }
    
  }
  
  public class ManyRelation : RelationMultiplicity {
    public ManyRelation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitManyRelation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(ManyRelation), new PGF.Expression[]{});
    }
    
  }
  
  public class OneRelation : RelationMultiplicity {
    public OneRelation() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOneRelation();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OneRelation), new PGF.Expression[]{});
    }
    
  }
  
  public abstract class Restriction : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAndRestr(RailCNL.Restriction x1,RailCNL.Restriction x2);
      R VisitEq(RailCNL.Value x1);
      R VisitGt(RailCNL.Value x1);
      R VisitGte(RailCNL.Value x1);
      R VisitLt(RailCNL.Value x1);
      R VisitLte(RailCNL.Value x1);
      R VisitNeq(RailCNL.Value x1);
      R VisitOrRestr(RailCNL.Restriction x1,RailCNL.Restriction x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Restriction,RailCNL.Restriction,R> _VisitAndRestr { get; set; }
      private System.Func<RailCNL.Value,R> _VisitEq { get; set; }
      private System.Func<RailCNL.Value,R> _VisitGt { get; set; }
      private System.Func<RailCNL.Value,R> _VisitGte { get; set; }
      private System.Func<RailCNL.Value,R> _VisitLt { get; set; }
      private System.Func<RailCNL.Value,R> _VisitLte { get; set; }
      private System.Func<RailCNL.Value,R> _VisitNeq { get; set; }
      private System.Func<RailCNL.Restriction,RailCNL.Restriction,R> _VisitOrRestr { get; set; }
      public Visitor(System.Func<RailCNL.Restriction,RailCNL.Restriction,R> VisitAndRestr, System.Func<RailCNL.Value,R> VisitEq, System.Func<RailCNL.Value,R> VisitGt, System.Func<RailCNL.Value,R> VisitGte, System.Func<RailCNL.Value,R> VisitLt, System.Func<RailCNL.Value,R> VisitLte, System.Func<RailCNL.Value,R> VisitNeq, System.Func<RailCNL.Restriction,RailCNL.Restriction,R> VisitOrRestr) {
        this._VisitAndRestr = VisitAndRestr;
        this._VisitEq = VisitEq;
        this._VisitGt = VisitGt;
        this._VisitGte = VisitGte;
        this._VisitLt = VisitLt;
        this._VisitLte = VisitLte;
        this._VisitNeq = VisitNeq;
        this._VisitOrRestr = VisitOrRestr;
      }
      
      public R VisitAndRestr(RailCNL.Restriction x1,RailCNL.Restriction x2) => _VisitAndRestr(x1, x2);
      public R VisitEq(RailCNL.Value x1) => _VisitEq(x1);
      public R VisitGt(RailCNL.Value x1) => _VisitGt(x1);
      public R VisitGte(RailCNL.Value x1) => _VisitGte(x1);
      public R VisitLt(RailCNL.Value x1) => _VisitLt(x1);
      public R VisitLte(RailCNL.Value x1) => _VisitLte(x1);
      public R VisitNeq(RailCNL.Value x1) => _VisitNeq(x1);
      public R VisitOrRestr(RailCNL.Restriction x1,RailCNL.Restriction x2) => _VisitOrRestr(x1, x2);
    }
    
    public static Restriction FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Restriction>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AndRestr) && args.Length == 2)
            return new AndRestr(Restriction.FromExpression(args[0]), Restriction.FromExpression(args[1]));
          if(fname == nameof(Eq) && args.Length == 1)
            return new Eq(Value.FromExpression(args[0]));
          if(fname == nameof(Gt) && args.Length == 1)
            return new Gt(Value.FromExpression(args[0]));
          if(fname == nameof(Gte) && args.Length == 1)
            return new Gte(Value.FromExpression(args[0]));
          if(fname == nameof(Lt) && args.Length == 1)
            return new Lt(Value.FromExpression(args[0]));
          if(fname == nameof(Lte) && args.Length == 1)
            return new Lte(Value.FromExpression(args[0]));
          if(fname == nameof(Neq) && args.Length == 1)
            return new Neq(Value.FromExpression(args[0]));
          if(fname == nameof(OrRestr) && args.Length == 2)
            return new OrRestr(Restriction.FromExpression(args[0]), Restriction.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AndRestr : Restriction {
    public RailCNL.Restriction x1 {get; set;}
    public RailCNL.Restriction x2 {get; set;}
    public AndRestr(RailCNL.Restriction x1, RailCNL.Restriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAndRestr(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AndRestr), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class Eq : Restriction {
    public RailCNL.Value x1 {get; set;}
    public Eq(RailCNL.Value x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitEq(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Eq), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class Gt : Restriction {
    public RailCNL.Value x1 {get; set;}
    public Gt(RailCNL.Value x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitGt(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Gt), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class Gte : Restriction {
    public RailCNL.Value x1 {get; set;}
    public Gte(RailCNL.Value x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitGte(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Gte), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class Lt : Restriction {
    public RailCNL.Value x1 {get; set;}
    public Lt(RailCNL.Value x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLt(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Lt), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class Lte : Restriction {
    public RailCNL.Value x1 {get; set;}
    public Lte(RailCNL.Value x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitLte(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Lte), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class Neq : Restriction {
    public RailCNL.Value x1 {get; set;}
    public Neq(RailCNL.Value x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitNeq(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(Neq), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class OrRestr : Restriction {
    public RailCNL.Restriction x1 {get; set;}
    public RailCNL.Restriction x2 {get; set;}
    public OrRestr(RailCNL.Restriction x1, RailCNL.Restriction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOrRestr(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OrRestr), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public abstract class Rule : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitMkRule(RailCNL.Literal x1,RailCNL.Conjunction x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Literal,RailCNL.Conjunction,R> _VisitMkRule { get; set; }
      public Visitor(System.Func<RailCNL.Literal,RailCNL.Conjunction,R> VisitMkRule) {
        this._VisitMkRule = VisitMkRule;
      }
      
      public R VisitMkRule(RailCNL.Literal x1,RailCNL.Conjunction x2) => _VisitMkRule(x1, x2);
    }
    
    public static Rule FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Rule>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(MkRule) && args.Length == 2)
            return new MkRule(Literal.FromExpression(args[0]), Conjunction.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class MkRule : Rule {
    public RailCNL.Literal x1 {get; set;}
    public RailCNL.Conjunction x2 {get; set;}
    public MkRule(RailCNL.Literal x1, RailCNL.Conjunction x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitMkRule(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(MkRule), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public abstract class SearchSubject : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitAnySearchSubject(RailCNL.Subject x1);
      R VisitSubjectOtherImplied();
      R VisitSubjectRelationToOneMascFem(RailCNL.Class x1);
      R VisitSubjectRelationToOneNeutrum(RailCNL.Class x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Subject,R> _VisitAnySearchSubject { get; set; }
      private System.Func<R> _VisitSubjectOtherImplied { get; set; }
      private System.Func<RailCNL.Class,R> _VisitSubjectRelationToOneMascFem { get; set; }
      private System.Func<RailCNL.Class,R> _VisitSubjectRelationToOneNeutrum { get; set; }
      public Visitor(System.Func<RailCNL.Subject,R> VisitAnySearchSubject, System.Func<R> VisitSubjectOtherImplied, System.Func<RailCNL.Class,R> VisitSubjectRelationToOneMascFem, System.Func<RailCNL.Class,R> VisitSubjectRelationToOneNeutrum) {
        this._VisitAnySearchSubject = VisitAnySearchSubject;
        this._VisitSubjectOtherImplied = VisitSubjectOtherImplied;
        this._VisitSubjectRelationToOneMascFem = VisitSubjectRelationToOneMascFem;
        this._VisitSubjectRelationToOneNeutrum = VisitSubjectRelationToOneNeutrum;
      }
      
      public R VisitAnySearchSubject(RailCNL.Subject x1) => _VisitAnySearchSubject(x1);
      public R VisitSubjectOtherImplied() => _VisitSubjectOtherImplied();
      public R VisitSubjectRelationToOneMascFem(RailCNL.Class x1) => _VisitSubjectRelationToOneMascFem(x1);
      public R VisitSubjectRelationToOneNeutrum(RailCNL.Class x1) => _VisitSubjectRelationToOneNeutrum(x1);
    }
    
    public static SearchSubject FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<SearchSubject>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(AnySearchSubject) && args.Length == 1)
            return new AnySearchSubject(Subject.FromExpression(args[0]));
          if(fname == nameof(SubjectOtherImplied) && args.Length == 0)
            return new SubjectOtherImplied();
          if(fname == nameof(SubjectRelationToOneMascFem) && args.Length == 1)
            return new SubjectRelationToOneMascFem(Class.FromExpression(args[0]));
          if(fname == nameof(SubjectRelationToOneNeutrum) && args.Length == 1)
            return new SubjectRelationToOneNeutrum(Class.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class AnySearchSubject : SearchSubject {
    public RailCNL.Subject x1 {get; set;}
    public AnySearchSubject(RailCNL.Subject x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitAnySearchSubject(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(AnySearchSubject), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class SubjectOtherImplied : SearchSubject {
    public SubjectOtherImplied() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSubjectOtherImplied();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SubjectOtherImplied), new PGF.Expression[]{});
    }
    
  }
  
  public class SubjectRelationToOneMascFem : SearchSubject {
    public RailCNL.Class x1 {get; set;}
    public SubjectRelationToOneMascFem(RailCNL.Class x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSubjectRelationToOneMascFem(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SubjectRelationToOneMascFem), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class SubjectRelationToOneNeutrum : SearchSubject {
    public RailCNL.Class x1 {get; set;}
    public SubjectRelationToOneNeutrum(RailCNL.Class x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSubjectRelationToOneNeutrum(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SubjectRelationToOneNeutrum), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class Statement : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitDistanceRelationRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.Class x3,RailCNL.Restriction x4);
      R VisitDistanceRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.GoalObject x3,RailCNL.Restriction x4);
      R VisitOntologyAssertion(RailCNL.Subject x1,RailCNL.Condition x2);
      R VisitOntologyRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.Condition x3);
      R VisitPathObligation(RailCNL.PathQuantifier x1,RailCNL.Subject x2,RailCNL.GoalObject x3,RailCNL.PathCondition x4);
      R VisitPlacementRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.AreaConj x3);
      R VisitRelatedObjectsToRelatedObjects(RailCNL.Modality x1,RailCNL.RelatedSubjects x2,RailCNL.TwoRelations x3);
      R VisitRelationDefiningPath(RailCNL.Class x1,RailCNL.Subject x2,RailCNL.GoalObject x3);
      R VisitRelationPathRestriction(RailCNL.Modality x1,RailCNL.Class x2,RailCNL.Subject x3,RailCNL.GoalObject x4);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.Class,RailCNL.Restriction,R> _VisitDistanceRelationRestriction { get; set; }
      private System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.GoalObject,RailCNL.Restriction,R> _VisitDistanceRestriction { get; set; }
      private System.Func<RailCNL.Subject,RailCNL.Condition,R> _VisitOntologyAssertion { get; set; }
      private System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.Condition,R> _VisitOntologyRestriction { get; set; }
      private System.Func<RailCNL.PathQuantifier,RailCNL.Subject,RailCNL.GoalObject,RailCNL.PathCondition,R> _VisitPathObligation { get; set; }
      private System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.AreaConj,R> _VisitPlacementRestriction { get; set; }
      private System.Func<RailCNL.Modality,RailCNL.RelatedSubjects,RailCNL.TwoRelations,R> _VisitRelatedObjectsToRelatedObjects { get; set; }
      private System.Func<RailCNL.Class,RailCNL.Subject,RailCNL.GoalObject,R> _VisitRelationDefiningPath { get; set; }
      private System.Func<RailCNL.Modality,RailCNL.Class,RailCNL.Subject,RailCNL.GoalObject,R> _VisitRelationPathRestriction { get; set; }
      public Visitor(System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.Class,RailCNL.Restriction,R> VisitDistanceRelationRestriction, System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.GoalObject,RailCNL.Restriction,R> VisitDistanceRestriction, System.Func<RailCNL.Subject,RailCNL.Condition,R> VisitOntologyAssertion, System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.Condition,R> VisitOntologyRestriction, System.Func<RailCNL.PathQuantifier,RailCNL.Subject,RailCNL.GoalObject,RailCNL.PathCondition,R> VisitPathObligation, System.Func<RailCNL.Modality,RailCNL.Subject,RailCNL.AreaConj,R> VisitPlacementRestriction, System.Func<RailCNL.Modality,RailCNL.RelatedSubjects,RailCNL.TwoRelations,R> VisitRelatedObjectsToRelatedObjects, System.Func<RailCNL.Class,RailCNL.Subject,RailCNL.GoalObject,R> VisitRelationDefiningPath, System.Func<RailCNL.Modality,RailCNL.Class,RailCNL.Subject,RailCNL.GoalObject,R> VisitRelationPathRestriction) {
        this._VisitDistanceRelationRestriction = VisitDistanceRelationRestriction;
        this._VisitDistanceRestriction = VisitDistanceRestriction;
        this._VisitOntologyAssertion = VisitOntologyAssertion;
        this._VisitOntologyRestriction = VisitOntologyRestriction;
        this._VisitPathObligation = VisitPathObligation;
        this._VisitPlacementRestriction = VisitPlacementRestriction;
        this._VisitRelatedObjectsToRelatedObjects = VisitRelatedObjectsToRelatedObjects;
        this._VisitRelationDefiningPath = VisitRelationDefiningPath;
        this._VisitRelationPathRestriction = VisitRelationPathRestriction;
      }
      
      public R VisitDistanceRelationRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.Class x3,RailCNL.Restriction x4) => _VisitDistanceRelationRestriction(x1, x2, x3, x4);
      public R VisitDistanceRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.GoalObject x3,RailCNL.Restriction x4) => _VisitDistanceRestriction(x1, x2, x3, x4);
      public R VisitOntologyAssertion(RailCNL.Subject x1,RailCNL.Condition x2) => _VisitOntologyAssertion(x1, x2);
      public R VisitOntologyRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.Condition x3) => _VisitOntologyRestriction(x1, x2, x3);
      public R VisitPathObligation(RailCNL.PathQuantifier x1,RailCNL.Subject x2,RailCNL.GoalObject x3,RailCNL.PathCondition x4) => _VisitPathObligation(x1, x2, x3, x4);
      public R VisitPlacementRestriction(RailCNL.Modality x1,RailCNL.Subject x2,RailCNL.AreaConj x3) => _VisitPlacementRestriction(x1, x2, x3);
      public R VisitRelatedObjectsToRelatedObjects(RailCNL.Modality x1,RailCNL.RelatedSubjects x2,RailCNL.TwoRelations x3) => _VisitRelatedObjectsToRelatedObjects(x1, x2, x3);
      public R VisitRelationDefiningPath(RailCNL.Class x1,RailCNL.Subject x2,RailCNL.GoalObject x3) => _VisitRelationDefiningPath(x1, x2, x3);
      public R VisitRelationPathRestriction(RailCNL.Modality x1,RailCNL.Class x2,RailCNL.Subject x3,RailCNL.GoalObject x4) => _VisitRelationPathRestriction(x1, x2, x3, x4);
    }
    
    public static Statement FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Statement>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(DistanceRelationRestriction) && args.Length == 4)
            return new DistanceRelationRestriction(Modality.FromExpression(args[0]), Subject.FromExpression(args[1]), Class.FromExpression(args[2]), Restriction.FromExpression(args[3]));
          if(fname == nameof(DistanceRestriction) && args.Length == 4)
            return new DistanceRestriction(Modality.FromExpression(args[0]), Subject.FromExpression(args[1]), GoalObject.FromExpression(args[2]), Restriction.FromExpression(args[3]));
          if(fname == nameof(OntologyAssertion) && args.Length == 2)
            return new OntologyAssertion(Subject.FromExpression(args[0]), Condition.FromExpression(args[1]));
          if(fname == nameof(OntologyRestriction) && args.Length == 3)
            return new OntologyRestriction(Modality.FromExpression(args[0]), Subject.FromExpression(args[1]), Condition.FromExpression(args[2]));
          if(fname == nameof(PathObligation) && args.Length == 4)
            return new PathObligation(PathQuantifier.FromExpression(args[0]), Subject.FromExpression(args[1]), GoalObject.FromExpression(args[2]), PathCondition.FromExpression(args[3]));
          if(fname == nameof(PlacementRestriction) && args.Length == 3)
            return new PlacementRestriction(Modality.FromExpression(args[0]), Subject.FromExpression(args[1]), AreaConj.FromExpression(args[2]));
          if(fname == nameof(RelatedObjectsToRelatedObjects) && args.Length == 3)
            return new RelatedObjectsToRelatedObjects(Modality.FromExpression(args[0]), RelatedSubjects.FromExpression(args[1]), TwoRelations.FromExpression(args[2]));
          if(fname == nameof(RelationDefiningPath) && args.Length == 3)
            return new RelationDefiningPath(Class.FromExpression(args[0]), Subject.FromExpression(args[1]), GoalObject.FromExpression(args[2]));
          if(fname == nameof(RelationPathRestriction) && args.Length == 4)
            return new RelationPathRestriction(Modality.FromExpression(args[0]), Class.FromExpression(args[1]), Subject.FromExpression(args[2]), GoalObject.FromExpression(args[3]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class DistanceRelationRestriction : Statement {
    public RailCNL.Modality x1 {get; set;}
    public RailCNL.Subject x2 {get; set;}
    public RailCNL.Class x3 {get; set;}
    public RailCNL.Restriction x4 {get; set;}
    public DistanceRelationRestriction(RailCNL.Modality x1, RailCNL.Subject x2, RailCNL.Class x3, RailCNL.Restriction x4) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
      this.x4 = x4;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitDistanceRelationRestriction(x1, x2, x3, x4);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(DistanceRelationRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression(), x4.ToExpression()});
    }
    
  }
  
  public class DistanceRestriction : Statement {
    public RailCNL.Modality x1 {get; set;}
    public RailCNL.Subject x2 {get; set;}
    public RailCNL.GoalObject x3 {get; set;}
    public RailCNL.Restriction x4 {get; set;}
    public DistanceRestriction(RailCNL.Modality x1, RailCNL.Subject x2, RailCNL.GoalObject x3, RailCNL.Restriction x4) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
      this.x4 = x4;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitDistanceRestriction(x1, x2, x3, x4);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(DistanceRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression(), x4.ToExpression()});
    }
    
  }
  
  public class OntologyAssertion : Statement {
    public RailCNL.Subject x1 {get; set;}
    public RailCNL.Condition x2 {get; set;}
    public OntologyAssertion(RailCNL.Subject x1, RailCNL.Condition x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOntologyAssertion(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OntologyAssertion), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class OntologyRestriction : Statement {
    public RailCNL.Modality x1 {get; set;}
    public RailCNL.Subject x2 {get; set;}
    public RailCNL.Condition x3 {get; set;}
    public OntologyRestriction(RailCNL.Modality x1, RailCNL.Subject x2, RailCNL.Condition x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitOntologyRestriction(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(OntologyRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public class PathObligation : Statement {
    public RailCNL.PathQuantifier x1 {get; set;}
    public RailCNL.Subject x2 {get; set;}
    public RailCNL.GoalObject x3 {get; set;}
    public RailCNL.PathCondition x4 {get; set;}
    public PathObligation(RailCNL.PathQuantifier x1, RailCNL.Subject x2, RailCNL.GoalObject x3, RailCNL.PathCondition x4) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
      this.x4 = x4;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitPathObligation(x1, x2, x3, x4);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(PathObligation), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression(), x4.ToExpression()});
    }
    
  }
  
  public class PlacementRestriction : Statement {
    public RailCNL.Modality x1 {get; set;}
    public RailCNL.Subject x2 {get; set;}
    public RailCNL.AreaConj x3 {get; set;}
    public PlacementRestriction(RailCNL.Modality x1, RailCNL.Subject x2, RailCNL.AreaConj x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitPlacementRestriction(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(PlacementRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public class RelatedObjectsToRelatedObjects : Statement {
    public RailCNL.Modality x1 {get; set;}
    public RailCNL.RelatedSubjects x2 {get; set;}
    public RailCNL.TwoRelations x3 {get; set;}
    public RelatedObjectsToRelatedObjects(RailCNL.Modality x1, RailCNL.RelatedSubjects x2, RailCNL.TwoRelations x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitRelatedObjectsToRelatedObjects(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(RelatedObjectsToRelatedObjects), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public class RelationDefiningPath : Statement {
    public RailCNL.Class x1 {get; set;}
    public RailCNL.Subject x2 {get; set;}
    public RailCNL.GoalObject x3 {get; set;}
    public RelationDefiningPath(RailCNL.Class x1, RailCNL.Subject x2, RailCNL.GoalObject x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitRelationDefiningPath(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(RelationDefiningPath), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public class RelationPathRestriction : Statement {
    public RailCNL.Modality x1 {get; set;}
    public RailCNL.Class x2 {get; set;}
    public RailCNL.Subject x3 {get; set;}
    public RailCNL.GoalObject x4 {get; set;}
    public RelationPathRestriction(RailCNL.Modality x1, RailCNL.Class x2, RailCNL.Subject x3, RailCNL.GoalObject x4) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
      this.x4 = x4;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitRelationPathRestriction(x1, x2, x3, x4);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(RelationPathRestriction), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression(), x4.ToExpression()});
    }
    
  }
  
  public abstract class String : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
    }
    
    public class Visitor<R> : IVisitor<R> {
      public Visitor() {
      }
      
    }
    
    public static String FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<String>() {
        fVisitApplication = (fname,args) =>  {
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public abstract class Subject : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitSubjectArea(RailCNL.Subject x1,RailCNL.AreaConj x2);
      R VisitSubjectClass(RailCNL.Class x1);
      R VisitSubjectCondition(RailCNL.Class x1,RailCNL.Condition x2);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Subject,RailCNL.AreaConj,R> _VisitSubjectArea { get; set; }
      private System.Func<RailCNL.Class,R> _VisitSubjectClass { get; set; }
      private System.Func<RailCNL.Class,RailCNL.Condition,R> _VisitSubjectCondition { get; set; }
      public Visitor(System.Func<RailCNL.Subject,RailCNL.AreaConj,R> VisitSubjectArea, System.Func<RailCNL.Class,R> VisitSubjectClass, System.Func<RailCNL.Class,RailCNL.Condition,R> VisitSubjectCondition) {
        this._VisitSubjectArea = VisitSubjectArea;
        this._VisitSubjectClass = VisitSubjectClass;
        this._VisitSubjectCondition = VisitSubjectCondition;
      }
      
      public R VisitSubjectArea(RailCNL.Subject x1,RailCNL.AreaConj x2) => _VisitSubjectArea(x1, x2);
      public R VisitSubjectClass(RailCNL.Class x1) => _VisitSubjectClass(x1);
      public R VisitSubjectCondition(RailCNL.Class x1,RailCNL.Condition x2) => _VisitSubjectCondition(x1, x2);
    }
    
    public static Subject FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Subject>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(SubjectArea) && args.Length == 2)
            return new SubjectArea(Subject.FromExpression(args[0]), AreaConj.FromExpression(args[1]));
          if(fname == nameof(SubjectClass) && args.Length == 1)
            return new SubjectClass(Class.FromExpression(args[0]));
          if(fname == nameof(SubjectCondition) && args.Length == 2)
            return new SubjectCondition(Class.FromExpression(args[0]), Condition.FromExpression(args[1]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class SubjectArea : Subject {
    public RailCNL.Subject x1 {get; set;}
    public RailCNL.AreaConj x2 {get; set;}
    public SubjectArea(RailCNL.Subject x1, RailCNL.AreaConj x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSubjectArea(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SubjectArea), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public class SubjectClass : Subject {
    public RailCNL.Class x1 {get; set;}
    public SubjectClass(RailCNL.Class x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSubjectClass(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SubjectClass), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public class SubjectCondition : Subject {
    public RailCNL.Class x1 {get; set;}
    public RailCNL.Condition x2 {get; set;}
    public SubjectCondition(RailCNL.Class x1, RailCNL.Condition x2) {
      this.x1 = x1;
      this.x2 = x2;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitSubjectCondition(x1, x2);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(SubjectCondition), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression()});
    }
    
  }
  
  public abstract class Term : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitFloatTerm(double x1);
      R VisitIntTerm(int x1);
      R VisitStringTerm(string x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<double,R> _VisitFloatTerm { get; set; }
      private System.Func<int,R> _VisitIntTerm { get; set; }
      private System.Func<string,R> _VisitStringTerm { get; set; }
      public Visitor(System.Func<double,R> VisitFloatTerm, System.Func<int,R> VisitIntTerm, System.Func<string,R> VisitStringTerm) {
        this._VisitFloatTerm = VisitFloatTerm;
        this._VisitIntTerm = VisitIntTerm;
        this._VisitStringTerm = VisitStringTerm;
      }
      
      public R VisitFloatTerm(double x1) => _VisitFloatTerm(x1);
      public R VisitIntTerm(int x1) => _VisitIntTerm(x1);
      public R VisitStringTerm(string x1) => _VisitStringTerm(x1);
    }
    
    public static Term FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Term>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(FloatTerm) && args.Length == 1)
            return new FloatTerm(((PGF.LiteralFloat)args[0]).Value);
          if(fname == nameof(IntTerm) && args.Length == 1)
            return new IntTerm(((PGF.LiteralInt)args[0]).Value);
          if(fname == nameof(StringTerm) && args.Length == 1)
            return new StringTerm(((PGF.LiteralString)args[0]).Value);
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class FloatTerm : Term {
    public double x1 {get; set;}
    public FloatTerm(double x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitFloatTerm(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(FloatTerm), new PGF.Expression[]{new PGF.LiteralFloat(x1)});
    }
    
  }
  
  public class IntTerm : Term {
    public int x1 {get; set;}
    public IntTerm(int x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitIntTerm(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(IntTerm), new PGF.Expression[]{new PGF.LiteralInt(x1)});
    }
    
  }
  
  public class StringTerm : Term {
    public string x1 {get; set;}
    public StringTerm(string x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitStringTerm(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(StringTerm), new PGF.Expression[]{new PGF.LiteralString(x1)});
    }
    
  }
  
  public abstract class TwoRelations : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitTwoRelationsOfSubject(RailCNL.Class x1,RailCNL.Class x2,RailCNL.Subject x3);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Class,RailCNL.Class,RailCNL.Subject,R> _VisitTwoRelationsOfSubject { get; set; }
      public Visitor(System.Func<RailCNL.Class,RailCNL.Class,RailCNL.Subject,R> VisitTwoRelationsOfSubject) {
        this._VisitTwoRelationsOfSubject = VisitTwoRelationsOfSubject;
      }
      
      public R VisitTwoRelationsOfSubject(RailCNL.Class x1,RailCNL.Class x2,RailCNL.Subject x3) => _VisitTwoRelationsOfSubject(x1, x2, x3);
    }
    
    public static TwoRelations FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<TwoRelations>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(TwoRelationsOfSubject) && args.Length == 3)
            return new TwoRelationsOfSubject(Class.FromExpression(args[0]), Class.FromExpression(args[1]), Subject.FromExpression(args[2]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class TwoRelationsOfSubject : TwoRelations {
    public RailCNL.Class x1 {get; set;}
    public RailCNL.Class x2 {get; set;}
    public RailCNL.Subject x3 {get; set;}
    public TwoRelationsOfSubject(RailCNL.Class x1, RailCNL.Class x2, RailCNL.Subject x3) {
      this.x1 = x1;
      this.x2 = x2;
      this.x3 = x3;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitTwoRelationsOfSubject(x1, x2, x3);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(TwoRelationsOfSubject), new PGF.Expression[]{x1.ToExpression(), x2.ToExpression(), x3.ToExpression()});
    }
    
  }
  
  public abstract class Value : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitMkValue(RailCNL.Term x1);
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<RailCNL.Term,R> _VisitMkValue { get; set; }
      public Visitor(System.Func<RailCNL.Term,R> VisitMkValue) {
        this._VisitMkValue = VisitMkValue;
      }
      
      public R VisitMkValue(RailCNL.Term x1) => _VisitMkValue(x1);
    }
    
    public static Value FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Value>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(MkValue) && args.Length == 1)
            return new MkValue(Term.FromExpression(args[0]));
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class MkValue : Value {
    public RailCNL.Term x1 {get; set;}
    public MkValue(RailCNL.Term x1) {
      this.x1 = x1;
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitMkValue(x1);
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(MkValue), new PGF.Expression[]{x1.ToExpression()});
    }
    
  }
  
  public abstract class Vector : Tree {
    public abstract R Accept<R>(IVisitor<R> visitor);
    public interface IVisitor<R> {
      R VisitTrackTangent();
    }
    
    public class Visitor<R> : IVisitor<R> {
      private System.Func<R> _VisitTrackTangent { get; set; }
      public Visitor(System.Func<R> VisitTrackTangent) {
        this._VisitTrackTangent = VisitTrackTangent;
      }
      
      public R VisitTrackTangent() => _VisitTrackTangent();
    }
    
    public static Vector FromExpression(PGF.Expression expr) {
      return expr.Accept(new PGF.Expression.Visitor<Vector>() {
        fVisitApplication = (fname,args) =>  {
          if(fname == nameof(TrackTangent) && args.Length == 0)
            return new TrackTangent();
          throw new System.ArgumentOutOfRangeException();
        }
        
      });
      
    }
    
  }
  
  public class TrackTangent : Vector {
    public TrackTangent() {
    }
    
    public override R Accept<R>(IVisitor<R> visitor) {
      return visitor.VisitTrackTangent();
    }
    
    public override PGF.Expression ToExpression() {
      return new PGF.Application(nameof(TrackTangent), new PGF.Expression[]{});
    }
    
  }
  
}

