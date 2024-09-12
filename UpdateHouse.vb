Public Class frmMain
    Const SUMMER_MIN = 73
    Const SUMMER_MAX = 78
    Const WINTER = 68

    Private DaqBoard1 As MccDaq.MccBoard = New MccDaq.MccBoard(1)
    Private DaqBoard2 As MccDaq.MccBoard = New MccDaq.MccBoard(2)
    Dim MailStatus As Integer
    Dim iIgnoreMailCounter As Integer
    Dim bIgnoreMail As Boolean
    Dim iBKDoorCounter, iFDoorCounter, iMudRmDoorCounter, iBasDoorCounter, iGDoorCounter As Integer
    Dim iSRMotionCounter, iUHMotionCounter, iGRMotionCounter, iBMotionCounter, iEXMotionCounter As Integer
    Dim bSRMotionDetected, bUHMotionDetected, bGRMotionDetected, bBMotionDetected, bEXMotionDetected As Boolean
    Dim bTelephoneDetected As Boolean
    Dim iTelephoneCounter As Integer
    Dim bHouseEmptyCheck, bHouseEmptyConfirmed, bMomCarGone, bDadCarGone, bGreetMe As Boolean
    Dim iTelephoneAway, iDoorBellAway, iMailAway, iHouseEmptyCheckCounter As Integer
    Dim bRaisedTemp, bLoweredTemp, bNightLightOff1, bNightLightOff2 As Boolean
    Dim bSetBackDown, bSetBackUp As Boolean
    Dim iTempDelta As Integer
    Dim bGeoFenceReached, bRoombaRun As Boolean
    Dim iLizardFed As Integer


    Private Sub InitializeHouse()
        ' Set Default Values
        MailStatus = Int(MailboxLabel1.Text)
        iIgnoreMailCounter = 0
        bIgnoreMail = False
        iBKDoorCounter = 0
        iFDoorCounter = 0
        iMudRmDoorCounter = 0
        iBasDoorCounter = 0
        iGDoorCounter = 0
        iSRMotionCounter = 0
        bSRMotionDetected = False
        iUHMotionCounter = 0
        bUHMotionDetected = False
        iGRMotionCounter = 0
        bGRMotionDetected = False
        iBMotionCounter = 0
        bBMotionDetected = False
        iEXMotionCounter = 0
        bEXMotionDetected = False
        iTelephoneCounter = 0
        bTelephoneDetected = False
        bHouseEmptyCheck = False
        bHouseEmptyConfirmed = False
        iTelephoneAway = 0
        iDoorBellAway = 0
        iMailAway = 0
        iHouseEmptyCheckCounter = 0
        bMomCarGone = False
        bDadCarGone = False
        bGeoFenceReached = False
        bRoombaRun = False
        iLizardFed = 0

        'WarnLizardFed()
        CheckLizardTemp()

        bRaisedTemp = False
        bLoweredTemp = False
        iTempDelta = 0
        bSetBackDown = False
        bSetBackUp = False
        bNightLightOff1 = False
        bNightLightOff2 = False


    End Sub

