cd C:\FILES\DEMO\JAVA_POOLING\component\
del PoolTestComponent.jar
cd C:\FILES\DEMO\JAVA_POOLING\component\PoolTest
del *.class
cd C:\FILES\DEMO\JAVA_POOLING\component\
javac @PoolTestComponent_srclist.dat
jar -cvfm PoolTestComponent.jar PoolTestComponent.mf PoolTest\*.class
