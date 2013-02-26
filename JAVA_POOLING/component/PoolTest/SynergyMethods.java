// Fri Jan 21 09:08:46 PST 2011

package PoolTest;

import java.lang.Exception;
import java.io.*;
import java.net.UnknownHostException;
import java.net.InetAddress;
import java.util.*;
import org.omg.CORBA.*;
import Synergex.synProxy.*;
import Synergex.synTypes.*;
import Synergex.util.*;

public class SynergyMethods
{
  private SWPConnect m_swpCnt = null;
  private SynergyWebProxy m_swp = null;
  private InetAddress m_localIP = null;
  private File m_iniFile = null;
  private String m_userString = null;
  private String m_xfhost = "";
  private int m_xfport = 0;
  private int m_xfminport = 0;
  private int m_xfmaxport = 0;
  private boolean m_xflogging = false;
  private String m_xflogfile = "";
  private boolean m_override = false;
  private SynergyTrace m_tracer = null;
  private boolean m_usepool = false;
  private String m_poolname = null;
  private SWPManager m_pool = null;

  /**   Default constructor 
  */ 
  public SynergyMethods() 
  {
    try {
      m_localIP = InetAddress.getLocalHost();
      m_iniFile = new java.io.File("xfNetLnk.ini");
      m_userString = new String();
      loadProperties();
      int pos = 0;
      if (m_xflogfile != null)
        pos = m_xflogfile.lastIndexOf('.');
      String lgfle = new String("");
      if (pos > 0)
      {
         lgfle = m_xflogfile.substring(0,pos);
         lgfle = lgfle + "JCW";
         lgfle = lgfle + m_xflogfile.substring(pos);
      }
      if (m_xflogging)
        m_tracer = new SynergyTrace(lgfle, m_xflogging);
    } catch (UnknownHostException uhe){
      System.out.println("SynergyMethods : " + uhe.getMessage());
    }
  }

  /**   Ini file constructor 
          @param inifile String in 
  */ 
  public SynergyMethods(String inifile) 
  {
    try {
      m_localIP = InetAddress.getLocalHost();
      m_iniFile = new java.io.File(inifile);
      m_userString = new String();
      loadProperties();
      int pos = 0;
      if (m_xflogfile != null)
        pos = m_xflogfile.lastIndexOf('.');
      String lgfle = new String("");
      if (pos > 0)
      {
         lgfle = m_xflogfile.substring(0,pos);
         lgfle = lgfle + "JCW";
         lgfle = lgfle + m_xflogfile.substring(pos);
      }
      if (m_xflogging)
        m_tracer = new SynergyTrace(lgfle, m_xflogging);
    } catch (UnknownHostException uhe){
      System.out.println("SynergyMethods : " + uhe.getMessage());
    }
  }

  private void loadProperties() {  
    try { 
        String tmpstr = new String(""); 
        Properties synProperties = System.getProperties(); 
        FileInputStream synPropIni = new FileInputStream(m_iniFile); 
        synProperties.load(synPropIni); 
        synPropIni.close(); 
        m_xfhost = synProperties.getProperty("xf_RemoteHostName"); 
        m_xflogfile = synProperties.getProperty("xf_LogFile"); 
        try { 
          tmpstr = synProperties.getProperty("xf_RemotePort"); 
          m_xfport = Utils.atoi(tmpstr); 
        } catch (Exception e) { 
        } 
        try { 
          tmpstr = synProperties.getProperty("xf_LocalMinPort"); 
          m_xfminport = Utils.atoi(tmpstr); 
        } catch (Exception e) { 
        } 
        try { 
          tmpstr = synProperties.getProperty("xf_LocalMaxPort"); 
          m_xfmaxport = Utils.atoi(tmpstr); 
        } catch (Exception e) { 
        } 
        try { 
          tmpstr = synProperties.getProperty("xf_DebugOutput"); 
          m_xflogging = false; 
          if (tmpstr.equals("true")) 
            m_xflogging = true; 
        } catch (Exception e) { 
        } 
    } catch (Exception e) { 
    } 
  }

/** 
    *** To Do *** Add method description 
*/  

  public void Activate() throws xfJCWException
  {
    try {
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Activate");
           m_tracer.trace("  * Input parameters");
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      wp.xcall("Activate");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.Activate:" + e.getMessage());
    }
  }

/** 
    *** To Do *** Add method description 
      @return int 
*/  

  public int CanBePooled() throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: CanBePooled");
           m_tracer.trace("  * Input parameters");
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      ret = (synDec)wp.xcall("CanBePooled");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.CanBePooled:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    *** To Do *** Add method description 
*/  

  public void Cleanup() throws xfJCWException
  {
    try {
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Cleanup");
           m_tracer.trace("  * Input parameters");
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      wp.xcall("Cleanup");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.Cleanup:" + e.getMessage());
    }
  }

/** 
    *** To Do *** Add method description 
*/  