#Region "Checkers"

    Function CheckHouse() As Integer
        Dim DIOVals1A_array(7), DIOVals1B_array(7) As Integer
        Dim DIOVals1CH_array(3), DIOVals1CL_array(3) As Integer
        Dim DIOVals1A, DIOVals1B, DIOVals1CH, DIOVals1CL As UShort
        Dim DIOVals2A_array(7), DIOVals2B_array(7) As Integer
        Dim DIOVals2CH_array(3), DIOVals2CL_array(3) As Integer
        Dim DIOVals2A, DIOVals2B As UShort
        Dim DIOVals2CH, DIOVals2CL As UShort
        Dim iResults, iHouseOccupied As Integer
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

        CheckMotion(DIOVals2B_array(5), DIOVals2B_array(4), DIOVals2B_array(6), DIOVals2CH_array(0), DIOVals2CH_array(1))

        CheckHouseEmpty(DIOVals2CL_array(1), DIOVals2CL_array(2), DIOVals2B_array(5), DIOVals2B_array(6), DIOVals2B_array(4), DIOVals2CH_array(0))

        If bHouseEmptyConfirmed Then
            iHouseOccupied = 0
        Else
            iHouseOccupied = 1
        End If

        CheckDoor(DIOVals1A_array(1), DIOVals1A_array(2), DIOVals1B_array(3), DIOVals1B_array(4), DIOVals1B_array(7), DIOVals1CL_array(0), _
                  DIOVals2B_array(0), DIOVals2B_array(1), DIOVals1CL_array(3), DIOVals1CH_array(0), DIOVals1CH_array(1))

        CheckTelephone(DIOVals2CL_array(0))

        CheckDoorbell(DIOVals2B_array(7))

        CheckMail(DIOVals1CH_array(2))

        CheckLeak()

        If chkWrite.Checked Then

            'Update Database
            Try
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
                                                                      1, DIOVals2B_array(2), 1, _
                                                                      DIOVals2B_array(5), DIOVals2B_array(6), DIOVals2B_array(4), _
                                                                      DIOVals2B_array(7), DIOVals2CL_array(0), DIOVals2CL_array(1), _
                                                                      DIOVals2CL_array(2), DIOVals2CL_array(3), DIOVals2CH_array(0), _
                                                                      DIOVals2CH_array(1), iHouseOccupied, DIOVals2CH_array(2))
            Catch e As Exception
                iResults = 0
            End Try

            If iResults > 0 Then
                'Update Labels on screen
                Event_Current_StateTableAdapter.Fill(WatchdogDataSet.Event_Current_State)
            End If
        Else
            Garage_DoorLabel1.Text = DIOVals1CL_array(3).ToString
            Garage_Window_SouthLabel1.Text = DIOVals1CL_array(2).ToString
            Garage_Window_NorthLabel1.Text = DIOVals1CL_array(1).ToString
            Garage_Outside_DoorLabel1.Text = DIOVals1CH_array(0).ToString
            Garage_Outside_Door_LockLabel1.Text = DIOVals1CH_array(1).ToString
            Garage_Inside_DoorLabel1.Text = DIOVals1B_array(7).ToString
            Garage_Inside_Door_LockLabel1.Text = DIOVals1CL_array(0).ToString
            Kitchen_WindowLabel1.Text = DIOVals1A_array(0).ToString
            Back_DoorLabel1.Text = DIOVals1A_array(1).ToString
            Back_Door_LockLabel1.Text = DIOVals1A_array(2).ToString
            Great_Room_Window_SouthLabel1.Text = DIOVals1A_array(4).ToString
            Great_Room_Window_NorthLabel1.Text = DIOVals1A_array(3).ToString
            Play_Room_Window_SouthLabel1.Text = DIOVals1A_array(6).ToString
            Play_Room_window_NorthLabel1.Text = DIOVals1A_array(5).ToString
            Famiy_Room_Window_SouthLabel1.Text = DIOVals1A_array(7).ToString
            Family_Room_Window_Front_SouthLabel1.Text = DIOVals1B_array(0).ToString
            Family_Room_Window_Front_MiddleLabel1.Text = DIOVals1B_array(1).ToString
            Family_Room_Window_Front_NorthLabel1.Text = DIOVals1B_array(2).ToString
            Front_DoorLabel1.Text = DIOVals1B_array(3).ToString
            Front_Door_LockLabel1.Text = DIOVals1B_array(4).ToString
            Dining_Room_Window_SouthLabel1.Text = DIOVals1B_array(5).ToString
            Dining_Room_Window_NorthLabel1.Text = DIOVals1B_array(6).ToString
            Master_Bath_WindowLabel1.Text = DIOVals2A_array(0).ToString
            Master_Bedroom_Window_SouthLabel1.Text = DIOVals2A_array(1).ToString
            Master_Bedroom_Window_Back_SouthLabel1.Text = DIOVals2A_array(2).ToString
            Master_Bedroom_Window_Back_NorthLabel1.Text = DIOVals2A_array(3).ToString
            Sydney_Bedroom_WindowLabel1.Text = DIOVals2A_array(4).ToString
            Ethan_Bedroom_WindowLabel1.Text = DIOVals2A_array(5).ToString
            Spare_Bedroom_Window_NorthLabel1.Text = DIOVals2A_array(6).ToString
            Spare_Bedroom_Window_SouthLabel1.Text = DIOVals2A_array(7).ToString
            MailboxLabel1.Text = MailStatus.ToString
            Basement_DoorLabel1.Text = DIOVals2B_array(0).ToString
            'Basement_Door_LockLabel1.Text = DIOVals2B_array(1).ToString
            Basement_Door_LockLabel1.Text = "1"
            Basement_Window_SouthLabel1.Text = DIOVals2B_array(2).ToString
            'Basement_Window_NorthLabel1.Text = DIOVals2B_array(3).ToString
            Basement_Window_NorthLabel1.Text = "1"
            Basement_Storage_DoorLabel1.Text = DIOVals2CL_array(3).ToString
            Server_Room_MotionLabel1.Text = DIOVals2B_array(5).ToString
            Great_Room_MotionLabel1.Text = DIOVals2B_array(6).ToString
            Upstairs_Hallway_MotionLabel1.Text = DIOVals2B_array(4).ToString
            Basement_MotionLabel1.Text = DIOVals2CH_array(0).ToString
            Exterior_MotionLabel1.Text = DIOVals2CH_array(1).ToString
            DoorbellLabel1.Text = DIOVals2B_array(7).ToString
            TelephoneLabel1.Text = DIOVals2CL_array(0).ToString
            Car_WestLabel1.Text = DIOVals2CL_array(1).ToString
            Car_EastLabel1.Text = DIOVals2CL_array(2).ToString
            Garbage_CanLabel1.Text = DIOVals2CH_array(2).ToString

        End If
        CheckHouse = iResults

    End Function

    Public Sub CheckLeak()
        If Leak_DetectedLabel1.Text = "1" Then
            Try
                Event_HistoryTableAdapter.InsertQuery("5034", Now())
                SpeakIt("Warning, Leak Detected.  Check all water valves immediately.")
                SendTextMsg("Leak Detected.")
                Event_Current_StateTableAdapter.ResetLeakDetected()
            Catch ex As Exception
            End Try

        End If
    End Sub

    Public Sub CheckDoorbell(ByVal iDoorbell As Integer)
        If iDoorbell = 1 Then
            If bHouseEmptyConfirmed Then
                iDoorBellAway = iDoorBellAway + 1
            Else
                Try
                    Insteon_ControlTableAdapter.Request_State_Change(1, "G5")
                    Event_HistoryTableAdapter.InsertQuery("5036", Now())
                    If Stair_LightsLabel1.Text = "1" Then
                        Insteon_ControlTableAdapter.Request_State_Change(1, "33.67.22")
                        Insteon_ControlTableAdapter.Request_State_Change(1, "2B.80.FF")
                        Event_HistoryTableAdapter.InsertQuery("5036", Now())
                        tFDCoachLightOff.Start()
                    End If
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Public Sub CheckHouseEmpty(ByVal iDadsCar As Integer, ByVal iMomsCar As Integer, ByVal iSRMotion As Integer, ByVal iGRMotion As Integer, ByVal iUHMotion As Integer, ByVal iBMotion As Integer)
        Dim bCarJustLeft, bCarJustArrived As Boolean
        Dim iWhoJustLeft As Integer = 0

        bCarJustLeft = False
        bCarJustArrived = False

        If Not bHouseEmptyCheck Then
            'House is Occupied 
            If iDadsCar = 0 And bDadCarGone = False Then
                bCarJustLeft = True
                bDadCarGone = True
                iWhoJustLeft = 1
            End If
            If iMomsCar = 0 And bMomCarGone = False Then
                bCarJustLeft = True
                bMomCarGone = True
                iWhoJustLeft = 2
            End If

            If bCarJustLeft Then
                bHouseEmptyCheck = True
                iTelephoneAway = 0
                iDoorBellAway = 0
                iHouseEmptyCheckCounter = 0
                lblOccupied.Text = "Checking"
                SendTextMsg(iWhoJustLeft)
                bSRMotionDetected = False
                iSRMotionCounter = 0
                bBMotionDetected = False
                iBMotionCounter = 0
                bUHMotionDetected = False
                iUHMotionCounter = 0
                bGRMotionDetected = False
                iGRMotionCounter = 0
            Else
                'Car arrived while house is occupied
                If iDadsCar = 1 And bDadCarGone = True Then
                    bDadCarGone = False
                End If
                If iMomsCar = 1 And bMomCarGone = True Then
                    bMomCarGone = False
                End If
            End If

            If bGreetMe And iGRMotion = 0 Then
                GreetArrival()
                iTelephoneAway = 0
                iDoorBellAway = 0
                iMailAway = 0
                bGreetMe = False
            End If

        Else
            'House is Unoccupied
            If iGRMotion = 0 Or iSRMotion = 0 Or iUHMotion = 0 Or iBMotion = 0 Then
                DeactivateTempChange()
                If bHouseEmptyConfirmed Then
                    Try
                        Dim Event_History_DB As WatchdogDataSet1.Event_HistoryDataTable
                        'GetLastUnoccupied
                        Event_History_DB = Event_HistoryTableAdapter.GetLastUnoccupied()
                        If Event_History_DB.Rows.Count = 1 Then
                            'DeleteLastUnoccupied
                            Event_HistoryTableAdapter.DeleteLogEntry(Event_History_DB.Rows(0).Item(0))
                        End If
                    Catch ex As Exception
                    End Try
                End If

                bTelephoneDetected = True  'block any false alarms from WDCallForwarding
                iTelephoneCounter = 0
                lblOccupied.Text = "Occupied"
                bHouseEmptyCheck = False
                bHouseEmptyConfirmed = False
            Else
                If iHouseEmptyCheckCounter <= 600 Then
                    iHouseEmptyCheckCounter = iHouseEmptyCheckCounter + 1
                End If
                If iHouseEmptyCheckCounter = 480 Then
                    PlayIt(5024)    '1 minute reminder
                End If
                If iHouseEmptyCheckCounter = 600 Then
                    Try
                        'Turn lights off and activate Thermostat setback 5 minutes after house becomes empty
                        Insteon_ControlTableAdapter.Request_All_Off()
                        Event_HistoryTableAdapter.InsertQuery("5036", Now())
                        ActivateTempChange()
                        bHouseEmptyConfirmed = True
                        lblOccupied.Text = "Unoccupied"
                        Event_HistoryTableAdapter.InsertQuery("5024", Now)
                        bGeoFenceReached = False
                        Event_Current_StateTableAdapter.ResetGeoFence()  'Reset just in case it was not done properly last time
                        Event_Current_StateTableAdapter.ResetRoombaRun()
                        Geofence_ReachedLabel1.Text = "0"
                        bTelephoneDetected = True  'block any false alarms from WDCallForwarding
                        iTelephoneCounter = 0
                    Catch ex As Exception
                    End Try
                End If

                'Did a car just arrive?
                If iDadsCar = 1 And bDadCarGone = True Then
                    bCarJustArrived = True
                    bDadCarGone = False
                End If
                If iMomsCar = 1 And bMomCarGone = True Then
                    bCarJustArrived = True
                    bMomCarGone = False
                End If

                'Check GeoFence
                If bHouseEmptyConfirmed And Geofence_ReachedLabel1.Text = "1" Then
                    Try
                        bGeoFenceReached = True
                        Event_Current_StateTableAdapter.ResetGeoFence()
                        DeactivateTempChange()
                    Catch ex As Exception
                    End Try
                End If

                'Check Roomba Run
                If bHouseEmptyConfirmed And lblRoombaRun.Text = "1" Then
                    Try
                        bRoombaRun = True
                        Event_Current_StateTableAdapter.ResetRoombaRun()
                    Catch ex As Exception
                    End Try
                End If

                If bCarJustArrived Then
                    lblOccupied.Text = "Occupied"
                    If bHouseEmptyConfirmed Then
                        Event_HistoryTableAdapter.InsertQuery("5023", Now)
                    End If
                    bTelephoneDetected = True  'block any false alarms from WDCallForwarding
                    iTelephoneCounter = 0
                    bHouseEmptyCheck = False
                    bHouseEmptyConfirmed = False
                    bGreetMe = True
                    If Not bGeoFenceReached Then
                        DeactivateTempChange()
                    End If

                    'Turn lights on if stair lights are on (it's dark outside)
                    If Stair_LightsLabel1.Text = "1" Then
                        Try
                            Thread.Sleep(100)  'Pause to wait for Thermostat Reset
                            Insteon_ControlTableAdapter.Request_On_Return_Home()
                            Event_HistoryTableAdapter.InsertQuery("5036", Now())

                            'Turn on RGB lights with Xbee;  They go off automatically

                            Dim serialPort1 As System.IO.Ports.SerialPort
                            serialPort1 = New System.IO.Ports.SerialPort("COM5")
                            serialPort1.BaudRate = 9600
                            serialPort1.DataBits = 8
                            serialPort1.Parity = Parity.None
                            serialPort1.StopBits = StopBits.One

                            serialPort1.Open()
                            serialPort1.Write("r=255, g=255, b=255" & Chr(13))
                            serialPort1.Close()
                            Event_HistoryTableAdapter.InsertQuery("5035", Now())
                        Catch ex As Exception
                            'Do nothing
                        End Try
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub CheckTelephone(ByRef iTelephone As Integer)
        'Check Telephone
        If Not bTelephoneDetected Then
            If iTelephone = 1 Then
                bTelephoneDetected = True
                iTelephoneCounter = 0
                If bHouseEmptyConfirmed Then
                    iTelephoneAway = iTelephoneAway + 1
                End If
            End If
        Else
            iTelephoneCounter = iTelephoneCounter + 1
            iTelephone = 0
            If iTelephoneCounter >= 120 Then
                'Ignore for 1 minutes - avoid detect of multiple rings
                bTelephoneDetected = False
                iTelephoneCounter = 0
            End If
        End If

    End Sub

    Public Sub CheckMotion(ByRef iSRMotion As Integer, ByRef iUHMotion As Integer, ByRef iGRMotion As Integer, ByRef iBMotion As Integer, ByRef iExMotion As Integer)
        'Note:  Motion Sensors have Normally Closed Circuits:  0 = Movement (except External Cameras)

        'Check Server Room
        If Not bSRMotionDetected Then
            If iSRMotion = 0 Then
                bSRMotionDetected = True
            End If
        Else
            iSRMotionCounter = iSRMotionCounter + 1
            iSRMotion = 1
            'If iSRMotionCounter >= 900 Then
            If iSRMotionCounter >= 1800 Then
                'Ignore for 15 minutes
                bSRMotionDetected = False
                iSRMotionCounter = 0
            End If
        End If


        'Check Great Room
        If Not bGRMotionDetected Then
            If iGRMotion = 0 Then
                bGRMotionDetected = True
            End If
        Else
            iGRMotionCounter = iGRMotionCounter + 1
            iGRMotion = 1
            'If iGRMotionCounter >= 900 Then
            If iGRMotionCounter >= 1800 Then
                'Ignore for 15 minutes
                bGRMotionDetected = False
                iGRMotionCounter = 0
            End If
        End If

        'Check Upstairs Hallway
        If Not bUHMotionDetected Then
            'If (Hour(Now) < 22 And Hour(Now) > 6) Then
            iUHMotion = 1
            'Else
            'If iUHMotion = 0 And chkMute.Checked = False Then
            'bUHMotionDetected = True
            'PlayIt(6002)
            'End If
            'End If
        Else
        iUHMotionCounter = iUHMotionCounter + 1
        iUHMotion = 1
        'If iUHMotionCounter >= 300 Then
            If iUHMotionCounter >= 600 Then
                'Ignore for 5 minutes
                bUHMotionDetected = False
                iUHMotionCounter = 0
            End If
        End If

        'Check Basement
        If Not bBMotionDetected Then
            If iBMotion = 0 Then
                bBMotionDetected = True
            End If
        Else
            iBMotionCounter = iBMotionCounter + 1
            iBMotion = 1
            'If iBMotionCounter >= 900 Then
            If iBMotionCounter >= 1800 Then
                'Ignore for 15 minutes
                bBMotionDetected = False
                iBMotionCounter = 0
            End If
        End If

        'Check Exterior Cameras (all 4)
        'If Not bEXMotionDetected Then
        '    'Ignore at night due to false alarms
        '    If (Hour(Now) >= 20 Or Hour(Now) <= 7) Then
        '        iExMotion = 0
        '    Else
        '        If iExMotion = 1 Then
        '            bEXMotionDetected = True
        '        End If
        '    End If
        'Else
        '    iEXMotionCounter = iEXMotionCounter + 1
        '    iExMotion = 0
        '    'If iEXMotionCounter >= 900 Then
        '    If iEXMotionCounter >= 1800 Then
        '        'Ignore for 15 minutes
        '        bEXMotionDetected = False
        '        iEXMotionCounter = 0
        '    End If
        'End If

    End Sub

    Public Sub CheckMail(ByVal iCurrentMail As Integer)

        If Not bIgnoreMail Then
            If MailStatus = 0 And iCurrentMail = 1 Then         'Mail not delivered yet
                MailStatus = 0
            ElseIf MailStatus = 0 And iCurrentMail = 0 Then     'Mail is being delivered
                MailStatus = 1
                bIgnoreMail = True
                If bHouseEmptyConfirmed Then
                    iMailAway = 1
                Else
                    SpeakIt("Youve got Mail")
                End If
            ElseIf MailStatus = 1 And iCurrentMail = 1 Then     'Mail has been delivered
                MailStatus = 1
            ElseIf MailStatus = 1 And iCurrentMail = 0 Then     'Mail being retrieved
                MailStatus = 2
                bIgnoreMail = True
                If bHouseEmptyConfirmed Then
                    iMailAway = 0
                End If
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

    Public Sub CheckDoor(ByVal iBkDoor As Integer, ByVal iBkDoorLock As Integer, ByVal iFDoor As Integer, ByVal iFDoorLock As Integer, ByVal iMudRmDoor As Integer, ByVal iMudRmDoorLock As Integer, ByVal iBasDoor As Integer, ByVal iBasDoorLock As Integer, ByVal iGDoor As Integer, ByVal iGOutsideDoor As Integer, ByVal iGOutsideDoorLock As Integer)
        Dim iConnectStringLen As Integer

        'BACK DOOR
        If (Hour(Now) < 22 And Hour(Now) > 6) And chkMute.Checked = False Then
            If iBkDoor = 1 And Back_DoorLabel1.Text = "0" Then
                PlayIt(2018) 'Closed
            End If
            If iBkDoor = 0 And Back_DoorLabel1.Text = "1" Then
                PlayIt(2017) 'Opened
            End If

            If iBkDoorLock = 1 And Back_Door_LockLabel1.Text = "0" Then
                PlayIt(2020) 'Locked
            End If
            If iBkDoorLock = 0 And Back_Door_LockLabel1.Text = "1" Then
                PlayIt(2019) 'Unlocked
            End If
        End If

        If iBkDoor = 0 Then
            iBKDoorCounter = iBKDoorCounter + 1
        Else
            iBKDoorCounter = 0
        End If

        'FRONT DOOR
        If (Hour(Now) < 22 And Hour(Now) > 6) And chkMute.Checked = False Then
            If iFDoor = 1 And Front_DoorLabel1.Text = "0" Then
                PlayIt(2038) 'Closed
            End If
            If iFDoor = 0 And Front_DoorLabel1.Text = "1" Then
                PlayIt(2037) 'Opened
            End If

            If iFDoorLock = 1 And Front_Door_LockLabel1.Text = "0" Then
                PlayIt(2040) 'Locked
            End If
            If iFDoorLock = 0 And Front_Door_LockLabel1.Text = "1" Then
                PlayIt(2039) 'Unlocked
            End If
        End If

        If iFDoor = 0 Then
            iFDoorCounter = iFDoorCounter + 1
            If Not tFDCoachLightOff.Enabled And (Stair_LightsLabel1.Text = "1") Then  'Turn on Front door coach lights when Front door opens and dark outside
                Insteon_ControlTableAdapter.Request_State_Change(1, "33.67.22")
                Insteon_ControlTableAdapter.Request_State_Change(1, "2B.80.FF")
                Event_HistoryTableAdapter.InsertQuery("5036", Now())
                tFDCoachLightOff.Start()
            End If
        Else
            iFDoorCounter = 0
        End If

        'MUDROOM DOOR
        If (Hour(Now) < 22 And Hour(Now) > 6) And chkMute.Checked = False Then
            If iMudRmDoor = 1 And Garage_Inside_DoorLabel1.Text = "0" Then
                PlayIt(2012) 'Closed
            End If
            If iMudRmDoor = 0 And Garage_Inside_DoorLabel1.Text = "1" Then
                PlayIt(2011) 'Opened
            End If

            If iMudRmDoorLock = 1 And Garage_Inside_Door_LockLabel1.Text = "0" Then
                PlayIt(2014) 'Locked
            End If
            If iMudRmDoorLock = 0 And Garage_Inside_Door_LockLabel1.Text = "1" Then
                PlayIt(2013) 'Unlocked
            End If
        End If

        If iMudRmDoor = 0 Then
            iMudRmDoorCounter = iMudRmDoorCounter + 1
        Else
            iMudRmDoorCounter = 0
        End If

        'BASEMENT DOOR
        If (Hour(Now) < 22 And Hour(Now) > 6) And chkMute.Checked = False Then

            If iBasDoor = 1 And Basement_DoorLabel1.Text = "0" Then
                PlayIt(1002) 'Closed
            End If
            If iBasDoor = 0 And Basement_DoorLabel1.Text = "1" Then
                PlayIt(1001) 'Opened
            End If

            If iBasDoorLock = 1 And Basement_Door_LockLabel1.Text = "0" Then
                'PlayIt(1004) 'Locked
            End If
            If iBasDoorLock = 0 And Basement_Door_LockLabel1.Text = "1" Then
                'PlayIt(1003) 'Unlocked
            End If
        End If

        If iBasDoor = 0 Then
            iBasDoorCounter = iBasDoorCounter + 1
        Else
            iBasDoorCounter = 0
        End If

        'GARAGE DOOR
        If (Hour(Now) < 22 And Hour(Now) > 6) And chkMute.Checked = False Then

            If iGDoor = 1 And Garage_DoorLabel1.Text = "0" Then
                PlayIt(2002) 'Closed
            End If
            If iGDoor = 0 And Garage_DoorLabel1.Text = "1" Then
                PlayIt(2001) 'Opened
            End If
        End If

        If iGDoor = 0 Then
            iGDoorCounter = iGDoorCounter + 1
            If Not tGarageLightOff.Enabled And (Stair_LightsLabel1.Text = "1") Then  'Turn on Garage coach lights when Garage door opens and dark outside
                Insteon_ControlTableAdapter.Request_State_Change(1, "17.A6.A9")  'GDCoach1
                Insteon_ControlTableAdapter.Request_State_Change(1, "15.FD.B8")  'GDCoach2
                Insteon_ControlTableAdapter.Request_State_Change(1, "33.66.15")  'Garage Inside
                Event_HistoryTableAdapter.InsertQuery("5036", Now())
                tGarageLightOff.Start()
            End If
        Else
            iGDoorCounter = 0
        End If

        'GARAGE OUTSIDE DOOR
        If (Hour(Now) < 22 And Hour(Now) > 6) And chkMute.Checked = False Then
            If iGOutsideDoor = 1 And Garage_Outside_DoorLabel1.Text = "0" Then
                PlayIt(2008) 'Closed
            End If
            If iGOutsideDoor = 0 And Garage_Outside_DoorLabel1.Text = "1" Then
                PlayIt(2007) 'Opened
            End If

            If iGOutsideDoorLock = 1 And Garage_Outside_Door_LockLabel1.Text = "0" Then
                PlayIt(2009) 'Locked
            End If
            If iGOutsideDoorLock = 0 And Garage_Outside_Door_LockLabel1.Text = "1" Then
                PlayIt(2010) 'Unlocked
            End If
        End If

        If chkMute.Checked = False Then
            Try
                If iBKDoorCounter = 120 Then     'speak after door is open for 60 seconds
                    SpeakIt("Attention, Please close the back door.")
                    Event_HistoryTableAdapter.InsertQuery("5016", Now)
                    iBKDoorCounter = 0
                End If

                If iFDoorCounter = 120 Then     'speak after door is open for 60 seconds
                    SpeakIt("Attention, Please close the front door.")
                    Event_HistoryTableAdapter.InsertQuery("5016", Now)
                    iFDoorCounter = 0
                End If

                If iMudRmDoorCounter = 360 Then     'speak after door is open for 3 minutes
                    SpeakIt("Attention, Please close the mud room door.")
                    Event_HistoryTableAdapter.InsertQuery("5016", Now)
                    iMudRmDoorCounter = 0
                End If

                If iBasDoorCounter = 120 Then     'speak after door is open for 60 seconds
                    SpeakIt("Attention, Please close the basement door.")
                    Event_HistoryTableAdapter.InsertQuery("5016", Now)
                    iBasDoorCounter = 0
                End If

                If iGDoorCounter = 1200 Then     'speak after door is open for 10 minutes
                    Dim Temp_DB As WatchdogDataSet.Temp_Current_StateDataTable
                    iConnectStringLen = Temp_Current_StateTableAdapter.Connection.ConnectionString.Length
                    Temp_Current_StateTableAdapter.Connection.ConnectionString = Temp_Current_StateTableAdapter.Connection.ConnectionString.Insert(iConnectStringLen, ";password=lEEward1")
                    Temp_DB = Temp_Current_StateTableAdapter.GetDataBy()
                    If Int(Temp_DB.Rows(0).Item(7).ToString) <= 45 Then
                        SpeakIt("Attention, Please close the garage door.")
                        Event_HistoryTableAdapter.InsertQuery("5016", Now)
                    End If
                    iGDoorCounter = 0
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub

    Sub CheckLizardTemp()
        If CInt(Lizard_Habitat_TempLabel1.Text) > 0 And CInt(Lizard_Habitat_TempLabel1.Text) < 80 Then
            Try
                'Something is wrong with the heat lamp
                If bHouseEmptyConfirmed Then
                    SendTextMsg("The lizard habitat temperature is too low.")
                Else
                    SpeakIt("Warning, the lizard habitat temperature is too low")
                End If
                Event_HistoryTableAdapter.InsertQuery("5032", Now)
            Catch ex As Exception
            End Try
        End If

    End Sub

