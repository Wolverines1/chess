Public Class PrintPosition

    Public Sub PrintAllFields()
        '0   Empty field
        '1   Pawn
        '3   Knight 
        '4   Bishop 
        '5   Rook 
        '10  Queen 
        '100 King
        '-1  Black Pawn

        'Draw 64 fields, starting from field a1
        'a1 - black field, b1 - white field, ...
        'The color of the fields alternates.
        'A problem arises when we reach the end of the horizontal. 
        'h1 - white field, a2 - white field!!!
        'In this case (white field a2), the variable changeСolor = 8
        'Therefore, we change the value of the variable 
        'changeСolor += 1

        Dim i As Integer = 0
        Dim changeСolor As Integer = 0
        For i = 0 To 63
            'changeСolor = 8 (field a2)
            'changeСolor = 17 (field a3)
            'changeСolor = 26 (field a4)
            'changeСolor = 35 (field a5)
            'changeСolor = 44 (field a6)
            'changeСolor = 53 (field a7)
            'changeСolor = 62 (field a8)
            If (changeСolor = 8 Or changeСolor = 17 Or changeСolor = 26 Or changeСolor = 35 Or
                changeСolor = 44 Or changeСolor = 53 Or changeСolor = 62) Then
                changeСolor += 1
            End If

            'Draw black field.
            If ((changeСolor Mod 2) = 0) Then
                Select Case Form1.arrayPosition(i)
                    Case 0
                        Form1.arrPictureBox(i).Image = My.Resources._0_BlackPole
                    Case 1
                        Form1.arrPictureBox(i).Image = My.Resources._1_WhitePeshkaBlack
                    Case 3
                        Form1.arrPictureBox(i).Image = My.Resources._3_WhiteSpringerBlack
                    Case 4
                        Form1.arrPictureBox(i).Image = My.Resources._4_WhiteLauferBlack
                    Case 5
                        Form1.arrPictureBox(i).Image = My.Resources._5_WhiteTurmBlack
                    Case 10
                        Form1.arrPictureBox(i).Image = My.Resources._10_WhiteDameBlack
                    Case 100
                        Form1.arrPictureBox(i).Image = My.Resources._100_WhiteKonigBlack
                    Case -1
                        Form1.arrPictureBox(i).Image = My.Resources._1_BlackPeshkaBlack
                    Case -3
                        Form1.arrPictureBox(i).Image = My.Resources._3_BlackSpringerBlack
                    Case -4
                        Form1.arrPictureBox(i).Image = My.Resources._4_BlackLauferBlack
                    Case -5
                        Form1.arrPictureBox(i).Image = My.Resources._5_BlackTurmBlack
                    Case -10
                        Form1.arrPictureBox(i).Image = My.Resources._10_BlackDameBlack
                    Case -100
                        Form1.arrPictureBox(i).Image = My.Resources._100_BlackKonigBlack
                    Case Else
                        Debug.WriteLine("No FIGURE")
                End Select
            Else
                'draw white field
                Select Case Form1.arrayPosition(i)
                    Case 0
                        Form1.arrPictureBox(i).Image = My.Resources._0_WhitePole
                    Case 1
                        Form1.arrPictureBox(i).Image = My.Resources._1_WhitePeshka
                    Case 3
                        Form1.arrPictureBox(i).Image = My.Resources._3_WhiteSpringer
                    Case 4
                        Form1.arrPictureBox(i).Image = My.Resources._4_WhiteLaufer
                    Case 5
                        Form1.arrPictureBox(i).Image = My.Resources._5_WhiteTurm
                    Case 10
                        Form1.arrPictureBox(i).Image = My.Resources._10_WhiteDame
                    Case 100
                        Form1.arrPictureBox(i).Image = My.Resources._100_WhiteKonig
                    Case -1
                        Form1.arrPictureBox(i).Image = My.Resources._1_BlackPeshka
                    Case -3
                        Form1.arrPictureBox(i).Image = My.Resources._3_BlackSpringer
                    Case -4
                        Form1.arrPictureBox(i).Image = My.Resources._4_BlackLaufer
                    Case -5
                        Form1.arrPictureBox(i).Image = My.Resources._5_BlackTurm
                    Case -10
                        Form1.arrPictureBox(i).Image = My.Resources._10_BlackDame
                    Case -100
                        Form1.arrPictureBox(i).Image = My.Resources._100_BlackKonig
                    Case Else
                        Debug.WriteLine("No FIGURE")
                End Select
            End If
            changeСolor += 1
        Next i
    End Sub
End Class
