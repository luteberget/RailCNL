#!/usr/bin/env python
# -*- coding: utf-8 -*-
import sys
document_file = sys.argv[1]
rule_file = sys.argv[2]



import xml.etree.ElementTree as ET
tree = ET.parse(rule_file)
xml_root = tree.getroot()

from bs4 import BeautifulSoup as Soup
soup = Soup(open(document_file),"lxml")


css_classification = {
  "definition" : "neutral",
  "static-infrastructure-datalog" : "covered",
  "datalog" : "known",
  "no-parse" : "error",
  "no-translation" : "known",
}

rule_classification = {
  "definition": "Definisjon.",
  "static-infrastructure-datalog": "Automatisk verifisering.",
  "datalog" : "",
  "no-parse": "Kunne ikke tolkes.",
  "no-class": "Kunne ikke tolkes.",
  "no-translation" : "Kunne ikke oversettes.",
  "missing" : "Mangler formalisering."
}

def paragraph(text):
  p = soup.new_tag("p")
  p.insert(0, text)
  return p

def paragraph_key_value(key,value):
  p = soup.new_tag("p")
  b = soup.new_tag("b")
  b.insert(0, key + ": ")
  p.insert(0, b)
  p.insert(1, value)
  return p

def get_text_by_id(i):
  rules = [rule for rule in xml_root if "textref" in rule.attrib and rule.attrib["textref"] == i]

  css_class = "error"
  content = []
  header_str = "ID: " + i + " — "
  #content.append((paragraph_key_value("ID", i)))

  if len(rules) == 0:
    #content.append(paragraph(rule_classification["missing"]))
    header_str += rule_classification["missing"]
  else:
    rule = rules[0]
    rule_class = rule.attrib.get("class","no-class")
    if rule_class in css_classification: css_class = css_classification[rule_class]

    cnl_representations = [cnl for cnl in rule if cnl.tag == "railcnl"]
    for cnl in cnl_representations:
      content.append(paragraph_key_value("RailCNL", cnl.text))

    header_str += rule_classification[rule_class]

  content = [paragraph(header_str)] + content

  return css_class, content




for label in soup.find_all("label"):
  rule_id = label['id']
  label_text = unicode(label)
  status,details_text = get_text_by_id(rule_id)

  section_start = "<div class=\"section\" id=\"section_" + rule_id + ">"
  section_end = "</div>"

  details = soup.new_tag("div", id="details_" + rule_id)
  details['class'] = "details " + status
  for i, item in enumerate(details_text):
    details.insert(i, item)

  section = soup.new_tag("div", id="section_" + rule_id)
  section['class'] = "section " + status
  label.replace_with(section)
  section.insert(0,details)
  section.insert(1,label)
  label['class'] = status

print soup