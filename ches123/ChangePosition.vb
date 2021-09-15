Class ChangePosition
    Dim SendKeys As Object

    'building the starting position 
    Public Sub startingPosition()

        'MsgBox("Now = " & Now & vbNewLine &
        '       "TimeOfDay = " & TimeOfDay & vbNewLine &
        '       "The current time is " & TimeString & vbNewLine &
        '      "Today = " & Today)

        '0   Empty field
        '1   Pawn
        '3   Knight 
        '4   Bishop 
        '5   Rook 
        '10  Queen 
        '100 King
        '-1  Black Pawn

        'arrayPosition(index)

        'index = 
        '0-7   (a1-h1) white pieces
        '8-15  (a2-h2) white pawns 
        '16-23 (a3-h3) empty fields
        '23-31 (a4-h4) empty fields
        '32-39 (a5-h5) empty fields
        '40-47 (a6-h6) empty fields
        '48-55 (a7-h7) black pawns 
        '56-63 (a8-h8) black pieces

        '(a1-h1) white pieces
        Form1.arrayPosition(0) = 5
        Form1.arrayPosition(1) = 3
        Form1.arrayPosition(2) = 4
        Form1.arrayPosition(3) = 10
        Form1.arrayPosition(4) = 100
        Form1.arrayPosition(5) = 4
        Form1.arrayPosition(6) = 3
        Form1.arrayPosition(7) = 5

        '(a2-h2) white pawns 
        Dim i As Integer
        For i = 8 To 15
            Form1.arrayPosition(i) = 1
        Next i

        '(a3-h6) empty fields
        Dim j As Integer
        For j = 16 To 47
            Form1.arrayPosition(j) = 0
        Next j

        '(a7-h7) black pawns 
        Dim k As Integer
        For k = 48 To 55
            Form1.arrayPosition(k) = -1
        Next k

        '(a8-h8) black pieces
        Form1.arrayPosition(56) = -5
        Form1.arrayPosition(57) = -3
        Form1.arrayPosition(58) = -4
        Form1.arrayPosition(59) = -10
        Form1.arrayPosition(60) = -100
        Form1.arrayPosition(61) = -4
        Form1.arrayPosition(62) = -3
        Form1.arrayPosition(63) = -5
    End Sub

    'clicked on the chessboard 
    Public Sub PictureBoxsAnalysis(ByVal index As Integer)
        'The move consists of two clicks
        'The first click is the start of move. 
        'The second click is the end of move. 
        '(Form1.clickedMove = 0) then the move has not started
        '(Form1.clickedMove = 1) then the move has started

        'At the beginning mode = 0
        'Print moves mode
        If Form1.mode = 0 Then
            'nowMove array consists of 4 elements of move
            'Kg1-Kf3 example
            'nowMove(0) = g1 - field index start of move
            'nowMove(1) = Knight - index of the piece that stood on the old field (now empty field) 
            'nowMove(2) = f3 - field index end of move
            'nowMove(3) = Knight - index of the piece that is now on the new field 

            'Start of move
            If Form1.clickedMove = 0 Then
                'Remove a picture from the clicked field
                Form1.arrPictureBox(index).Image = Nothing
                Form1.clickedMove = 1
                Form1.nowMove(0) = index
                Form1.nowMove(1) = Form1.arrayPosition(index)
                'change (Label_Color) color
                svetofor()
            Else
                'End of move
                Form1.clickedMove = 0
                Form1.nowMove(2) = index
                Form1.nowMove(3) = Form1.arrayPosition(index)
                'change (Label_Color) color
                svetofor()

                'clicked the wrong place, return the move by clicking on the same place
                If Form1.nowMove(0) = Form1.nowMove(2) Then
                    Form1.nowMove(0) = 0
                    Form1.nowMove(1) = 0
                    Form1.nowMove(2) = 0
                    Form1.nowMove(3) = 0
                    'redraw position
                    Dim Ob1 As PrintPosition = New PrintPosition()
                    Ob1.PrintAllFields()
                Else
                    'The move is made, you need to process it.
                    moveMove()
                End If
            End If
        Else
            'Workout mode
            'mode = 1,2
            'If mode = 3 (we repeat for black), then make 1 move for white
            'moveForward() and mode = 2!
            'Thus, there is no need to separately consider the case (mode = 3)
            modeFunk(index)
        End If
    End Sub

    'Make a move 
    Public Sub moveMove()
        'Move number
        'For example:
        'white move + black move = 2 moves 
        Form1.moveNumber += 1

        'nowMove array consists of 4 elements of move
        'AllMoves array consists of all elements (4 elements for 1 move) of all moves
        'Save 1 move to the general array AllMoves
        Form1.AllMoves(Form1.indexAllMoves) = Form1.nowMove(0)
        Form1.AllMoves(Form1.indexAllMoves + 1) = Form1.nowMove(1)
        Form1.AllMoves(Form1.indexAllMoves + 2) = Form1.nowMove(2)
        Form1.AllMoves(Form1.indexAllMoves + 3) = Form1.nowMove(3)

        'Preparing the index for the next move
        Form1.indexAllMoves += 4
        'Save index from current move
        Form1.nowMoveIndex = Form1.indexAllMoves

        'Check exception moves.
        '3 Exceptions (castling, en passant, pawn Promotion).
        Dim Ob0 As MoveException = New MoveException()
        Ob0.moveExceptions()

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'The field where the figure stood is now empty
        Form1.arrayPosition(Form1.nowMove(0)) = 0
        'Move the piece to a new field
        Form1.arrayPosition(Form1.nowMove(2)) = Form1.nowMove(1)
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'Draw position
        Dim Ob1 As PrintPosition = New PrintPosition()
        Ob1.PrintAllFields()

        'Write 1 move in the game form
        'In Form1.ListBox1
        Dim Ob2 As MoveIntepret = New MoveIntepret()
        Ob2.moveIntepretieren(Form1.AllMoves, Form1.moveNumber)
    End Sub

    'Delete move
    Public Sub deleteMove()
        'There is nothing to delete
        If Form1.moveNumber = 0 Then
            Return
        End If

        'Updating variables 
        Form1.moveNumber -= 1
        Form1.indexAllMoves -= 4
        Form1.nowMoveIndex = Form1.indexAllMoves

        'Actualization of the current move
        Form1.nowMove(0) = Form1.AllMoves(Form1.indexAllMoves)
        Form1.nowMove(1) = Form1.AllMoves(Form1.indexAllMoves + 1)
        Form1.nowMove(2) = Form1.AllMoves(Form1.indexAllMoves + 2)
        Form1.nowMove(3) = Form1.AllMoves(Form1.indexAllMoves + 3)

        'Check exception moves.
        '2 Exceptions (castling, en passant).
        Dim Ob0 As MoveException = New MoveException()
        Ob0.moveExceptionsBack()

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'Return move
        'Kg1-Kf3 example
        'nowMove(0) = g1 - field index start of move
        'nowMove(1) = Knight - index of the piece that stood on the old field (now empty field) 
        'nowMove(2) = f3 - field index end of move
        'nowMove(3) = Knight - index of the piece that is now on the new field 
        Form1.arrayPosition(Form1.nowMove(0)) = Form1.nowMove(1)
        Form1.arrayPosition(Form1.nowMove(2)) = Form1.nowMove(3)
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'Draw position
        Dim Ob1 As PrintPosition = New PrintPosition()
        Ob1.PrintAllFields()

        'Delete 1 move in the game form
        'In Form1.ListBox1
        Dim Ob2 As MoveIntepret = New MoveIntepret()
        Ob2.moveIntepretieren(Form1.AllMoves, Form1.moveNumber)
    End Sub

    Public Sub moveBack()
        Form1.B_vpered.Enabled = True

        'No moves
        If Form1.moveNumber = 0 Then
            Return
        End If

        'Start position
        If Form1.nowMoveIndex = 0 Then
            Form1.B_nazad.Enabled = False
            MsgBox("Start position")
            Return
        End If

        'Updating variable
        Form1.nowMoveIndex -= 4

        'Actualization of the current move
        Form1.nowMove(0) = Form1.AllMoves(Form1.nowMoveIndex)
        Form1.nowMove(1) = Form1.AllMoves(Form1.nowMoveIndex + 1)
        Form1.nowMove(2) = Form1.AllMoves(Form1.nowMoveIndex + 2)
        Form1.nowMove(3) = Form1.AllMoves(Form1.nowMoveIndex + 3)

        'Check exception moves.
        '2 Exceptions (castling, en passant).
        Dim Ob0 As MoveException = New MoveException()
        Ob0.moveExceptionsBack()

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'Return move
        'Kg1-Kf3 example
        'nowMove(0) = g1 - field index start of move
        'nowMove(1) = Knight - index of the piece that stood on the old field (now empty field) 
        'nowMove(2) = f3 - field index end of move
        'nowMove(3) = Knight - index of the piece that is now on the new field
        Form1.arrayPosition(Form1.nowMove(0)) = Form1.nowMove(1)
        Form1.arrayPosition(Form1.nowMove(2)) = Form1.nowMove(3)
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'Draw position
        Dim Ob1 As PrintPosition = New PrintPosition()
        Ob1.PrintAllFields()
    End Sub

    Public Sub moveForward()
        'Workout mode
        'Form1.mode = 1,2,3

        Form1.B_nazad.Enabled = True

        'The repetition of the variation is successful!!!
        'If Form1.nowMoveIndex = Form1.indexAllMoves And Form1.mode <> 0 Then
        'MsgBox("Anfangaaaa")
        ''Stop timer
        'Form1.Timer1.Enabled = False
        ''Draw victory smiley!
        'Form1.PictureBox64.Image = My.Resources.good
        ''update file statistik.txt
        ''1 means success
        'statistikFunk(1)
        'Return
        'End If

        'Viewing a party, not a workout!
        'Form1.mode = 0
        If Form1.nowMoveIndex = Form1.indexAllMoves And Form1.mode = 0 Then
            MsgBox("End of partie")
            Form1.B_vpered.Enabled = False
            Return
        End If

        'Actualization of the current move
        Form1.nowMove(0) = Form1.AllMoves(Form1.nowMoveIndex)
        Form1.nowMove(1) = Form1.AllMoves(Form1.nowMoveIndex + 1)
        Form1.nowMove(2) = Form1.AllMoves(Form1.nowMoveIndex + 2)
        Form1.nowMove(3) = Form1.AllMoves(Form1.nowMoveIndex + 3)

        'Updating variable
        Form1.nowMoveIndex += 4

        'Check exception moves.
        '3 Exceptions (castling, en passant, pawn Promotion).
        Dim Ob0 As MoveException = New MoveException()
        Ob0.moveExceptions()

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'The field where the figure stood is now empty
        Form1.arrayPosition(Form1.nowMove(0)) = 0
        'Move the piece to a new field
        Form1.arrayPosition(Form1.nowMove(2)) = Form1.nowMove(1)
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'Draw position
        Dim Ob2 As PrintPosition = New PrintPosition()
        Ob2.PrintAllFields()

        'Workout mode
        'Form1.mode = 1,2,3
        'The repetition of the variation is successful!!!
        If Form1.nowMoveIndex = Form1.indexAllMoves And Form1.mode <> 0 Then
            'Stop timer
            Form1.Timer1.Enabled = False
            'Draw victory smiley!
            Form1.PictureBox64.Image = My.Resources.good
            'update file statistik.txt
            '1 means success
            statistikFunk(1)
            Return
        End If
    End Sub

    'Workout mode
    Public Sub modeFunk(ByVal index As Integer)
        'mode = 1,2
        'Made a move in training mode, check how we repeat

        'mode = 1 -> repeat all moves (for white and black)
        'mode = 2 -> we only repeat our moves,
        'the program makes moves for the opponent

        'mode = 1 -> repeat all moves (for white and black)
        If Form1.mode = 1 Then
            'Array Form1.nowTrening() contains 2 elements
            'Kg1-Kf3 example
            'Form1.nowTrening(0) = g1 - field index start of move
            'Form1.nowTrening(1) = f3 - field index end of move
            'This is enough to compare the move for correctness.
            'It doesn't matter which figure moves!

            'Start of move
            If Form1.clickedMove = 0 Then
                'Remove a picture from the clicked field
                Form1.arrPictureBox(index).Image = Nothing
                Form1.clickedMove = 1
                Form1.nowTrening(0) = index
            Else
                'End of move
                Form1.clickedMove = 0
                Form1.nowTrening(1) = index

                'Сlicked the wrong place, return the move by clicking on the same place
                If Form1.nowTrening(0) = Form1.nowTrening(1) Then
                    Form1.nowTrening(0) = 0
                    Form1.nowTrening(1) = 0
                    'redraw position
                    Dim Ob1 As PrintPosition = New PrintPosition()
                    Ob1.PrintAllFields()
                    Return
                End If

                'Check if the move is correct
                If Form1.nowTrening(0) = Form1.AllMoves(Form1.nowMoveIndex) And Form1.nowTrening(1) = Form1.AllMoves(Form1.nowMoveIndex + 2) Then
                    'Move is correct

                    'Stop the timer
                    Form1.Timer1.Enabled = False
                    'Making a move on the board
                    Form1.B_vpered_Click(SendKeys, New System.EventArgs())

                    'MsgBox("move is made")

                    'If there are more moves, then set the timer again and start it
                    If Form1.nowMoveIndex <> Form1.indexAllMoves Then
                        'MsgBox("not the end")
                        If Form1.TextBox1.Text <> "" Then
                            Form1.secondProZug = CInt(Form1.TextBox2.Text)
                        Else
                            Form1.secondProZug = 30
                        End If
                        Form1.Timer1.Enabled = True
                    End If
                Else
                    'Move is not correct 

                    'Stop the timer
                    Form1.Timer1.Enabled = False
                    MsgBox("mistake!")
                    'Draw bad smiley
                    Form1.PictureBox64.Image = My.Resources.bad

                    'update file statistik.txt
                    '0 means failure
                    statistikFunk(0)

                    'Making the right move on the board 
                    Form1.mode = 0
                    Form1.B_vpered_Click(SendKeys, New System.EventArgs())
                    Return
                End If
            End If
        End If

        'mode = 2 -> repeat moves (for white or black)
        If Form1.mode = 2 Then
            'Array Form1.nowTrening() contains 2 elements
            'Kg1-Kf3 example
            'Form1.nowTrening(0) = g1 - field index start of move
            'Form1.nowTrening(1) = f3 - field index end of move
            'This is enough to compare the move for correctness.
            'It doesn't matter which figure moves!

            'Start of move
            If Form1.clickedMove = 0 Then
                'Remove a picture from the clicked field
                Form1.arrPictureBox(index).Image = Nothing
                Form1.clickedMove = 1
                Form1.nowTrening(0) = index
            Else
                'End of move
                Form1.clickedMove = 0
                Form1.nowTrening(1) = index

                'clicked the wrong place, return the move by clicking on the same place
                If Form1.nowTrening(0) = Form1.nowTrening(1) Then
                    Form1.nowTrening(0) = 0
                    Form1.nowTrening(1) = 0
                    'redraw position
                    Dim Ob1 As PrintPosition = New PrintPosition()
                    Ob1.PrintAllFields()
                    Return
                End If

                'Check if the move is correct
                If Form1.nowTrening(0) = Form1.AllMoves(Form1.nowMoveIndex) And Form1.nowTrening(1) = Form1.AllMoves(Form1.nowMoveIndex + 2) Then
                    'Move is correct

                    'Stop the timer
                    Form1.Timer1.Enabled = False

                    'Making a move on the board
                    Form1.B_vpered_Click(SendKeys, New System.EventArgs())

                    'If there are more moves, then make an answer from the opponent
                    If Form1.nowMoveIndex <> Form1.indexAllMoves Then
                        'MsgBox("move from the opponent")

                        'Move from the opponent
                        Form1.B_vpered_Click(SendKeys, New System.EventArgs())

                        'If there are more moves, then set the timer again and start it
                        If Form1.nowMoveIndex <> Form1.indexAllMoves Then
                            If Form1.TextBox1.Text <> "" Then
                                Form1.secondProZug = CInt(Form1.TextBox2.Text)
                            Else
                                Form1.secondProZug = 30
                            End If
                            Form1.Timer1.Enabled = True
                        End If
                    End If
                Else
                    'Move is not correct 

                    'Stop the timer
                    Form1.Timer1.Enabled = False
                    MsgBox("mistake!")
                    'Draw bad smiley
                    Form1.PictureBox64.Image = My.Resources.bad

                    'Update file statistik.txt
                    '0 means failure
                    statistikFunk(0)

                    'Making the right move on the board 
                    Form1.mode = 0
                    Form1.B_vpered_Click(SendKeys, New System.EventArgs())
                    Return
                End If
            End If
        End If
    End Sub

    Public Sub My_Timer1()
        Form1.Label_sec.Text = Form1.secondProZug.ToString
        If Form1.secondProZug = 0 Then
            Form1.Timer1.Enabled = False
            Form1.PictureBox64.Image = My.Resources.bad
            MsgBox("Time!!!")
            statistikFunk(0)
        End If
        Form1.secondProZug -= 1
    End Sub

    'Update file statistik.txt
    Public Sub statistikFunk(ByVal index As Integer)
        'If you have already evaluated this option,
        'then you do not need a second time
        If Form1.fertig = 1 Or Form1.fertig = 0 Then
            MsgBox("schon bewertet")
            Return
        End If
        'Save the index
        Form1.fertig = index

        'Form1.pathFileVariant = file folder path to statistik.txt
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Dim pathFileStatistics As String = Form1.pathFileVariant
        pathFileStatistics += "\statistik.txt"
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'Dim pathFileStatistics As String = My.Application.Info.DirectoryPath
        'MsgBox(pathFileStatistics)

        'Read the entire file and save to a variable
        Dim SearchString As String
        SearchString = My.Computer.FileSystem.ReadAllText(pathFileStatistics)
        'MsgBox(SearchString)

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
        Dim number1Int As Integer = CInt(tempString1)
        'All attempts, int
        Dim number2Int As Integer = CInt(tempString2)

        'If successful, increase the number of successes by 1
        If index = 1 Then
            number1Int += 1
        End If
        'Increase the number of retry attempts by 1
        number2Int += 1

        '--------------------------------------------------------------------
        'Create date
        Dim SearchChar0 As String = "|"
        Dim TestPos0 As Integer
        TestPos0 = InStr(1, SearchString, SearchChar0, CompareMethod.Binary)
        Dim sizeCreateDate As Integer = TestPos0 - 1
        'Create date, string
        Dim d As Integer = 0
        Dim createDateString As String = ""
        For d = 0 To sizeCreateDate - 1
            createDateString += SearchString.Chars(d)
        Next d
        '--------------------------------------------------------------------
        'MsgBox("createDateString = " & createDateString)

        'For example 14.09.2021
        Dim thisDate As Date
        thisDate = Today

        'Result
        'Example: 01.01.2021|15.09.2021 (9/10)
        Dim result As String = createDateString & "|" & thisDate & " (" & number1Int.ToString & "/" & number2Int.ToString & ")"

        'Delete old file
        My.Computer.FileSystem.DeleteFile(pathFileStatistics)

        'Create a new file
        Dim sw As System.IO.StreamWriter
        sw = System.IO.File.AppendText(pathFileStatistics)
        sw.Write(result)
        sw.Flush()
        sw.Close()

        Form1.Label_statistik.Text = My.Computer.FileSystem.ReadAllText(pathFileStatistics)

        'Dim Ob1 As ShowStatistics = New ShowStatistics()
        'Ob1.showDebutStatistics()
    End Sub

    Public Sub svetofor()
        If Form1.clickedMove = 1 Then
            'Green if move is started
            Form1.Label_Color.BackColor = Color.Green
        Else
            'White if move is not started
            Form1.Label_Color.BackColor = Color.White
        End If
    End Sub
End Class
