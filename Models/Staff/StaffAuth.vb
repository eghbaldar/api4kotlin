Public Class StaffAuth

    Dim _auth As String
    Public Property auth As String
        Get
            Return _auth
        End Get
        Set(value As String)
            _auth = value
        End Set
    End Property


End Class
