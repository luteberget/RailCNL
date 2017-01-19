using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace RailCNL2Datalog
{
	class MainClass
	{
		public static int Main (string[] args)
		{
			try {
				if (args.Length == 1 && args [0] == "-i") {
					Interactive ();
				} else if (args.Length == 2) {
					ProcessFile (args [0], args [1]);
				} else {
					Console.WriteLine ($"usage: {nameof(RailCNL2Datalog)} [-i] [IN OUT]");
					Console.WriteLine ($"  -i: interactive mode");
					Console.WriteLine ($"  IN OUT: process file in RailCons XML format");
					return 1;
				}
			} catch (Exception e) {
				Console.WriteLine ($"Error: {e.Message}");

				return 1;
			}

			return 0;
		}

		public static void ProcessFile (string infile, string outfile)
		{
			Console.WriteLine ($"Loading {infile}.");
			var serializer = new XmlSerializer (typeof(RailConsXMLFormat.RailConsXML));

			var fileReader = new System.IO.StreamReader (infile);
			var railconsxml = (RailConsXMLFormat.RailConsXML)serializer.Deserialize (fileReader);

			if (railconsxml == null || railconsxml.Scopes == null) {
				throw new ArgumentException ("Input file not recognized.");
			}

			Console.WriteLine ($"Transforming.");

			using (var grammar = PGF.Grammar.FromFile ("/home/bjlut/Dropbox/RailCNL.pgf")) {
				var lang = grammar.Languages.First ().Value;

				Transform.TransformContents (lang, railconsxml, s => Console.WriteLine ($"WARNING: {s}"));

			}


			Console.WriteLine ($"Writing to {outfile}.");
			using (StreamWriter writer = new StreamWriter (outfile)) {
				serializer.Serialize (writer, railconsxml);
			}

		}


		public static PGF.Expression ParseInput(PGF.Concrete langugage, string input) {
			var relexed = Relexer.Input2GF (input);
			var parsed = langugage.Parse (relexed).First ();

			return parsed;
		}

		public static void Interactive ()
		{
			using (var grammar = PGF.Grammar.FromFile ("/home/bjlut/Dropbox/RailCNL.pgf")) {
				var lang = grammar.Languages.First ().Value;

				Console.WriteLine ($"-- RailCNL2Datalog: {lang.ToString()}.");
				string inputLine;
				int n = 1;
				while (true) {
					inputLine = Console.ReadLine ();
					if (String.IsNullOrWhiteSpace (inputLine))
						break;
					
					try {
						var parsed = ParseInput(lang, inputLine);
						Console.WriteLine ($"-- Successfully parsed to: {parsed.ToString()}");
						var statement = RailCNL.Statement.FromExpression (parsed);

						IList<RailCNL.Rule> rules = null;
						try {
							var conv = new Converter ();
							rules = conv.ConvertStatement (statement, $"interactive{n++}");
						} catch (Exception e) {
							throw new RailCNL2Datalog.UnsupportedExpressionException ($"Converter failed unexpectedly.");
						}

						Console.WriteLine ($"-- Parsed statement resulted in {rules.Count} rules.");
						foreach (var rule in rules) {
							Console.WriteLine (EmitDatalog.Generate (rule));
						}
					} catch (PGF.Exceptions.ParseErrorException e) {
						Console.WriteLine ("-- Parse failed.");
					} catch (RailCNL2Datalog.UnsupportedExpressionException e) {
						Console.WriteLine ($"-- Unsupported expression: {e.Message}");
					} catch (RailCNL2Datalog.LexerException e) {
						Console.WriteLine ($"-- Error: statement must end with a period.");
					}

					Console.WriteLine ();
				}
				Console.WriteLine ("-- Exiting.");
			}
		}
	}
}


/*var stmt = new RailCNL.DistanceObligation(new RailCNL.SubjectClass(new RailCNL.StringClass("balise")),
			  new RailCNL.AnyFound(new RailCNL.AnyDirectionObject(new RailCNL.ObjectClass(new RailCNL.StringClass("signal")))),
			  new RailCNL.Eq(new RailCNL.MkValue(new RailCNL.StringTerm("500")))
			);
*/
