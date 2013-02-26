Option Strict On

Imports CommandLineParse
Imports System.io
Imports System.Text.RegularExpressions

Module Module1

   Sub Main()

	  Dim parser As CommandLineParser = New CommandLineParser()
	  Dim args As String
	  Dim sErr As String
	  Dim anEntry As CommandLineEntry
	  Dim i As Integer
	  Dim unmatched As CommandLineParse.UnmatchedTokens

	  Do

		 SetupCommandLineEntries(parser)

		 Console.WriteLine("Enter a command line and press Enter to test it, or type ""exit"" and press Enter to quit.")
		 Console.Write("Command Line: > ")

		 args = Console.ReadLine

		 If args.ToLower = "exit" Then
			End
		 End If

		 parser.CommandLine = args

		 If parser.Parse() Then
			Console.WriteLine("Successful parse")
			Console.WriteLine("")
		 Else
			Console.WriteLine("Parse failed")
			For Each sErr In parser.Errors
			   Console.WriteLine("Reason: " & sErr)
			Next
			Console.WriteLine("")
		 End If

		 'Did the command line contain unmatched tokens?
		 unmatched = parser.UnmatchedTokens

		 If unmatched.Count > 0 Then
			Console.WriteLine("Some tokens were not matched")
			Dim aBadToken As String
			For Each aBadToken In unmatched
			   Console.WriteLine("Unmatched token: " & aBadToken)
			Next
		 End If

		 Console.WriteLine("")
		 i = 0
		 For Each anEntry In parser.Entries
			If anEntry.HasValue Then
			   i += 1
			End If
			Console.WriteLine(anEntry.ToString)
			Console.WriteLine(String.Empty)
		 Next

	  Loop

   End Sub

	Sub SetupCommandLineEntries(ByVal parser As CommandLineParser)

		Dim CommandToExecute As CommandLineEntry
		Dim EnvOption As CommandLineEntry
		Dim Environment As CommandLineEntry


		parser.Errors.Clear()
		parser.Entries.Clear()

		CommandToExecute = parser.CreateEntry(CommandTypeEnum.Value)
		CommandToExecute.Required = True
		CommandToExecute.RequiredPosition = 0
		parser.Entries.Add(CommandToExecute)

		EnvOption = parser.CreateEntry(CommandTypeEnum.Flag, "e")
		EnvOption.Required = False
		parser.Entries.Add(EnvOption)

		Environment = parser.CreateEntry(CommandTypeEnum.Value)
		Environment.MustFollowEntry = EnvOption
		parser.Entries.Add(Environment)

   End Sub

End Module