  public void Deactivate() throws xfJCWException
  {
    try {
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Deactivate");
           m_tracer.trace("  * Input parameters");
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      wp.xcall("Deactivate");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.Deactivate:" + e.getMessage());
    }
  }

/** 
    *** To Do *** Add method description 
      @return int 
*/  

  public int Initialize() throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Initialize");
           m_tracer.trace("  * Input parameters");
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      ret = (synDec)wp.xcall("Initialize");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.Initialize:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    *** To Do *** Add method description 
      @param p1 StringBuffer out 
*/  

  public void getGreeting(StringBuffer p1) throws xfJCWException
  {
    try {
      synAlpha p1_tmp =  new synAlpha();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: getGreeting");
           m_tracer.trace("  * Input parameters");
           m_tracer.trace("     StringBuffer p1 = " + p1.toString());
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      wp.xcall("getGreeting",p1_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      p1.replace(0,p1.length(),((synAlpha)p1_tmp).value());
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
           m_tracer.trace("     StringBuffer p1 = " + p1.toString());
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.getGreeting:" + e.getMessage());
    }
  }

/** 
    *** To Do *** Add method description 
      @param p1 String in 
*/  

  public void setGreeting(String p1) throws xfJCWException
  {
    try {
      synAlpha p1_tmp =  new synAlpha(p1);
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: setGreeting");
           m_tracer.trace("  * Input parameters");
           m_tracer.trace("     String p1 = " + p1);
         } catch (Exception e) { }
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      wp.xcall("setGreeting",p1_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           m_tracer.trace("  * Output parameters");
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	throw new xfJCWException("SynergyMethods.setGreeting:" + e.getMessage());
    }
  }
  /** 
    Gets the host name or IP address of the machine where xfServerPlus is running.
      @return String 
  */ 
  public String getxfHost()
  {
    return m_xfhost; 
  }

  /** 
    Sets the host name or IP address of the machine where xfServerPlus is running.
      @param host String in 
  */ 
  public void setxfHost(String host)
  {
    m_xfhost = host; 
    m_override = true; 
  }

  /** 
    Returns the port number of the machine where xfServerPlus is running.
      @return int 
  */ 
  public int getxfPort()
  {
    return m_xfport; 
  }

  /** 
    Sets the port number of the machine where xfServerPlus is running.
      @param port int in 
  */ 
  public void setxfPort(int port)
  {
    m_xfport = port; 
    m_override = true; 
  }

  /** 
    Returns the beginning value for the port range that the client is listening on.
      @return int 
  */ 
  public int getxfMinport()
  {
    return m_xfminport; 
  }

  /** 
    Sets the beginning value for the port range that the client is listening on.
      @param port int in 
  */ 
  public void setxfMinport(int port) throws xfJCWException
  {
    if (port <= 1024) 
      throw new xfJCWException("Minimum port must be > 1024");
    m_xfminport = port; 
    m_override = true; 
  }

  /** 
    Returns the ending value for the port range that the client is listening on.
      @return int 
  */ 
  public int getxfMaxport()
  {
    return m_xfmaxport; 
  }

  /** 
    Sets the ending value for the port range that the client is listening on.
      @param port int in 
  */ 
  public void setxfMaxport(int port) throws xfJCWException
  {
    if (port <= 1024) 
      throw new xfJCWException("Maximum port must be > 1024");
    m_xfmaxport = port; 
    m_override = true; 
  }

  /** 
    Sets client-side logging to true or false.
      @return int 
      @param logging boolean in 
  */ 
  public int setxfLogging(boolean logging)
  {
    int rtn = 0;
    if(m_swp == null) {
      m_xflogging = logging; 
      m_override = true; 
    } else {
      rtn = 1;
    }
    return(rtn);
  }

  /** 
    Returns the name of the client-side logfile.
      @return String 
  */ 
  public String getxfLogfile()
  {
    return m_xflogfile; 
  }

  /** 
    Sets the name of the client-side logfile. If you do not specify a logfile name, output is written to the screen.
      @return int 
      @param logfile String in 
  */ 
  public int setxfLogfile(String logfile)
  {
    int rtn = 0;
    if(m_swp == null) {
      m_xflogfile = logfile; 
      int pos = 0;
      if (m_xflogfile != null && m_xflogfile != "")
        pos = m_xflogfile.lastIndexOf('.');
      String lgfle = new String("");
      if (pos > 0) {
         lgfle = m_xflogfile.substring(0,pos);
         lgfle = lgfle + "JCW";
         lgfle = lgfle + m_xflogfile.substring(pos);
      }
      if (m_tracer != null) {
        m_tracer.close();
        m_tracer = null;
      }
      if (m_xflogging)
        m_tracer = new SynergyTrace(lgfle, m_xflogging);
    } else 
      rtn = 1;
    return(rtn);
  }

  /** 
    Makes a connection to xfServerPlus.
  */ 
  public void connect() throws xfJCWException
  {
    try {
      m_swp = doConnect();
    } catch (Exception e) {
	throw new xfJCWException("SynergyMethods.connect: " + e.getMessage());
    }
  }

  /** 
    Closes the connection to xfServerPlus.
  */ 
  public void disconnect() throws xfJCWException
  {
     try {
       if (null != m_swpCnt)
         m_swpCnt.disconnect();
       m_swpCnt = null;
       m_swp = null;
     } catch (Exception ex) {
       throw new xfJCWException(ex.getMessage());
     }
  }

  /** 
    Gets the already-established SWPConnect connection of the specified object.
      @return java.lang.Object 
  */ 
  public java.lang.Object getConnect() throws xfJCWException
  {
     checkConnect("getConnect");
     return (java.lang.Object)m_swpCnt;
  }

  /** 
    Shares the specified SWPConnect connection.
      @param anObject java.lang.Object in 
  */ 
  public void shareConnect(java.lang.Object anObject) throws xfJCWException
  {
    if (anObject instanceof SWPConnect) {
	     SWPConnect an_swpCnt = (SWPConnect)anObject;
	     m_swpCnt = an_swpCnt;
	     m_swp = an_swpCnt.getM_swp();
	     m_swpCnt.incConnectCount();
    }
    else
	throw new xfJCWException("SynergyMethods.shareConnect: Invalid connection passed into shareConnect");
  }

  /** 
    Initializes a connection to xfServerPlus so you can manually start a session in debug mode.
      @param clientIP String in 
      @param listeningIP StringBuffer out 
      @param port StringBuffer out 
  */ 
  public void debugInit (String clientIP, StringBuffer listeningIP, StringBuffer port)
         throws xfJCWException
  {
     try {
       InetAddress client = InetAddress.getByName(clientIP);
       m_swp = new SynergyWebProxy(client, true, "COM_Debug");

       // get listening IP
       StringBuffer ip = new StringBuffer(m_swp.getlisten_ip());
       if (ip.length() < 8)
	      ip.insert(0,0);
       listeningIP.replace(0,listeningIP.length(),ip.toString());

       // get listening port
       port.replace(0,port.length(),m_swp.getlisten_port());
     } catch (Exception ex) {
       throw new xfJCWException(ex.getMessage());
     }
  }

  /** 
    Completes the connection to xfServerPlus in debug mode.
      @param clientIP String in 
  */ 
  public void debugStart(String clientIP) throws xfJCWException
  {
     try {
       InetAddress client = InetAddress.getByName(clientIP);
       checkConnect("debugStart");
       m_swp.DebugStart(client);
     } catch (Exception ex) {
       throw new xfJCWException(ex.getMessage());
     }
  }

  /** 
    Sets the call time-out value in seconds. The call time-out measures the length of time the xfNetLink Java client waits for a return call from xfServerPlus.
      @param seconds int in 
  */ 
  public void setxfCallTimeout (int seconds) throws xfJCWException
  {
    checkConnect("setxfCallTimeout");
    m_swp.resetRemoteCallTimeout(seconds);
  }

  /** 
    Passes a user-defined string to the xfServerPlus log.
      @param str String in 
  */ 
  public void setUserString (String str) throws xfJCWException
  {
    checkConnect("setUserString");
    m_swp.passUserString(str);
    m_userString = str;
  }

  /** 
    Returns the user string currently stored by setUserString().
      @return String
  */ 
  public String getUserString () 
  {
    return m_userString;
  }

  /** 
    Indicates that Java connection pooling will be used. 
      @param poolID String in 
      @param swpMgr SWPManager in 
  */ 
  public void usePool (String poolID, SWPManager swpMgr)
  {
     m_poolname = poolID;
     m_pool = swpMgr;
     m_usepool = false;
     if (m_poolname != null)
       m_usepool = true;
  }

  private void checkConnect(String where) throws xfJCWException
  {
    if (null == m_swp)
       throw new xfJCWException("SynergyMethods." + where + ": No connection established");
  }

  private SynergyWebProxy doConnect() throws Exception
  {
    if (m_usepool) {
      m_swpCnt = m_pool.getConnection(m_poolname);
    } else {
      if (m_override)
        m_swpCnt = new SWPConnect(m_xfhost,m_xfport,m_xfminport,m_xfmaxport,m_xflogging,m_xflogfile);
      else 
        m_swpCnt = new SWPConnect(m_iniFile);
    }
    return (m_swpCnt.getM_swp());
  }

}
