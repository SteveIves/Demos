<CODEGEN_FILENAME>ServiceInstanceProvider.dbl</CODEGEN_FILENAME>
<REQUIRES_USERTOKEN>WCF_SERVICE</REQUIRES_USERTOKEN>
<PROCESS_TEMPLATE>BackgroundDispatcher</PROCESS_TEMPLATE>
<PROCESS_TEMPLATE>IsolatableServiceBase</PROCESS_TEMPLATE>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System
import System.ServiceModel
import System.ServiceModel.Channels
import System.ServiceModel.Dispatcher

namespace <NAMESPACE>

	public class ServiceInstanceProvider implements IInstanceProvider
		
		public method GetInstance, @object
			instanceContext, @InstanceContext 
			message, @Message 
			endparams
		proc
			data instanceAppDomain, @AppDomain, AppDomain.CreateDomain(Guid.NewGuid().ToString())
			data service, @<WCF_SERVICE>, (@<WCF_SERVICE>)instanceAppDomain.CreateInstanceAndUnwrap(^typeof(<WCF_SERVICE>).Assembly.FullName, ^typeof(<WCF_SERVICE>).FullName)
			service.ServiceDispatcher = BackgroundDispatcher.AllocateDispatcher()
			mreturn service
		endmethod
		
		public method GetInstance, @object
			instanceContext, @InstanceContext 
			endparams
		proc
			mreturn this.GetInstance(instanceContext, ^null)
		endmethod
		
		public method ReleaseInstance, void
			instanceContext, @InstanceContext 
			instance, @object 
			endparams
		proc
			data instanceAppDomain = ((@IsolatableServiceBase)instance).GetAppDomain()
			BackgroundDispatcher.DeallocateDispatcher(((@IsolatableServiceBase)instance).ServiceDispatcher)
			AppDomain.Unload(instanceAppDomain)
		endmethod
	
	endclass

endnamespace

