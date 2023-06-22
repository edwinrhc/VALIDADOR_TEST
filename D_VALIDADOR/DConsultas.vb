Option Explicit On
Imports System.IO
Imports System.Windows.Forms
Imports E_VALIDADOR

Imports Oracle.ManagedDataAccess.Client

Public Class DConsultas


#Region "Reporte"

    'Public Function EjecutarProcedimientoAlmacenadoYConsulta(Obj As Validador) As DataTable
    '    Try
    '        Dim miConexion As New Conexion()
    '        Dim conexionOracle As OracleConnection = miConexion.conn

    '        ' Ejecutar el procedimiento almacenado
    '        Dim procedimiento As String = "VALIDADOR_TEST.SP_TRAB_CASUISTICA"
    '        Dim comandoProcedimiento As New OracleCommand(procedimiento, conexionOracle)
    '        comandoProcedimiento.CommandType = CommandType.StoredProcedure
    '        comandoProcedimiento.Parameters.Add("pi_grupo", OracleDbType.Int32).Value = Obj.Po_Num_NUMCAR

    '        comandoProcedimiento.ExecuteNonQuery()

    '        ' Obtener el valor de numCar necesario para la consulta
    '        Dim numCar As Long = Obj.Po_Num_NUMCAR

    '        ' Realizar la consulta con el método ObsDatosPersonales
    '        Dim datosPersonales As DataTable = ObsDatosPersonales(numCar)

    '        ' Hacer uso de los datos obtenidos
    '        ' ...
    '        ' Aquí puedes realizar las operaciones necesarias con la DataTable 'datosPersonales'

    '    Catch ex As OracleException
    '        Throw New Exception("Error al ejecutar el procedimiento almacenado y realizar la consulta: " + ex.Message)
    '    End Try
    'End Function




    'Public Function ObsDatosPersonales(Valor As Long) As DataTable
    '    Dim dtResultado As New DataTable()
    '    Try
    '        Dim miConexion As New Conexion()
    '        Dim conexionOracle As OracleConnection = miConexion.conn
    '        Dim sql As String = "SELECT * FROM VALIDADOR_TEST.TRAB_OBSERVADOS_CASUISTICA  WHERE  NROCARGA  = :numCar"
    '        Dim comando As New OracleCommand(sql, conexionOracle)
    '        comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor

    '        Dim adaptador As New OracleDataAdapter(comando)
    '        adaptador.Fill(dtResultado)
    '    Catch ex As OracleException
    '        Throw New Exception("Error al buscar el registro: " + ex.Message)
    '    End Try
    '    Return dtResultado
    'End Function

    Public Function ObsDatosPersonales(Valor As Long) As DataTable
        Dim dtResultado As New DataTable()
        Dim miConexion As New Conexion()
        Dim conexionOracle As OracleConnection = miConexion.conn
        Try

            ' Abrir la conexión a la base de datos
            conexionOracle.Open()

            ' Ejecutar el procedimiento almacenado
            Dim procedimiento As String = "VALIDADOR_TEST.SP_TRAB_CASUISTICA"
            Dim comandoProcedimiento As New OracleCommand(procedimiento, conexionOracle)
            comandoProcedimiento.CommandType = CommandType.StoredProcedure
            comandoProcedimiento.Parameters.Add("pi_grupo", OracleDbType.Int32).Value = Valor

            comandoProcedimiento.ExecuteNonQuery()

            Dim sql As String = "SELECT NROCARGA, CASUISTICA, TIPDOC, NRODOC, APEPATERNO, APEMATERNO, NOMBRES, FECNAC, TIPDOCRENIEC, NRODOCRENIEC, APEPATERNORENIEC, APEMATERNORENIEC, NOMBRESRENIEC, FECNACRENIEC FROM VALIDADOR_TEST.TRAB_OBSERVADOS_CASUISTICA WHERE NROCARGA = :numCar"
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor

            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        Finally
            ' Cerrar la conexión a la base de datos
            conexionOracle.Close()
        End Try
        Return dtResultado
    End Function



