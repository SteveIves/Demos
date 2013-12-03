<CODEGEN_FILENAME><StructureName>.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>DataUtil</PROCESS_TEMPLATE>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.Runtime.Serialization

namespace <NAMESPACE>

    {Serializable}
    public class <StructureName> extends MarshalByRefObject implements ISerializable

.region "Backing storage for properties"

        <FIELD_LOOP>
        private m<FieldSqlName>, <field_spec>
        </FIELD_LOOP>

.endregion

.region "Constructors"

        ;;; <summary>
        ;;; Construct an empty <StructureName> object
        ;;; </summary>
        public method <StructureName>
            endparams
        proc
            <FIELD_LOOP>
            init m<FieldSqlName>
            </FIELD_LOOP>
        endmethod

        ;;; <summary>
        ;;; Construct a <StructureName> object containing the data from a <STRUCTURE_NOALIAS> record
        ;;; </summary>
        <FIELD_LOOP>
        ;;; <param name="a<FieldSqlName>">Passed <FIELD_DESC> (<field_spec>)</param>
        </FIELD_LOOP>
        public method <StructureName>
            <FIELD_LOOP>
            required in a<FieldSqlName>, <field_spec>
            </FIELD_LOOP>
            endparams
            this()
        proc
            ;;Save the data
            <FIELD_LOOP>
            m<FieldSqlName> = a<FieldSqlName>
            </FIELD_LOOP>
        endmethod

.endregion

.region "Public properties to expose individual fields"

        <FIELD_LOOP>
        ;;; <summary>
        ;;; <FIELD_DESC> (<FIELD_NAME>, <FIELD_SPEC>)
        ;;; </summary>
        public property <FieldSqlName>, <FIELD_CSTYPE>
            method get
            proc
                <IF ALPHA>
                mreturn %atrim(m<FieldSqlName>)
                </IF ALPHA>
                <IF DECIMAL>
                mreturn m<FieldSqlName>
                </IF DECIMAL>
                <IF DATE>
                mreturn DataUtils.DateFromDecimal(m<FieldSqlName>)
                </IF DATE>
                <IF TIME>
                mreturn DataUtils.TimeFromDecimal(m<FieldSqlName>)
                </IF TIME>
                <IF INTEGER>
                mreturn m<FieldSqlName>
                </IF INTEGER>
                <IF USER>
                mreturn m<FieldSqlName>
                </IF USER>
            endmethod
            method set
            proc
                <IF ALPHA>
                m<FieldSqlName> = value
                </IF ALPHA>
                <IF DECIMAL>
                m<FieldSqlName> = value
                </IF DECIMAL>
                <IF DATE_YYYYMMDD>
                m<FieldSqlName> = DataUtils.D8FromDate(value)
                </IF>
                <IF DATE_YYMMDD>
                m<FieldSqlName> = DataUtils.D6FromDate(value)
                </IF>
                <IF TIME_HHMMSS>
                m<FieldSqlName> = DataUtils.D6FromTime(value)
                </IF>
                <IF TIME_HHMM>
                m<FieldSqlName> = DataUtils.D4FromTime(value)
                </IF>
                <IF INTEGER>
                m<FieldSqlName> = value
                </IF INTEGER>
                <IF USER>
                m<FieldSqlName> = value
                </IF USER>
            endmethod
        endproperty

        </FIELD_LOOP>
.endregion

.region "ISerializable members"

        ;;; <summary>
        ;;; Serialize a <StructureName> object to a string
        ;;; </summary>
        public method GetObjectData, void
            info, @SerializationInfo
            context, StreamingContext
            endparams
        proc
            <FIELD_LOOP>
            info.AddValue("<FieldSqlName>",<FieldSqlName>,^typeof(<FIELD_CSTYPE>))
            </FIELD_LOOP>
        endmethod

        ;;; <summary>
        ;;; Deserialize a string back to a <StructureName> object
        ;;; </summary>
        public method <StructureName>
            info, @SerializationInfo
            context, StreamingContext
            endparams
        proc
            <FIELD_LOOP>
            <FieldSqlName> = (<FIELD_CSTYPE>)info.GetValue("<FieldSqlName>",^typeof(<FIELD_CSTYPE>))
            </FIELD_LOOP>
        endmethod

.endregion

    endclass

endnamespace

