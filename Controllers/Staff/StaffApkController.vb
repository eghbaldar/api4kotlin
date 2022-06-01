Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers.Staff
    Public Class StaffApkController
        Inherits ApiController

        Dim _DLL As New DLL

        ' GET: api/StaffApk
        Public Function GetValues()

            Dim apk = New List(Of StaffApk)
            Dim aApk = New StaffApk()

            aApk = New StaffApk()
            aApk.apk = _DLL.GetStaffApk
            apk.Add(aApk)

            '-------------------------------------------------------
            'According to the block of below code, there is no "/" between values
            Dim result As String = JsonConvert.SerializeObject(apk)
            Dim response = Request.CreateResponse(HttpStatusCode.OK)
            response.Content = New StringContent(result, System.Text.Encoding.UTF8, "application/json")
            Return response

        End Function

        ' GET: api/StaffApk/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/StaffApk
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/StaffApk/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/StaffApk/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace