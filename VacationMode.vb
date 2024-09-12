Public Class frmVacationMode
    Private DaqBoard1 As MccDaq.MccBoard = New MccDaq.MccBoard(1)
    Private DaqBoard2 As MccDaq.MccBoard = New MccDaq.MccBoard(2)
    Dim iStartDelay As Integer
    Dim iTelephoneCounter As Integer
    Dim iMissedTelephone, iMissedVisitor As Integer
    Dim bTelephoneDetected As Boolean
    Dim MailStatus As Integer
    Dim iIgnoreMailCounter, iIgnoreSecurityCounter As Integer
    Dim bIgnoreMail, bIgnoreSecurity, bSoundPlayed As Boolean
    Dim bRandomWait, bLightsOn, bStairLights As Boolean
    Dim iLights As Integer
    Dim bSetBackDown, bSetBackUp As Boolean

#Region "Buttons"
    Private Sub btnDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisable.Click
        Dim mbResult As MsgBoxResult

        mbResult = MsgBox("Are you sure you want to disable Vacation Mode?", MsgBoxStyle.OkCancel, "Vacation Mode")
        If mbResult = MsgBoxResult.Ok Then
            Timer1.Stop()
            tStartDelay.Stop()
            tLights.Stop()
            tIntruderWarning.Stop()
            tHourly.Stop()
            Event_HistoryTableAdapter.InsertQuery("5013", Now)
            SetbackOff()
            MsgBox("While you were gone, you missed " & iMissedTelephone.ToString & " calls and " & iMissedVisitor & " visitors.", MsgBoxStyle.OkOnly, "Welcome Back")

            Me.Hide()
        End If
    End Sub



    Private Sub chkPause_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPause.CheckedChanged
        If chkPause.Checked Then
            Timer1.Stop()
            lblState.Text = "Paused"
        Else
            lblState.Text = "Running"
            Timer1.Start()
        End If
    End Sub

#End Region

