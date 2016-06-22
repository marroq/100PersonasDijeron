Public Class Form1
    Dim countA As Integer = 0
    Dim countB As Integer = 0
    Dim EnabledA As Boolean
    Dim EnabledB As Boolean
    Dim RobarA As Boolean = False
    Dim RobarB As Boolean = False
    Dim ErrorA As Boolean = False
    Dim ErrorB As Boolean = False
    Dim second As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "") Then Exit Sub
        If (TextBox3.Text = "") Then Exit Sub
        Dim pregunta As Integer = TextBox3.Text
        Label3.Visible = True
        PreguntaPublica = ObtenerPregunta("Pregunta", pregunta)
        Label3.Text = PreguntaPublica
        Form2.Label3.Visible = True
        Form2.Label3.Text = PreguntaPublica
        ConsultarRespuestas("Respuestas", pregunta, DataGridView1)
        Button1.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Form2.Label1.Text = TextBox1.Text
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Form2.Label2.Text = TextBox2.Text
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        ValidarNumero(e)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Start()
        countA = countA + 1
        ErrorA = True
        If countA = 1 Then
            Form2.picA1.Visible = True
        ElseIf countA = 2 Then
            Form2.picA2.Visible = True
        ElseIf countA = 3 Then
            Form2.picA3.Visible = True
            Button3.Enabled = False
            ButtonA.Enabled = False
            RobarA = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer1.Start()
        countB = countB + 1
        ErrorB = True
        If countB = 1 Then
            Form2.picB1.Visible = True
        ElseIf countB = 2 Then
            Form2.picB2.Visible = True
        ElseIf countB = 3 Then
            Form2.picB3.Visible = True
            Button5.Enabled = False
            ButtonB.Enabled = False
            RobarB = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs)
        ValidarNumero(e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs)
        ValidarNumero(e)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim fila As Integer = DataGridView1.CurrentRow.Index
        Dim datos As DataGridViewRow = DataGridView1.CurrentRow

        If (EnabledA = True) Then
            If (RobarB = True) Then
                PuntajeA = PuntajeA + CInt(Form2.pB.Text)
                Form2.pB.Text = 0
            End If
            PuntajeA = PuntajeA + DatoGrid(fila, datos)
            Form2.pA.Text = PuntajeA
            ButtonB.Enabled = True
        ElseIf (EnabledB = True) Then
            If (RobarA = True) Then
                PuntajeB = PuntajeB + CInt(Form2.pA.Text)
                Form2.pA.Text = 0
            End If
            PuntajeB = PuntajeB + DatoGrid(fila, datos)
            Form2.pB.Text = PuntajeB
            ButtonA.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        countA = 0
        countB = 0
        r1 = 0
        r2 = 0
        r3 = 0
        r4 = 0
        r5 = 0
        PuntajeA = 0
        PuntajeB = 0
        Form2.r1.Text = ""
        Form2.r2.Text = ""
        Form2.r3.Text = ""
        Form2.r4.Text = ""
        Form2.r5.Text = ""
        Form2.p1.Text = ""
        Form2.p2.Text = ""
        Form2.p3.Text = ""
        Form2.p4.Text = ""
        Form2.p5.Text = ""
        Form2.pA.Text = "0"
        Form2.pB.Text = "0"
        Form2.Label1.Text = ""
        Form2.Label2.Text = ""
        Form2.Label3.Text = ""
        Label3.Text = ""
        TextBox3.Clear()
        TextBox3.Focus()
        Button3.Enabled = True
        ButtonA.Enabled = True
        Button5.Enabled = True
        ButtonB.Enabled = True
        Button1.Enabled = True
        Form2.picA1.Visible = False
        Form2.picA2.Visible = False
        Form2.picA3.Visible = False
        Form2.picB1.Visible = False
        Form2.picB2.Visible = False
        Form2.picB3.Visible = False
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub ButtonB_Click(sender As Object, e As EventArgs) Handles ButtonB.Click
        EnabledB = True
        EnabledA = False
        If countA < 3 Then ButtonA.Enabled = False
    End Sub

    Private Sub ButtonA_Click(sender As Object, e As EventArgs) Handles ButtonA.Click
        EnabledA = True
        EnabledB = False
        If countB < 3 Then ButtonB.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = false;
        second = second + 1
        If (second = 2) Then
            Form2.er1.Visible = False
            Form2.er2.Visible = False
            Form2.er3.Visible = False
            Timer1.Stop()
            second = 0
        End If

        If ErrorA = True Then
            If countA = 1 Then
                Form2.er1.Visible = True
            ElseIf countA = 2 Then
                Form2.er1.Visible = True
                Form2.er2.Visible = True
            ElseIf countA = 3 Then
                Form2.er1.Visible = True
                Form2.er2.Visible = True
                Form2.er3.Visible = True
            End If
        End If

        If ErrorB = True Then
            If countB = 1 Then
                Form2.er1.Visible = True
            ElseIf countB = 2 Then
                Form2.er1.Visible = True
                Form2.er2.Visible = True
            ElseIf countB = 3 Then
                Form2.er1.Visible = True
                Form2.er2.Visible = True
                Form2.er3.Visible = True
            End If
        End If

        ErrorA = False
        ErrorB = False
        Timer1.Enabled = true;
    End Sub
End Class
