Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers.Staff
    Public Class StaffAuthenticationController
        Inherits ApiController

        Dim _DLL As New DLL

        ' GET: api/StaffApk
        Public Function GetValues(user As String, pass As String)

            Dim valid = New StaffAuth()
            valid.auth = _DLL.GetAuthentication(user, pass)
            '-------------------------------------------------------
            'According to the block of below code, there Is no "/" between values
            Dim result As String = JsonConvert.SerializeObject(valid)
            Dim response = Request.CreateResponse(HttpStatusCode.OK)
            response.Content = New StringContent(result, System.Text.Encoding.UTF8, "application/json")
            Return response

        End Function

    End Class
End Namespace