#Region "Action Functions"

    Private Sub StartupCheck()
        Dim DIOVals1A_array(7), DIOVals1B_array(7) As Integer
        Dim DIOVals1CH_array(3), DIOVals1CL_array(3) As Integer
        Dim DIOVals1A, DIOVals1B, DIOVals1CH, DIOVals1CL As UShort
        Dim DIOVals2A_array(7), DIOVals2B_array(7) As Integer
        Dim DIOVals2CH_array(3), DIOVals2CL_array(3) As Integer
        Dim DIOVals2A, DIOVals2B As UShort
        Dim DIOVals2CH, DIOVals2CL As UShort
        Dim ULStat As MccDaq.ErrorInfo
        Dim bSecure As Boolean
        Dim strSendText As String

        'Read from Device 1 --> DIOVals1
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortA, DIOVals1A)
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortB, DIOVals1B)
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortCH, DIOVals1CH)
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortCL, DIOVals1CL)

        binConvert8(DIOVals1A_array, DIOVals1A)
        binConvert8(DIOVals1B_array, DIOVals1B)
        binConvert4(DIOVals1CH_array, DIOVals1CH)
        binConvert4(DIOVals1CL_array, DIOVals1CL)

        'Read from Device 2 --> DIOVals2
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortA, DIOVals2A)
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortB, DIOVals2B)
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortCL, DIOVals2CL)
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortCH, DIOVals2CH)

        binConvert8(DIOVals2A_array, DIOVals2A)
        binConvert8(DIOVals2B_array, DIOVals2B)
        binConvert4(DIOVals2CL_array, DIOVals2CL)
        binConvert4(DIOVals2CH_array, DIOVals2CH)

        'Check Security
        bSecure = True
        strSendText = "Before you leave, lock the following doors: " & Chr(13)
        If DIOVals1A_array(2) = 0 Then
            bSecure = False
            strSendText = strSendText & "BACK DOOR; "
        End If
        If DIOVals1B_array(4) = 0 Then
            bSecure = False
            strSendText = strSendText & "FRONT DOOR; "
        End If
        If DIOVals1CH_array(2) = 0 Then
            bSecure = False
            strSendText = strSendText & "GARAGE OUTSIDE DOOR; "
        End If
        If DIOVals2B_array(1) = 0 Then
            bSecure = False
            strSendText = strSendText & "BASEMENT DOOR"
        End If


        If Not bSecure Then
            SendTextMsg(strSendText)
        End If

    End Sub

    Private Function CheckHouse()
        Dim DIOVals1A_array(7), DIOVals1B_array(7) As Integer
        Dim DIOVals1CH_array(3), DIOVals1CL_array(3) As Integer
        Dim DIOVals1A, DIOVals1B, DIOVals1CH, DIOVals1CL As UShort
        Dim DIOVals2A_array(7), DIOVals2B_array(7) As Integer
        Dim DIOVals2CH_array(3), DIOVals2CL_array(3) As Integer
        Dim DIOVals2A, DIOVals2B As UShort
        Dim DIOVals2CH, DIOVals2CL As UShort
        Dim iResults As Integer
        Dim ULStat As MccDaq.ErrorInfo

        'Read from Device 1 --> DIOVals1
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortA, DIOVals1A)
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortB, DIOVals1B)
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortCH, DIOVals1CH)
        ULStat = DaqBoard1.DIn(MccDaq.DigitalPortType.FirstPortCL, DIOVals1CL)

        binConvert8(DIOVals1A_array, DIOVals1A)
        binConvert8(DIOVals1B_array, DIOVals1B)
        binConvert4(DIOVals1CH_array, DIOVals1CH)
        binConvert4(DIOVals1CL_array, DIOVals1CL)

        'Read from Device 2 --> DIOVals2
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortA, DIOVals2A)
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortB, DIOVals2B)
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortCL, DIOVals2CL)
        ULStat = DaqBoard2.DIn(MccDaq.DigitalPortType.FirstPortCH, DIOVals2CH)

        binConvert8(DIOVals2A_array, DIOVals2A)
        binConvert8(DIOVals2B_array, DIOVals2B)
        binConvert4(DIOVals2CL_array, DIOVals2CL)
        binConvert4(DIOVals2CH_array, DIOVals2CH)

        CheckSecurity(DIOVals1B_array(3), DIOVals1A_array(1), DIOVals1CL_array(3), _
                      DIOVals1CH_array(1), DIOVals2B_array(0), DIOVals2B_array(5), _
                      DIOVals2B_array(6), DIOVals2B_array(4), DIOVals2CH_array(0))

        CheckMail(DIOVals1CH_array(2))

        CheckTelephone(DIOVals2CL_array(0))

        'Check Doorbell
        If DIOVals2B_array(7) = 1 Then
            iMissedVisitor = iMissedVisitor + 1
            lblMissedVisitor.Text = iMissedVisitor.ToString
        End If

        'Update Database
        iResults = Event_Current_StateTableAdapter.UpdateAll1(Now, DIOVals1CL_array(3), DIOVals1CL_array(2), _
                                                              DIOVals1CL_array(1), DIOVals1CH_array(0), DIOVals1CH_array(1), _
                                                              DIOVals1B_array(7), DIOVals1CL_array(0), DIOVals1A_array(0), _
                                                              DIOVals1A_array(1), DIOVals1A_array(2), DIOVals1A_array(4), _
                                                              DIOVals1A_array(3), DIOVals1A_array(6), DIOVals1A_array(5), _
                                                              DIOVals1A_array(7), DIOVals1B_array(0), DIOVals1B_array(1), _
                                                              DIOVals1B_array(2), DIOVals1B_array(3), DIOVals1B_array(4), _
                                                              DIOVals1B_array(5), DIOVals1B_array(6), DIOVals2A_array(0), _
                                                              DIOVals2A_array(1), DIOVals2A_array(2), DIOVals2A_array(3), _
                                                              DIOVals2A_array(4), DIOVals2A_array(5), DIOVals2A_array(6), _
                                                              DIOVals2A_array(7), MailStatus, DIOVals2B_array(0), _
                                                              DIOVals2B_array(1), DIOVals2B_array(2), DIOVals2B_array(3), _
                                                              DIOVals2B_array(5), DIOVals2B_array(6), DIOVals2B_array(4), _
                                                              DIOVals2B_array(7), DIOVals2CL_array(0), DIOVals2CL_array(1), _
                                                              DIOVals2CL_array(2), DIOVals2CL_array(3), DIOVals2CH_array(0), _
                                                              DIOVals2CH_array(1), 0, DIOVals2CH_array(2))

        If iResults > 0 Then
            Me.Event_ListTableAdapter.Fill(Me.WatchdogDataSet1.Event_List)
            Event_Current_StateTableAdapter.Fill(WatchdogDataSet.Event_Current_State)
        End If

        CheckHouse = 0
    End Function

    Public Sub CheckSecurity(ByVal iFrontDoor As Integer, ByVal iBackDoor As Integer, ByVal iGarageDoor As Integer, ByVal iGarageOutsideDoor As Integer, ByVal iBasementDoor As Integer, ByRef iSRMotion As Integer, ByRef iGRMotion As Integer, ByRef iUHMotion As Integer, ByRef iBMotion As Integer)

        If Not bSoundPlayed And (iSRMotion = 0 Or iGRMotion = 0 Or iUHMotion = 0 Or iBMotion = 0) Then
            bSoundPlayed = True
            PlayIt(5014)
            tIntruderWarning.Start()
        End If

        If Not bIgnoreSecurity Then
            If iFrontDoor = 0 Or iBackDoor = 0 Or iBasementDoor = 0 Or iGarageDoor = 0 Or iGarageOutsideDoor = 0 Or iSRMotion = 0 Or iGRMotion = 0 Or iUHMotion = 0 Or iBMotion = 0 Then
                bIgnoreSecurity = True
                SendTextMsg("Possible security breach at the house.")
                Event_HistoryTableAdapter.InsertQuery("5014", Now)
                lblState.Text = "Sleeping"
            End If
        Else
            iIgnoreSecurityCounter += 1
            iSRMotion = 1
            iGRMotion = 1
            iUHMotion = 1
            iBMotion = 1
        End If

        'Ignore for 2 hours
        If iIgnoreSecurityCounter = 16000 Then
            bIgnoreSecurity = False
            iIgnoreSecurityCounter = 0
            bSoundPlayed = False
            lblState.Text = "Running"
        End If

        If Geofence_ReachedLabel1.Text = "1" Then
            Event_Current_StateTableAdapter.ResetGeoFence()
            SetbackOff()
        End If

    End Sub

    Public Sub CheckMail(ByVal iCurrentMail As Integer)

        If Not bIgnoreMail Then
            If MailStatus = 0 And iCurrentMail = 1 Then         'Mail not delivered yet
                MailStatus = 0
            ElseIf MailStatus = 0 And iCurrentMail = 0 Then     'Mail is being delivered
                MailStatus = 1
                bIgnoreMail = True
            ElseIf MailStatus = 1 And iCurrentMail = 1 Then     'Mail has been delivered
                MailStatus = 1
            ElseIf MailStatus = 1 And iCurrentMail = 0 Then     'Mail being retrieved
                MailStatus = 2
                bIgnoreMail = True
            ElseIf MailStatus = 2 And iCurrentMail = 1 Then     'Mail was retrieved
                MailStatus = 2
            End If
        Else
            'Mailbox door could be open for up to 2 minutes getting/retrieving mail
            iIgnoreMailCounter = iIgnoreMailCounter + 1
            If iIgnoreMailCounter = 240 Then
                iIgnoreMailCounter = 0
                bIgnoreMail = False
            End If
        End If

    End Sub

    Public Function PlayIt(ByVal iCode As Integer) As Integer
        Dim WavPlay1 As New System.Media.SoundPlayer
        Dim strPath As String = "c:\Progra~1\Watchdog\"

        Select Case iCode
            Case 5014
                WavPlay1.SoundLocation() = strPath & "Intruder.wav"
        End Select
        Try
            WavPlay1.Load()
            WavPlay1.PlaySync()
        Catch ex As Exception
            Return 1
        End Try
        Return 0

    End Function

    Public Sub SpeakIt(ByVal SpeakText As String)
        Dim SpeakIt As System.Diagnostics.Process = New System.Diagnostics.Process

        SpeakIt.StartInfo.UseShellExecute = False
        SpeakIt.StartInfo.CreateNoWindow = True
        SpeakIt.StartInfo.FileName = "WDPlay_Voice.exe"
        SpeakIt.StartInfo.Arguments = SpeakText
        Try
            SpeakIt.Start()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SendTextMsg(ByVal MsgText As String)
        Dim SendIt As System.Diagnostics.Process

        SendIt = New System.Diagnostics.Process
        SendIt.StartInfo.UseShellExecute = False
        SendIt.StartInfo.CreateNoWindow = True
        SendIt.StartInfo.FileName = "WDSendTextMsg.exe"
        Try
            SendIt.StartInfo.Arguments = "5133287911 " & MsgText
            SendIt.Start()
            SendIt.StartInfo.Arguments = "5135445316 " & MsgText
            SendIt.Start()
        Catch ex As Exception
        End Try
        Event_HistoryTableAdapter.InsertQuery("5009", Now)

    End Sub

    Public Sub CheckTelephone(ByRef iTelephone As Integer)
        'Check Telephone
        If Not bTelephoneDetected Then
            If iTelephone = 1 Then
                bTelephoneDetected = True
                iMissedTelephone = iMissedTelephone + 1
                lblMissedTelephone.Text = iMissedTelephone.ToString
            End If
        Else
            iTelephoneCounter = iTelephoneCounter + 1
            iTelephone = 0
            If iTelephoneCounter >= 60 Then
                'Ignore for 1 minutes - avoid detect of multiple rings
                bTelephoneDetected = False
                iTelephoneCounter = 0
            End If
        End If

    End Sub

    Private Sub CheckLeak()
        If Leak_DetectedLabel2.Text = "1" Then
            Event_HistoryTableAdapter.InsertQuery("5034", Now())
            SendTextMsg("Leak Detected.")
            Event_Current_StateTableAdapter.ResetLeakDetected()
        End If
    End Sub

