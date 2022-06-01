Imports System.Web.Http

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()

        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)

        ' The below code allows us to check all of request for checking API_KEY
        GlobalConfiguration.Configuration.MessageHandlers.Add(New apiAuth())

    End Sub

End Class
