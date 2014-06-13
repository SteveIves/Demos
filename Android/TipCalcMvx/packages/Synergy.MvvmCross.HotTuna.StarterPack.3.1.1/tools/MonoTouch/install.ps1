param($installPath, $toolsPath, $package, $project)

$item = $project.ProjectItems | where-object {$_.Name -eq "TODO_iOS_UI.txt"}
$item.Properties.Item("BuildAction").Value = [int]0
