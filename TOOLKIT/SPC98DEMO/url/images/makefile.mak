#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit example
#
# $Revision:   1.0  $
#
# $Date:   07 Aug 2007 11:05:52  $
#

WCH = examples
PROD = toolkit

all: files 


files:
%If "$(OSTYPE)" == "WINNT"
	@get $(CHKUPD) -u -n  *.giv
	@get $(CHKUPD) -u -n  *.jpv
%EndIf

