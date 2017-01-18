TEMPLATE = template.html
STYLE = --css template.css --css style.css --toc --toc-depth 3

SOURCES := $(wildcard *.wiki)
OUTPUTS := $(SOURCES:wiki=html)

all: index.html $(OUTPUTS)

index.html: index.md
	pandoc -s -S index.md -o index.html --template $(TEMPLATE) $(STYLE)

%.unannotated : %.wiki $(TEMPLATE)
	pandoc -f mediawiki -t html $< -o $@ --template $(TEMPLATE) $(STYLE)

%.html : %.unannotated %.railcons
	python annotate.py $^ > $@
