#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit example
#
# $Revision:   1.0  $
#
# $Date:   07 Aug 2007 10:44:12  $
#

WCH = examples
PROD = toolkit

all: files 


files:
%If "$(OSTYPE)" == "WINNT"
	@get $(CHKUPD) -u -n  *.avv
	@get $(CHKUPD) -u -n  *.icv
	@get $(CHKUPD) -u -n  *.wvv
	@get $(CHKUPD) -u -n  *.bmv
%EndIf

