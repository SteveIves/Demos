Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://psg.synergex.com/webservices")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class UnitConversions
    Inherits System.Web.Services.WebService

    ' The ConvertLength() method converts a length from one unit of measure to another.

    <WebMethod(Description:="Converts a length from one unit of measure to another")> _
    Public Function ConvertLength(ByVal OriginalLength As Double, _
                                      ByVal OriginalUnit As LengthUnit, _
                                      ByVal TargetUnit As LengthUnit) As Double

        Dim ReturnValue As Double

        'Length conversion constants
        Const MillimeterInCentimeter As Double = 10
        Const MillimeterInMeter As Double = 1000
        Const MillimeterInKilometer As Double = 1000000
        Const MillimeterInInch As Double = 25.4
        Const MillimeterInFoot As Double = 304.8
        Const MillimeterInYard As Double = 914.4
        Const MillimeterInMile As Double = 1609344
        Const MillimeterInNauticalmile As Double = 1852000 'US/International, UK=1853184
        Const MillimeterInFathom As Double = 1828.8
        Const MillimeterInCubit As Double = 457.2

        'Convert length to millimeters
        Select Case OriginalUnit
            Case LengthUnit.Millimeter
                ReturnValue = OriginalLength
            Case LengthUnit.Centimeter
                ReturnValue = OriginalLength * MillimeterInCentimeter
            Case LengthUnit.Meter
                ReturnValue = OriginalLength * MillimeterInMeter
            Case LengthUnit.Kilometer
                ReturnValue = OriginalLength * MillimeterInKilometer
            Case LengthUnit.Inch
                ReturnValue = OriginalLength * MillimeterInInch
            Case LengthUnit.Foot
                ReturnValue = OriginalLength * MillimeterInFoot
            Case LengthUnit.Yard
                ReturnValue = OriginalLength * MillimeterInYard
            Case LengthUnit.Mile
                ReturnValue = OriginalLength * MillimeterInMile
            Case LengthUnit.NauticalMile
                ReturnValue = OriginalLength * MillimeterInNauticalmile
            Case LengthUnit.Fathom
                ReturnValue = OriginalLength * MillimeterInFathom
            Case LengthUnit.Cubit
                ReturnValue = OriginalLength * MillimeterInCubit
        End Select

        'Convert millimeters to target unit
        Select Case TargetUnit
            Case LengthUnit.Millimeter
                'Nothing to do
            Case LengthUnit.Centimeter
                ReturnValue = ReturnValue / MillimeterInCentimeter
            Case LengthUnit.Meter
                ReturnValue = ReturnValue / MillimeterInMeter
            Case LengthUnit.Kilometer
                ReturnValue = ReturnValue / MillimeterInKilometer
            Case LengthUnit.Inch
                ReturnValue = ReturnValue / MillimeterInInch
            Case LengthUnit.Foot
                ReturnValue = ReturnValue / MillimeterInFoot
            Case LengthUnit.Yard
                ReturnValue = ReturnValue / MillimeterInYard
            Case LengthUnit.Mile
                ReturnValue = ReturnValue / MillimeterInMile
            Case LengthUnit.NauticalMile
                ReturnValue = ReturnValue / MillimeterInNauticalmile
            Case LengthUnit.Fathom
                ReturnValue = ReturnValue / MillimeterInFathom
            Case LengthUnit.Cubit
                ReturnValue = ReturnValue / MillimeterInCubit
        End Select

        Return ReturnValue

    End Function

    ' The ConvertWeight() method converts a weight from one unit of measure to another.

    <WebMethod(Description:="Converts a weight from one unit of measure to another")> _
    Public Function ConvertWeight(ByVal OriginalWeight As Double, _
                                      ByVal OriginalUnit As WeightUnit, _
                                      ByVal TargetUnit As WeightUnit) As Double

        Dim ReturnValue As Double

        'Weight constants
        Const GramInKilogram As Double = 1000
        Const GramInMetricton As Double = 1000000
        Const GramInOunce As Double = 28.3495231
        Const GramInPound As Double = 453.59237

        'Convert to grams
        Select Case OriginalUnit
            Case WeightUnit.Gram
                ReturnValue = OriginalWeight
            Case WeightUnit.Kilogram
                ReturnValue = OriginalWeight * GramInKilogram
            Case WeightUnit.MetricTon
                ReturnValue = OriginalWeight * GramInMetricton
            Case WeightUnit.Ounce
                ReturnValue = OriginalWeight * GramInOunce
            Case WeightUnit.Pound
                ReturnValue = OriginalWeight * GramInPound
        End Select

        'Convert grams to target unit
        Select Case TargetUnit
            Case WeightUnit.Gram
                'Nothing to do
            Case WeightUnit.Kilogram
                ReturnValue = ReturnValue / GramInKilogram
            Case WeightUnit.MetricTon
                ReturnValue = ReturnValue / GramInMetricton
            Case WeightUnit.Ounce
                ReturnValue = ReturnValue / GramInOunce
            Case WeightUnit.Pound
                ReturnValue = ReturnValue / GramInPound
        End Select

        Return ReturnValue

    End Function

    ' The ConvertTemperature() method converts a temperature from one unit of measure to another.

    <WebMethod(Description:="Converts a temperature from one unit of measure to another")> _
    Public Function ConvertTemperature(ByVal OriginalTemperature As Double, _
                                      ByVal OriginalUnit As TemperatureUnit, _
                                      ByVal TargetUnit As TemperatureUnit) As Double

        Dim ReturnValue As Double

        'Temperature constants
        Const CelsiusInKelvin As Double = 273.15

        'Convert original temperature to Kelvin
        Select Case OriginalUnit
            Case TemperatureUnit.Kelvin
                ReturnValue = OriginalTemperature
            Case TemperatureUnit.Celsius
                ReturnValue = OriginalTemperature + CelsiusInKelvin
            Case TemperatureUnit.Farenheit
                ReturnValue = ((OriginalTemperature - 32) / 1.8) + CelsiusInKelvin
        End Select

        'Convert Kelvin to target unit
        Select Case TargetUnit
            Case TemperatureUnit.Kelvin
                'Nothing to do
            Case TemperatureUnit.Celsius
                ReturnValue = ReturnValue - CelsiusInKelvin
            Case TemperatureUnit.Farenheit
                ReturnValue = (1.8 * (ReturnValue - CelsiusInKelvin)) + 32
        End Select

        Return ReturnValue

    End Function

    ' The ConvertArea() method converts an area from one unit of measure to another.

    <WebMethod(Description:="Converts an area from one unit of measure to another")> _
    Public Function ConvertArea(ByVal OriginalArea As Double, _
                                      ByVal OriginalUnit As AreaUnit, _
                                      ByVal TargetUnit As AreaUnit) As Double

        Dim ReturnValue As Double

        'Area constants
        Const SqMillimeterInSqCentimeter As Double = 100
        Const SqMillimeterInSqMeter As Double = 1000000
        Const SqMillimeterInSqKilometer As Double = 1000000000000
        Const SqMillimeterInSqInch As Double = 645.16
        Const SqMillimeterInSqFoot As Double = 92903.04
        Const SqMillimeterInSqYard As Double = 836127.36
        Const SqMillimeterInSqMile As Double = 2589988110336

        'Convert original area to square millimeters
        Select Case OriginalUnit
            Case AreaUnit.SquareMillimeter
                ReturnValue = OriginalArea
            Case AreaUnit.SquareCentimeter
                ReturnValue = OriginalArea * SqMillimeterInSqCentimeter
            Case AreaUnit.SquareMeter
                ReturnValue = OriginalArea * SqMillimeterInSqMeter
            Case AreaUnit.SquareKilometer
                ReturnValue = OriginalArea * SqMillimeterInSqKilometer
            Case AreaUnit.SquareInch
                ReturnValue = OriginalArea * SqMillimeterInSqInch
            Case AreaUnit.SquareFoot
                ReturnValue = OriginalArea * SqMillimeterInSqFoot
            Case AreaUnit.SquareYard
                ReturnValue = OriginalArea * SqMillimeterInSqYard
            Case AreaUnit.SquareMile
                ReturnValue = OriginalArea * SqMillimeterInSqMile
        End Select

        'Convert square millimeters to target unit
        Select Case TargetUnit
            Case AreaUnit.SquareMillimeter
                'Nothing to do
            Case AreaUnit.SquareCentimeter
                ReturnValue = ReturnValue / SqMillimeterInSqCentimeter
            Case AreaUnit.SquareMeter
                ReturnValue = ReturnValue / SqMillimeterInSqMeter
            Case AreaUnit.SquareKilometer
                ReturnValue = ReturnValue / SqMillimeterInSqKilometer
            Case AreaUnit.SquareInch
                ReturnValue = ReturnValue / SqMillimeterInSqInch
            Case AreaUnit.SquareFoot
                ReturnValue = ReturnValue / SqMillimeterInSqFoot
            Case AreaUnit.SquareYard
                ReturnValue = ReturnValue / SqMillimeterInSqYard
            Case AreaUnit.SquareMile
                ReturnValue = ReturnValue / SqMillimeterInSqMile
        End Select

        Return ReturnValue

    End Function

    ' The ConvertDataStorage() method converts unit of data storage from one unit of measure to another.

    <WebMethod(Description:="Converts an expression of data storage from one unit of measure to another")> _
    Public Function ConvertDataStorage(ByVal OriginalData As Double, _
                                      ByVal OriginalUnit As DataUnit, _
                                      ByVal TargetUnit As DataUnit) As Double

        Dim ReturnValue As Double

        'Data storage constants
        Const BitInByte As Long = 8
        Const BitInKilobyte As Long = 8192
        Const BitInMegabyte As Long = 8388608
        Const BitInGigabyte As Long = 8589934592
        Const BitInTerabyte As Long = 8796093022208
        Const BitInPetabyte As Long = 9007199254740992

        'Convert original data storage to bits
        Select Case OriginalUnit
            Case DataUnit.data_bit
                ReturnValue = OriginalData
            Case DataUnit.data_byte
                ReturnValue = OriginalData * BitInByte
            Case DataUnit.data_kilobyte
                ReturnValue = OriginalData * BitInKilobyte
            Case DataUnit.data_megabyte
                ReturnValue = OriginalData * BitInMegabyte
            Case DataUnit.data_terabyte
                ReturnValue = OriginalData * BitInTerabyte
            Case DataUnit.data_gigabyte
                ReturnValue = OriginalData * BitInGigabyte
            Case DataUnit.data_petabyte
                ReturnValue = OriginalData * BitInPetabyte
        End Select

        'Convert bits to target data storage
        Select Case TargetUnit
            Case DataUnit.data_bit
                'Nothing to do
            Case DataUnit.data_byte
                ReturnValue = ReturnValue / BitInByte
            Case DataUnit.data_kilobyte
                ReturnValue = ReturnValue / BitInKilobyte
            Case DataUnit.data_megabyte
                ReturnValue = ReturnValue / BitInMegabyte
            Case DataUnit.data_terabyte
                ReturnValue = ReturnValue / BitInTerabyte
            Case DataUnit.data_gigabyte
                ReturnValue = ReturnValue / BitInGigabyte
            Case DataUnit.data_petabyte
                ReturnValue = ReturnValue / BitInPetabyte
        End Select

        Return ReturnValue

    End Function

    'Enumerations used by conversion routines

    Enum LengthUnit
        Millimeter = 1
        Centimeter = 2
        Meter = 3
        Kilometer = 4
        Inch = 5
        Foot = 6
        Yard = 7
        Mile = 8
        NauticalMile = 9
        Fathom = 10
        Cubit = 11
    End Enum

    Enum WeightUnit
        Gram = 1
        Kilogram = 2
        MetricTon = 3
        Ounce = 4
        Pound = 5
    End Enum

    Enum TemperatureUnit
        Celsius = 1
        Farenheit = 2
        Kelvin = 3
    End Enum

    Enum AreaUnit
        SquareMillimeter = 1
        SquareCentimeter = 2
        SquareMeter = 3
        SquareKilometer = 4
        SquareInch = 5
        SquareFoot = 6
        SquareYard = 7
        SquareMile = 8
    End Enum

    Enum DataUnit
        data_bit = 1
        data_byte = 2
        data_kilobyte = 3
        data_megabyte = 4
        data_gigabyte = 5
        data_terabyte = 6
        data_petabyte = 7
    End Enum

End Class