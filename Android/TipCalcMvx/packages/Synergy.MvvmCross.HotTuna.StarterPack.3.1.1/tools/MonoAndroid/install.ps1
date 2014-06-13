param($installPath, $toolsPath, $package, $project)

Write-Host Android install script starting

#Build Action Values:
# 0 = None
# 1 = Compile
# 2 = Content
# 3 = Embeded Resource
# 4 = Resource
# 5 = Page
# 6 = ApplicationDefinition
# 7 = AppxPackage
# 8 = AndroidResource
# 10 = AndroidManifest
# 11 = AndroidNativeLibrary

Write-Host Setting TODO_Android_UI.txt to Build Action = None
$item = $project.ProjectItems | where-object {$_.Name -eq "TODO_Android_UI.txt"}
$item.Properties.Item("BuildAction").Value = [int]0

foreach ($item in $project.ProjectItems.Item("Resources").ProjectItems.Item("Drawable").ProjectItems)
{
    $item.Properties.Item("BuildAction").Value = [int]8;
}

foreach ($item in $project.ProjectItems.Item("Resources").ProjectItems.Item("Layout").ProjectItems)
{
    $item.Properties.Item("BuildAction").Value = [int]8;
}

#Can't do this because it caused NuGet to hang!!!!
foreach ($item in $project.ProjectItems.Item("Resources").ProjectItems.Item("Values").ProjectItems)
{
    $item.Properties.Item("BuildAction").Value = [int]8;
}

Write-Host Android install script completed