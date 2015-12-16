Imports System.Data.OleDb

Module Module1
    Public ConnString As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=100CristianosDijeron.accdb;Persist Security Info=False;")
    Public OleDBConn As New OleDbConnection(ConnString)
    
    Public PreguntaPublica As String
    Public PuntajeA As Integer = 0
    Public PuntajeB As Integer = 0
    Public r1 As Integer = 0, r2 As Integer = 0, r3 As Integer = 0, r4 As Integer = 0, r5 As Integer = 0

    Public Function ObtenerPregunta(ByVal Tabla As String, ByVal PreguntaId As String) As String
        Dim respuesta As String = String.Format("SELECT Descripcion FROM {0} WHERE PreguntaId={1}", Tabla, PreguntaId)
        Dim cmd As New OleDbCommand(respuesta, OleDBConn)
        OleDBConn.Open()
        Dim pregunta As String = cmd.ExecuteScalar
        OleDBConn.Close()                                                   'Cerrar la conexión
        Return pregunta
    End Function

    Public Sub ConsultarRespuestas(ByVal Tabla As String, ByVal PreguntaId As Integer, ByVal Grid As DataGridView)
        Try
            Dim OleDBCmd As New OleDbCommand()
            Dim OleDBdr As OleDbDataReader
            Dim SQLStr As String = String.Format("SELECT RespuestaId as Respuesta,Descripcion, Puntaje FROM {0} WHERE PreguntaId={1}", Tabla, PreguntaId)

            OleDBConn.Open()
            OleDBCmd.Connection = OleDBConn
            OleDBCmd.CommandText = SQLStr
            OleDBdr = OleDBCmd.ExecuteReader

            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter(SQLStr, OleDBConn)

            da.Fill(ds, Tabla)
            Grid.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            OleDBConn.Close()
        End Try
    End Sub

    Public Function RRandom(ByVal Rango As Integer) As Integer
        Randomize()
        Dim value As Integer = CInt(Int((Rango * Rnd()) + 1))

        Return value
    End Function

    Public Sub ValidarNumero(e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Function DatoGrid(ByVal fila As Integer, ByVal datos As DataGridViewRow) As Integer
        Dim puntos As Integer

        Try
            Select Case fila
                Case 0
                    If (r1 = 1) Then Exit Select
                    Form2.r1.Text = CStr(datos.Cells(1).Value)
                    Form2.p1.Text = CStr(datos.Cells(2).Value)
                    puntos = CStr(datos.Cells(2).Value)
                    r1 = 1
                Case 1
                    If (r2 = 1) Then Exit Select
                    Form2.r2.Text = CStr(datos.Cells(1).Value)
                    Form2.p2.Text = CStr(datos.Cells(2).Value)
                    puntos = CStr(datos.Cells(2).Value)
                    r2 = 1
                Case 2
                    If (r3 = 1) Then Exit Select
                    Form2.r3.Text = CStr(datos.Cells(1).Value)
                    Form2.p3.Text = CStr(datos.Cells(2).Value)
                    puntos = CStr(datos.Cells(2).Value)
                    r3 = 1
                Case 3
                    If (r4 = 1) Then Exit Select
                    Form2.r4.Text = CStr(datos.Cells(1).Value)
                    Form2.p4.Text = CStr(datos.Cells(2).Value)
                    puntos = CStr(datos.Cells(2).Value)
                    r4 = 1
                Case 4
                    If (r5 = 1) Then Exit Select
                    Form2.r5.Text = CStr(datos.Cells(1).Value)
                    Form2.p5.Text = CStr(datos.Cells(2).Value)
                    puntos = CStr(datos.Cells(2).Value)
                    r5 = 1
                Case Else
                    Exit Select
            End Select
        Catch ex As Exception
            Return 0
        End Try

        Return puntos
    End Function
End Module
