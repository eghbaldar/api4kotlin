Public Class StaffCalendarOverview

    Private _count As Byte
    Public Property Count() As Byte
        Get
            Return _count
        End Get
        Set(value As Byte)
            _count = value
        End Set
    End Property

    Private _day As Byte
    Public Property Day() As Byte
        Get
            Return _day
        End Get
        Set(value As Byte)
            _day = value
        End Set
    End Property

End Class
