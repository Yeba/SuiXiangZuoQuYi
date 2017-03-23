Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ss As String = ""
        For i = 0 To TextBox1.Text.Length - 4

        Next
        My.Computer.FileSystem.WriteAllText("C:\Users\liuyj\Desktop\unity.漾音乐", ss, False)
    End Sub

    'unity
    'Dim ch As Char = TextBox1.Text.Substring(i, 1)
    'If ch = " " Then ss &= Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) : Continue For
    'If IsNumeric(ch) Then '↑
    'If TextBox1.Text.Substring(i + 1, 3) = "↑↑↑" Then
    '                ss &= Chr(127) & Chr(60 + Val(ch)) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100)
    '                i += 3
    '                Continue For
    'ElseIf TextBox1.Text.Substring(i + 1, 2) = "↑↑" Then
    '                i += 2
    '                ss &= Chr(127) & Chr(50 + Val(ch)) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100)
    '                Continue For
    'ElseIf TextBox1.Text.Substring(i + 1, 1) = "↑" Then
    '                i += 1
    '                ss &= Chr(127) & Chr(40 + Val(ch)) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100) & Chr(100)
    '                Continue For
    'End If
    'Else
    'Continue For
    'End If


    '版本-欢乐颂
    'For i = 0 To TextBox1.Text.Length - 1
    'If TextBox1.Text.Substring(i, 1) = " " Then
    'For j = 1 To 8
    '                ss &= Chr(100)
    '            Next
    'Else
    ''5      3
    'If TextBox1.Text.Substring(i, 8) = "5      3" Then
    '                ss &= Chr(20 + Val(TextBox1.Text.Substring(i, 1)))
    '                Continue For
    'End If
    '            ss &= Chr(30 + Val(TextBox1.Text.Substring(i, 1)))
    '        End If
    'Next
End Class
