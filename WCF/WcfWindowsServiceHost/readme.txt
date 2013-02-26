
To test the service,

1.	Open a command prompt and go to the folder containing the windows service executable (bin)

2.  Install the windows service:

		installutil WcfWindowsServiceHost.exe

3.  Start the windows service:

		net start WcfServiceHost

4. Go to the service home page in a browser:

		http://localhost:8080

5. Create a client app and add a service reference (using the same url)
