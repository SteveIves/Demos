param($installPath, $toolsPath, $package, $project)

$item = $project.ProjectItems | where-object {$_.Name -eq "TODO_WPF_UI.txt"}
$item.Properties.Item("BuildAction").Value = [int]0
