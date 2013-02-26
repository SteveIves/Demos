#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit example
#
# $Revision:   1.0  $
#
# $Date:   06 Aug 2007 14:24:40  $
#

WCH = examples
PROD = toolkit

all: files 


files:
%If "$(OSTYPE)" == "WINNT"
	@get $(CHKUPD) -u -n  *.ocv
%EndIf

