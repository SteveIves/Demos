#
# Source:	makefile.mak
#
# Description:	Makefile for building the toolkit examples/data
#
# $Revision:   1.5  $
#
# $Date:   Tue Feb 24 09:33:30 2004  $
#

WCH = examples
PROD = toolkit

all: files data

.INCLUDE $[f,$(CONF),builtins,mak]

files: 
	@get $(CHKUPD) -n *.ddv *.pav *.mak

data: descrip.ism price.ism quote_detail.ism quote_head.ism

descrip.ism: descrip.par descrip.ddf
%If "$(OSTYPE)" == "VMS"
%If %Exists(descrip.ism)
	$(REMOVE) descrip.ism;*
%EndIf
%Else
%If %Exists(descrip.ism)
	$(REMOVE) descrip.ism
%EndIf
%If %Exists(descrip.is1)
	$(REMOVE) descrip.is1
%EndIf
%EndIf
%If "$(OSTYPE)" == "VMS"
	|@< <
$ run DBLDIR:bldism
@descrip.par
$EOD
<
	|@< <
$ run DBLDIR:isload
load
descrip
descrip

$EOD
<
%Else
	$(STRT) dbr DBLDIR:bldism <<<
@ICSTUT:descrip.par

<
	$(STRT) dbr DBLDIR:isload <<<
load
descrip
descrip

<
%EndIf

price.ism: price.par price.ddf
%If "$(OSTYPE)" == "VMS"
%If %Exists(price.ism)
	$(REMOVE) price.ism;*
%EndIf
%Else
%If %Exists(price.ism)
	$(REMOVE) price.ism
%EndIf
%If %Exists(price.is1)
	$(REMOVE) price.is1
%EndIf
%EndIf
%If "$(OSTYPE)" == "VMS"
	|@< <
$ run DBLDIR:bldism
@price.par
$EOD
<
	|@< <
$ run DBLDIR:isload
load
price
price

$EOD
<
%Else
	$(STRT) dbr DBLDIR:bldism <<<
@ICSTUT:price.par

<
	$(STRT) dbr DBLDIR:isload <<<
load
price
price

<
%EndIf

quote_detail.ism: quote_detail.par quote_detail.ddf
%If "$(OSTYPE)" == "VMS"
%If %Exists(quote_detail.ism)
	$(REMOVE) quote_detail.ism;*
%EndIf
%Else
%If %Exists(quote_detail.ism)
	$(REMOVE) quote_detail.ism
%EndIf
%If %Exists(quote_detail.is1)
	$(REMOVE) quote_detail.is1
%EndIf
%EndIf
%If "$(OSTYPE)" == "VMS"
	|@< <
$ run DBLDIR:bldism
@quote_detail.par
$EOD
<
	|@< <
$ run DBLDIR:isload
load
quote_detail
quote_detail

$EOD
<
%Else
	$(STRT) dbr DBLDIR:bldism <<<
@ICSTUT:quote_detail.par

<
	$(STRT) dbr DBLDIR:isload <<<
load
quote_detail
quote_detail

<
%EndIf

quote_head.ism: quote_head.par quote_head.ddf
%If "$(OSTYPE)" == "VMS"
%If %Exists(quote_head.ism)
	$(REMOVE) quote_head.ism;*
%EndIf
%Else
%If %Exists(quote_head.ism)
	$(REMOVE) quote_head.ism
%EndIf
%If %Exists(quote_head.is1)
	$(REMOVE) quote_head.is1
%EndIf
%EndIf
%If "$(OSTYPE)" == "VMS"
	|@< <
$ run DBLDIR:bldism
@quote_head.par
$EOD
<
	|@< <
$ run DBLDIR:isload
load
quote_head
quote_head

$EOD
<
%Else
	$(STRT) dbr DBLDIR:bldism <<<
@ICSTUT:quote_head.par

<
	$(STRT) dbr DBLDIR:isload <<<
load
quote_head
quote_head

<
%EndIf

clearall: clean

clean:
%If "$(OSTYPE)" == "VMS"
%If %Exists(descrip.ism)
	$(REMOVE) descrip.ism;*
%EndIf
%If %Exists(price.ism)
	$(REMOVE) price.ism;*
%EndIf
%If %Exists(quote_detail.ism)
	$(REMOVE) quote_detail.ism;*
%EndIf
%If %Exists(quote_head.ism)
	$(REMOVE) quote_head.ism;*
%EndIf
%Else
%If %Exists(descrip.ism)
	$(REMOVE) descrip.ism
%EndIf
%If %Exists(descrip.is1)
	$(REMOVE) descrip.is1
%EndIf
%If %Exists(price.ism)
	$(REMOVE) price.ism
%EndIf
%If %Exists(price.is1)
	$(REMOVE) price.is1
%EndIf
%If %Exists(quote_detail.ism)
	$(REMOVE) quote_detail.ism
%EndIf
%If %Exists(quote_detail.is1)
	$(REMOVE) quote_detail.is1
%EndIf
%If %Exists(quote_head.ism)
	$(REMOVE) quote_head.ism
%EndIf
%If %Exists(quote_head.is1)
	$(REMOVE) quote_head.is1
%EndIf
%EndIf
