'Option Strict On
Imports System.Security.Cryptography
Imports System.Management

Class ContolParol
    Public parolDemo As String = ""

    Public Sub parolGenerieren()
        'SpecificationsNet()
        'SNProc()

        'GetHDD_SerNum()

        Dim strComputer As String = "."
        Dim WMI As Object
        WMI = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")

        'vypolnjaetsja 1 raz
        For Each Obj In WMI.ExecQuery("SELECT SerialNumber FROM Win32_BaseBoard")
            Form1.parol = Obj.SerialNumber
        Next
        'MsgBox("SerialNumber = " & Form1.parol)

        Dim password As String = Form1.parol

        Call passwordEncryptSHA(password) ' Lets call the first password encryption function for SHA1

        Dim number As Integer
        Dim passwordSHA As String = ""

        For number = 1 To 12
            passwordSHA = passwordEncryptSHA(password) ' give the variable the returned SHA value
            password = passwordSHA
        Next number
        password += "egor_24_!"
        For number = 1 To 12
            passwordSHA = passwordEncryptSHA(password)
            password = passwordSHA
        Next number

        parolDemo = passwordSHA

        'Dim wegParol As String
        'wegParol = My.Application.Info.DirectoryPath
        'wegParol += "\password.txt"

        'If FileExist(wegParol) Then
        '    MsgBox("!!!!!!!")
        'End If

        'Dim sw As System.IO.StreamWriter
        'sw = System.IO.File.AppendText(wegParol)
        'sw.Write(passwordSHA.ToString)
        'sw.Flush()
        'sw.Close()

        For number = 1 To 100
            passwordSHA = passwordEncryptSHA(password)
            password = passwordSHA
        Next number
        password += "dh_dgji4985"
        For number = 1 To 11
            passwordSHA = passwordEncryptSHA(password)
            password = passwordSHA
        Next number

        Form1.parol = passwordSHA
    End Sub

    Public Function passwordEncryptSHA(ByVal password As String) As String
        Dim sha As New SHA1CryptoServiceProvider ' declare sha as a new SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte ' and here is a byte variable

        bytesToHash = System.Text.Encoding.ASCII.GetBytes(password) ' covert the password into ASCII code
        bytesToHash = sha.ComputeHash(bytesToHash) ' this is where the magic starts and the encryption begins

        Dim encPassword As String = ""

        For Each b As Byte In bytesToHash
            encPassword += b.ToString("x2")
        Next

        Return encPassword ' boom there goes the encrypted password!
    End Function

    Public Sub controlPassword()
        Dim wegParol As String
        wegParol = My.Application.Info.DirectoryPath
        wegParol += "\password.txt"
        If FileExist(wegParol) Then
            Dim SearchString As String
            SearchString = My.Computer.FileSystem.ReadAllText(wegParol)
            If SearchString = Form1.parol Then
                Dim null As Image = Nothing
                Form1.BackgroundImage = null
                Return
            End If
        End If
        'Dim imgSave As New Bitmap(My.Resources.meer)
        'Dim img2Save As New Bitmap(imgSave, Form1.Width, Form1.Height)
        'Form1.BackgroundImage = img2Save
        disable()
        parolFeldDraw()
        createDemoFilePassword()
    End Sub

    Function FileExist(fileName As String) As Boolean
        On Error Resume Next
        FileExist = Dir$(fileName) <> ""
        If Err.Number <> 0 Then FileExist = False
        On Error GoTo 0
    End Function

    Public Sub disable()
        Dim k As Integer
        For k = 0 To 63
            'arrPictureBox(k).BorderStyle = BorderStyle.FixedSingle
            Form1.arrPictureBox(k).Visible = False
        Next k
        Form1.B_board_change.Visible = False
        Form1.B_delete_move.Visible = False
        Form1.B_links.Visible = False
        Form1.B_minus.Visible = False
        Form1.B_plus.Visible = False
        Form1.B_Read.Visible = False
        Form1.B_rechts.Visible = False
        Form1.B_save.Visible = False
        Form1.B_clear.Visible = False
        Form1.B_trenirovka.Visible = False
        Form1.B_vpered.Visible = False
        Form1.B_nazad.Visible = False

        Form1.Button1.Visible = False
        Form1.B_start.Visible = False

        Form1.ListBox1.Visible = False
        Form1.ListBox2.Visible = False

        Form1.Chart1.Visible = False

        Form1.L_Info.Visible = False
        Form1.Label_sec.Visible = False
        Form1.Label_statistik.Visible = False
        Form1.Label_Color.Visible = False

        Form1.TextBox1.Visible = False
        Form1.TextBox2.Visible = False

        Form1.B_form.Visible = False
        Form1.L_all_statistik.Visible = False

        Form1.PictureBox64.Visible = False
    End Sub

    Public Sub undisable()
        Dim k As Integer
        For k = 0 To 63
            'arrPictureBox(k).BorderStyle = BorderStyle.FixedSingle
            Form1.arrPictureBox(k).Visible = True
        Next k
        Form1.B_board_change.Visible = True
        Form1.B_delete_move.Visible = True
        Form1.B_links.Visible = True
        Form1.B_minus.Visible = True
        Form1.B_plus.Visible = True
        Form1.B_Read.Visible = True
        Form1.B_rechts.Visible = True
        Form1.B_save.Visible = True
        Form1.B_clear.Visible = True
        Form1.B_trenirovka.Visible = True
        Form1.B_vpered.Visible = True
        Form1.B_nazad.Visible = True

        Form1.Button1.Visible = True
        Form1.B_start.Visible = True

        Form1.ListBox1.Visible = True
        Form1.ListBox2.Visible = True

        Form1.Chart1.Visible = True

        Form1.L_Info.Visible = True
        Form1.Label_sec.Visible = True
        Form1.Label_statistik.Visible = True
        Form1.Label_Color.Visible = True

        Form1.TextBox1.Visible = True
        Form1.TextBox2.Visible = True

        Form1.B_form.Visible = True
        Form1.L_all_statistik.Visible = True

        Form1.PictureBox64.Visible = True
    End Sub

    Public Sub parolFeldDraw()
        Form1.T_parol.Visible = True
        Form1.B_parol.Visible = True

        Dim sizeField As Integer = Form1.Size.Height \ 10

        Form1.T_parol.Width = 6 * sizeField
        'T_parol.Height = 50
        Form1.T_parol.Top = Form1.Size.Height \ 2 - sizeField \ 2
        Form1.T_parol.Left = Form1.Size.Width \ 2 - Form1.T_parol.Width \ 2

        Form1.B_parol.Width = sizeField * 3 \ 2
        Form1.B_parol.Height = (sizeField \ 3) * 2
        Form1.B_parol.Top = Form1.Size.Height \ 2
        Form1.B_parol.Left = Form1.Size.Width \ 2 - Form1.B_parol.Width \ 2
        Form1.B_parol.BackColor = Color.FromArgb(0, 150, 255)
        'Form1.TransparencyKey = Color.Magenta
        'Form1.BackColor = Color.Magenta
        'Form1.B_parol.BackColor = Transparent
        'Form1.B_parol.BackColor = Color.Magenta
        'Form1.B_parol.Text = "password"
    End Sub

    Public Sub createDemoFilePassword()
        Dim wegParol As String
        wegParol = My.Application.Info.DirectoryPath
        wegParol += "\password.txt"

        If FileExist(wegParol) Then
            My.Computer.FileSystem.DeleteFile(wegParol)
        End If

        Dim sw As System.IO.StreamWriter
        sw = System.IO.File.AppendText(wegParol)
        sw.Write(parolDemo.ToString)
        sw.Flush()
        sw.Close()
    End Sub

    Public Sub buttonParol()
        Dim antwort As String
        antwort = Form1.T_parol.Text
        If antwort = Form1.parol Then
            Form1.T_parol.Visible = False
            Form1.B_parol.Visible = False

            undisable()

            Dim null As Image = Nothing
            Form1.BackgroundImage = null

            parolDemo = Form1.parol
            createDemoFilePassword()
        Else
            MsgBox("falsch")
            Return
        End If
    End Sub

    'Public Function GetMACAddress() As String
    '    Dim mc As New ManagementClass("Win32_Processor")
    '    Dim moc As ManagementObjectCollection = mc.GetInstances()
    '    Dim MACAddress As String = String.Empty
    '    For Each mo As ManagementObject In moc
    '        If MACAddress = String.Empty Then
    '            MACAddress = mo("ProcessorId").ToString()
    '        End If
    '        mo.Dispose()
    '    Next

    '    MACAddress = MACAddress.Replace(":", "")
    '    Return MACAddress
    'End Function

    'Public Function GetMACAddress2() As String
    '    Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
    '    Dim moc As ManagementObjectCollection = mc.GetInstances()
    '    Dim MACAddress As String = String.Empty
    '    For Each mo As ManagementObject In moc
    '        If MACAddress = String.Empty Then
    '            If CBool(mo("IPEnabled")) = True Then
    '                MACAddress = mo("MacAddress").ToString()
    '            End If
    '        End If
    '        mo.Dispose()
    '    Next

    '    MACAddress = MACAddress.Replace(":", "")
    '    Return MACAddress
    'End Function

    Private Sub SpecificationsNet()
        Dim strComputer As String
        Dim objWMIService As Object, colBIOS As Object, objBIOS As Object

        strComputer = "."
        objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")
        colBIOS = objWMIService.ExecQuery("SELECT * FROM Win32_NetworkAdapter")
        For Each objBIOS In colBIOS
            Debug.Print("Name adapter: " & objBIOS.name)
            Debug.Print("MAC-adress: " & objBIOS.MACAddress)
            If Not IsDBNull(objBIOS.MACAddress) Then
                MsgBox("Name adapter: " & objBIOS.name & vbNewLine &
                       "MAC-adress: " & objBIOS.MACAddress)
            End If
            'If Not IsNull(objBIOS.MACAddress) Then Range("A1") = objBIOS.MACAddress
        Next
        objWMIService = Nothing
    End Sub

    Sub SNProc()
        Dim WMI As Object
        WMI = GetObject("winmgmts:" _
                          & "{impersonationLevel=impersonate}!\\.\root\cimv2")
        Dim it As Object
        it = WMI.ExecQuery("Select * from Win32_Processor")
        For Each i In it
            MsgBox("ProcessorId = " & i.ProcessorId)
        Next
        Dim SN As Object
        SN = CreateObject("scripting.filesystemobject").GetDrive("c:\").SerialNumber
        MsgBox("c:\SerialNumber = " & SN)
    End Sub

    Sub GetHDD_SerNum()
        Dim objWMIService As Object
        objWMIService = GetObject("winmgmts:\\.\root\cimv2")
        Dim colItems As Object
        colItems = objWMIService.ExecQuery("SELECT * FROM Win32_DiskDrive", , 48)
        For Each Item In colItems
            MsgBox(Item.SerialNumber)
        Next
    End Sub
End Class
