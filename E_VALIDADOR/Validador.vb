Public Class Validador

    Private _po_Num_NUMCAR As Integer
    Private _pi_dat_FECCAR As Date
    Private _pi_vC2_DESCRI As String
    Private _pi_Num_ESTADO As Integer
    Private _PI_VC2_NOMDIREMPLEADOR As String
    Private _PI_VC2_NOMDIREMPLEADORARCHIVO As String
    Private _PI_VC2_NOMDIRTRABAJADORARCHIVO As String
    Private _PI_VC2_NOMDIRREMUNERACIONESARCHIVO As String
    Private _pi_TIP_EMPL As String

    Private _LI_VALIDADOR As Integer 'Formato de validación
    Private _LITIPVAL As Integer 'Tipo de Validación
    Private _LITIPPAD As Integer 'Aportes Y/O Minimo


    Private _po_vc2_coderr As String
    Private _po_vc2_deserr As String

    Public Property Po_Num_NUMCAR As Integer
        Get
            Return _po_Num_NUMCAR
        End Get
        Set(value As Integer)
            _po_Num_NUMCAR = value
        End Set
    End Property

    Public Property Pi_dat_FECCAR As Date
        Get
            Return _pi_dat_FECCAR
        End Get
        Set(value As Date)
            _pi_dat_FECCAR = value
        End Set
    End Property

    Public Property Pi_vC2_DESCRI As String
        Get
            Return _pi_vC2_DESCRI
        End Get
        Set(value As String)
            _pi_vC2_DESCRI = value
        End Set
    End Property

    Public Property Pi_Num_ESTADO As Integer
        Get
            Return _pi_Num_ESTADO
        End Get
        Set(value As Integer)
            _pi_Num_ESTADO = value
        End Set
    End Property

    Public Property PI_VC2_NOMDIREMPLEADOR As String
        Get
            Return _PI_VC2_NOMDIREMPLEADOR
        End Get
        Set(value As String)
            _PI_VC2_NOMDIREMPLEADOR = value
        End Set
    End Property

    Public Property PI_VC2_NOMDIREMPLEADORARCHIVO As String
        Get
            Return _PI_VC2_NOMDIREMPLEADORARCHIVO
        End Get
        Set(value As String)
            _PI_VC2_NOMDIREMPLEADORARCHIVO = value
        End Set
    End Property

    Public Property PI_VC2_NOMDIRTRABAJADORARCHIVO As String
        Get
            Return _PI_VC2_NOMDIRTRABAJADORARCHIVO
        End Get
        Set(value As String)
            _PI_VC2_NOMDIRTRABAJADORARCHIVO = value
        End Set
    End Property

    Public Property PI_VC2_NOMDIRREMUNERACIONESARCHIVO As String
        Get
            Return _PI_VC2_NOMDIRREMUNERACIONESARCHIVO
        End Get
        Set(value As String)
            _PI_VC2_NOMDIRREMUNERACIONESARCHIVO = value
        End Set
    End Property

    Public Property Pi_TIP_EMPL As String
        Get
            Return _pi_TIP_EMPL
        End Get
        Set(value As String)
            _pi_TIP_EMPL = value
        End Set
    End Property

    Public Property LI_VALIDADOR As Integer
        Get
            Return _LI_VALIDADOR
        End Get
        Set(value As Integer)
            _LI_VALIDADOR = value
        End Set
    End Property

    Public Property LITIPVAL As Integer
        Get
            Return _LITIPVAL
        End Get
        Set(value As Integer)
            _LITIPVAL = value
        End Set
    End Property

    Public Property LITIPPAD As Integer
        Get
            Return _LITIPPAD
        End Get
        Set(value As Integer)
            _LITIPPAD = value
        End Set
    End Property

    Public Property Po_vc2_coderr As String
        Get
            Return _po_vc2_coderr
        End Get
        Set(value As String)
            _po_vc2_coderr = value
        End Set
    End Property

    Public Property Po_vc2_deserr As String
        Get
            Return _po_vc2_deserr
        End Get
        Set(value As String)
            _po_vc2_deserr = value
        End Set
    End Property
End Class
