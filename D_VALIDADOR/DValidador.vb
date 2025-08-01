Option Explicit On
Imports System.IO
Imports System.Windows.Forms
Imports E_VALIDADOR

Imports Oracle.ManagedDataAccess.Client

Public Class DValidador

#Region "Variables"
    Private FSO As Scripting.FileSystemObject


    Dim estado As String
    'sp_fo_carga_sqlloader
    'Declaramos las variables
    Dim pi_vc2_arccar_empleador As String
    Dim pi_vc2_arccar_trabajador As String
    Dim pi_vc2_arccar_remunera As String
    Dim pi_num_codcar As Integer

    Dim vc2_username As String
    Dim vc2_password As String
    Dim vc2_connect As String

    Dim vc2_carga_empleadores As String
    Dim vc2_carga_trabajadores As String
    Dim vc2_carga_remunera As String

    Dim vc2_directorio_log As String
    Dim vc2_directorio_ctl As String
    Dim vc2_directorio_discard As String
    Dim vc2_directorio_bad As String

    Dim vc2_archivo_log As String
    Dim vc2_archivo_bad As String
    Dim vc2_archivo_discard As String
    Dim vc2_archivo_ctl As String

    Dim vc2_archivo_log_trabajadores As String

    Dim PI_VC2_NOMDIR As String

    'Dim conexion As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
    'Dim builder As New OracleConnectionStringBuilder(conexion)

    Dim conexion As Conexion = New Conexion()

#End Region

