#!/usr/bin/python

#
# For Sixteen Colors
# 
# Released as open source by NCC Group Plc - http://www.nccgroup.com/
# 
# Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com
#
# http://www.github.com/nccgroup/44Con2013Game/ansi.scoreboard/for.sixteen.colors/
#
# Released under AGPL see LICENSE for more information#
#

# Imports
import sys
import colorama
import time

# Argument error checking
if len(sys.argv) < 2 :
	sys.stderr.write("[?] usage: " + sys.argv[0] + " [file.ans]\n")
	sys.exit()

# Collect init stuff
colorama.init()

# Open the ANSi file
try:
	with open(sys.argv[1]) as f:
		content = f.readlines()
except:
	sys.stderr.write("[!] couldn't open " + sys.argv[2] + "\n")

# Write it
for line in content:
	sys.stdout.write(line)
		

