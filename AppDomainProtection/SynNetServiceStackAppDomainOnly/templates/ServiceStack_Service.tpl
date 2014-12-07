<CODEGEN_FILENAME><StructureName>sService.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>LOGIC_PROJECT</REQUIRES_USERTOKEN>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import System
import System.Collections.Generic
import System.Reflection
import System.Web
import ServiceStack
import AppDomainProtection
import <LOGIC_PROJECT>

namespace <NAMESPACE>

.region "<StructureName>sService"

    public partial class <StructureName>sService extends Service

        public method Any, @<StructureName>CreateResponse
            required in request, @<StructureName>Create
            endparams
        proc
            data api, @<StructureName>sLogic, BusinessLogicFactory.GetInstance<<StructureName>sLogic>()
            data sts, MethodStatus, api.Create<StructureName>(request.<StructureName>)
            BusinessLogicFactory.ReleaseInstance(api)
            mreturn new <StructureName>CreateResponse(sts)
        endmethod

        public method Any, @<StructureName>ReadResponse
            required in request, @<StructureName>Read
            endparams
        proc
            data api, @<StructureName>sLogic, BusinessLogicFactory.GetInstance<<StructureName>sLogic>()
            data <structureName>, @<StructureName>
            data grfa, string
            data sts, MethodStatus, api.Read<StructureName>(<PRIMARY_KEY><SEGMENT_LOOP>request.<SegmentName><IF MORE>,</IF></SEGMENT_LOOP></PRIMARY_KEY>,<structureName>,grfa)
            data response, @<StructureName>ReadResponse, new <StructureName>ReadResponse(sts,<structureName>,grfa)
            BusinessLogicFactory.ReleaseInstance(api)
            mreturn response
        endmethod

        public method Any, @<StructureName>ReadAllResponse
            required in request, @<StructureName>ReadAll
            endparams
        proc
            data api, @<StructureName>sLogic, BusinessLogicFactory.GetInstance<<StructureName>sLogic>()
            data <structureName>s, @List<<StructureName>>
            data sts, MethodStatus, api.ReadAll<StructureName>s(<structureName>s)
            data response, @<StructureName>ReadAllResponse, new <StructureName>ReadAllResponse(sts,<structureName>s)
            BusinessLogicFactory.ReleaseInstance(api)
            mreturn response
        endmethod

        public method Any, @<StructureName>UpdateResponse
            required in request, @<StructureName>Update
            endparams
        proc
            data api, @<StructureName>sLogic, BusinessLogicFactory.GetInstance<<StructureName>sLogic>()
            data <structureName>, @<StructureName>, request.<StructureName>
            data grfa, string, request.grfa
            data sts, MethodStatus, api.Update<StructureName>(<structureName>,grfa)
            data response, @<StructureName>UpdateResponse, new <StructureName>UpdateResponse(sts,<structureName>,grfa)
            BusinessLogicFactory.ReleaseInstance(api)
            mreturn response
        endmethod

        public method Any, @<StructureName>DeleteResponse
            required in request, @<StructureName>Delete
            endparams
        proc
            data api, @<StructureName>sLogic, BusinessLogicFactory.GetInstance<<StructureName>sLogic>()
            data sts, MethodStatus, api.Delete<StructureName>(request.Grfa)
            BusinessLogicFactory.ReleaseInstance(api)
            mreturn new <StructureName>DeleteResponse(sts)
        endmethod

        public method Any, @<StructureName>ExistsResponse
            required in request, @<StructureName>Exists
            endparams
        proc
            data api, @<StructureName>sLogic, BusinessLogicFactory.GetInstance<<StructureName>sLogic>()
            data sts, MethodStatus, api.<StructureName>Exists(<PRIMARY_KEY><SEGMENT_LOOP>request.<SegmentName><IF MORE>,</IF></SEGMENT_LOOP></PRIMARY_KEY>)
            BusinessLogicFactory.ReleaseInstance(api)
            mreturn new <StructureName>ExistsResponse(sts)
        endmethod

    endclass

.endregion

.region "<StructureName>Create DTO's"

    {Route("/<structureName>s", "POST")}
    public class <StructureName>Create implements IReturn<<StructureName>CreateResponse>

        public property <StructureName>, @<StructureName>
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

    public class <StructureName>CreateResponse

        public method <StructureName>CreateResponse
            required in aStatus, MethodStatus
            endparams
        proc
            Status = aStatus
        endmethod

        public property Status, MethodStatus
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