#Region "Insertar"
    Public Function Insertar(Obj As Validador, nombreTablas As String())
        Dim numCar As Long

        'Codigo para obtener la ruta completa en la capa presentación
        Dim PI_VC2_NOMDIREMPLEADORARCHIVO As String
        Dim PI_VC2_NOMDIRTRABAJADORARCHIVO As String
        Dim PI_VC2_NOMDIRREMUNERCIONESARCHIVO As String
        Try
            Dim miConexion As New Conexion()
            'Dim miConexion As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
            'Dim conexionOracle As New OracleConnection(miConexion)

            Dim conexionOracle As OracleConnection = miConexion.conn
            ' Obtener el nuevo número de carga
            conexionOracle.Open()
            'Obteniendo el numero de carga
            Dim ComandoNumCar As New OracleCommand("SELECT pq_fo_FOMCADE.fn_new_numcar FROM DUAL", conexionOracle)
            numCar = ComandoNumCar.ExecuteScalar()

            ' Insertar la nueva carga
            Dim Comando As New OracleCommand("pq_fo_fomcade.sp_fo_insertar", conexionOracle)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add(New OracleParameter("po_Num_NUMCAR", OracleDbType.Int64)).Value = numCar
            Comando.Parameters.Add(New OracleParameter("pi_dat_FECCAR", OracleDbType.Date)).Value = DateTime.Now
            Comando.Parameters.Add(New OracleParameter("pi_vC2_DESCRI", OracleDbType.NVarchar2)).Value = "CARGA DE DATOS REALIZADA EL: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            Comando.Parameters.Add(New OracleParameter("pi_Num_ESTADO", OracleDbType.Int64)).Value = 2 'Estado 



            Comando.Parameters.Add(New OracleParameter("PI_VC2_NOMDIR", OracleDbType.NVarchar2)).Value = Obj.PI_VC2_NOMDIREMPLEADOR

            Comando.Parameters.Add(New OracleParameter("pi_TIP_EMPL", OracleDbType.NVarchar2)).Value = Obj.Pi_TIP_EMPL

            Comando.Parameters.Add(New OracleParameter("po_vc2_coderr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output
            Comando.Parameters.Add(New OracleParameter("po_vc2_deserr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output

            'Obtenemos el valor de la ruta y le pasamos a la variable PI_VC2_NOMDIREMPLEADORARCHIVO
            PI_VC2_NOMDIREMPLEADORARCHIVO = Obj.PI_VC2_NOMDIREMPLEADORARCHIVO
            PI_VC2_NOMDIRTRABAJADORARCHIVO = Obj.PI_VC2_NOMDIRTRABAJADORARCHIVO
            PI_VC2_NOMDIRREMUNERCIONESARCHIVO = Obj.PI_VC2_NOMDIRREMUNERACIONESARCHIVO

            'Console.WriteLine("El nuevo número de carga es: " + numCar.ToString())
            'Console.WriteLine("RUTA DE ARCHIVO CARPETA txtArchivoEmpleador: " + Obj.PI_VC2_NOMDIREMPLEADOR)
            'Console.WriteLine("RUTA DE ARCHIVO CARPETA + ARCHIVO txtArchivoEmpleador: " + PI_VC2_NOMDIREMPLEADORARCHIVO)

            Comando.ExecuteNonQuery()
#End Region

            pi_num_codcar = numCar

            'CREACIÓN DE TABLAS DE "FOMEMPL", "FODRETR", "FODTREM"
            CreacionTablas(nombreTablas, conexionOracle, numCar)

            DefineDirectorio(conexionOracle)

            CreacionDirectorioyFicheros(pi_num_codcar)


#Region "Creacion de Ficheros"
            '    '****************************************************************
            '    ' Carga Empleadores
            '    '****************************************************************
            'FicheroEmpleador(numCar, PI_VC2_NOMDIREMPLEADORARCHIVO)
            FicheroEmpleador(numCar, PI_VC2_NOMDIREMPLEADORARCHIVO, Obj)

            FicheroTrabajador(numCar, PI_VC2_NOMDIRTRABAJADORARCHIVO, Obj)

            FicheroRemuneraciones(numCar, PI_VC2_NOMDIRREMUNERCIONESARCHIVO, Obj)
#End Region
            '    '****************************************************************
            '    ' Aplica Las Validaciones
            '    '****************************************************************
            AplicarValidador(conexionOracle, numCar, Obj)

            conexionOracle.Close()

        Catch ex As Exception
            Throw ex
        End Try

        Return numCar

    End Function

    Sub CreacionTablas(nombreTablas, conexionOracle, numcar)

        'CREACIÓN DE TABLAS DE "FOMEMPL", "FODRETR", "FODTREM"
        For Each nombreTabla As String In nombreTablas
            'Creacion de tabla Empleador
            'Ejecutamos el procedimiento sp_create_tables
            Dim ComandoTabla As New OracleCommand("pq_fo_carga_empresas_03.sp_create_tables", conexionOracle)
            ComandoTabla.CommandType = CommandType.StoredProcedure

            ComandoTabla.Parameters.Add(New OracleParameter("pi_vc2_nomtab", OracleDbType.NVarchar2)).Value = nombreTabla
            ComandoTabla.Parameters.Add(New OracleParameter("pi_vc2_prefijo", OracleDbType.Int64)).Value = numcar
            ComandoTabla.Parameters.Add(New OracleParameter("po_vc2_coderr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output
            ComandoTabla.Parameters.Add(New OracleParameter("po_vc2_deserr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output

            ComandoTabla.ExecuteNonQuery()



            Dim tablaCreada As Boolean = False

            ' Consulta SQL para buscar la tabla creada
            Dim consulta As String = "SELECT COUNT(*) FROM USER_TABLES WHERE TABLE_NAME = '" & nombreTabla & "'"
            Dim comandoConsulta As New OracleCommand(consulta, conexionOracle)
            Dim resultadoConsulta As Object = comandoConsulta.ExecuteScalar()

            If Convert.ToInt32(resultadoConsulta) > 0 Then
                tablaCreada = True
            End If

            ' Imprimir mensaje en la consola
            If tablaCreada Then
                Console.WriteLine("La tabla " & nombreTabla & "_" & numcar & " se ha creado correctamente.")
            Else
                Console.WriteLine("Error al crear la tabla " & nombreTabla & "_" & numcar)
            End If

        Next

    End Sub

    Sub DefineDirectorio(conexionOracle)
        '    '*****************************************************************************************
        '    'Define Directoriodonde Se Encuentran Los Archivos De Control
        '    '*****************************************************************************************

        Dim ComandoLog As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(2) FROM DUAL", conexionOracle)
        Dim ComandoDiscard As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(3) FROM DUAL", conexionOracle)
        Dim Comandobad As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(4) FROM DUAL", conexionOracle)
        Dim ComandoCtl As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(1) FROM DUAL", conexionOracle)


        vc2_directorio_log = ComandoLog.ExecuteScalar().ToString()
        vc2_directorio_discard = ComandoDiscard.ExecuteScalar().ToString()
        vc2_directorio_bad = Comandobad.ExecuteScalar().ToString()
        vc2_directorio_ctl = ComandoCtl.ExecuteScalar().ToString()

    End Sub

    Sub CreacionDirectorioyFicheros(pi_num_codcar)
        '    '****************************************************************
        '    ' Creando los directorios al C:/
        '    '****************************************************************
        If Not Directory.Exists(vc2_directorio_log) Then
            MkDir(vc2_directorio_log)
            Console.WriteLine("Directorio LOG creado correctamente." & vc2_directorio_log)
        Else
            Console.WriteLine("Directorio LOG ya existe." & vc2_directorio_log)

        End If

        If Not Directory.Exists(vc2_directorio_discard) Then
            MkDir(vc2_directorio_discard)
            Console.WriteLine("Directorio DISCARD creado correctamente." & vc2_directorio_discard)
        Else
            Console.WriteLine("Directorio DISCARD ya existe." & vc2_directorio_discard)

        End If

        If Not Directory.Exists(vc2_directorio_bad) Then
            MkDir(vc2_directorio_bad)
            Console.WriteLine("Directorio DISCARD creado correctamente." & vc2_directorio_bad)
        Else
            Console.WriteLine("Directorio DISCARD ya existe." & vc2_directorio_bad)

        End If

        If Not Directory.Exists(vc2_directorio_ctl) Then
            MkDir(vc2_directorio_ctl)
            Console.WriteLine("Directorio CTL creado correctamente." & vc2_directorio_ctl)
        Else
            Console.WriteLine("Directorio CTL ya existe." & vc2_directorio_ctl)

        End If

        Console.WriteLine("vc2_directorio_log: " & vc2_directorio_log)
        Console.WriteLine("vc2_directorio_discard: " & vc2_directorio_discard)
        Console.WriteLine("vc2_directorio_bad: " & vc2_directorio_bad)
        Console.WriteLine("vc2_directorio_ctl: " & vc2_directorio_ctl)

        '    '*********************************************************************
        '    '-- Le Asginamos El Nombre Y El Numero De Codigo De Carga + Ctl
        '    '*********************************************************************

        vc2_carga_empleadores = "carga_empleadores" & pi_num_codcar & ".ctl"
        vc2_carga_trabajadores = "carga_trabajadores" & pi_num_codcar & ".ctl"
        vc2_carga_remunera = "carga_remunera" & pi_num_codcar & ".ctl"

        Console.WriteLine("El carga_empleadores: " & vc2_carga_empleadores)
        Console.WriteLine("El carga_trabajadores: " & vc2_carga_trabajadores)
        Console.WriteLine("El carga_remunera: " & vc2_carga_remunera)

    End Sub

    Sub FicheroEmpleador(numCar, PI_VC2_NOMDIREMPLEADORARCHIVO, Obj)

        vc2_archivo_log = vc2_directorio_log & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".log"
        'Crear el objeto FileSystemObject vc2_archivo_log
        FSO = CreateObject("Scripting.FileSystemObject")

        ' Crear el archivo en disco ARCHIVO LOG
        Dim archivo_log As Scripting.TextStream
        'Set archivo = FSO.CreateTextFile(vc2_archivo_log, True)
        archivo_log = FSO.CreateTextFile(vc2_archivo_log, True)
        ' Escribir el contenido en el archivo
        archivo_log.WriteLine()

        ' Cerrar el archivo
        archivo_log.Close()

        vc2_archivo_bad = vc2_directorio_bad & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".bad"

        Dim archivo_bad As Scripting.TextStream
        archivo_bad = FSO.CreateTextFile(vc2_archivo_bad, True)
        archivo_bad.WriteLine()
        archivo_bad.Close()

        vc2_archivo_discard = vc2_directorio_discard & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".dis"

        Dim archivo_discard As Scripting.TextStream
        archivo_discard = FSO.CreateTextFile(vc2_archivo_discard, True)
        archivo_discard.Close()

        ' Crear el archivo en disco ARCHIVO CTL

        vc2_archivo_ctl = vc2_directorio_ctl & vc2_carga_empleadores

        Dim TipoValidacion As String = Obj.LI_VALIDADOR ' Tipo de formato de validación 1 o 2

        Console.WriteLine("Tipo de validacion es Formato 1 o 2 => : " + TipoValidacion)

        Dim archivo_ctl As Scripting.TextStream
        archivo_ctl = FSO.CreateTextFile(vc2_archivo_ctl, True)

        'Realizamos la condicion del formato 1 o 2
        If TipoValidacion = "1" Then
            ' Escribir el contenido en el archivo formato 1
            archivo_ctl.WriteLine("LOAD DATA
                TRUNCATE
                INTO TABLE FOMEMPL_" & numCar & "      
                (
                c_codtie POSITION(1:2) CHAR,
                c_numdoc POSITION(3:17) CHAR,
                c_codsed POSITION(18:36) CHAR,
                c_tipint POSITION(37:38) CHAR,
                c_razsoe POSITION(39:138) CHAR,
                c_dessed POSITION(139:238) CHAR,
                c_tidofo POSITION(239:240) CHAR,
                c_nudore POSITION(241:255) CHAR,
                c_noapre POSITION(256:355) CHAR,
                c_cocare POSITION(356:357) CHAR,
                c_correp POSITION(358:457) CHAR,
                c_telrep POSITION(458:477) CHAR,
                c_tdoal1 POSITION(478:479) CHAR,
                c_nuale1 POSITION(480:494) CHAR,
                c_tdoal2 POSITION(495:496) CHAR,
                c_nuale2 POSITION(497:511) CHAR
                ) ")
        ElseIf TipoValidacion = "2" Then
            ' Escribir el contenido en el archivo formato 2
            archivo_ctl.WriteLine("LOAD DATA
                TRUNCATE
                INTO TABLE FOMEMPL_" & numCar & "      
                (
                c_codtie POSITION(1:2) CHAR,
                c_numdoc POSITION(3:17) CHAR,
                c_tipint POSITION(18:19) CHAR,
                c_razsoe POSITION(20:119) CHAR,
                c_tidofo POSITION(120:121) CHAR,
                c_nudore POSITION(122:136) CHAR,
                c_noapre POSITION(137:236) CHAR,
                c_correp POSITION(237:336) CHAR,
                c_telrep POSITION(337:356) CHAR
                ) ")
            'Fin de CTL
        End If
        '' Cerrar el archivo
        archivo_ctl.Close()

        Console.WriteLine("El vc2_archivo_log: " & vc2_archivo_log)
        Console.WriteLine("El vc2_archivo_bad: " & vc2_archivo_bad)
        Console.WriteLine("El vc2_archivo_discard: " & vc2_archivo_discard)

        Console.WriteLine("El vc2_archivo_ctl: " & vc2_archivo_ctl)

        Dim the_command As String

        Dim vc2_username As String = conexion.Usuario
        Dim vc2_password As String = conexion.Clave
        Dim vc2_connect As String = conexion.Servidor & "/" & conexion.Base

        pi_vc2_arccar_empleador = PI_VC2_NOMDIREMPLEADORARCHIVO

        'dvl_create_ctl_empleadores(conexionOracle, numCar, obj)

        'pi_vc2_arccar_trabajador = es la direccion del archivo

        the_command = "sqlldr control=" & vc2_directorio_ctl & vc2_carga_empleadores & " data=" & pi_vc2_arccar_empleador & " log=" & vc2_archivo_log & " BAD=" & vc2_archivo_bad & " DISCARD=" & vc2_archivo_discard & " userid=" & vc2_username & "/" & vc2_password & "@" & vc2_connect & " errors=9999999 direct=TRUE DISCARDMAX=9999999 PARALLEL=FALSE;"

        Console.WriteLine("¨***********************Creando  SQLOADER EMPLEADOR***************: " & the_command)

        Try
            Dim process As New Process
            Dim process_info As New ProcessStartInfo("cmd.exe", "/c " & the_command)

            process_info.CreateNoWindow = True
            process_info.UseShellExecute = False

            process.StartInfo = process_info
            process.Start()
            process.WaitForExit()

            Dim exit_code As Integer = process.ExitCode

            Console.WriteLine("El comando a ejecutar es: " & process_info.FileName & " " & process_info.Arguments)

            Console.WriteLine("El comando a ejecutar START: " & process.Start())

            If exit_code = 0 Then
                ' MsgBox("La carga de datos se ha realizado correctamente.")
            Else
                MsgBox("La carga de datos del EMPLEADOR ha fallado con el código de salida " & exit_code & ".")
                Dim result As MsgBoxResult
                result = MsgBox("¿Desea abrir el archivo de log de EMPLEADOR?", vbYesNo, "Error en la carga de datos")

                If result = MsgBoxResult.Yes Then
                    ' Código para abrir el archivo de registro
                    Process.Start(vc2_archivo_log)
                Else
                    ' Código para no hacer nada o cerrar el formulario, según corresponda
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ejecutar el comando: " & ex.Message)
        End Try
    End Sub
    Sub FicheroTrabajador(numCar, PI_VC2_NOMDIRTRABAJADORARCHIVO, Obj)

        vc2_archivo_log = vc2_directorio_log & "TRABAJADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".log"
        'Crear el objeto FileSystemObject vc2_archivo_log
        FSO = CreateObject("Scripting.FileSystemObject")

        ' Crear el archivo en disco ARCHIVO LOG
        Dim archivo_log As Scripting.TextStream
        'Set archivo = FSO.CreateTextFile(vc2_archivo_log, True)
        archivo_log = FSO.CreateTextFile(vc2_archivo_log, True)
        ' Escribir el contenido en el archivo
        archivo_log.WriteLine()
        ' Cerrar el archivo
        archivo_log.Close()

        vc2_archivo_bad = vc2_directorio_bad & "TRABAJADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".bad"

        Dim archivo_bad As Scripting.TextStream
        archivo_bad = FSO.CreateTextFile(vc2_archivo_bad, True)
        archivo_bad.WriteLine()
        archivo_bad.Close()

        vc2_archivo_discard = vc2_directorio_discard & "TRABAJADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".dis"

        Dim archivo_discard As Scripting.TextStream
        archivo_discard = FSO.CreateTextFile(vc2_archivo_discard, True)
        archivo_discard.Close()
        ' Crear el archivo en disco ARCHIVO CTL
        vc2_archivo_ctl = vc2_directorio_ctl & vc2_carga_trabajadores
        'Declaramo variable 
        Dim tipoValidacion As String = Obj.LI_VALIDADOR ' Tipo de formato de validación 1 o 2
        Dim archivo_ctl As Scripting.TextStream
        archivo_ctl = FSO.CreateTextFile(vc2_archivo_ctl, True)
        'Realizamos la condición en el archivo formato 1 o 2
        If tipoValidacion = "1" Then
            ' Escribir el contenido en el archivo
            archivo_ctl.WriteLine("LOAD DATA
                TRUNCATE
                INTO TABLE FODTREM_" & numCar & "      
                    (
                    C_CODTIE POSITION(1:2) CHAR,
                    C_NUMDOE POSITION(3:17) CHAR,
                    C_CODSED POSITION(18:36) CHAR,
                    C_CODTIT POSITION(37:38) CHAR,
                    C_NUMDOT POSITION(39:53) CHAR,
                    C_APEPAT POSITION(54:153) CHAR,
                    C_APEMAT POSITION(154:253) CHAR,
                    C_NOMBRT POSITION(254:353) CHAR,
                    C_NUSEAU POSITION(354:383) CHAR,
                    C_TDOAL1 POSITION(384:385) CHAR,
                    C_NUALE1 POSITION(386:400) CHAR,
                    C_TDOAL2 POSITION(401:402) CHAR,
                    C_NUALE2 POSITION(403:417) CHAR,
                    C_FECNAC POSITION(418:427) CHAR,
                    C_CODTRI POSITION(428:442) CHAR
                    )
                ")
        ElseIf tipoValidacion = "2" Then
            ' Escribir el contenido en el archivo formato 2
            archivo_ctl.WriteLine("LOAD DATA
                TRUNCATE
                INTO TABLE FODTREM_" & numCar & "
                (
                C_CODTIE POSITION(1:2) CHAR,
                C_NUMDOE POSITION(3:17) CHAR,
                C_CODTIT POSITION(18:19) CHAR,
                C_NUMDOT POSITION(20:34) CHAR,
                C_APEPAT POSITION(35:134) CHAR,
                C_APEMAT POSITION(135:234) CHAR,
                C_NOMBRT POSITION(235:334) CHAR,
                C_FECNAC POSITION(335:344) CHAR,
                C_NUSEAU POSITION(345:374) CHAR,
                C_CODTRI POSITION(375:389) CHAR,
                C_TDOAL1 POSITION(390:391) CHAR,
                C_NUALE1 POSITION(392:406) CHAR
                )")
        End If
        ' Cerrar el archivo
        archivo_ctl.Close()

        Console.WriteLine("El vc2_archivo_log: " & vc2_archivo_log)
        Console.WriteLine("El vc2_archivo_bad: " & vc2_archivo_bad)
        Console.WriteLine("El vc2_archivo_discard: " & vc2_archivo_discard)

        Console.WriteLine("El vc2_archivo_ctl: " & vc2_archivo_ctl)

        Dim the_command As String

        Dim vc2_username As String = conexion.Usuario
        Dim vc2_password As String = conexion.Clave
        Dim vc2_connect As String = conexion.Servidor & "/" & conexion.Base

        'Dim vc2_username As String = builder.UserID
        'Dim vc2_password As String = builder.Password
        'Dim vc2_connect As String = builder.DataSource

        'pi_vc2_arccar_empleador = Obj.PI_VC2_NOMDIREMPLEADOR & "EMPLEADOR.TXT"
        pi_vc2_arccar_trabajador = PI_VC2_NOMDIRTRABAJADORARCHIVO

        'pi_vc2_arccar_trabajador = es la direccion del archivo

        the_command = "sqlldr control=" & vc2_directorio_ctl & vc2_carga_trabajadores & " data=" & pi_vc2_arccar_trabajador & " log=" & vc2_archivo_log & " BAD=" & vc2_archivo_bad & " DISCARD=" & vc2_archivo_discard & " userid=" & vc2_username & "/" & vc2_password & "@" & vc2_connect & " errors=9999999 direct=TRUE DISCARDMAX=9999999 PARALLEL=FALSE;"

        Console.WriteLine("Creando  SQLOADER TRABAJADORES: " & the_command)

        Try
            Dim process As New Process
            Dim process_info As New ProcessStartInfo("cmd.exe", "/c " & the_command)

            process_info.CreateNoWindow = True
            process_info.UseShellExecute = False

            process.StartInfo = process_info
            process.Start()
            process.WaitForExit()

            Dim exit_code As Integer = process.ExitCode

            If exit_code = 0 Then
                '  MsgBox("La carga de datos se ha realizado correctamente .")
            Else
                MsgBox("La carga de datos TRABAJADOR ha fallado con el código de salida " & exit_code & ".")
                Dim result As MsgBoxResult
                result = MsgBox("¿Desea abrir el archivo de log de TRABAJADOR?", vbYesNo, "Error en la carga de datos")

                If result = MsgBoxResult.Yes Then
                    ' Código para abrir el archivo de registro
                    Process.Start(vc2_archivo_log)
                Else
                    ' Código para no hacer nada o cerrar el formulario, según corresponda
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ejecutar el comando: " & ex.Message)
        End Try

    End Sub

    Sub FicheroRemuneraciones(numCar, PI_VC2_NOMDIRREMUNERCIONESARCHIVO, Obj)

        vc2_archivo_log = vc2_directorio_log & "REMUNERA_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".log"
        'Crear el objeto FileSystemObject vc2_archivo_log
        FSO = CreateObject("Scripting.FileSystemObject")

        ' Crear el archivo en disco ARCHIVO LOG
        Dim archivo_log As Scripting.TextStream
        'Set archivo = FSO.CreateTextFile(vc2_archivo_log, True)
        archivo_log = FSO.CreateTextFile(vc2_archivo_log, True)
        ' Escribir el contenido en el archivo
        archivo_log.WriteLine()
        ' Cerrar el archivo
        archivo_log.Close()

        vc2_archivo_bad = vc2_directorio_bad & "REMUNERA_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".bad"

        Dim archivo_bad As Scripting.TextStream
        archivo_bad = FSO.CreateTextFile(vc2_archivo_bad, True)
        archivo_bad.WriteLine()
        archivo_bad.Close()


        vc2_archivo_discard = vc2_directorio_discard & "REMUNERA_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".dis"

        Dim archivo_discard As Scripting.TextStream
        archivo_discard = FSO.CreateTextFile(vc2_archivo_discard, True)
        archivo_discard.Close()
        ' Crear el archivo en disco ARCHIVO CTL
        vc2_archivo_ctl = vc2_directorio_ctl & vc2_carga_remunera

        Dim TipoValidacion As String = Obj.LI_VALIDADOR 'Tipo  de formato de validación 1 o 2 

        Dim archivo_ctl As Scripting.TextStream

        archivo_ctl = FSO.CreateTextFile(vc2_archivo_ctl, True)

        'Realizamos la condición del formato 1 o 2
        If TipoValidacion = "1" Then

            ' Escribir el contenido en el archivo
            archivo_ctl.WriteLine("LOAD DATA
                TRUNCATE
                INTO TABLE FODRETR_" & numCar & "      
           (
            C_CODTIE POSITION(1:2) CHAR,
            C_NUMDOE POSITION(3:17) CHAR,
            C_CODSED POSITION(18:36) CHAR,
            C_CODTIT POSITION(37:38) CHAR,
            C_NUMDOT POSITION(39:53) CHAR,
            D_FECIPA POSITION(54:63) CHAR,
            D_FECFPA POSITION(64:73) CHAR,
            C_CODTTR POSITION(74:75) CHAR,
            C_CODPIR POSITION(76:77) CHAR,
            C_TIPMON POSITION(78:79) CHAR,
            C_MOAREM POSITION(80:94) INTEGER EXTERNAL,
            C_TIPSEG POSITION(95:96) CHAR, 
            C_MOAPSE POSITION(97:111) INTEGER EXTERNAL,
            C_TIREPE POSITION(112:113) CHAR,
            C_MOARPE POSITION(114:128) INTEGER EXTERNAL,
            C_MOAPFT POSITION(129:143) INTEGER EXTERNAL,
            C_MOAPFE POSITION(144:158) INTEGER EXTERNAL
            )"
                )
        ElseIf TipoValidacion = "2" Then
            ' Escribir el contenido en el archivo formato 2
            archivo_ctl.WriteLine("LOAD DATA 
                TRUNCATE
                 INTO TABLE FOMEMPL_" & numCar & "      
                 (
                    C_CODTIE POSITION(1:2) CHAR,
                    C_NUMDOE POSITION(3:17) CHAR,
                    C_CODTIT POSITION(18:19) CHAR,
                    C_NUMDOT POSITION(20:34) CHAR,
                    D_FECIPA POSITION(35:44) CHAR,
                    D_FECFPA POSITION(45:54) CHAR,
                    C_CODPIR POSITION(55:56) CHAR'
                 ) ")
            'Fin de CTL
        End If
        ' Cerrar el archivo
        archivo_ctl.Close()

        Console.WriteLine("El vc2_archivo_log: " & vc2_archivo_log)
        Console.WriteLine("El vc2_archivo_bad: " & vc2_archivo_bad)
        Console.WriteLine("El vc2_archivo_discard: " & vc2_archivo_discard)

        Console.WriteLine("El vc2_archivo_ctl: " & vc2_archivo_ctl)

        Dim the_command As String

        Dim vc2_username As String = conexion.Usuario
        Dim vc2_password As String = conexion.Clave
        Dim vc2_connect As String = conexion.Servidor & "/" & conexion.Base

        pi_vc2_arccar_remunera = PI_VC2_NOMDIRREMUNERCIONESARCHIVO

        the_command = "sqlldr control=" & vc2_directorio_ctl & vc2_carga_remunera & " data=" & pi_vc2_arccar_remunera & " log=" & vc2_archivo_log & " BAD=" & vc2_archivo_bad & " DISCARD=" & vc2_archivo_discard & " userid=" & vc2_username & "/" & vc2_password & "@" & vc2_connect & " errors=9999999 direct=TRUE DISCARDMAX=9999999 PARALLEL=FALSE;"

        Console.WriteLine("Creando  SQLOADER REMUNERA: " & the_command)

        Try
            Dim process As New Process
            Dim process_info As New ProcessStartInfo("cmd.exe", "/c " & the_command)

            process_info.CreateNoWindow = True
            process_info.UseShellExecute = False

            process.StartInfo = process_info
            process.Start()
            process.WaitForExit()

            Dim exit_code As Integer = process.ExitCode

            If exit_code = 0 Then

            Else
                Dim result As DialogResult
                result = MessageBox.Show("La carga de datos REMUNERACIONES ha fallado con el código de salida " & exit_code & "." & vbCrLf & "¿Desea abrir el archivo de log de REMUNERACIONES?", "Error en la carga de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

                If result = DialogResult.Yes Then
                    Process.Start(vc2_archivo_log)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ejecutar el comando: " & ex.Message)
        End Try

    End Sub

    Sub AplicarValidador(conexionOracle, numCar, Obj)

        '    '****************************************************************
        '    ' Aplica Las Validaciones
        '    '****************************************************************
        Dim LITIPVALIDADOR As String
        Dim LITIPPADVALIDADOR As String
        Try
            Dim ComandoValidaciones As New OracleCommand("pq_fo_carga_empresas.sp_fo_general_LANZA_JOB", conexionOracle)
            ' Dim ComandoValidaciones As New OracleCommand("pq_fo_carga_empresas_ARCHIVO2.sp_fo_general_LANZA_JOB", conexionOracle)
            ComandoValidaciones.CommandType = CommandType.StoredProcedure
            ComandoValidaciones.Parameters.Add(New OracleParameter("pi_num_tippas", OracleDbType.Int64)).Value = Obj.LITIPPAD 'APORTES 1 MINIMO 2
            ComandoValidaciones.Parameters.Add(New OracleParameter("pi_num_tipval", OracleDbType.Int64)).Value = Obj.LITIPVAL 'Empleador, Interna , Empleador + Reniec
            ComandoValidaciones.Parameters.Add(New OracleParameter("po_num_numcar", OracleDbType.Int64)).Value = numCar

            ComandoValidaciones.ExecuteNonQuery()

            LITIPVALIDADOR = Obj.LITIPVAL
            LITIPPADVALIDADOR = Obj.LITIPPAD

            Console.WriteLine("Vemos que tipo de validacion LITIPVALIDADOR  es: " & LITIPVALIDADOR)

            Console.WriteLine("Vemos que tipo de validacion es LITIPPADVALIDADOR: " & LITIPPADVALIDADOR)
            Console.WriteLine("Validaciones aplicadas con éxito.")


        Catch ex As Exception

            Console.WriteLine("Se produjo un error al aplicar las validaciones. " & ex.Message)

        End Try


    End Sub

#Region "Buscar"
    Public Function Buscar(Valor As String) As DataTable
        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "SELECT N_numcar, D_feccar, C_descri, N_estado,
                                    CASE
                                        WHEN C_TIPEMPL = '0' THEN 'PUBLICO'
                                        WHEN C_TIPEMPL = '1' THEN 'PRICO'
                                        WHEN C_TIPEMPL = '2' THEN 'PRIVADO'
                                        WHEN C_TIPEMPL = '3' THEN 'BUEN CONTRIBUYENTE'
                                        WHEN C_TIPEMPL = '4' THEN 'OTROS'
                                    END AS C_TIPEMPL
                                FROM Fomcade
                                WHERE N_NUMCAR = :numCar"
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor

            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region

#Region "Buscar Por Estado"
    Public Function BuscarPorEstado(N_Estado As String) As DataTable
        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "       SELECT N_numcar, D_feccar, C_descri, N_estado,
                                    CASE
                                        WHEN C_TIPEMPL = '0' THEN 'PUBLICO'
                                        WHEN C_TIPEMPL = '1' THEN 'PRICO'
                                        WHEN C_TIPEMPL = '2' THEN 'PRIVADO'
                                        WHEN C_TIPEMPL = '3' THEN 'BUEN CONTRIBUYENTE'
                                        WHEN C_TIPEMPL = '4' THEN 'OTROS'
                                    END AS C_TIPEMPL
                                FROM Fomcade
                                WHERE N_ESTADO = :n_estado
                                        ORDER BY D_feccar DESC
                                        "
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("n_estado", OracleDbType.Int64).Value = N_Estado

            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        End Try
        Return dtResultado


    End Function

#End Region

#Region "Listar los 500 ultimos registro"
    Public Function Listar50Ultimos() As DataTable
        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "SELECT N_numcar, D_feccar, C_descri, N_estado,C_TIPEMPL 
                                    FROM (
                                        SELECT N_numcar, D_feccar, C_descri, N_estado,
                                        CASE
                                        WHEN C_TIPEMPL = '0' THEN 'PUBLICO'
                                        WHEN C_TIPEMPL = '1' THEN 'PRICO'
                                        WHEN C_TIPEMPL = '2' THEN 'PRIVADO'
                                        WHEN C_TIPEMPL = '3' THEN 'BUEN CONTRIBUYENTE'
                                        WHEN C_TIPEMPL = '4' THEN 'OTROS'
                                    END AS C_TIPEMPL
                                        FROM Fomcade 
                                        ORDER BY D_feccar DESC
                                    ) 
                                    WHERE ROWNUM <= 500"
            Dim comando As New OracleCommand(sql, conexionOracle)
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw ex
        End Try
        Return dtResultado
    End Function

#End Region

#Region "Tipo de empleadores PUBLICO,PRICO,PRIVADO,BUEN CONTRIBUYENTE"
    Public Function TipoEmpleadores()

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "Select * From fodtita Where n_coddom = 11"
            Dim comando As New OracleCommand(sql, conexionOracle)
            Dim adaptador As New OracleDataAdapter(comando)

            Dim dataTable As New DataTable()
            adaptador.Fill(dataTable)

            Return dataTable
        Catch ex As Exception
            Throw ex
            'Finally
            '    conexionOracle.Close()
        End Try
        Return dtResultado
    End Function

#End Region

#Region "RESUMEN CARGA EMPRESA"
    Public Function RESUMEN_CARGA_EMPRESA(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
     SELECT fr.n_numcar,
     (
     select 'NRO DOC EMPLEADOR:'||ee.c_numdoc
     from FOMEMPL_VAL_HIST ee where ee.n_numcar =FR.N_NUMCAR  AND ROWNUM=1
     )||'-'||C_NOMEMP C_NOMEMP,
     Decode(fr.n_estado,1,'CARGA SATISFACTORIA',2,'CARGA REGISTRADA',3,'CARGA EN PROCESO','CARGA CON OBSERVACIONES') C_ESTADO,fr.d_feccar, fr.c_descri, fr.n_numtot, fr.n_regert, fr.n_regsat, fr.n_numtoe, fr.n_regere, fr.n_regsae, fr.n_numtor,fr.n_regerr, fr.n_regsar, fr.n_emppas, fr.n_trabpas, fr.n_rempas, fr.n_poremp, fr.n_portrab, fr.n_porrem, t.c_descri TipEmpl
         FROM FOMCADE FR
       Left Join fodtita t On t.c_coddet = fr.c_tipempl
     And t.n_coddom = 11
    where n_numcar = :n_numcar"
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region

#Region "RESULTADO DE CARGA REALIZADA"
    Public Function RESULTADO_CARGA_REALIZADA(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
Select 'Empresas' registro, t.n_numtoe RegCargados, t.n_regere RegError, t.n_regsae RegValido, t.n_poremp Porcentaje
From fomcade t
Where t.n_numcar = :n_numcar 
Union All
Select 'Trabajadores' registro, t.n_numtot RegCargados, t.n_regert RegError, t.n_regsat RegValido, t.n_portrab Porcentaje
       From fomcade t
Where t.n_numcar = :n_numcar 
Union All
Select 'Remuneraciones' registro, t.n_numtor RegCargados, t.n_regerr RegError, t.n_regsar RegValido, t.n_porrem Porcentaje
From fomcade t
Where t.n_numcar = :n_numcar "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function

#End Region


#Region "RESUMEN POR TIPO DE ERROR EMPLEADORES"
    Public Function RESUMEN_TIPOERROR_EMPLEADORES(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT 
                res.C_DESTIP AS tipo,
                SUM(res.N_NUMREG) AS CUENTA,
                res.N_CODERR As CODERR,
                ERR.C_DESCRI AS DES_ERROR
                FROM FODDERE res
                INNER JOIN FODERRO ERR ON ERR.N_CODERR = RES.N_CODERR
                WHERE N_NUMCAR = :n_numcar  AND res.C_DESTIP = '1. EMPLEADORES'
                GROUP BY ERR.C_DESCRI, res.N_NUMREG, res.C_DESTIP, res.N_CODERR "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
#Region "RESUMEN POR TIPO DE ERROR TRABAJADORES"
    Public Function RESUMEN_TIPOERROR_TRABAJADORES(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT 
                res.C_DESTIP AS tipo,
                SUM(res.N_NUMREG) AS CUENTA,
                res.N_CODERR As CODERR,
                ERR.C_DESCRI AS DES_ERROR
                FROM FODDERE res
                INNER JOIN FODERRO ERR ON ERR.N_CODERR = RES.N_CODERR
                WHERE N_NUMCAR = :n_numcar  AND res.C_DESTIP = '2. TRABAJADORES'
                GROUP BY ERR.C_DESCRI, res.N_NUMREG, res.C_DESTIP, res.N_CODERR "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
#Region "RESUMEN POR TIPO DE ERROR REMUNERACIONES "
    Public Function RESUMEN_TIPOERROR_REMUNERACIONES(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT 
                res.C_DESTIP AS tipo,
                SUM(res.N_NUMREG) AS CUENTA,
                res.N_CODERR As CODERR,
                ERR.C_DESCRI AS DES_ERROR
                FROM FODDERE res
                INNER JOIN FODERRO ERR ON ERR.N_CODERR = RES.N_CODERR
                WHERE N_NUMCAR = :n_numcar  AND res.C_DESTIP = '3. REMUNERACIONES'
                GROUP BY ERR.C_DESCRI, res.N_NUMREG, res.C_DESTIP, res.N_CODERR "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
#Region "RESUMEN POR TIPO DE ERROR 4. REMUNERACIONES DUPLICADOS "
    Public Function RESUMEN_TIPOERROR_REMUNERACIONES_DUPLICADOS(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT 
                res.C_DESTIP AS tipo,
                SUM(res.N_NUMREG) AS CUENTA,
                res.N_CODERR As CODERR,
                ERR.C_DESCRI AS DES_ERROR
                FROM FODDERE res
                INNER JOIN FODERRO ERR ON ERR.N_CODERR = RES.N_CODERR
                WHERE N_NUMCAR = :n_numcar  AND res.C_DESTIP = '4. REMUNERACIONES DUPLICADOS'
                GROUP BY ERR.C_DESCRI, res.N_NUMREG, res.C_DESTIP, res.N_CODERR "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
#Region "RESUMEN POR TIPO DE ERROR 5. TRABAJADORES INTEGRIDAD "
    Public Function RESUMEN_TIPOERROR_TRABAJADORES_INTEGRIDAD(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT 
                res.C_DESTIP AS tipo,
                SUM(res.N_NUMREG) AS CUENTA,
                res.N_CODERR As CODERR,
                ERR.C_DESCRI AS DES_ERROR
                FROM FODDERE res
                INNER JOIN FODERRO ERR ON ERR.N_CODERR = RES.N_CODERR
                WHERE N_NUMCAR = :n_numcar  AND res.C_DESTIP = '5. TRABAJADORES INTEGRIDAD'
                GROUP BY ERR.C_DESCRI, res.N_NUMREG, res.C_DESTIP, res.N_CODERR "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
#Region "RESUMEN POR TIPO DE ERROR 6. REMUNERACIONES INTEGRIDAD "
    Public Function RESUMEN_TIPOERROR_REMUNERACIONES_INTEGRIDAD(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT 
                res.C_DESTIP AS tipo,
                SUM(res.N_NUMREG) AS CUENTA,
                res.N_CODERR As CODERR,
                ERR.C_DESCRI AS DES_ERROR
                FROM FODDERE res
                INNER JOIN FODERRO ERR ON ERR.N_CODERR = RES.N_CODERR
                WHERE N_NUMCAR = :n_numcar  AND res.C_DESTIP = '6. REMUNERACIONES INTEGRIDAD'
                GROUP BY ERR.C_DESCRI, res.N_NUMREG, res.C_DESTIP, res.N_CODERR "

            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
#Region "RESUMEN POR TIPO DE DOCUMENTO POR TRABAJADOR"
    Public Function RESUMEN_TIPODOCUMENTO_TRABAJADOR(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
              Select count(1) CUENTA_TIPDOC ,
               (Select C_DESCRI
                From fodtita tittA
                Where tittA.N_CODDOM =1
                  And tittA.c_CODDET =DETA.C_CODTIT
                ) TIPO_DOC_TRABAJ
        From fodtrem_val_hist deta
        Where deta.n_numcar= :n_numcar
        Group By DETA.C_CODTIT"
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el RESUMEN_CARGA_EMPRESA: " + ex.Message)
        End Try
        Return dtResultado
    End Function
#End Region
    Public Function ESTADO_CARGA(Valor As String) As DataTable

        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                Select  N_numcar,D_feccar,C_descri,N_estado,C_nomdir
                From Fomcade  where N_numcar = :numCar AND n_ESTADO < 3 "
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor
            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al ESTADO CARGA: " + ex.Message)
        End Try
        Return dtResultado
    End Function

End Class
