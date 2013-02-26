#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit examples/script
#
# $Revision:   1.7  $
#
# $Date:   Tue Feb 24 09:35:24 2004  $
#

WCH = examples
PROD = toolkit

all: files libr exec

.include $[f,$(CONF),builtins,mak]

.PATH.def = $(CWD);$(WND);$(DBLDIR)
.PATH.gbl = $(CWD)
.PATH.inc = $(CWD)

DEMOSRC	= demoprog.dbl about.dbl add_line.dbl file_io.dbl help_system.dbl \
		i_disable_set.dbl i_enable_set.dbl \
		print_quote.dbl progress.dbl sendmail.dbl \
		webbrowser.dbl who_details.dbl \
		wizard_setup.dbl convert_spc_wizard.dbl
DEMOINC	= demoprog.def io.def io_arg.inc io_std.inc wizard_setup.gbl

%If "$(OSTYPE)" == "VMS"
RPSPTH = [-.rpsdat]
LIBPTH = [-.library]
EXEPTH = [-.execute]
%Else
%if "$(OSTYPE)" == "WINNT"
RPSPTH = ..\rpsdat
LIBPTH = ..\library
EXEPTH = ..\execute
%Else
RPSPTH = ../rpsdat
LIBPTH = ../library
EXEPTH = ../execute
%EndIf
%EndIf

%If "$(OSTYPE)" != "VMS"
%If "$(OSTYPE)" == "WINNT"
%SetEnv DEMOSRC=$(CWD)
%SetEnv DEMOLIB=$(LIBPTH)
%SetEnv RPSMFIL=$[f,$(RPSPTH),rpsmain,ism]
%SetEnv RPSTFIL=$[f,$(RPSPTH),rpstext,ism]
%echo Using SetEnv on WINNT
%Else
%If "$[C,$(_Version),1,4]" == "V5.3"
%SetEnv DEMOSRC=$(CWD)
%SetEnv DEMOLIB=$(LIBPTH)
%SetEnv RPSMFIL=$[f,$(RPSPTH),rpsmain,ism]
%SetEnv RPSTFIL=$[f,$(RPSPTH),rpstext,ism]
%echo Using SetEnv on V5.3
%Else
%If "$[C,$(_Version),1,3]" == "5.3"
%SetEnv DEMOSRC=$(CWD)
%SetEnv DEMOLIB=$(LIBPTH)
%SetEnv RPSMFIL=$[f,$(RPSPTH),rpsmain,ism]
%SetEnv RPSTFIL=$[f,$(RPSPTH),rpstext,ism]
%echo Using SetEnv on 5.3
%Else
DEMOSRC=$(CWD)
RPSMFIL=$[f,$(RPSPTH),rpsmain,ism]
RPSTFIL=$[f,$(RPSPTH),rpstext,ism]
%echo NOT Using SetEnv on $(_Version)
%EndIf
%EndIf
%EndIf
%Else
%If "$[C,$(_Version),1,4]" == "V5.3"
%SetEnv DEMOSRC=$(CWD)
%SetEnv DEMOLIB=$(LIBPTH)
%SetEnv RPSMFIL=$[f,$(RPSPTH),rpsmain,ism]
%SetEnv RPSTFIL=$[f,$(RPSPTH),rpstext,ism]
%echo VMS Using SetEnv on $(_Version)
%Else
%echo VMS NOT Using SetEnv on $(_Version)
%EndIf
%EndIf

%If "$(OSTYPE)" == "VMS"
SYNOPT	= $[f,$(DBLDIR),synergy,opt]
%EndIf

libr: cleanlib demoprog.wsc
%If "$(OSTYPE)" == "VMS"
	script:==$WND:script
	script -c $[f,$(LIBPTH),demo,ism] -i demoprog.wsc
%Else
	$(STRT) dbr WND:script -c $[f,$(LIBPTH),demo,ism] -i demoprog.wsc
%EndIf

%If "$(OSTYPE)" == "VMS"
exec:	$(DEMOSRC) demoprog.opt
	dbl demoprog/DEBUG/TRIM/IMPLICIT
	link demoprog,demoprog.opt/opt,$(SYNOPT)/opt/exe=$[f,$(EXEPTH),demoprog,$(EXEEXT)]
%Else
exec:	$(DEMOSRC)
	dbl -TXd demoprog
%if "$(OSTYPE)" == "WINNT"
	dblink -do $[f,$(EXEPTH),demoprog,$(EXEEXT)] demoprog DBLDIR:axlib.elb WND:tklib.elb RPSLIB:ddlib.elb
%Else
	dblink -do $[f,$(EXEPTH),demoprog,$(EXEEXT)] demoprog WND:tklib.elb RPSLIB:ddlib.elb
%EndIf
%EndIf

%If "$(OSTYPE)" == "VMS"
demoprog.opt:
	%If %Exists($[f,$(CWD),demoprog,opt])
		$(REMOVE) $[f,$(CWD),demoprog,opt;*]
	%EndIf
	copy < <
CLUSTER = synergy$$code
COLLECT = synergy$$code,$DBLTRNSF_CODE,$CODE$
CLUSTER = synergy$$READONLY
COLLECT = synergy$$readonly,$DBG$,$DBL_ADDR,$DBL_CODE,$DBL_LINCTL,$DBL_LITERAL
WND:TKLIB_SH.EXE/SHARE
RPSLIB:DDLIB/LIB
V5BIN:synrtl/SHARE
V5LIB:DBLTLIB/LIB
< demoprog.opt
%EndIf

					# Include source dependencies
%If %Exists($[f,$(CWD),deps,mak])
.INCLUDE $[f,$(CWD),deps,mak]
%EndIf

files:
	@get $(CHKUPD) -n *.dbv *.inv *.wsv *.psv *.dev *.gbv *.mak

clearall: clean

clean: cleanlib
%If "$(OSTYPE)" == "VMS"
%If %Exists($[f,$(EXEPTH),demoprog,$(EXEEXT)])
	$(REMOVE) $[f,$(EXEPTH),demoprog,$(EXEEXT);*]
%EndIf
%If %Exists($[f,$(CWD),demoprog,$(OBJEXT)])
	$(REMOVE) $[f,$(CWD),demoprog,$(OBJEXT);*]
%EndIf
%If %Exists($[f,$(CWD),demoprog,opt])
	$(REMOVE) $[f,$(CWD),demoprog,opt;*]
%EndIf
%Else
%If %Exists($[f,$(EXEPTH),demoprog,$(EXEEXT)])
	$(REMOVE) $[f,$(EXEPTH),demoprog,$(EXEEXT)]
%EndIf
%If %Exists($[f,$(CWD),demoprog,$(OBJEXT)])
	$(REMOVE) $[f,$(CWD),demoprog,$(OBJEXT)]
%EndIf
%EndIf

cleanlib:
%If "$(OSTYPE)" == "VMS"
%If %Exists($[f,$(LIBPTH),demo,ism])
	$(REMOVE) $[f,$(LIBPTH),demo,ism;*]
%EndIf
%Else
%If %Exists($[f,$(LIBPTH),demo,ism])
	$(REMOVE) $[f,$(LIBPTH),demo,ism]
%EndIf
%If %Exists($[f,$(LIBPTH),demo,is1])
	$(REMOVE) $[f,$(LIBPTH),demo,is1]
%EndIf
%EndIf
