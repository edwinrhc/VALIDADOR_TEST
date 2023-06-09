Imports System.IO
Imports System.Net
Imports System.Text

Module Utilitario


    Private tipoDocumento As String
    Private numeroDocumento As String
    Public Property valorTipoDocumento() As String
        Get
            Return tipoDocumento
        End Get
        Set(ByVal value As String)
            tipoDocumento = value
        End Set
    End Property
    Public Property valorNumeroDocumento() As String
        Get
            Return numeroDocumento
        End Get
        Set(ByVal value As String)
            numeroDocumento = value
        End Set
    End Property


    Public Function GetIpV4() As String

        Dim myHost As String = Dns.GetHostName
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(myHost)
        Dim ip As String = ""

        For Each tmpIpAddress As IPAddress In ipEntry.AddressList
            If tmpIpAddress.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                Dim ipAddress As String = tmpIpAddress.ToString
                ip = ipAddress
                Exit For
            End If
        Next

        If ip = "" Then
            Throw New Exception("No 10. IP found!")
        End If

        Return ip

    End Function

    Public Function GetFechaDDMMYYY(ByVal fecha As String) As String
        If fecha.Length > 10 Then
            fecha = fecha.Substring(0, 10)
        End If
        Return fecha
    End Function
    Public Function GetFechaYYYY(ByVal fecha As String) As String
        If fecha.Length >= 10 Then
            fecha = fecha.Substring(6, 4)
        End If
        Return fecha
    End Function
    Public Function GetFechaDMMYYYY(ByVal fecha As String) As String
        Dim anio As String = ""
        Dim mes As String = ""
        If fecha.Length >= 10 Then
            anio = fecha.Substring(6, 4)
            mes = GetDescripcionMes(fecha.Substring(3, 2))
        End If

        Return mes & " de " & anio
    End Function

    Public Function GetDescripcionMes(ByVal mes As String) As String
        If mes.Length = 2 Then
            Select Case mes
                Case "01"
                    mes = "enero"
                Case "02"
                    mes = "febrero"
                Case "03"
                    mes = "marzo"
                Case "04"
                    mes = "abril"
                Case "05"
                    mes = "mayo"
                Case "06"
                    mes = "junio"
                Case "07"
                    mes = "julio"
                Case "08"
                    mes = "agosto"
                Case "09"
                    mes = "setiembre"
                Case "10"
                    mes = "octubre"
                Case "11"
                    mes = "noviembre"
                Case "12"
                    mes = "diciembre"
            End Select
        End If
        Return mes
    End Function

    Public Function GetEstados() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("ID")
        dt.Columns.Add("DESCRIPCION")

        dt.Rows.Add()
        dt.Rows(0)(0) = ""
        dt.Rows(0)(1) = "SELECCIONE"

        dt.Rows.Add()
        dt.Rows(1)(0) = "0"
        dt.Rows(1)(1) = "CON ERRORES"


        dt.Rows.Add()
        dt.Rows(2)(0) = "1"
        dt.Rows(2)(1) = "FINALIZADOS"

        dt.Rows.Add()
        dt.Rows(3)(0) = "3"
        dt.Rows(3)(1) = "EN PROCESO"


        Return dt
    End Function

    Public Function GetFormatos() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("ID")
        dt.Columns.Add("DESCRIPCION")

        dt.Rows.Add()
        dt.Rows(0)(0) = 0
        dt.Rows(0)(1) = "SELECCIONE"


        dt.Rows.Add()
        dt.Rows(1)(0) = 1
        dt.Rows(1)(1) = "1er Formato"

        dt.Rows.Add()
        dt.Rows(2)(0) = 2
        dt.Rows(2)(1) = "2do Formato"


        Return dt
    End Function
    Public Function GetTipoAporte() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("ID")
        dt.Columns.Add("DESCRIPCION")

        dt.Rows.Add()
        dt.Rows(0)(0) = 0
        dt.Rows(0)(1) = "SELECCIONE"


        dt.Rows.Add()
        dt.Rows(1)(0) = 1
        dt.Rows(1)(1) = "Aportes"

        dt.Rows.Add()
        dt.Rows(2)(0) = 2
        dt.Rows(2)(1) = "Minimo"


        Return dt
    End Function

    Public Function GetTipoValidacion() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("ID")
        dt.Columns.Add("DESCRIPCION")

        dt.Rows.Add()
        dt.Rows(0)(0) = 0
        dt.Rows(0)(1) = "SELECCIONE"


        dt.Rows.Add()
        dt.Rows(1)(0) = 1
        dt.Rows(1)(1) = "Empleador"

        dt.Rows.Add()
        dt.Rows(2)(0) = 2
        dt.Rows(2)(1) = "Interna"

        dt.Rows.Add()
        dt.Rows(3)(0) = 3
        dt.Rows(3)(1) = "Empleador + Reniec"

        Return dt
    End Function

    Public Function GetSexo() As DataTable

        Dim dt As New DataTable
        dt.Rows.Add()
        dt.Columns.Add("ID")
        dt.Columns.Add("DESCRIPCION")

        dt.Rows(0)("ID") = "0"
        dt.Rows(0)("DESCRIPCION") = "SELECCIONE"
        dt.Rows.Add()


        dt.Rows(1)("ID") = "19"
        dt.Rows(1)("DESCRIPCION") = "MASCULINO"

        dt.Rows.Add()
        dt.Rows(2)("ID") = "20"
        dt.Rows(2)("DESCRIPCION") = "FEMENINO"

        Return dt

    End Function



    Function adicionarSeleccione(ByVal datos As DataTable) As DataTable

        Dim row As DataRow
        row = datos.NewRow()
        row(0) = "0"
        row(1) = "SELECCIONE"
        datos.Rows.InsertAt(row, 0)

        Return datos
    End Function


    Public Function OnlyNumbers(ByVal txtTBox As TextBox, ByVal Character As Char, ByVal bDecimal As Boolean) As Boolean
        If (Char.IsNumber(Character, 0) = True) Or Character = Convert.ToChar(8) Then
            If Character = "." Then
                If bDecimal = True Then
                    If txtTBox.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function




    Public Function Encriptar(ByVal strCadena As String) As String
        Dim Codificacion As New UTF8Encoding
        Dim md5Hasher As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strCadena))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()

    End Function

    Public Function ConvertImageToByteArray(ByVal imageToConvert As System.Drawing.Image, ByVal formatOfImage As System.Drawing.Imaging.ImageFormat) As Byte()
        Dim Ret As Byte()
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream()
        imageToConvert.Save(ms, formatOfImage)
        Ret = ms.ToArray()
        Return Ret
    End Function

    Public Function ConvertByteArrayToImage(ByVal arreglo As Byte()) As System.Drawing.Image
        If arreglo Is Nothing Then
            Return Nothing
        End If
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(arreglo)
        Dim bm As System.Drawing.Bitmap = Nothing
        bm = New System.Drawing.Bitmap(ms)

        Return bm

    End Function


    Public Function CargarImagen(ByVal rutaArchivo As String) As Byte()


        Dim Archivo As FileStream = New FileStream(rutaArchivo, FileMode.Open) ';//Creo el archivo
        Dim binRead As BinaryReader = New BinaryReader(Archivo) ';//Cargo el Archivo en modo binario

        ' Dim imagenEnBytes As Byte() = New Byte(Archivo.Length)  '//Creo un Array de Bytes donde guardare la imagen

        Dim imagenEnBytes(0 To Archivo.Length - 1) As Byte

        binRead.Read(imagenEnBytes, 0, CType(Archivo.Length, Integer)) ';//Cargo la imagen en el array de Bytes
        binRead.Close()
        Archivo.Close()

        Return imagenEnBytes ';//Devuelvo la imagen convertida en un array de bytes


    End Function

    Public Function obtenerFechaLarga(ByVal fecha As Date) As String
        Dim fechaTexto As String
        Dim fechaLarga As String

        fechaLarga = ""

        fechaTexto = FormatDateTime(fecha, vbLongDate)

        'quitamos el día de la semana (lunes, martes, ...) y la coma
        fechaTexto = Mid(fechaTexto, InStr(fechaTexto, ",") + 2, Len(fechaTexto))

        fechaLarga = fechaTexto

        Return fechaLarga
    End Function


    Public Function completarCeros(ByVal numero As String, cantidadCeros As Integer) As String
        Dim cuantos As String, i As Integer
        numero = Trim(numero) 'Trim quita los espacion en blanco 
        cuantos = "0"
        For i = 1 To cantidadCeros
            cuantos = cuantos & "0"
        Next i
        Return cuantos & numero
    End Function



    Public Function Imagen_A_Bytes(ByVal ruta As String) As Byte()
        Dim foto As New FileStream(ruta, FileMode.Open)
        Dim arreglo(0 To foto.Length - 1) As Byte
        Dim reader As New BinaryReader(foto)
        arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length))
        foto.Close()
        Return arreglo
    End Function


    Public Function GetFormatosFechas() As DataTable

        Dim dt As New DataTable

        dt.Columns.Add("ID")
        dt.Columns.Add("DESCRIPCION")

        dt.Rows.Add()
        dt.Rows(0)("ID") = "0"
        dt.Rows(0)("DESCRIPCION") = "SELECCIONE"

        dt.Rows.Add()
        dt.Rows(1)("ID") = "1"
        dt.Rows(1)("DESCRIPCION") = "DIA/MES/AÑO"

        dt.Rows.Add()
        dt.Rows(2)("ID") = "2"
        dt.Rows(2)("DESCRIPCION") = "MES/AÑO"

        dt.Rows.Add()
        dt.Rows(3)("ID") = "3"
        dt.Rows(3)("DESCRIPCION") = "AÑO"
        Return dt

    End Function

    Public Sub ValPer_Textbox(ByVal vlTipVal As Byte, ByVal Nom_Text As TextBox, ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case vlTipVal
            Case 1 'Todos los caracteres
                'No hacemos nada

            Case 2 'Sólo números
                If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
                    e.KeyChar = ""
                End If

            Case 3 'Sólo letras
                If Char.IsLetter(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsSeparator(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            Case 4 'Alfanuméricos
                If Char.IsLetter(e.KeyChar) Or Char.IsNumber(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsSeparator(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            Case 5 'Números y punto
                If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
                    e.KeyChar = ""
                Else
                    If e.KeyChar = "." And InStr(1, Nom_Text.Text, ".") > 0 Then e.KeyChar = ""
                End If

        End Select
    End Sub
End Module
