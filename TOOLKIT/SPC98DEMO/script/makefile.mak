#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit examples/script
#
# $Revision:   1.5  $
#
# $Date:   Tue Feb 24 09:35:48 2004  $
#

WCH = examples
PROD = toolkit

SYNOPT  = $[f,$(DBLDIR),synergy,opt]

all: files scrcmp

.Include $[f,$(CONF),builtins,mak]

scrcmp:	scrcmp.$(EXEEXT)

%If "$(OSTYPE)" == "VMS"
scrcmp.$(EXEEXT): scrcmp.$(OBJEXT) scrcmp.opt $(SYNOPT)
	link scrcmp,scrcmp/opt,$(SYNOPT)/opt/exe=$@
%Else
scrcmp.$(EXEEXT): scrcmp.$(OBJEXT)
	dblink $(DBG) scrcmp WND:tklib.elb RPSLIB:ddlib.elb WND:script.elb
%EndIf

%If "$(OSTYPE)" == "VMS"
scrcmp.opt:
	%If %Exists($[f,$(CWD),scrcmp,opt])
		$(REMOVE) $[f,$(CWD),scrcmp,opt;*]
	%EndIf
	copy < <
CLUSTER = SYNERGY$$CODE
COLLECT = SYNERGY$$CODE,$DBLTRNSF_CODE,$CODE$
CLUSTER = SYNERGY$$READONLY
COLLECT = SYNERGY$$READONLY,$DBG$,$DBL_ADDR,$DBL_CODE,$DBL_LINCTL,$DBL_LITERAL
RPSLIB:ddlib/lib
V5LIB:DBLTLIB/LIB
WND:TKLIB_SH/SHARE
WND:SCRIPT_SH/SHARE
V5BIN:SYNRTL/SHARE
< scrcmp.opt
%EndIf

files:
	@get $(CHKUPD) -n *.dbv *.mak
%If "$(OSTYPE)" == "VMS"
	@get $(CHKUPD) -n scrcmp.cov
	@get $(CHKUPD) -n readme.txt
%Else
%If "$(OSTYPE)" == "WINNT"
	@get $(CHKUPD) -n scrcmp.bav
	@get $(CHKUPD) -n "readme.txv(README.TXT)"
%Else
	@get $(CHKUPD) -n scrcmp.env
	@get $(CHKUPD) -n "readme.txv(README.TXT)"
%EndIf
%EndIf

clearall: clean

clean:
%If "$(OSTYPE)" == "VMS"
%If %Exists($[f,$(CWD),scrcmp,$(EXEEXT)])
	$(REMOVE) $[f,$(CWD),scrcmp,$(EXEEXT);*]
%EndIf
%If %Exists($[f,$(CWD),scrcmp,$(OBJEXT)])
	$(REMOVE) $[f,$(CWD),scrcmp,$(OBJEXT);*]
%EndIf
%If %Exists($[f,$(CWD),scrcmp,opt])
	$(REMOVE) $[f,$(CWD),scrcmp,opt;*]
%EndIf
%Else
%If %Exists($[f,$(CWD),scrcmp,$(EXEEXT)])
	$(REMOVE) $[f,$(CWD),scrcmp,$(EXEEXT)]
%EndIf
%If %Exists($[f,$(CWD),scrcmp,$(OBJEXT)])
	$(REMOVE) $[f,$(CWD),scrcmp,$(OBJEXT)]
%EndIf
%EndIf
