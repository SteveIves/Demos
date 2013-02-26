// Generated on 14-Dec-2010 5:40:14 by gencs v1.0.11.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Collections;
using System.Reflection;
#if POOLING
using System.EnterpriseServices;
#endif
using Synergex.xfnlnet;
namespace spc2010
{
/// <summary>
/// Procedural Interface Class SynergyComponent
/// </summary>
#if POOLING
	[ObjectPooling()]
	public class SynergyServer : ServicedComponent, ISynergyServer
#else
	public class SynergyServer : ISynergyServer
#endif
	{
		/// <summary>
		/// constructor
		/// </summary>
		public SynergyServer()
		{
			m_xfnet = new XFNet(this);
			m_xfnet.initialize();
		}
#if POOLING
		/// <summary>
		/// release method for pooling
		/// </summary>
		~SynergyServer()
		{
			Dispose(false);
		}
		private new void Dispose(Boolean disposing)
		{
			m_xfnet.disconnect(disposing);
		}
#endif
		/// <summary>
		/// Returns an address record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="AddressID">Passed address ID</param>
		/// <param name="Address">Returned address structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status GetAddressForUpdate (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int AddressID
			,[XFAttr(dir=XFAttr.xfdir.OUT)]ref Address Address
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.OUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]ref string Message
		)
		{
			object[] pa = new object[5];
			pa[0]=CustomerID;
			pa[1]=AddressID;
			pa[2]=Address;
			pa[3]=GRFA;
			pa[4]=Message;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("GetAddressForUpdate",ref pa);
			Address=(Address)pa[2];
			GRFA=(byte[])pa[3];
			Message=(string)pa[4];
			return ret;
		}
		/// <summary>
		/// Returns a collection of all customers
		/// </summary>
		/// <param name="Customers">Returned ArrayList of boxed customer structures</param>
		public void GetAllCustomers (
			[XFAttr(size=118,sysal=true,dir=XFAttr.xfdir.OUT)]ref ArrayList Customers
		)
		{
			object[] pa = new object[1];
			Customers.Clear();
			Customer xfStr0 = new Customer();
			Customers.Add(xfStr0);
			pa[0] = Customers;
			pa[0]=Customers;
			m_xfnet.callUserMethod("GetAllCustomers",ref pa);
			Customers=(ArrayList)pa[0];
		}
		/// <summary>
		/// Returns a contact record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="ContactID">Passed contact ID</param>
		/// <param name="Contact">Returned contact structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status GetContactForUpdate (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int ContactID
			,[XFAttr(dir=XFAttr.xfdir.OUT)]ref Contact Contact
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.OUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]ref string Message
		)
		{
			object[] pa = new object[5];
			pa[0]=CustomerID;
			pa[1]=ContactID;
			pa[2]=Contact;
			pa[3]=GRFA;
			pa[4]=Message;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("GetContactForUpdate",ref pa);
			Contact=(Contact)pa[2];
			GRFA=(byte[])pa[3];
			Message=(string)pa[4];
			return ret;
		}
		/// <summary>
		/// Returns a collection of addresses for a customer
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Addresses">Returned ArrayList of boxed address structures</param>
		public void GetCustomerAddresses (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(size=250,sysal=true,dir=XFAttr.xfdir.OUT)]ref ArrayList Addresses
		)
		{
			object[] pa = new object[2];
			pa[0]=CustomerID;
			Addresses.Clear();
			Address xfStr1 = new Address();
			Addresses.Add(xfStr1);
			pa[1] = Addresses;
			pa[1]=Addresses;
			m_xfnet.callUserMethod("GetCustomerAddresses",ref pa);
			Addresses=(ArrayList)pa[1];
		}
		/// <summary>
		/// Returns a collection of contacts for a customer
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Contacts">Returned ArrayList of boxed contact structures</param>
		public void GetCustomerContacts (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(size=691,sysal=true,dir=XFAttr.xfdir.OUT)]ref ArrayList Contacts
		)
		{
			object[] pa = new object[2];
			pa[0]=CustomerID;
			Contacts.Clear();
			Contact xfStr1 = new Contact();
			Contacts.Add(xfStr1);
			pa[1] = Contacts;
			pa[1]=Contacts;
			m_xfnet.callUserMethod("GetCustomerContacts",ref pa);
			Contacts=(ArrayList)pa[1];
		}
		/// <summary>
		/// Returns a customer record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Customer">Returned customer structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status GetCustomerForUpdate (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(dir=XFAttr.xfdir.OUT)]ref Customer Customer
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.OUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]ref string Message
		)
		{
			object[] pa = new object[4];
			pa[0]=CustomerID;
			pa[1]=Customer;
			pa[2]=GRFA;
			pa[3]=Message;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("GetCustomerForUpdate",ref pa);
			Customer=(Customer)pa[1];
			GRFA=(byte[])pa[2];
			Message=(string)pa[3];
			return ret;
		}
		/// <summary>
		/// Updated a contact record
		/// </summary>
		/// <param name="Contact">Contact structure</param>
		/// <param name="GRFA">Previous GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status UpdateContact (
			[XFAttr(dir=XFAttr.xfdir.INOUT)]ref Contact Contact
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.INOUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]ref string Message
		)
		{
			object[] pa = new object[3];
			pa[0]=Contact;
			pa[1]=GRFA;
			pa[2]=Message;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("UpdateContact",ref pa);
			Contact=(Contact)pa[0];
			GRFA=(byte[])pa[1];
			Message=(string)pa[2];
			return ret;
		}
		/// <summary>
		/// Updated a customer record
		/// </summary>
		/// <param name="Customer">Customer structure</param>
		/// <param name="GRFA">Previous GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status UpdateCustomer (
			[XFAttr(dir=XFAttr.xfdir.INOUT)]ref Customer Customer
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.INOUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]ref string Message
		)
		{
			object[] pa = new object[3];
			pa[0]=Customer;
			pa[1]=GRFA;
			pa[2]=Message;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("UpdateCustomer",ref pa);
			Customer=(Customer)pa[0];
			GRFA=(byte[])pa[1];
			Message=(string)pa[2];
			return ret;
		}
		#region xfnlnet support methods
		/// <summary>
		/// connect to xfServerPlus
		/// </summary>
		public void connect()
		{
			m_xfnet.connect();
		}
		/// <summary>
		/// xfServerPlus four parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		public void connect(string hostIP, int hostPort, int minPort, int maxPort)
		{
			m_xfnet.connect(hostIP, hostPort, minPort, maxPort);
		}
		/// <summary>
		/// xfServerPlus host and port connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		public void connect(string hostIP, int hostPort)
		{
			m_xfnet.connect(hostIP, hostPort);
		}
		/// <summary>
		/// disconnect from xfServerPlus
		/// </summary>
		public void disconnect()
		{
			m_xfnet.disconnect();
		}
		/// <summary>
		/// initialize a debug session
		/// </summary>
		/// <param name="hexip">IP address</param>
		/// <param name="port">port number</param>
		public void debugInit(ref string hexip, ref int port)
		{
			m_xfnet.debugInit(ref hexip, ref port);
		}
		/// <summary>
		/// start a debug session of xfServerPlus
		/// </summary>
		public void debugStart()
		{
			m_xfnet.debugStart();
		}
