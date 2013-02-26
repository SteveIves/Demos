dbl -dTX GoogleSearch.dbl
dbl -dTX GoogleSearchMarshalling.dbl
dbl -dTX SoapUtils.dbl
dbl -dTX SynList.dbl
dblink -d GoogleSearch SoapUtils SynList GoogleSearchMarshalling DBLDIR:synxml.elb
