<CODEGEN_FILENAME><StructureName>Wrapper.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>DataUtils</PROCESS_TEMPLATE>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.Runtime.Serialization

namespace <NAMESPACE>

    .include "<STRUCTURE_NOALIAS>" repository, structure="str<StructureName>", end

    {Serializable}
    public class <StructureName>Wrapper extends MarshalByRefObject implements ISerializable
		    
        internal m<StructureName>, str<StructureName>

        public method <StructureName>Wrapper
			      endparams
        proc
            init m<StructureName>
        endmethod

        public method <StructureName>Wrapper
            info, @SerializationInfo
            context, StreamingContext
            endparams
            this()
        proc
            throw new System.NotImplementedException("This <StructureName>Wrapper constructor should never be called!")
        endmethod
		
        public method GetObjectData, void
            info, @SerializationInfo 
            context, StreamingContext 
            endparams
        proc
            throw new System.NotImplementedException("<StructureName>Wrapper.GetObjectData should never be called!")
        endmethod
        
        public property Record, String
            method get
            proc
                mreturn (String)m<StructureName>
            endmethod
            method set
            proc
                m<StructureName> = value
            endmethod
        endproperty

        <FIELD_LOOP>
        ;;; <summary>
        ;;; <FIELD_DESC> (<FIELD_NAME>, <FIELD_SPEC>)
        ;;; </summary>
        public property <FieldNetName>, <FIELD_SNTYPE>
            method get
            proc
                <IF ALPHA>
                mreturn %atrim(m<StructureName>.<field_name>)
                </IF ALPHA>
                <IF DECIMAL>
                mreturn m<StructureName>.<field_name>
                </IF DECIMAL>
                <IF DATE>
                mreturn DataUtils.DateFromDecimal(m<StructureName>.<field_name>)
                </IF DATE>
                <IF TIME>
                mreturn DataUtils.TimeFromDecimal(m<StructureName>.<field_name>)
                </IF TIME>
                <IF INTEGER>
                mreturn m<StructureName>.<field_name>
                </IF INTEGER>
                <IF USER>
                mreturn m<StructureName>.<field_name>
                </IF USER>
            endmethod
            method set
            proc
                <IF ALPHA>
                m<StructureName>.<field_name> = value
                </IF ALPHA>
                <IF DECIMAL>
                m<StructureName>.<field_name> = value
                </IF DECIMAL>
                <IF DATE_YYYYMMDD>
                m<StructureName>.<field_name> = DataUtils.D8FromDate(value)
                </IF>
                <IF DATE_YYMMDD>
                m<StructureName>.<field_name> = DataUtils.D6FromDate(value)
                </IF>
                <IF TIME_HHMMSS>
                m<StructureName>.<field_name> = DataUtils.D6FromTime(value)
                </IF>
                <IF TIME_HHMM>
                m<StructureName>.<field_name> = DataUtils.D4FromTime(value)
                </IF>
                <IF INTEGER>
                m<StructureName>.<field_name> = value
                </IF INTEGER>
                <IF USER>
                m<StructureName>.<field_name> = value
                </IF USER>
            endmethod
        endproperty

        </FIELD_LOOP>

	endclass

endnamespace

                