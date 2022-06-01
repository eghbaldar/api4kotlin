Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Formatting
Imports System.Web.Http
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Namespace Controllers.Staff
    Public Class StaffCalendarGeneralController
        Inherits ApiController

        Dim _DLL As New DLL
        Private calendars As List(Of StaffCalendarListItem) '= New List(Of StaffCalendarListItem)()


        ' GET api/StaffCalendarGeneral/{selectedDate}
        Public Function GetValue(selectedDate As String)

            'selectedDate: inputed data with shamsi format!
            'a sample of input: 14010209
            Dim _date As String = Strings.Left(selectedDate, 4) & "/" & selectedDate.Substring(4, 2) & "/" & Strings.Right(selectedDate, 2)

            Dim listCalendar = New List(Of StaffCalendarListItem)
            Dim aCalendar = New StaffCalendarListItem()

            For i As Long = 0 To _DLL.GetOptionalDayCalendar(ShamsiDate.ShamsiToMiladi(_date)).Rows.Count - 1

                Dim dtRow As DataRow = _DLL.GetOptionalDayCalendar(ShamsiDate.ShamsiToMiladi(_date)).Rows(i)

                aCalendar = New StaffCalendarListItem()

                aCalendar.Id = dtRow("id")
                aCalendar.idUser = dtRow("idUser")
                aCalendar.datetime = dtRow("date")
                aCalendar.note = dtRow("note")

                listCalendar.Add(aCalendar)
            Next

            '-------------------------------------------------------
            'According to the block of below code, there is no "/" between values
            Dim result As String = JsonConvert.SerializeObject(listCalendar)
            Dim response = Request.CreateResponse(HttpStatusCode.OK)
            response.Content = New StringContent(result, System.Text.Encoding.UTF8, "application/json")
            Return response
            'But, based on the below codes, there is a lot of "/" (that's absolutely nonesence) :
            'Return New JavaScriptSerializer().Serialize(listCalendar)
            ''Return ShamsiDate.ShamsiToMiladi(_date)

        End Function

        ' GET api/StaffCalendarGeneral/each/{id}
        Public Function GetOneValue(id As Long)


            Dim listCalendar = New List(Of StaffCalendarListItem)
            Dim aCalendar = New StaffCalendarListItem()

            If _DLL.GetCalendar(id).Rows.Count > 0 Then


                Dim dtRow As DataRow = _DLL.GetCalendar(id).Rows(0)

                aCalendar = New StaffCalendarListItem()

                aCalendar.Id = dtRow("id")
                aCalendar.idUser = dtRow("idUser")
                aCalendar.datetime = dtRow("date")
                aCalendar.note = dtRow("note")

                listCalendar.Add(aCalendar)

                '-------------------------------------------------------
                'According to the block of below code, there is no "/" between values
                Dim result As String = JsonConvert.SerializeObject(listCalendar)
                Dim response = Request.CreateResponse(HttpStatusCode.OK)
                response.Content = New StringContent(result, System.Text.Encoding.UTF8, "application/json")
                Return response
                'But, based on the below codes, there is a lot of "/" (that's absolutely nonesence) :
                'Return New JavaScriptSerializer().Serialize(listCalendar)
                ''Return ShamsiDate.ShamsiToMiladi(_date)

            End If

        End Function

        'POST api/StaffCalendarGeneral
        'You have to send all your parameteres with <body>: [ x-www-form-urlencoded ] format
        Public Function PostValue(ByVal value As StaffCalendarListItem)
            'value.datetime: inputed data with shamsi format!
            'a sample of input: 14010209
            Dim _date As String = Strings.Left(value.datetime, 4) & "/" & value.datetime.Substring(4, 2) & "/" & Strings.Right(value.datetime, 2)
            _DLL.InsertCalendar(Val(value.idUser), _date, value.note)
        End Function

        ' PUT api/StaffCalendarGeneral/each/{id}
        Public Sub PutValue(ByVal id As Integer, ByVal value As StaffCalendarListItem)
            _DLL.UpdateCalendar(id, value.idUser, value.datetime, value.note)
        End Sub

        ' DELETE api/StaffCalendarGeneral/each/{id}
        Public Sub DeleteValue(ByVal id As Long)
            _DLL.DeleteCalendar(id)
        End Sub

    End Class

End Namespace