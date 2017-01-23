#!/bin/bash

sed -i 's/\[\[\s*Fil:/[[File:/' *wiki
sed -i 's/\[\[\s*Bilde:/[[Image:/' *wiki
sed -i 's/<caption>\(.*\)<\/caption>/\1/' *wiki

