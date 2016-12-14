all:
	pandoc --template template.tex -f markdown main.md -o trv.tex --variable mainfont="TeXGyrePagella" -V geometry:margin=1.3in
	#pandoc -s main.md -o trv.tex
	latexmk -pdf trv
