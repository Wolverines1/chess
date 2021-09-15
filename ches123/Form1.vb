'Option Strict On

Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Dim SendKeys As Object
    Public Property fso As Object
    Public Property fso2 As Object
    Public Property koren As Object
    Private Property FilesInKoren As Object
    Public Property Podpapki As Object
    Public Property FileInodPapka As Object

    Public pathFileVariant As String = ""
    Public pathRoot As String
    Public pathFileVariantWithName As String

    Public saveVersion As Integer = 0
    Public moveNumberReal As Integer = 0
    Public indexAllMoves As Integer = 0
    Public moveNumber As Integer = 0
    'Public indexAllMoveCopy As Integer = 0
    Public nomerHodaCopy As Integer = 0
    Public clickedMove As Integer = 0
    Public boardChanged As Integer = 0
    Public nowMoveIndex As Integer = 0

    Public mode As Integer = 0
    Public indexAllMoveEND As Integer = 0
    Public indexTraining As Integer = 0
    Public secondProZug As Integer = 10
    'For timer2
    Public secondProSave As Integer = 2

    Public fertig As Integer = 10
    Public readMode As Integer = 0
    Public form As Integer = 0

    Public parol As String = ""

    Public itemKlicked As Integer = 0

    Public strFolder As String = ""

    Public arrayPosition(63) As Integer
    Public nowMove(3) As Integer
    Public AllMoves(2000) As Integer

    Public arrayMovesWhite() As String
    Public arrayMovesBlack() As String

    Public nowTrening(1) As Integer

    Public arrButton() As Button
    Public arrPictureBox() As PictureBox

    Public beatField As Integer = -1

    Public numberRepeat As Integer = 2
    Public indexRepeat As Integer = 0

    Public numberOptions As Integer = 0
    Public arrSortString(2000) As String

    Public arrSortName(2000) As Integer
    Public arrSortDataBorn(2000) As Integer
    Public arrSortDataRepeat(2000) As Integer
    Public arrSortProcent(2000) As Integer
    Public arrSortNumberAttempts(2000) As Integer

    Public indexSort As Integer = 0
    Public indexSortRound As Integer = 0

    Public one As Integer = 1

    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        Button1.Visible = False
        B_form.Enabled = False
        B_Read.Visible = False
        Label_Color.Visible = False

        arrPictureBox = New PictureBox() {
            PictureBox0, PictureBox1, PictureBox2, PictureBox3, PictureBox4, PictureBox5, PictureBox6, PictureBox7,
            PictureBox8, PictureBox9, PictureBox10, PictureBox11, PictureBox12, PictureBox13, PictureBox14, PictureBox15,
            PictureBox16, PictureBox17, PictureBox18, PictureBox19, PictureBox20, PictureBox21, PictureBox22, PictureBox23,
            PictureBox24, PictureBox25, PictureBox26, PictureBox27, PictureBox28, PictureBox29, PictureBox30, PictureBox31,
            PictureBox32, PictureBox33, PictureBox34, PictureBox35, PictureBox36, PictureBox37, PictureBox38, PictureBox39,
            PictureBox40, PictureBox41, PictureBox42, PictureBox43, PictureBox44, PictureBox45, PictureBox46, PictureBox47,
            PictureBox48, PictureBox49, PictureBox50, PictureBox51, PictureBox52, PictureBox53, PictureBox54, PictureBox55,
            PictureBox56, PictureBox57, PictureBox58, PictureBox59, PictureBox60, PictureBox61, PictureBox62, PictureBox63}

        arrButton = New Button() {B_clear, B_board_change,
            B_links, B_rechts,
            B_nazad, B_vpered,
            B_minus, B_plus,
            B_save,
            B_Read, B_delete_move}

        create()

        'control()
    End Sub

    Public Sub create()
        Dim Ob1 As FirstPrint = New FirstPrint()

        'Ob1.disable()

        'Print the board (64 PictureBox)
        Ob1.board()

        'Print ListBoxen (chess blank and Varianten)
        Ob1.printListBoxen()

        'Print all (Buttons, Labels, TextBoxes)
        Ob1.printAllButtons()

        'set start values, draw starting position
        Ob1.set_start_values()

        T_parol.Visible = False
        B_parol.Visible = False
    End Sub

    'Parol
    Public Sub control()
        Dim Ob1 As ContolParol = New ContolParol()
        Ob1.parolGenerieren()
        Ob1.controlPassword()
    End Sub

    Private Sub B_parol_Click(sender As Object, e As EventArgs) Handles B_parol.Click
        Dim Ob1 As ContolParol = New ContolParol()
        Ob1.buttonParol()
    End Sub
    'Parol--------------------------------------------------------

    '--------------------------------------------------------------------------------------
    'set start values
    Public Sub Button_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_clear.Click
        Dim Ob1 As FirstPrint = New FirstPrint()
        Ob1.set_start_values()
    End Sub
    '--------------------------------------------------------------------------------------

    '--------------------------------------------------------------------------------------
    'ChangePosition
    'moveBack(), moveForward(), deleteMove(), My_Timer1(), PictureBoxsAnalysis(index)
    Public Sub B_nazad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_nazad.Click
        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.moveBack()
    End Sub

    Public Sub B_vpered_Click(sender As Object, e As EventArgs) Handles B_vpered.Click
        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.moveForward()
    End Sub

    Public Sub B_delete_move_Click(sender As Object, e As EventArgs) Handles B_delete_move.Click
        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.deleteMove()
    End Sub
    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.My_Timer1()
    End Sub
    Public Sub PictureBox_Click_Analysis(ByVal index As Integer)
        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.PictureBoxsAnalysis(index)
    End Sub
    '--------------------------------------------------------------------------------------

    Private Sub PictureBox0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox0.Click
        PictureBox_Click_Analysis(0)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox_Click_Analysis(1)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PictureBox_Click_Analysis(2)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        PictureBox_Click_Analysis(3)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        PictureBox_Click_Analysis(4)
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        PictureBox_Click_Analysis(5)
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        PictureBox_Click_Analysis(6)
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        PictureBox_Click_Analysis(7)
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        PictureBox_Click_Analysis(8)
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        PictureBox_Click_Analysis(9)
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        PictureBox_Click_Analysis(10)
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        PictureBox_Click_Analysis(11)
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        PictureBox_Click_Analysis(12)
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        PictureBox_Click_Analysis(13)
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        PictureBox_Click_Analysis(14)
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        PictureBox_Click_Analysis(15)
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        PictureBox_Click_Analysis(16)
    End Sub

    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        PictureBox_Click_Analysis(17)
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        PictureBox_Click_Analysis(18)
    End Sub

    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click
        PictureBox_Click_Analysis(19)
    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.Click
        PictureBox_Click_Analysis(20)
    End Sub

    Private Sub PictureBox21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox21.Click
        PictureBox_Click_Analysis(21)
    End Sub

    Private Sub PictureBox22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox22.Click
        PictureBox_Click_Analysis(22)
    End Sub

    Private Sub PictureBox23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox23.Click
        PictureBox_Click_Analysis(23)
    End Sub

    Private Sub PictureBox24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox24.Click
        PictureBox_Click_Analysis(24)
    End Sub

    Private Sub PictureBox25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.Click
        PictureBox_Click_Analysis(25)
    End Sub

    Private Sub PictureBox26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.Click
        PictureBox_Click_Analysis(26)
    End Sub

    Private Sub PictureBox27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox27.Click
        PictureBox_Click_Analysis(27)
    End Sub

    Private Sub PictureBox28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox28.Click
        PictureBox_Click_Analysis(28)
    End Sub

    Private Sub PictureBox29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox29.Click
        PictureBox_Click_Analysis(29)
    End Sub

    Private Sub PictureBox30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox30.Click
        PictureBox_Click_Analysis(30)
    End Sub

    Private Sub PictureBox31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox31.Click
        PictureBox_Click_Analysis(31)
    End Sub

    Private Sub PictureBox32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox32.Click
        PictureBox_Click_Analysis(32)
    End Sub

    Private Sub PictureBox33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox33.Click
        PictureBox_Click_Analysis(33)
    End Sub

    Private Sub PictureBox34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox34.Click
        PictureBox_Click_Analysis(34)
    End Sub

    Private Sub PictureBox35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox35.Click
        PictureBox_Click_Analysis(35)
    End Sub

    Private Sub PictureBox36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox36.Click
        PictureBox_Click_Analysis(36)
    End Sub

    Private Sub PictureBox37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox37.Click
        PictureBox_Click_Analysis(37)
    End Sub

    Private Sub PictureBox38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox38.Click
        PictureBox_Click_Analysis(38)
    End Sub

    Private Sub PictureBox39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox39.Click
        PictureBox_Click_Analysis(39)
    End Sub

    Private Sub PictureBox40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox40.Click
        PictureBox_Click_Analysis(40)
    End Sub

    Private Sub PictureBox41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox41.Click
        PictureBox_Click_Analysis(41)
    End Sub

    Private Sub PictureBox42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox42.Click
        PictureBox_Click_Analysis(42)
    End Sub

    Private Sub PictureBox43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox43.Click
        PictureBox_Click_Analysis(43)
    End Sub

    Private Sub PictureBox44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox44.Click
        PictureBox_Click_Analysis(44)
    End Sub

    Private Sub PictureBox45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox45.Click
        PictureBox_Click_Analysis(45)
    End Sub

    Private Sub PictureBox46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox46.Click
        PictureBox_Click_Analysis(46)
    End Sub

    Private Sub PictureBox47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox47.Click
        PictureBox_Click_Analysis(47)
    End Sub

    Private Sub PictureBox48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox48.Click
        PictureBox_Click_Analysis(48)
    End Sub

    Private Sub PictureBox49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox49.Click
        PictureBox_Click_Analysis(49)
    End Sub

    Private Sub PictureBox50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox50.Click
        PictureBox_Click_Analysis(50)
    End Sub

    Private Sub PictureBox51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox51.Click
        PictureBox_Click_Analysis(51)
    End Sub

    Private Sub PictureBox52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox52.Click
        PictureBox_Click_Analysis(52)
    End Sub

    Private Sub PictureBox53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox53.Click
        PictureBox_Click_Analysis(53)
    End Sub

    Private Sub PictureBox54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox54.Click
        PictureBox_Click_Analysis(54)
    End Sub

    Private Sub PictureBox55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox55.Click
        PictureBox_Click_Analysis(55)
    End Sub

    Private Sub PictureBox56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox56.Click
        PictureBox_Click_Analysis(56)
    End Sub

    Private Sub PictureBox57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox57.Click
        PictureBox_Click_Analysis(57)
    End Sub

    Private Sub PictureBox58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox58.Click
        PictureBox_Click_Analysis(58)
    End Sub

    Private Sub PictureBox59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox59.Click
        PictureBox_Click_Analysis(59)
    End Sub

    Private Sub PictureBox60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox60.Click
        PictureBox_Click_Analysis(60)
    End Sub

    Private Sub PictureBox61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox61.Click
        PictureBox_Click_Analysis(61)
    End Sub

    Private Sub PictureBox62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox62.Click
        PictureBox_Click_Analysis(62)
    End Sub

    Private Sub PictureBox63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox63.Click
        PictureBox_Click_Analysis(63)
    End Sub

    Private Sub Button_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_save.Click
        Dim Ob1 As Save = New Save()
        Ob1.savePartie()
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    'class ChangeBoard
    'flipBoard(), leftBoard(), rightBoard(), plusBoard(), minusBoard()
    Public Sub B_board_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_board_change.Click
        Dim Ob1 As ChangeBoard = New ChangeBoard()
        Ob1.flipBoard()
    End Sub

    Public Sub B_links_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_links.Click
        Dim Ob1 As ChangeBoard = New ChangeBoard()
        Ob1.leftBoard()
    End Sub

    Public Sub B_rechts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_rechts.Click
        Dim Ob1 As ChangeBoard = New ChangeBoard()
        Ob1.rightBoard()
    End Sub

    Public Sub B_plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_plus.Click
        Dim Ob1 As ChangeBoard = New ChangeBoard()
        Ob1.plusBoard()
    End Sub

    Public Sub B_minus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_minus.Click
        Dim Ob1 As ChangeBoard = New ChangeBoard()
        Ob1.minusBoard()
    End Sub
    '--------------------------------------------------------------------------------------------------------------

    '--------------------------------------------------------------------------------------------------------------
    'right click
    'remove/show unnecessary/necessary buttons 
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        B_board_change.Visible = False
        B_links.Visible = False
        B_rechts.Visible = False
        B_minus.Visible = False
        B_plus.Visible = False
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        B_board_change.Visible = True
        B_links.Visible = True
        B_rechts.Visible = True
        B_minus.Visible = True
        B_plus.Visible = True
    End Sub
    '--------------------------------------------------------------------------------------------------------------
    Private Sub B_Read_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Read.Click
        Dim Ob1 As OpenChessFile = New OpenChessFile()
        Ob1.openFile()
    End Sub

    Private Sub B_trenirovka_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_trenirovka.Click
        Me.PictureBox64.Image = My.Resources.waiting
        Button1.Visible = True
        'MsgBox("indexRepeat = " & indexRepeat)
        If readMode = 0 Then
            MsgBox("file not take!")
            Return
        End If
        fertig = 10

        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.startingPosition()

        Dim Ob2 As PrintPosition = New PrintPosition()
        Ob2.PrintAllFields()
        nowMoveIndex = 0

        ListBox1.Items.Clear()

        'mode = 1 for all
        'mode = 2 for white
        'mode = 3 for black

        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
            mode = CInt(TextBox1.Text)
            secondProZug = CInt(TextBox2.Text)
            numberRepeat = CInt(TextBox3.Text)
            B_nazad.Enabled = False
            B_vpered.Enabled = False
            B_delete_move.Enabled = False
            B_save.Enabled = False
        Else
            mode = 1
            secondProZug = 30
            numberRepeat = 1
            TextBox1.Text = "1"
            TextBox2.Text = "30"
            TextBox3.Text = "1"
            B_nazad.Enabled = False
            B_vpered.Enabled = False
            B_delete_move.Enabled = False
            B_save.Enabled = False
        End If
        Label_sec.Text = secondProZug.ToString

        If mode <> 1 And mode <> 2 And mode <> 3 Then
            MsgBox("false mode mumber")
            Return
        End If

        '!!!!!!!!!!!!!!!!!!!!!
        Timer1.Enabled = True
        '!!!!!!!!!!!!!!!!!!!!!

        If mode = 3 Then
            B_vpered_Click(SendKeys, New System.EventArgs())
            mode = 2
        End If

        'indexAllMoveEND = indexAllMoves
        'MsgBox(indexAllMoves)
        'indexTraining = 0

        'indexAllMoves = 0
        'If mode = 3 Then
        '    indexAllMoves += 4
        '    B_vpered_Click(SendKeys, New System.EventArgs())
        '    mode = 2
        'End If
        'MsgBox(mode.ToString)
    End Sub

    ' Private Sub KeyHandler_KeyDown(KeyCode As Integer, Shift As Integer)
    ' Dim intShiftDown As Integer, intAltDown As Integer
    ' Dim intCtrlDown As Integer

    '    ' Use bit masks to determine which key was pressed. 
    '    intShiftDown = (Shift And acShiftMask) > 0
    '    intAltDown = (Shift And acAltMask) > 0
    '   intCtrlDown = (Shift And acCtrlMask) > 0
    '' Display message telling user which key was pressed. 
    ' If intShiftDown Then MsgBox "You pressed the Shift key." 
    ' If intAltDown Then MsgBox "You pressed the Alt key." 
    ' If intCtrlDown Then MsgBox "You pressed the Ctrl key." 
    ' End Sub


    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If (e.KeyData = Keys.Right) Then
        'MsgBox("aaa")
        'End If
        'MsgBox("sss")
        'MsgBox("control = " + e.Control.ToString + ", shift = " + e.Shift.ToString + ", e.Keycode = " + e.KeyCode.ToString)
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'If (e.KeyData = Keys.Space) Then
        'MsgBox("aaa")
        'End If
        'If (e.KeyData = Keys.Right) Then
        'MsgBox("aaa2")
        'B_vpered_Click(sender, e)
        ' End If
    End Sub
    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "k" OrElse e.KeyChar = "K" Then
            MessageBox.Show("Pressed!")
            ListBox1.Items.Clear()
            Button_Clear_Click(sender, e)
            ListBox2.SetSelected(1, True)
            B_trenirovka_Click(sender, e)
            MsgBox("Pause")
            ListBox1.Items.Clear()
            Button_Clear_Click(sender, e)
            ListBox2.SetSelected(2, True)
            B_trenirovka_Click(sender, e)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If Len(ListBox2.Text) = 0 Then
            MsgBox("Empty ListBox2")
            Return
        End If

        ListBox1.Items.Clear()
        Button_Clear_Click(sender, e)
        Dim sss2 As String = ""
        sss2 += pathRoot
        Dim nameFile As String = ListBox2.SelectedItem.ToString()

        Dim nameFileReal As String = ""
        Dim i As Integer = 0
        'MsgBox(nameFile)
        While nameFile(i) <> " "
            nameFileReal += nameFile(i)
            i += 1
        End While
        'MsgBox("nameFileReal = " & nameFileReal)
        'MsgBox("nameFile = " & nameFile & vbNewLine & "nameFileReal = " & nameFileReal)

        Dim nameFileOhneTXT As String = Microsoft.VisualBasic.Strings.Left(nameFileReal, nameFileReal.Length - 4)
        sss2 += nameFileOhneTXT
        'dlja statistiki menjaju!!!

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        pathFileVariant = sss2

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'sss2 += ListBox1.SelectedItem.ToString()
        sss2 += "\"
        sss2 += nameFileReal

        Dim Ob1 As OpenChessFile = New OpenChessFile()
        Ob1.downloadFile(sss2)

        'MsgBox(sss)

        readMode = 1
        B_trenirovka.Enabled = True
    End Sub

    Private Sub B_start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_start.Click
        B_form.Enabled = True
        Button_Clear_Click(sender, e)
        Dim Ob1 As ShowStatistics = New ShowStatistics()
        Ob1.showDebutStatistics()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        numberRepeat -= 1
        TextBox3.Text = numberRepeat.ToString
        If numberRepeat <> 0 Then
            ListBox1.Items.Clear()
            Dim Ob1 As FirstPrint = New FirstPrint()
            Ob1.set_start_values()
            indexRepeat += 1
            'MsgBox("indexRepeat = " & indexRepeat)
            ListBox2.SetSelected(indexRepeat, True)
            B_trenirovka_Click(SendKeys, New System.EventArgs())
        Else
            indexRepeat = 0
            ListBox2.SetSelected(indexRepeat, True)
            MsgBox("No more options")
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'Saved the variant, change the smiley
        Dim imgOk As New Bitmap(My.Resources.ok)
        Dim img2Ok As New Bitmap(imgOk, B_save.Width * 8 \ 10, B_save.Height * 8 \ 10)
        B_save.Image = img2Ok

        'Time is up
        If secondProSave = 0 Then
            'Stop the timer
            Timer2.Enabled = False
            'Restore the smiley diskette
            Dim imgsave As New Bitmap(My.Resources.save)
            Dim img2save As New Bitmap(imgsave, B_save.Width * 8 \ 10, B_save.Height * 8 \ 10)
            B_save.Image = img2save
            'sec = 2
            secondProSave = 2
            'Exit
            Return
        End If
        secondProSave -= 1
    End Sub
    Private Sub B_form_Click(sender As Object, e As EventArgs) Handles B_form.Click
        If form = 0 Then
            Dim imgSave As New Bitmap(My.Resources.meer)
            Dim img2Save As New Bitmap(imgSave, Me.Width, Me.Height)
            Me.BackgroundImage = img2Save
            form = 1
            ' Else
            '    Dim null As Image = Nothing
            '    Me.BackgroundImage = null
            '    form = 0
        End If

        If one = 1 Then
            ReDim arrSortString(numberOptions - 1)
            For i = 0 To numberOptions - 1
                ListBox2.SetSelected(i, True)
                arrSortString(i) = ListBox2.SelectedItem.ToString
                'MsgBox(ListBox2.SelectedItem.ToString)
            Next i
            one = 0
        End If


        arraySort(arrSortString)

        'For i = 0 To numberOptions - 1
        '    MsgBox(arrSortString(i))
        'Next i
    End Sub

    Public Sub arraySort(ByVal arrSortString() As String)
        'arrSortName(2000) As Integer
        'arrSortDataBorn(2000) As Integer
        'arrSortDataRepeat(2000) As Integer
        'arrSortProcent(2000) As Integer
        'arrSortNumberAttempts(2000) As Integer

        'fill arrays of numbers
        For i = 0 To numberOptions - 1
            arraySort1String(arrSortString(i))
        Next i

        'For j = 0 To numberOptions - 1
        'MsgBox("arrSortName = " & arrSortName(j))
        'MsgBox("arrSortDataBorn = " & arrSortDataBorn(j))
        'MsgBox("arrSortDataRepeat = " & arrSortDataRepeat(j))
        'MsgBox("arrSortProcent = " & arrSortProcent(j))
        'MsgBox("arrSortNumberAttempts = " & arrSortNumberAttempts(j))
        ' Next j

        ListBox2.Items.Clear()

        If indexSortRound = 0 Then
            'MsgBox("sortMyProcent()")
            sortMyProcent()
            indexSortRound = 1
            Return
        End If
        If indexSortRound = 1 Then
            'MsgBox("sortMyNumberAttempts()")
            sortMyNumberAttempts()
            indexSortRound = 2
            Return
        End If
        If indexSortRound = 2 Then
            'MsgBox("sortMyName()")
            sortMyName()
            indexSortRound = 3
            Return
        End If
        If indexSortRound = 3 Then
            'MsgBox("sortMyDataBorn()")
            sortMyDataBorn()
            indexSortRound = 4
            Return
        End If
        If indexSortRound = 4 Then
            'MsgBox("sortMyDataRepeat()")
            sortMyDataRepeat()
            indexSortRound = 0
            B_form.Enabled = False
            Return
        End If

    End Sub

    Public Sub arraySort1String(ByVal str As String)
        'indexSort
        Dim SearchString As String = str
        '---------------------------------------------
        'arrSortName(2000) As Integer
        Dim SearchChar1Name As String = "_"
        Dim TestPos1Name As Integer
        TestPos1Name = InStr(1, SearchString, SearchChar1Name, CompareMethod.Binary)

        Dim e As Integer = 0
        Dim tempString1Name As String = ""
        For e = 0 To 1
            tempString1Name += SearchString.Chars(TestPos1Name + e)
        Next e
        'MsgBox("tempString1Name = " & tempString1Name)
        arrSortName(indexSort) = CInt(tempString1Name)
        'MsgBox("arrSortName(indexSort) = " & arrSortName(indexSort))
        '---------------------------------------------
        'arrSortDataBorn(2000) As Integer
        Dim SearchChar1DataBorn As String = " "
        Dim TestPos1DataBorn As Integer
        TestPos1DataBorn = InStr(1, SearchString, SearchChar1DataBorn, CompareMethod.Binary)
        'There are 3 spaces
        TestPos1DataBorn += 2

        Dim tempString1DataBorn As String = ""

        'Dim b As Integer = 0
        'For b = 0 To 9
        'tempString1DataBorn += SearchString.Chars(TestPos1DataBorn + b)
        'Next b

        Dim tempString1DataBorn1 As String = ""
        Dim b1 As Integer = 0
        For b1 = 6 To 9
            tempString1DataBorn1 += SearchString.Chars(TestPos1DataBorn + b1)
        Next b1

        Dim tempString1DataBorn2 As String = ""
        Dim b2 As Integer = 0
        For b2 = 3 To 4
            tempString1DataBorn2 += SearchString.Chars(TestPos1DataBorn + b2)
        Next b2

        Dim tempString1DataBorn3 As String = ""
        Dim b3 As Integer = 0
        For b3 = 0 To 1
            tempString1DataBorn3 += SearchString.Chars(TestPos1DataBorn + b3)
        Next b3

        tempString1DataBorn = tempString1DataBorn1 & tempString1DataBorn2 & tempString1DataBorn3

        'MsgBox("tempString1DataBorn = " & tempString1DataBorn)
        arrSortDataBorn(indexSort) = CInt(tempString1DataBorn)
        'MsgBox("arrSortDataBorn(indexSort) = " & arrSortDataBorn(indexSort))
        '---------------------------------------------
        'arrSortDataRepeat(2000) As Integer
        Dim SearchChar1Repeat As String = "|"
        Dim TestPos1Repeat As Integer
        TestPos1Repeat = InStr(1, SearchString, SearchChar1Repeat, CompareMethod.Binary)

        Dim tempString1Repeat As String = ""

        Dim tempString1Repeat1 As String = ""
        Dim r1 As Integer = 0
        For r1 = 6 To 9
            tempString1Repeat1 += SearchString.Chars(TestPos1Repeat + r1)
        Next r1

        Dim tempString1Repeat2 As String = ""
        Dim r2 As Integer = 0
        For r2 = 3 To 4
            tempString1Repeat2 += SearchString.Chars(TestPos1Repeat + r2)
        Next r2

        Dim tempString1Repeat3 As String = ""
        Dim r3 As Integer = 0
        For r3 = 0 To 1
            tempString1Repeat3 += SearchString.Chars(TestPos1Repeat + r3)
        Next r3

        tempString1Repeat = tempString1Repeat1 & tempString1Repeat2 & tempString1Repeat3

        'Dim r As Integer = 0
        'For r = 0 To 9
        'tempString1Repeat += SearchString.Chars(TestPos1Repeat + r)
        'Next r
        'MsgBox("tempString1Repeat = " & tempString1Repeat)
        arrSortDataRepeat(indexSort) = CInt(tempString1Repeat)
        'MsgBox("arrSortDataRepeat(indexSort) = " & arrSortDataRepeat(indexSort))
        '---------------------------------------------
        'success, attempts
        'arrSortProcent(2000) As Integer
        'arrSortNumberAttempts(2000) As Integer

        Dim SearchChar1 As String = "("
        Dim SearchChar2 As String = "/"
        Dim SearchChar3 As String = ")"

        Dim TestPos1 As Integer
        Dim TestPos2 As Integer
        Dim TestPos3 As Integer

        'Example: SearchString = (10/15)
        'TestPos1 = 1, TestPos2 = 4, TestPos3 = 7
        TestPos1 = InStr(1, SearchString, SearchChar1, CompareMethod.Binary)
        TestPos2 = InStr(1, SearchString, SearchChar2, CompareMethod.Binary)
        TestPos3 = InStr(1, SearchString, SearchChar3, CompareMethod.Binary)

        'Successful attempts, the size
        Dim size1Number As Integer
        'All attempts, the size
        Dim size2Number As Integer

        size1Number = TestPos2 - TestPos1 - 1
        size2Number = TestPos3 - TestPos2 - 1

        'Successful attempts, string
        Dim i As Integer = 0
        Dim tempString1 As String = ""
        For i = 0 To size1Number - 1
            tempString1 += SearchString.Chars(TestPos1 + i)
        Next i

        'All attempts, string
        Dim j As Integer = 0
        Dim tempString2 As String = ""
        For j = 0 To size2Number - 1
            tempString2 += SearchString.Chars(TestPos2 + j)
        Next j

        'Successful attempts, int
        Dim success As Integer = CInt(tempString1)
        'All attempts, int
        Dim attempts As Integer = CInt(tempString2)

        'MsgBox("success = " & success)
        'MsgBox("attempts = " & attempts)

        arrSortProcent(indexSort) = success * 100 \ attempts
        arrSortNumberAttempts(indexSort) = attempts

        'MsgBox("arrSortProcent(indexSort) = " & arrSortProcent(indexSort))
        'MsgBox("arrSortNumberAttempts(indexSort) = " & arrSortNumberAttempts(indexSort))
        indexSort += 1
    End Sub

    Public Sub sortMyProcent()
        Dim indexMin As Integer = 0

        Dim i As Integer
        For i = 0 To numberOptions - 1
            indexMin = suchenMin(arrSortProcent)
            'MsgBox("indexMin = " & indexMin)
            'MsgBox("arraySort1String(indexMin) = " & arrSortString(indexMin))
            ListBox2.Items.Add(arrSortString(indexMin))
            arrSortProcent(indexMin) = -1
        Next i
    End Sub

    Public Sub sortMyNumberAttempts()
        Dim indexMin As Integer = 0

        Dim i As Integer
        For i = 0 To numberOptions - 1
            indexMin = suchenMin(arrSortNumberAttempts)
            'MsgBox("indexMin = " & indexMin)
            'MsgBox("arraySort1String(indexMin) = " & arrSortString(indexMin))
            ListBox2.Items.Add(arrSortString(indexMin))
            arrSortNumberAttempts(indexMin) = -1
        Next i
    End Sub

    Public Sub sortMyName()
        Dim indexMin As Integer = 0

        Dim i As Integer
        For i = 0 To numberOptions - 1
            indexMin = suchenMin(arrSortName)
            'MsgBox("indexMin = " & indexMin)
            'MsgBox("arraySort1String(indexMin) = " & arrSortString(indexMin))
            ListBox2.Items.Add(arrSortString(indexMin))
            arrSortName(indexMin) = -1
        Next i
    End Sub

    Public Sub sortMyDataBorn()
        Dim indexMin As Integer = 0

        Dim i As Integer
        For i = 0 To numberOptions - 1
            indexMin = suchenMin(arrSortDataBorn)
            'MsgBox("indexMin = " & indexMin)
            'MsgBox("arraySort1String(indexMin) = " & arrSortString(indexMin))
            ListBox2.Items.Add(arrSortString(indexMin))
            arrSortDataBorn(indexMin) = -1
        Next i
    End Sub

    Public Sub sortMyDataRepeat()
        Dim indexMin As Integer = 0

        Dim i As Integer
        For i = 0 To numberOptions - 1
            indexMin = suchenMin(arrSortDataRepeat)
            'MsgBox("indexMin = " & indexMin)
            'MsgBox("arraySort1String(indexMin) = " & arrSortString(indexMin))
            ListBox2.Items.Add(arrSortString(indexMin))
            arrSortDataRepeat(indexMin) = -1
        Next i
    End Sub

    Function suchenMin(ByVal massiv() As Integer) As Integer
        Dim i As Integer
        Dim min As Integer = 100000000
        Dim indexMin As Integer = 0

        For i = 0 To numberOptions - 1
            If massiv(i) <= min And massiv(i) <> -1 Then
                min = massiv(i)
                indexMin = i
            End If
        Next i
        Return indexMin
    End Function
End Class
