<CODEGEN_FILENAME>SingletonBehaviorAttribute.dbl</CODEGEN_FILENAME>
<PROCESS_TEMPLATE>ServiceInstanceProvider</PROCESS_TEMPLATE>
<REQUIRES_USERTOKEN>WCF_INTERFACE</REQUIRES_USERTOKEN>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.ServiceModel.Channels
import System.ServiceModel.Description
import System.ServiceModel.Dispatcher

namespace <NAMESPACE>
	
	public class SingletonBehaviorAttribute extends Attribute implements IContractBehaviorAttribute, IContractBehavior
		
		public property TargetContract, @Type
			method get
			proc
				mreturn ^typeof(<WCF_INTERFACE>)
			endmethod
		endproperty
		
		public method AddBindingParameters, void
			description, @ContractDescription 
			endpoint, @ServiceEndpoint 
			parameters, @BindingParameterCollection 
			endparams
		proc
		endmethod
		
		public method ApplyClientBehavior, void
			description, @ContractDescription 
			endpoint, @ServiceEndpoint 
			clientRuntime, @ClientRuntime 
			endparams
		proc
		endmethod
		
		public method ApplyDispatchBehavior, void
			description, @ContractDescription 
			endpoint, @ServiceEndpoint 
			dispatch, @DispatchRuntime 
			endparams
		proc
			dispatch.InstanceProvider = new ServiceInstanceProvider()
		endmethod
		
		public method Validate, void
			description, @ContractDescription 
			endpoint, @ServiceEndpoint 
			endparams
		proc
		endmethod
		
	endclass
	
endnamespace