#End Region

#Region "frmMain"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ULStat As MccDaq.ErrorInfo

        ' Update Screen
        Event_Current_StateTableAdapter.Fill(WatchdogDataSet.Event_Current_State)

        InitializeHouse()

        ' Write Startup Event
        Event_HistoryTableAdapter.InsertQuery("9001", Now)

        ' Configure Ports
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortA, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortB, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortCL, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard1.DConfigPort(MccDaq.DigitalPortType.FirstPortCH, MccDaq.DigitalPortDirection.DigitalIn)

        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortA, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortB, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortCL, MccDaq.DigitalPortDirection.DigitalIn)
        ULStat = DaqBoard2.DConfigPort(MccDaq.DigitalPortType.FirstPortCH, MccDaq.DigitalPortDirection.DigitalIn)

        SpeakStatusTimer.Start()
        HourTimer.Interval = ((59 - Now.Minute) * 60000) + ((60 - Now.Second) * 1000)
        HourTimer.Start()
        'tLizardHabitat.Start()
        Timer1.Start()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Write Shutdown Event
        If btnStart.Enabled = False Then
            Event_HistoryTableAdapter.InsertQuery("9002", Now)
        End If

    End Sub

#End Region

#Region "Insteon"

    Public Sub ActivateTempChange()
        Dim iOutsideTemp
        Try
            iOutsideTemp = GetOutsideTemp()

            'If heat is on, decrease temp by 3 degrees
            If iOutsideTemp <= WINTER Then
                bSetBackDown = True
                Temp_ControlTableAdapter.Request_Temp_Change("H", "-", 4)
                Event_HistoryTableAdapter.InsertQuery("5027", Now())
                iTempDelta -= 4
                lblTempDelta.Text = iTempDelta.ToString
            End If

            'If AC is on, increase temp by 3 degrees
            If iOutsideTemp >= SUMMER_MIN And iOutsideTemp <= SUMMER_MAX Then
                bSetBackUp = True
                Temp_ControlTableAdapter.Request_Temp_Change("C", "+", 4)
                Event_HistoryTableAdapter.InsertQuery("5026", Now())
                iTempDelta += 4
                lblTempDelta.Text = iTempDelta.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DeactivateTempChange()
        Try
            If bSetBackDown Then
                bSetBackDown = False
                Temp_ControlTableAdapter.Request_Temp_Change("H", "+", 4)
                Event_HistoryTableAdapter.InsertQuery("5026", Now())
                iTempDelta += 4
                lblTempDelta.Text = iTempDelta.ToString
            End If
            If bSetBackUp Then
                bSetBackUp = False
                Temp_ControlTableAdapter.Request_Temp_Change("C", "-", 4)
                Event_HistoryTableAdapter.InsertQuery("5027", Now())
                iTempDelta -= 4
                lblTempDelta.Text = iTempDelta.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Action Functions"

    Public Sub GreetArrival()
        Dim strGreeting, strStatus, strTelephoneStatus, strDoorBellStatus, strMailboxStatus, strRoombaStatus, strExpecting As String

        If Hour(Now) > 7 Then
            If iTelephoneAway > 1 Then
                strTelephoneStatus = Str(iTelephoneAway) & " phone calls "
            Else
                strTelephoneStatus = Str(iTelephoneAway) & " phone call "
            End If
            If iDoorBellAway > 1 Then
                strDoorBellStatus = Str(iDoorBellAway) & " visitors "
            Else
                strDoorBellStatus = Str(iDoorBellAway) & " visitor "
            End If
            strMailboxStatus = " the mail was delivered"
            strRoombaStatus = " the floor was cleaned"
            If iTelephoneAway > 0 And iDoorBellAway > 0 And iMailAway > 0 And bRoombaRun Then
                strStatus = "you missed " & strTelephoneStatus & strDoorBellStatus & ".  Also, " & strMailboxStatus & " and " & strRoombaStatus
                '--
            ElseIf iTelephoneAway > 0 And iDoorBellAway > 0 And iMailAway > 0 Then
                strStatus = "you missed " & strTelephoneStatus & strDoorBellStatus & " and " & strMailboxStatus
            ElseIf iTelephoneAway > 0 And iDoorBellAway > 0 And bRoombaRun Then
                strStatus = "you missed " & strTelephoneStatus & strDoorBellStatus & " and " & strRoombaStatus
            ElseIf iTelephoneAway > 0 And iMailAway > 0 And bRoombaRun Then
                strStatus = "you missed " & strTelephoneStatus & ". Also, " & strMailboxStatus & " and " & strRoombaStatus
            ElseIf iDoorBellAway > 0 And iMailAway > 0 And bRoombaRun Then
                strStatus = "you missed " & strDoorBellStatus & ". Also, " & strMailboxStatus & " and " & strRoombaStatus
                '--
            ElseIf iTelephoneAway > 0 And iDoorBellAway > 0 Then
                strStatus = "you missed " & strTelephoneStatus & " and " & strDoorBellStatus
            ElseIf iTelephoneAway > 0 And iMailAway > 0 Then
                strStatus = "you missed " & strTelephoneStatus & " and " & strMailboxStatus
            ElseIf iTelephoneAway > 0 And bRoombaRun > 0 Then
                strStatus = "you missed " & strTelephoneStatus & " and " & strRoombaStatus
            ElseIf iDoorBellAway > 0 And bRoombaRun > 0 Then
                strStatus = "you missed " & strDoorBellStatus & " and " & strRoombaStatus
            ElseIf iDoorBellAway > 0 And iMailAway > 0 Then
                strStatus = "you missed " & strDoorBellStatus & " and " & strMailboxStatus
            ElseIf iMailAway > 0 And bRoombaRun Then
                strStatus = strMailboxStatus & " and " & strRoombaStatus
                '--
            ElseIf iDoorBellAway > 0 Then
                strStatus = "you missed " & strDoorBellStatus
            ElseIf iTelephoneAway > 0 Then
                strStatus = "You missed " & strTelephoneStatus
            ElseIf iMailAway > 0 Then
                strStatus = strMailboxStatus
            ElseIf bRoombaRun Then
                strStatus = strRoombaStatus
            Else
                strStatus = "nothing interesting happened."
            End If

            bRoombaRun = False

            If bGeoFenceReached Then
                strExpecting = " I have been expecting your return.  "
                bGeoFenceReached = False
            Else
                strExpecting = ""
            End If

            Try
                strGreeting = Special_DaysTableAdapter.GetTodaysGreeting()
                If strGreeting <> "" Then
                    SpeakIt(strGreeting.Trim & strExpecting & "  While you were gone " & strStatus)
                Else
                    SpeakIt("Welcome home.  " & strExpecting & "While you were gone " & strStatus)
                End If
            Catch ex As Exception
                Event_HistoryTableAdapter.InsertQuery("9900", Now)
            Finally
                Event_HistoryTableAdapter.InsertQuery("5015", Now)
            End Try
        End If
    End Sub

    Public Sub SendTextMsg(ByVal iWhoJustLeft As Integer)
        Dim SendIt As System.Diagnostics.Process
        Dim bSecure As Boolean
        Dim strSendText As String

        bSecure = True
        strSendText = "Before you leave, take the following actions: " & Chr(13)
        If Back_Door_LockLabel1.Text = "0" Then
            bSecure = False
            strSendText = strSendText & "LOCK BACK DOOR; "
        End If
        If Front_Door_LockLabel1.Text = "0" Then
            bSecure = False
            strSendText = strSendText & "LOCK FRONT DOOR; "
        End If
        If Garage_Outside_Door_LockLabel1.Text = "0" Then
            bSecure = False
            strSendText = strSendText & "LOCK GARAGE OUTSIDE DOOR; "
        End If
        If Basement_Door_LockLabel1.Text = "0" Then
            'bSecure = False
            'strSendText = strSendText & "LOCK BASEMENT DOOR; "
        End If
        If Garage_Inside_DoorLabel1.Text = "0" Then
            bSecure = False
            strSendText = strSendText & "CLOSE MUD ROOM DOOR"
        End If


        If Not bSecure Then
            Try
                SendIt = New System.Diagnostics.Process
                SendIt.StartInfo.UseShellExecute = False
                SendIt.StartInfo.CreateNoWindow = True
                SendIt.StartInfo.FileName = "WDSendTextMsg.exe"
                If iWhoJustLeft = 1 Then
                    'Dad was last to leave
                    SendIt.StartInfo.Arguments = "5132224248 " & strSendText
                    Try
                        SendIt.Start()
                    Catch ex As Exception
                        Event_HistoryTableAdapter.InsertQuery("9900", Now)
                    End Try
                Else
                    'Mom was last to leave
                    SendIt.StartInfo.Arguments = "5135445316 " & strSendText
                    Try
                        SendIt.Start()
                    Catch ex As Exception
                        Event_HistoryTableAdapter.InsertQuery("9900", Now)
                    End Try
                End If
                Event_HistoryTableAdapter.InsertQuery("5009", Now)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub WarnLizardFed()
        Dim dtNow As Date
        Dim iSpecialDay As Integer

        dtNow = Now

        If Lizard_FedLabel1.Text = "0" Then
            If (DatePart(DateInterval.Weekday, dtNow, FirstDayOfWeek.Sunday) <> 7 And DatePart(DateInterval.Weekday, dtNow, FirstDayOfWeek.Sunday) <> 1) Then
                Try
                    iSpecialDay = Special_DaysTableAdapter.CheckSpecialDay()
                    If iSpecialDay = 1 Then
                        If DatePart(DateInterval.Hour, dtNow) = 9 And DatePart(DateInterval.Minute, dtNow) >= 30 And DatePart(DateInterval.Minute, dtNow) <= 40 Then
                            'Play warning 3 times between 8:10 and 8:20am on weekdays during school year
                            'Play warning 3 times between 9:30 and 9:40am on weekdays during summer
                            SpeakIt("Attention, Please feed Molly.")
                            Event_HistoryTableAdapter.InsertQuery("5046", Now)
                        End If
                    Else
                        If DatePart(DateInterval.Hour, dtNow) = 8 And DatePart(DateInterval.Minute, dtNow) >= 10 And DatePart(DateInterval.Minute, dtNow) <= 20 Then
                            SpeakIt("Attention, Please feed Molly.")
                            Event_HistoryTableAdapter.InsertQuery("5046", Now)
                        End If
                    End If

                    If DatePart(DateInterval.Hour, dtNow) = 10 And DatePart(DateInterval.Minute, dtNow) >= 30 And DatePart(DateInterval.Minute, dtNow) <= 35 Then
                        'Play warning between 10:30 and 10:35am on weekdays
                        SpeakIt("Ok, seriously.  Molly is starving!  Stop what you're doing and feed her now.")
                        Event_HistoryTableAdapter.InsertQuery("5046", Now)
                    End If
                    If DatePart(DateInterval.Hour, dtNow) = 10 And DatePart(DateInterval.Minute, dtNow) >= 45 And DatePart(DateInterval.Minute, dtNow) <= 50 Then
                        'Send Text warning at 10:45 on weekdays
                        Event_HistoryTableAdapter.InsertQuery("5046", Now)
                        SendTextMsg("Molly has not been fed!")
                    End If
                Catch ex As Exception
                End Try
            Else
                Try
                    If DatePart(DateInterval.Hour, dtNow) = 9 And DatePart(DateInterval.Minute, dtNow) >= 30 And DatePart(DateInterval.Minute, dtNow) <= 40 Then
                        'Play warning between 9:30 and 9:40am on weekends
                        SpeakIt("Attention, Please feed Molly.")
                        Event_HistoryTableAdapter.InsertQuery("5046", Now)
                    End If
                    If DatePart(DateInterval.Hour, dtNow) = 10 And DatePart(DateInterval.Minute, dtNow) >= 30 And DatePart(DateInterval.Minute, dtNow) <= 35 Then
                        'Play warning between 10:30 and 10:35am on weekends
                        SpeakIt("Ok, seriously.  Molly is starving!  Stop what you're doing and feed her now.")
                        Event_HistoryTableAdapter.InsertQuery("5046", Now)
                    End If
                    If DatePart(DateInterval.Hour, dtNow) = 10 And DatePart(DateInterval.Minute, dtNow) >= 45 And DatePart(DateInterval.Minute, dtNow) <= 50 Then
                        'Send Text warning at 10:45 on weekends
                        Event_HistoryTableAdapter.InsertQuery("5046", Now)
                        SendTextMsg("Molly has not been fed!")
                    End If
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

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

    Public Function PlayIt(ByVal iCode As Integer) As Integer
        Dim WavPlay1 As New System.Media.SoundPlayer
        Dim strPath As String = "c:\Progra~1\Watchdog\"

        Select Case iCode
            Case 1001, 2007, 2011, 2017, 2037
                WavPlay1.SoundLocation() = strPath & "Door_Opened.wav"

            Case 1002, 2008, 2012, 2018, 2038
                WavPlay1.SoundLocation() = strPath & "Door_Closed.wav"

            Case 2001
                WavPlay1.SoundLocation() = strPath & "GDoor_Up.wav"

            Case 2002
                WavPlay1.SoundLocation() = strPath & "GDoor_Down.wav"

            Case 1003, 2009, 2013, 2019, 2039
                WavPlay1.SoundLocation() = strPath & "Door_Unlocked.wav"

            Case 1004, 2010, 2014, 2020, 2040
                WavPlay1.SoundLocation() = strPath & "Door_Locked.wav"

                'Case 6002
                'WavPlay1.SoundLocation() = strPath & "Motion_Detected.wav"

            Case 5014
                WavPlay1.SoundLocation() = strPath & "Intruder.wav"

            Case 5024
                WavPlay1.SoundLocation() = strPath & "Notify.wav"

        End Select
        Try
            WavPlay1.Load()
            WavPlay1.PlaySync()
        Catch ex As Exception
            Return 1
        End Try
        Return 0

    End Function

    Public Sub SendTextMsg(ByVal MsgText As String)
        Dim SendIt As System.Diagnostics.Process

        SendIt = New System.Diagnostics.Process
        SendIt.StartInfo.UseShellExecute = False
        SendIt.StartInfo.CreateNoWindow = True
        SendIt.StartInfo.FileName = "WDSendTextMsg.exe"
        Try
            SendIt.StartInfo.Arguments = "5132224248 " & MsgText
            SendIt.Start()
            SendIt.StartInfo.Arguments = "5135445316 " & MsgText
            SendIt.Start()
        Catch ex As Exception
        End Try
        Event_HistoryTableAdapter.InsertQuery("5009", Now)

    End Sub

    Public Function GetOutsideTemp() As Integer
        Dim iConnectStringLen As Integer
        Dim Temp_DB As WatchdogDataSet.Temp_Current_StateDataTable
        Dim iOutsideTemp

        Try
            iConnectStringLen = Temp_Current_StateTableAdapter.Connection.ConnectionString.Length
            Temp_Current_StateTableAdapter.Connection.ConnectionString = Temp_Current_StateTableAdapter.Connection.ConnectionString.Insert(iConnectStringLen, ";password=lEEward1")
            Temp_DB = Temp_Current_StateTableAdapter.GetDataBy()

            iOutsideTemp = Int(Temp_DB.Rows(0).Item(7).ToString)
            Temp_DB = Nothing
        Catch ex As Exception
            iOutsideTemp = 68
        End Try

        Return iOutsideTemp

    End Function


