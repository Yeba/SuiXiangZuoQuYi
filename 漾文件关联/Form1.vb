Imports Microsoft.Win32

Public Class Form1
    Private path As String = Application.StartupPath


    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        ' path = "d:"
        'regname.SetValue("必应壁纸.exe", """" & pathload & "\必应壁纸.exe""")
        Dim ak As RegistryKey = Registry.ClassesRoot.OpenSubKey("", True)
        ak.CreateSubKey(".漾音乐")
        ak = Registry.ClassesRoot.OpenSubKey(".漾音乐", True)
        ak.SetValue("(默认)", """" & "漾音乐file")
        ak = Registry.ClassesRoot.OpenSubKey("", True)
        ak.CreateSubKey("漾音乐file")
        ak = Registry.ClassesRoot.OpenSubKey("漾音乐file", True)
        ak.CreateSubKey("DefaultIcon")
        ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\DefaultIcon", True)
        ak.SetValue("(默认)", """" & path & "resources\i.ico")
        ak = Registry.ClassesRoot.OpenSubKey("漾音乐file", True)
        ak.CreateSubKey("shell")
        ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\shell", True)
        ak.CreateSubKey("open")
        ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\shell\\open", True)
        ak.CreateSubKey("command")
        ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\shell\\open\\command", True)
        ak.SetValue("(默认)", """" & path & "随想作曲仪.exe %1")
        MsgBox("关联成功！")

    End Sub

    Private Sub b2_Click(sender As Object, e As EventArgs) Handles b2.Click
        Dim ak As RegistryKey = Registry.ClassesRoot.OpenSubKey("", True)
        ak.DeleteSubKeyTree(".漾乐")
        ak.DeleteSubKeyTree("漾乐file")
        MsgBox("解关联成功！")
    End Sub
End Class
