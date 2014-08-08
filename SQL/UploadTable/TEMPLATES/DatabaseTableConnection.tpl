<CODEGEN_FILENAME>DatabaseConnection.dbl</CODEGEN_FILENAME>
;//****************************************************************************
;//
;// Title:       DatabaseTableConnection.tpl
;//
;// Type:        CodeGen Template
;//
;// Description: This template generates a class which can be used to create
;//              a connection to a SQL Server database. The resulting class
;//              is used by the classes generated from the DatabaseTable
;//              and DatabaseTableMapped templates.
;//
;// Date:        12th May 2012
;//
;// Author:      Steve Ives, Synergex Professional Services Group
;//              http://www.synergex.com
;//
;//****************************************************************************
;//
;// Copyright (c) 2012, Synergex International, Inc.
;// All rights reserved.
;//
;// Redistribution and use in source and binary forms, with or without
;// modification, are permitted provided that the following conditions are met:
;//
;// * Redistributions of source code must retain the above copyright notice,
;//   this list of conditions and the following disclaimer.
;//
;// * Redistributions in binary form must reproduce the above copyright notice,
;//   this list of conditions and the following disclaimer in the documentation
;//   and/or other materials provided with the distribution.
;//
;// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
;// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
;// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
;// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
;// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
;// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
;// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
;// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
;// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
;// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
;// POSSIBILITY OF SUCH DAMAGE.
;//
;;*****************************************************************************
;;
;; Title:       DatabaseConnection.dbl
;;
;; Type:        Class
;;
;; Description: Provides the ability to connect to, and represents a connection
;;              to a SQL Server database.
;;
;; Author:      <AUTHOR>
;;
;; Company:     <COMPANY>
;;
;;*****************************************************************************
;;
;; WARNING:     This code was generated by CodeGen. Any changes that you make
;;              to this file will be lost if the code is regenerated.
;;
;;*****************************************************************************
;;
import <NAMESPACE>

namespace <NAMESPACE>

    .include "CONNECTDIR:ssql.def"

    public class DatabaseConnection

		private mChannel, 		int
        private mConnectString,	string
        private mConnected, 	boolean, false

		private mMaxCursors, 	int
		private mMaxColumns, 	int
		private mBufferSize, 	int
		private mDbCursors,		int
		
        public method DatabaseConnection
            required in aChannel, int
            required in aConnectString, string
            endparams
        proc

			;;Save away the channel and connect string
            mChannel = aChannel
            mConnectString = aConnectString

			;;Set default values for other properties
			mMaxCursors = 128
			mMaxColumns = 254
            mBufferSize = 32768
			mDbCursors = mMaxCursors

			;Initialize SQL Connection
			begin
				data sts, int
				.ifdef OS_VMS
				xcall init_ssql
				.else
				sts=%option(48,1)
				.endc
			end

        endmethod

        method ~DatabaseConnection
            endparams
        proc
            if (mConnected)
                this.Disconnect()
        endmethod
		
		public method Connect, void
			endparams
		proc

            ;Initialize the database channel
            if (ssc_init(mChannel,maxCursors,maxColumns,bufferSize,dbCursors)==SSQL_FAILURE)
                throw new ApplicationException("Failed to initialize database channel")

            ;Connect to the database
            if (ssc_connect(mChannel,mConnectString)==SSQL_FAILURE)
            begin
                data errtxt, a512
                data tmpLen, int
                ssc_getemsg(mChannel,errtxt,tmpLen)
                throw new ApplicationException("Failed to connect to database. Error was: "+errtxt(1:tmpLen))
            end

            mConnected = true

		endmethod
		
        public method Disconnect, void
            endparams
        proc
            if (mConnected)
			begin
                ssc_release(mChannel)
				mConnected = false
			end
        endmethod
		
		;;Public properties
		
		public property Channel, int
			method get
			proc
				mreturn mChannel
			endmethod
		endproperty

		public property ConnectString, string
			method get
			proc
				mreturn mConnectString
			endmethod
		endproperty

		public property Connected, boolean
			method get
			proc
				mreturn mConnected
			endmethod
		endproperty

		public property MaxCursors, int
			method get
			proc
				mreturn mMaxCursors
			endmethod
			method set
			proc
				mMaxCursors = value
			endmethod
		endproperty

		public property MaxColumns, int
			method get
			proc
				mreturn mMaxColumns
			endmethod
			method set
			proc
				mMaxColumns = value
			endmethod
		endproperty

		public property BufferSize, int
			method get
			proc
				mreturn mBufferSize
			endmethod
			method set
			proc
				mBufferSize = value
			endmethod
		endproperty

		public property DbCursors, int
			method get
			proc
				mreturn mDbCursors
			endmethod
			method set
			proc
				mDbCursors = value
			endmethod
		endproperty
		
    endclass

endnamespace
