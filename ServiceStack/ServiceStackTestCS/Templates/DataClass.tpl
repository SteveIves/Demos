<CODEGEN_FILENAME><StructureName>.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>DataWrapper</PROCESS_TEMPLATE>
;;******************************************************************************
;; WARNING: THIS FILE WAS CODE GENERATED. CHANGES MAY BE LOST IF REGENERATED
;;******************************************************************************

import System
import System.Runtime.Serialization

namespace <NAMESPACE>

    {Serializable}
    public cls class <StructureName>

        private wrapper, @<StructureName>Wrapper

        ;;; <summary>
        ;;; Construct an empty <StructureName> object
        ;;; </summary>
        public method <StructureName>
            endparams
        proc
            wrapper = new <StructureName>Wrapper()
        endmethod

        ;;; <summary>
        ;;; Construct a <StructureName> object containing the data from a <STRUCTURE_NOALIAS> record
        ;;; </summary>
        ;;; <param name="a<StructureName>">Passed <StructureName> record</param>
        internal method <StructureName>
            required in a<StructureName>, String
            endparams
            this()
        proc
            ;;Save the record
            wrapper.Record = a<StructureName>
        endmethod

        internal property Record, String
            method get
            proc
                mreturn wrapper.Record
            endmethod
        endproperty

        ;;Expose the fields in the Synergy record as properties, using .NET types

        <FIELD_LOOP>
        ;;; <summary>
        ;;; <FIELD_DESC>
        ;;; </summary>
        public property <FieldNetName>, <FIELD_SNTYPE>
            method get
            proc
                mreturn wrapper.<FieldNetName>
            endmethod
            method set
            proc
                wrapper.<FieldNetName> = value
            endmethod
        endproperty

        </FIELD_LOOP>

    endclass

endnamespace
