Public Class ShowStatistics
    Public Sub showDebutStatistics()
        Form1.PictureBox64.Image = My.Resources.waiting

        Dim filename As String = ""
        If Form1.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Root path with name (.../readme.txt)
            Form1.pathFileVariantWithName = Form1.OpenFileDialog1.FileName
            'readme.txt
            filename = System.IO.Path.GetFileName(Form1.pathFileVariantWithName)
            'Сlear chart
            Form1.Chart1.Series("diagramm").Points.Clear()
            'Сlear Form1.ListBox2
            Form1.ListBox2.Items.Clear()
            'Сlear Labels
            Form1.Label_statistik.Text = ""
            Form1.L_all_statistik.Text = ""
        Else
            Return
        End If
        'Root path
        Form1.pathRoot = Form1.pathFileVariantWithName.Replace(filename, "")

        Form1.fso = CreateObject("Scripting.FileSystemObject")
        Form1.koren = Form1.fso.GetFolder(Form1.pathRoot)
        Form1.Podpapki = Form1.koren.SubFolders

        Dim success As Integer = 0
        Dim attempts As Integer = 0

        For Each Podpapka In Form1.Podpapki
            Form1.FileInodPapka = Podpapka.Files

            Dim nameVariant As String = ""
            For Each FileInPapka In Form1.FileInodPapka
                nameVariant = FileInPapka.name
                If nameVariant(0) = "v" Then
                    Exit For
                End If
            Next

            Dim nameVariantWithoutTXT As String = Microsoft.VisualBasic.Strings.Left(nameVariant, nameVariant.Length - 4)

            Dim nameSTATISTIK As String = ""
            For Each FileInPapka In Form1.FileInodPapka
                nameSTATISTIK = FileInPapka.name
                If nameSTATISTIK(0) = "s" Then
                    Exit For
                End If
            Next

            'Form1.pathFileVariant = file folder path to statistik.txt
            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Dim pathFileStatistics As String = Form1.pathRoot
            pathFileStatistics += nameVariantWithoutTXT
            pathFileStatistics += "\"
            pathFileStatistics += nameSTATISTIK
            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            Dim SearchString As String
            SearchString = My.Computer.FileSystem.ReadAllText(pathFileStatistics)

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
            Dim tmpSuccess As Integer = CInt(tempString1)
            success += tmpSuccess
            'All attempts, int
            Dim tmpAttempts As Integer = CInt(tempString2)
            attempts += tmpAttempts

            Dim tmpProzent As Integer = 0
            tmpProzent = tmpSuccess * 100 \ tmpAttempts

            Dim tmpProzentString As String = ""
            tmpProzentString = tmpProzent.ToString & "%"

            Form1.numberOptions += 1
            Form1.ListBox2.Items.Add(nameVariant & "   " & SearchString & " " & tmpProzentString)
        Next

        Dim prozent As Integer = 0
        prozent = success * 100 \ attempts
        Dim neUspehProzent As Integer = 100 - prozent

        Form1.Chart1.Series("diagramm").Points.AddXY(prozent & "%", prozent)
        Form1.Chart1.Series("diagramm").Points.AddXY(neUspehProzent & "%", neUspehProzent)

        Form1.L_all_statistik.Text = "(" & success & "\" & attempts & ")"
    End Sub
End Class
