Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Public Class DLL

    Dim sqlconnDesktop As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("DesktopConnectionString").ConnectionString)
    Dim sqlconnIFP As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("iranfilmportConnectionString").ConnectionString)

    'Calendar

    Public Function GetOptionalDayCalendar(_date As String) As DataTable
        Try
            If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
            sqlconnDesktop.Open()
            Dim sqlcom As New SqlCommand("select * from [dbo].[tbCalendar] where CONVERT(VARCHAR(10), [date], 112) = CONCAT( YEAR('" & _date & "'), REPLACE(CONVERT(varchar, MONTH('" & _date & "') * 0.01), '0.', ''), + REPLACE(CONVERT(varchar, DAY('" & _date & "') * 0.01), '0.', '') ) order by [date] desc", sqlconnDesktop)
            Dim sqlda As New SqlDataAdapter(sqlcom)
            Dim ds As New DataSet
            sqlda.Fill(ds)
            Return ds.Tables(0)
            sqlconnDesktop.Close()
        Catch ex As Exception
        Finally
            sqlconnDesktop.Close()
        End Try
    End Function

    Public Function GetCalendar(id As Long) As DataTable
        Try
            If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
            sqlconnDesktop.Open()
            Dim sqlcom As New SqlCommand("select * from [dbo].[tbCalendar] where id=" & id.ToString, sqlconnDesktop)
            Dim sqlda As New SqlDataAdapter(sqlcom)
            Dim ds As New DataSet
            sqlda.Fill(ds)
            Return ds.Tables(0)
            sqlconnDesktop.Close()
        Catch ex As Exception
        Finally
            sqlconnDesktop.Close()
        End Try
    End Function

    Public Function InsertCalendar(ByVal idUser As Byte, datetime As String, note As String) As Boolean
        Try
            If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
            sqlconnDesktop.Open()
            'A sample of datetime: 1401/02/18
            Dim sqlcom As New SqlCommand("insert into dbo.tbCalendar (idUser,date,note) values (" +
                                         idUser.ToString + ",'" + ShamsiDate.ShamsiToMiladi(validDate(datetime)) & " " & Now.ToString("HH:mm:ss") + "',N'" & note & "')", sqlconnDesktop)

            sqlcom.ExecuteNonQuery()
            sqlconnDesktop.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqlconnDesktop.Close()
        End Try
    End Function

    Public Function DeleteCalendar(id As Long) As Boolean
        Try
            If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
            sqlconnDesktop.Open()
            Dim sqlcom As New SqlCommand("delete from dbo.tbCalendar where id=" & id.ToString, sqlconnDesktop)
            sqlcom.ExecuteScalar()
            sqlconnDesktop.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqlconnDesktop.Close()
        End Try
    End Function

    Public Function UpdateCalendar(id As Long, idUser As Byte, datetime As String, note As String) As Boolean
        Try
            If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
            sqlconnDesktop.Open()
            Dim sqlcom As New SqlCommand("update dbo.tbCalendar set idUser=" & idUser.ToString &
                                         ",date='" & ShamsiDate.ShamsiToMiladi(validDate(datetime)) & " " & Now.ToString("HH:mm:ss") & "',note=N'" & note & "' where id=" & id.ToString, sqlconnDesktop)
            sqlcom.ExecuteScalar()
            sqlconnDesktop.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqlconnDesktop.Close()
        End Try
    End Function

    Public Function GetOneCalendar(id As Long) As DataTable
        'Try
        '    If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
        '    sqlconnDesktop.Open()
        '    Dim sqlcom As New SqlCommand("select * from dbo.tbCalendar where id=" & id.ToString, sqlconnDesktop)
        '    Dim sqlda As New SqlDataAdapter(sqlcom)
        '    Dim ds As New DataSet
        '    sqlda.Fill(ds)
        '    Return ds.Tables(0)
        '    sqlconnDesktop.Close()
        'Catch ex As Exception
        'Finally
        '    sqlconnDesktop.Close()
        'End Try
    End Function

    Private Function validDate(datetime As String) As String
        Dim SeparateDate() As String = datetime.Split("/")
        Dim NewY = SeparateDate(0)
        Dim NewM
        Dim NewD = SeparateDate(2)
        Select Case SeparateDate(1)
            Case 1
                NewM = "01"
            Case 2
                NewM = "02"
            Case 3
                NewM = "03"
            Case 4
                NewM = "04"
            Case 5
                NewM = "05"
            Case 6
                NewM = "06"
            Case 7
                NewM = "07"
            Case 8
                NewM = "08"
            Case 9
                NewM = "09"
            Case Else
                NewM = SeparateDate(1)
        End Select
        Return NewY & "/" & NewM & "/" & NewD

    End Function

    'APK

    Public Function GetStaffApk() As String
        Try
            If sqlconnIFP.State = ConnectionState.Open Then sqlconnIFP.Close()
            sqlconnIFP.Open()
            Dim sqlcom As New SqlCommand("select [apkStaff] from [dbo].[tbl_setting]", sqlconnIFP)
            Return sqlcom.ExecuteScalar
            sqlconnIFP.Close()
        Catch ex As Exception
        Finally
            sqlconnIFP.Close()
        End Try
    End Function

    'Calendar Overview

    Public Function GetStaffCalendarOverview() As DataTable
        Try
            If sqlconnDesktop.State = ConnectionState.Open Then sqlconnDesktop.Close()
            sqlconnDesktop.Open()
            Dim sqlcom As New SqlCommand("exec spStaffCalendarOverview", sqlconnDesktop)
            Dim sqlda As New SqlDataAdapter(sqlcom)
            Dim ds As New DataSet
            sqlda.Fill(ds)
            Return ds.Tables(0)
            sqlconnDesktop.Close()
        Catch ex As Exception
        Finally
            sqlconnDesktop.Close()
        End Try
    End Function

End Class