#End Region

#Region "Timers"

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Runs once every .45 seconds

        Timer1.Stop()
        If CheckHouse() = 0 Then
            'handle error
        End If

        If Geofence_ReachedLabel2.Text = "1" Then
            Event_Current_StateTableAdapter.ResetGeoFence()
            tStartDelay.Stop()
            tLights.Stop()
            tIntruderWarning.Stop()
            tHourly.Stop()
            Event_HistoryTableAdapter.InsertQuery("5013", Now)
            SetbackOff()
            SendTextMsg("Welcome Back.  While you were gone, you missed " & iMissedTelephone.ToString & " calls and " & iMissedVisitor & " visitors.")
            Me.Hide()
        Else
            Timer1.Start()
        End If
    End Sub


    Private Sub tHourly_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tHourly.Tick
        CheckLeak()

        'Reset Mail Status
        If Hour(Now) = 10 Then
            MailStatus = 0
        End If

        'Restate House is unoccupied
        If Hour(Now) = 0 Then
            Event_HistoryTableAdapter.InsertQuery("5024", Now)
        End If
    End Sub

    Private Sub tLights_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tLights.Tick
        'Runs once per hour to activate lights
        'Need a separate hourly timer for lights since the interval is adjusted

        tLights.Stop()
        'If Not bStairLights And Stair_LightsLabel1.Text = "1" Then
        '    LightSet0On()
        '    bStairLights = True
        'ElseIf bStairLights And Stair_LightsLabel1.Text = "0" Then
        '    LightSet0Off()
        '    LightSet1Off()
        '    LightSet2Off()
        '    bStairLights = False
        'End If

        If (Hour(Now) = 19 Or Hour(Now) = 20) And Not bLightsOn Then
            'Wait a random interval before turning on the lights
            Thread.Sleep(Second(Now) * 20000)
            'Turn on the lights one set at a time
            If iLights = 2 Then
                LightSet2On()
                tLights.Interval = 1800000  '30 min
                bLightsOn = True
                iLights = 0
            End If
            If iLights = 1 Then
                LightSet1On()
                tLights.Interval = 600000  '10 min
                iLights = 2
            End If
            If iLights = 0 Then
                LightSet0On()
                tLights.Interval = 600000  '10 min
                iLights = 1
            End If
        End If

        If (Hour(Now) = 23 Or Hour(Now) = 0) And bLightsOn Then
            'Wait a random interval before turning on the lights
            Thread.Sleep(Second(Now) * 20000)

            'Turn off the lights one set at a time
            If iLights = 2 Then
                LightSet2Off()
                tLights.Interval = 1800000 '30 min
                bLightsOn = False
                iLights = 0
            End If
            If iLights = 1 Then
                LightSet1Off()
                tLights.Interval = 600000  '10 min
                iLights = 2
            End If
            If iLights = 0 Then
                LightSet0Off()
                tLights.Interval = 600000  '10 min
                iLights = 1
            End If
        End If

        tLights.Start()
    End Sub

    Private Sub tIntruderWarning_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tIntruderWarning.Tick
        'Need this because sound and voice will play at same time.
        tIntruderWarning.Stop()
        SpeakIt("Intruder Detected.  The home owners have been notified")
    End Sub

    Private Sub tStartDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tStartDelay.Tick
        'Waits 5 minutes to start Vacation Mode
        iStartDelay = iStartDelay - 1
        lblCountDown.Text = iStartDelay.ToString

        If iStartDelay = 180 Then
            'Check house 2 minutes after activating and send text message if unsecure
            StartupCheck()
        End If

        If iStartDelay = 60 Then
            'One minute before activation, warn that Vacation Mode will be activated
            SpeakIt("Warning, Vacation Mode will activate in one minute")
            Insteon_ControlTableAdapter.Request_All_Off()
        End If

        If iStartDelay = 0 Then
            tStartDelay.Stop()
            lblCountDown.Visible = False
            lblState.Text = "Running"
            chkPause.Enabled = True
            SendTextMsg("Vacation Mode Activated - Have a nice trip")
            Event_HistoryTableAdapter.InsertQuery("5012", Now)
            SetbackOn()
            tLights.Start()
            Timer1.Start()
            tHourly.Start()
        End If
    End Sub

