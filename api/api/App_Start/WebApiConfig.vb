Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)

        '' Web API routes
        config.MapHttpAttributeRoutes()

        'Staff apk
        config.Routes.MapHttpRoute(
            name:="Api_GetAPK",
            routeTemplate:="api/apk/{controller}/",
            defaults:=New With {.controller = "StaffApkController"}
        )

        'Staff Calendar Overview
        config.Routes.MapHttpRoute(
            name:="Api_GetCalendarOverview",
            routeTemplate:="api/calOverview/{controller}/",
            defaults:=New With {.controller = "StaffcalOverviewController"}
        )

        ''Staff Calendar
        config.Routes.MapHttpRoute(
            name:="Api_GetRecordBasedDate",
            routeTemplate:="api/{controller}/{selectedDate}/",
            defaults:=New With {.selectedDate = RouteParameter.Optional}
        )

        config.Routes.MapHttpRoute(
            name:="Api_GetRecordBasedId",
            routeTemplate:="api/{controller}/each/{id}/",
            defaults:=New With {.id = RouteParameter.Optional}
        )

        '*********************************************** MAKE CLEAR OUTPOUT *****************************************
        'This code removes the XmlFormatter (which was the default output formatter), And configures the JsonFormatter to
        'camel-case property names And to use UTC time for dates.

        'config.Formatters.Remove(config.Formatters.XmlFormatter)
        'config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = New CamelCasePropertyNamesContractResolver()
        'config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc

        'I used to the below codes instead of the above codes in each of GET-methods in each of controllers!
        'HttpContext.Current.Response.Write(New JavaScriptSerializer().Serialize(listCalendar))
        '*********************************************** END of MAKE CLEAR OUTPOUT **********************************

    End Sub

End Module
