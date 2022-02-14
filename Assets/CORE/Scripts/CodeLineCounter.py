# > lines_of_code_counter.py .h .cpp
# Total lines:   15378
# Blank lines:   2945
# Comment lines: 1770
# Code lines:    10663

# Change this value based on the comment symbol used in your programming
# language.
commentSymbol = "//"

import sys
import os, os.path

acceptableFileExtensions = sys.argv[1:]
if not acceptableFileExtensions:
    print('Bitte gebe mindest eine FileExtension an (bsp: "python CodeLineCounter.py .py .cs. .h .c").')
    quit()

currentDir = os.getcwd()

filesToCheck = []
for root, _, files in os.walk(currentDir):
    for f in files:
        fullpath = os.path.join(root, f)
        if '.git' not in fullpath:
            for extension in acceptableFileExtensions:
            	if fullpath.endswith(extension):
                    filesToCheck.append(fullpath)

if not filesToCheck:
    print( 'Keine Datein gefunden.')
    quit()

lineCount = 0
totalBlankLineCount = 0
totalCommentLineCount = 0

print('')
print('Datei Name\tZeilen gesamt\tleere Zeilen\tKommentarzeilen\tCode Zeilen')

for fileToCheck in filesToCheck:
    with open(fileToCheck) as f:

        fileLineCount = 0
        fileBlankLineCount = 0
        fileCommentLineCount = 0

        for line in f:
            lineCount += 1
            fileLineCount += 1

            lineWithoutWhitespace = line.strip()
            if not lineWithoutWhitespace:
                totalBlankLineCount += 1
                fileBlankLineCount += 1
            elif lineWithoutWhitespace.startswith(commentSymbol):
                totalCommentLineCount += 1
                fileCommentLineCount += 1

        print(os.path.basename(fileToCheck) + \
              "\t" + str(fileLineCount) + \
              "\t" + str(fileBlankLineCount) + \
              "\t" + str(fileCommentLineCount) + \
              "\t" + str(fileLineCount - fileBlankLineCount - fileCommentLineCount))


print('')
print('Total')
print('--------------------')
print('Lines:         ' + str(lineCount))
print('Blank lines:   ' + str(totalBlankLineCount))
print('Comment lines: ' + str(totalCommentLineCount))
print('Code lines:    '+ str(lineCount - totalBlankLineCount - totalCommentLineCount))
