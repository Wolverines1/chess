'Option Strict On

Class FirstPrint
    Private coordStartHeight As Integer = 0
    Private coordStartWidth As Integer = 0
    Private sizeField As Integer = 0

    Public Sub board()
        'Field size 
        'sizeField = Form1.Size.Height \ 10
        sizeField = (Form1.Size.Width * 0.45) \ 8
        'coordinate height field a8
        coordStartHeight = 2
        'coordinate width field a8
        coordStartWidth = 6
        'print board (64)
        printBoard(coordStartHeight, coordStartWidth, sizeField)
    End Sub

    'Print the board (64 PictureBox)
    Public Sub printBoard(ByVal coorH As Integer, ByVal coorW As Integer, ByVal size As Integer)
        'coorH - coordinate height field a8 
        'coorW - coordinate width field a8
        'size - field size

        'coorHtmp - coordinate height field a1!
        Dim coorHtmp As Integer = coorH + 7 * size
        'coorWtmp - coordinate width field a1!
        Dim coorWtmp As Integer = coorW

        Dim i, k As Integer
        Dim index As Integer = 0

        'Print all the fields, starting from the a1 field,
        'first 1 horizontal (a1-h1),
        'then 2 horizontal (a2-h2) ...
        For i = 0 To 7
            For k = 0 To 7
                printPictureBox(index, coorHtmp, coorWtmp, size)
                coorWtmp += size
                index += 1
            Next k
            'Go to the next horizontal (1-8)
            coorHtmp -= size
            'Go to the beginning, vertical a (a2, a3, ... ,a8)
            coorWtmp = coorW
        Next i
    End Sub

    Public Sub printPictureBox(ByVal index As Integer, ByVal coorH As Integer, ByVal coorW As Integer, ByVal size As Integer)
        Form1.arrPictureBox(index).Top = coorH
        Form1.arrPictureBox(index).Left = coorW
        Form1.arrPictureBox(index).Height = size
        Form1.arrPictureBox(index).Width = size
    End Sub

    Public Sub printListBoxen()
        'Chess blank
        Form1.ListBox1.Top = sizeField
        Form1.ListBox1.Left = (Form1.Size.Width \ 2) + (5.5 * sizeField)
        'Blank length = 6 fields 
        Form1.ListBox1.Height = 6 * sizeField
        Form1.ListBox1.Width = Form1.Size.Width \ 8

        Dim frontier As Integer = Form1.Size.Width \ 2 + sizeField \ 2
        Form1.ListBox2.Top = sizeField * 4
        Form1.ListBox2.Left = frontier
        Form1.ListBox2.Height = 3 * sizeField
        'Form1.ListBox2.Width = Form1.Size.Width \ 4 - Form1.Size.Width \ 60
        Form1.ListBox2.Width = Form1.Size.Width \ 4
    End Sub

    Public Sub printAllButtons()
        Dim frontier As Integer = Form1.Size.Width \ 2 + sizeField \ 2
        Dim standardHeight As Integer = Form1.Size.Height \ 18
        Dim standardHeight2 As Integer = Form1.Size.Height \ 22
        Dim Listbox1Left As Integer = (Form1.Size.Width \ 2) + (5.5 * sizeField)
        Dim ListBox1Width As Integer = Form1.Size.Width \ 8
        Dim Listbox2Width As Integer = Form1.Size.Width \ 4

        '----------Form1.Button1_Color----------
        Form1.Button1.Top = sizeField * 7
        Form1.Button1.Left = frontier
        Form1.Button1.Height = sizeField \ 3
        Form1.Button1.Width = sizeField
        Form1.Button1.Text = "next"

        '----------Form1.Label_sec------------
        Form1.Label_sec.Top = sizeField \ 15
        Form1.Label_sec.Left = frontier
        Form1.Label_sec.Height = standardHeight
        Form1.Label_sec.Width = standardHeight

        Dim imgKrug As New Bitmap(My.Resources.krug)
        Dim img2Krug As New Bitmap(imgKrug, Form1.Label_sec.Width, Form1.Label_sec.Height)
        Form1.Label_sec.Image = img2Krug
        '-------------------------------------

        '----------Form1.L_Info----------
        Form1.L_Info.Top = 2
        Form1.L_Info.Left = frontier + sizeField
        Form1.L_Info.Height = sizeField \ 2 + standardHeight \ 3
        Form1.L_Info.Width = sizeField

        Form1.L_Info.Text = "1 - all     " & vbNewLine & "2 - white" & vbNewLine & "3 - black"
        Form1.L_Info.BorderStyle = BorderStyle.None
        '-------------------------------------

        '----------------------------------------------------------------
        'TextBox1, TextBox2, TextBox3, B_trenirovka

        '----------Form1.TextBox1----------
        Form1.TextBox1.Top = 5
        Form1.TextBox1.Left = frontier + 2 * sizeField
        Form1.TextBox1.Height = standardHeight / 2
        Form1.TextBox1.Width = standardHeight

        '----------Form1.TextBox2----------
        Form1.TextBox2.Top = Form1.TextBox1.Top + Form1.TextBox1.Height
        Form1.TextBox2.Left = frontier + 2 * sizeField
        Form1.TextBox2.Height = standardHeight / 2
        Form1.TextBox2.Width = standardHeight

        '----------Form1.TextBox3----------
        Form1.TextBox3.Top = Form1.TextBox2.Top + Form1.TextBox2.Height
        Form1.TextBox3.Left = frontier + 2 * sizeField
        Form1.TextBox3.Height = standardHeight / 2
        Form1.TextBox3.Width = standardHeight

        '----------Form1.B_trenirovka----------
        Form1.B_trenirovka.Text = ""

        Form1.B_trenirovka.Top = 2
        Form1.B_trenirovka.Left = frontier + 2 * sizeField + standardHeight + 5
        Form1.B_trenirovka.Height = standardHeight
        Form1.B_trenirovka.Width = standardHeight

        Dim imgMode As New Bitmap(My.Resources.mode)
        Dim img2Mode As New Bitmap(imgMode, Form1.B_trenirovka.Width, Form1.B_trenirovka.Height)
        Form1.B_trenirovka.Image = img2Mode
        '----------------------------------------------------------------

        '---------Form1.B_start---------------------
        Form1.B_start.Height = Form1.Size.Height \ 15
        Form1.B_start.Width = Form1.Size.Height \ 15
        Form1.B_start.Top = sizeField
        Form1.B_start.Left = frontier + Listbox2Width \ 2 - Form1.B_start.Width \ 2

        Form1.B_start.Text = ""
        Dim imgStartEngine0 As New Bitmap(My.Resources.start)
        Dim img2StartEngine0 As New Bitmap(imgStartEngine0, Form1.B_start.Width, Form1.B_start.Height)
        Form1.B_start.Image = img2StartEngine0
        '----------------------------------------------------------------

        '----------Form1.L_all_statistik---------------
        Form1.L_all_statistik.Top = sizeField * 2
        Form1.L_all_statistik.Left = frontier
        Form1.L_all_statistik.Height = standardHeight / 2
        Form1.L_all_statistik.Width = sizeField * 0.9

        'diagram
        '----------Form1.Chart1---------------
        Form1.Chart1.Height = 2 * sizeField * 8 \ 10
        Form1.Chart1.Width = 3 * sizeField * 8 \ 10
        Form1.Chart1.Top = sizeField * 2
        Form1.Chart1.Left = frontier + Listbox2Width \ 2 - Form1.Chart1.Width \ 2
        '----------------------------------------------------------------

        '----------Form1.Label_statistik----------
        Form1.Label_statistik.Top = sizeField * 3.7
        Form1.Label_statistik.Left = frontier
        Form1.Label_statistik.Height = standardHeight / 2
        Form1.Label_statistik.Width = Listbox2Width
        '----------------------------------------------------------------

        '------------Form1.B_Read-------------
        Form1.B_Read.Top = sizeField * 8
        Form1.B_Read.Left = frontier
        Form1.B_Read.Height = standardHeight2
        Form1.B_Read.Width = Form1.Size.Height \ 5

        Form1.B_Read.Text = ""
        Dim imgRead As New Bitmap(My.Resources.read)
        Dim img2Read As New Bitmap(imgRead, Form1.B_Read.Width, Form1.B_Read.Height)
        Form1.B_Read.Image = img2Read
        '----------------------------------------------------------------

        '------------Form1.B_links------------------------------
        Form1.B_links.Top = 2
        Form1.B_links.Left = Listbox1Left
        Form1.B_links.Height = standardHeight2
        Form1.B_links.Width = standardHeight

        Form1.B_links.Text = ""
        Dim imgLinks As New Bitmap(My.Resources.links)
        Dim img2Links As New Bitmap(imgLinks, Form1.B_links.Width, Form1.B_links.Height)
        Form1.B_links.Image = img2Links
        '----------------------------------------------------------------

        '---------Form1.B_board_change------------------------
        Form1.B_board_change.Height = (Form1.Size.Height \ 19) * 7 \ 10
        Form1.B_board_change.Width = Form1.Size.Height \ 19
        Form1.B_board_change.Top = 2
        Form1.B_board_change.Left = Listbox1Left + ListBox1Width \ 2 - Form1.B_board_change.Width \ 2

        Form1.B_board_change.Text = ""
        Dim imgPovorot As New Bitmap(My.Resources.povorot)
        Dim img2Povorot As New Bitmap(imgPovorot, Form1.B_board_change.Width, Form1.B_board_change.Height)
        Form1.B_board_change.Image = img2Povorot
        '----------------------------------------------------------------

        '------------Form1.B_rechts---------------------------------
        Form1.B_rechts.Height = standardHeight2
        Form1.B_rechts.Width = standardHeight
        Form1.B_rechts.Top = 2
        Form1.B_rechts.Left = Listbox1Left + ListBox1Width - Form1.B_rechts.Width

        Form1.B_rechts.Text = ""
        Dim imgRechts As New Bitmap(My.Resources.rechts)
        Dim img2Rechts As New Bitmap(imgRechts, Form1.B_rechts.Width, Form1.B_rechts.Height)
        Form1.B_rechts.Image = img2Rechts
        '----------------------------------------------------------------

        '------------Form1.B_minus------------------------
        Form1.B_minus.Height = standardHeight2
        Form1.B_minus.Width = standardHeight2
        Form1.B_minus.Top = sizeField - Form1.B_minus.Height
        Form1.B_minus.Left = Listbox1Left

        Form1.B_minus.Text = ""
        Dim imgMinus As New Bitmap(My.Resources.minus)
        Dim img2Minus As New Bitmap(imgMinus, Form1.B_minus.Width, Form1.B_minus.Height)
        Form1.B_minus.Image = img2Minus
        '----------------------------------------------------------------

        '------------Form1.B_plus------------------------
        Form1.B_plus.Height = standardHeight2
        Form1.B_plus.Width = standardHeight2
        Form1.B_plus.Top = sizeField - Form1.B_minus.Height
        Form1.B_plus.Left = Listbox1Left + ListBox1Width - Form1.B_plus.Width

        Form1.B_plus.Text = ""
        Dim imgPlus As New Bitmap(My.Resources.plus)
        Dim img2Plus As New Bitmap(imgPlus, Form1.B_plus.Width, Form1.B_plus.Height)
        Form1.B_plus.Image = img2Plus
        '----------------------------------------------------------------

        '---------Form1.B_nazad------------------------
        Form1.B_nazad.Top = sizeField * 7
        Form1.B_nazad.Left = Listbox1Left
        Form1.B_nazad.Height = standardHeight2
        Form1.B_nazad.Width = standardHeight2

        Form1.B_nazad.Text = ""
        Dim imgStrelkaNazad As New Bitmap(My.Resources.StrelkaNazad)
        Dim img2StrelkaNazad As New Bitmap(imgStrelkaNazad, Form1.B_nazad.Width, Form1.B_nazad.Height)
        Form1.B_nazad.Image = img2StrelkaNazad
        '----------------------------------------------------------------

        '------------Form1.B_delete_move---------------------
        Form1.B_delete_move.Height = standardHeight2
        Form1.B_delete_move.Width = standardHeight2
        Form1.B_delete_move.Top = sizeField * 7
        Form1.B_delete_move.Left = Listbox1Left + ListBox1Width \ 2 - Form1.B_delete_move.Width \ 2

        Form1.B_delete_move.Text = ""
        Dim imgDelete As New Bitmap(My.Resources.delete)
        Dim img2Delete As New Bitmap(imgDelete, Form1.B_delete_move.Width, Form1.B_delete_move.Height)
        Form1.B_delete_move.Image = img2Delete
        '----------------------------------------------------------------

        '---------Form1.B_vpered------------------------
        Form1.B_vpered.Height = standardHeight2
        Form1.B_vpered.Width = standardHeight2
        Form1.B_vpered.Top = sizeField * 7
        Form1.B_vpered.Left = Listbox1Left + ListBox1Width - Form1.B_vpered.Width

        Form1.B_vpered.Text = ""
        Dim imgStrelkaVpered As New Bitmap(My.Resources.StrelkaVpered)
        Dim img2StrelkaVpered As New Bitmap(imgStrelkaVpered, Form1.B_vpered.Width, Form1.B_vpered.Height)
        Form1.B_vpered.Image = img2StrelkaVpered
        '----------------------------------------------------------------

        '------------Form1.B_save------------------------
        Form1.B_save.Height = Form1.Size.Height \ 17
        Form1.B_save.Width = Form1.Size.Height \ 17
        Form1.B_save.Top = 8 * sizeField
        Form1.B_save.Left = Listbox1Left + ListBox1Width \ 2 - Form1.B_save.Width \ 2

        Form1.B_save.Text = ""
        Dim imgSave As New Bitmap(My.Resources.save)
        Dim img2Save As New Bitmap(imgSave, Form1.B_save.Width, Form1.B_save.Height)
        Form1.B_save.Image = img2Save
        '----------------------------------------------------------------

        '----------Form1.Label_Color----------
        Form1.Label_Color.Height = sizeField \ 3
        Form1.Label_Color.Width = sizeField \ 3
        Form1.Label_Color.Top = sizeField \ 15
        Form1.Label_Color.Left = Form1.Size.Width - 2 * Form1.Label_Color.Width
        '-------------------------------------

        '----------Form1.B_clear--------------
        Form1.B_clear.Height = sizeField \ 2
        Form1.B_clear.Width = sizeField \ 2
        Form1.B_clear.Top = sizeField * 7
        Form1.B_clear.Left = frontier + sizeField * 4

        Form1.B_clear.Text = ""
        Dim imgStartEngine As New Bitmap(My.Resources.waterdrop)
        Dim img2StartEngine As New Bitmap(imgStartEngine, Form1.B_clear.Width, Form1.B_clear.Height)
        Form1.B_clear.Image = img2StartEngine
        '-------------------------------------

        '------------Form1.B_form------------------------
        Form1.B_form.Height = sizeField \ 3
        Form1.B_form.Width = sizeField
        Form1.B_form.Top = sizeField * 7
        Form1.B_form.Left = frontier + sizeField * 2
        Form1.B_form.Text = "sort"
        '-------------------------------------

        'invisible at the beginning! 
        '---------Form1.PictureBox64---------------------
        Form1.PictureBox64.Height = sizeField * 0.85
        Form1.PictureBox64.Width = sizeField * 0.85
        Form1.PictureBox64.Top = 2
        Form1.PictureBox64.Left = Listbox1Left - 1.5 * Form1.PictureBox64.Width
        '-------------------------------------
    End Sub

    Public Sub set_start_values()
        Form1.B_nazad.Enabled = True
        Form1.B_vpered.Enabled = True
        Form1.B_delete_move.Enabled = True
        Form1.B_save.Enabled = True
        Form1.B_trenirovka.Enabled = False
        'ListBox2.Items.Clear()
        Form1.ListBox1.Items.Clear()

        Form1.clickedMove = 0
        Form1.indexAllMoves = 0
        Form1.moveNumber = 0
        'Form1.indexAllMoveCopy = 0
        Form1.nomerHodaCopy = 0
        Form1.nowMoveIndex = 0
        Form1.mode = 0

        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.startingPosition()

        Dim Ob2 As PrintPosition = New PrintPosition()
        Ob2.PrintAllFields()

        'Dim imgSave As New Bitmap(My.Resources.save)
        'Dim img2Save As New Bitmap(imgSave, Form1.B_save.Width * 9 \ 10, Form1.B_save.Height * 9 \ 10)
        'Form1.B_save.Image = img2Save
    End Sub

    Public Sub disable()
        Dim k As Integer
        For k = 0 To 63
            'arrPictureBox(k).BorderStyle = BorderStyle.FixedSingle
            Form1.arrPictureBox(k).Visible = False
        Next k
    End Sub
End Class
