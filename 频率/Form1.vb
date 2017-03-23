Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Int32 = 66
        For i = 1 To 7
            TextBox1.Text &= "Case " & 10 * i + 1 & vbCrLf & "Return " & a * 2 ^ (i - 1) & vbCrLf
            TextBox1.Text &= "Case " & 10 * i + 2 & vbCrLf & "Return " & a * 2 ^ (i - 1) * 9 / 8 & vbCrLf
            TextBox1.Text &= "Case " & 10 * i + 3 & vbCrLf & "Return " & a * 2 ^ (i - 1) * 5 / 4 & vbCrLf
            TextBox1.Text &= "Case " & 10 * i + 4 & vbCrLf & "Return " & a * 2 ^ (i - 1) * 4 / 3 & vbCrLf
            TextBox1.Text &= "Case " & 10 * i + 5 & vbCrLf & "Return " & a * 2 ^ (i - 1) * 3 / 2 & vbCrLf
            TextBox1.Text &= "Case " & 10 * i + 6 & vbCrLf & "Return " & a * 2 ^ (i - 1) * 5 / 3 & vbCrLf
            TextBox1.Text &= "Case " & 10 * i + 7 & vbCrLf & "Return " & a * 2 ^ (i - 1) * 15 / 8 & vbCrLf
        Next
    End Sub
End Class
