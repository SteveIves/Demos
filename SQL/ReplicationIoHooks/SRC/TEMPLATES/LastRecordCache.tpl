<CODEGEN_FILENAME>LastRecordCache.dbl</CODEGEN_FILENAME>

import Synergex.SynergyDE.IOExtensions
import Synergex.SynergyDE.Select

namespace <NAMESPACE>

	public static class LastRecordCache

		private static cache, [#]string

		static method LastRecordCache
		proc
			cache = new string[1024]
		endmethod

		public static method Init, void
			required in aChannel, int
			endparams
		proc
			cache[aChannel] = ""
		endmethod

		public static method Update, void
			required in aChannel, int
			required in aData, string
			endparams
		proc
			cache[aChannel] = aData
		endmethod

		public static method HasChanged, boolean
			required in aChannel, int
			required in aData, string
			endparams
		proc
			mreturn (aData != cache[aChannel])
		endmethod

		public static method Retrieve, string
			required in aChannel, int
		proc
			mreturn cache[aChannel]
		endmethod

		public static method Clear, void
			required in aChannel, int
		proc
			cache[aChannel] = ^null
		endmethod
	endclass

endnamespace