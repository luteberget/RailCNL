#!/bin/bash

# Trees input to treebank.
echo "rf -lines -tree -file=test_trees_in.txt | l -unlextext -treebank "  | gf --run  RailCNL???.gf > test_trees_out.txt

# Parse Norwegian
echo "rf -lines -file=test_nor_in.txt | p -lang=Nor | pt " | gf --run RailCNLNor.gf > test_nor_out.txt

