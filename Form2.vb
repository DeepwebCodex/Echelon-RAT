Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TextBox1.Text &= "   Ich:" & vbNewLine & TextBox2.Text & vbNewLine
        Form1.Client.Senden("Chat MSG#++#" & TextBox2.Text)
        TextBox2.Clear()
      
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox1.Text &= "   Ich:" & vbNewLine & TextBox2.Text & vbNewLine
            Form1.Client.Senden("Chat MSG#++#" & TextBox2.Text)
            TextBox2.Clear()
        End If
    End Sub

    Private Sub Form2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TextBox1.Width = Me.Width - 20
        TextBox2.Width = Me.Width - 110
        Button1.Location = New Point(Me.Width - 90, Me.Height - 58)
        TextBox2.Location = New Point(3, Me.Height - 56)
        TextBox1.Height = Me.Height - 66
    End Sub
End Class