#End Region

#Region "Observación de Carga Empleador"

    Public Function ObsCargaEmpleador(Valor As Long) As DataTable
        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
                SELECT
                  (
                  SELECT pd.c_descri FROM validador_test.fodtita@DBL_QA pd WHERE pd.n_coddom = 1 AND pd.c_coddet=a.c_codtit 
                  ) c_codtit,
                  a.c_numdot,
                  a.c_apepat,
                  a.c_apemat,
                  a.c_nombrt,
                  a.f_nacimiento,
                  a.Anio,
                  a.Mes,
                  a.tipo,
                  a.c_detreg,
                  a.c_deterr,
                  a.n_numcar,     
                ROW_NUMBER() OVER (ORDER BY
                a.c_numdot,
                  a.c_apepat,
                  a.c_apemat,
                  a.c_nombrt,
                  a.Anio,
                  a.Mes,
                  a.tipo,
                  a.c_detreg,
                  a.c_deterr,
                  a.n_numcar
                ) rn

                FROM
                (
                  SELECT                 
              NULL c_codtit, NULL c_numdot, NULL c_apepat, NULL c_apemat,NULL c_nombrt, NULL f_nacimiento, NULL Anio, NULL Mes,
              '1. EMPLEADORES' tipo,
                  LPAD(NVL(c_codtie,' '),2,' ')||
                  LPAD(NVL(c_numdoc,' '),15,' ')||
                  LPAD(NVL(c_codsed,' '),19,'0')||
                  LPAD(NVL(c_tipint,' '),2,' ')||
                  LPAD(NVL(c_razsoe,' '),100,' ')||
                  LPAD(NVL(c_dessed,' '),100,' ')||
                  LPAD(NVL(c_tidofo,' '),2,' ')||
                  LPAD(NVL(c_nudore,' '),15,' ')||
                  LPAD(NVL(c_noapre,' '),100,' ')||
                  LPAD(NVL(c_cocare,' '),2,' ')||
                  LPAD(NVL(c_correp,' '),100,' ')||
                  LPAD(NVL(c_telrep,' '),20,' ')||
                  LPAD(NVL(c_tdoal1,' '),2,' ')||
                  LPAD(NVL(c_nuale1,' '),15,' ')||
                  LPAD(NVL(c_tdoal2,' '),2,' ')||
                  LPAD(NVL(c_nuale2,' '),15,' ') c_detreg,
                  DEE.C_DESCRI c_deterr,
                  n_numcar
                  FROM VALIDADOR_TEST.fomempl_ERR_HIST@DBL_QA  ERR,
                  VALIDADOR_TEST.foddeer_HIST@DBL_QA  DEE
                  WHERE DEE.N_CORREL_EMPL=ERR.N_CORREL
                
                  UNION ALL

                  SELECT
            c_codtit, c_numdot, c_apepat, c_apemat, c_nombrt,c_fecnac f_nacimiento, NULL Anio, NULL Mes,
                  '2. TRABAJADORES' tipo,
                  LPAD(NVL(c_codtie,' '),2,' ')||
                  LPAD(NVL(c_numdoe,' '),15,' ')||
                  LPAD(NVL(c_codsed,' '),19,'0')||
                  LPAD(NVL(c_codtit,' '),2,' ')||
                  LPAD(NVL(c_numdot,' '),15,' ')||
                  LPAD(NVL(c_apepat,' '),100,' ')||
                  LPAD(NVL(c_apemat,' '),100,' ')||
                  LPAD(NVL(c_nombrt,' '),100,' ')||
                  LPAD(NVL(c_nuseau,' '),30,' ')||
                  LPAD(NVL(c_tdoal1,' '),2,' ')||
                  LPAD(NVL(c_nuale1,' '),15,' ')||
                  LPAD(NVL(c_tdoal2,' '),2,' ')||
                  LPAD(NVL(c_nuale2,' '),15,' ')||
                  LPAD(NVL((c_fecnac),' '),10,' ')||
                  LPAD(NVL(c_codtri,' '),15,'0') c_detreg,
                  DEE.C_DESCRI c_deterr,
                  n_numcar
                  FROM VALIDADOR_TEST.fodtrem_err_HIST@DBL_QA  ERR
                  ,VALIDADOR_TEST.foddeer_HIST@DBL_QA  DEE
                  WHERE DEE.N_CORREL_TRA =ERR.N_CORREL

                  UNION ALL
                  SELECT
                  tra.c_codtit, tra.c_numdot, tra.c_apepat, tra.c_apemat, tra.c_nombrt, tra.c_fecnac f_nacimiento,
                  SUBSTR(err.c_fecipa,7,4) Anio, SUBSTR(err.c_fecipa,4,2) Mes,    

                  '3. REMUNERACIONES' tipo,
                  LPAD(NVL(ERR.c_codtie,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdoe,' '),15,' ')||
                  LPAD(NVL(ERR.c_codsed,' '),19,' ')||
                  LPAD(NVL(ERR.c_codtit,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdot,' '),15,' ')||
                  LPAD(NVL(ERR.c_fecipa,' '),10,' ')||
                  LPAD(NVL(ERR.c_fecfpa,' '),10,' ')||
                  LPAD(NVL(ERR.c_codttr,' '),2,' ')||
                  LPAD(NVL(ERR.c_codpir,' '),2,' ')||
                  LPAD(NVL(ERR.c_tipmon,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarem,' '),15,'0')||
                  LPAD(NVL(ERR.c_tipseg,' '),2,' ')||
                  LPAD(NVL(ERR.c_moapse,' '),15,'0')||
                  LPAD(NVL(ERR.c_tirepe,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarpe,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapft,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapfe,' '),15,'0') c_detreg,
                  DEE.C_DESCRI c_deterr,
                  ERR.n_numcar
                  FROM VALIDADOR_TEST.fodretr_err_HIST@DBL_QA  ERR
                  INNER JOIN VALIDADOR_TEST.foddeer_HIST@DBL_QA DEE    ON DEE.N_CORREL_REMU =ERR.N_CORREL
                  LEFT  JOIN VALIDADOR_TEST.fodtrem_val_hist@DBL_QA TRA ON TRA.c_codtie = ERR.c_codtie
                  AND tra.c_numdoe = err.c_numdoe AND NVL(tra.c_codsed,'*') = NVL(err.c_codsed,'*')
                  AND tra.c_codtit = err.c_codtit AND tra.c_numdot = err.c_numdot AND tra.n_numcar = err.n_numcar           

                  UNION ALL

                  SELECT
                  tra.c_codtit, tra.c_numdot, tra.c_apepat, tra.c_apemat, tra.c_nombrt, tra.c_fecnac f_nacimiento,
              SUBSTR(err.c_fecipa,7,4) Anio, SUBSTR(err.c_fecipa,4,2) Mes,

                  '4. REMUNERACIONES DUPLICADOS' tipo,
                  LPAD(NVL(ERR.c_codtie,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdoe,' '),15,' ')||
                  LPAD(NVL(ERR.c_codsed,' '),19,' ')||
                  LPAD(NVL(ERR.c_codtit,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdot,' '),15,' ')||
                  LPAD(NVL(ERR.c_fecipa,' '),10,' ')||
                  LPAD(NVL(ERR.c_fecfpa,' '),10,' ')||
                  LPAD(NVL(ERR.c_codttr,' '),2,' ')||
                  LPAD(NVL(ERR.c_codpir,' '),2,' ')||
                  LPAD(NVL(ERR.c_tipmon,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarem,' '),15,'0')||
                  LPAD(NVL(ERR.c_tipseg,' '),2,' ')||
                  LPAD(NVL(ERR.c_moapse,' '),15,'0')||
                  LPAD(NVL(ERR.c_tirepe,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarpe,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapft,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapfe,' '),15,'0')  c_detreg,
                  ERR.c_deterr,
                  ERR.n_numcar

                  FROM VALIDADOR_TEST.fodretr_dup_HIST@DBL_QA ERR
                  LEFT  JOIN VALIDADOR_TEST.fodtrem_val_hist@DBL_QA TRA ON TRA.c_codtie = ERR.c_codtie
                  AND tra.c_numdoe = err.c_numdoe AND NVL(tra.c_codsed,'*') = NVL(err.c_codsed,'*')
                  AND tra.c_codtit = err.c_codtit AND tra.c_numdot = err.c_numdot AND tra.n_numcar = err.n_numcar
                 
                  UNION ALL
                  SELECT
                  c_codtit, c_numdot, c_apepat, c_apemat, c_nombrt,c_fecnac f_nacimiento, NULL Anio, NULL Mes,
                  '5. TRABAJADORES INTEGRIDAD' tipo,
                  c_codtie||
                  c_numdoe||
                  c_codsed||
                  c_codtit||
                  c_numdot||
                  c_apepat||
                  c_apemat||
                  c_nombrt||
                  c_nuseau||
                  c_tdoal1||
                  c_nuale1||
                  c_tdoal2||
                  c_nuale2||
                  c_fecnac||
                  c_codtri c_detreg,
                  c_deterr,
                  n_numcar
                  FROM validador_test.fodtrem_INT_HIST@DBL_QA  

                  UNION ALL
                  SELECT
            tra.c_codtit, tra.c_numdot, tra.c_apepat, tra.c_apemat, tra.c_nombrt,tra.c_fecnac f_nacimiento,
              SUBSTR(err.c_fecipa,7,4) Anio, SUBSTR(err.c_fecipa,4,2) Mes,
                  '6. REMUNERACIONES INTEGRIDAD' tipo,
                  LPAD(NVL(ERR.c_codtie,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdoe,' '),15,' ')||
                  LPAD(NVL(ERR.c_codsed,' '),19,' ')||
                  LPAD(NVL(ERR.c_codtit,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdot,' '),15,' ')||
                  LPAD(NVL(ERR.c_fecipa,' '),10,' ')||
                  LPAD(NVL(ERR.c_fecfpa,' '),10,' ')||
                  LPAD(NVL(ERR.c_codttr,' '),2,' ')||
                  LPAD(NVL(ERR.c_codpir,' '),2,' ')||
                  LPAD(NVL(ERR.c_tipmon,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarem,' '),15,'0')||
                  LPAD(NVL(ERR.c_tipseg,' '),2,' ')||
                  LPAD(NVL(ERR.c_moapse,' '),15,'0')||
                  LPAD(NVL(ERR.c_tirepe,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarpe,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapft,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapfe,' '),15,'0')  c_detreg,
                  ERR.c_deterr,
                  ERR.n_numcar
                  FROM validador_test.fodretr_int_HIST@DBL_QA ERR 
                  LEFT  JOIN VALIDADOR_TEST.fodtrem_val_hist@DBL_QA TRA ON TRA.c_codtie = ERR.c_codtie
                  AND tra.c_numdoe = err.c_numdoe AND NVL(tra.c_codsed,'*') = NVL(err.c_codsed,'*')
                  AND tra.c_codtit = err.c_codtit AND tra.c_numdot = err.c_numdot AND tra.n_numcar = err.n_numcar
                  ORDER BY 1
              
                    ) a
                        WHERE a.n_numcar=:numCar

            "
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

    Public Function TotalObsCargaEmpleador(Valor As Long) As DataTable
        Dim dtResultado As New DataTable()
        Try
            Dim miConexion As New Conexion()
            Dim conexionOracle As OracleConnection = miConexion.conn
            Dim sql As String = "
