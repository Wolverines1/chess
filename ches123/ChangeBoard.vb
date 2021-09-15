Public Class ChangeBoard
    Private sender As Object

    'Change white and black pieces 
    Public Sub flipBoard()
        'Form1.boardChanged = 0 -> White outside
        'Form1.boardChanged = 1 -> Black outside
        'It will be needed later when shifting the board 
        If Form1.boardChanged = 0 Then
            Form1.boardChanged = 1
        Else
            Form1.boardChanged = 0
        End If

        'Temporary coordinates (x,y)
        Dim tmpTop As Integer = 0
        Dim tmpLeft As Integer = 0

        'Transposition
        'a1 = arrPictureBox(0)
        'h8 = arrPictureBox(63)
        'tmp = a1
        'a1 = h8 
        'h8 = tmp 
        For k = 0 To 31
            tmpTop = Form1.arrPictureBox(k).Top
            tmpLeft = Form1.arrPictureBox(k).Left
            Form1.arrPictureBox(k).Top = Form1.arrPictureBox(63 - k).Top
            Form1.arrPictureBox(k).Left = Form1.arrPictureBox(63 - k).Left
            Form1.arrPictureBox(63 - k).Top = tmpTop
            Form1.arrPictureBox(63 - k).Left = tmpLeft
        Next k
    End Sub

    'Move the board to the left 
    Public Sub leftBoard()
        'Find out the size of the field 
        Dim size As Integer = Form1.PictureBox0.Width

        'The left coordinate of the field a1 
        Dim left_a1 As Integer = 0

        Dim board As Integer = 0

        'If the Then board is upside down, turn it over.
        'So that the a1 field is at the bottom left. 
        If Form1.boardChanged = 0 Then
            left_a1 = Form1.PictureBox0.Left
        Else
            'The board is upside down.
            board = 1
            Form1.B_board_change_Click(sender, New System.EventArgs())
            left_a1 = Form1.PictureBox0.Left
        End If

        'If the distance to the left is more than 10 pixels,
        'then move the board to the left by 10 pixels.
        If left_a1 >= 10 Then
            left_a1 -= 10
        End If

        'Draw a board, back off from the top 2 pixels 
        Dim Ob1 As FirstPrint = New FirstPrint()
        Ob1.printBoard(2, left_a1, size)

        'If board = 1 Then
        '    Form1.B_board_change_Click(sender, New System.EventArgs())
        '    board = 0
        'End If
    End Sub

    'Move the board to the right 
    Public Sub rightBoard()
        'Find out the size of the field 
        Dim size As Integer = Form1.PictureBox0.Width

        'The right coordinate of the field h1
        Dim right_h1 As Integer = 0

        Dim board As Integer = 0

        'If the then board is upside down, turn it over.
        'So that the a1 field is at the bottom left.
        If Form1.boardChanged = 0 Then
            right_h1 = Form1.PictureBox7.Left + size
        Else
            'The board is upside down.
            board = 1
            Form1.B_board_change_Click(sender, New System.EventArgs())
            right_h1 = Form1.PictureBox7.Left + size
        End If

        'move the board to the right 10 pixels to the middle of the window width 
        If right_h1 < Form1.Size.Width / 2 Then
            right_h1 += 10
        End If

        'The left coordinate of the field a1 
        Dim left_a1 As Integer = right_h1 - 8 * size
        'Draw a board, back off from the top 2 pixels
        Dim Ob1 As FirstPrint = New FirstPrint()
        Ob1.printBoard(2, left_a1, size)

        'If board = 1 Then
        '    Form1.B_board_change_Click(sender, New System.EventArgs())
        '    board = 0
        'End If
    End Sub

    'Increase board size 
    Public Sub plusBoard()
        'Board is upside down, turn it over.
        'So that the a1 field is at the bottom left.
        If Form1.boardChanged = 1 Then
            Form1.B_board_change_Click(sender, New System.EventArgs())
        End If

        'Increase the size of all 64 fields by 5 pixels. 
        For k = 0 To 63
            Form1.arrPictureBox(k).Width += 5
            Form1.arrPictureBox(k).Height += 5
        Next k

        'The left coordinate of the field a1 
        Dim left_a1 As Integer = Form1.PictureBox0.Left
        'Find out the new size of the field 
        Dim size As Integer = Form1.PictureBox0.Width
        'Draw a board, back off from the top 2 pixels
        Dim Ob1 As FirstPrint = New FirstPrint()
        Ob1.printBoard(2, left_a1, size)
    End Sub

    'Reduce board size 
    Public Sub minusBoard()
        'Board is upside down, turn it over.
        'So that the a1 field is at the bottom left.
        If Form1.boardChanged = 1 Then
            Form1.B_board_change_Click(sender, New System.EventArgs())
        End If

        'Decrease the size of all 64 fields by 5 pixels 
        For k = 0 To 63
            Form1.arrPictureBox(k).Width -= 5
            Form1.arrPictureBox(k).Height -= 5
        Next k

        'The left coordinate of the field a1 
        Dim left_a1 As Integer = Form1.PictureBox0.Left
        'Find out the new size of the field 
        Dim size As Integer = Form1.PictureBox0.Width
        'Draw a board, back off from the top 2 pixels
        Dim Ob1 As FirstPrint = New FirstPrint()
        Ob1.printBoard(2, left_a1, size)

        'Dim imgSave As New Bitmap(My.Resources.meer)
        'Dim img2Save As New Bitmap(imgSave, Form1.Width, Form1.Height)
        'Form1.BackgroundImage = img2Save
    End Sub
End Class