#if !POOLING
		/// <summary>
		/// get the object's xfServerPlus connection
		/// </summary>
		/// <returns>xfServerPlus connection</returns>
		public object getConnect()
		{
			return m_xfnet.getConnect();
		}
		/// <summary>
		/// share the provided connection
		/// </summary>
		/// <param name="connect">connection to share</param>
		public void shareConnect(object connect)
		{
			m_xfnet.shareConnect(connect);
		}
#endif
		/// <summary>
		/// set the call timeout in seconds
		/// </summary>
		/// <param name="seconds">timeout in seconds</param>
		public void setCallTimeout(int seconds)
		{
			m_xfnet.setCallTimeout(seconds);
		}
		/// <summary>
		/// set the user string
		/// </summary>
		/// <param name="userString">The user string</param>
		public void setUserString(string userString)
		{
			m_xfnet.setUserString(userString);
		}
		/// <summary>
		/// get the user string 
		/// </summary>
		/// <returns>User String</returns>
		public string getUserString()
		{
			return m_xfnet.getUserString();
		}
		/// <summary>
		/// indicate if an object can be put back into the pool
		/// </summary>
		/// <returns>true if object can be returned to pool</returns>
		[XFAttr(type=XFAttr.xftype.INTEGER, size=1)]
#if POOLING
		protected override bool CanBePooled()
#else
		public bool CanBePooled()
#endif
		{
			bool ret = m_xfnet.CanBePooled();
			return ret;
		}
		#endregion
		private XFNet m_xfnet = null;
	}
}
