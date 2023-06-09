Imports E_VALIDADOR

Imports Oracle.ManagedDataAccess.Client
Public Class DValidador
    'sp_fo_carga_sqlloader
    'Declaramos las variables
    Dim pi_vc2_arccar_empleador As String
    Dim pi_vc2_arccar_trabajador As String
    Dim pi_vc2_arccar_remunera As String
    Dim pi_num_codcar As Integer
    Dim pi_num_tiparch As Integer


    Dim the_command As String

    Dim vc2_username As String
    Dim vc2_password As String
    Dim vc2_connect As String

    Dim vc2_coderr As String
    Dim vc2_deserr As String




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




    Public Function Insertar(Obj As Validador)
        Dim numCar As Long
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            ' Obtener el nuevo número de carga
            conexionOracle.Open()
            Dim ComandoNumCar As New OracleCommand("SELECT pq_fo_FOMCADE.fn_new_numcar FROM DUAL", conexionOracle)
            numCar = ComandoNumCar.ExecuteScalar()

            ' Insertar la nueva carga
            Dim Comando As New OracleCommand("pq_fo_fomcade.sp_fo_insertar", conexionOracle)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add(New OracleParameter("po_Num_NUMCAR", OracleDbType.Int64)).Value = numCar
            Comando.Parameters.Add(New OracleParameter("pi_dat_FECCAR", OracleDbType.Date)).Value = DateTime.Now
            Comando.Parameters.Add(New OracleParameter("pi_vC2_DESCRI", OracleDbType.NVarchar2)).Value = "CARGA DE DATOS REALIZADA EL: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Comando.Parameters.Add(New OracleParameter("pi_Num_ESTADO", OracleDbType.Int64)).Value = 2
            Comando.Parameters.Add(New OracleParameter("PI_VC2_NOMDIR", OracleDbType.NVarchar2)).Value = Obj.PI_VC2_NOMDIR
            Comando.Parameters.Add(New OracleParameter("po_vc2_coderr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output
            Comando.Parameters.Add(New OracleParameter("po_vc2_deserr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output

            Console.WriteLine("El nuevo número de carga es: " + numCar.ToString())

            Comando.ExecuteNonQuery()


            conexionOracle.Close()
            ' End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return numCar

    End Function

    Public Sub CrearTablas(nombreTablas As String())
        Dim numCar As Long
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            conexionOracle.Open()

            Dim ComandoNumCar As New OracleCommand("SELECT pq_fo_FOMCADE.fn_new_numcar FROM DUAL", conexionOracle)
            numCar = ComandoNumCar.ExecuteScalar()

            For Each nombreTabla As String In nombreTablas
                'Creacion de tabla Empleador
                Dim Comando As New OracleCommand("pq_fo_carga_empresas_03.sp_create_tables", conexionOracle)
                Comando.CommandType = CommandType.StoredProcedure

                Comando.Parameters.Add(New OracleParameter("pi_vc2_nomtab", OracleDbType.NVarchar2)).Value = nombreTabla
                Comando.Parameters.Add(New OracleParameter("pi_vc2_prefijo", OracleDbType.Int64)).Value = numCar
                Comando.Parameters.Add(New OracleParameter("po_vc2_coderr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output
                Comando.Parameters.Add(New OracleParameter("po_vc2_deserr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output

                Comando.ExecuteNonQuery()
            Next

            conexionOracle.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    '=========================================================================================================
    Sub GenerandocargaSQLloader()

        pi_num_codcar = 121 'TODO: es un ejemplo aqui va el número de carga

        '*********************************************************************
        '-- Le Asginamos El Nombre Y El Numero De Codigo De Carga + Ctl
        '*********************************************************************


        vc2_carga_empleadores = "carga_empleadores" & pi_num_codcar & ".ctl"
        vc2_carga_trabajadores = "carga_trabajadores" & pi_num_codcar & ".ctl"
        vc2_carga_remunera = "carga_remunera" & pi_num_codcar & ".ctl"

        'Obtiene Credenciales De Conexion


        '*********************************************************************
        'Define Dem  Directorioa De Trabajo
        '*********************************************************************
        'Otros Procedimientos Con Variables Declarables
        Dim miConexion As New Conexion()
        Dim conexionOracle As OracleConnection = miConexion.conn
        conexionOracle.Open()

        Dim ComandoLog As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(2) FROM DUAL", conexionOracle)
        Dim ComandoDiscard As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(3) FROM DUAL", conexionOracle)
        Dim Comandobad As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(4) FROM DUAL", conexionOracle)


        '*****************************************************************************************
        'Define Directoriodonde Se Encuentran Los Archivos De Control
        '*****************************************************************************************
        Dim ComandoCtl As New OracleCommand("SELECT pq_fo_utlitarios.FN_FO_RECUPERA_CONF(1) FROM DUAL", conexionOracle)


        vc2_directorio_log = ComandoLog.ExecuteScalar().ToString()
        vc2_directorio_discard = ComandoDiscard.ExecuteScalar().ToString()
        vc2_directorio_bad = Comandobad.ExecuteScalar().ToString()


        vc2_directorio_ctl = ComandoCtl.ExecuteScalar().ToString()

        conexionOracle.Close()


        '****************************************************************
        ' Carga Empleadores
        '****************************************************************


        'vc2_archivo_log := vc2_directorio_log||'EMPLEADORES_'||to_char(sysdate,'yyyymmdd')||'_' ||to_char(sysdate,'hh24miss')||'_CARGA_NRO_' ||pi_num_codcar||'.log ';
        vc2_archivo_log = vc2_directorio_log & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".log"

        ' vc2_archivo_bad := vc2_directorio_discard||'EMPLEADORES_'||to_char(sysdate,'yyyymmdd')||'_' ||to_char(sysdate,'hh24miss')||'_CARGA_NRO_' ||pi_num_codcar||'.dis ';

        vc2_archivo_bad = vc2_directorio_discard & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".dis"

        ' vc2_archivo_discard := vc2_directorio_bad||'EMPLEADORES_'||to_char(sysdate,'yyyymmdd')||'_' ||to_char(sysdate,'hh24miss')||'_CARGA_NRO_' ||pi_num_codcar||'.bad ';

        vc2_archivo_discard = vc2_directorio_bad & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".bad"

        'HOST( 'cmd /c del '||vc2_directorio_ctl||vc2_carga_empleadores   , NO_SCREEN );  
        ' Crear una instancia del proceso
        Dim proceso As New Process()
        ' Configurar el comando a ejecutar
        proceso.StartInfo.FileName = "cmd.exe"
        proceso.StartInfo.Arguments = "/c del " & vc2_directorio_ctl & vc2_carga_empleadores
        proceso.StartInfo.CreateNoWindow = True
        proceso.StartInfo.UseShellExecute = False
        ' Iniciar el proceso
        proceso.Start()
        ' Esperar a que el proceso termine
        proceso.WaitForExit()

    End Sub

    'Generando Archivo Ctl
    'Procedimiento

    Public Function GenerarArchivoCtl(Obj As Validador)

        Dim numCar As Long
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            ' Obtener el nuevo número de carga
            conexionOracle.Open()

            ' Insertar la nueva carga
            Dim Comando As New OracleCommand("SYSTEM.dvl_create_ctl_empleadores", conexionOracle)
            Comando.CommandType = CommandType.StoredProcedure

            Comando.Parameters.Add(New OracleParameter("pi_num_tipval", OracleDbType.Int64)).Value = 1 'aqui se relaciona con el otro procedure
            Comando.Parameters.Add(New OracleParameter("pi_vc2_nomarch", OracleDbType.NVarchar2)).Value = vc2_directorio_ctl & vc2_carga_empleadores
            Comando.Parameters.Add(New OracleParameter("pi_nom_tables", OracleDbType.NVarchar2)).Value = "FOMEMPL_" & pi_num_codcar


            Comando.Parameters.Add(New OracleParameter("po_vc2_coderr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output
            Comando.Parameters.Add(New OracleParameter("po_vc2_deserr", OracleDbType.NVarchar2)).Direction = ParameterDirection.Output


            Comando.ExecuteNonQuery()

            conexionOracle.Close()
            ' End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return numCar

    End Function

    Sub thecomand()

        Dim the_command As String

        'vc2_directorio_ctl=c:\CARGA_EMPRESAS\ARCHIVOS_CTL\
        'vc2_carga_empleadores = "carga_empleadores" & pi_num_codcar & ".ctl"
        'es un ejemplo c:\CARGA_EMPRESAS\ARCHIVOS_CTL\carga_empleadores501545.ctl


        'pi_vc2_arccar_empleador = el directorio de empleador

        'vc2_archivo_log = vc2_directorio_log & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".log"
        'c:\CARGA_EMPRESAS\LOG\

        'vc2_archivo_bad = vc2_directorio_discard & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".dis"

        'vc2_archivo_discard = vc2_directorio_bad & "EMPLEADORES_" & Format(Now, "yyyyMMdd_HHmmss") & "_CARGA_NRO_" & pi_num_codcar & ".bad"

        the_command = "sqlldr control=" & vc2_directorio_ctl & vc2_carga_empleadores & " data=" & pi_vc2_arccar_empleador & " log=" & vc2_archivo_log & " BAD=" & vc2_archivo_bad & " DISCARD=" & vc2_archivo_discard & " userid=" & vc2_username & "/" & vc2_password & "@" & vc2_connect & " errors=9999999 direct=TRUE DISCARDMAX=9999999;"


    End Sub


End Class
