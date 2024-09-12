<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVacationMode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Geofence_ReachedLabel As System.Windows.Forms.Label
        Dim Leak_DetectedLabel As System.Windows.Forms.Label
        Dim Stair_LightsLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVacationMode))
        Me.btnDisable = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tStartDelay = New System.Windows.Forms.Timer(Me.components)
        Me.lblState = New System.Windows.Forms.Label
        Me.lblCountDown = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Event_ListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Event_ListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WatchdogDataSet1 = New WindowsApplication1.WatchdogDataSet1
        Me.tLights = New System.Windows.Forms.Timer(Me.components)
        Me.lblMissedTelephone = New System.Windows.Forms.Label
        Me.lblMissedVisitor = New System.Windows.Forms.Label
        Me.chkPause = New System.Windows.Forms.CheckBox
        Me.tIntruderWarning = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Temp_Current_StateDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Temp_Current_StateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WatchdogDataSet = New WindowsApplication1.WatchdogDataSet
        Me.Event_HistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Event_HistoryTableAdapter = New WindowsApplication1.WatchdogDataSet1TableAdapters.Event_HistoryTableAdapter
        Me.TableAdapterManager = New WindowsApplication1.WatchdogDataSet1TableAdapters.TableAdapterManager
        Me.Event_ListTableAdapter = New WindowsApplication1.WatchdogDataSet1TableAdapters.Event_ListTableAdapter
        Me.Temp_Daily_AggregateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Temp_Daily_AggregateTableAdapter = New WindowsApplication1.WatchdogDataSet1TableAdapters.Temp_Daily_AggregateTableAdapter
        Me.Temp_Daily_AggregateDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Geofence_ReachedLabel1 = New System.Windows.Forms.Label
        Me.Event_Current_StateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Insteon_ControlDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Insteon_ControlBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Temp_ControlDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Temp_ControlBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Geofence_ReachedLabel2 = New System.Windows.Forms.Label
        Me.Leak_DetectedLabel2 = New System.Windows.Forms.Label
        Me.Stair_LightsLabel1 = New System.Windows.Forms.Label
        Me.tHourly = New System.Windows.Forms.Timer(Me.components)
        Me.Event_Current_StateTableAdapter = New WindowsApplication1.WatchdogDataSetTableAdapters.Event_Current_StateTableAdapter
        Me.TableAdapterManager1 = New WindowsApplication1.WatchdogDataSetTableAdapters.TableAdapterManager
        Me.Temp_Current_StateTableAdapter = New WindowsApplication1.WatchdogDataSetTableAdapters.Temp_Current_StateTableAdapter
        Me.Insteon_ControlTableAdapter = New WindowsApplication1.WatchdogDataSetTableAdapters.Insteon_ControlTableAdapter
        Me.Temp_ControlTableAdapter = New WindowsApplication1.WatchdogDataSetTableAdapters.Temp_ControlTableAdapter
        Geofence_ReachedLabel = New System.Windows.Forms.Label
        Leak_DetectedLabel = New System.Windows.Forms.Label
        Stair_LightsLabel = New System.Windows.Forms.Label
        CType(Me.Event_ListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Event_ListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WatchdogDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Temp_Current_StateDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Temp_Current_StateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WatchdogDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Event_HistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Temp_Daily_AggregateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Temp_Daily_AggregateDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Event_Current_StateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Insteon_ControlDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Insteon_ControlBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Temp_ControlDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Temp_ControlBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Geofence_ReachedLabel
        '
        Geofence_ReachedLabel.AutoSize = True
        Geofence_ReachedLabel.Location = New System.Drawing.Point(13, 336)
        Geofence_ReachedLabel.Name = "Geofence_ReachedLabel"
        Geofence_ReachedLabel.Size = New System.Drawing.Size(104, 13)
        Geofence_ReachedLabel.TabIndex = 14
        Geofence_ReachedLabel.Text = "Geofence Reached:"
        '
        'Leak_DetectedLabel
        '
        Leak_DetectedLabel.AutoSize = True
        Leak_DetectedLabel.Location = New System.Drawing.Point(13, 354)
        Leak_DetectedLabel.Name = "Leak_DetectedLabel"
        Leak_DetectedLabel.Size = New System.Drawing.Size(81, 13)
        Leak_DetectedLabel.TabIndex = 16
        Leak_DetectedLabel.Text = "Leak Detected:"
        '
        'Stair_LightsLabel
        '
        Stair_LightsLabel.AutoSize = True
        Stair_LightsLabel.Location = New System.Drawing.Point(13, 372)
        Stair_LightsLabel.Name = "Stair_LightsLabel"
        Stair_LightsLabel.Size = New System.Drawing.Size(62, 13)
        Stair_LightsLabel.TabIndex = 18
        Stair_LightsLabel.Text = "Stair Lights:"
        '
        'btnDisable
        '
        Me.btnDisable.Location = New System.Drawing.Point(329, 315)
        Me.btnDisable.Name = "btnDisable"
        Me.btnDisable.Size = New System.Drawing.Size(79, 26)
        Me.btnDisable.TabIndex = 0
        Me.btnDisable.Text = "Disable"
        Me.btnDisable.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 450
        '
        'tStartDelay
        '
        Me.tStartDelay.Interval = 1000
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(3, 315)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(57, 13)
        Me.lblState.TabIndex = 1
        Me.lblState.Text = "Starting in:"
        '
        'lblCountDown
        '
        Me.lblCountDown.AutoSize = True
        Me.lblCountDown.Location = New System.Drawing.Point(58, 315)
        Me.lblCountDown.Name = "lblCountDown"
        Me.lblCountDown.Size = New System.Drawing.Size(25, 13)
        Me.lblCountDown.TabIndex = 2
        Me.lblCountDown.Text = "300"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Missed Phone Calls:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(254, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Missed Visitors:"
        '
        'Event_ListDataGridView
        '
        Me.Event_ListDataGridView.AllowUserToAddRows = False
        Me.Event_ListDataGridView.AllowUserToDeleteRows = False
        Me.Event_ListDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.Event_ListDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Event_ListDataGridView.AutoGenerateColumns = False
        Me.Event_ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Event_ListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3})
        Me.Event_ListDataGridView.DataSource = Me.Event_ListBindingSource
        Me.Event_ListDataGridView.Location = New System.Drawing.Point(12, 39)
        Me.Event_ListDataGridView.Name = "Event_ListDataGridView"
        Me.Event_ListDataGridView.ReadOnly = True
        Me.Event_ListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Event_ListDataGridView.Size = New System.Drawing.Size(396, 270)
        Me.Event_ListDataGridView.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Event_description"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Event Description"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Event_Timestamp"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "Event Timestamp"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 130
        '
        'Event_ListBindingSource
        '
        Me.Event_ListBindingSource.DataMember = "Event_List"
        Me.Event_ListBindingSource.DataSource = Me.WatchdogDataSet1
        '
        'WatchdogDataSet1
        '
        Me.WatchdogDataSet1.DataSetName = "WatchdogDataSet1"
        Me.WatchdogDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tLights
        '
        Me.tLights.Interval = 360000
        '
        'lblMissedTelephone
        '
        Me.lblMissedTelephone.AutoSize = True
        Me.lblMissedTelephone.Location = New System.Drawing.Point(122, 12)
        Me.lblMissedTelephone.Name = "lblMissedTelephone"
        Me.lblMissedTelephone.Size = New System.Drawing.Size(13, 13)
        Me.lblMissedTelephone.TabIndex = 6
        Me.lblMissedTelephone.Text = "0"
        '
        'lblMissedVisitor
        '
        Me.lblMissedVisitor.AutoSize = True
        Me.lblMissedVisitor.Location = New System.Drawing.Point(339, 12)
        Me.lblMissedVisitor.Name = "lblMissedVisitor"
        Me.lblMissedVisitor.Size = New System.Drawing.Size(13, 13)
        Me.lblMissedVisitor.TabIndex = 7
        Me.lblMissedVisitor.Text = "0"
        '
        'chkPause
        '
        Me.chkPause.AutoSize = True
        Me.chkPause.Enabled = False
        Me.chkPause.Location = New System.Drawing.Point(260, 320)
        Me.chkPause.Name = "chkPause"
        Me.chkPause.Size = New System.Drawing.Size(56, 17)
        Me.chkPause.TabIndex = 8
        Me.chkPause.Text = "Pause"
        Me.chkPause.UseVisualStyleBackColor = True
        '
        'tIntruderWarning
        '
        Me.tIntruderWarning.Interval = 1000
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Light1_on"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Light1_on"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Light1_off"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Light1_off"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Light2_on"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Light2_on"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Light2_off"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Light2_off"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Light3_on"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Light3_on"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Light3_off"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Light3_off"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Temp_Up_1"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Temp_Up_1"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Temp_Down_1"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Temp_Down_1"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Temp_Up_3"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Temp_Up_3"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Temp_Down_3"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Temp_Down_3"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Zone1_on"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Zone1_on"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Zone1_off"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Zone1_off"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Zone2_on"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Zone2_on"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Zone2_off"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Zone2_off"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Zone3_on"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Zone3_on"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Zone3_off"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Zone3_off"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "Zone4_on"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Zone4_on"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Zone4_off"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Zone4_off"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'Temp_Current_StateDataGridView
        '
        Me.Temp_Current_StateDataGridView.AutoGenerateColumns = False
        Me.Temp_Current_StateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Temp_Current_StateDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31})
        Me.Temp_Current_StateDataGridView.DataSource = Me.Temp_Current_StateBindingSource
        Me.Temp_Current_StateDataGridView.Location = New System.Drawing.Point(393, 26)
        Me.Temp_Current_StateDataGridView.Name = "Temp_Current_StateDataGridView"
        Me.Temp_Current_StateDataGridView.Size = New System.Drawing.Size(10, 11)
        Me.Temp_Current_StateDataGridView.TabIndex = 10
        Me.Temp_Current_StateDataGridView.Visible = False
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "Last_Update"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Last_Update"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Master_Bedroom"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Master_Bedroom"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Ethan_Bedroom"
        Me.DataGridViewTextBoxColumn24.HeaderText = "Ethan_Bedroom"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Sydney_Bedroom"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Sydney_Bedroom"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "Play_Room"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Play_Room"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "Kitchen"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Kitchen"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "Living_Room"
        Me.DataGridViewTextBoxColumn28.HeaderText = "Living_Room"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "Garage"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Garage"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "Basement_Office"
        Me.DataGridViewTextBoxColumn30.HeaderText = "Basement_Office"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "Great_Room"
        Me.DataGridViewTextBoxColumn31.HeaderText = "Great_Room"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        '
        'Temp_Current_StateBindingSource
        '
        Me.Temp_Current_StateBindingSource.DataMember = "Temp_Current_State"
        Me.Temp_Current_StateBindingSource.DataSource = Me.WatchdogDataSet
        '
        'WatchdogDataSet
        '
        Me.WatchdogDataSet.DataSetName = "WatchdogDataSet"
        Me.WatchdogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Event_HistoryBindingSource
        '
        Me.Event_HistoryBindingSource.DataMember = "Event_History"
        Me.Event_HistoryBindingSource.DataSource = Me.WatchdogDataSet1
        '
        'Event_HistoryTableAdapter
        '
        Me.Event_HistoryTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.Temp_Daily_AggregateTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.WatchdogDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Event_ListTableAdapter
        '
        Me.Event_ListTableAdapter.ClearBeforeFill = True
        '
        'Temp_Daily_AggregateBindingSource
        '
        Me.Temp_Daily_AggregateBindingSource.DataMember = "Temp_Daily_Aggregate"
        Me.Temp_Daily_AggregateBindingSource.DataSource = Me.WatchdogDataSet1
        '
        'Temp_Daily_AggregateTableAdapter
        '
        Me.Temp_Daily_AggregateTableAdapter.ClearBeforeFill = True
        '
        'Temp_Daily_AggregateDataGridView
        '
        Me.Temp_Daily_AggregateDataGridView.AutoGenerateColumns = False
        Me.Temp_Daily_AggregateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Temp_Daily_AggregateDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38})
        Me.Temp_Daily_AggregateDataGridView.DataSource = Me.Temp_Daily_AggregateBindingSource
        Me.Temp_Daily_AggregateDataGridView.Location = New System.Drawing.Point(403, 16)
        Me.Temp_Daily_AggregateDataGridView.Name = "Temp_Daily_AggregateDataGridView"
        Me.Temp_Daily_AggregateDataGridView.Size = New System.Drawing.Size(14, 10)
        Me.Temp_Daily_AggregateDataGridView.TabIndex = 11
        Me.Temp_Daily_AggregateDataGridView.Visible = False
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "Last_Updated"
        Me.DataGridViewTextBoxColumn32.HeaderText = "Last_Updated"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "Avg_Inside"
        Me.DataGridViewTextBoxColumn33.HeaderText = "Avg_Inside"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "Avg_Outside"
        Me.DataGridViewTextBoxColumn34.HeaderText = "Avg_Outside"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "Min_Inside"
        Me.DataGridViewTextBoxColumn35.HeaderText = "Min_Inside"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "Min_Outside"
        Me.DataGridViewTextBoxColumn36.HeaderText = "Min_Outside"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "Max_Inside"
        Me.DataGridViewTextBoxColumn37.HeaderText = "Max_Inside"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "Max_Outside"
        Me.DataGridViewTextBoxColumn38.HeaderText = "Max_Outside"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        '
        'Geofence_ReachedLabel1
        '
        Me.Geofence_ReachedLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Event_Current_StateBindingSource, "Geofence_Reached", True))
        Me.Geofence_ReachedLabel1.Location = New System.Drawing.Point(155, 316)
        Me.Geofence_ReachedLabel1.Name = "Geofence_ReachedLabel1"
        Me.Geofence_ReachedLabel1.Size = New System.Drawing.Size(16, 12)
        Me.Geofence_ReachedLabel1.TabIndex = 13
        Me.Geofence_ReachedLabel1.Text = "."
        Me.Geofence_ReachedLabel1.Visible = False
        '
        'Event_Current_StateBindingSource
        '
        Me.Event_Current_StateBindingSource.DataMember = "Event_Current_State"
        Me.Event_Current_StateBindingSource.DataSource = Me.WatchdogDataSet
        '
        'Insteon_ControlDataGridView
        '
        Me.Insteon_ControlDataGridView.AllowUserToAddRows = False
        Me.Insteon_ControlDataGridView.AllowUserToDeleteRows = False
        Me.Insteon_ControlDataGridView.AutoGenerateColumns = False
        Me.Insteon_ControlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Insteon_ControlDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn41, Me.DataGridViewTextBoxColumn42, Me.DataGridViewTextBoxColumn43})
        Me.Insteon_ControlDataGridView.DataSource = Me.Insteon_ControlBindingSource
        Me.Insteon_ControlDataGridView.Location = New System.Drawing.Point(390, 7)
        Me.Insteon_ControlDataGridView.Name = "Insteon_ControlDataGridView"
        Me.Insteon_ControlDataGridView.ReadOnly = True
        Me.Insteon_ControlDataGridView.Size = New System.Drawing.Size(13, 13)
        Me.Insteon_ControlDataGridView.TabIndex = 13
        Me.Insteon_ControlDataGridView.Visible = False
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "Row_ID"
        Me.DataGridViewTextBoxColumn39.HeaderText = "Row_ID"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "Device_Name"
        Me.DataGridViewTextBoxColumn40.HeaderText = "Device_Name"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "Device_ID"
        Me.DataGridViewTextBoxColumn41.HeaderText = "Device_ID"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.ReadOnly = True
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "Device_Current_State"
        Me.DataGridViewTextBoxColumn42.HeaderText = "Device_Current_State"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.ReadOnly = True
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "Device_Request_State"
        Me.DataGridViewTextBoxColumn43.HeaderText = "Device_Request_State"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.ReadOnly = True
        '
        'Insteon_ControlBindingSource
        '
        Me.Insteon_ControlBindingSource.DataMember = "Insteon_Control"
        Me.Insteon_ControlBindingSource.DataSource = Me.WatchdogDataSet
        '
        'Temp_ControlDataGridView
        '
        Me.Temp_ControlDataGridView.AllowUserToAddRows = False
        Me.Temp_ControlDataGridView.AllowUserToDeleteRows = False
        Me.Temp_ControlDataGridView.AutoGenerateColumns = False
        Me.Temp_ControlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Temp_ControlDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn44, Me.DataGridViewTextBoxColumn45, Me.DataGridViewTextBoxColumn46, Me.DataGridViewTextBoxColumn47})
        Me.Temp_ControlDataGridView.DataSource = Me.Temp_ControlBindingSource
        Me.Temp_ControlDataGridView.Location = New System.Drawing.Point(377, 18)
        Me.Temp_ControlDataGridView.Name = "Temp_ControlDataGridView"
        Me.Temp_ControlDataGridView.ReadOnly = True
        Me.Temp_ControlDataGridView.Size = New System.Drawing.Size(10, 14)
        Me.Temp_ControlDataGridView.TabIndex = 13
        Me.Temp_ControlDataGridView.Visible = False
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "Row_ID"
        Me.DataGridViewTextBoxColumn44.HeaderText = "Row_ID"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.ReadOnly = True
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "Temp_Mode"
        Me.DataGridViewTextBoxColumn45.HeaderText = "Temp_Mode"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        Me.DataGridViewTextBoxColumn45.ReadOnly = True
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "Temp_Direction"
        Me.DataGridViewTextBoxColumn46.HeaderText = "Temp_Direction"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        Me.DataGridViewTextBoxColumn46.ReadOnly = True
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "Temp_Degrees"
        Me.DataGridViewTextBoxColumn47.HeaderText = "Temp_Degrees"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        Me.DataGridViewTextBoxColumn47.ReadOnly = True
        '
        'Temp_ControlBindingSource
        '
        Me.Temp_ControlBindingSource.DataMember = "Temp_Control"
        Me.Temp_ControlBindingSource.DataSource = Me.WatchdogDataSet
        '
        'Geofence_ReachedLabel2
        '
        Me.Geofence_ReachedLabel2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Event_Current_StateBindingSource, "Geofence_Reached", True))
        Me.Geofence_ReachedLabel2.Location = New System.Drawing.Point(125, 336)
        Me.Geofence_ReachedLabel2.Name = "Geofence_ReachedLabel2"
        Me.Geofence_ReachedLabel2.Size = New System.Drawing.Size(20, 13)
        Me.Geofence_ReachedLabel2.TabIndex = 15
        Me.Geofence_ReachedLabel2.Text = "0"
        '
        'Leak_DetectedLabel2
        '
        Me.Leak_DetectedLabel2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Event_Current_StateBindingSource, "Leak_Detected", True))
        Me.Leak_DetectedLabel2.Location = New System.Drawing.Point(125, 354)
        Me.Leak_DetectedLabel2.Name = "Leak_DetectedLabel2"
        Me.Leak_DetectedLabel2.Size = New System.Drawing.Size(20, 13)
        Me.Leak_DetectedLabel2.TabIndex = 17
        Me.Leak_DetectedLabel2.Text = "0"
        '
        'Stair_LightsLabel1
        '
        Me.Stair_LightsLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Event_Current_StateBindingSource, "Stair_Lights", True))
        Me.Stair_LightsLabel1.Location = New System.Drawing.Point(125, 372)
        Me.Stair_LightsLabel1.Name = "Stair_LightsLabel1"
        Me.Stair_LightsLabel1.Size = New System.Drawing.Size(20, 13)
        Me.Stair_LightsLabel1.TabIndex = 19
        Me.Stair_LightsLabel1.Text = "0"
        '
        'tHourly
        '
        Me.tHourly.Interval = 3600000
        '
        'Event_Current_StateTableAdapter
        '
        Me.Event_Current_StateTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.Event_Current_StateTableAdapter = Me.Event_Current_StateTableAdapter
        Me.TableAdapterManager1.Insteon_ControlTableAdapter = Nothing
        Me.TableAdapterManager1.Special_DaysTableAdapter = Nothing
        Me.TableAdapterManager1.Temp_ControlTableAdapter = Nothing
        Me.TableAdapterManager1.Temp_Current_StateTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = WindowsApplication1.WatchdogDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Temp_Current_StateTableAdapter
        '
        Me.Temp_Current_StateTableAdapter.ClearBeforeFill = True
        '
        'Insteon_ControlTableAdapter
        '
        Me.Insteon_ControlTableAdapter.ClearBeforeFill = True
        '
        'Temp_ControlTableAdapter
        '
        Me.Temp_ControlTableAdapter.ClearBeforeFill = True
        '
        'frmVacationMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 392)
        Me.Controls.Add(Stair_LightsLabel)
        Me.Controls.Add(Me.Stair_LightsLabel1)
        Me.Controls.Add(Leak_DetectedLabel)
        Me.Controls.Add(Me.Leak_DetectedLabel2)
        Me.Controls.Add(Geofence_ReachedLabel)
        Me.Controls.Add(Me.Geofence_ReachedLabel2)
        Me.Controls.Add(Me.Temp_ControlDataGridView)
        Me.Controls.Add(Me.Insteon_ControlDataGridView)
        Me.Controls.Add(Me.Geofence_ReachedLabel1)
        Me.Controls.Add(Me.Temp_Daily_AggregateDataGridView)
        Me.Controls.Add(Me.Temp_Current_StateDataGridView)
        Me.Controls.Add(Me.chkPause)
        Me.Controls.Add(Me.lblMissedVisitor)
        Me.Controls.Add(Me.lblMissedTelephone)
        Me.Controls.Add(Me.Event_ListDataGridView)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCountDown)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.btnDisable)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVacationMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vacation Mode"
        CType(Me.Event_ListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Event_ListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WatchdogDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Temp_Current_StateDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Temp_Current_StateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WatchdogDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Event_HistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Temp_Daily_AggregateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Temp_Daily_AggregateDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Event_Current_StateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Insteon_ControlDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Insteon_ControlBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Temp_ControlDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Temp_ControlBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDisable As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tStartDelay As System.Windows.Forms.Timer
    Friend WithEvents WatchdogDataSet1 As WindowsApplication1.WatchdogDataSet1
    Friend WithEvents Event_HistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Event_HistoryTableAdapter As WindowsApplication1.WatchdogDataSet1TableAdapters.Event_HistoryTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.WatchdogDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblCountDown As System.Windows.Forms.Label
    Friend WithEvents WatchdogDataSet As WindowsApplication1.WatchdogDataSet
    Friend WithEvents Event_Current_StateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Event_Current_StateTableAdapter As WindowsApplication1.WatchdogDataSetTableAdapters.Event_Current_StateTableAdapter
    Friend WithEvents TableAdapterManager1 As WindowsApplication1.WatchdogDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Event_ListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Event_ListTableAdapter As WindowsApplication1.WatchdogDataSet1TableAdapters.Event_ListTableAdapter
    Friend WithEvents Event_ListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents tLights As System.Windows.Forms.Timer
    Friend WithEvents lblMissedTelephone As System.Windows.Forms.Label
    Friend WithEvents lblMissedVisitor As System.Windows.Forms.Label
    Friend WithEvents chkPause As System.Windows.Forms.CheckBox
    Friend WithEvents tIntruderWarning As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp_Current_StateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Temp_Current_StateTableAdapter As WindowsApplication1.WatchdogDataSetTableAdapters.Temp_Current_StateTableAdapter
    Friend WithEvents Temp_Current_StateDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp_Daily_AggregateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Temp_Daily_AggregateTableAdapter As WindowsApplication1.WatchdogDataSet1TableAdapters.Temp_Daily_AggregateTableAdapter
    Friend WithEvents Temp_Daily_AggregateDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Geofence_ReachedLabel1 As System.Windows.Forms.Label
    Friend WithEvents Insteon_ControlBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Insteon_ControlTableAdapter As WindowsApplication1.WatchdogDataSetTableAdapters.Insteon_ControlTableAdapter
    Friend WithEvents Insteon_ControlDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp_ControlBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Temp_ControlTableAdapter As WindowsApplication1.WatchdogDataSetTableAdapters.Temp_ControlTableAdapter
    Friend WithEvents Temp_ControlDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Geofence_ReachedLabel2 As System.Windows.Forms.Label
    Friend WithEvents Leak_DetectedLabel2 As System.Windows.Forms.Label
    Friend WithEvents Stair_LightsLabel1 As System.Windows.Forms.Label
    Friend WithEvents tHourly As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