#End Region

    Private Sub frmVacationMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ULStat As MccDaq.ErrorInfo

        iTelephoneCounter = 0
        iMissedTelephone = 0
        iMissedVisitor = 0
        MailStatus = 0
        bTelephoneDetected = False
        iIgnoreMailCounter = 0
        bIgnoreMail = False
        iIgnoreSecurityCounter = 0
        bIgnoreSecurity = False
        bRandomWait = False
        iLights = 0
        bSetBackDown = False
        bSetBackUp = False
        If Hour(Now) <= 20 Then
            bLightsOn = False
        Else
            bLightsOn = True
        End If
        bSoundPlayed = False
        lblState.Text = "Starting In"
        lblCountDown.Visible = True
        lblCountDown.Text = "300"
        bStairLights = False

        Me.Event_ListTableAdapter.Fill(Me.WatchdogDataSet1.Event_List)

        ' Configure Ports
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortA, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortB, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortCL, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortCH, MccDaq.DigitalPortDirection.DigitalIn)

        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortA, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortB, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortCL, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortCH, MccDaq.DigitalPortDirection.DigitalIn)


        iStartDelay = 300
        tStartDelay.Start()
    End Sub

    Public Sub binConvert8(ByRef binArray() As Integer, ByVal iNumber As UShort)
        Dim i As Integer

        For i = 0 To 7
            binArray(i) = 1
        Next

        If iNumber >= 128 Then
            binArray(7) = 0
            iNumber = iNumber - 128
        End If

        If iNumber >= 64 Then
            binArray(6) = 0
            iNumber = iNumber - 64
        End If

        If iNumber >= 32 Then
            binArray(5) = 0
            iNumber = iNumber - 32
        End If

        If iNumber >= 16 Then
            binArray(4) = 0
            iNumber = iNumber - 16
        End If

        If iNumber >= 8 Then
            binArray(3) = 0
            iNumber = iNumber - 8
        End If

        If iNumber >= 4 Then
            binArray(2) = 0
            iNumber = iNumber - 4
        End If

        If iNumber >= 2 Then
            binArray(1) = 0
            iNumber = iNumber - 2
        End If

        If iNumber >= 1 Then
            binArray(0) = 0
            iNumber = iNumber - 1
        End If

    End Sub

    Public Sub binConvert4(ByRef binArray() As Integer, ByVal iNumber As UShort)
        Dim i As Integer

        For i = 0 To 3
            binArray(i) = 1
        Next

        If iNumber >= 8 Then
            binArray(3) = 0
            iNumber = iNumber - 8
        End If

        If iNumber >= 4 Then
            binArray(2) = 0
            iNumber = iNumber - 4
        End If

        If iNumber >= 2 Then
            binArray(1) = 0
            iNumber = iNumber - 2
        End If

        If iNumber >= 1 Then
            binArray(0) = 0
            iNumber = iNumber - 1
        End If

    End Sub

