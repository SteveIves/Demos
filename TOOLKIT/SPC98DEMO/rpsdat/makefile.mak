#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit examples/rpsdat
#
# $Revision:   1.6  $
#
# $Date:   Tue Feb 24 09:33:54 2004  $
#

WCH = examples
PROD = toolkit

all: files data

.include $[f,$(CONF),builtins,mak]

files:
	@get $(CHKUPD) -n spcdemo.sdv
	@get $(CHKUPD) -n *.mak

data: rpsmain.ism

rpsmain.ism: spcdemo.sdl
%If "$(OSTYPE)" == "VMS"
%If %Exists(rpsmain.ism)
	$(REMOVE) rpsmain.ism;*
%EndIf
%If %Exists(rpstext.ism)
	$(REMOVE) rpstext.ism;*
%EndIf
	rpsutl:=$RPS:rpsutl.exe
	rpsutl -i spcdemo.sdl -ia -d rpsmain.ism rpstext.ism
%Else
%If %Exists(rpsmain.ism)
	$(REMOVE) rpsmain.ism
%EndIf
%If %Exists(rpsmain.is1)
	$(REMOVE) rpsmain.is1
%EndIf
%If %Exists(rpstext.ism)
	$(REMOVE) rpstext.ism
%EndIf
%If %Exists(rpstext.is1)
	$(REMOVE) rpstext.is1
%EndIf
	dbr RPS:rpsutl -i spcdemo.sdl -ia -d rpsmain.ism rpstext.ism 
%EndIf

clearall: clean

clean:
%If "$(OSTYPE)" == "VMS"
%If %Exists(rpsmain.ism)
	$(REMOVE) rpsmain.ism;*
%EndIf
%If %Exists(rpstext.ism)
	$(REMOVE) rpstext.ism;*
%EndIf
%Else
%If %Exists(rpsmain.ism)
	$(REMOVE) rpsmain.ism
%EndIf
%If %Exists(rpsmain.is1)
	$(REMOVE) rpsmain.is1
%EndIf
%If %Exists(rpstext.ism)
	$(REMOVE) rpstext.ism
%EndIf
%If %Exists(rpstext.is1)
	$(REMOVE) rpstext.is1
%EndIf
%EndIf
