<CODEGEN_FILENAME>I<StructureName>Service.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<REQUIRES_USERTOKEN>API_NAMESPACE</REQUIRES_USERTOKEN>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.Collections.Generic
import System.Runtime.Serialization
import System.ServiceModel
import System.Threading.Tasks
import <API_NAMESPACE>

namespace <NAMESPACE>

	{ServiceContract(SessionMode = SessionMode.Required)}
	{SingletonBehaviorAttribute()}
	public partial interface I<WCF_SERVICE>
		
		{OperationContract}
		method Create<StructureName>, MethodStatus
			required in a<StructureName>, @<StructureName>
		endmethod
			
    <PRIMARY_KEY>
		{OperationContract}
		method Read<StructureName>, MethodStatus
      <SEGMENT_LOOP>
      required in  a<SegmentName>, <SEGMENT_CSTYPE>
      </SEGMENT_LOOP>
			required out a<StructureName>, @<StructureName>
			required out aGrfa, String
		endmethod
    </PRIMARY_KEY>

		{OperationContract}
		method ReadAll<StructureName>s, MethodStatus
			required out a<StructureName>s, @List<<StructureName>>
		endmethod

		{OperationContract}
		method Update<StructureName>, MethodStatus
			required inout a<StructureName>, @<StructureName>
			required inout aGrfa, String
		endmethod

		{OperationContract}
		method Delete<StructureName>, MethodStatus
			required in aGrfa, String
		endmethod
		
    <PRIMARY_KEY>
		{OperationContract}
		method <StructureName>Exists, MethodStatus
      <SEGMENT_LOOP>
      required in a<SegmentName>, <SEGMENT_CSTYPE>
      </SEGMENT_LOOP>
		endmethod
    </PRIMARY_KEY>
		
	endinterface
		
endnamespace