#Region "Lights and Temp"

    Public Sub LightSet1On()
        Insteon_ControlTableAdapter.Request_State_Change(255, "23.C5.30")  'Sydney Bedroom
        Insteon_ControlTableAdapter.Request_State_Change(255, "23.B6.EB")  'Ethan Bedroom
        Event_HistoryTableAdapter.InsertQuery("5036", Now())

    End Sub

    Public Sub LightSet1Off()
        Insteon_ControlTableAdapter.Request_State_Change(0, "23.C5.30")  'Sydney Bedroom
        'leave Ethan's light on since it automatically dims
        Event_HistoryTableAdapter.InsertQuery("5036", Now())

    End Sub

    Public Sub LightSet2On()
        Insteon_ControlTableAdapter.Request_State_Change(255, "20.E5.84")  'Master Bedroom
        Insteon_ControlTableAdapter.Request_State_Change(1, "23.E2.E4")    'Master Bathroom
        Event_HistoryTableAdapter.InsertQuery("5036", Now())

    End Sub

    Public Sub LightSet2Off()
        Insteon_ControlTableAdapter.Request_State_Change(0, "20.E5.84")  'Master Bedroom
        Insteon_ControlTableAdapter.Request_State_Change(0, "23.E2.E4")  'Master Bathroom
        Event_HistoryTableAdapter.InsertQuery("5036", Now())

    End Sub

    Public Sub LightSet0On()
        Insteon_ControlTableAdapter.Request_State_Change(1, "22.10.09")  'Kitchen
        Insteon_ControlTableAdapter.Request_State_Change(1, "1A.F4.47")  'Spider Lamp
        Insteon_ControlTableAdapter.Request_State_Change(1, "22.10.0C")  'Art Room
        Event_HistoryTableAdapter.InsertQuery("5036", Now())

    End Sub

    Public Sub LightSet0Off()
        Insteon_ControlTableAdapter.Request_State_Change(0, "22.10.09")  'Kitchen
        Insteon_ControlTableAdapter.Request_State_Change(0, "1A.F4.47")  'Spider Lamp
        Insteon_ControlTableAdapter.Request_State_Change(0, "22.10.0C")  'Art Room
        Event_HistoryTableAdapter.InsertQuery("5036", Now())

    End Sub

    Public Sub SetbackOn()
        Dim iOutsideTemp

        iOutsideTemp = GetOutsideTemp()

        'If heat is on, decrease temp by 3 degrees
        If iOutsideTemp <= 65 Then
            bSetBackDown = True
            Temp_ControlTableAdapter.Request_Temp_Change("H", "-", 3)
            Event_HistoryTableAdapter.InsertQuery("5027", Now())
        End If

        'If AC is on, increase temp by 3 degrees
        If iOutsideTemp >= 73 Then
            bSetBackUp = True
            Temp_ControlTableAdapter.Request_Temp_Change("C", "+", 3)
            Event_HistoryTableAdapter.InsertQuery("5026", Now())

        End If
    End Sub

    Public Sub SetbackOff()
        If bSetBackDown Then
            bSetBackDown = False
            Temp_ControlTableAdapter.Request_Temp_Change("H", "+", 3)
            Event_HistoryTableAdapter.InsertQuery("5026", Now())

        End If
        If bSetBackUp Then
            bSetBackUp = False
            Temp_ControlTableAdapter.Request_Temp_Change("C", "-", 3)
            Event_HistoryTableAdapter.InsertQuery("5027", Now())

        End If
    End Sub

    Public Function GetOutsideTemp() As Integer
        Dim iConnectStringLen As Integer
        Dim Temp_DB As WatchdogDataSet.Temp_Current_StateDataTable
        Dim iOutsideTemp

        iConnectStringLen = Temp_Current_StateTableAdapter.Connection.ConnectionString.Length
        Temp_Current_StateTableAdapter.Connection.ConnectionString = Temp_Current_StateTableAdapter.Connection.ConnectionString.Insert(iConnectStringLen, ";password=lEEward1")
        Temp_DB = Temp_Current_StateTableAdapter.GetDataBy()

        iOutsideTemp = Int(Temp_DB.Rows(0).Item(7).ToString)
        Temp_DB = Nothing

        Return iOutsideTemp

    End Function
#End Region

End Class