#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit example
#
# $Revision:   1.13  $
#
# $Date:   27 Feb 2008 11:46:56  $
#

WCH = examples
PROD = toolkit

all: files datafiles rpsfiles src scrcmp

.Include $[f,$(CONF),builtins,mak]

datafiles:
    @%cd data
    @build
    @%cd ..

rpsfiles:
    @%cd rpsdat
    @build
    @%cd ..

src:
%If "$(OSTYPE)" != "VMS"
    %setenv DEMOLIB = $(WND)/examples/library
    %setenv RPSMFIL = $(WND)/examples/rpsdat/rpsmain.ism
    %setenv RPSTFIL = $(WND)/examples/rpsdat/rpstext.ism
%EndIf
    @%cd source
    @build
    @%cd ..

scrcmp:
    @%cd script
    @build
    @%cd ..

files:
%If "$(OSTYPE)" == "VMS"
	@get $(CHKUPD) -n env.com
	@get $(CHKUPD) -n "readme.vmv(readme.txt)"
	@get $(CHKUPD) -n *.mak
%Else
%If "$(OSTYPE)" == "WINNT"
	@get $(CHKUPD) -n env.bat
	@get $(CHKUPD) -n synergy.ini
	@get $(CHKUPD) -n "readme.txv(README.TXT)"
%Else
	@get $(CHKUPD) -w -y set.env
	@get $(CHKUPD) -n "readme.unv(README.UNX)"
%EndIf
%EndIf

clearall: clean

clean:
    @%cd data
    @build clean
    @%cd ..
    @%cd rpsdat
    @build clean
    @%cd ..
    @%cd source
    @build clean
    @%cd ..
    @%cd script
    @build clean
    @%cd ..
