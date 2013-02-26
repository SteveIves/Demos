if exist %DAT%\cusmas.ism del /q %DAT%\cusmas.ism
if exist %DAT%\cusmas.is1 del /q %DAT%\cusmas.is1
if exist %DAT%\invgrp.ism del /q %DAT%\invgrp.ism
if exist %DAT%\invgrp.is1 del /q %DAT%\invgrp.is1
if exist %DAT%\invmas.ism del /q %DAT%\invmas.ism
if exist %DAT%\invmas.is1 del /q %DAT%\invmas.is1
if exist %DAT%\ordhdr.ism del /q %DAT%\ordhdr.ism
if exist %DAT%\ordhdr.is1 del /q %DAT%\ordhdr.is1
if exist %DAT%\ordlin.ism del /q %DAT%\ordlin.ism
if exist %DAT%\ordlin.is1 del /q %DAT%\ordlin.is1
fconvert -it DAT:cusmas.seq -oi DAT:cusmas.ism -d XDL:cusmas.xdl
fconvert -it DAT:invgrp.seq -oi DAT:invgrp.ism -d XDL:invgrp.xdl
fconvert -it DAT:invmas.seq -oi DAT:invmas.ism -d XDL:invmas.xdl
fconvert -it DAT:ordhdr.seq -oi DAT:ordhdr.ism -d XDL:ordhdr.xdl
fconvert -it DAT:ordlin.seq -oi DAT:ordlin.ism -d XDL:ordlin.xdl
