cd D:\Dev\Demos\XFPL_JAVA\COMPONENT\
del JavaComponent.jar
cd D:\Dev\Demos\XFPL_JAVA\COMPONENT\SynergyApp
del *.class
javadoc  -notree -nohelp -noindex -nonavbar -nodeprecatedlist @"D:\Dev\Demos\XFPL_JAVA\COMPONENT\JavaComponent_srclist.dat"
cd D:\Dev\Demos\XFPL_JAVA\COMPONENT\
javac -target 1.6 @JavaComponent_srclist.dat
jar -cvfm JavaComponent.jar JavaComponent.mf SynergyApp\*.class