.endregion

.region "<StructureName>Read DTO's"

    {Route("/<structureName>s/<PRIMARY_KEY><SEGMENT_LOOP>{<SegmentName>}<IF MORE>/</IF></SEGMENT_LOOP></PRIMARY_KEY>", "GET")}
    public class <StructureName>Read implements IReturn<<StructureName>ReadResponse>

        <PRIMARY_KEY>
        <SEGMENT_LOOP>
        public property <SegmentName>, <SEGMENT_SNTYPE>
            method get
            endmethod
            method set
            endmethod
        endproperty

        </SEGMENT_LOOP>
        </PRIMARY_KEY>
      endclass

    public class <StructureName>ReadResponse

        public method <StructureName>ReadResponse
            required in aStatus, MethodStatus
            required in a<StructureName>, @<StructureName>
            required in aGrfa, String
            endparams
        proc
            Status = aStatus
            <StructureName> = a<StructureName>
            Grfa = aGrfa
        endmethod

        public property Status, MethodStatus
            method get
            endmethod
            method set
            endmethod
        endproperty

        public property <StructureName>, @<StructureName>
            method get
            endmethod
            method set
            endmethod
        endproperty

        public property Grfa, String
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

.endregion

.region "<StructureName>ReadAll DTO's"

    {Route("/<structureName>s", "GET")}
    public class <StructureName>ReadAll implements IReturn<<StructureName>ReadAllResponse>

    endclass

    public class <StructureName>ReadAllResponse

        public method <StructureName>ReadAllResponse
            required in aStatus, MethodStatus
            required in a<StructureName>s, @List<<StructureName>> 
            endparams
        proc
            Status = aStatus
            <StructureName>s = a<StructureName>s
        endmethod

        public property Status, MethodStatus
            method get
            endmethod
            method set
            endmethod
        endproperty

        public property <StructureName>s, @List<<StructureName>>
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

.endregion

.region "<StructureName>Update DTO's"

    {Route("/<structureName>s", "PUT")}
    public class <StructureName>Update implements IReturn<<StructureName>UpdateResponse>

        public property <StructureName>, @<StructureName>
            method get
            endmethod
            method set
            endmethod
        endproperty

        public property Grfa, String
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

    public class <StructureName>UpdateResponse

        public method <StructureName>UpdateResponse
            required in aStatus, MethodStatus
            required in a<StructureName>, @<StructureName>
            required in aGrfa, String
            endparams
        proc
            Status = aStatus
            <StructureName> = a<StructureName>
            Grfa = aGrfa
        endmethod

        public property Status, MethodStatus
            method get
            endmethod
            method set
            endmethod
        endproperty

        public property <StructureName>, @<StructureName>
            method get
            endmethod
            method set
            endmethod
        endproperty

        public property Grfa, String
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

.endregion	

.region "<StructureName>Delete DTO's"

    {Route("/<structureName>s/{Grfa}", "DELETE")}
    public class <StructureName>Delete implements IReturn<<StructureName>DeleteResponse>

        public property Grfa, string
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

    public class <StructureName>DeleteResponse

        public method <StructureName>DeleteResponse
            required in aStatus, MethodStatus
            endparams
        proc
            Status = aStatus
        endmethod

        public property Status, MethodStatus
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

.endregion

.region "<StructureName>Exists DTO's"

    {Route("/<structureName>s/exist/<PRIMARY_KEY><SEGMENT_LOOP>{<SegmentName>}<IF MORE>/</IF></SEGMENT_LOOP></PRIMARY_KEY>", "GET")}
    public class <StructureName>Exists implements IReturn<<StructureName>ExistsResponse>

        <PRIMARY_KEY>
        <SEGMENT_LOOP>
        public property <SegmentName>, <SEGMENT_SNTYPE>
            method get
            endmethod
            method set
            endmethod
        endproperty

        </SEGMENT_LOOP>
        </PRIMARY_KEY>
    endclass

    public class <StructureName>ExistsResponse

        public method <StructureName>ExistsResponse
            required in aStatus, MethodStatus
            endparams
        proc
            Status = aStatus
        endmethod

        public property Status, MethodStatus
            method get
            endmethod
            method set
            endmethod
        endproperty

    endclass

.endregion

endnamespace
