<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.historyListBox = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dateLabel = New System.Windows.Forms.Label()
        Me.cmntLabel = New System.Windows.Forms.Label()
        Me.nhTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.nhLabel = New System.Windows.Forms.Label()
        Me.ssLabel = New System.Windows.Forms.Label()
        Me.dsLabel = New System.Windows.Forms.Label()
        Me.hlprLabel = New System.Windows.Forms.Label()
        Me.dsTextBox = New System.Windows.Forms.TextBox()
        Me.snTextBox = New System.Windows.Forms.TextBox()
        Me.hlprTextBox = New System.Windows.Forms.TextBox()
        Me.kyoTextBox = New System.Windows.Forms.TextBox()
        Me.hokTextBox = New System.Windows.Forms.TextBox()
        Me.s1TextBox = New System.Windows.Forms.TextBox()
        Me.s2TextBox = New System.Windows.Forms.TextBox()
        Me.s4TextBox = New System.Windows.Forms.TextBox()
        Me.s3TextBox = New System.Windows.Forms.TextBox()
        Me.s5TextBox = New System.Windows.Forms.TextBox()
        Me.s10TextBox = New System.Windows.Forms.TextBox()
        Me.s9TextBox = New System.Windows.Forms.TextBox()
        Me.s8TextBox = New System.Windows.Forms.TextBox()
        Me.s7TextBox = New System.Windows.Forms.TextBox()
        Me.s6TextBox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.sdnTextBox = New System.Windows.Forms.TextBox()
        Me.nsTextBox = New System.Windows.Forms.TextBox()
        Me.tok1TextBox = New System.Windows.Forms.TextBox()
        Me.tok2TextBox = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tok4TextBox = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tok3TextBox = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.syk1TextBox = New System.Windows.Forms.TextBox()
        Me.syk2TextBox = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.yoteiGroupBox = New System.Windows.Forms.GroupBox()
        Me.dgvCmnt = New System.Windows.Forms.DataGridView()
        Me.dgvYotei = New System.Windows.Forms.DataGridView()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.editModeCheckBox = New System.Windows.Forms.CheckBox()
        Me.YmdBox = New ADBox2.ADBox2()
        Me.YmBox = New ADBox2.ADBox2()
        Me.yoteiGroupBox.SuspendLayout()
        CType(Me.dgvCmnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvYotei, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "掲　示　板"
        '
        'historyListBox
        '
        Me.historyListBox.BackColor = System.Drawing.SystemColors.Control
        Me.historyListBox.FormattingEnabled = True
        Me.historyListBox.ItemHeight = 12
        Me.historyListBox.Location = New System.Drawing.Point(552, 81)
        Me.historyListBox.Name = "historyListBox"
        Me.historyListBox.Size = New System.Drawing.Size(131, 496)
        Me.historyListBox.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(16, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 1)
        Me.Panel1.TabIndex = 3
        '
        'dateLabel
        '
        Me.dateLabel.AutoSize = True
        Me.dateLabel.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dateLabel.Location = New System.Drawing.Point(147, 32)
        Me.dateLabel.Name = "dateLabel"
        Me.dateLabel.Size = New System.Drawing.Size(0, 27)
        Me.dateLabel.TabIndex = 4
        '
        'cmntLabel
        '
        Me.cmntLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmntLabel.Location = New System.Drawing.Point(16, 61)
        Me.cmntLabel.Name = "cmntLabel"
        Me.cmntLabel.Size = New System.Drawing.Size(524, 18)
        Me.cmntLabel.TabIndex = 5
        Me.cmntLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nhTextBox
        '
        Me.nhTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.nhTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.nhTextBox.ForeColor = System.Drawing.Color.Blue
        Me.nhTextBox.Location = New System.Drawing.Point(138, 109)
        Me.nhTextBox.Multiline = True
        Me.nhTextBox.Name = "nhTextBox"
        Me.nhTextBox.Size = New System.Drawing.Size(402, 48)
        Me.nhTextBox.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(16, 168)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(524, 1)
        Me.Panel2.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.ForeColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(16, 267)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(524, 1)
        Me.Panel3.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.ForeColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(16, 336)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(524, 1)
        Me.Panel4.TabIndex = 9
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Control
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.ForeColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(16, 389)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(524, 1)
        Me.Panel5.TabIndex = 10
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.Control
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.ForeColor = System.Drawing.Color.Black
        Me.Panel6.Location = New System.Drawing.Point(16, 455)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(524, 1)
        Me.Panel6.TabIndex = 11
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.Control
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.ForeColor = System.Drawing.Color.Black
        Me.Panel7.Location = New System.Drawing.Point(16, 508)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(524, 1)
        Me.Panel7.TabIndex = 12
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.ForeColor = System.Drawing.Color.Black
        Me.Panel8.Location = New System.Drawing.Point(16, 570)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(524, 1)
        Me.Panel8.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "【特　　　　養】"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "【ショートステイ】"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 18)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "【デイサービス】"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 18)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "【支援ハウス】"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 394)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 18)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "【ヘ　ル　パー】"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 460)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 18)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "【居　　　　宅】"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 513)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 18)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "【　そ　の　他　】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 574)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 18)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "【本日の待機】"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(140, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 15)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "本日のご利用者数は"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(140, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 15)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "本日のご利用者数は"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(140, 393)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "本日のご利用者数は"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(140, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 15)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "本日のご入居者数は"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(302, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 15)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "名様です。"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(302, 173)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 15)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "名様です。"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(302, 271)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 15)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "名様です。"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(302, 393)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 15)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "名様です。"
        '
        'nhLabel
        '
        Me.nhLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nhLabel.Location = New System.Drawing.Point(273, 87)
        Me.nhLabel.Name = "nhLabel"
        Me.nhLabel.Size = New System.Drawing.Size(31, 15)
        Me.nhLabel.TabIndex = 30
        Me.nhLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ssLabel
        '
        Me.ssLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ssLabel.Location = New System.Drawing.Point(273, 173)
        Me.ssLabel.Name = "ssLabel"
        Me.ssLabel.Size = New System.Drawing.Size(31, 15)
        Me.ssLabel.TabIndex = 31
        Me.ssLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsLabel
        '
        Me.dsLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dsLabel.Location = New System.Drawing.Point(273, 271)
        Me.dsLabel.Name = "dsLabel"
        Me.dsLabel.Size = New System.Drawing.Size(31, 15)
        Me.dsLabel.TabIndex = 32
        Me.dsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hlprLabel
        '
        Me.hlprLabel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.hlprLabel.Location = New System.Drawing.Point(273, 393)
        Me.hlprLabel.Name = "hlprLabel"
        Me.hlprLabel.Size = New System.Drawing.Size(31, 15)
        Me.hlprLabel.TabIndex = 33
        Me.hlprLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsTextBox
        '
        Me.dsTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.dsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dsTextBox.ForeColor = System.Drawing.Color.Blue
        Me.dsTextBox.Location = New System.Drawing.Point(138, 291)
        Me.dsTextBox.Multiline = True
        Me.dsTextBox.Name = "dsTextBox"
        Me.dsTextBox.Size = New System.Drawing.Size(402, 36)
        Me.dsTextBox.TabIndex = 34
        '
        'snTextBox
        '
        Me.snTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.snTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.snTextBox.ForeColor = System.Drawing.Color.Blue
        Me.snTextBox.Location = New System.Drawing.Point(138, 344)
        Me.snTextBox.Multiline = True
        Me.snTextBox.Name = "snTextBox"
        Me.snTextBox.Size = New System.Drawing.Size(402, 36)
        Me.snTextBox.TabIndex = 35
        '
        'hlprTextBox
        '
        Me.hlprTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.hlprTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.hlprTextBox.ForeColor = System.Drawing.Color.Blue
        Me.hlprTextBox.Location = New System.Drawing.Point(138, 412)
        Me.hlprTextBox.Multiline = True
        Me.hlprTextBox.Name = "hlprTextBox"
        Me.hlprTextBox.Size = New System.Drawing.Size(402, 36)
        Me.hlprTextBox.TabIndex = 36
        '
        'kyoTextBox
        '
        Me.kyoTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.kyoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.kyoTextBox.ForeColor = System.Drawing.Color.Blue
        Me.kyoTextBox.Location = New System.Drawing.Point(138, 463)
        Me.kyoTextBox.Multiline = True
        Me.kyoTextBox.Name = "kyoTextBox"
        Me.kyoTextBox.Size = New System.Drawing.Size(402, 36)
        Me.kyoTextBox.TabIndex = 37
        '
        'hokTextBox
        '
        Me.hokTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.hokTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.hokTextBox.ForeColor = System.Drawing.Color.Blue
        Me.hokTextBox.Location = New System.Drawing.Point(138, 515)
        Me.hokTextBox.Multiline = True
        Me.hokTextBox.Name = "hokTextBox"
        Me.hokTextBox.Size = New System.Drawing.Size(402, 48)
        Me.hokTextBox.TabIndex = 38
        '
        's1TextBox
        '
        Me.s1TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s1TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s1TextBox.Location = New System.Drawing.Point(145, 191)
        Me.s1TextBox.Name = "s1TextBox"
        Me.s1TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s1TextBox.TabIndex = 39
        '
        's2TextBox
        '
        Me.s2TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s2TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s2TextBox.Location = New System.Drawing.Point(145, 205)
        Me.s2TextBox.Name = "s2TextBox"
        Me.s2TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s2TextBox.TabIndex = 40
        '
        's4TextBox
        '
        Me.s4TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s4TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s4TextBox.Location = New System.Drawing.Point(145, 233)
        Me.s4TextBox.Name = "s4TextBox"
        Me.s4TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s4TextBox.TabIndex = 42
        '
        's3TextBox
        '
        Me.s3TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s3TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s3TextBox.Location = New System.Drawing.Point(145, 219)
        Me.s3TextBox.Name = "s3TextBox"
        Me.s3TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s3TextBox.TabIndex = 41
        '
        's5TextBox
        '
        Me.s5TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s5TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s5TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s5TextBox.Location = New System.Drawing.Point(145, 247)
        Me.s5TextBox.Name = "s5TextBox"
        Me.s5TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s5TextBox.TabIndex = 43
        '
        's10TextBox
        '
        Me.s10TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s10TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s10TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s10TextBox.Location = New System.Drawing.Point(269, 247)
        Me.s10TextBox.Name = "s10TextBox"
        Me.s10TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s10TextBox.TabIndex = 48
        '
        's9TextBox
        '
        Me.s9TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s9TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s9TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s9TextBox.Location = New System.Drawing.Point(269, 233)
        Me.s9TextBox.Name = "s9TextBox"
        Me.s9TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s9TextBox.TabIndex = 47
        '
        's8TextBox
        '
        Me.s8TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s8TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s8TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s8TextBox.Location = New System.Drawing.Point(269, 219)
        Me.s8TextBox.Name = "s8TextBox"
        Me.s8TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s8TextBox.TabIndex = 46
        '
        's7TextBox
        '
        Me.s7TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s7TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s7TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s7TextBox.Location = New System.Drawing.Point(269, 205)
        Me.s7TextBox.Name = "s7TextBox"
        Me.s7TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s7TextBox.TabIndex = 45
        '
        's6TextBox
        '
        Me.s6TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.s6TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s6TextBox.ForeColor = System.Drawing.Color.Blue
        Me.s6TextBox.Location = New System.Drawing.Point(269, 191)
        Me.s6TextBox.Name = "s6TextBox"
        Me.s6TextBox.Size = New System.Drawing.Size(100, 12)
        Me.s6TextBox.TabIndex = 44
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(33, 598)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 15)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "生活相談員待機"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(33, 619)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 15)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "看護師待機"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(33, 640)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 15)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "特養・夜勤者"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(33, 664)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 15)
        Me.Label21.TabIndex = 52
        Me.Label21.Text = "宿直者"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(218, 598)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 15)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "さん"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(218, 619)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 15)
        Me.Label23.TabIndex = 54
        Me.Label23.Text = "さん"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(218, 640)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(29, 15)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "さん"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.Location = New System.Drawing.Point(218, 664)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 15)
        Me.Label25.TabIndex = 56
        Me.Label25.Text = "さん"
        '
        'sdnTextBox
        '
        Me.sdnTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.sdnTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.sdnTextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sdnTextBox.ForeColor = System.Drawing.Color.Blue
        Me.sdnTextBox.Location = New System.Drawing.Point(145, 598)
        Me.sdnTextBox.Name = "sdnTextBox"
        Me.sdnTextBox.Size = New System.Drawing.Size(71, 15)
        Me.sdnTextBox.TabIndex = 57
        Me.sdnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nsTextBox
        '
        Me.nsTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.nsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.nsTextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nsTextBox.ForeColor = System.Drawing.Color.Blue
        Me.nsTextBox.Location = New System.Drawing.Point(145, 619)
        Me.nsTextBox.Name = "nsTextBox"
        Me.nsTextBox.Size = New System.Drawing.Size(71, 15)
        Me.nsTextBox.TabIndex = 58
        Me.nsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tok1TextBox
        '
        Me.tok1TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.tok1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tok1TextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tok1TextBox.ForeColor = System.Drawing.Color.Blue
        Me.tok1TextBox.Location = New System.Drawing.Point(145, 640)
        Me.tok1TextBox.Name = "tok1TextBox"
        Me.tok1TextBox.Size = New System.Drawing.Size(71, 15)
        Me.tok1TextBox.TabIndex = 59
        Me.tok1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tok2TextBox
        '
        Me.tok2TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.tok2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tok2TextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tok2TextBox.ForeColor = System.Drawing.Color.Blue
        Me.tok2TextBox.Location = New System.Drawing.Point(246, 640)
        Me.tok2TextBox.Name = "tok2TextBox"
        Me.tok2TextBox.Size = New System.Drawing.Size(71, 15)
        Me.tok2TextBox.TabIndex = 61
        Me.tok2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(319, 640)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(29, 15)
        Me.Label26.TabIndex = 60
        Me.Label26.Text = "さん"
        '
        'tok4TextBox
        '
        Me.tok4TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.tok4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tok4TextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tok4TextBox.ForeColor = System.Drawing.Color.Blue
        Me.tok4TextBox.Location = New System.Drawing.Point(449, 640)
        Me.tok4TextBox.Name = "tok4TextBox"
        Me.tok4TextBox.Size = New System.Drawing.Size(71, 15)
        Me.tok4TextBox.TabIndex = 65
        Me.tok4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(522, 640)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(29, 15)
        Me.Label27.TabIndex = 64
        Me.Label27.Text = "さん"
        '
        'tok3TextBox
        '
        Me.tok3TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.tok3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tok3TextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tok3TextBox.ForeColor = System.Drawing.Color.Blue
        Me.tok3TextBox.Location = New System.Drawing.Point(348, 640)
        Me.tok3TextBox.Name = "tok3TextBox"
        Me.tok3TextBox.Size = New System.Drawing.Size(71, 15)
        Me.tok3TextBox.TabIndex = 63
        Me.tok3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.Location = New System.Drawing.Point(421, 640)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(29, 15)
        Me.Label28.TabIndex = 62
        Me.Label28.Text = "さん"
        '
        'syk1TextBox
        '
        Me.syk1TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.syk1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.syk1TextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.syk1TextBox.ForeColor = System.Drawing.Color.Blue
        Me.syk1TextBox.Location = New System.Drawing.Point(145, 664)
        Me.syk1TextBox.Name = "syk1TextBox"
        Me.syk1TextBox.Size = New System.Drawing.Size(71, 15)
        Me.syk1TextBox.TabIndex = 66
        Me.syk1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'syk2TextBox
        '
        Me.syk2TextBox.BackColor = System.Drawing.SystemColors.Control
        Me.syk2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.syk2TextBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.syk2TextBox.ForeColor = System.Drawing.Color.Blue
        Me.syk2TextBox.Location = New System.Drawing.Point(246, 664)
        Me.syk2TextBox.Name = "syk2TextBox"
        Me.syk2TextBox.Size = New System.Drawing.Size(71, 15)
        Me.syk2TextBox.TabIndex = 68
        Me.syk2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(319, 664)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(29, 15)
        Me.Label29.TabIndex = 67
        Me.Label29.Text = "さん"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.Control
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.ForeColor = System.Drawing.Color.Black
        Me.Panel9.Location = New System.Drawing.Point(348, 657)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(71, 1)
        Me.Panel9.TabIndex = 69
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.Control
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.ForeColor = System.Drawing.Color.Black
        Me.Panel10.Location = New System.Drawing.Point(449, 657)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(71, 1)
        Me.Panel10.TabIndex = 70
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(364, 660)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 10)
        Me.Label30.TabIndex = 71
        Me.Label30.Text = "（深　夜）"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(464, 660)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(42, 10)
        Me.Label31.TabIndex = 72
        Me.Label31.Text = "（深　夜）"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(590, 590)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 26)
        Me.btnPrint.TabIndex = 73
        Me.btnPrint.Text = "印　刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'yoteiGroupBox
        '
        Me.yoteiGroupBox.Controls.Add(Me.YmBox)
        Me.yoteiGroupBox.Controls.Add(Me.dgvCmnt)
        Me.yoteiGroupBox.Controls.Add(Me.dgvYotei)
        Me.yoteiGroupBox.Controls.Add(Me.btnDelete)
        Me.yoteiGroupBox.Controls.Add(Me.btnUpdate)
        Me.yoteiGroupBox.Controls.Add(Me.editModeCheckBox)
        Me.yoteiGroupBox.Location = New System.Drawing.Point(702, 7)
        Me.yoteiGroupBox.Name = "yoteiGroupBox"
        Me.yoteiGroupBox.Size = New System.Drawing.Size(416, 696)
        Me.yoteiGroupBox.TabIndex = 74
        Me.yoteiGroupBox.TabStop = False
        Me.yoteiGroupBox.Text = "予定ﾏｽﾀ"
        '
        'dgvCmnt
        '
        Me.dgvCmnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCmnt.Location = New System.Drawing.Point(14, 549)
        Me.dgvCmnt.Name = "dgvCmnt"
        Me.dgvCmnt.RowTemplate.Height = 21
        Me.dgvCmnt.Size = New System.Drawing.Size(388, 139)
        Me.dgvCmnt.TabIndex = 5
        '
        'dgvYotei
        '
        Me.dgvYotei.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYotei.Location = New System.Drawing.Point(14, 60)
        Me.dgvYotei.Name = "dgvYotei"
        Me.dgvYotei.RowTemplate.Height = 21
        Me.dgvYotei.Size = New System.Drawing.Size(388, 484)
        Me.dgvYotei.TabIndex = 4
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(313, 33)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "削除(掲示板)"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(229, 33)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(78, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "更　新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'editModeCheckBox
        '
        Me.editModeCheckBox.AutoSize = True
        Me.editModeCheckBox.Location = New System.Drawing.Point(147, 15)
        Me.editModeCheckBox.Name = "editModeCheckBox"
        Me.editModeCheckBox.Size = New System.Drawing.Size(138, 16)
        Me.editModeCheckBox.TabIndex = 1
        Me.editModeCheckBox.Text = "編集モード（マスタ読込）"
        Me.editModeCheckBox.UseVisualStyleBackColor = True
        '
        'YmdBox
        '
        Me.YmdBox.dateText = ""
        Me.YmdBox.Location = New System.Drawing.Point(541, 45)
        Me.YmdBox.Mode = 0
        Me.YmdBox.monthText = ""
        Me.YmdBox.Name = "YmdBox"
        Me.YmdBox.Size = New System.Drawing.Size(160, 32)
        Me.YmdBox.TabIndex = 1
        Me.YmdBox.textReadOnly = False
        Me.YmdBox.Visible = False
        Me.YmdBox.yearText = ""
        '
        'YmBox
        '
        Me.YmBox.dateText = ""
        Me.YmBox.Location = New System.Drawing.Point(14, 13)
        Me.YmBox.Mode = 32
        Me.YmBox.monthText = ""
        Me.YmBox.Name = "YmBox"
        Me.YmBox.Size = New System.Drawing.Size(110, 46)
        Me.YmBox.TabIndex = 0
        Me.YmBox.textReadOnly = False
        Me.YmBox.yearText = ""
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 723)
        Me.Controls.Add(Me.YmdBox)
        Me.Controls.Add(Me.yoteiGroupBox)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.syk2TextBox)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.syk1TextBox)
        Me.Controls.Add(Me.tok4TextBox)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tok3TextBox)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.tok2TextBox)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.tok1TextBox)
        Me.Controls.Add(Me.nsTextBox)
        Me.Controls.Add(Me.sdnTextBox)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.s10TextBox)
        Me.Controls.Add(Me.s9TextBox)
        Me.Controls.Add(Me.s8TextBox)
        Me.Controls.Add(Me.s7TextBox)
        Me.Controls.Add(Me.s6TextBox)
        Me.Controls.Add(Me.s5TextBox)
        Me.Controls.Add(Me.s4TextBox)
        Me.Controls.Add(Me.s3TextBox)
        Me.Controls.Add(Me.s2TextBox)
        Me.Controls.Add(Me.s1TextBox)
        Me.Controls.Add(Me.hokTextBox)
        Me.Controls.Add(Me.kyoTextBox)
        Me.Controls.Add(Me.hlprTextBox)
        Me.Controls.Add(Me.snTextBox)
        Me.Controls.Add(Me.dsTextBox)
        Me.Controls.Add(Me.hlprLabel)
        Me.Controls.Add(Me.dsLabel)
        Me.Controls.Add(Me.ssLabel)
        Me.Controls.Add(Me.nhLabel)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.nhTextBox)
        Me.Controls.Add(Me.cmntLabel)
        Me.Controls.Add(Me.dateLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.historyListBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TopForm"
        Me.Text = "Board　掲示板"
        Me.yoteiGroupBox.ResumeLayout(False)
        Me.yoteiGroupBox.PerformLayout()
        CType(Me.dgvCmnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvYotei, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents historyListBox As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dateLabel As Label
    Friend WithEvents cmntLabel As Label
    Friend WithEvents nhTextBox As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents nhLabel As Label
    Friend WithEvents ssLabel As Label
    Friend WithEvents dsLabel As Label
    Friend WithEvents hlprLabel As Label
    Friend WithEvents dsTextBox As TextBox
    Friend WithEvents snTextBox As TextBox
    Friend WithEvents hlprTextBox As TextBox
    Friend WithEvents kyoTextBox As TextBox
    Friend WithEvents hokTextBox As TextBox
    Friend WithEvents s1TextBox As TextBox
    Friend WithEvents s2TextBox As TextBox
    Friend WithEvents s4TextBox As TextBox
    Friend WithEvents s3TextBox As TextBox
    Friend WithEvents s5TextBox As TextBox
    Friend WithEvents s10TextBox As TextBox
    Friend WithEvents s9TextBox As TextBox
    Friend WithEvents s8TextBox As TextBox
    Friend WithEvents s7TextBox As TextBox
    Friend WithEvents s6TextBox As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents sdnTextBox As TextBox
    Friend WithEvents nsTextBox As TextBox
    Friend WithEvents tok1TextBox As TextBox
    Friend WithEvents tok2TextBox As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents tok4TextBox As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tok3TextBox As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents syk1TextBox As TextBox
    Friend WithEvents syk2TextBox As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents yoteiGroupBox As GroupBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents editModeCheckBox As CheckBox
    Friend WithEvents dgvCmnt As DataGridView
    Friend WithEvents dgvYotei As DataGridView
    Friend WithEvents YmdBox As ADBox2.ADBox2
    Friend WithEvents YmBox As ADBox2.ADBox2
End Class
