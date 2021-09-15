Public Class MoveIntepret
    Dim SendKeys As Object

    Public Sub moveIntepretieren(ByVal allMoves() As Integer, ByVal moveNumber As Integer)
        'Array contains all the moves.
        Dim allMovesInString(moveNumber - 1) As String
        'Array contains 4 indices of one move 
        Dim array1Move(3) As Integer

        Dim m As Integer = 0
        Dim a As Integer
        For a = 0 To moveNumber - 1
            m = a * 4
            array1Move(0) = allMoves(m)
            array1Move(1) = allMoves(m + 1)
            array1Move(2) = allMoves(m + 2)
            'array1Move(3) don't use
            array1Move(3) = allMoves(m + 3)

            'Save the 1 move as a string 
            allMovesInString(a) = do1Move(array1Move)
        Next a

        'clear the blank form, Form1.ListBox1
        Form1.ListBox1.Items.Clear()
        Dim parity As Integer = 0

        'Form1.moveNumber has the number of moves, white and black.
        'For example
        '1.e2-e4 e7-e5  (Form1.moveNumber = 2) (Form1.moveNumberReal = 1)
        '1.e2-e4 ...    (Form1.moveNumber = 1) (Form1.moveNumberReal = 1)

        If (Form1.moveNumber Mod 2) = 0 Then
            Form1.moveNumberReal = Form1.moveNumber \ 2
        Else
            Form1.moveNumberReal = Form1.moveNumber \ 2
            Form1.moveNumberReal += 1
            'Remember the parity
            parity = 2
        End If

        'Fill the arrays of white And black moves
        ReDim Form1.arrayMovesWhite(Form1.moveNumberReal - 1)
        ReDim Form1.arrayMovesBlack(Form1.moveNumberReal - 1)

        Dim i As Integer = 0
        Dim k As Integer = 0
        For i = 0 To Form1.moveNumberReal - 1
            If i = Form1.moveNumberReal - 1 And parity = 2 Then
                Form1.arrayMovesWhite(i) = allMovesInString(k)
                Form1.arrayMovesBlack(i) = "...    "
                Exit For
            End If
            Form1.arrayMovesWhite(i) = allMovesInString(k)
            Form1.arrayMovesBlack(i) = allMovesInString(k + 1)
            k += 2
        Next i

        'Writing moves in a chess blank (Form1.ListBox1)
        For j = 0 To Form1.moveNumberReal - 1
            Form1.ListBox1.Items.Add(j + 1 & ". " & Form1.arrayMovesWhite(j) & "    " & Form1.arrayMovesBlack(j))
        Next j
    End Sub

    'Save the 1 move as a string 
    Function do1Move(ByVal arrayOneMove() As Integer) As String
        '2 Exceptions

        '-------------------------------------------------------------------------------
        '1 chess castling
        '4 possible cases

        'O-O for white, move was Ke1-Kg1
        If arrayOneMove(0) = 4 And arrayOneMove(1) = 100 And arrayOneMove(2) = 6 Then
            Return "O-O     "
        End If

        'O-O-O for white, move was Ke1-Kc1
        If arrayOneMove(0) = 4 And arrayOneMove(1) = 100 And arrayOneMove(2) = 2 Then
            Return "O-O-O  "
        End If

        'O-O for black, move was Ke8-Kg8
        If arrayOneMove(0) = 60 And arrayOneMove(1) = -100 And arrayOneMove(2) = 62 Then
            Return "O-O     "
        End If

        'O-O-O for black, move was Ke8-Kc8
        If arrayOneMove(0) = 60 And arrayOneMove(1) = -100 And arrayOneMove(2) = 58 Then
            Return "O-O-O  "
        End If
        '-------------------------------------------------------------------------------
        '2 chess pawn Promotion

        '8 possible cases for white

        'white move a7-a8
        If arrayOneMove(0) = 48 And arrayOneMove(1) = 1 And arrayOneMove(2) = 56 Then
            Return "a7-a8D  "
        End If

        'white move b7-b8
        If arrayOneMove(0) = 49 And arrayOneMove(1) = 1 And arrayOneMove(2) = 57 Then
            Return "b7-b8D  "
        End If

        'white move c7-c8
        If arrayOneMove(0) = 50 And arrayOneMove(1) = 1 And arrayOneMove(2) = 58 Then
            Return "c7-c8D  "
        End If

        'white move d7-d8
        If arrayOneMove(0) = 51 And arrayOneMove(1) = 1 And arrayOneMove(2) = 59 Then
            Return "d7-d8D  "
        End If

        'white move e7-e8
        If arrayOneMove(0) = 52 And arrayOneMove(1) = 1 And arrayOneMove(2) = 60 Then
            Return "e7-e8D  "
        End If

        'white move f7-f8
        If arrayOneMove(0) = 53 And arrayOneMove(1) = 1 And arrayOneMove(2) = 61 Then
            Return "f7-f8D  "
        End If

        'white move g7-g8
        If arrayOneMove(0) = 54 And arrayOneMove(1) = 1 And arrayOneMove(2) = 62 Then
            Return "g7-g8D  "
        End If

        'white move h7-h8
        If arrayOneMove(0) = 55 And arrayOneMove(1) = 1 And arrayOneMove(2) = 63 Then
            Return "h7-h8D  "
        End If
        '-------------------------------------------------------------------------------
        '8 possible cases for black

        'black move a2-a1
        If arrayOneMove(0) = 8 And arrayOneMove(1) = -1 And arrayOneMove(2) = 0 Then
            Return "a2-a1D "
        End If

        'black move b2-b1
        If arrayOneMove(0) = 9 And arrayOneMove(1) = -1 And arrayOneMove(2) = 1 Then
            Return "b2-b1D "
        End If

        'black move c2-c1
        If arrayOneMove(0) = 10 And arrayOneMove(1) = -1 And arrayOneMove(2) = 2 Then
            Return "c2-c1D "
        End If

        'black move d2-d1
        If arrayOneMove(0) = 11 And arrayOneMove(1) = -1 And arrayOneMove(2) = 3 Then
            Return "d2-d1D "
        End If

        'black move e2-e1
        If arrayOneMove(0) = 12 And arrayOneMove(1) = -1 And arrayOneMove(2) = 4 Then
            Return "e2-e1D "
        End If

        'black move f2-f1
        If arrayOneMove(0) = 13 And arrayOneMove(1) = -1 And arrayOneMove(2) = 5 Then
            Return "f2-f1D "
        End If

        'black move g2-g1
        If arrayOneMove(0) = 14 And arrayOneMove(1) = -1 And arrayOneMove(2) = 6 Then
            Return "g2-g1D "
        End If

        'black move h2-h1
        If arrayOneMove(0) = 15 And arrayOneMove(1) = -1 And arrayOneMove(2) = 7 Then
            Return "h2-h1D "
        End If
        '-------------------------------------------------------------------------------

        Dim figureSymbol As String = ""
        'find by index the symbol of figure
        figureSymbol = figureSymbolSearch(arrayOneMove(1))

        Dim space As String = ""
        If figureSymbol = "" Then
            space += "  "
        End If

        Dim fieldSymbol1 As String = ""
        Dim fieldSymbol2 As String = ""

        'find by index the symbol of a field
        fieldSymbol1 = fieldSymbolSeach(arrayOneMove(0))
        fieldSymbol2 = fieldSymbolSeach(arrayOneMove(2))

        Dim result As String = ""
        result = figureSymbol + fieldSymbol1 + "-" + figureSymbol + fieldSymbol2 + space

        Return result
    End Function

    'find by index the symbol of figure
    Function figureSymbolSearch(ByVal index As Integer) As String
        Dim result As String = ""

        Select Case index
            Case 1
                result = ""
            Case -1
                result = ""
            Case 3
                result = "S"
            Case -3
                result = "S"
            Case 4
                result = "L"
            Case -4
                result = "L"
            Case 5
                result = "T"
            Case -5
                result = "T"
            Case 10
                result = "D"
            Case -10
                result = "D"
            Case 100
                result = "K"
            Case -100
                result = "K"
            Case Else
                MsgBox("Empty field!")
                Form1.B_delete_move_Click(SendKeys, New System.EventArgs())
                Debug.WriteLine("No FIGURE")
        End Select

        Return result
    End Function

    'find by index the symbol of a field
    Function fieldSymbolSeach(ByVal index As Integer) As String
        Dim allSymbols(63) As String
        allSymbols = {"a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1",
            "a2", "b3", "c2", "d2", "e2", "f2", "g2", "h2",
            "a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3",
            "a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4",
            "a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5",
            "a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6",
            "a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7",
            "a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8"}
        Return allSymbols(index)
    End Function
End Class
