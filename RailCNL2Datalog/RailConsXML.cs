using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RailConsXMLFormat
{
	// RailCons XML storage format

	[XmlRoot ("RailConsXML")]
	public class RailConsXML
	{
		[XmlElement ("scope")]
		public List<Scope> Scopes = new List<Scope> ();
	}

	public class TextElement
	{
		[XmlText]
		public string Text = null;
	}

	public class Scope
	{
		[XmlAttribute ("name")]
		public string Name = null;

		[XmlElement ("rule")]
		public List<Rule> Rules = new List<Rule> ();
	}

	public class Rule
	{
		[XmlElement ("railcnl")]
		public TextElement CNLText = null;

		[XmlElement ("ast")]
		public TextElement AST = null;

		[XmlElement ("datalog")]
		public TextElement Datalog = null;

		[XmlAttribute ("textref")]
		public string TextRef = null;

		[XmlAttribute("class")]
		public RuleClass Class = RuleClass.Missing;

		public override string ToString ()
		{
			return $"Rule ({Class}) [{TextRef}] {CNLText?.Text?.Trim()}";
		}
	}

	public enum RuleClass {
		[XmlEnum("definition")] Definition,

		[XmlEnum("static-infrastructure-datalog")] StaticInfrastructureDatalog,
		[XmlEnum("datalog")] Datalog,
		[XmlEnum("other-content")] OtherContent,

		[XmlEnum("no-parse")] NoParse,
		[XmlEnum("no-class")] NoClass,
		[XmlEnum("no-translation")] NoTranslation,

		[XmlEnum("missing")] Missing

	}
}