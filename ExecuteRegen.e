#include "slick.sh"
#import "stdprocs.e"

_command void ExecuteRegen() name_info(',')
{
    // Clear build window
    _mdi.p_child.clear_pbuffer();
 
    _str workspacePath = strip_filename(_workspace_filename,'N');
    _str projectPath = strip_filename(_project_name,'N');

    //Is there a regen.bat in the project folder?
    if (file_exists(projectPath "\\regen.bat"))
    {
       //Yes, run it
       EchoBuildMessage("Generating project code...");
       int status = concur_command(projectPath "\\regen.bat" , false, false, true, false);
    }
    else if (file_exists(workspacePath "\\regen.bat"))
    {
       //Run regen.bat from the workspace folder
       EchoBuildMessage("Generating workspace code...");
       int status = concur_command(workspacePath "\\regen.bat" , false, false, true, false);
    }
}

boolean EchoBuildMessage(_str msg)
{
    int buildWid = GetBuildWID();
    if (buildWid > 0)
    {
        int curWid = p_window_id;
        p_window_id = buildWid;
        bottom();
        insert_line("echo " :+ msg);
        _insert_text("\r\n");
        
        p_window_id = curWid;

        return true;
    }

    return false;
}


int GetBuildWID()
{
    // See if the build window is an MDI window
    int wid = _mdi.p_child._find_tile(".process");
    if(!wid)
    {
        // Not MDI. Get the .process buffer window from
        // the build toolwindow form, without activating it.
        int formwid = _find_formobj('_tbshell_form','n');
        if (formwid)
        {
            _nocheck _control _shellEditor;
            wid = formwid._shellEditor;
        }
    }
    return wid;
}

