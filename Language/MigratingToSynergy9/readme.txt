-------------------------------------------------------------------------------

Name:           MigratingToSynergy9.zip

Author:         Steve Ives
                Synergex Professional Services Group
                steve.ives@synergex.com

Platforms:      Windows

Minimum version: Synergy/DE 9.1.3

Revisions:       Version  Date                     Comment
                 -------  -----                    --------
                 1.0      30th April 2008          Original version

Disclaimer:      All code is supplied as seen and without warranty or support.
                 Use at your own risk. Neither the author nor Synergex accept 
                 any responsibility for any loss or damage which may result 
                 from the use of this code.

-------------------------------------------------------------------------------

This CodeExchange entry contains a collection of programs which highlight many
of the changes between the Synergy/DE V9 compiler, and earlier versions of the
compiler.

Each of the included programs compiles without errors or warnings under the
Synergy V8.3 compiler, but results in compiler errors or warnings when compiled
with the V9 compiler.  Each source file includes comments which discuss the
reason for the change, and suggest how to address the issue.

The changes highlighted by the various programs are typical of the changes that
some developers may need to make to their applications when migrating to
Synergy/DE V9 for the first time.

Although all of the programs included will COMPILE with the V8.3 compiler,
several may have the possibilities of runtime errors.  Typically the changes
required to make the code compile with the V9 compiler also removes the
possibility of these runtime errors.

Instructions:

Use Workbench to open the Workspace MigratingToSyerngy9.vpw

For each source file in the project

1). Open the file in the editor
2). Compile with the V8 compiler (Build menu, Compile With V8)
3). Compile with the V9 compiler (Build menu, Compile With V9)
4). Review the compiler errors or warnings
5). Review and implement the suggested solution
6). Compile with the V9 compiler (Build menu, Compile With V9)

-------------------------------------------------------------------------------

