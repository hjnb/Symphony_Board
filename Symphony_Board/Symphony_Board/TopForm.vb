Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop

Public Class TopForm
    Public Class dgvRowHeaderCell

        'DataGridViewRowHeaderCell を継承
        Inherits DataGridViewRowHeaderCell

        'DataGridViewHeaderCell.Paint をオーバーライドして行ヘッダーを描画
        Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle,
           ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates,
           ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String,
           ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle,
           ByVal paintParts As DataGridViewPaintParts)
            '標準セルの描画からセル内容の背景だけ除いた物を描画(-5)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
                     formattedValue, errorText, cellStyle, advancedBorderStyle,
                     Not DataGridViewPaintParts.ContentBackground)
        End Sub

    End Class

    'データベースのパス
    Public dbBoardFilePath As String = My.Application.Info.DirectoryPath & "\Board.mdb"
    Public DB_Board As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbBoardFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\書式.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\Board.ini"

    'Shiftのデータベースパス
    Public dbShiftFilePath As String = Util.getIniString("System", "DB2Dir", iniFilePath) & "\Shift.mdb"
    Public DB_Shift As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbShiftFilePath

    'workのデータベースパス
    Public dbWorkFilePath As String = Util.getIniString("System", "DB3Dir", iniFilePath) & "\Work.mdb"
    Public DB_Work As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbWorkFilePath

    '印刷の状態("Y"(印刷) or "N"(ﾌﾟﾚﾋﾞｭｰ))
    Private printState As String = Util.getIniString("System", "Printer", iniFilePath)

    Private dayArray() As String = {"日", "月", "火", "水", "木", "金", "土"}

    '編集不可部分のセルスタイル
    Private readOnlyCellStyle As DataGridViewCellStyle

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TopForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbBoardFilePath) Then
            MsgBox(dbBoardFilePath & "が存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(dbShiftFilePath) Then
            MsgBox(dbShiftFilePath & "が存在しません。iniファイルのDB2Dirに正しいパスを設定してください。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(dbWorkFilePath) Then
            MsgBox(dbWorkFilePath & "が存在しません。iniファイルのDB3Dirに正しいパスを設定してください。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        'セルスタイル作成
        createCellStyles()

        '非表示
        YmdBox.Visible = False
        yoteiGroupBox.Visible = False

        'データグリッドビュー初期設定
        initDgvYotei()
        initDgvCmnt()
        displayDgvCmnt()

        '現在日付セット
        YmdBox.setADStr(Today.ToString("yyyy/MM/dd"))
        YmBox.setADStr(Today.ToString("yyyy/MM/dd"))

        '履歴リスト表示
        loadHistoryList()
    End Sub

    ''' <summary>
    ''' keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TopForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.F10 Then
            '(Alt + F10)キー押下
            YmdBox.Visible = Not YmdBox.Visible
            yoteiGroupBox.Visible = Not yoteiGroupBox.Visible
            If YmdBox.Visible Then
                YmdBox.Focus()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 掲示板入力内容クリア
    ''' </summary>
    Private Sub clearInputBoard()
        'コメント
        cmntLabel.Text = ""
        '特養
        nhLabel.Text = ""
        nhTextBox.Text = ""
        'ショートステイ
        ssLabel.Text = ""
        For i As Integer = 1 To 10
            DirectCast(Controls("s" & i & "TextBox"), TextBox).Text = ""
        Next
        'デイサービス 
        dsLabel.Text = ""
        dsTextBox.Text = ""
        '支援ハウス
        snTextBox.Text = ""
        'ヘルパー
        hlprLabel.Text = ""
        hlprTextBox.Text = ""
        '居宅
        kyoTextBox.Text = ""
        'その他
        hokTextBox.Text = ""
        '本日の待機
        sdnTextBox.Text = ""
        nsTextBox.Text = ""
        tok1TextBox.Text = ""
        tok2TextBox.Text = ""
        tok3TextBox.Text = ""
        tok4TextBox.Text = ""
        syk1TextBox.Text = ""
        syk2TextBox.Text = ""
    End Sub

    ''' <summary>
    ''' 予定表クリア
    ''' </summary>
    Private Sub clearInputYotei()
        For Each row As DataGridViewRow In dgvYotei.Rows
            row.Cells("Ymd").Value = ""
            row.Cells("Youbi").Value = ""
            row.Cells("Sdn").Value = ""
            row.Cells("Syk1").Value = ""
            row.Cells("Syk2").Value = ""
            row.Cells("Ds").Value = ""
            row.Cells("Hlpr").Value = ""
            row.Cells("Nh").Value = ""
        Next
    End Sub

    ''' <summary>
    ''' セルスタイル作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createCellStyles()
        readOnlyCellStyle = New DataGridViewCellStyle()
        readOnlyCellStyle.BackColor = Color.FromArgb(216, 216, 216)
        readOnlyCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control)
        readOnlyCellStyle.SelectionForeColor = Color.Black
        readOnlyCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ''' <summary>
    ''' dgvコメント初期設定
    ''' </summary>
    Private Sub initDgvCmnt()
        Util.EnableDoubleBuffering(dgvCmnt)

        With dgvCmnt
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 17
            .RowTemplate.Height = 15
            .RowHeadersWidth = 25
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
    End Sub

    ''' <summary>
    ''' dgv予定初期設定
    ''' </summary>
    Private Sub initDgvYotei()
        Util.EnableDoubleBuffering(dgvYotei)

        With dgvYotei
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 17
            .ColumnHeadersDefaultCellStyle.Font = New Font("MS UI Gothic", 7)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowTemplate.Height = 15
            .RowHeadersWidth = 25
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.SelectionBackColor = Color.White
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
        End With

        '列追加、空の行追加
        Dim dt As New DataTable()
        dt.Columns.Add("Ymd", Type.GetType("System.String"))
        dt.Columns.Add("Youbi", Type.GetType("System.String"))
        dt.Columns.Add("Sdn", Type.GetType("System.String"))
        dt.Columns.Add("Syk1", Type.GetType("System.String"))
        dt.Columns.Add("Syk2", Type.GetType("System.String"))
        dt.Columns.Add("DS", Type.GetType("System.String"))
        dt.Columns.Add("Hlpr", Type.GetType("System.String"))
        dt.Columns.Add("NH", Type.GetType("System.String"))

        For i = 0 To 30
            Dim row As DataRow = dt.NewRow()
            dt.Rows.Add(row)
        Next

        '表示
        dgvYotei.DataSource = dt

        '幅設定等
        With dgvYotei
            With .Columns("Ymd")
                .HeaderText = "年月日"
                .Width = 74
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("Youbi")
                .HeaderText = "曜日"
                .Width = 35
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle = readOnlyCellStyle
                .ReadOnly = True
            End With
            With .Columns("Sdn")
                .HeaderText = "相談員"
                .Width = 42
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Syk1")
                .HeaderText = "宿直1"
                .Width = 42
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Syk2")
                .HeaderText = "宿直2"
                .Width = 42
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Ds")
                .HeaderText = "DS"
                .Width = 42
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Hlpr")
                .HeaderText = "Hlpr"
                .Width = 42
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Nh")
                .HeaderText = "NH"
                .Width = 42
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End With

    End Sub

    ''' <summary>
    ''' 掲示板表示
    ''' </summary>
    ''' <param name="ymd"></param>
    Private Sub displayBoard(ymd As String)
        clearInputBoard()

        '日付
        dateLabel.Text = formatDateStr(ymd)

        'データ取得、表示
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Board)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Brd where Ymd='" & ymd & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            'コメント
            cmntLabel.Text = Util.checkDBNullValue(rs.Fields("Cmnt").Value)
            '特養
            nhLabel.Text = Util.checkDBNullValue(rs.Fields("Nh").Value)
            nhTextBox.Text = Util.checkDBNullValue(rs.Fields("NhTxt").Value)
            'ショートステイ
            Dim ssCount As Integer = 0
            For i As Integer = 1 To 10
                Dim nam As String = Util.checkDBNullValue(rs.Fields("S" & i).Value)
                If nam <> "" Then
                    DirectCast(Controls("s" & i & "TextBox"), TextBox).Text = nam
                    ssCount += 1
                End If
            Next
            ssLabel.Text = ssCount
            'デイサービス
            dsLabel.Text = Util.checkDBNullValue(rs.Fields("Ds").Value)
            dsTextBox.Text = Util.checkDBNullValue(rs.Fields("DsTxt").Value)
            '支援ハウス
            snTextBox.Text = Util.checkDBNullValue(rs.Fields("SnTxt").Value)
            'ヘルパー
            hlprLabel.Text = Util.checkDBNullValue(rs.Fields("Hlpr").Value)
            hlprTextBox.Text = Util.checkDBNullValue(rs.Fields("HlprTxt").Value)
            '居宅
            kyoTextBox.Text = Util.checkDBNullValue(rs.Fields("KyoTxt").Value)
            'その他
            hokTextBox.Text = Util.checkDBNullValue(rs.Fields("HokTxt").Value)
            '本日の待機
            sdnTextBox.Text = Util.checkDBNullValue(rs.Fields("Sdn").Value) '生活相談員待機
            nsTextBox.Text = Util.checkDBNullValue(rs.Fields("Ns").Value) '看護師待機
            tok1TextBox.Text = Util.checkDBNullValue(rs.Fields("Tok1").Value) '特養・夜勤者
            tok2TextBox.Text = Util.checkDBNullValue(rs.Fields("Tok2").Value) '特養・夜勤者
            tok3TextBox.Text = Util.checkDBNullValue(rs.Fields("Tok3").Value) '特養・夜勤者
            tok4TextBox.Text = Util.checkDBNullValue(rs.Fields("Tok4").Value) '特養・夜勤者
            syk1TextBox.Text = Util.checkDBNullValue(rs.Fields("Syk1").Value) '宿直者
            syk2TextBox.Text = Util.checkDBNullValue(rs.Fields("Syk2").Value) '宿直者

            rs.Close()
            cnn.Close()
        ElseIf rs.RecordCount = 0 AndAlso editModeCheckBox.Checked Then
            rs.Close()
            cnn.Close()
            loadMasterData()
        Else
            rs.Close()
            cnn.Close()
        End If
    End Sub

    ''' <summary>
    ''' dgv予定マスタ表示
    ''' </summary>
    ''' <param name="ym"></param>
    Private Sub displayDgvYotei(ym As String)
        'クリア
        clearInputYotei()

        '年月日、曜日部分表示
        Dim year As Integer = CInt(ym.Split("/")(0))
        Dim month As Integer = CInt(ym.Split("/")(1))
        Dim dt As New DateTime(year, month, 1)
        Dim firstDayOfWeek As Integer = dt.DayOfWeek '最初の曜日
        Dim lastDay As Integer = DateTime.DaysInMonth(year, month) '日数
        For i As Integer = 1 To lastDay
            Dim day As String = If(i < 10, "0" & i, i)
            dgvYotei("Ymd", i - 1).Value = ym & "/" & day
            dgvYotei("Youbi", i - 1).Value = dayArray((firstDayOfWeek + (i - 1)) Mod 7)
        Next

        'データ表示
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Board)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from EtcM where Ym='" & ym & "' order by Ymd"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim dd As Integer = CInt(Util.checkDBNullValue(rs.Fields("Ymd").Value).Split("/")(2))
            dgvYotei("Sdn", dd - 1).Value = Util.checkDBNullValue(rs.Fields("Sdn").Value)
            dgvYotei("Syk1", dd - 1).Value = Util.checkDBNullValue(rs.Fields("Syk1").Value)
            dgvYotei("Syk2", dd - 1).Value = Util.checkDBNullValue(rs.Fields("Syk2").Value)
            dgvYotei("Ds", dd - 1).Value = Util.checkDBNullValue(rs.Fields("Ds").Value)
            dgvYotei("Hlpr", dd - 1).Value = Util.checkDBNullValue(rs.Fields("Hlpr").Value)
            dgvYotei("Nh", dd - 1).Value = Util.checkDBNullValue(rs.Fields("Nh").Value)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

    End Sub

    ''' <summary>
    ''' dgvコメント表示
    ''' </summary>
    Private Sub displayDgvCmnt()
        dgvCmnt.Columns.Clear()
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Cmnt from CmntM order by Dy"
        cnn.Open(DB_Board)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "CmntM")
        dgvCmnt.DataSource = ds.Tables("CmntM")
        cnn.Close()

        '幅設定等
        With dgvCmnt
            With .Columns("Cmnt")
                .HeaderText = "コメント"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 344
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With
    End Sub

    ''' <summary>
    ''' マスタ読込処理
    ''' </summary>
    Private Sub loadMasterData()
        clearInputBoard()

        Dim ymd As String = YmdBox.getADStr()
        Dim ym As String = ymd.Substring(0, 7)
        Dim dd As Integer = CInt(ymd.Split("/")(2))

        '日付
        dateLabel.Text = formatDateStr(ymd)

        'コメント
        cmntLabel.Text = Util.checkDBNullValue(dgvCmnt("Cmnt", dd - 1).Value)

        'Brdから最新のデータ読込
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Board)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select top 1 * from Brd order by Ymd Desc"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            '特養
            nhTextBox.Text = Util.checkDBNullValue(rs.Fields("NhTxt").Value)
            'ショートステイ
            Dim ssCount As Integer = 0
            For i As Integer = 1 To 10
                Dim nam As String = Util.checkDBNullValue(rs.Fields("S" & i).Value)
                If nam <> "" Then
                    DirectCast(Controls("s" & i & "TextBox"), TextBox).Text = nam
                    ssCount += 1
                End If
            Next
            ssLabel.Text = ssCount
            'デイサービス
            dsTextBox.Text = Util.checkDBNullValue(rs.Fields("DsTxt").Value)
            '支援ハウス
            snTextBox.Text = Util.checkDBNullValue(rs.Fields("SnTxt").Value)
            'ヘルパー
            hlprTextBox.Text = Util.checkDBNullValue(rs.Fields("HlprTxt").Value)
            '居宅
            kyoTextBox.Text = Util.checkDBNullValue(rs.Fields("KyoTxt").Value)
            'その他
            hokTextBox.Text = Util.checkDBNullValue(rs.Fields("HokTxt").Value)
        End If
        rs.Close()

        '予定マスタからの読込
        rs = New ADODB.Recordset
        sql = "select * from EtcM where Ymd='" & ymd & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            sdnTextBox.Text = Util.checkDBNullValue(rs.Fields("Sdn").Value) '生活相談員待機
            syk1TextBox.Text = Util.checkDBNullValue(rs.Fields("Syk1").Value) '宿直者
            syk2TextBox.Text = Util.checkDBNullValue(rs.Fields("Syk2").Value) '宿直者
            nhLabel.Text = Util.checkDBNullValue(rs.Fields("Nh").Value)
            hlprLabel.Text = Util.checkDBNullValue(rs.Fields("Hlpr").Value)
            dsLabel.Text = Util.checkDBNullValue(rs.Fields("Ds").Value)
        End If
        rs.Close()
        cnn.Close()

        'Shiftから看護師待機を読込
        cnn.Open(DB_Shift)
        rs = New ADODB.Recordset
        sql = "select * from Mnth where Ym='" & ym & "' And (Gyo=0 Or Gyo=" & dd & ") order by Gyo Desc"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount = 2 Then
            Dim initialStr As String = Util.checkDBNullValue(rs.Fields("D1").Value) '漢字１文字
            rs.MoveNext()
            'Gyo=0のレコードから対象の苗字を探す
            For i As Integer = 0 To rs.Fields.Count - 1
                Dim nam As String = Util.checkDBNullValue(rs.Fields(i).Value)
                If nam <> "" AndAlso nam.Substring(0, 1) = initialStr Then
                    nam = nam.Replace(" ", "　")
                    nsTextBox.Text = nam.Split("　")(0)
                    Exit For
                End If
            Next
        End If
        rs.Close()
        cnn.Close()

        'Workから特養夜勤者読込
        cnn.Open(DB_Work)
        rs = New ADODB.Recordset
        sql = "select * from KinD where Ym='" & ym & "' order by Seq2"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim workStr As String = Util.checkDBNullValue(rs.Fields("Y" & dd).Value) '勤務名
            If workStr = "夜" OrElse workStr = "深" Then
                Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
                If nam <> "" Then
                    Dim seq2 As String = Util.checkDBNullValue(rs.Fields("Seq2").Value)
                    nam = nam.Replace(" ", "　").Split("　")(0)
                    If workStr = "夜" Then
                        If seq2.Substring(0, 1) = "2" Then
                            '2階の人用
                            tok1TextBox.Text = nam
                        Else
                            '3階と※の人用
                            tok2TextBox.Text = nam
                        End If
                    Else
                        If seq2.Substring(0, 1) = "2" Then
                            '2階の人用
                            tok3TextBox.Text = nam
                        Else
                            '3階と※の人用
                            tok4TextBox.Text = nam
                        End If
                    End If
                End If
            End If
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

    End Sub

    ''' <summary>
    ''' 履歴リスト取得、表示
    ''' </summary>
    Private Sub loadHistoryList()
        historyListBox.Items.Clear()
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Board)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Brd order by Ymd desc"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim ymd As String = Util.checkDBNullValue(rs.Fields("Ymd").Value)
            Dim year As Integer = CInt(ymd.Substring(0, 4))
            Dim month As Integer = CInt(ymd.Substring(5, 2))
            Dim day As Integer = CInt(ymd.Substring(8, 2))
            Dim youbi As String = "(" & New DateTime(year, month, day).ToString("ddd") & ")"
            Dim wareki As String = Util.convADStrToWarekiStr(ymd)
            historyListBox.Items.Add(wareki & youbi)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()
    End Sub

    Private Sub YmdBox_YmdTextChange(sender As Object, e As EventArgs) Handles YmdBox.YmdTextChange
        displayBoard(YmdBox.getADStr())
    End Sub

    Private Sub YmBox_YmdTextChange(sender As Object, e As EventArgs) Handles YmBox.YmdTextChange
        displayDgvYotei(YmBox.getADYmStr())
    End Sub

    Private Sub historyListBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles historyListBox.SelectedValueChanged
        Dim ymd As String = Util.convWarekiStrToADStr(historyListBox.Text.Substring(0, 9))
        YmdBox.setADStr(ymd)
    End Sub

    ''' <summary>
    ''' 和暦表記にフォーマット
    ''' </summary>
    ''' <param name="adStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function formatDateStr(adStr As String) As String
        If adStr = "" Then
            Return ""
        End If

        Dim day As String = dayArray(New DateTime(CInt(adStr.Substring(0, 4)), CInt(adStr.Substring(5, 2)), CInt(adStr.Substring(8, 2))).DayOfWeek)
        Dim warekiStr As String = Util.convADStrToWarekiStr(adStr)
        Dim kanji As String = Util.getKanji(warekiStr)
        Dim eraNum As String = CInt(warekiStr.Substring(1, 2))
        Dim monthNum As String = CInt(warekiStr.Substring(4, 2))
        Dim dateNum As String = CInt(warekiStr.Substring(7, 2))
        Return kanji & " " & eraNum & " 年 " & monthNum & " 月 " & dateNum & " 日 " & "(" & day & ")"
    End Function

    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvCmnt.CellPainting, dgvYotei.CellPainting
        '行ヘッダーかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.CellStyle.Font,
                indexRect,
                e.CellStyle.ForeColor,
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If

        '選択したセルに枠を付ける
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts
            pParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 編集モードチェックボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub editModeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles editModeCheckBox.CheckedChanged
        If editModeCheckBox.Checked Then
            loadMasterData()
        Else
            displayBoard(YmdBox.getADStr())
        End If
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim ymd As String = YmdBox.getADStr()
            Dim cnn As New ADODB.Connection
            cnn.Open(DB_Board)
            Dim cmd As New ADODB.Command()
            cmd.ActiveConnection = cnn
            cmd.CommandText = "delete from Brd where Ymd='" & ymd & "'"
            cmd.Execute()
            cnn.Close()

            '履歴リスト表示
            loadHistoryList()

            '再表示
            YmdBox.setADStr(ymd)
        End If
    End Sub

    ''' <summary>
    ''' 更新ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Board)
        Dim rs As ADODB.Recordset
        Dim sql As String

        'dgv予定マスタの更新
        Dim ym As String = YmBox.getADYmStr()
        Dim year As Integer = CInt(ym.Split("/")(0))
        Dim month As Integer = CInt(ym.Split("/")(1))
        Dim dt As New DateTime(year, month, 1)
        Dim lastDay As Integer = DateTime.DaysInMonth(year, month) '日数
        rs = New ADODB.Recordset
        sql = "select * from EtcM where Ym='" & ym & "' order by Ymd"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            For i As Integer = 0 To lastDay - 1
                rs.AddNew()
                rs.Fields("Ym").Value = ym
                rs.Fields("Ymd").Value = Util.checkDBNullValue(dgvYotei("Ymd", i).Value)
                rs.Fields("Sdn").Value = Util.checkDBNullValue(dgvYotei("Sdn", i).Value)
                rs.Fields("Syk1").Value = Util.checkDBNullValue(dgvYotei("Syk1", i).Value)
                rs.Fields("Syk2").Value = Util.checkDBNullValue(dgvYotei("Syk2", i).Value)
                rs.Fields("Ds").Value = Util.checkDBNullValue(dgvYotei("Ds", i).Value)
                rs.Fields("Hlpr").Value = Util.checkDBNullValue(dgvYotei("Hlpr", i).Value)
                rs.Fields("Nh").Value = Util.checkDBNullValue(dgvYotei("Nh", i).Value)
            Next
            rs.Update()
        Else
            '更新
            For i As Integer = 0 To rs.RecordCount - 1
                rs.Fields("Sdn").Value = Util.checkDBNullValue(dgvYotei("Sdn", i).Value)
                rs.Fields("Syk1").Value = Util.checkDBNullValue(dgvYotei("Syk1", i).Value)
                rs.Fields("Syk2").Value = Util.checkDBNullValue(dgvYotei("Syk2", i).Value)
                rs.Fields("Ds").Value = Util.checkDBNullValue(dgvYotei("Ds", i).Value)
                rs.Fields("Hlpr").Value = Util.checkDBNullValue(dgvYotei("Hlpr", i).Value)
                rs.Fields("Nh").Value = Util.checkDBNullValue(dgvYotei("Nh", i).Value)
                If i <> rs.RecordCount - 1 Then
                    rs.MoveNext()
                End If
            Next
            rs.Update()
        End If
        rs.Close()

        'dgvコメントの更新
        rs = New ADODB.Recordset
        sql = "select Cmnt from CmntM order by Dy"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            For i As Integer = 0 To 30
                rs.Fields("Cmnt").Value = Util.checkDBNullValue(dgvCmnt("Cmnt", i).Value)
                If i <> 30 Then
                    rs.MoveNext()
                End If
            Next
            rs.Update()
        End If
        rs.Close()

        'dgvBoardの更新
        Dim ymd As String = YmdBox.getADStr()
        rs = New ADODB.Recordset
        sql = "select * from Brd where Ymd='" & ymd & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            rs.AddNew()
        Else
            '更新確認
            Dim result As DialogResult = MessageBox.Show("既に登録されています。上書きしますか？", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result <> DialogResult.Yes Then
                rs.Close()
                cnn.Close()
                Return
            End If
        End If
        rs.Fields("Ymd").Value = ymd
        rs.Fields("Cmnt").Value = cmntLabel.Text
        rs.Fields("Nh").Value = nhLabel.Text
        rs.Fields("NhTxt").Value = nhTextBox.Text
        rs.Fields("S1").Value = s1TextBox.Text
        rs.Fields("S2").Value = s2TextBox.Text
        rs.Fields("S3").Value = s3TextBox.Text
        rs.Fields("S4").Value = s4TextBox.Text
        rs.Fields("S5").Value = s5TextBox.Text
        rs.Fields("S6").Value = s6TextBox.Text
        rs.Fields("S7").Value = s7TextBox.Text
        rs.Fields("S8").Value = s8TextBox.Text
        rs.Fields("S9").Value = s9TextBox.Text
        rs.Fields("S10").Value = s10TextBox.Text
        rs.Fields("Ds").Value = dsLabel.Text
        rs.Fields("DsTxt").Value = dsTextBox.Text
        rs.Fields("SnTxt").Value = snTextBox.Text
        rs.Fields("Hlpr").Value = hlprLabel.Text
        rs.Fields("HlprTxt").Value = hlprTextBox.Text
        rs.Fields("KyoTxt").Value = kyoTextBox.Text
        rs.Fields("HokTxt").Value = hokTextBox.Text
        rs.Fields("Sdn").Value = sdnTextBox.Text
        rs.Fields("Ns").Value = nsTextBox.Text
        rs.Fields("Tok1").Value = tok1TextBox.Text
        rs.Fields("Tok2").Value = tok2TextBox.Text
        rs.Fields("Tok3").Value = tok3TextBox.Text
        rs.Fields("Tok4").Value = tok4TextBox.Text
        rs.Fields("Syk1").Value = syk1TextBox.Text
        rs.Fields("Syk2").Value = syk2TextBox.Text
        rs.Update()
        rs.Close()
        cnn.Close()

        '再表示
        displayBoard(ymd)

        '履歴リスト再表示
        loadHistoryList()
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '日付
        Dim ymd As String = YmdBox.getADStr()

        'データ存在チェック
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Board)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Brd where Ymd='" & ymd & "'"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("印刷データがありません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cnn.Close()
            Return
        End If

        '印刷データ作成
        Dim ymdFormatStr As String = formatDateStr(ymd)
        Dim cmnt As String = Util.checkDBNullValue(rs.Fields("Cmnt").Value)
        Dim dataArray(48, 9) As String
        '特養
        dataArray(0, 0) = "本日のご入居者数は " & Util.checkDBNullValue(rs.Fields("Nh").Value) & " 名です。"
        dataArray(2, 0) = Util.checkDBNullValue(rs.Fields("NhTxt").Value)
        'ショート
        Dim ssCount As Integer = 0
        Dim ssArray(9) As String
        For i As Integer = 0 To 9
            Dim nam As String = Util.checkDBNullValue(rs.Fields("S" & (i + 1)).Value)
            ssArray(i) = nam
            If nam <> "" Then
                ssCount += 1
            End If
        Next
        dataArray(8, 0) = "本日のご利用者数は " & ssCount & " 名です。"
        dataArray(9, 0) = ssArray(0)
        dataArray(10, 0) = ssArray(1)
        dataArray(11, 0) = ssArray(2)
        dataArray(12, 0) = ssArray(3)
        dataArray(13, 0) = ssArray(4)
        dataArray(9, 4) = ssArray(5)
        dataArray(10, 4) = ssArray(6)
        dataArray(11, 4) = ssArray(7)
        dataArray(12, 4) = ssArray(8)
        dataArray(13, 4) = ssArray(9)
        'デイサービス
        dataArray(16, 0) = "本日のご利用者数は " & Util.checkDBNullValue(rs.Fields("Ds").Value) & " 名です。"
        dataArray(17, 0) = Util.checkDBNullValue(rs.Fields("DsTxt").Value)
        '支援ハウス
        dataArray(21, 0) = Util.checkDBNullValue(rs.Fields("SnTxt").Value)
        'ヘルパー
        dataArray(26, 0) = "本日のご利用者数は " & Util.checkDBNullValue(rs.Fields("Hlpr").Value) & " 名です。"
        dataArray(27, 0) = Util.checkDBNullValue(rs.Fields("HlprTxt").Value)
        '居宅
        dataArray(31, 0) = Util.checkDBNullValue(rs.Fields("KyoTxt").Value)
        'その他
        dataArray(36, 0) = Util.checkDBNullValue(rs.Fields("HokTxt").Value)
        '本日の待機者
        dataArray(42, 0) = "待機者は月曜日からの一週間交代になっています。"
        '生活相談員
        dataArray(44, 0) = Util.checkDBNullValue(rs.Fields("Sdn").Value)
        dataArray(44, 1) = "さん"
        '看護師
        dataArray(45, 0) = Util.checkDBNullValue(rs.Fields("Ns").Value)
        dataArray(45, 1) = "さん"
        '特養・夜勤者
        dataArray(46, 0) = Util.checkDBNullValue(rs.Fields("Tok1").Value)
        dataArray(46, 1) = "さん"
        dataArray(46, 2) = Util.checkDBNullValue(rs.Fields("Tok2").Value)
        dataArray(46, 3) = "さん、"
        dataArray(46, 4) = Util.checkDBNullValue(rs.Fields("Tok3").Value)
        dataArray(46, 5) = "さん、"
        dataArray(46, 6) = Util.checkDBNullValue(rs.Fields("Tok4").Value)
        dataArray(46, 7) = "さん"
        dataArray(47, 4) = "(深夜)"
        dataArray(47, 6) = "(深夜)"
        '宿直
        dataArray(48, 3) = "本日の宿直は"
        dataArray(48, 4) = Util.checkDBNullValue(rs.Fields("Syk1").Value)
        dataArray(48, 5) = "さん、"
        dataArray(48, 6) = Util.checkDBNullValue(rs.Fields("Syk2").Value)
        dataArray(48, 7) = "さん"

        rs.Close()
        cnn.Close()

        'エクセル準備
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("Board改")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '日付
        oSheet.Range("B3").Value = ymdFormatStr
        'コメント
        oSheet.Range("B5").Value = cmnt

        'データ貼り付け
        oSheet.Range("F7", "O55").Value = dataArray

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If printState = "Y" Then
            oSheet.PrintOut()
        ElseIf printState = "N" Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub
End Class
