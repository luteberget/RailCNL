using System;
using RailConsXMLFormat;
using System.Text;

namespace RailCNL2Datalog
{
	public class Transform
	{
		public static PGF.Expression FlattenGender (PGF.Expression expr)
		{
			return expr.Accept (new PGF.Expression.Visitor<PGF.Expression> {
				fVisitApplication = (fn, args) => {
					if (fn == "StringClassGen1" || fn == "StringClassGen2") {
						return new PGF.Application ("StringClass", args);
					}

					return new PGF.Application (fn, args);
				},
				fVisitLiteralFlt = i => new PGF.LiteralFloat (i),
				fVisitLiteralInt = i => new PGF.LiteralInt (i),
				fVisitLiteralStr = i => new PGF.LiteralString (i),
			});
		}

		public static string ConvertToDatalogString (PGF.Expression expression, string name)
		{
			var statement = RailCNL.Statement.FromExpression (FlattenGender (expression));
			var conv = new Converter ();
			var rules = conv.ConvertStatement (statement, name);

			var stringBuilder = new StringBuilder ();
			foreach (var rule in rules) {
				stringBuilder.AppendLine (EmitDatalog.Generate (rule));
			}
			return stringBuilder.ToString ();
		}

		public static void TransformContents (PGF.Concrete language, RailConsXML root, Action<string> warning)
		{
			foreach (var scope in root.Scopes) {
				Console.WriteLine ($"Processing scope: {scope.Name}");

				foreach (var rule in scope.Rules) {
					rule.Class = RuleClass.Missing;
					if (string.IsNullOrWhiteSpace (rule.TextRef)) {
						warning ($"Rule without ID / text reference: {rule}");
						continue;
					}

					rule.Class = RuleClass.NoClass;
					if (string.IsNullOrWhiteSpace (rule.CNLText?.Text)) {
						warning ($"Rule without CNL content: {rule}");
						continue;
					}

					rule.Class = RuleClass.NoParse;
					PGF.Expression expression = null;
					try {
						expression = MainClass.ParseInput (language, rule.CNLText.Text);
						rule.AST = new TextElement{ Text = expression.ToString () };
					} catch (Exception e) {
						warning ($"Failed to parse input for {rule}: {e.Message}");
						continue;
					}

					rule.Class = RuleClass.NoTranslation;
					try {
						var datalogString = ConvertToDatalogString (expression, rule.TextRef);
						rule.Datalog = new TextElement{ Text = datalogString };
						rule.Class = RuleClass.StaticInfrastructureDatalog;
					} catch (UnsupportedExpressionException e) {
						rule.Class = RuleClass.Definition;
					} catch (Exception e) {
						warning ($"Failed to convert AST expression to Datalog: {e.Message}");
						continue;
					}
				}
			}
		}
	}
}

