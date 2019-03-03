Public Class TopForm
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
    ''' 入力内容クリア
    ''' </summary>
    Private Sub clearInput()
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

    Private Sub displayBoard(ymd As String)
        clearInput()

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
End Class
