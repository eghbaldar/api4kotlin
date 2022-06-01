Imports System.Web
Imports System.Net.Http
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Net

Public Class apiAuth
    Inherits DelegatingHandler

    ' The below function allows you to control request!
    ' According to function, all of request from clients needs to set the header: {KEY: APIkey , Value: [API_KEY -> from apiKey Class] }
    Protected Overrides Async Function SendAsync(HttpRequestMessage As HttpRequestMessage,
                                cancellationtoken As CancellationToken) As Task(Of HttpResponseMessage)

        Dim validKey = False
        Dim requestHeader As IEnumerable(Of String)
        Dim checkApiKeyExists = HttpRequestMessage.Headers.TryGetValues("APIkey", requestHeader)
        If checkApiKeyExists Then
            If (requestHeader.FirstOrDefault().Equals(apiKey.API_KEY)) Then
                validKey = True
            End If
        End If
        If Not validKey Then
            Return HttpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key")
        End If
        Dim res = Await MyBase.SendAsync(HttpRequestMessage, cancellationtoken)
        Return res

    End Function

End Class