#End Region

#Region "Binary Functions"

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

#End Region

#Region "Buttons"

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Timer1.Stop()
        SpeakStatusTimer.Stop()
        HourTimer.Stop()
        tFDCoachLightOff.Stop()
        tGarageLightOff.Stop()

        btnStop.Enabled = False
        btnStart.Enabled = True

        ' Write Stop Event
        Event_HistoryTableAdapter.InsertQuery("9002", Now)

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        btnStop.Enabled = True

        ' Write Start Event
        Event_HistoryTableAdapter.InsertQuery("9001", Now)

        ' Refresh Fields on screen
        Event_Current_StateTableAdapter.Fill(WatchdogDataSet.Event_Current_State)

        InitializeHouse()

        SpeakStatusTimer.Start()
        HourTimer.Interval = ((59 - Now.Minute) * 60000) + ((60 - Now.Second) * 1000)
        HourTimer.Start()
        Timer1.Start()
    End Sub


    Private Sub btnVacation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVacation.Click
        Dim mbResult As MsgBoxResult

        mbResult = MsgBox("Vacation Mode will be activated in 5 minutes.  Are you sure you want to continue?", MsgBoxStyle.OkCancel, "Vacation Mode")
        If mbResult = MsgBoxResult.Ok Then
            Timer1.Stop()
            SpeakStatusTimer.Stop()
            HourTimer.Stop()
            'tLizardHabitat.Stop()
            tFDCoachLightOff.Stop()
            tGarageLightOff.Stop()
            btnStop.Enabled = False
            btnStart.Enabled = True
            frmVacationMode.ShowDialog()
        End If

        'After Vacation Mode is Disabled
        InitializeHouse()

        Timer1.Start()
        HourTimer.Interval = ((59 - Now.Minute) * 60000) + ((60 - Now.Second) * 1000)
        HourTimer.Start()
        'tLizardHabitat.Start()
        SpeakStatusTimer.Start()
        btnStop.Enabled = True
        btnStart.Enabled = False
    End Sub