SELECT COUNT(*) AS total_rows
FROM (

    SELECT 
      (
      SELECT pd.c_descri FROM validador_test.fodtita@DBL_QA pd WHERE pd.n_coddom = 1 AND pd.c_coddet=a.c_codtit 
      ) c_codtit,
      a.c_numdot,
      a.c_apepat,
      a.c_apemat,
      a.c_nombrt,
      a.f_nacimiento,
      a.Anio,
      a.Mes,
      a.tipo,
      a.c_detreg,
      a.c_deterr,
      a.n_numcar,     
    ROW_NUMBER() OVER (ORDER BY
    a.c_numdot,
      a.c_apepat,
      a.c_apemat,
      a.c_nombrt,
      a.Anio,
      a.Mes,
      a.tipo,
      a.c_detreg,
      a.c_deterr,
      a.n_numcar
    ) rn

    FROM
    (
                  SELECT                 
              NULL c_codtit, NULL c_numdot, NULL c_apepat, NULL c_apemat,NULL c_nombrt, NULL f_nacimiento, NULL Anio, NULL Mes,
              '1. EMPLEADORES' tipo,
                  LPAD(NVL(c_codtie,' '),2,' ')||
                  LPAD(NVL(c_numdoc,' '),15,' ')||
                  LPAD(NVL(c_codsed,' '),19,'0')||
                  LPAD(NVL(c_tipint,' '),2,' ')||
                  LPAD(NVL(c_razsoe,' '),100,' ')||
                  LPAD(NVL(c_dessed,' '),100,' ')||
                  LPAD(NVL(c_tidofo,' '),2,' ')||
                  LPAD(NVL(c_nudore,' '),15,' ')||
                  LPAD(NVL(c_noapre,' '),100,' ')||
                  LPAD(NVL(c_cocare,' '),2,' ')||
                  LPAD(NVL(c_correp,' '),100,' ')||
                  LPAD(NVL(c_telrep,' '),20,' ')||
                  LPAD(NVL(c_tdoal1,' '),2,' ')||
                  LPAD(NVL(c_nuale1,' '),15,' ')||
                  LPAD(NVL(c_tdoal2,' '),2,' ')||
                  LPAD(NVL(c_nuale2,' '),15,' ') c_detreg,
                  DEE.C_DESCRI c_deterr,
                  n_numcar
                  FROM VALIDADOR_TEST.fomempl_ERR_HIST@DBL_QA  ERR,
                  VALIDADOR_TEST.foddeer_HIST@DBL_QA  DEE
                  WHERE DEE.N_CORREL_EMPL=ERR.N_CORREL
                
                  UNION ALL

                  SELECT
            c_codtit, c_numdot, c_apepat, c_apemat, c_nombrt,c_fecnac f_nacimiento, NULL Anio, NULL Mes,
                  '2. TRABAJADORES' tipo,
                  LPAD(NVL(c_codtie,' '),2,' ')||
                  LPAD(NVL(c_numdoe,' '),15,' ')||
                  LPAD(NVL(c_codsed,' '),19,'0')||
                  LPAD(NVL(c_codtit,' '),2,' ')||
                  LPAD(NVL(c_numdot,' '),15,' ')||
                  LPAD(NVL(c_apepat,' '),100,' ')||
                  LPAD(NVL(c_apemat,' '),100,' ')||
                  LPAD(NVL(c_nombrt,' '),100,' ')||
                  LPAD(NVL(c_nuseau,' '),30,' ')||
                  LPAD(NVL(c_tdoal1,' '),2,' ')||
                  LPAD(NVL(c_nuale1,' '),15,' ')||
                  LPAD(NVL(c_tdoal2,' '),2,' ')||
                  LPAD(NVL(c_nuale2,' '),15,' ')||
                  LPAD(NVL((c_fecnac),' '),10,' ')||
                  LPAD(NVL(c_codtri,' '),15,'0') c_detreg,
                  DEE.C_DESCRI c_deterr,
                  n_numcar
                  FROM VALIDADOR_TEST.fodtrem_err_HIST@DBL_QA  ERR
                  ,VALIDADOR_TEST.foddeer_HIST@DBL_QA  DEE
                  WHERE DEE.N_CORREL_TRA =ERR.N_CORREL

                  UNION ALL
                  SELECT
                  tra.c_codtit, tra.c_numdot, tra.c_apepat, tra.c_apemat, tra.c_nombrt, tra.c_fecnac f_nacimiento,
                  SUBSTR(err.c_fecipa,7,4) Anio, SUBSTR(err.c_fecipa,4,2) Mes,    

                  '3. REMUNERACIONES' tipo,
                  LPAD(NVL(ERR.c_codtie,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdoe,' '),15,' ')||
                  LPAD(NVL(ERR.c_codsed,' '),19,' ')||
                  LPAD(NVL(ERR.c_codtit,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdot,' '),15,' ')||
                  LPAD(NVL(ERR.c_fecipa,' '),10,' ')||
                  LPAD(NVL(ERR.c_fecfpa,' '),10,' ')||
                  LPAD(NVL(ERR.c_codttr,' '),2,' ')||
                  LPAD(NVL(ERR.c_codpir,' '),2,' ')||
                  LPAD(NVL(ERR.c_tipmon,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarem,' '),15,'0')||
                  LPAD(NVL(ERR.c_tipseg,' '),2,' ')||
                  LPAD(NVL(ERR.c_moapse,' '),15,'0')||
                  LPAD(NVL(ERR.c_tirepe,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarpe,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapft,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapfe,' '),15,'0') c_detreg,
                  DEE.C_DESCRI c_deterr,
                  ERR.n_numcar
                  FROM VALIDADOR_TEST.fodretr_err_HIST@DBL_QA  ERR
                  INNER JOIN VALIDADOR_TEST.foddeer_HIST@DBL_QA DEE    ON DEE.N_CORREL_REMU =ERR.N_CORREL
                  LEFT  JOIN VALIDADOR_TEST.fodtrem_val_hist@DBL_QA TRA ON TRA.c_codtie = ERR.c_codtie
                  AND tra.c_numdoe = err.c_numdoe AND NVL(tra.c_codsed,'*') = NVL(err.c_codsed,'*')
                  AND tra.c_codtit = err.c_codtit AND tra.c_numdot = err.c_numdot AND tra.n_numcar = err.n_numcar           

                  UNION ALL

                  SELECT
                  tra.c_codtit, tra.c_numdot, tra.c_apepat, tra.c_apemat, tra.c_nombrt, tra.c_fecnac f_nacimiento,
              SUBSTR(err.c_fecipa,7,4) Anio, SUBSTR(err.c_fecipa,4,2) Mes,

                  '4. REMUNERACIONES DUPLICADOS' tipo,
                  LPAD(NVL(ERR.c_codtie,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdoe,' '),15,' ')||
                  LPAD(NVL(ERR.c_codsed,' '),19,' ')||
                  LPAD(NVL(ERR.c_codtit,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdot,' '),15,' ')||
                  LPAD(NVL(ERR.c_fecipa,' '),10,' ')||
                  LPAD(NVL(ERR.c_fecfpa,' '),10,' ')||
                  LPAD(NVL(ERR.c_codttr,' '),2,' ')||
                  LPAD(NVL(ERR.c_codpir,' '),2,' ')||
                  LPAD(NVL(ERR.c_tipmon,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarem,' '),15,'0')||
                  LPAD(NVL(ERR.c_tipseg,' '),2,' ')||
                  LPAD(NVL(ERR.c_moapse,' '),15,'0')||
                  LPAD(NVL(ERR.c_tirepe,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarpe,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapft,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapfe,' '),15,'0')  c_detreg,
                  ERR.c_deterr,
                  ERR.n_numcar

                  FROM VALIDADOR_TEST.fodretr_dup_HIST@DBL_QA ERR
                  LEFT  JOIN VALIDADOR_TEST.fodtrem_val_hist@DBL_QA TRA ON TRA.c_codtie = ERR.c_codtie
                  AND tra.c_numdoe = err.c_numdoe AND NVL(tra.c_codsed,'*') = NVL(err.c_codsed,'*')
                  AND tra.c_codtit = err.c_codtit AND tra.c_numdot = err.c_numdot AND tra.n_numcar = err.n_numcar
                 
                  UNION ALL
                  SELECT
                  c_codtit, c_numdot, c_apepat, c_apemat, c_nombrt,c_fecnac f_nacimiento, NULL Anio, NULL Mes,
                  '5. TRABAJADORES INTEGRIDAD' tipo,
                  c_codtie||
                  c_numdoe||
                  c_codsed||
                  c_codtit||
                  c_numdot||
                  c_apepat||
                  c_apemat||
                  c_nombrt||
                  c_nuseau||
                  c_tdoal1||
                  c_nuale1||
                  c_tdoal2||
                  c_nuale2||
                  c_fecnac||
                  c_codtri c_detreg,
                  c_deterr,
                  n_numcar
                  FROM validador_test.fodtrem_INT_HIST@DBL_QA  

                  UNION ALL
                  SELECT
            tra.c_codtit, tra.c_numdot, tra.c_apepat, tra.c_apemat, tra.c_nombrt,tra.c_fecnac f_nacimiento,
              SUBSTR(err.c_fecipa,7,4) Anio, SUBSTR(err.c_fecipa,4,2) Mes,
                  '6. REMUNERACIONES INTEGRIDAD' tipo,
                  LPAD(NVL(ERR.c_codtie,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdoe,' '),15,' ')||
                  LPAD(NVL(ERR.c_codsed,' '),19,' ')||
                  LPAD(NVL(ERR.c_codtit,' '),2,' ')||
                  LPAD(NVL(ERR.c_numdot,' '),15,' ')||
                  LPAD(NVL(ERR.c_fecipa,' '),10,' ')||
                  LPAD(NVL(ERR.c_fecfpa,' '),10,' ')||
                  LPAD(NVL(ERR.c_codttr,' '),2,' ')||
                  LPAD(NVL(ERR.c_codpir,' '),2,' ')||
                  LPAD(NVL(ERR.c_tipmon,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarem,' '),15,'0')||
                  LPAD(NVL(ERR.c_tipseg,' '),2,' ')||
                  LPAD(NVL(ERR.c_moapse,' '),15,'0')||
                  LPAD(NVL(ERR.c_tirepe,' '),2,' ')||
                  LPAD(NVL(ERR.c_moarpe,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapft,' '),15,'0')||
                  LPAD(NVL(ERR.c_moapfe,' '),15,'0')  c_detreg,
                  ERR.c_deterr,
                  ERR.n_numcar
                  FROM validador_test.fodretr_int_HIST@DBL_QA ERR 
                  LEFT  JOIN VALIDADOR_TEST.fodtrem_val_hist@DBL_QA TRA ON TRA.c_codtie = ERR.c_codtie
                  AND tra.c_numdoe = err.c_numdoe AND NVL(tra.c_codsed,'*') = NVL(err.c_codsed,'*')
                  AND tra.c_codtit = err.c_codtit AND tra.c_numdot = err.c_numdot AND tra.n_numcar = err.n_numcar
                  ORDER BY 1
              
              ) a
              WHERE a.n_numcar = :numCar
            ) subquery"
            Dim comando As New OracleCommand(sql, conexionOracle)
            comando.Parameters.Add("numCar", OracleDbType.Int64).Value = Valor

            Dim adaptador As New OracleDataAdapter(comando)
            adaptador.Fill(dtResultado)
        Catch ex As OracleException
            Throw New Exception("Error al buscar el registro: " + ex.Message)
        End Try
        Return dtResultado
    End Function

End Class
