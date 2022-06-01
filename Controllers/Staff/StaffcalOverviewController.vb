Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers.Staff

    Public Class StaffcalOverviewController
        Inherits ApiController

        Dim _DLL As New DLL

        ' GET: api/StaffCalendarOverView
        Public Function GetValues()

            Dim CalendarOverview = New List(Of StaffCalendarOverview)
            Dim aCalendarOverview = New StaffCalendarOverview()

            For i As Long = 0 To _DLL.GetStaffCalendarOverview().Rows.Count - 1

                Dim dtRow As DataRow = _DLL.GetStaffCalendarOverview().Rows(i)

                aCalendarOverview = New StaffCalendarOverview()

                aCalendarOverview.Day = dtRow("day")
                aCalendarOverview.Count = dtRow("count")

                CalendarOverview.Add(aCalendarOverview)
            Next

            '-------------------------------------------------------
            'According to the block of below code, there is no "/" between values
            Dim result As String = JsonConvert.SerializeObject(CalendarOverview)
            Dim response = Request.CreateResponse(HttpStatusCode.OK)
            response.Content = New StringContent(result, System.Text.Encoding.UTF8, "application/json")
            Return response

        End Function

    End Class

End Namespace