#End Region

#Region "Timers"

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Runs once every 1 second (896 ms)
        'Runs once every .5 seconds (375 ms) vulture
        'Runs once every .5 seconds (342 ms) watchdog1 (400 - no effect on dups)

        Timer1.Stop()
        If CheckHouse() = 0 Then
            'handle error
        End If
        Timer1.Start()

    End Sub


    Private Sub SpeakStatusTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeakStatusTimer.Tick
        'Runs once every 10 minutes;  Speaks between 9:30pm and 10:00pm every 10 minutes
        Dim bSpeak As Boolean
        Dim SpeakText As String

        SpeakStatusTimer.Stop()
        SpeakText = ""
        bSpeak = False
        If Hour(Now) = 21 And Minute(Now) >= 30 Then
            If Back_Door_LockLabel1.Text = "0" Then
                bSpeak = True
                SpeakText = "Lock the Back Door"
            End If
            If Front_Door_LockLabel1.Text = "0" Then
                bSpeak = True
                SpeakText = SpeakText & ", Lock the Front door"
            End If
            If Garage_Outside_Door_LockLabel1.Text = "0" Then
                bSpeak = True
                SpeakText = SpeakText & ", Lock the Garage Outside door"
            End If
            If Basement_Door_LockLabel1.Text = "0" Then
                'bSpeak = True
                'SpeakText = SpeakText & ", Lock the Basement door"
            End If
            If Garage_DoorLabel1.Text = "0" Then
                bSpeak = True
                SpeakText = SpeakText & ", Close the Garage Door"
            End If
            If bSpeak Then
                SpeakText = "Attention, the following security items must be addressed. " & SpeakText
            End If
            If CInt(Brine_TankLabel1.Text) <= 20 Then
                If bSpeak Then
                    SpeakText = SpeakText & "Also, please add more salt to the water softener brine tank."
                Else
                    SpeakText = "Attention, please add more salt to the water softener brine tank."
                    bSpeak = True
                End If
            End If

            If bSpeak And chkMute.Checked = False Then
                Dim SpeakIt As System.Diagnostics.Process = New System.Diagnostics.Process

                SpeakIt.StartInfo.UseShellExecute = False
                SpeakIt.StartInfo.CreateNoWindow = True
                SpeakIt.StartInfo.FileName = "WDPlay_Voice.exe"
                SpeakIt.StartInfo.Arguments = SpeakText
                Try
                    SpeakIt.Start()
                Catch ex As Exception
                    Event_HistoryTableAdapter.InsertQuery("9900", Now)
                Finally
                    Event_HistoryTableAdapter.InsertQuery("5017", Now)
                End Try
            End If

        End If

        SpeakStatusTimer.Start()

    End Sub


    Private Sub HourTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourTimer.Tick
        'Runs once every 1 hour
        Dim iHour As Integer = Hour(Now)

        HourTimer.Interval = 3600000
        'CheckLizardTemp()

        If iHour = 20 And Now.DayOfWeek = DayOfWeek.Sunday And Garbage_CanLabel1.Text = "1" Then
            SpeakIt("Attention, Don't forget to take out the garbage")
            Event_HistoryTableAdapter.InsertQuery("5101", Now)
        End If

        If iHour = 20 And Now.DayOfWeek = DayOfWeek.Monday And Garbage_CanLabel1.Text = "0" Then
            SpeakIt("Attention, Don't forget to bring in the garbage cans.")
            Event_HistoryTableAdapter.InsertQuery("5101", Now)
        End If

        If iHour = 10 Then
            'Reset mailbox status between 10AM and 11AM
            MailStatus = 0
            bNightLightOff1 = False
            bNightLightOff2 = False
        End If

        If iHour >= 0 And iHour <= 3 Then
            'if no motion in great room between 12AM and 4AM, turn off lamp
            If iGRMotionCounter = 0 And Not bNightLightOff1 Then
                Insteon_ControlTableAdapter.Request_Off_Main_Level()
                Event_HistoryTableAdapter.InsertQuery("5036", Now())
                bNightLightOff1 = True
            End If
            'if no motion in basement between 12AM and 4AM, turn off lights
            If iSRMotionCounter = 0 And Not bNightLightOff2 Then
                Insteon_ControlTableAdapter.Request_Off_Basement()
                Event_HistoryTableAdapter.InsertQuery("5036", Now())
                bNightLightOff2 = True
            End If
        End If

        If iHour = 22 And Not (bLoweredTemp) And Not (bRaisedTemp) Then
            'Adjust Temp at Night
            Dim iOutsideTemp

            iOutsideTemp = GetOutsideTemp()

            'If heat is on, decrease temp by 2 degrees
            If iOutsideTemp <= WINTER Then
                Try
                    bLoweredTemp = True
                    Temp_ControlTableAdapter.Request_Temp_Change("H", "-", 2)
                    Event_HistoryTableAdapter.InsertQuery("5027", Now())
                    iTempDelta -= 2
                    lblTempDelta.Text = iTempDelta.ToString
                Catch ex As Exception
                End Try
            End If

            'If AC is on, increase temp by 2 degrees
            If iOutsideTemp >= SUMMER_MIN And iOutsideTemp <= SUMMER_MAX Then
                Try
                    bRaisedTemp = True
                    Temp_ControlTableAdapter.Request_Temp_Change("C", "+", 2)
                    Event_HistoryTableAdapter.InsertQuery("5026", Now())
                    iTempDelta += 2
                    lblTempDelta.Text = iTempDelta.ToString
                Catch ex As Exception
                End Try
            End If

            'If Outside temp is between 68 and 73 degrees, do nothing
            'If Outside temp is above 85, then its too hot to adjust temp at night
        End If

        If iHour = 5 Then
            'Adjust Temp in Morning - undo last change
            If bRaisedTemp Then
                Try
                    bRaisedTemp = False
                    Temp_ControlTableAdapter.Request_Temp_Change("C", "-", 2)
                    Event_HistoryTableAdapter.InsertQuery("5027", Now())
                    iTempDelta -= 2
                    lblTempDelta.Text = iTempDelta.ToString
                Catch ex As Exception
                End Try
            End If
            If bLoweredTemp Then
                Try
                    bLoweredTemp = False
                    Temp_ControlTableAdapter.Request_Temp_Change("H", "+", 2)
                    Event_HistoryTableAdapter.InsertQuery("5026", Now())
                    iTempDelta += 2
                    lblTempDelta.Text = iTempDelta.ToString
                Catch ex As Exception
                End Try
            End If
        End If

        If iHour = 23 Then
            Special_DaysTableAdapter.DeleteOldSpecialDate(Now())
        End If

    End Sub

    Private Sub tLizardHabitat_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tLizardHabitat.Tick
        'Runs once every 5 minutes
        Try
            WarnLizardFed()

            If iLizardFed = 0 And Lizard_FedLabel1.Text = "1" Then
                Event_HistoryTableAdapter.InsertQuery("5061", Now)
            End If
            iLizardFed = Int(Lizard_FedLabel1.Text)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub tFDCoachLightOff_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tFDCoachLightOff.Tick
        Try
            tFDCoachLightOff.Stop()
            Insteon_ControlTableAdapter.Request_State_Change(0, "33.67.22")
            Insteon_ControlTableAdapter.Request_State_Change(0, "2B.80.FF")
            Event_HistoryTableAdapter.InsertQuery("5036", Now())
        Catch ex As Exception
        End Try
    End Sub


    Private Sub tGarageLightOff_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tGarageLightOff.Tick
        Try
            tGarageLightOff.Stop()
            Insteon_ControlTableAdapter.Request_State_Change(0, "17.A6.A9")  'GDCoach1
            Insteon_ControlTableAdapter.Request_State_Change(0, "15.FD.B8")  'GDCoach2
            Insteon_ControlTableAdapter.Request_State_Change(0, "33.66.15")  'Garage Inside
            Event_HistoryTableAdapter.InsertQuery("5036", Now())
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class
