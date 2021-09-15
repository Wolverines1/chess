Public Class OpenChessFile
    Private sender As Object
    Public Sub openFile()
        Form1.readMode = 0
        Form1.Button_Clear_Click(sender, New System.EventArgs())

        Form1.PictureBox64.Image = My.Resources.waiting

        Form1.OpenFileDialog1.Filter = "Text-Dateien (*.txt)|*.txt|" &
                                      "Alle Dateien (*.*)|*.*"

        Dim filename As String = ""
        Dim datpfadMitName As String = ""
        If Form1.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Form1.B_trenirovka.Enabled = True
            datpfadMitName = Form1.OpenFileDialog1.FileName
            filename = System.IO.Path.GetFileName(datpfadMitName)
            Form1.readMode = 1
        Else
            MsgBox("file not take")
            Return
        End If
        'MsgBox(datpfadMitName.ToString)
        'MsgBox(filename)

        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'variant_00 - Ordner
        Form1.pathFileVariant = datpfadMitName.Replace(filename, "")
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        'MsgBox(Form1.pathFileVariant)

        Dim aaab As String = Form1.pathFileVariant
        aaab += "\statistik.txt"
        Dim SearchString As String
        SearchString = My.Computer.FileSystem.ReadAllText(aaab)
        Form1.Label_statistik.Text = SearchString

        'Dim weg As String = Form1.datpfad

        '...\variant_00\variant_00.txt
        downloadFile(datpfadMitName)

    End Sub

    Public Sub downloadFile(ByVal datpfadMitName0 As String)
        Dim wegToExe As String = datpfadMitName0
        'MsgBox("datpfadMitName0 = " & datpfadMitName0)
        'Dim wegToExe As String = My.Application.Info.DirectoryPath
        'wegToExe += "\0.txt"

        Dim stringFromDatei As String
        stringFromDatei = My.Computer.FileSystem.ReadAllText(wegToExe)
        stringFromDatei += "!"
        'MsgBox(stringFromDatei)

        Dim dlineString As Integer = 0
        While stringFromDatei(dlineString) <> "!"
            dlineString += 1
        End While
        'MsgBox("dlina = " + dlineString.ToString)

        Dim arrAllMoves(dlineString - 1) As String
        Dim i As Integer = 0
        For i = 0 To dlineString - 1
            arrAllMoves(i) = stringFromDatei(i)
        Next i

        Dim howManyNL As Integer = 0
        For i = 0 To dlineString - 1
            If Asc(arrAllMoves(i)) = 13 Then
                howManyNL = howManyNL + 1
            End If
        Next i

        'MsgBox("howManyNL = " + howManyNL.ToString)

        Dim lengthArrOhneNL = dlineString - howManyNL
        'MsgBox("lengthArrOhneNL = " + lengthArrOhneNL.ToString)
        Dim arrOhneNL(lengthArrOhneNL) As String

        Dim index01 As Integer = 0
        For i = 0 To dlineString - 1
            If Asc(arrAllMoves(i)) = 13 Then
                'MsgBox("13!!!")
                index01 -= 1
            Else
                If Asc(arrAllMoves(i)) = 10 Then
                    'MsgBox("10!!!")
                    arrOhneNL(index01) = " "
                    'MsgBox("arrTets(" + index01.ToString + ") = " + arrOhneNL(index01).ToString + " ASCII = " + Asc(arrOhneNL(index01)).ToString)
                Else
                    arrOhneNL(index01) = arrAllMoves(i)
                    'MsgBox("arrTets(" + index01.ToString + ") = " + arrOhneNL(index01).ToString + " ASCII = " + Asc(arrOhneNL(index01)).ToString)
                End If
            End If
            index01 += 1
        Next i

        arrOhneNL(lengthArrOhneNL) = "!"
        Dim dlineOhneNL As Integer = 0
        While arrOhneNL(dlineOhneNL) <> "!"
            dlineOhneNL += 1
        End While
        'MsgBox("dlinaOhneNL = " + dlineOhneNL.ToString)
        'For i = 0 To lengthArrOhneNL
        '    MsgBox("arr(" + i.ToString + ") = " + arrOhneNL(i).ToString + " ASCII = " + Asc(arrOhneNL(i)).ToString)
        'Next i

        Dim stringOhneNumeration As String
        stringOhneNumeration = DeleteNumeration(lengthArrOhneNL, arrOhneNL)
        'MsgBox("DeleteNumaration = " + stringOhneNumeration)

        Dim dlinaDeleteNumaration As Integer = 0
        While stringOhneNumeration(dlinaDeleteNumaration) <> "!"
            dlinaDeleteNumaration += 1
        End While
        'dlinaDeleteNumaration bez "!"
        'MsgBox("dlinaDeleteNumaration = " + dlinaDeleteNumaration.ToString)

        Dim numberOfMoves0 As Integer = numberOfMoves(stringOhneNumeration)
        'MsgBox("numberOfMoves0 = " + numberOfMoves0.ToString)

        Dim moves(numberOfMoves0 - 1) As Integer
        moves = toMoves(stringOhneNumeration)
        'MsgBox("moves = " + moves(0).ToString + " " + moves(1).ToString + " " + moves(2).ToString)

        Dim size As Integer = 2 * numberOfMoves0

        'MsgBox("size = " + size.ToString)
        Dim movesNumber(size - 1) As Integer
        movesNumber = splitMovesToInt(numberOfMoves0, moves)

        Dim index1 As Integer
        Dim temp1 As String = ""
        For index1 = 0 To size - 1
            temp1 += movesNumber(index1).ToString
            temp1 += " "
        Next index1
        'MsgBox("temp1 = " + temp1)

        Dim index2 As Integer
        Dim temp2 As Integer
        Dim temp3 As String = ""
        For index2 = 0 To size - 1
            temp2 = movesNumber(index2)
            movesNumber(index2) = temp2 \ 10 - 1 + 8 * ((temp2 Mod 10) - 1)
            temp3 += movesNumber(index2).ToString
            temp3 += " "
            Form1.PictureBox_Click_Analysis(movesNumber(index2))
        Next index2
        'MsgBox("temp3 = " + temp3)

        'ListBox1.Items.Clear()

        Dim Ob1 As ChangePosition = New ChangePosition()
        Ob1.startingPosition()

        Dim Ob2 As PrintPosition = New PrintPosition()
        Ob2.PrintAllFields()

        Form1.nowMoveIndex = 0

        'MsgBox("ss")

        'Form1.OpenFileDialog1.InitialDirectory = "C:\"
        'Form1.OpenFileDialog1.Title = "Open a Text File"
        'Form1.OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ''Form1.OpenFileDialog1.ShowDialog()
        'If Form1.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
        '    MsgBox(Form1.OpenFileDialog1.InitialDirectory)
        '    'RichTextBox1.Text = Form1.OpenFileDialog1.OpenFile
        '    'ListBox2.Items.Add(Form1.OpenFileDialog1.ReadAllText(Of String))
        'End If
    End Sub

    Public Function DeleteNumeration(ByVal length As Integer, ByVal ParamArray arr() As String) As String
        Dim i As Integer = 0, j As Integer, k As Integer = 0
        'For i = 0 To length
        '    MsgBox("arr(" + i.ToString + ") = " + arr(i).ToString + " ASCII = " + Asc(arr(i)).ToString)
        'Next i

        'MsgBox("length = " + length.ToString)

        Dim strMoves As String = ""
        For i = 0 To length - 1
            If arr(i) <> "." Then
                'MsgBox("...")
            Else
                For j = 0 To 4
                    i += 1
                    strMoves += arr(i)
                    'MsgBox("strMoves = " + strMoves)
                Next j
                If arr(i) = "!" Then
                    'MsgBox("!!!")
                    Exit For
                Else
                    For k = 0 To 4
                        i += 1
                        strMoves += arr(i)
                        'MsgBox("nnn strMoves = " + strMoves)
                    Next k
                End If
            End If
        Next i

        Return strMoves
    End Function

    Public Function numberOfMoves(ByVal line As String) As Integer
        Dim result As Integer = 0, i As Integer = 0
        While line(i) <> "!"
            If line(i) = " " Then
                result += 1
            End If
            i += 1
        End While
        result += 1
        Return result
    End Function

    Public Function toMoves(ByVal line As String) As Integer()
        Dim number As Integer = numberOfMoves(line)
        Dim result(number - 1) As Integer

        Dim numberStringTemp As String = ""
        Dim numberTemp As Integer = 0
        Dim indexNextMove As Integer = 0
        Dim index As Integer = 0
        Dim i, k As Integer

        For i = 0 To number - 1
            numberStringTemp = ""
            For k = indexNextMove To indexNextMove + 3
                numberStringTemp += line(k)
            Next k
            numberTemp = CInt(numberStringTemp)
            result(index) = numberTemp
            index += 1

            indexNextMove += 4
            If line(indexNextMove) = "!" Then
                Exit For
            Else
                indexNextMove += 1
            End If
        Next i

        Return result
    End Function

    Public Function splitMovesToInt(ByVal number As Integer, ByVal ParamArray moves() As Integer) As Integer()
        Dim newSize As Integer = 2 * number
        Dim movesIntFinished(newSize) As Integer

        Dim index As Integer = 0
        Dim i As Integer
        For i = 0 To number - 1
            movesIntFinished(index) = moves(i) \ 100
            movesIntFinished(index + 1) = moves(i) Mod 100
            index += 2
        Next i

        Return movesIntFinished
    End Function
End Class
