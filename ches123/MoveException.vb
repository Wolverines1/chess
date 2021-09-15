Public Class MoveException
    Public Sub moveExceptions()
        '3 Exceptions

        '1 chess castling
        castling()

        '2 chess en passant
        enPassant()
        Form1.beatField = checkBeatField()

        '3 chess pawn Promotion
        pawnPromotion()
    End Sub

    'Chess castling
    Public Sub castling()
        'Index of King = 100
        'Index of Rook = 5 

        'O-O for white
        'move was Ke1-Kg1 -> remove rook h1 and draw rook f1
        If Form1.nowMove(0) = 4 And Form1.nowMove(1) = 100 And Form1.nowMove(2) = 6 Then
            Form1.arrayPosition(7) = 0
            Form1.arrayPosition(5) = 5
        End If

        'O-O-O for white
        'move was Ke1-Kc1 -> remove rook a1 and draw rook d1
        If Form1.nowMove(0) = 4 And Form1.nowMove(1) = 100 And Form1.nowMove(2) = 2 Then
            Form1.arrayPosition(0) = 0
            Form1.arrayPosition(3) = 5
        End If

        'O-O for black
        'move was Ke8-Kg8 -> remove rook h8 and draw rook f8
        If Form1.nowMove(0) = 60 And Form1.nowMove(1) = -100 And Form1.nowMove(2) = 62 Then
            Form1.arrayPosition(63) = 0
            Form1.arrayPosition(61) = -5
        End If

        'O-O-O for black
        'move was Ke8-Kc8 -> remove rook a8 and draw rook d8
        If Form1.nowMove(0) = 60 And Form1.nowMove(1) = -100 And Form1.nowMove(2) = 58 Then
            Form1.arrayPosition(56) = 0
            Form1.arrayPosition(59) = -5
        End If
    End Sub

    'Chess en passant
    Public Sub enPassant()
        'en passant
        'Chessboard field indices.
        '
        '56 57 58 59 60 61 62 63 - (a8-h8)
        '48 49 50 51 52 53 54 55 - (a7-h7)
        '40 41 42 43 44 45 46 47 - (a6-h6) Black beat fields are here
        '32 33 34 35 36 37 38 39 - (a5-h5)
        '24 25 26 27 28 29 30 31 - (a4-h4)
        '16 17 18 19 20 21 22 23 - (a3-h3) White beat fields are here
        '8  9  10 11 12 13 14 15 - (a2-h2)
        '0  1  2  3  4  5  6  7  - (a1-h1)
        If Form1.beatField <> -1 Then
            'broken field is available

            '----------------------------------------------------------------------------------------------------------
            'check black beat fields
            '14 possible cases

            'white move b5-a6, BeatField = a6 = 40 -> remove pawn a5
            If Form1.nowMove(0) = 33 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 40 And Form1.beatField = 40 Then
                Form1.arrayPosition(32) = 0
            End If

            'white move a5-b6, BeatField = b6 = 41 -> remove pawn b5
            If Form1.nowMove(0) = 32 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 41 And Form1.beatField = 41 Then
                Form1.arrayPosition(33) = 0
            End If
            'white move c5-b6, BeatField = b6 = 41 -> remove pawn b5
            If Form1.nowMove(0) = 34 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 41 And Form1.beatField = 41 Then
                Form1.arrayPosition(33) = 0
            End If

            'white move b5-c6, BeatField = c6 = 42 -> remove pawn c5
            If Form1.nowMove(0) = 33 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 42 And Form1.beatField = 42 Then
                Form1.arrayPosition(34) = 0
            End If
            'white move d5-c6, BeatField = c6 = 42 -> remove pawn c5
            If Form1.nowMove(0) = 35 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 42 And Form1.beatField = 42 Then
                Form1.arrayPosition(34) = 0
            End If

            'white move c5-d6, BeatField = d6 = 43 -> remove pawn d5
            If Form1.nowMove(0) = 34 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 43 And Form1.beatField = 43 Then
                Form1.arrayPosition(35) = 0
            End If
            'white move e5-d6, BeatField = d6 = 43 -> remove pawn d5
            If Form1.nowMove(0) = 36 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 43 And Form1.beatField = 43 Then
                Form1.arrayPosition(35) = 0
            End If

            'white move d5-e6, BeatField = e6 = 44 -> remove pawn e5
            If Form1.nowMove(0) = 35 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 44 And Form1.beatField = 44 Then
                Form1.arrayPosition(36) = 0
            End If
            'white move f5-e6, BeatField = e6 = 44 -> remove pawn e5
            If Form1.nowMove(0) = 37 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 44 And Form1.beatField = 44 Then
                Form1.arrayPosition(36) = 0
            End If

            'white move e5-f6, BeatField = f6 = 45 -> remove pawn f5
            If Form1.nowMove(0) = 36 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 45 And Form1.beatField = 45 Then
                Form1.arrayPosition(37) = 0
            End If
            'white move g5-f6, BeatField = f6 = 45 -> remove pawn f5
            If Form1.nowMove(0) = 38 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 45 And Form1.beatField = 45 Then
                Form1.arrayPosition(37) = 0
            End If

            'white move f5-g6, BeatField = g6 = 46 -> remove pawn g5
            If Form1.nowMove(0) = 37 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 46 And Form1.beatField = 46 Then
                Form1.arrayPosition(38) = 0
            End If
            'white move h5-g6, BeatField = g6 = 46 -> remove pawn g5
            If Form1.nowMove(0) = 39 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 46 And Form1.beatField = 46 Then
                Form1.arrayPosition(38) = 0
            End If

            'white move g5-h6, BeatField = h6 = 47 -> remove pawn h5
            If Form1.nowMove(0) = 38 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 47 And Form1.beatField = 47 Then
                Form1.arrayPosition(39) = 0
            End If
            '----------------------------------------------------------------------------------------------------------

            'check white beat fields
            '14 possible cases

            'black move b4-a3, BeatField = a3 = 16 -> remove pawn a4
            If Form1.nowMove(0) = 25 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 16 And Form1.beatField = 16 Then
                Form1.arrayPosition(24) = 0
            End If

            'black move a4-b3, BeatField = b3 = 17 -> remove pawn b4
            If Form1.nowMove(0) = 24 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 17 And Form1.beatField = 17 Then
                Form1.arrayPosition(25) = 0
            End If
            'black move c4-b3, BeatField = b3 = 17 -> remove pawn b4
            If Form1.nowMove(0) = 26 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 17 And Form1.beatField = 17 Then
                Form1.arrayPosition(25) = 0
            End If

            'black move b4-c3, BeatField = c3 = 18 -> remove pawn c4
            If Form1.nowMove(0) = 25 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 18 And Form1.beatField = 18 Then
                Form1.arrayPosition(26) = 0
            End If
            'black move d4-c3, BeatField = c3 = 18 -> remove pawn c4
            If Form1.nowMove(0) = 27 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 18 And Form1.beatField = 18 Then
                Form1.arrayPosition(26) = 0
            End If

            'black move c4-d3, BeatField = d3 = 19 -> remove pawn d4
            If Form1.nowMove(0) = 26 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 19 And Form1.beatField = 19 Then
                Form1.arrayPosition(27) = 0
            End If
            'black move e4-d3, BeatField = d3 = 19 -> remove pawn d4
            If Form1.nowMove(0) = 28 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 19 And Form1.beatField = 19 Then
                Form1.arrayPosition(27) = 0
            End If

            'black move d4-e3, BeatField = e3 = 20 -> remove pawn e4
            If Form1.nowMove(0) = 27 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 20 And Form1.beatField = 20 Then
                Form1.arrayPosition(28) = 0
            End If
            'black move f4-e3, BeatField = e3 = 20 -> remove pawn e4
            If Form1.nowMove(0) = 29 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 20 And Form1.beatField = 20 Then
                Form1.arrayPosition(28) = 0
            End If

            'black move e4-f3, BeatField = f3 = 21 -> remove pawn f4
            If Form1.nowMove(0) = 28 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 21 And Form1.beatField = 21 Then
                Form1.arrayPosition(29) = 0
            End If
            'black move g4-f3, BeatField = f3 = 21 -> remove pawn f4
            If Form1.nowMove(0) = 30 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 21 And Form1.beatField = 21 Then
                Form1.arrayPosition(29) = 0
            End If

            'black move f4-g3, BeatField = g3 = 22 -> remove pawn g4
            If Form1.nowMove(0) = 29 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 22 And Form1.beatField = 22 Then
                Form1.arrayPosition(30) = 0
            End If
            'black move h4-g3, BeatField = g3 = 22 -> remove pawn g4
            If Form1.nowMove(0) = 31 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 22 And Form1.beatField = 22 Then
                Form1.arrayPosition(30) = 0
            End If

            'black move g4-h3, BeatField = h3 = 23 -> remove pawn h4
            If Form1.nowMove(0) = 30 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 23 And Form1.beatField = 23 Then
                Form1.arrayPosition(31) = 0
            End If
        End If
    End Sub

    'Chess pawn Promotion
    Public Sub pawnPromotion()
        'Pawn Promotion
        '0   Empty field
        '1   Pawn
        '10  Queen 

        'Chessboard field indices.
        'example a7-a8 (Dame, Turm, Laeufer, Springer)
        '
        '56 57 58 59 60 61 62 63 - (a8-h8) White pawns will be here
        '48 49 50 51 52 53 54 55 - (a7-h7) White pawns are here
        '40 41 42 43 44 45 46 47 - (a6-h6)
        '32 33 34 35 36 37 38 39 - (a5-h5)
        '24 25 26 27 28 29 30 31 - (a4-h4)
        '16 17 18 19 20 21 22 23 - (a3-h3)
        '8  9  10 11 12 13 14 15 - (a2-h2) Black pawns are here
        '0  1  2  3  4  5  6  7  - (a1-h1) Black pawns will be here

        '8 possible cases for white

        'white move a7-a8
        If Form1.nowMove(0) = 48 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 56 Then
            Form1.nowMove(1) = 10
        End If

        'white move b7-b8
        If Form1.nowMove(0) = 49 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 57 Then
            Form1.nowMove(1) = 10
        End If

        'white move c7-c8
        If Form1.nowMove(0) = 50 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 58 Then
            Form1.nowMove(1) = 10
        End If

        'white move d7-d8
        If Form1.nowMove(0) = 51 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 59 Then
            Form1.nowMove(1) = 10
        End If

        'white move e7-e8
        If Form1.nowMove(0) = 52 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 60 Then
            Form1.nowMove(1) = 10
        End If

        'white move f7-f8
        If Form1.nowMove(0) = 53 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 61 Then
            Form1.nowMove(1) = 10
        End If

        'white move g7-g8
        If Form1.nowMove(0) = 54 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 62 Then
            Form1.nowMove(1) = 10
        End If

        'white move h7-h8
        If Form1.nowMove(0) = 55 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 63 Then
            Form1.nowMove(1) = 10
        End If

        '8 possible cases for black

        'black move a2-a1
        If Form1.nowMove(0) = 8 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 0 Then
            Form1.nowMove(1) = -10
        End If

        'black move b2-b1
        If Form1.nowMove(0) = 9 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 1 Then
            Form1.nowMove(1) = -10
        End If

        'black move c2-c1
        If Form1.nowMove(0) = 10 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 2 Then
            Form1.nowMove(1) = -10
        End If

        'black move d2-d1
        If Form1.nowMove(0) = 11 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 3 Then
            Form1.nowMove(1) = -10
        End If

        'black move e2-e1
        If Form1.nowMove(0) = 12 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 4 Then
            Form1.nowMove(1) = -10
        End If

        'black move f2-f1
        If Form1.nowMove(0) = 13 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 5 Then
            Form1.nowMove(1) = -10
        End If

        'black move g2-g1
        If Form1.nowMove(0) = 14 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 6 Then
            Form1.nowMove(1) = -10
        End If

        'black move h2-h1
        If Form1.nowMove(0) = 15 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 7 Then
            Form1.nowMove(1) = -10
        End If
    End Sub

    Function checkBeatField() As Integer
        'The pawn moves 2 spaces forward.
        '16 possible cases 
        'Chessboard field indices.
        '
        '56 57 58 59 60 61 62 63 - (a8-h8)
        '48 49 50 51 52 53 54 55 - (a7-h7) Black pawns are here
        '40 41 42 43 44 45 46 47 - (a6-h6)
        '32 33 34 35 36 37 38 39 - (a5-h5) Black pawns will be here
        '24 25 26 27 28 29 30 31 - (a4-h4) White pawns will be here
        '16 17 18 19 20 21 22 23 - (a3-h3)
        '8  9  10 11 12 13 14 15 - (a2-h2) White pawns are here
        '0  1  2  3  4  5  6  7  - (a1-h1)

        'Checking broken fields for whites
        '8 possible cases 

        'move a2-a4, BeatField = a3 = 16
        If Form1.nowMove(0) = 8 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 24 Then
            Return 16
        End If
        'move b2-b4, BeatField = a3 = 17
        If Form1.nowMove(0) = 9 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 25 Then
            Return 17
        End If
        'move c2-c4, BeatField = c3 = 18
        If Form1.nowMove(0) = 10 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 26 Then
            Return 18
        End If
        'move d2-d4, BeatField = d3 = 19
        If Form1.nowMove(0) = 11 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 27 Then
            Return 19
        End If
        'move e2-e4, BeatField = e3 = 20
        If Form1.nowMove(0) = 12 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 28 Then
            Return 20
        End If
        'move f2-f4, BeatField = f3 = 21
        If Form1.nowMove(0) = 13 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 29 Then
            Return 21
        End If
        'move g2-g4, BeatField = g3 = 22
        If Form1.nowMove(0) = 14 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 30 Then
            Return 22
        End If
        'move h2-h4, BeatField = h3 = 23
        If Form1.nowMove(0) = 15 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 31 Then
            Return 23
        End If

        'Checking broken fields for black
        '8 possible cases

        'move a7-a5, BeatField = a6 = 40
        If Form1.nowMove(0) = 48 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 32 Then
            Return 40
        End If
        'move b7-b5, BeatField = b6 = 41
        If Form1.nowMove(0) = 49 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 33 Then
            Return 41
        End If
        'move c7-c5, BeatField = c6 = 42
        If Form1.nowMove(0) = 50 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 34 Then
            Return 42
        End If
        'move d7-d5, BeatField = d6 = 43
        If Form1.nowMove(0) = 51 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 35 Then
            Return 43
        End If
        'move e7-e5, BeatField = e6 = 44
        If Form1.nowMove(0) = 52 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 36 Then
            Return 44
        End If
        'move f7-f5, BeatField = f6 = 45
        If Form1.nowMove(0) = 53 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 37 Then
            Return 45
        End If
        'move g7-g5, BeatField = g6 = 46
        If Form1.nowMove(0) = 54 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 38 Then
            Return 46
        End If
        'move h7-h5, BeatField = h6 = 47
        If Form1.nowMove(0) = 55 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 39 Then
            Return 47
        End If
        'broken field not found 
        Return -1
    End Function

    '--------------------------------------------------------------------------------------
    'Return 1 move, restoring exceptions!!!

    'Checking for two exceptions 
    Public Sub moveExceptionsBack()
        '2 Exceptions.
        'Chess pawn Promotion no need to check!

        '1 chess castling
        castlingBack()

        '2 chess en passant
        Form1.beatField = checkBeatFieldBack()
        enPassantBack()
    End Sub

    'Chess castling, move back
    Public Sub castlingBack()
        'Index of King = 100
        'Index of Rook = 5 

        'O-O for white
        'move was Ke1-Kg1 -> remove rook f1 and draw rook h1
        If Form1.nowMove(0) = 4 And Form1.nowMove(1) = 100 And Form1.nowMove(2) = 6 Then
            Form1.arrayPosition(7) = 5
            Form1.arrayPosition(5) = 0
        End If

        'O-O-O for white
        'move was Ke1-Kc1 -> remove rook d1 and draw rook a1
        If Form1.nowMove(0) = 4 And Form1.nowMove(1) = 100 And Form1.nowMove(2) = 2 Then
            Form1.arrayPosition(0) = 5
            Form1.arrayPosition(3) = 0
        End If

        'O-O for black
        'move was Ke8-Kg8 -> remove rook f8 and draw rook h8
        If Form1.nowMove(0) = 60 And Form1.nowMove(1) = -100 And Form1.nowMove(2) = 62 Then
            Form1.arrayPosition(63) = -5
            Form1.arrayPosition(61) = 0
        End If

        'O-O-O for black
        'move was Ke8-Kc8 -> remove rook d8 and draw rook a8
        If Form1.nowMove(0) = 60 And Form1.nowMove(1) = -100 And Form1.nowMove(2) = 58 Then
            Form1.arrayPosition(56) = -5
            Form1.arrayPosition(59) = 0
        End If
    End Sub

    'Chess en passant, move back
    Public Sub enPassantBack()
        'en passant
        'Chessboard field indices.
        '
        '56 57 58 59 60 61 62 63 - (a8-h8)
        '48 49 50 51 52 53 54 55 - (a7-h7)
        '40 41 42 43 44 45 46 47 - (a6-h6) Black beat fields are here
        '32 33 34 35 36 37 38 39 - (a5-h5)
        '24 25 26 27 28 29 30 31 - (a4-h4)
        '16 17 18 19 20 21 22 23 - (a3-h3) White beat fields are here
        '8  9  10 11 12 13 14 15 - (a2-h2)
        '0  1  2  3  4  5  6  7  - (a1-h1)
        If Form1.beatField <> -1 Then
            'broken field is available

            '----------------------------------------------------------------------------------------------------------
            'check black beat fields
            '14 possible cases

            'white move b5-a6, BeatField = a6 = 40 -> draw pawn a5
            If Form1.nowMove(0) = 33 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 40 And Form1.beatField = 40 Then
                Form1.arrayPosition(32) = -1
            End If

            'white move a5-b6, BeatField = b6 = 41 -> draw pawn b5
            If Form1.nowMove(0) = 32 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 41 And Form1.beatField = 41 Then
                Form1.arrayPosition(33) = -1
            End If
            'white move c5-b6, BeatField = b6 = 41 -> draw pawn b5
            If Form1.nowMove(0) = 34 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 41 And Form1.beatField = 41 Then
                Form1.arrayPosition(33) = -1
            End If

            'white move b5-c6, BeatField = c6 = 42 -> draw pawn c5
            If Form1.nowMove(0) = 33 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 42 And Form1.beatField = 42 Then
                Form1.arrayPosition(34) = -1
            End If
            'white move d5-c6, BeatField = c6 = 42 -> draw pawn c5
            If Form1.nowMove(0) = 35 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 42 And Form1.beatField = 42 Then
                Form1.arrayPosition(34) = -1
            End If

            'white move c5-d6, BeatField = d6 = 43 -> draw pawn d5
            If Form1.nowMove(0) = 34 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 43 And Form1.beatField = 43 Then
                Form1.arrayPosition(35) = -1
            End If
            'white move e5-d6, BeatField = d6 = 43 -> draw pawn d5
            If Form1.nowMove(0) = 36 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 43 And Form1.beatField = 43 Then
                Form1.arrayPosition(35) = -1
            End If

            'white move d5-e6, BeatField = e6 = 44 -> draw pawn e5
            If Form1.nowMove(0) = 35 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 44 And Form1.beatField = 44 Then
                Form1.arrayPosition(36) = -1
            End If
            'white move f5-e6, BeatField = e6 = 44 -> draw pawn e5
            If Form1.nowMove(0) = 37 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 44 And Form1.beatField = 44 Then
                Form1.arrayPosition(36) = -1
            End If

            'white move e5-f6, BeatField = f6 = 45 -> draw pawn f5
            If Form1.nowMove(0) = 36 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 45 And Form1.beatField = 45 Then
                Form1.arrayPosition(37) = -1
            End If
            'white move g5-f6, BeatField = f6 = 45 -> draw pawn f5
            If Form1.nowMove(0) = 38 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 45 And Form1.beatField = 45 Then
                Form1.arrayPosition(37) = -1
            End If

            'white move f5-g6, BeatField = g6 = 46 -> draw pawn g5
            If Form1.nowMove(0) = 37 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 46 And Form1.beatField = 46 Then
                Form1.arrayPosition(38) = -1
            End If
            'white move h5-g6, BeatField = g6 = 46 -> draw pawn g5
            If Form1.nowMove(0) = 39 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 46 And Form1.beatField = 46 Then
                Form1.arrayPosition(38) = -1
            End If

            'white move g5-h6, BeatField = h6 = 47 -> draw pawn h5
            If Form1.nowMove(0) = 38 And Form1.nowMove(1) = 1 And Form1.nowMove(2) = 47 And Form1.beatField = 47 Then
                Form1.arrayPosition(39) = -1
            End If
            '----------------------------------------------------------------------------------------------------------

            'check white beat fields
            '14 possible cases

            'black move b4-a3, BeatField = a3 = 16 -> draw pawn a4
            If Form1.nowMove(0) = 25 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 16 And Form1.beatField = 16 Then
                Form1.arrayPosition(24) = 1
            End If

            'black move a4-b3, BeatField = b3 = 17 -> draw pawn b4
            If Form1.nowMove(0) = 24 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 17 And Form1.beatField = 17 Then
                Form1.arrayPosition(25) = 1
            End If
            'black move c4-b3, BeatField = b3 = 17 -> draw pawn b4
            If Form1.nowMove(0) = 26 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 17 And Form1.beatField = 17 Then
                Form1.arrayPosition(25) = 1
            End If

            'black move b4-c3, BeatField = c3 = 18 -> draw pawn c4
            If Form1.nowMove(0) = 25 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 18 And Form1.beatField = 18 Then
                Form1.arrayPosition(26) = 1
            End If
            'black move d4-c3, BeatField = c3 = 18 -> draw pawn c4
            If Form1.nowMove(0) = 27 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 18 And Form1.beatField = 18 Then
                Form1.arrayPosition(26) = 1
            End If

            'black move c4-d3, BeatField = d3 = 19 -> draw pawn d4
            If Form1.nowMove(0) = 26 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 19 And Form1.beatField = 19 Then
                Form1.arrayPosition(27) = 1
            End If
            'black move e4-d3, BeatField = d3 = 19 -> draw pawn d4
            If Form1.nowMove(0) = 28 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 19 And Form1.beatField = 19 Then
                Form1.arrayPosition(27) = 1
            End If

            'black move d4-e3, BeatField = e3 = 20 -> draw pawn e4
            If Form1.nowMove(0) = 27 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 20 And Form1.beatField = 20 Then
                Form1.arrayPosition(28) = 1
            End If
            'black move f4-e3, BeatField = e3 = 20 -> draw pawn e4
            If Form1.nowMove(0) = 29 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 20 And Form1.beatField = 20 Then
                Form1.arrayPosition(28) = 1
            End If

            'black move e4-f3, BeatField = f3 = 21 -> draw pawn f4
            If Form1.nowMove(0) = 28 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 21 And Form1.beatField = 21 Then
                Form1.arrayPosition(29) = 1
            End If
            'black move g4-f3, BeatField = f3 = 21 -> draw pawn f4
            If Form1.nowMove(0) = 30 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 21 And Form1.beatField = 21 Then
                Form1.arrayPosition(29) = 1
            End If

            'black move f4-g3, BeatField = g3 = 22 -> draw pawn g4
            If Form1.nowMove(0) = 29 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 22 And Form1.beatField = 22 Then
                Form1.arrayPosition(30) = 1
            End If
            'black move h4-g3, BeatField = g3 = 22 -> draw pawn g4
            If Form1.nowMove(0) = 31 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 22 And Form1.beatField = 22 Then
                Form1.arrayPosition(30) = 1
            End If

            'black move g4-h3, BeatField = h3 = 23 -> draw pawn h4
            If Form1.nowMove(0) = 30 And Form1.nowMove(1) = -1 And Form1.nowMove(2) = 23 And Form1.beatField = 23 Then
                Form1.arrayPosition(31) = 1
            End If
        End If
    End Sub

    Function checkBeatFieldBack() As Integer
        'The pawn moves 2 spaces forward.
        '16 possible cases 
        'Chessboard field indices.
        '
        '56 57 58 59 60 61 62 63 - (a8-h8)
        '48 49 50 51 52 53 54 55 - (a7-h7) Black pawns are here
        '40 41 42 43 44 45 46 47 - (a6-h6)
        '32 33 34 35 36 37 38 39 - (a5-h5) Black pawns will be here
        '24 25 26 27 28 29 30 31 - (a4-h4) White pawns will be here
        '16 17 18 19 20 21 22 23 - (a3-h3)
        '8  9  10 11 12 13 14 15 - (a2-h2) White pawns are here
        '0  1  2  3  4  5  6  7  - (a1-h1)

        'No previous move 
        If Form1.nowMoveIndex = 0 Then
            Return -1
        End If

        'Save the previous move to the array!
        Dim nowMoveBack(3) As Integer
        nowMoveBack(0) = Form1.AllMoves(Form1.nowMoveIndex - 4)
        nowMoveBack(1) = Form1.AllMoves(Form1.nowMoveIndex - 3)
        nowMoveBack(2) = Form1.AllMoves(Form1.nowMoveIndex - 2)
        nowMoveBack(3) = Form1.AllMoves(Form1.nowMoveIndex - 1)


        'Checking broken fields for whites
        '8 possible cases 

        'move a2-a4, BeatField = a3 = 16
        If nowMoveBack(0) = 8 And nowMoveBack(1) = 1 And nowMoveBack(2) = 24 Then
            Return 16
        End If
        'move b2-b4, BeatField = a3 = 17
        If nowMoveBack(0) = 9 And nowMoveBack(1) = 1 And nowMoveBack(2) = 25 Then
            Return 17
        End If
        'move c2-c4, BeatField = c3 = 18
        If nowMoveBack(0) = 10 And nowMoveBack(1) = 1 And nowMoveBack(2) = 26 Then
            Return 18
        End If
        'move d2-d4, BeatField = d3 = 19
        If nowMoveBack(0) = 11 And nowMoveBack(1) = 1 And nowMoveBack(2) = 27 Then
            Return 19
        End If
        'move e2-e4, BeatField = e3 = 20
        If nowMoveBack(0) = 12 And nowMoveBack(1) = 1 And nowMoveBack(2) = 28 Then
            Return 20
        End If
        'move f2-f4, BeatField = f3 = 21
        If nowMoveBack(0) = 13 And nowMoveBack(1) = 1 And nowMoveBack(2) = 29 Then
            Return 21
        End If
        'move g2-g4, BeatField = g3 = 22
        If nowMoveBack(0) = 14 And nowMoveBack(1) = 1 And nowMoveBack(2) = 30 Then
            Return 22
        End If
        'move h2-h4, BeatField = h3 = 23
        If nowMoveBack(0) = 15 And nowMoveBack(1) = 1 And nowMoveBack(2) = 31 Then
            Return 23
        End If

        'Checking broken fields for black
        '8 possible cases

        'move a7-a5, BeatField = a6 = 40
        If nowMoveBack(0) = 48 And nowMoveBack(1) = -1 And nowMoveBack(2) = 32 Then
            Return 40
        End If
        'move b7-b5, BeatField = b6 = 41
        If nowMoveBack(0) = 49 And nowMoveBack(1) = -1 And nowMoveBack(2) = 33 Then
            Return 41
        End If
        'move c7-c5, BeatField = c6 = 42
        If nowMoveBack(0) = 50 And nowMoveBack(1) = -1 And nowMoveBack(2) = 34 Then
            Return 42
        End If
        'move d7-d5, BeatField = d6 = 43
        If nowMoveBack(0) = 51 And nowMoveBack(1) = -1 And nowMoveBack(2) = 35 Then
            Return 43
        End If
        'move e7-e5, BeatField = e6 = 44
        If nowMoveBack(0) = 52 And nowMoveBack(1) = -1 And nowMoveBack(2) = 36 Then
            Return 44
        End If
        'move f7-f5, BeatField = f6 = 45
        If nowMoveBack(0) = 53 And nowMoveBack(1) = -1 And nowMoveBack(2) = 37 Then
            Return 45
        End If
        'move g7-g5, BeatField = g6 = 46
        If nowMoveBack(0) = 54 And nowMoveBack(1) = -1 And nowMoveBack(2) = 38 Then
            Return 46
        End If
        'move h7-h5, BeatField = h6 = 47
        If nowMoveBack(0) = 55 And nowMoveBack(1) = -1 And nowMoveBack(2) = 39 Then
            Return 47
        End If
        'broken field not found 
        Return -1
    End Function
End Class
