Namespace TestWebSolution

Public Module Utilities

	Public Function ArrayListFromArray(ByVal Array()) As ArrayList

		Dim ArrayList As New ArrayList
		Dim Count As Integer

		For Count = 0 To UBound(Array)
			ArrayList.Add(Array(Count))
		Next

		Return ArrayList

	End Function

	Public Function DateFromYYYYMMDD(ByVal DateYYYYMMDD As Integer) As Date

		'Accepts an integer containing a date in YYYYMMDD format
		'and returns a date object representing that date

		Dim StringDate As String
		Dim Year As Integer, Month As Integer, Day As Integer

		StringDate = Format(DateYYYYMMDD, "00000000")

		Year = Integer.Parse(StringDate.Substring(0, 4))
		Month = Integer.Parse(StringDate.Substring(4, 2))
		Day = Integer.Parse(StringDate.Substring(6, 2))

		Return New Date(Year, Month, Day)

	End Function

	Public Function YYYYMMDDFromDate(ByVal RealDate As Date) As String

		'Accepts a date object and returns an integer containing a
		'representation of the date in YYYYMMDD format.

		Return (RealDate.Year * 10000) + (RealDate.Month * 100) + RealDate.Day

	End Function

	Public Function DateFromYYMMDD(ByVal DateYYMMDD As Integer) As Date

		'Accepts an integer containing a date in YYMMDD format
		'and returns a date object representing that date

		Dim StringDate As String
		Dim Year As Integer, Month As Integer, Day As Integer

		StringDate = Format(DateYYMMDD, "000000")

		Year = Year2to4(Integer.Parse(StringDate.Substring(0, 2)))
		Month = Integer.Parse(StringDate.Substring(2, 2))
		Day = Integer.Parse(StringDate.Substring(4, 2))

		Return New Date(Year, Month, Day)

	End Function

	Public Function YYMMDDFromDate(ByVal RealDate As Date) As String

		'Accepts a date object and returns an integer containing a
		'representation of the date in YYMMDD format.

		Return Format(((Year4to2(RealDate.Year) * 10000) + (RealDate.Month * 100) + RealDate.Day), "000000")

	End Function

	Public Function DateFromMMDDYY(ByVal DateMdy As Integer) As Date

		'Accepts an integer containing a date in MMDDYY format
		'and returns a date object representing that date

		Dim StringDate As String
		Dim Year As Integer, Month As Integer, Day As Integer

		StringDate = Format(DateMdy, "000000")

		Year = Year2to4(Integer.Parse(StringDate.Substring(4, 2)))
		Month = Integer.Parse(StringDate.Substring(0, 2))
		Day = Integer.Parse(StringDate.Substring(2, 2))

		Return New Date(Year, Month, Day)

	End Function

	Public Function MMDDYYFromDate(ByVal RealDate As Date) As String

		'Accepts a date object and returns an integer containing a
		'representation of the date in MMDDYY format.

		Return Format((Year4to2(RealDate.Year) + (RealDate.Day * 100) + (RealDate.Month * 10000)), "000000")

	End Function

	Public Function Year2to4(ByVal Year As Integer, Optional ByVal Cutoff As Integer = 50) As Integer

		If Year < Cutoff Then
			Year = Year + 2000
		Else
			Year = Year + 1900
		End If

		Return Year

	End Function

	Public Function Year4to2(ByVal Year As Integer) As Integer

		Dim NewYear As Integer

		If Year >= 2000 Then
			NewYear = Year - 2000
		Else
			NewYear = Year - 1900
		End If

		Return NewYear

	End Function

End Module

End Namespace
