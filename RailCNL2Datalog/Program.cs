﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace RailCNL2Datalog
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var grammar = PGF.Grammar.FromFile ("/home/bjlut/Dropbox/RailCNL.pgf")) {
				var lang = grammar.Languages.First ().Value;

				Console.WriteLine ($"-- RailCNL2Datalog: {lang.ToString()}.");
				string inputLine;
				int n = 1;
				while(true) {
					inputLine = Console.ReadLine ();
					if (String.IsNullOrWhiteSpace(inputLine))
						break;
					
					try {
						inputLine = Relexer.Input2GF(inputLine);

						var parsed = lang.Parse(inputLine).First();
						Console.WriteLine($"-- Successfully parsed to: {parsed.ToString()}");
						var statement = RailCNL.Statement.FromExpression(parsed);

						IList<RailCNL.Rule> rules = null;
						try {
							var conv = new Converter();
							rules = conv.ConvertStatement(statement, $"interactive{n++}");
						} catch (Exception e) {
							throw new RailCNL2Datalog.UnsupportedExpressionException($"Converter failed unexpectedly.");
						}

						Console.WriteLine($"-- Parsed statement resulted in {rules.Count} rules.");
						foreach(var rule in rules) {
							Console.WriteLine(EmitDatalog.Generate(rule));
						}
					} catch (PGF.Exceptions.ParseErrorException e) {
						Console.WriteLine("-- Parse failed.");
					} catch (RailCNL2Datalog.UnsupportedExpressionException e) {
						Console.WriteLine ($"-- Unsupported expression: {e.Message}");
					} catch(RailCNL2Datalog.LexerException e) {
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
