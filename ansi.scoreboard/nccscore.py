#!/usr/bin/python

#
# The NCC Group Game from 44CON 2013
# 
# Released as open source by NCC Group Plc - http://www.nccgroup.com/
# 
# Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com
#
# http://www.github.com/nccgroup/44Con2013Game
#
# Released under AGPL see LICENSE for more information#
#

#
# note it expects three field comma delimited response from the server
# ideally 5 lines or more, the format is:
#
# name, level, time
#


# Imports
import sys
import colorama
import urllib2
import socket
import time

# Static vars
backup = ['technical problem,12,99','with score web server,12,88','service will be resumed,12,77','soon!! lots of apologies!!,12,77','errot monkey,0,1']
errotmonkey = "errot monkey,-999,-999";

# Argument error checking
if len(sys.argv) < 3 :
	sys.stderr.write("[?] usage: " + sys.argv[0] + " [url] [template.ans]\n")
	sys.exit()

# Init
timeout = 5
socket.setdefaulttimeout(timeout)

# Collect init stuff
colorama.init()

# Open the ANSi template (once)
try:
	with open(sys.argv[2]) as f:
		content = f.readlines()
except:
	sys.stderr.write("[!] couldn't open " + sys.argv[2] + "\n")

while True:
	# Get the information from the score server
	try:
		req = urllib2.Request(sys.argv[1])
		response = urllib2.urlopen(req)
		scores = response.readlines()
	except:
		scores = backup

	count = 0
			
	for line in content:
		newline = line

		if "Player" in newline:
			try:
				scoresplit = scores[count].split(",")
				
				rem = 28  # remaining space until level
				rem -= len(scoresplit[0])
				
				rem2 = 14 # remaining space until time
				rem2-= len(scoresplit[1])
				
				rem3 = 10 # remaining space until boarder
				rem3-= len(scoresplit[2].strip())
				
				scoreline = scoresplit[0] + " " * rem + scoresplit[1] + " " * rem2 + scoresplit[2].strip() + " " * rem3			
			except:
				scoresplit = errotmonkey.split(",")
				rem = 28
				rem -= len(scoresplit[0])
				rem2 = 14
				rem2-= len(scoresplit[1])
				rem3 = 10
				rem3-= len(scoresplit[2].strip())
				scoreline = scoresplit[0] + " " * rem + scoresplit[1] + " " * rem2 + scoresplit[2].strip() + " " * rem3			
				
			if "Player 1" in newline and len(scores) > 0:
				newline = newline.replace("Player 1",scoreline)
				count+=1
			elif "Player 2" in newline and len(scores) > 1:
				newline = newline.replace("Player 2",scoreline)
				count+=1
			elif "Player 3" in newline and len(scores) > 2:
				newline = newline.replace("Player 3",scoreline)
				count+=1
			elif "Player 4" in newline and len(scores) > 3:
				newline = newline.replace("Player 4",scoreline)
				count+=1
			elif "Player 5" in newline and len(scores) > 4:
				newline = newline.replace("Player 5",scoreline)
				count+=1
	
		else:
			pass

		# write either the original
		# or modified line out
		sys.stdout.write(newline)

	# before the refresh
	time.sleep(30)
