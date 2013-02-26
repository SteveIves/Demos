import java.io.*;
import Synergex.util.*;
import PoolTest.*;

public class testprog
{

    public static void main(String args[])
    {

        boolean ok=true;
        boolean created=false;
        boolean connected=false;
        SWPManager PoolMgr = null;
        SynergyMethods synServer = null;

        //Create an instance of the pool manager.
        System.out.println("Creating new pool...");
        try
        {
            PoolMgr = SWPManager.getInstance();
        }
        catch(Exception e)
        {
            System.out.println("ERROR: Failed to create pool");
            System.out.println("  Exception : " + e.getClass().toString()+"");
            System.out.println("  Message   : " + e.getMessage()+"");
            ok=false;
        }

        //Create an instance of the Synergy procedural class
        if(ok)
        {
            System.out.println("Creating new object...");
            synServer = new SynergyMethods();
            created = true;

            //Connect to xfServerPlus (via an existing pooled connection)
            System.out.println("Telling object to use pooled connection...");
            synServer.usePool("MyPool",PoolMgr);

            //Connect to xfServerPlus (get connection from pool)
            try
            {
                synServer.connect();
                connected=true;
            }
            catch(Exception e)
            {
                System.out.println(e.getMessage());
                ok=false;
            }
        }

        if(ok)
        {
            System.out.println("Calling setGreeting method...");
            try
            {
                synServer.setGreeting("Hello World");
            }
            catch(Exception e)
            {
                System.out.println(e.getMessage());
                ok=false;
            }
        }

        if(ok)
        {
            System.out.println("Calling getGreeting method...");
            StringBuffer greeting = new StringBuffer();
            try
            {
                synServer.getGreeting(greeting);
                System.out.println("Data returned was: " + greeting + "");
            }
            catch(Exception e)
            {
                System.out.println(e.getMessage());
                ok=false;
            }
        }

        if(connected)
        {
            //Disconnect from xfServerPlus (release connection)
            System.out.println("Disconnecting from xfServerPlus...");
            try
            {
                synServer.disconnect();
            }
            catch(Exception e)
            {
                System.out.println(e.getMessage());
            }
        }

        //Delete object
        if(created)
        {
            System.out.println("Deleting object...");
            synServer = null;
        }

        String CurLine = "";
        System.out.println("Press a key to stop pool and quit: ");
        InputStreamReader converter = new InputStreamReader(System.in);
        BufferedReader in = new BufferedReader(converter);
        try
        {
            CurLine = in.readLine();
        }
        catch(Exception e)
        {
        }

    }
}
