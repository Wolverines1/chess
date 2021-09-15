Imports System.IO

Class Save
    Dim SendKeys As Object

    'Save the party
    Public Sub savePartie()
        'Create a folder
        'Save 3 files to it

        'Example
        'variant_00
        'statistik
        'chess_variant_00

        'If move started, then it is impossible to save
        If Form1.clickedMove = 1 Then
            MsgBox("move started")
            Return
        End If
        'clear chess blank
        Form1.ListBox1.Items.Clear()

        'Form1.moveNumber has the number of moves, white and black.
        'For example
        '1.e2-e4 e7-e5  (Form1.moveNumber = 2) (Form1.moveNumberReal = 1)
        '1.e2-e4 ...    (Form1.moveNumber = 1) (Form1.moveNumberReal = 1)
        '----------------------------------------------------------------
        'For example
        '1.e2-e4 e7-e5  (indexField = 4)
        'arrayNewIndexField(0) = e2 (index)
        'arrayNewIndexField(1) = e4 (index)
        'arrayNewIndexField(2) = e7 (index)
        'arrayNewIndexField(3) = e5 (index)
        Dim indexField As Integer = Form1.moveNumber * 2
        Dim arrayNewIndexField(indexField) As Integer

        '--------------------------------
        'alt index board = 
        '56-63 (a8-h8)
        '48-55 (a7-h7)
        '40-47 (a6-h6)
        '32-39 (a5-h5)
        '23-31 (a4-h4)
        '16-23 (a3-h3)
        '8-15  (a2-h2)
        '0-7   (a1-h1)

        '--------------------------------
        'new index board = 
        '18,28,38,48,58,68,78,88  (a8-h8)
        '17,27,37,47,57,67,77,87  (a7-h7)
        '16,26,36,46,56,66,76,86  (a6-h6)
        '15,25,35,45,55,65,75,85  (a5-h5)
        '14,24,34,44,54,64,74,84  (a4-h4)
        '13,23,33,43,53,63,73,83  (a3-h3)
        '12,22,32,42,52,62,72,82  (a2-h2)
        '11,21,31,41,51,61,71,81  (a1-h1)
        '--------------------------------

        'For example
        '--------------------------------
        '1.e2-e4 ...    (indexField = 2)
        'arrayNewIndexField(0) = e2 (index = 12) 
        '10 * (12 Mod 8 + 1) = 50
        '12 \ 8 + 1 = 1 + 1 = 2
        '50 + 2 = 52
        'arrayNewIndexField(0) = 52
        '-------------------------------
        'arrayNewIndexField(1) = e4 (index = 28)
        'etc ...
        'arrayNewIndexField(1) = 54
        Dim l As Integer = 0
        For i = 0 To indexField - 1
            arrayNewIndexField(i) = CInt(10 * (Form1.AllMoves(l) Mod 8 + 1) + Form1.AllMoves(l) \ 8 + 1)
            l += 2
        Next i

        Dim move_Number As Integer = Form1.moveNumber
        Dim arrayNewAllMove(move_Number) As Integer

        'For example
        'arrayNewIndexField(0) = 52
        'arrayNewIndexField(0) = 54
        'arrayNewAllMove(0) = 5254
        Dim tmp As String
        Dim m As Integer = 0
        For i = 0 To move_Number - 1
            tmp = arrayNewIndexField(m).ToString + arrayNewIndexField(m + 1).ToString
            arrayNewAllMove(i) = CInt(tmp)
            m = m + 2
        Next i

        'Save version
        Dim versionString = Form1.saveVersion.ToString
        '0 -> 01
        If CInt(versionString) < 10 Then
            versionString = "0" & versionString
        End If

        'New line
        Dim newln As String = Environment.NewLine

        'The path where the program is located (exe)
        Dim pathExe As String = My.Application.Info.DirectoryPath

        '-------------------------------------------------------------------
        'Сreation readme.txt

        'Path File readme
        Dim pathFileReadme As String = pathExe & "\readme.txt"

        If Not My.Computer.FileSystem.FileExists(pathFileReadme) Then
            Dim resultReadme As String = Now
            resultReadme += newln
            resultReadme += "Chess program from Egor Krivoborodov!"
            resultReadme += newln
            resultReadme += newln
            resultReadme += "After starting the program to download statistics"
            resultReadme += newln
            resultReadme += "1. Press the start button"
            resultReadme += newln
            resultReadme += "2. Open in program this file readme.txt"

            'Create a file-readme and save information to it
            Dim swReadme As System.IO.StreamWriter
            swReadme = System.IO.File.AppendText(pathFileReadme)
            swReadme.Write(resultReadme)
            swReadme.Flush()
            swReadme.Close()
        End If
        '-------------------------------------------------------------------

        'The path for new Folder
        Form1.strFolder = pathExe & "\variant_" & versionString
        '--------------------------------------------------------------
        'Create a folder
        With Form1.SaveFileDialog1
            .Filter = "Textdateien (*.txt)|*.txt|" &
                      "Alle Dateien (*.*)|*.*"
            .InitialDirectory = "D:\Basic"
            Form1.fso2 = CreateObject("Scripting.FileSystemObject")

            'Create new Folder
            If Not Form1.fso2.FolderExists(Form1.strFolder) Then
                MsgBox(Form1.strFolder)
                Form1.fso2.CreateFolder(Form1.strFolder)
            Else
                'search folder to save
                'MsgBox("Folder exists, try next!")
                Form1.saveVersion += 1
                savePartie()
                'End the function, so as not to overwrite the existing options!!! 
                Exit Sub
            End If
            .OverwritePrompt = False
        End With
        '--------------------------------------------------------------

        'Form1.moveNumber has the number of moves, white and black.
        'For example
        '1.e2-e4 e7-e5  (Form1.moveNumber = 2)
        '1.e2-e4 ...    (Form1.moveNumber = 1)
        Dim len As Integer = move_Number \ 2

        'flagFullMove = 1, if a move is made by white and black
        'flagFullMove = 0, if a move is made only by white
        Dim flagFullMove As Integer = 0
        If move_Number Mod 2 = 0 Then
            flagFullMove = 1
        End If

        Dim strWriter As New StringWriter()

        Dim tmp2 As Integer = 0
        'flagFullMove = 1, if a move is made by white and black
        If flagFullMove = 1 Then
            For i = 0 To len - 1
                'last move, do not add a new line at the end
                If i = len - 1 Then
                    strWriter.Write(i + 1 & "." & arrayNewAllMove(tmp2) & " " & arrayNewAllMove(tmp2 + 1))
                Else
                    strWriter.Write(i + 1 & "." & arrayNewAllMove(tmp2) & " " & arrayNewAllMove(tmp2 + 1) & newln)
                End If
                tmp2 += 2
            Next i
        End If

        tmp2 = 0
        Dim hod As Integer = 0
        'flagFullMove = 0, if a move is made only by white
        If flagFullMove = 0 Then
            For i = 0 To len - 1
                strWriter.Write(i + 1 & "." & arrayNewAllMove(tmp2) & " " & arrayNewAllMove(tmp2 + 1) & newln)
                hod = i + 1
                tmp2 += 2
            Next i
            'last white move, do not add a new line at the end
            strWriter.Write(hod + 1 & "." & arrayNewAllMove(tmp2))
        End If

        'Path File Variant
        Dim pathFileVariant As String = Form1.strFolder & "\variant_" & versionString & ".txt"
        'Create a file-variant and save information to it
        File.AppendAllText(pathFileVariant, strWriter.ToString())
        strWriter.Close()

        '--------------------------------------------------------------
        'start-statistik (1/1)

        'For example 14.09.2021
        Dim thisDate As Date
        thisDate = Today
        'Сreation date = reiteration date
        Dim result As String = thisDate & "|" & thisDate & " (1/1)"

        'Path File statistik
        Dim pathFileStatistik As String = Form1.strFolder & "\statistik.txt"

        'Create a file-statistik and save information to it
        Dim sw As System.IO.StreamWriter
        sw = System.IO.File.AppendText(pathFileStatistik)
        sw.Write(result)
        sw.Flush()
        sw.Close()
        '--------------------------------------------------------------
        'chess_variant_00

        'Path File chess_variant
        Dim pathFileChessVariant As String = Form1.strFolder & "\chess_variant_" & versionString & ".txt"

        Dim strWriter2 As New StringWriter()
        For i = 0 To Form1.moveNumberReal - 1
            'last move, do not add a new line at the end
            If i = (Form1.moveNumberReal - 1) Then
                newln = ""
            End If
            strWriter2.Write(i + 1 & ". " & Form1.arrayMovesWhite(i) & " " & Form1.arrayMovesBlack(i) & newln)
        Next i

        'Create a file-chess_variant and save information to it
        File.AppendAllText(pathFileChessVariant, strWriter2.ToString())
        strWriter2.Close()

        'Start timer
        Form1.Timer2.Enabled = True
        'Prepare variable for new save
        Form1.saveVersion += 1

        'We clear everything
        Form1.Button_Clear_Click(SendKeys, New System.EventArgs())
    End Sub
End Class
