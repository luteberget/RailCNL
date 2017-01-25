TEMPLATE = template.html
STYLE = --css template.css --css style.css --toc --toc-depth 3
RAILCNL2DATALOG = ../RailCNL2Datalog/bin/Debug/RailCNL2Datalog.exe
ANNOTATE = annotate.py
PGF = ../Grammar/RailCNL.pgf

SOURCES := $(wildcard *.wiki)
OUTPUTS := $(SOURCES:wiki=html)

all: index.html $(OUTPUTS)

index.html: index.md
	pandoc -s -S index.md -o index.html --template $(TEMPLATE) $(STYLE)

%.unannotated : %.wiki $(TEMPLATE)
	pandoc -f mediawiki -t html $< -o $@ --template $(TEMPLATE) $(STYLE)

%.html : %.unannotated %.railcons.proc $(ANNOTATE)
	python $(ANNOTATE) $^ > $@

%.railcons.proc : %.railcons $(PGF) $(RAILCNL2DATALOG)
	$(RAILCNL2DATALOG) $(PGF) $< $@

# Don't delete proc files, for inspection.
.PRECIOUS: %.railcons.proc
