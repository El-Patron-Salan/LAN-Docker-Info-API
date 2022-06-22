#!/usr/bin/python
import os
import sys
import json

filename = ""
jsonFilename = ""
fields = []
noIndex = 0

if sys.argv[1] == "container":
    filename = "ContainerInformation.txt"
    jsonFilename = "ContainersInformation.json"
    fields = ['ID', 'Image', 'Size', 'State', 'Status', 'CreatedAt', 'RunningFor']
    noIndex = 7

elif sys.argv[1] == "image":
    filename = "ImageInformation.txt"
    jsonFilename = "ImagesInformation.json"
    fields = ['Repository', 'Tag', 'ID', 'CreatedSince', 'Size']
    noIndex = 5

elif sys.argv[1] == "system":
    filename = "SystemInformation.txt"
    jsonFilename = "SystemInformation.json"
    fields = ['Type', 'TotalCount', 'Active', 'Size']
    noIndex = 4

else:
    os.system('echo -e "`date +"%d-%m-%Y %T"` | Unknown argument\n" >> ~/parser.log')
    
arr = []
with open(filename) as fh:

    for line in fh:
          
        description = list( line.strip().split("\t", noIndex))
          
        i = 0
        dict2 = {}
        while i<len(fields):
                dict2[fields[i]] = description[i]
                i = i + 1
           
        arr.append(dict2)

out_file = open(jsonFilename, "w")
json.dump(arr, out_file, indent = noIndex)
out_file.close()
