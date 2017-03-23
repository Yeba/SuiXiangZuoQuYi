Imports System.IO
Imports System.Net
Imports System.Text
'更新无忘：版本，发布，linkdeng
Public Class Form1
    '’‘’‘’‘’‘’‘’‘版本
    Public Const vision As Single = 2.52
    '‘’‘’‘’‘’‘’‘’‘’版本
    Dim MyFileName, ss As String  '漾文件地址 ；  储存的旋律（曲子）
    Declare Function Beep Lib "kernel32" Alias "Beep" (ByVal pinglv As Int32, ByVal shijian As Int32) As Int32 '电子音api
    Dim c3 As SByte, s As SByte = 100  '3个色块运动  ； 单个音符 
    '音符规则：大字二组11-17  大字组21-27  小字组31-37  至  小字四组71-77    数字越大音调越高   电子音取负
    Dim ss_len As UInt64 = 1, ss_now As UInt64 = 1   ' ss长度 ； s现在在ss的位置
    Dim path As String = Application.StartupPath  '程序启动路径
    Dim isp As Boolean = True      'is—piano？
    Dim p As Bitmap = New Bitmap(20, 50)  '数字音符源位图
    Dim a As UInt16 '绘制界面按键大小
    Dim line1() As Char = {"Q", "W", "E", "R", "T", "Y", "U"， "I", "O", "P"}  '使用二位数组在这里不如3个一维数组方便
    Dim line2() As Char = {"A", "S", "D", "F", "G", "H", "J", "K", "L"}   '在简洁版界面使用
    Dim line3() As Char = {"Z", "X", "C", "V", "B", "N", "M"}
    Dim clic(4) As UInt16 '按下效果 0-时间 1-x 2-y 3-函数1 or 2

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load '程序打开自动加载
        pc2.Top = -500
        pc1.Top = -500
        b3.Enabled = False


        '用做 拿 *.漾音乐 文件拖拽到【随想作曲仪.exe】上时打开，不是拖拽到已打开程序,picturebox不支持拖拽 ，所以拖拽到已打开程序腹死胎中
        'clickonce 部署方法
        Try
            Dim args As String()
            args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData()
            If args.Length = 0 Then Exit Sub
            Dim ur As New Uri(args(0))
            MyFileName = ur.LocalPath
            If MyFileName.Substring(MyFileName.Length - 3, 3) = "漾音乐" = False Then MyFileName = "" : Exit Sub
            ss = My.Computer.FileSystem.ReadAllText(MyFileName)
            If ss = "" Then Exit Sub
            Text = " 随想作曲仪 - " & My.Computer.FileSystem.GetName(MyFileName) : ss_len = ss.Length : tb.Value = 1 : focu()
            b2.Text = "关闭" : b3.Text = "播放" : tb.Enabled = True : bchangeyinse.Enabled = False : ss_now = 1 : lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : Exit Sub

        Catch ex As Exception

        End Try

        '传统应用
        'Dim MyFile As String = ""  '用以保存所打开的文件路径  
        'Dim Parameters() As String  '用以保存数组参数 
        'Dim i As Integer = 0
        'Parameters = System.Environment.GetCommandLineArgs()
        'i = Parameters.GetUpperBound(0)
        'If i > 0 Then
        '    MyFileName = Parameters(1)
        '    ss = My.Computer.FileSystem.ReadAllText(MyFileName)
        '    ss_len = ss.Length
        '    tb.Enabled = True
        '    tout.Enabled = True
        '    tb.Value = 1 : focu()
        '    b2.Text = "关闭" : b3.Text = "播放" : bchangeyinse.Enabled = False : ss_now = 1 : lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : showyinse()
        'End If

    End Sub

    Private Sub ban_Click(sender As Object, e As EventArgs) Handles ban.Click 'ban（picture box）,绘制字符和主要操作区，上有26或49个音符，可鼠标点击或触屏。
        If b1.Enabled = False Then Exit Sub '文件打开状态
        Dim x As Integer = (mopo().x - ban.Left)   '点击位置
        Dim y As Integer = ban.Height - (mopo().y - ban.Top)
        If 标准版ToolStripMenuItem.Checked Then '不同界面
            s = 10 * (y \ a) + x \ a + 11
        ElseIf 简洁版ToolStripMenuItem.Checked Then
            If (y > 2 * a) Then '第1行
                key_return(Asc(line1(x \ a)))
            ElseIf (y > a And y < 2 * a) Then '第2行
                If x > a \ 2 And x < a * 9.5 Then
                    key_return(Asc(line2((x - a \ 2) \ a)))
                Else
                    Exit Sub
                End If
            ElseIf y < a Then '第3行
                If x > a And x < a * 8 Then
                    key_return(Asc(line3(x \ a - 1)))
                Else
                    Exit Sub
                End If
            End If
        ElseIf 触屏版ToolStripMenuItem.Checked Then
            s = 10 * (2 * (y \ a - 1) + （x \ a) \ 7) + （x \ a) Mod 7 + 31
        End If
        If isp = False Then s = -s  '电子音色
        plays(s)
    End Sub
    Private Sub showyinse()
        If isp Then
            lhelp.Text = vbCrLf & "目前音色：钢琴" & vbCrLf & "点击‘切换音色’按钮或敲下键盘BackSpace键都可以切换音色"
        Else
            lhelp.Text = vbCrLf & "目前音色：电子" & vbCrLf & "点击‘切换音色’按钮或敲下键盘BackSpace键都可以切换音色"
        End If
    End Sub
    Private Sub yinse() '切换音色
        If isp Then
            isp = False
            showyinse()
        Else
            isp = True
            showyinse()
        End If
        s = 100
    End Sub

    Private Function s_pl(sv As SByte)
        Select Case sv '音调转换为电子频率  详情参见高中物理选修3-4 （关于里的网页的技术部分有图片）
            Case 11  '低声区需高性能设备才能更好支持，以后需改进
                Return 66
            Case 12
                Return 74.25
            Case 13
                Return 82.5
            Case 14
                Return 88
            Case 15
                Return 99
            Case 16
                Return 110
            Case 17
                Return 123.75
            Case 21
                Return 132
            Case 22
                Return 148.5
            Case 23
                Return 165
            Case 24
                Return 176
            Case 25
                Return 198
            Case 26
                Return 220
            Case 27
                Return 247.5
            Case 31
                Return 264
            Case 32
                Return 297
            Case 33
                Return 330
            Case 34
                Return 352
            Case 35
                Return 396
            Case 36
                Return 440
            Case 37
                Return 495
            Case 41
                Return 528
            Case 42
                Return 594
            Case 43
                Return 660
            Case 44
                Return 704
            Case 45
                Return 792
            Case 46
                Return 880
            Case 47
                Return 990
            Case 51
                Return 1056
            Case 52
                Return 1188
            Case 53
                Return 1320
            Case 54
                Return 1408
            Case 55
                Return 1584
            Case 56
                Return 1760
            Case 57
                Return 1980
            Case 61
                Return 2112
            Case 62
                Return 2376
            Case 63
                Return 2640
            Case 64
                Return 2816
            Case 65
                Return 3168
            Case 66
                Return 3520
            Case 67
                Return 3960
            Case 71
                Return 4224
            Case 72
                Return 4752
            Case 73
                Return 5280
            Case 74
                Return 5632
            Case 75
                Return 6336
            Case 76
                Return 7040
            Case 77
                Return 7920
            Case Else
                Return 0
        End Select
    End Function
    Private Function key_return(k As SByte)
        Select Case k '由键盘物理顺序决定
            Case 65 '如 ascii A -> 65 -> 小字组1
                s = 31
            Case 66
                s = 25
            Case 67
                s = 23
            Case 68
                s = 33
            Case 69
                s = 45
            Case 70
                s = 34
            Case 71
                s = 35
            Case 72
                s = 36
            Case 73
                s = 53
            Case 74
                s = 37
            Case 75
                s = 41
            Case 76
                s = 42
            Case 77
                s = 27
            Case 78
                s = 26
            Case 79
                s = 54
            Case 80
                s = 55
            Case 81
                s = 43
            Case 82
                s = 46
            Case 83
                s = 32
            Case 84
                s = 47
            Case 85
                s = 52
            Case 86
                s = 24
            Case 87
                s = 44
            Case 88
                s = 22
            Case 89
                s = 51
            Case 90
                s = 21
        End Select
        Return s
    End Function
    Private Sub key_s(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If b1.Enabled = False Then Exit Sub
        If e.KeyCode = Keys.Back Then '点击键盘 backspace键切换音色
            yinse()
        End If
        Dim k As Integer = e.KeyValue
        If k < 65 Or k > 90 Then Exit Sub
        key_return(k)
        If isp = False Then s = -s
        plays(s)
    End Sub
    Private Function epic(sv As SByte, a As UInt16) As Bitmap
        Dim pp As Bitmap = New Bitmap(a, a)
        Dim gg As Graphics = Graphics.FromImage(pp)
        gg.FillRectangle(Brushes.White, 0, 0, a, a)
        cv(sv)
        gg.DrawImage(p, a \ 2 - 10, a \ 2 - 25)
        Return pp
    End Function '制造ban上的音符位图制造
    Private Function epic2(ch As Char, sv As SByte, a As UInt16) As Bitmap
        Dim pp As Bitmap = New Bitmap(a, a)
        Dim gg As Graphics = Graphics.FromImage(pp)
        gg.FillRectangle(Brushes.White, 0, 0, a, a)
        cv(sv)
        gg.DrawImage(p, CSng(a * 0.6), a \ 2 - 25)
        Dim fo As Font : Dim br As Brush = Brushes.Black
        With fo
            fo = New Font("宋体", a \ 3)
        End With
        gg.DrawString(ch, fo, Brushes.Black, CSng(a * 0.2), CSng(a * 0.2))
        Return pp
    End Function '制造ban上的音符位图制造（简洁模式，有英文字母）
    Private Sub look_biaoz()
        '界面设置
        a = 100
        GroupBox1.Top = 30 : GroupBox1.Left = 8
        ban.Left = GroupBox1.Width + 15 : ban.Top = 40 : ban.Width = 700 : ban.Height = 700
        Width = ban.Left + ban.Width + 20 : Height = ban.Height + ban.Top + 50
        'bchangeyinse.Width = GroupBox1.Width : bchangeyinse.Height = GroupBox1.Height - 10
        'bchangeyinse.Left = GroupBox1.Left : bchangeyinse.Top = ban.Top + ban.Height - bchangeyinse.Height
        'lp.Left = GroupBox1.Left : lp.Top = GroupBox1.Top - GroupBox1.Height - 15
        'lp.Width = GroupBox1.Width : lp.Height = ban.Height = GroupBox1.Height - 20
        pc1.Height = a : pc1.Width = pc1.Height
        pc2.Height = pc1.Height : pc1.Width = pc1.Height
        lhelp.Left = 5 : lhelp.Top = GroupBox1.Top + GroupBox1.Height + 10
        lhelp.Width = GroupBox1.Width : lhelp.Height = ban.Height - GroupBox1.Height - 20
        focu() ： clic(3) = 3 : lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : showyinse()
        Dim ap As Bitmap '为在ban上绘图做准备
        ap = New Bitmap(ban.Width, ban.Height)
        ban.Image = ap
        Dim ag As Graphics = Graphics.FromImage(ban.Image)
        ag.FillRectangle(Brushes.LightGray, 0, 0, ap.Width, ap.Height)

        For i = 0 To 6 '|
            For j = 0 To 6 '--
                ag.DrawImage(epic(i * 10 + j + 11, a - 8), j * a + 4, CSng(ban.Height - (i + 1) * a) + 4)
            Next
        Next

    End Sub '标准版
    Private Sub look_jian()
        '界面设置
        Dim screenx As UInt16 = Screen.PrimaryScreen.Bounds.Width.ToString
        ';  Dim screeny As UInt16 = Screen.PrimaryScreen.Bounds.Height.ToString
        '  Text = screenx & " " & screeny

        a = screenx \ 10
        GroupBox1.Top = 30 : GroupBox1.Left = 8
        ban.Left = 0 : ban.Top = GroupBox1.Top + GroupBox1.Height + 5
        ban.Width = a * 10 : ban.Height = a * 3
        Width = screenx : Height = ban.Top + ban.Height + 40
        'bchangeyinse.Height = a - 20 : bchangeyinse.Width = a * 1.8
        'bchangeyinse.Top = ban.Top + a * 2 + 20 : bchangeyinse.Left = ban.Left + a * 8 + 4
        'lp.Left = bchangeyinse.Left : lp.Top = bchangeyinse.Top - 15
        pc1.Height = a : pc1.Width = pc1.Height
        pc2.Height = pc1.Height : pc1.Width = pc1.Height
        lhelp.Left = GroupBox1.Left + GroupBox1.Width + 10 : lhelp.Top = GroupBox1.Top
        lhelp.Width = Width - GroupBox1.Width - 40 : lhelp.Height = GroupBox1.Height
        focu() ： clic(3) = 2 : lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : showyinse()
        Dim ap As Bitmap '为在ban上绘图做准备
        ap = New Bitmap(ban.Width, ban.Height)
        ban.Image = ap
        Dim ag As Graphics = Graphics.FromImage(ban.Image)
        ag.FillRectangle(Brushes.LightGray, 0, 0, ap.Width, ap.Height)
        '写字
        For i = 0 To line1.Length - 1  '第一行
            ag.DrawImage(epic2(line1(i), key_return(Asc(line1(i))), a - 4), a * i + 2, 2)
        Next
        For i = 0 To line2.Length - 1 '第二行
            ag.DrawImage(epic2(line2(i), key_return(Asc(line2(i))), a - 4), CSng(a * (i + 0.5) + 2), a + 2)
        Next
        For i = 0 To line3.Length - 1 '第三行
            ag.DrawImage(epic2(line3(i), key_return(Asc(line3(i))), a - 4), CSng(a * (i + 1) + 2), a * 2 + 2)
        Next
        '掩人耳目
        Dim br As Brush = Brushes.WhiteSmoke
        ag.FillRectangle(br, 0, CSng(a * 1.01), CSng(a * 0.49), a)
        ag.FillRectangle(br, CSng(a * 9.51), CSng(a * 1.01), CSng(a * 0.5), a)
        ag.FillRectangle(br, 0, CSng(a * 2.01), CSng(a * 0.99), a)
        ag.FillRectangle(br, CSng(a * 8.01), CSng(a * 2.01), a * 2, a)
    End Sub '简洁版

    Private Sub look_chup()
        '界面设置
        Dim screenx As UInt16 = Screen.PrimaryScreen.Bounds.Width.ToString
        '    Dim screeny As UInt16 = Screen.PrimaryScreen.Bounds.Height.ToString
        ban.Top = GroupBox1.Top + GroupBox1.Height + 5
        a = screenx \ 14
        '    bchangeyinse.Height = GroupBox1.Height : bchangeyinse.Left = a * 5 : bchangeyinse.Top = ban.Top + a * 3
        Height = ban.Top + a * 3 + 60 : Width = screenx
        ban.Left = 0 : ban.Height = a * 3 : ban.Width = a * 14
        'lp.Top = bchangeyinse.Top : lp.Left = bchangeyinse.Left + bchangeyinse.Width
        pc1.Height = a : pc1.Width = pc1.Height
        pc2.Height = pc1.Height : pc1.Width = pc1.Height
        lhelp.Left = GroupBox1.Left + GroupBox1.Width + 10 : lhelp.Top = GroupBox1.Top
        lhelp.Width = Width - GroupBox1.Width - 40 : lhelp.Height = GroupBox1.Height
        focu() ： clic(3) = 3 : lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : showyinse()
        Dim ap As Bitmap '为在ban上绘图做准备
        ap = New Bitmap(ban.Width, ban.Height)
        ban.Image = ap
        Dim ag As Graphics = Graphics.FromImage(ban.Image)
        ag.FillRectangle(Brushes.LightGray, 0, 0, ap.Width, ap.Height)

        For i = 0 To 2 '--
            For j = 0 To 13 ' |
                ag.DrawImage(epic(10 * ((2 - i) * 2 + 1 + j \ 7) + j Mod 7 + 1, a - 8), a * j + 4, a * i + 4)
            Next
        Next

    End Sub '触屏版
    Private Sub later_Tick(sender As Object, e As EventArgs) Handles later.Tick  '为避免null，在窗口加载完毕后初始化界面
        look_jian()
        later.Enabled = False
        If MyFileName = "" = False Then '从文件打开-播放文件
            b3_Click()
            Text = " 随想作曲仪 - " & My.Computer.FileSystem.GetName(MyFileName)
            tout.Enabled = True
            b1.Enabled = False : b3.Enabled = True
            focu() '焦点聚集到暂停键
            标准版ToolStripMenuItem_Click()
        End If
        If b1.Text = "取消" = False Then s = 100

        lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。"
        If (My.Computer.Info.TotalPhysicalMemory / 2 ^ 30 < 4) Then
            lhelp.Text &= vbCrLf & "提示：您的计算机内存不充足"
        End If
    End Sub
    Private Sub cv(cv As SByte) 'canvas
        Dim fo As Font : Dim br As Brush = Brushes.Black
        With fo
            fo = New Font("宋体", 15)
        End With
        Dim g As Graphics = Graphics.FromImage(p)
        g.FillRectangle(Brushes.White, 0, 0, p.Width, p.Height)
        g.DrawString(cv Mod 10, fo, br, 0, 20)
        Dim i As SByte
        If cv > 30 Then
            For i = 1 To cv \ 10 - 3
                g.FillRectangle(br, 7, (22 - i * 5), 2, 2)
            Next
        ElseIf cv < 30 Then
            For i = i To 2 - cv \ 10
                g.FillRectangle(br, 7, 40 + i * 5, 2, 2)
            Next
        End If
    End Sub '数字音符元位图

    Private Sub 生成乐谱ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 生成乐谱ToolStripMenuItem.Click
        '10*50
        If MyFileName = "" Then Exit Sub
        If ss = "" Then Exit Sub
        Dim ss_tep As UInt64 = ss_now
        Dim cout(1) As UInt64  ' 使用动态数组储存分行点
        cout(0) = 0
        Dim sum As UInt16 = 0
        For ss_now = 1 To ss_len - 1
            Select Case Asc(ss.Substring(ss_now, 1))
                Case 100
                    sum += 2
                Case 127
                    ss_now += 1 '若是电子音符加1
                    sum += 50
                Case Else
                    sum += 50
            End Select
            If sum >= 900 Then
                ReDim Preserve cout(cout.Length) '动态数组操作
                cout(cout.Length - 1) = ss_now
                sum = 0
            End If
        Next

        Dim ap As Bitmap '创建乐谱图片
        ap = New Bitmap(1000, 50 * （cout.Length + 1）)
        Dim ag As Graphics = Graphics.FromImage(ap)
        ag.FillRectangle(Brushes.White, 0, 0, ap.Width, ap.Height)
        Dim fo As Font
        Dim br As Brush = Brushes.Black
        Dim name As String = My.Computer.FileSystem.GetName(MyFileName)
        For i = name.Length - 1 To 0 Step -1 '去除后缀名
            If name.Substring(i, 1) = "." Then
                name = name.Substring(0, i)
                i = 1
            End If
        Next ' Text = name
        With fo
            fo = New Font("宋体", 30, FontStyle.Italic)
        End With
        ag.DrawString(name, fo, br, 500 - 40 * name.Length / 2, 5)

        '       ban.Image = ap : ban.Width = 1000 : Me.Width = 1350    ‘测试用


        For i = 1 To cout.Length - 1
            Dim x As UInt16 = 20 : Dim j As UInt64 : Dim y As UInt16 = 50 * (i - 1) + 1
            For j = cout(i - 1) To cout(i)
                Select Case Asc(ss.Substring(j, 1))
                    Case 100
                        x += 2 : Continue For
                    Case 127
                        j += 1
                End Select
                cv(Asc(ss.Substring(j, 1)))
                ag.DrawImage(p, x, y + 1)
                x += 50
            Next
            ag.DrawLine(Pens.Black, 19, (1 + i * 50), 980, (1 + i * 50))
        Next
        ss_now = ss_tep

        With SaveFileDialog1
            .DefaultExt = "bmp"
            .FileName = name
            .FilterIndex = 1
            .OverwritePrompt = True
            .Title = "保存乐谱"
            .Filter = "图像文件|*.bmp"
        End With
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                MyFileName = SaveFileDialog1.FileName
                ap.Save(MyFileName)
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub tin_Tick(sender As Object, e As EventArgs) Handles tin.Tick
        '100-无信号  127+数字--电子
        If s > 0 Then
            ss &= Chr(s)
        ElseIf s < 0 Then
            ss &= Chr(127) & Chr(-s)
        End If

        '  test(s, Label2)  debug
        s = 100
    End Sub '录音

    Private Sub tout_Tick(sender As Object, e As EventArgs) Handles tout.Tick
        'TrackBar 控制
        tb.Value = Int(100 * ss_now / ss_len)
        ltb.Text = "进度条：" & tb.Value & "%"
        If ss_len = 0 Or ss_now = ss_len Then '无长度或播放结束停止
            tout.Enabled = False : tc3.Enabled = False
            Exit Sub
        End If
        '100-无信号  127+数字--电子
        s = Asc(ss.Substring(ss_now, 1)) '读取单个音符
        ss_now += 1
        isp = True
        If s = 100 Or s = 0 Then
            s = 100 : Exit Sub
        ElseIf s = 127 Then
            s = -Asc(ss.Substring(ss_now, 1))
            ss_now += 1
            isp = False
        End If

        '   test(s, Label2)  debug
        plays(s)
    End Sub '播放
    Private Sub tclick_Tick(sender As Object, e As EventArgs) Handles tclick.Tick
        'If clic(0) = 20 Then
        '    clic(0) = 0 : clic(1) = 0 : clic(2) = 0
        '    pc1.Top = -500 ' pc1.Left = -500
        '    pc2.Top = -500 ' pc2.Left = -500 '回到无遮拦地初始状态
        '    tclick.Enabled = False
        '    Exit Sub
        'End If

        clic(0) += 1
        'If clic(3) = 2 Then
        '    pc2move(0.0016 * ((clic(0) - 10) * clic(0) + 100) + 0.84)
        'ElseIf clic(3) = 3 Then
        '    pc2move(0.002 * ((clic(0) - 10) * clic(0) + 100) + 0.8)
        'End If

        Select Case clic(0)
            Case 6
                clic(0) = 0 : clic(1) = 0 : clic(2) = 0
                pc1.Top = -500 : pc1.Left = -500
                pc2.Top = -500 : pc2.Left = -500 '回到无遮拦地初始状态
                tclick.Enabled = False
                Exit Sub
            Case 2 Or 4
                If clic(3) = 2 Then
                    pc2move(0.84)
                ElseIf clic(3) = 3 Then
                    pc2move(0.75)
                End If : Exit Sub
            Case 3
                If clic(3) = 2 Then
                    pc2move(0.82)
                ElseIf clic(3) = 3 Then
                    pc2move(0.73)
                End If : Exit Sub
            Case 5
                If clic(3) = 2 Then
                    pc2move(0.9)
                ElseIf clic(3) = 3 Then
                    pc2move(0.83)
                End If : Exit Sub
        End Select
        ' Text = clic(0)
    End Sub
    Private Sub pc2move(rate As Single)
        With pc2  '顺序决定了稳定程度  人眼对横向事物观察敏锐，优先横向属性
            .Left = clic(1) + a * (1 - rate) / 2  '仔细观察会发现抖动，但不伤大雅
            .Width = a * rate
            .Top = clic(2) + a * (1 - rate) / 2
            .Height = a * rate
        End With
    End Sub

    Private Sub cli(sv As SByte)
        clic(0) = 1 ' clic(1) x   clic(2) y  clic(3) 1-0.02 2=0.03
        If 标准版ToolStripMenuItem.Checked Then
            clic(1) = (sv Mod 10 - 1) * a + ban.Left  '计算点击地位置
            clic(2) = ban.Height - (sv \ 10) * a + ban.Top
            pc2.Image = epic(sv, a) '为pc2设置点击位置的音符位图
            pc2move(0.83) 'y=0.02(x-3)^2+0.82  x即clic(0)取 1 2 3 4 5 6
            'pc2.Left = x + a * 0.1 : pc2.Top = y + a * 0.1 : pc2.Width = a * 0.8 : pc2.Height = a * 0.8  '使用pc2缩小制造出音符位图点击后下陷的假象
        ElseIf 简洁版ToolStripMenuItem.Checked Then
            Dim c As Char = " "
            If sv > 20 And sv < 30 Then '第3行
                clic(2) = ban.Top + a * 2
                clic(1) = ban.Left + a * (sv - 20)
                c = line3(sv - 21)
            ElseIf sv > 30 And sv <= 42 Then '第2行
                clic(2) = ban.Top + a
                clic(1) = ban.Left + a * (7 * (sv \ 10 - 3) + sv Mod 10 - 0.5)
                c = line2(7 * (sv \ 10 - 3) + sv Mod 10 - 1)
            ElseIf sv >= 43 And sv <= 55 Then '第1行
                clic(2) = ban.Top
                clic(1) = ban.Left + a * (7 * (sv \ 10 - 4) + sv Mod 10 - 3)
                c = line1(7 * (sv \ 10 - 4) + sv Mod 10 - 3)
            ElseIf (sv < 20) Or (sv > 55) Then
                pc1.Top = -500
                pc2.Top = -500
                lhelp.Text = "提示：部分音符超出本界面显示范围，无法显示点击效果。" : tmsg.Enabled = True
                clic(0) = 0 : clic(1) = 0 : clic(2) = 0
                tclick.Enabled = False
                Exit Sub
            End If
            pc2.Image = epic2(c, sv, a)
            pc2move(0.9) 'y=0.03(x-3)^2+0.73
        ElseIf 触屏版ToolStripMenuItem.Checked Then
            clic(1) = ban.Left + a * ((sv - 11) Mod 10 + 7 * (1 - ((sv Mod 20) \ 10)))
            clic(2) = ban.Top + ban.Height - a * (((sv - 10) \ 20) + 1)
            pc2.Image = epic(sv, a)
            pc2move(0.83)
        End If
        pc1.Left = clic(1) : pc1.Top = clic(2) '使用pc1遮罩，为pc2掩人耳目创造条件

        tclick.Enabled = True
    End Sub
    Private Sub plays(sv As SByte) '播放音符及点击效果
        If sv = 100 Or sv = 127 Then Exit Sub

        If sv < 0 Then
            Try
                b_1() '4*多线程保证电子beep运转流畅
                cli(-sv)
            Catch ex As Exception
                Exit Sub
            End Try

        Else ' 
            If b1.Enabled = False Then   '为了拒绝因多线程延迟而造成的一系列玄之又玄的问题
                If Asc(ss.Substring(ss_now - 2, 1)) = 127 Then Exit Sub
                If Asc(ss.Substring(ss_now - 1, 1)) = s = False Then Exit Sub
                If Asc(ss.Substring(ss_now - 1, 1)) = sv = False Then Exit Sub
            End If
            If isp = False Then Exit Sub

            cli(sv)
            Try
                My.Computer.Audio.Play(path & "\resources\" & sv & ".wav")
            Catch ex As Exception
                b3_Click()
                MessageBox.Show("音频文件丢失！" & vbCrLf & "请重新安装软件！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Me.Close()
            End Try
        End If
    End Sub
    Public Function httpget(url As String)
        Dim request As WebRequest = WebRequest.Create(url)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Console.WriteLine(responseFromServer)
        reader.Close()
        response.Close()
        Return responseFromServer
    End Function
    Private Sub 检查更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查更新ToolStripMenuItem.Click
        Try
            My.Computer.Network.Ping("www.baidu.com")
        Catch ex As Exception
            MessageBox.Show("暂无网络连接", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'post到我的服务器 http://mxcan.win 检查=更新
        Try
            Dim res As String = httpget("http://mxcan.win/vb/hyyy/update.php?a=" & vision)
            If res = "no" Then
                MsgBox("暂无更新", 0, "检查更新")
            Else
                System.Diagnostics.Process.Start(res)
            End If
        Catch ex As Exception
            MsgBox("暂无更新", 0, "检查更新")
        End Try

    End Sub

    Private Function mopo() '得到MousePosition
        Return PointToClient(MousePosition)
    End Function
    Private Sub b_1() '多线程1
        If b.IsBusy Then
            b_2() '链接到多线程2  ，类似于c语言的链表操作 
            b.CancelAsync()
        Else
            b.RunWorkerAsync()
        End If
    End Sub
    Private Sub b_2() '链式多线程2
        If be.IsBusy Then
            b_3()
            be.CancelAsync()
        Else
            be.RunWorkerAsync()
        End If
    End Sub
    Private Sub b_3() '链式多线程3
        If bee.IsBusy Then
            b_4()
            bee.CancelAsync()
        Else
            bee.RunWorkerAsync()
        End If
    End Sub
    Private Sub b_4() '链式多线程4 
        If beee.IsBusy Then
            b_5()
            beee.CancelAsync()
        Else
            beee.RunWorkerAsync()
        End If
    End Sub
    Private Sub b_5() '链式多线程5  可以添加更多，但是没有必要了
        If beeee.IsBusy Then
            b_1()  '首尾相接
            beeee.CancelAsync()
        Else
            beeee.RunWorkerAsync()
        End If
    End Sub
    Private Sub bep()
        Beep(s_pl(-s), 250) '250 是测试后感觉适中的时长
        s = 100
    End Sub
    Private Sub b_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles b.DoWork
        bep() '多线程1
    End Sub
    Private Sub bee_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bee.DoWork
        bep() '多线程3
    End Sub
    Private Sub beeee_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles beeee.DoWork
        bep() '多线程5
    End Sub
    Private Sub be_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles be.DoWork
        bep() '多线程2
    End Sub

    Private Sub beee_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles beee.DoWork
        bep() '多线程4
    End Sub

    Private Sub tb_Scroll(sender As Object, e As EventArgs) Handles tb.ValueChanged '进度条控制
        ss_now = ss_len * tb.Value / 100
        If b1.Enabled = False Then ltb.Text = "进度条：" & Int(100 * ss_now / ss_len) & "%"
    End Sub
    Private Sub tb_Scroll_1(sender As Object, e As EventArgs) Handles tb.MouseDown '进度条控制
        tout.Enabled = False
    End Sub

    Private Sub tb_Scroll_2(sender As Object, e As EventArgs) Handles tb.MouseUp '进度条控制
        If b3.Text = "暂停" Then tout.Enabled = True
    End Sub

    Private Sub 操作ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 操作ToolStripMenuItem.Click
        If MyFileName = "" Then '先打开文件方可选择
            生成乐谱ToolStripMenuItem.Enabled = False
        Else
            生成乐谱ToolStripMenuItem.Enabled = True
        End If
        If MyFileName = "" Then 'double  防延迟
            生成乐谱ToolStripMenuItem.Enabled = False
        Else
            生成乐谱ToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub tc3_Tick(sender As Object, e As EventArgs) Handles tc3.Tick
        c3 += 1
        If c3 = 100 Then c3 = 0
        Dim y As Byte
        If c3 >= 0 And c3 < 50 Then
            y = Int(-2 / 25 * c3 ^ 2 + 4 * c3)
            pot1.Left = pot2.Left - 7 - y
        Else
            c3 -= 50
            y = Int(-2 / 25 * c3 ^ 2 + 4 * c3)
            c3 += 50
            pot3.Left = pot2.Left + 7 + y
        End If
    End Sub '3个小色块运动

    Private Sub 简洁版ToolStripMenuItem_Click() Handles 简洁版ToolStripMenuItem.Click
        If 简洁版ToolStripMenuItem.Checked Then Exit Sub
        look_jian()
        简洁版ToolStripMenuItem.Checked = True
        标准版ToolStripMenuItem.Checked = False
        触屏版ToolStripMenuItem.Checked = False
    End Sub '界面切换

    Private Sub 标准版ToolStripMenuItem_Click() Handles 标准版ToolStripMenuItem.Click
        If 标准版ToolStripMenuItem.Checked Then Exit Sub
        look_biaoz()
        简洁版ToolStripMenuItem.Checked = False
        标准版ToolStripMenuItem.Checked = True
        触屏版ToolStripMenuItem.Checked = False
    End Sub '界面切换

    Private Sub 触屏版ToolStripMenuItem_Click() Handles 触屏版ToolStripMenuItem.Click
        If 触屏版ToolStripMenuItem.Checked Then Exit Sub
        look_chup()
        简洁版ToolStripMenuItem.Checked = False
        标准版ToolStripMenuItem.Checked = False
        触屏版ToolStripMenuItem.Checked = True
    End Sub '界面切换


    Private Sub b1s(sender As Object, e As EventArgs) Handles 录制ToolStripMenuItem.Click, 取消ToolStripMenuItem.Click
        If b1.Enabled = True Then b1_Click()
    End Sub
    Private Sub b2s(sender As Object, e As EventArgs) Handles 打开漾音乐文件ToolStripMenuItem.Click, 保存ToolStripMenuItem.Click, 关闭ToolStripMenuItem.Click
        If b2.Enabled = True Then b2_Click()
    End Sub
    Private Sub b3s(sender As Object, e As EventArgs) Handles 继续ToolStripMenuItem.Click, 播放ToolStripMenuItem.Click, 暂停ToolStripMenuItem.Click, 暂停ToolStripMenuItem1.Click
        If b3.Enabled = True Then b3_Click()
    End Sub

    Private Sub 如何打开文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 如何打开文件ToolStripMenuItem.Click
        lhelp.Text = "你可以使用基础功能菜单选择打开文件，或直接使用控制区的打开按钮打开文件。“ & vbCrLf &
            ”打开文件后，程序标题将显示该文件，你可以播放，或关闭文件。播放时，3个色块将往返运动提示你正在工作。" & vbCrLf &
            “你也可以双击任意*.漾音乐文件，将默认使用随想作曲仪打开。”
    End Sub

    Private Sub 关于ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 关于ToolStripMenuItem1.Click
        Try
            System.Diagnostics.Process.Start(httpget("http://mxcan.win/vb/hyyy/link.html"))
        Catch ex As Exception
            MessageBox.Show("暂无法连接到服务器", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub 如何操作ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 如何操作ToolStripMenuItem.Click
        lhelp.Text = "试着点击下方的音符区，或敲击键盘的字母区，你会听到你点击的音符，你会看到该音符在点击后下陷。" & vbCrLf &
            “现在试着弹一首曲子吧。如果觉得弹得不错，可以将曲子录制下来。你可以打开录制好的曲子，如随程序附带的‘欢乐颂.漾音乐’和‘Unity.漾音乐’文件。你可以使用暂停/播放/继续按钮控制播放，和进度条控制进度。”
    End Sub

    Private Sub 简介ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 简介ToolStripMenuItem.Click
        lhelp.Text = "欢迎来到随想作曲仪。你可以使用左（或上）方控制区内的3个按钮录制或打开文件（建议），或者使用最上方的菜单栏进行操作。" & vbCrLf &
        "程序支持3种界面（简洁·标准·触屏），2种音色（钢琴·电子）和每一个界面都支持的3种操作方式（鼠标·键盘·触屏）。其中触屏需你的设备支持。" & vbCrLf &
        ”你可以使用界面控制菜单切换界面。“ & vbCrLf &
        “打开文件后，你可以使用高级功能生成简易数字乐谱。” & vbCrLf &
        “哦对了，使用时别忘了打开扬声器。”
    End Sub

    Private Sub 如何录制ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 如何录制ToolStripMenuItem.Click
        lhelp.Text = "你可以使用基础功能菜单选择录制文件，或直接使用控制区的录制按钮。" & vbCrLf &
       "录制时，3个色块将往返运动提示你正在工作。” & vbCrLf &
       “*.漾音乐每分钟约储存4kb文件，不大，但是不建议长时间录制，容易溢出。" & vbCrLf &
       ”录制时也可以切换音色和暂停。“
    End Sub

    Private Sub 如何生成乐谱ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 如何生成乐谱ToolStripMenuItem.Click
        lhelp.Text = "打开文件后，选择高级功能菜单的‘生成简易乐谱’，即可。" & vbCrLf &
        "程序将制作图片版的简易数字乐谱，图片内乐谱名使用漾音乐文件名。"
    End Sub

    Private Sub 切换音色什么鬼ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 切换音色什么鬼ToolStripMenuItem.Click
        lhelp.Text = "钢琴固然是乐器里的贵族，但是整天听也太无聊了，程序支持电子音插科打诨。" & vbCrLf &
        "你可以在非播放状态时按下巨大的‘切换音色’按钮切换音色。" & vbCrLf &
        “电子音色可以用来鬼畜，和一些娱乐时间。” & vbCrLf &
        “你可以打开随程序附带的‘Unity.漾音乐’文件体验一下。”
    End Sub

    Private Sub 进度条什么用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 进度条什么用ToolStripMenuItem.Click
        lhelp.Text = "打开文件后，你可以使用进度条控制播放进度。" & vbCrLf &
        "调节进度时，播放将暂停。交接完毕，将恢复原来的播放状态。"
    End Sub

    Private Sub bchangeyinse_Click(sender As Object, e As EventArgs) Handles bchangeyinse.Click
        lhelp.Text = "" : yinse()
        focu()
    End Sub
    Private Sub focu()
        If b3.Enabled Then b3.Focus() Else bf.Focus()
    End Sub
    Private Sub bchangeyinse_fo(sender As Object, e As EventArgs) Handles bchangeyinse.GotFocus
        focu()
    End Sub

    Private Sub tmsg_Tick(sender As Object, e As EventArgs) Handles tmsg.Tick
        lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : showyinse()
        tmsg.Enabled = False
    End Sub

    '3个动态智能按键，，所谓“智能”就是人工列举，这几段代码啰嗦，难以读懂。这三个按键是对“基础功能”菜单的高度浓缩。
    Private Sub b1_Click() Handles b1.Click
        If b1.Text = "录制" Then
            s = 100 : showyinse()
            tin.Enabled = True
            b1.Text = "取消"
            b2.Text = "保存" : b2.Enabled = True
            b3.Enabled = True : tc3.Enabled = True
        ElseIf b1.Text = "取消" Then
            tin.Enabled = False
            ss = "" : s = 100 : tc3.Enabled = False
            b2.Text = "打开" : b2.Enabled = True
            b1.Text = "录制" : b3.Text = "暂停" : b3.Enabled = False
            ss_now = 1 : ss_len = 1
        End If
        focu() '聚焦
    End Sub  '动态智能按键1
    Private Sub b2_Click() Handles b2.Click
        If b2.Text = "保存" Then
            tin.Enabled = False : tc3.Enabled = False
            With SaveFileDialog1
                .DefaultExt = "漾音乐"
                .FileName = My.Computer.FileSystem.GetName(MyFileName)
                .FilterIndex = 1
                .OverwritePrompt = True
                .Title = "保存曲子"
                .Filter = "漾音乐文件|*.漾音乐"
            End With
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    MyFileName = SaveFileDialog1.FileName
                    My.Computer.FileSystem.WriteAllText(MyFileName, ss, False)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            b1.Text = "录制" : b2.Text = "打开" : b3.Text = "暂停" : b3.Enabled = False
            s = 100 : ss = "" : ss_now = 1 : ss_len = 1 : MyFileName = ""
            lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : showyinse()
        ElseIf b2.Text = "打开" Then
            b1.Enabled = False : b2.Text = "关闭" : b3.Enabled = True : ss_now = 1 : ss_len = 1 : ss = ""
            With OpenFileDialog1
                .Filter = "文本文件|*.漾音乐"
                .FilterIndex = 1
                .Title = "打开曲子"
                .FileName = ""
            End With
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    MyFileName = OpenFileDialog1.FileName
                Catch ex As Exception
                    MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MyFileName = ""
                End Try : Text = " 随想作曲仪 - " & My.Computer.FileSystem.GetName(MyFileName)
                ss = My.Computer.FileSystem.ReadAllText(MyFileName) : ss_len = ss.Length : tb.Value = 1 : focu()
                b2.Text = "关闭" : b3.Text = "播放" : tb.Enabled = True : bchangeyinse.Enabled = False : ss_now = 1 : lhelp.Text = "欢迎来到随想作曲仪。你可以在帮助中心查看详细帮助。" : Exit Sub
            Else
                b2.Text = "打开" : b3.Text = "暂停" : b3.Enabled = False : b1.Enabled = True : MyFileName = ""
            End If
        ElseIf b2.Text = "关闭" Then
            tout.Enabled = False : Text = " 随想作曲仪"
            ss = "" : s = 100 : ss_now = 1 : ss_len = 1 : bchangeyinse.Enabled = True  'lp.Enabled = True
            b1.Enabled = True : b2.Text = "打开" : tc3.Enabled = False
            b3.Text = "暂停" : b3.Enabled = False : tb.Enabled = False : tb.Value = 1 ': ltb.Text = "进度条"
        End If
        focu()
    End Sub '动态智能按键2
    Private Sub b3_Click() Handles b3.Click
        If b3.Text = "暂停" Then : tc3.Enabled = False
            If b1.Enabled = True Then
                b3.Text = "继续"
            Else
                b3.Text = "播放"
            End If
            If b1.Text = "取消" Then tin.Enabled = False
            If b2.Text = "关闭" Then tout.Enabled = False
            focu()
        ElseIf b3.Text = "播放" Then : tc3.Enabled = True
            If b1.Enabled = True Then
                b3.Text = "继续"
            Else
                b3.Text = "播放"
            End If
            If b1.Text = "取消" Then tin.Enabled = True
            If b2.Text = "关闭" Then tout.Enabled = True
            b3.Text = "暂停"
        ElseIf b3.Text = "继续" Then
            b3.Text = "暂停" : tc3.Enabled = True
            If b1.Text = "取消" Then tin.Enabled = True
            If b2.Text = "关闭" Then tout.Enabled = True
        End If
        focu()
    End Sub  '动态智能按键3


    '‘’‘这里是一些腹死胎中的代码
    '‘’‘这里是一些腹死胎中的代码
    'Imports System.Math
    'Imports System.Xml.Serialization
    'Imports Microsoft.Win32

    '  Dim ini As String  原打算添加 *.ini 文件读写支持

    ' Dim x As IntPtr  vb居然有指针类型，，下次要好好玩玩

    'Private Function iniread(name As String) 'ini操作  从xml代码中得到启发，有read write update 3个函数
    '    For i = 0 To ini.Length - name.Length
    '        Dim con As String = ini.Substring(i, name.Length)
    '        If con = name Then Return con
    '    Next
    'End Function
    'Private Sub iniwrite(name As String, con As String)
    '    My.Computer.FileSystem.WriteAllText("me.ini", " " & name & "=" & con & vbCrLf, True)
    'End Sub
    'Private Sub iniupdate(name As String, con As String)
    '    For i = 1 To ini.Length - name.Length
    '        If ini.Substring(i - 1, 1) = " " = False Then Continue For '优化速度
    '        Dim j As Byte
    '        For j = 0 To ini.Length - name.Length - i
    '            If ini.Substring(j, 1) = vbCrLf Then Exit For
    '        Next
    '        If ini.Substring(i, name.Length) = name Then
    '            ini = ini.Substring(0, i + name.Length + 1) & con & ini.Substring(j, ini.Length - j)
    '        End If
    '    Next
    'End Sub


    'Private Sub bchangeimag() '绘制切换音色按钮的外观
    '    Dim fo As Font : Dim br As Brush = Brushes.Black
    '    Dim ap = New Bitmap(bchangeyinse.Width, bchangeyinse.Height)
    '    bchangeyinse.Image = ap
    '    Dim ag = Graphics.FromImage(ap)
    '    ag.FillEllipse(Brushes.Gainsboro, 0, 0, ap.Width, ap.Height)
    '    With fo
    '        fo = New Font("宋体", ap.Height \ 8, FontStyle.Italic)
    '    End With
    '    ag.DrawString(" 点击我或BackSpace键", fo, br, 0, ap.Height * 0.1)
    '    With fo
    '        fo = New Font("宋体", ap.Height \ 3)
    '    End With
    '    ag.DrawString("切换音色", fo, br, 0, ap.Height * 0.35)
    'End Sub


    '注册表操作，成功了几次，但总有一些问题
    'Private Sub 关联启动()
    '    Dim sInfo As New Diagnostics.ProcessStartInfo
    '    sInfo.FileName = "目标程序路径"
    '    sInfo.Verb = "RunAs" '以管理员身份运行
    '    sInfo.LoadUserProfile = True
    '    Diagnostics.Process.Start(sInfo) '运行程序
    '    Dim ak As RegistryKey = Registry.ClassesRoot.OpenSubKey("", True)
    '    ak.CreateSubKey(".漾音乐")
    '    ak = Registry.ClassesRoot.OpenSubKey(".漾音乐", True)
    '    ak.SetValue("(默认)", "漾音乐file")
    '    ak = Registry.ClassesRoot.OpenSubKey("", True)
    '    ak.CreateSubKey("漾音乐file")
    '    ak = Registry.ClassesRoot.OpenSubKey("漾音乐file", True)
    '    ak.CreateSubKey("DefaultIcon")
    '    ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\DefaultIcon", True)
    '    ak.SetValue("(默认)", path & "resources\i.ico")
    '    ak = Registry.ClassesRoot.OpenSubKey("漾音乐file", True)
    '    ak.CreateSubKey("shell")
    '    ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\shell", True)
    '    ak.CreateSubKey("open")
    '    ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\shell\\open", True)
    '    ak.CreateSubKey("command")
    '    ak = Registry.ClassesRoot.OpenSubKey("漾音乐file\\shell\\open\\command", True)
    '    ak.SetValue("(默认)", path & "随想作曲仪.exe %1")
    '    MsgBox("关联成功！")
    'End Sub

    'Private Sub l1_drag(sender As Object, e As DragEventArgs) Handles Me.DragDrop  ’拖拽操作，但picturebox不支持
    '    If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
    '        e.Effect = DragDropEffects.Link
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub
    'Private Sub l1_in(sender As Object, e As DragEventArgs) Handles l1.DragDrop
    '    Dim fd() As String
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        fd = e.Data.GetData(DataFormats.FileDrop)
    '    End If
    '    For Each fdd As String In fd
    '        Label1.Text &= fdd
    '    Next

    'End Sub

    'Private Sub ltb_Click(sender As Object, e As EventArgs)    debug
    '    ss_len = ss.Length
    '    '   MsgBox(ss_len)
    '    For ss_now = 1 To ss_len - 1
    '        s = Asc(ss.Substring(ss_now, 1))
    '        test(s, Label1)
    '    Next
    'End Sub
    'Private Sub test(s As SByte, te As Label)
    '    If s = 100 Then
    '        Exit Sub
    '    End If
    '    te.Text &= s & " "
    '    If te.Text.Length Mod 100 = 0 Then
    '        te.Text &= vbCrLf
    '    End If
    'End Sub

End Class
