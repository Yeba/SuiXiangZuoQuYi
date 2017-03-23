<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ban = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.基础功能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.打开漾音乐文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.播放ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.暂停ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关闭ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.录制漾音乐文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.录制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.暂停ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.继续ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.取消ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.标准版ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.简洁版ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.触屏版ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.操作ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.生成乐谱ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.检查更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.简介ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.如何操作ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.如何录制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.如何生成乐谱ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.如何打开文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.进度条什么用ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.切换音色什么鬼ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.later = New System.Windows.Forms.Timer(Me.components)
        Me.tout = New System.Windows.Forms.Timer(Me.components)
        Me.tb = New System.Windows.Forms.TrackBar()
        Me.tin = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ltb = New System.Windows.Forms.Label()
        Me.b2 = New System.Windows.Forms.Button()
        Me.b1 = New System.Windows.Forms.Button()
        Me.b3 = New System.Windows.Forms.Button()
        Me.pot1 = New System.Windows.Forms.PictureBox()
        Me.pot3 = New System.Windows.Forms.PictureBox()
        Me.pot2 = New System.Windows.Forms.PictureBox()
        Me.pc1 = New System.Windows.Forms.PictureBox()
        Me.pc2 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.bee = New System.ComponentModel.BackgroundWorker()
        Me.be = New System.ComponentModel.BackgroundWorker()
        Me.beee = New System.ComponentModel.BackgroundWorker()
        Me.tc3 = New System.Windows.Forms.Timer(Me.components)
        Me.b = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.bchangeyinse = New System.Windows.Forms.Button()
        Me.tclick = New System.Windows.Forms.Timer(Me.components)
        Me.beeee = New System.ComponentModel.BackgroundWorker()
        Me.lhelp = New System.Windows.Forms.TextBox()
        Me.bf = New System.Windows.Forms.Button()
        Me.tmsg = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.tb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pot1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pot3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pot2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pc2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ban
        '
        Me.ban.BackColor = System.Drawing.Color.LightGray
        Me.ban.Location = New System.Drawing.Point(363, 38)
        Me.ban.Name = "ban"
        Me.ban.Size = New System.Drawing.Size(800, 700)
        Me.ban.TabIndex = 0
        Me.ban.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.基础功能ToolStripMenuItem, Me.设置ToolStripMenuItem, Me.操作ToolStripMenuItem, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1354, 35)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '基础功能ToolStripMenuItem
        '
        Me.基础功能ToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.基础功能ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.打开ToolStripMenuItem, Me.ToolStripSeparator3, Me.打开漾音乐文件ToolStripMenuItem, Me.播放ToolStripMenuItem, Me.暂停ToolStripMenuItem, Me.关闭ToolStripMenuItem, Me.ToolStripSeparator4, Me.ToolStripSeparator5, Me.录制漾音乐文件ToolStripMenuItem, Me.ToolStripSeparator6, Me.录制ToolStripMenuItem, Me.暂停ToolStripMenuItem1, Me.继续ToolStripMenuItem, Me.保存ToolStripMenuItem, Me.取消ToolStripMenuItem})
        Me.基础功能ToolStripMenuItem.Name = "基础功能ToolStripMenuItem"
        Me.基础功能ToolStripMenuItem.Size = New System.Drawing.Size(104, 31)
        Me.基础功能ToolStripMenuItem.Text = "基础功能"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(241, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(241, 6)
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.打开ToolStripMenuItem.Text = "打开*.漾音乐文件"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(241, 6)
        '
        '打开漾音乐文件ToolStripMenuItem
        '
        Me.打开漾音乐文件ToolStripMenuItem.Name = "打开漾音乐文件ToolStripMenuItem"
        Me.打开漾音乐文件ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.打开漾音乐文件ToolStripMenuItem.Text = "打开"
        '
        '播放ToolStripMenuItem
        '
        Me.播放ToolStripMenuItem.Name = "播放ToolStripMenuItem"
        Me.播放ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.播放ToolStripMenuItem.Text = "播放"
        '
        '暂停ToolStripMenuItem
        '
        Me.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem"
        Me.暂停ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.暂停ToolStripMenuItem.Text = "暂停"
        '
        '关闭ToolStripMenuItem
        '
        Me.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem"
        Me.关闭ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.关闭ToolStripMenuItem.Text = "关闭"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(241, 6)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(241, 6)
        '
        '录制漾音乐文件ToolStripMenuItem
        '
        Me.录制漾音乐文件ToolStripMenuItem.Name = "录制漾音乐文件ToolStripMenuItem"
        Me.录制漾音乐文件ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.录制漾音乐文件ToolStripMenuItem.Text = "录制*.漾音乐文件"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(241, 6)
        '
        '录制ToolStripMenuItem
        '
        Me.录制ToolStripMenuItem.Name = "录制ToolStripMenuItem"
        Me.录制ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.录制ToolStripMenuItem.Text = "录制"
        '
        '暂停ToolStripMenuItem1
        '
        Me.暂停ToolStripMenuItem1.Name = "暂停ToolStripMenuItem1"
        Me.暂停ToolStripMenuItem1.Size = New System.Drawing.Size(244, 32)
        Me.暂停ToolStripMenuItem1.Text = "暂停"
        '
        '继续ToolStripMenuItem
        '
        Me.继续ToolStripMenuItem.Name = "继续ToolStripMenuItem"
        Me.继续ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.继续ToolStripMenuItem.Text = "继续"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        '取消ToolStripMenuItem
        '
        Me.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem"
        Me.取消ToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.取消ToolStripMenuItem.Text = "取消"
        '
        '设置ToolStripMenuItem
        '
        Me.设置ToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.设置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.标准版ToolStripMenuItem, Me.简洁版ToolStripMenuItem, Me.触屏版ToolStripMenuItem})
        Me.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem"
        Me.设置ToolStripMenuItem.Size = New System.Drawing.Size(104, 31)
        Me.设置ToolStripMenuItem.Text = "界面控制"
        '
        '标准版ToolStripMenuItem
        '
        Me.标准版ToolStripMenuItem.Name = "标准版ToolStripMenuItem"
        Me.标准版ToolStripMenuItem.Size = New System.Drawing.Size(150, 32)
        Me.标准版ToolStripMenuItem.Text = "标准版"
        '
        '简洁版ToolStripMenuItem
        '
        Me.简洁版ToolStripMenuItem.Checked = True
        Me.简洁版ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.简洁版ToolStripMenuItem.Name = "简洁版ToolStripMenuItem"
        Me.简洁版ToolStripMenuItem.Size = New System.Drawing.Size(150, 32)
        Me.简洁版ToolStripMenuItem.Text = "简洁版"
        '
        '触屏版ToolStripMenuItem
        '
        Me.触屏版ToolStripMenuItem.Name = "触屏版ToolStripMenuItem"
        Me.触屏版ToolStripMenuItem.Size = New System.Drawing.Size(150, 32)
        Me.触屏版ToolStripMenuItem.Text = "触屏版"
        '
        '操作ToolStripMenuItem
        '
        Me.操作ToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.操作ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.生成乐谱ToolStripMenuItem, Me.检查更新ToolStripMenuItem})
        Me.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem"
        Me.操作ToolStripMenuItem.Size = New System.Drawing.Size(104, 31)
        Me.操作ToolStripMenuItem.Text = "高级功能"
        '
        '生成乐谱ToolStripMenuItem
        '
        Me.生成乐谱ToolStripMenuItem.AutoToolTip = True
        Me.生成乐谱ToolStripMenuItem.Name = "生成乐谱ToolStripMenuItem"
        Me.生成乐谱ToolStripMenuItem.Size = New System.Drawing.Size(210, 32)
        Me.生成乐谱ToolStripMenuItem.Text = "生成简易乐谱"
        Me.生成乐谱ToolStripMenuItem.ToolTipText = "仅打开文件后可使用"
        '
        '检查更新ToolStripMenuItem
        '
        Me.检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem"
        Me.检查更新ToolStripMenuItem.Size = New System.Drawing.Size(210, 32)
        Me.检查更新ToolStripMenuItem.Text = "检查更新"
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro
        Me.关于ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.简介ToolStripMenuItem, Me.如何操作ToolStripMenuItem, Me.如何录制ToolStripMenuItem, Me.如何生成乐谱ToolStripMenuItem, Me.如何打开文件ToolStripMenuItem, Me.进度条什么用ToolStripMenuItem, Me.切换音色什么鬼ToolStripMenuItem, Me.关于ToolStripMenuItem1})
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(104, 31)
        Me.关于ToolStripMenuItem.Text = "帮助中心"
        '
        '简介ToolStripMenuItem
        '
        Me.简介ToolStripMenuItem.Name = "简介ToolStripMenuItem"
        Me.简介ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.简介ToolStripMenuItem.Text = "简介"
        '
        '如何操作ToolStripMenuItem
        '
        Me.如何操作ToolStripMenuItem.Name = "如何操作ToolStripMenuItem"
        Me.如何操作ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.如何操作ToolStripMenuItem.Text = "如何优雅地操作"
        '
        '如何录制ToolStripMenuItem
        '
        Me.如何录制ToolStripMenuItem.Name = "如何录制ToolStripMenuItem"
        Me.如何录制ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.如何录制ToolStripMenuItem.Text = "如何科学地录制"
        '
        '如何生成乐谱ToolStripMenuItem
        '
        Me.如何生成乐谱ToolStripMenuItem.Name = "如何生成乐谱ToolStripMenuItem"
        Me.如何生成乐谱ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.如何生成乐谱ToolStripMenuItem.Text = "如何生成乐谱"
        '
        '如何打开文件ToolStripMenuItem
        '
        Me.如何打开文件ToolStripMenuItem.Name = "如何打开文件ToolStripMenuItem"
        Me.如何打开文件ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.如何打开文件ToolStripMenuItem.Text = "如何打开文件"
        '
        '进度条什么用ToolStripMenuItem
        '
        Me.进度条什么用ToolStripMenuItem.Name = "进度条什么用ToolStripMenuItem"
        Me.进度条什么用ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.进度条什么用ToolStripMenuItem.Text = "进度条有什么用"
        '
        '切换音色什么鬼ToolStripMenuItem
        '
        Me.切换音色什么鬼ToolStripMenuItem.Name = "切换音色什么鬼ToolStripMenuItem"
        Me.切换音色什么鬼ToolStripMenuItem.Size = New System.Drawing.Size(230, 32)
        Me.切换音色什么鬼ToolStripMenuItem.Text = "切换音色什么鬼"
        '
        '关于ToolStripMenuItem1
        '
        Me.关于ToolStripMenuItem1.AutoToolTip = True
        Me.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1"
        Me.关于ToolStripMenuItem1.Size = New System.Drawing.Size(230, 32)
        Me.关于ToolStripMenuItem1.Text = "关于"
        Me.关于ToolStripMenuItem1.ToolTipText = "即将进入我的网站"
        '
        'later
        '
        Me.later.Enabled = True
        Me.later.Interval = 10
        '
        'tout
        '
        Me.tout.Interval = 10
        '
        'tb
        '
        Me.tb.AutoSize = False
        Me.tb.Enabled = False
        Me.tb.LargeChange = 1
        Me.tb.Location = New System.Drawing.Point(3, 133)
        Me.tb.Maximum = 100
        Me.tb.Name = "tb"
        Me.tb.Size = New System.Drawing.Size(340, 38)
        Me.tb.TabIndex = 14
        '
        'tin
        '
        Me.tin.Interval = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.b3)
        Me.GroupBox1.Controls.Add(Me.ltb)
        Me.GroupBox1.Controls.Add(Me.b2)
        Me.GroupBox1.Controls.Add(Me.b1)
        Me.GroupBox1.Controls.Add(Me.tb)
        Me.GroupBox1.Controls.Add(Me.bchangeyinse)
        Me.GroupBox1.Controls.Add(Me.pot1)
        Me.GroupBox1.Controls.Add(Me.pot3)
        Me.GroupBox1.Controls.Add(Me.pot2)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 38)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(347, 174)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "控制"
        '
        'ltb
        '
        Me.ltb.AutoSize = True
        Me.ltb.Location = New System.Drawing.Point(7, 120)
        Me.ltb.Name = "ltb"
        Me.ltb.Size = New System.Drawing.Size(52, 15)
        Me.ltb.TabIndex = 17
        Me.ltb.Text = "进度条"
        '
        'b2
        '
        Me.b2.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.b2.Location = New System.Drawing.Point(169, 24)
        Me.b2.Margin = New System.Windows.Forms.Padding(4)
        Me.b2.Name = "b2"
        Me.b2.Size = New System.Drawing.Size(138, 45)
        Me.b2.TabIndex = 8
        Me.b2.TabStop = False
        Me.b2.Text = "打开"
        Me.b2.UseVisualStyleBackColor = True
        '
        'b1
        '
        Me.b1.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.b1.Location = New System.Drawing.Point(20, 24)
        Me.b1.Margin = New System.Windows.Forms.Padding(4)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(138, 45)
        Me.b1.TabIndex = 6
        Me.b1.TabStop = False
        Me.b1.Text = "录制"
        Me.b1.UseVisualStyleBackColor = True
        '
        'b3
        '
        Me.b3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.b3.Enabled = False
        Me.b3.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.b3.Location = New System.Drawing.Point(20, 75)
        Me.b3.Margin = New System.Windows.Forms.Padding(4)
        Me.b3.Name = "b3"
        Me.b3.Size = New System.Drawing.Size(138, 45)
        Me.b3.TabIndex = 1
        Me.b3.TabStop = False
        Me.b3.Text = "暂停"
        Me.b3.UseVisualStyleBackColor = True
        '
        'pot1
        '
        Me.pot1.BackgroundImage = CType(resources.GetObject("pot1.BackgroundImage"), System.Drawing.Image)
        Me.pot1.Location = New System.Drawing.Point(133, 12)
        Me.pot1.Margin = New System.Windows.Forms.Padding(4)
        Me.pot1.Name = "pot1"
        Me.pot1.Size = New System.Drawing.Size(10, 10)
        Me.pot1.TabIndex = 3
        Me.pot1.TabStop = False
        '
        'pot3
        '
        Me.pot3.Image = CType(resources.GetObject("pot3.Image"), System.Drawing.Image)
        Me.pot3.Location = New System.Drawing.Point(157, 12)
        Me.pot3.Margin = New System.Windows.Forms.Padding(4)
        Me.pot3.Name = "pot3"
        Me.pot3.Size = New System.Drawing.Size(10, 10)
        Me.pot3.TabIndex = 4
        Me.pot3.TabStop = False
        '
        'pot2
        '
        Me.pot2.BackgroundImage = CType(resources.GetObject("pot2.BackgroundImage"), System.Drawing.Image)
        Me.pot2.Location = New System.Drawing.Point(145, 12)
        Me.pot2.Margin = New System.Windows.Forms.Padding(4)
        Me.pot2.Name = "pot2"
        Me.pot2.Size = New System.Drawing.Size(10, 10)
        Me.pot2.TabIndex = 5
        Me.pot2.TabStop = False
        '
        'pc1
        '
        Me.pc1.BackColor = System.Drawing.Color.LightGray
        Me.pc1.Location = New System.Drawing.Point(217, 219)
        Me.pc1.Name = "pc1"
        Me.pc1.Size = New System.Drawing.Size(50, 37)
        Me.pc1.TabIndex = 18
        Me.pc1.TabStop = False
        '
        'pc2
        '
        Me.pc2.BackColor = System.Drawing.Color.Gainsboro
        Me.pc2.Location = New System.Drawing.Point(98, 219)
        Me.pc2.Name = "pc2"
        Me.pc2.Size = New System.Drawing.Size(57, 50)
        Me.pc2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pc2.TabIndex = 19
        Me.pc2.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'bee
        '
        Me.bee.WorkerReportsProgress = True
        Me.bee.WorkerSupportsCancellation = True
        '
        'be
        '
        Me.be.WorkerReportsProgress = True
        Me.be.WorkerSupportsCancellation = True
        '
        'beee
        '
        Me.beee.WorkerReportsProgress = True
        Me.beee.WorkerSupportsCancellation = True
        '
        'tc3
        '
        Me.tc3.Interval = 10
        '
        'b
        '
        Me.b.WorkerReportsProgress = True
        Me.b.WorkerSupportsCancellation = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 100
        '
        'bchangeyinse
        '
        Me.bchangeyinse.BackColor = System.Drawing.SystemColors.Control
        Me.bchangeyinse.Font = New System.Drawing.Font("宋体", 16.0!)
        Me.bchangeyinse.Location = New System.Drawing.Point(169, 75)
        Me.bchangeyinse.Name = "bchangeyinse"
        Me.bchangeyinse.Size = New System.Drawing.Size(138, 45)
        Me.bchangeyinse.TabIndex = 20
        Me.bchangeyinse.Text = "切换音色"
        Me.bchangeyinse.UseVisualStyleBackColor = True
        '
        'tclick
        '
        Me.tclick.Interval = 40
        '
        'beeee
        '
        Me.beeee.WorkerReportsProgress = True
        Me.beeee.WorkerSupportsCancellation = True
        '
        'lhelp
        '
        Me.lhelp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lhelp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lhelp.CausesValidation = False
        Me.lhelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lhelp.Enabled = False
        Me.lhelp.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lhelp.Location = New System.Drawing.Point(259, 235)
        Me.lhelp.Multiline = True
        Me.lhelp.Name = "lhelp"
        Me.lhelp.ReadOnly = True
        Me.lhelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lhelp.ShortcutsEnabled = False
        Me.lhelp.Size = New System.Drawing.Size(143, 100)
        Me.lhelp.TabIndex = 22
        Me.lhelp.TabStop = False
        Me.lhelp.Text = "欢迎来到随想作曲仪。"
        '
        'bf
        '
        Me.bf.Location = New System.Drawing.Point(-50, -50)
        Me.bf.Name = "bf"
        Me.bf.Size = New System.Drawing.Size(75, 23)
        Me.bf.TabIndex = 23
        Me.bf.Text = "Button1"
        Me.bf.UseVisualStyleBackColor = True
        '
        'tmsg
        '
        Me.tmsg.Enabled = True
        Me.tmsg.Interval = 2000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1354, 769)
        Me.Controls.Add(Me.pc2)
        Me.Controls.Add(Me.bf)
        Me.Controls.Add(Me.lhelp)
        Me.Controls.Add(Me.pc1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ban)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "随想作曲仪"
        CType(Me.ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.tb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pot1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pot3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pot2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pc2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ban As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 操作ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 检查更新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 生成乐谱ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 设置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents later As Timer
    Friend WithEvents tout As Timer
    Friend WithEvents tb As TrackBar
    Friend WithEvents tin As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents b2 As Button
    Friend WithEvents b1 As Button
    Friend WithEvents b3 As Button
    Friend WithEvents pot1 As PictureBox
    Friend WithEvents pot3 As PictureBox
    Friend WithEvents pot2 As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents bee As System.ComponentModel.BackgroundWorker
    Friend WithEvents be As System.ComponentModel.BackgroundWorker
    Friend WithEvents beee As System.ComponentModel.BackgroundWorker
    Friend WithEvents ltb As Label
    Friend WithEvents tc3 As Timer
    Friend WithEvents 标准版ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 简洁版ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 触屏版ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents b As System.ComponentModel.BackgroundWorker
    Friend WithEvents pc1 As PictureBox
    Friend WithEvents 基础功能ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents 打开ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents 打开漾音乐文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 播放ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 暂停ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 关闭ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents 录制漾音乐文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents 录制ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 暂停ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 取消ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 继续ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pc2 As PictureBox
    Friend WithEvents bchangeyinse As Button
    Friend WithEvents tclick As Timer
    Friend WithEvents beeee As System.ComponentModel.BackgroundWorker
    Friend WithEvents 如何操作ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 如何录制ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 切换音色什么鬼ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 进度条什么用ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 如何生成乐谱ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 如何打开文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents lhelp As TextBox
    Friend WithEvents 简介ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents bf As Button
    Friend WithEvents tmsg As Timer
End Class
