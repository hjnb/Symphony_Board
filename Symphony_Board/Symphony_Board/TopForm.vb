Imports System.Data.OleDb

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

        'データグリッドビュー初期設定
        initDgvYotei()
        initDgvCmnt()
        displayDgvCmnt()

        '現在日付セット
        YmdBox.setADStr(Today.ToString("yyyy/MM/dd"))
        YmBox.setADStr(Today.ToString("yyyy/MM/dd"))

        '非表示
        YmdBox.Visible = False
        yoteiGroupBox.Visible = False

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
        End If
        rs.Close()
        cnn.Close()
    End Sub

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


End Class
