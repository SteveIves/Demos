using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SynPSG.Examples.NetMenu
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			string appTitle = "RiteRX";
			string xmlFile;
			string dbrSpec;
			string netDll;

			try 
			{
				//Locate and build the spec for dbr.exe
				dbrSpec=Environment.GetEnvironmentVariable("DBLDIR");
				if (dbrSpec==null)
					throw new Exception("Environment variable DBLDIR is not set.");
				if (!dbrSpec.Trim().EndsWith("\\"))
					dbrSpec = dbrSpec.Trim() + "\\";
				dbrSpec = dbrSpec.Trim() + "bin\\dbr.exe";
				//Make sure we know where our .NET assemblies are
				netDll = Environment.GetEnvironmentVariable("NETDLL");
				if (netDll==null)
					throw new Exception("Environment variable NETDLL is not set.");
				//And build the spec of the menu data XML file
				xmlFile=Environment.GetEnvironmentVariable("EXE");
				if (xmlFile==null)
					throw new Exception("Environment variable EXE is not set.");
				if (!xmlFile.Trim().EndsWith("\\"))
					xmlFile = xmlFile.Trim() + "\\";
				xmlFile = xmlFile.Trim() + "hbsmenu.xml";

				MainMenu menu = new MainMenu(appTitle, xmlFile, dbrSpec);
				menu.ShowDialog();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				System.Threading.Thread.Sleep(2000);
			}
		}
	}
}
