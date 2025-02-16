namespace HomeSphere
{
    partial class DataViewJames
    {
        private System.ComponentModel.IContainer components = null;

        // Declare components
        private System.Windows.Forms.TabControl tabControlSensors;
        private System.Windows.Forms.TabPage LEDtab, Buzzertab, Buttontab, PIRMotiontab, RFIDtab, Watertab, RotaryAngletab, Soundtab, Temperaturetab, Ultrasonictab;
        private System.Windows.Forms.DataGridView dataGridViewLED, dataGridViewBuzzer, dataGridViewButton, dataGridViewPIRMotion, dataGridViewRFID, dataGridViewWater, dataGridViewRotaryAngle, dataGridViewSound, dataGridViewTemperature, dataGridViewUltrasonic;
        private System.Windows.Forms.Button btnRefreshLED, btnRefreshBuzzer, btnRefreshButton, btnRefreshPIRMotion, btnRefreshRFID, btnRefreshWater, btnRefreshRotaryAngle, btnRefreshSound, btnRefreshTemperature, btnRefreshUltrasonic;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewJames));
            this.tabControlSensors = new System.Windows.Forms.TabControl();
            this.LEDtab = new System.Windows.Forms.TabPage();
            this.btnClearAllData = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnsendredoff = new System.Windows.Forms.Button();
            this.btnsendredon = new System.Windows.Forms.Button();
            this.dataGridViewLED = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dutyCycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voltageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEDName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEDSensorDataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hardwareDBDataSet = new HomeSphere.HardwareDBDataSet();
            this.btnRefreshLED = new System.Windows.Forms.Button();
            this.Buzzertab = new System.Windows.Forms.TabPage();
            this.dataGridViewBuzzer = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buzzerStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buzzerSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshBuzzer = new System.Windows.Forms.Button();
            this.Buttontab = new System.Windows.Forms.TabPage();
            this.dataGridViewButton = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pressedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timestampDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshButton = new System.Windows.Forms.Button();
            this.PIRMotiontab = new System.Windows.Forms.TabPage();
            this.dataGridViewPIRMotion = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timestampDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pIRSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshPIRMotion = new System.Windows.Forms.Button();
            this.RFIDtab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRFID = new System.Windows.Forms.TextBox();
            this.dataGridViewRFID = new System.Windows.Forms.DataGridView();
            this.logIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFIDTagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFIDAccessLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshRFID = new System.Windows.Forms.Button();
            this.Watertab = new System.Windows.Forms.TabPage();
            this.dataGridViewWater = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterDetectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timestampDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshWater = new System.Windows.Forms.Button();
            this.RotaryAngletab = new System.Windows.Forms.TabPage();
            this.dataGridViewRotaryAngle = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.angleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotaryAngleSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshRotaryAngle = new System.Windows.Forms.Button();
            this.Soundtab = new System.Windows.Forms.TabPage();
            this.dataGridViewSound = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshSound = new System.Windows.Forms.Button();
            this.Temperaturetab = new System.Windows.Forms.TabPage();
            this.dataGridViewTemperature = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperatureSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshTemperature = new System.Windows.Forms.Button();
            this.Ultrasonictab = new System.Windows.Forms.TabPage();
            this.dataGridViewUltrasonic = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultrasonicSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshUltrasonic = new System.Windows.Forms.Button();
            this.lEDSensorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buzzerSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.BuzzerSensorDataTableAdapter();
            this.buttonSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.ButtonSensorDataTableAdapter();
            this.pIRSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.PIRSensorDataTableAdapter();
            this.rFIDAccessLogsTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.RFIDAccessLogsTableAdapter();
            this.waterSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.WaterSensorDataTableAdapter();
            this.rotaryAngleSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.RotaryAngleSensorDataTableAdapter();
            this.soundSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.SoundSensorDataTableAdapter();
            this.temperatureSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.TemperatureSensorDataTableAdapter();
            this.ultrasonicSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.UltrasonicSensorDataTableAdapter();
            this.lEDSensorDataTableAdapter = new HomeSphere.HardwareDBDataSetTableAdapters.LEDSensorDataTableAdapter();
            this.hardwareDBDataSet1 = new HomeSphere.HardwareDBDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.SensorData = new System.Windows.Forms.ToolStripButton();
            this.Overview = new System.Windows.Forms.ToolStripButton();
            this.Products = new System.Windows.Forms.ToolStripButton();
            this.EventManagement = new System.Windows.Forms.ToolStripButton();
            this.UserManagement = new System.Windows.Forms.ToolStripButton();
            this.tabControlSensors.SuspendLayout();
            this.LEDtab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lEDSensorDataBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardwareDBDataSet)).BeginInit();
            this.Buzzertab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuzzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzzerSensorDataBindingSource)).BeginInit();
            this.Buttontab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSensorDataBindingSource)).BeginInit();
            this.PIRMotiontab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPIRMotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIRSensorDataBindingSource)).BeginInit();
            this.RFIDtab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRFID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDAccessLogsBindingSource)).BeginInit();
            this.Watertab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterSensorDataBindingSource)).BeginInit();
            this.RotaryAngletab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRotaryAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaryAngleSensorDataBindingSource)).BeginInit();
            this.Soundtab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundSensorDataBindingSource)).BeginInit();
            this.Temperaturetab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureSensorDataBindingSource)).BeginInit();
            this.Ultrasonictab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUltrasonic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultrasonicSensorDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lEDSensorDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardwareDBDataSet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSensors
            // 
            this.tabControlSensors.Controls.Add(this.LEDtab);
            this.tabControlSensors.Controls.Add(this.Buzzertab);
            this.tabControlSensors.Controls.Add(this.Buttontab);
            this.tabControlSensors.Controls.Add(this.PIRMotiontab);
            this.tabControlSensors.Controls.Add(this.RFIDtab);
            this.tabControlSensors.Controls.Add(this.Watertab);
            this.tabControlSensors.Controls.Add(this.RotaryAngletab);
            this.tabControlSensors.Controls.Add(this.Soundtab);
            this.tabControlSensors.Controls.Add(this.Temperaturetab);
            this.tabControlSensors.Controls.Add(this.Ultrasonictab);
            this.tabControlSensors.Location = new System.Drawing.Point(12, 71);
            this.tabControlSensors.Name = "tabControlSensors";
            this.tabControlSensors.SelectedIndex = 0;
            this.tabControlSensors.Size = new System.Drawing.Size(800, 600);
            this.tabControlSensors.TabIndex = 0;
            // 
            // LEDtab
            // 
            this.LEDtab.AutoScroll = true;
            this.LEDtab.Controls.Add(this.btnClearAllData);
            this.LEDtab.Controls.Add(this.btnTestConnection);
            this.LEDtab.Controls.Add(this.btnsendredoff);
            this.LEDtab.Controls.Add(this.btnsendredon);
            this.LEDtab.Controls.Add(this.dataGridViewLED);
            this.LEDtab.Controls.Add(this.btnRefreshLED);
            this.LEDtab.Location = new System.Drawing.Point(4, 25);
            this.LEDtab.Name = "LEDtab";
            this.LEDtab.Size = new System.Drawing.Size(792, 571);
            this.LEDtab.TabIndex = 0;
            this.LEDtab.Text = "LED";
            // 
            // btnClearAllData
            // 
            this.btnClearAllData.Location = new System.Drawing.Point(506, 535);
            this.btnClearAllData.Name = "btnClearAllData";
            this.btnClearAllData.Size = new System.Drawing.Size(131, 23);
            this.btnClearAllData.TabIndex = 5;
            this.btnClearAllData.Text = "Clear all data\r\n";
            this.btnClearAllData.UseVisualStyleBackColor = true;
            this.btnClearAllData.Click += new System.EventHandler(this.btnClearAllData_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(323, 535);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(120, 23);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnsendredoff
            // 
            this.btnsendredoff.Location = new System.Drawing.Point(177, 536);
            this.btnsendredoff.Name = "btnsendredoff";
            this.btnsendredoff.Size = new System.Drawing.Size(75, 23);
            this.btnsendredoff.TabIndex = 3;
            this.btnsendredoff.Text = "Off (red)";
            this.btnsendredoff.UseVisualStyleBackColor = true;
            this.btnsendredoff.Click += new System.EventHandler(this.btnSendRedOff_Click);
            // 
            // btnsendredon
            // 
            this.btnsendredon.Location = new System.Drawing.Point(23, 536);
            this.btnsendredon.Name = "btnsendredon";
            this.btnsendredon.Size = new System.Drawing.Size(75, 23);
            this.btnsendredon.TabIndex = 2;
            this.btnsendredon.Text = "On (red)";
            this.btnsendredon.UseVisualStyleBackColor = true;
            this.btnsendredon.Click += new System.EventHandler(this.btnSendRedOn_Click);
            // 
            // dataGridViewLED
            // 
            this.dataGridViewLED.AutoGenerateColumns = false;
            this.dataGridViewLED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLED.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLED.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dutyCycleDataGridViewTextBoxColumn,
            this.voltageDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn,
            this.LEDName});
            this.dataGridViewLED.DataSource = this.lEDSensorDataBindingSource1;
            this.dataGridViewLED.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewLED.Name = "dataGridViewLED";
            this.dataGridViewLED.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewLED.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Width = 77;
            // 
            // dutyCycleDataGridViewTextBoxColumn
            // 
            this.dutyCycleDataGridViewTextBoxColumn.DataPropertyName = "DutyCycle";
            this.dutyCycleDataGridViewTextBoxColumn.HeaderText = "DutyCycle";
            this.dutyCycleDataGridViewTextBoxColumn.Name = "dutyCycleDataGridViewTextBoxColumn";
            // 
            // voltageDataGridViewTextBoxColumn
            // 
            this.voltageDataGridViewTextBoxColumn.DataPropertyName = "Voltage";
            this.voltageDataGridViewTextBoxColumn.HeaderText = "Voltage";
            this.voltageDataGridViewTextBoxColumn.Name = "voltageDataGridViewTextBoxColumn";
            this.voltageDataGridViewTextBoxColumn.ReadOnly = true;
            this.voltageDataGridViewTextBoxColumn.Width = 85;
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            this.timestampDataGridViewTextBoxColumn.Width = 106;
            // 
            // LEDName
            // 
            this.LEDName.DataPropertyName = "LEDName";
            this.LEDName.HeaderText = "LEDName";
            this.LEDName.Name = "LEDName";
            this.LEDName.Width = 101;
            // 
            // lEDSensorDataBindingSource1
            // 
            this.lEDSensorDataBindingSource1.DataMember = "LEDSensorData";
            this.lEDSensorDataBindingSource1.DataSource = this.hardwareDBDataSet;
            // 
            // hardwareDBDataSet
            // 
            this.hardwareDBDataSet.DataSetName = "HardwareDBDataSet";
            this.hardwareDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRefreshLED
            // 
            this.btnRefreshLED.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshLED.Name = "btnRefreshLED";
            this.btnRefreshLED.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshLED.TabIndex = 1;
            this.btnRefreshLED.Text = "Refresh";
            this.btnRefreshLED.Click += new System.EventHandler(this.btnRefreshLED_Click);
            // 
            // Buzzertab
            // 
            this.Buzzertab.Controls.Add(this.dataGridViewBuzzer);
            this.Buzzertab.Controls.Add(this.btnRefreshBuzzer);
            this.Buzzertab.Location = new System.Drawing.Point(4, 25);
            this.Buzzertab.Name = "Buzzertab";
            this.Buzzertab.Size = new System.Drawing.Size(792, 571);
            this.Buzzertab.TabIndex = 1;
            this.Buzzertab.Text = "Buzzer";
            // 
            // dataGridViewBuzzer
            // 
            this.dataGridViewBuzzer.AutoGenerateColumns = false;
            this.dataGridViewBuzzer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBuzzer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBuzzer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.buzzerStatusDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn1});
            this.dataGridViewBuzzer.DataSource = this.buzzerSensorDataBindingSource;
            this.dataGridViewBuzzer.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewBuzzer.Name = "dataGridViewBuzzer";
            this.dataGridViewBuzzer.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewBuzzer.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn1.Width = 50;
            // 
            // buzzerStatusDataGridViewTextBoxColumn
            // 
            this.buzzerStatusDataGridViewTextBoxColumn.DataPropertyName = "BuzzerStatus";
            this.buzzerStatusDataGridViewTextBoxColumn.HeaderText = "BuzzerStatus";
            this.buzzerStatusDataGridViewTextBoxColumn.Name = "buzzerStatusDataGridViewTextBoxColumn";
            this.buzzerStatusDataGridViewTextBoxColumn.Width = 121;
            // 
            // timestampDataGridViewTextBoxColumn1
            // 
            this.timestampDataGridViewTextBoxColumn1.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn1.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn1.Name = "timestampDataGridViewTextBoxColumn1";
            this.timestampDataGridViewTextBoxColumn1.Width = 106;
            // 
            // buzzerSensorDataBindingSource
            // 
            this.buzzerSensorDataBindingSource.DataMember = "BuzzerSensorData";
            this.buzzerSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshBuzzer
            // 
            this.btnRefreshBuzzer.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshBuzzer.Name = "btnRefreshBuzzer";
            this.btnRefreshBuzzer.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshBuzzer.TabIndex = 1;
            this.btnRefreshBuzzer.Text = "Refresh";
            this.btnRefreshBuzzer.Click += new System.EventHandler(this.btnRefreshBuzzer_Click);
            // 
            // Buttontab
            // 
            this.Buttontab.Controls.Add(this.dataGridViewButton);
            this.Buttontab.Controls.Add(this.btnRefreshButton);
            this.Buttontab.Location = new System.Drawing.Point(4, 25);
            this.Buttontab.Name = "Buttontab";
            this.Buttontab.Size = new System.Drawing.Size(792, 571);
            this.Buttontab.TabIndex = 2;
            this.Buttontab.Text = "Button";
            // 
            // dataGridViewButton
            // 
            this.dataGridViewButton.AutoGenerateColumns = false;
            this.dataGridViewButton.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewButton.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewButton.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn2,
            this.pressedDataGridViewCheckBoxColumn,
            this.timestampDataGridViewTextBoxColumn2});
            this.dataGridViewButton.DataSource = this.buttonSensorDataBindingSource;
            this.dataGridViewButton.Location = new System.Drawing.Point(20, 56);
            this.dataGridViewButton.Name = "dataGridViewButton";
            this.dataGridViewButton.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewButton.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn2
            // 
            this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn2.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
            this.iDDataGridViewTextBoxColumn2.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn2.Width = 50;
            // 
            // pressedDataGridViewCheckBoxColumn
            // 
            this.pressedDataGridViewCheckBoxColumn.DataPropertyName = "Pressed";
            this.pressedDataGridViewCheckBoxColumn.HeaderText = "Pressed";
            this.pressedDataGridViewCheckBoxColumn.Name = "pressedDataGridViewCheckBoxColumn";
            this.pressedDataGridViewCheckBoxColumn.Width = 66;
            // 
            // timestampDataGridViewTextBoxColumn2
            // 
            this.timestampDataGridViewTextBoxColumn2.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn2.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn2.Name = "timestampDataGridViewTextBoxColumn2";
            this.timestampDataGridViewTextBoxColumn2.Width = 106;
            // 
            // buttonSensorDataBindingSource
            // 
            this.buttonSensorDataBindingSource.DataMember = "ButtonSensorData";
            this.buttonSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshButton
            // 
            this.btnRefreshButton.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshButton.Name = "btnRefreshButton";
            this.btnRefreshButton.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshButton.TabIndex = 1;
            this.btnRefreshButton.Text = "Refresh";
            this.btnRefreshButton.Click += new System.EventHandler(this.btnRefreshButton_Click);
            // 
            // PIRMotiontab
            // 
            this.PIRMotiontab.Controls.Add(this.dataGridViewPIRMotion);
            this.PIRMotiontab.Controls.Add(this.btnRefreshPIRMotion);
            this.PIRMotiontab.Location = new System.Drawing.Point(4, 25);
            this.PIRMotiontab.Name = "PIRMotiontab";
            this.PIRMotiontab.Size = new System.Drawing.Size(792, 571);
            this.PIRMotiontab.TabIndex = 3;
            this.PIRMotiontab.Text = "PIR Motion";
            // 
            // dataGridViewPIRMotion
            // 
            this.dataGridViewPIRMotion.AutoGenerateColumns = false;
            this.dataGridViewPIRMotion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPIRMotion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPIRMotion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPIRMotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn3,
            this.detectedDataGridViewCheckBoxColumn,
            this.timestampDataGridViewTextBoxColumn3});
            this.dataGridViewPIRMotion.DataSource = this.pIRSensorDataBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPIRMotion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPIRMotion.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewPIRMotion.Name = "dataGridViewPIRMotion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPIRMotion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPIRMotion.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewPIRMotion.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn3
            // 
            this.iDDataGridViewTextBoxColumn3.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn3.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn3.Name = "iDDataGridViewTextBoxColumn3";
            this.iDDataGridViewTextBoxColumn3.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn3.Width = 50;
            // 
            // detectedDataGridViewCheckBoxColumn
            // 
            this.detectedDataGridViewCheckBoxColumn.DataPropertyName = "Detected";
            this.detectedDataGridViewCheckBoxColumn.HeaderText = "Detected";
            this.detectedDataGridViewCheckBoxColumn.Name = "detectedDataGridViewCheckBoxColumn";
            this.detectedDataGridViewCheckBoxColumn.Width = 71;
            // 
            // timestampDataGridViewTextBoxColumn3
            // 
            this.timestampDataGridViewTextBoxColumn3.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn3.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn3.Name = "timestampDataGridViewTextBoxColumn3";
            this.timestampDataGridViewTextBoxColumn3.Width = 106;
            // 
            // pIRSensorDataBindingSource
            // 
            this.pIRSensorDataBindingSource.DataMember = "PIRSensorData";
            this.pIRSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshPIRMotion
            // 
            this.btnRefreshPIRMotion.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshPIRMotion.Name = "btnRefreshPIRMotion";
            this.btnRefreshPIRMotion.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshPIRMotion.TabIndex = 1;
            this.btnRefreshPIRMotion.Text = "Refresh";
            this.btnRefreshPIRMotion.Click += new System.EventHandler(this.btnRefreshPIRMotion_Click);
            // 
            // RFIDtab
            // 
            this.RFIDtab.Controls.Add(this.label1);
            this.RFIDtab.Controls.Add(this.textBoxRFID);
            this.RFIDtab.Controls.Add(this.dataGridViewRFID);
            this.RFIDtab.Controls.Add(this.btnRefreshRFID);
            this.RFIDtab.Location = new System.Drawing.Point(4, 25);
            this.RFIDtab.Name = "RFIDtab";
            this.RFIDtab.Size = new System.Drawing.Size(792, 571);
            this.RFIDtab.TabIndex = 4;
            this.RFIDtab.Text = "RFID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "RFID:";
            // 
            // textBoxRFID
            // 
            this.textBoxRFID.Location = new System.Drawing.Point(56, 537);
            this.textBoxRFID.Name = "textBoxRFID";
            this.textBoxRFID.ReadOnly = true;
            this.textBoxRFID.Size = new System.Drawing.Size(154, 22);
            this.textBoxRFID.TabIndex = 2;
            this.textBoxRFID.TextChanged += new System.EventHandler(this.textBoxRFID_TextChanged);
            // 
            // dataGridViewRFID
            // 
            this.dataGridViewRFID.AutoGenerateColumns = false;
            this.dataGridViewRFID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRFID.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRFID.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewRFID.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logIDDataGridViewTextBoxColumn,
            this.rFIDTagDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.accessStatusDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn4});
            this.dataGridViewRFID.DataSource = this.rFIDAccessLogsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRFID.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewRFID.Location = new System.Drawing.Point(20, 59);
            this.dataGridViewRFID.Name = "dataGridViewRFID";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRFID.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewRFID.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewRFID.TabIndex = 0;
            // 
            // logIDDataGridViewTextBoxColumn
            // 
            this.logIDDataGridViewTextBoxColumn.DataPropertyName = "LogID";
            this.logIDDataGridViewTextBoxColumn.HeaderText = "LogID";
            this.logIDDataGridViewTextBoxColumn.Name = "logIDDataGridViewTextBoxColumn";
            this.logIDDataGridViewTextBoxColumn.Width = 74;
            // 
            // rFIDTagDataGridViewTextBoxColumn
            // 
            this.rFIDTagDataGridViewTextBoxColumn.DataPropertyName = "RFIDTag";
            this.rFIDTagDataGridViewTextBoxColumn.HeaderText = "RFIDTag";
            this.rFIDTagDataGridViewTextBoxColumn.Name = "rFIDTagDataGridViewTextBoxColumn";
            this.rFIDTagDataGridViewTextBoxColumn.Width = 93;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // accessStatusDataGridViewTextBoxColumn
            // 
            this.accessStatusDataGridViewTextBoxColumn.DataPropertyName = "AccessStatus";
            this.accessStatusDataGridViewTextBoxColumn.HeaderText = "AccessStatus";
            this.accessStatusDataGridViewTextBoxColumn.Name = "accessStatusDataGridViewTextBoxColumn";
            this.accessStatusDataGridViewTextBoxColumn.Width = 122;
            // 
            // timestampDataGridViewTextBoxColumn4
            // 
            this.timestampDataGridViewTextBoxColumn4.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn4.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn4.Name = "timestampDataGridViewTextBoxColumn4";
            this.timestampDataGridViewTextBoxColumn4.Width = 106;
            // 
            // rFIDAccessLogsBindingSource
            // 
            this.rFIDAccessLogsBindingSource.DataMember = "RFIDAccessLogs";
            this.rFIDAccessLogsBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshRFID
            // 
            this.btnRefreshRFID.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshRFID.Name = "btnRefreshRFID";
            this.btnRefreshRFID.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshRFID.TabIndex = 1;
            this.btnRefreshRFID.Text = "Refresh";
            this.btnRefreshRFID.Click += new System.EventHandler(this.btnRefreshRFID_Click);
            // 
            // Watertab
            // 
            this.Watertab.Controls.Add(this.dataGridViewWater);
            this.Watertab.Controls.Add(this.btnRefreshWater);
            this.Watertab.Location = new System.Drawing.Point(4, 25);
            this.Watertab.Name = "Watertab";
            this.Watertab.Size = new System.Drawing.Size(792, 571);
            this.Watertab.TabIndex = 5;
            this.Watertab.Text = "Water";
            // 
            // dataGridViewWater
            // 
            this.dataGridViewWater.AutoGenerateColumns = false;
            this.dataGridViewWater.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewWater.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWater.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewWater.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn4,
            this.waterDetectedDataGridViewCheckBoxColumn,
            this.timestampDataGridViewTextBoxColumn5});
            this.dataGridViewWater.DataSource = this.waterSensorDataBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWater.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewWater.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewWater.Name = "dataGridViewWater";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWater.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewWater.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewWater.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn4
            // 
            this.iDDataGridViewTextBoxColumn4.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn4.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn4.Name = "iDDataGridViewTextBoxColumn4";
            this.iDDataGridViewTextBoxColumn4.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn4.Width = 50;
            // 
            // waterDetectedDataGridViewCheckBoxColumn
            // 
            this.waterDetectedDataGridViewCheckBoxColumn.DataPropertyName = "WaterDetected";
            this.waterDetectedDataGridViewCheckBoxColumn.HeaderText = "WaterDetected";
            this.waterDetectedDataGridViewCheckBoxColumn.Name = "waterDetectedDataGridViewCheckBoxColumn";
            this.waterDetectedDataGridViewCheckBoxColumn.Width = 109;
            // 
            // timestampDataGridViewTextBoxColumn5
            // 
            this.timestampDataGridViewTextBoxColumn5.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn5.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn5.Name = "timestampDataGridViewTextBoxColumn5";
            this.timestampDataGridViewTextBoxColumn5.Width = 106;
            // 
            // waterSensorDataBindingSource
            // 
            this.waterSensorDataBindingSource.DataMember = "WaterSensorData";
            this.waterSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshWater
            // 
            this.btnRefreshWater.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshWater.Name = "btnRefreshWater";
            this.btnRefreshWater.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshWater.TabIndex = 1;
            this.btnRefreshWater.Text = "Refresh";
            this.btnRefreshWater.Click += new System.EventHandler(this.btnRefreshWater_Click);
            // 
            // RotaryAngletab
            // 
            this.RotaryAngletab.Controls.Add(this.dataGridViewRotaryAngle);
            this.RotaryAngletab.Controls.Add(this.btnRefreshRotaryAngle);
            this.RotaryAngletab.Location = new System.Drawing.Point(4, 25);
            this.RotaryAngletab.Name = "RotaryAngletab";
            this.RotaryAngletab.Size = new System.Drawing.Size(792, 571);
            this.RotaryAngletab.TabIndex = 6;
            this.RotaryAngletab.Text = "Rotary Angle";
            // 
            // dataGridViewRotaryAngle
            // 
            this.dataGridViewRotaryAngle.AutoGenerateColumns = false;
            this.dataGridViewRotaryAngle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRotaryAngle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRotaryAngle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewRotaryAngle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn5,
            this.angleDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn6});
            this.dataGridViewRotaryAngle.DataSource = this.rotaryAngleSensorDataBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRotaryAngle.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewRotaryAngle.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewRotaryAngle.Name = "dataGridViewRotaryAngle";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRotaryAngle.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewRotaryAngle.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewRotaryAngle.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn5
            // 
            this.iDDataGridViewTextBoxColumn5.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn5.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn5.Name = "iDDataGridViewTextBoxColumn5";
            this.iDDataGridViewTextBoxColumn5.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn5.Width = 50;
            // 
            // angleDataGridViewTextBoxColumn
            // 
            this.angleDataGridViewTextBoxColumn.DataPropertyName = "Angle";
            this.angleDataGridViewTextBoxColumn.HeaderText = "Angle";
            this.angleDataGridViewTextBoxColumn.Name = "angleDataGridViewTextBoxColumn";
            this.angleDataGridViewTextBoxColumn.Width = 73;
            // 
            // timestampDataGridViewTextBoxColumn6
            // 
            this.timestampDataGridViewTextBoxColumn6.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn6.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn6.Name = "timestampDataGridViewTextBoxColumn6";
            this.timestampDataGridViewTextBoxColumn6.Width = 106;
            // 
            // rotaryAngleSensorDataBindingSource
            // 
            this.rotaryAngleSensorDataBindingSource.DataMember = "RotaryAngleSensorData";
            this.rotaryAngleSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshRotaryAngle
            // 
            this.btnRefreshRotaryAngle.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshRotaryAngle.Name = "btnRefreshRotaryAngle";
            this.btnRefreshRotaryAngle.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshRotaryAngle.TabIndex = 1;
            this.btnRefreshRotaryAngle.Text = "Refresh";
            this.btnRefreshRotaryAngle.Click += new System.EventHandler(this.btnRefreshRotaryAngle_Click);
            // 
            // Soundtab
            // 
            this.Soundtab.Controls.Add(this.dataGridViewSound);
            this.Soundtab.Controls.Add(this.btnRefreshSound);
            this.Soundtab.Location = new System.Drawing.Point(4, 25);
            this.Soundtab.Name = "Soundtab";
            this.Soundtab.Size = new System.Drawing.Size(792, 571);
            this.Soundtab.TabIndex = 7;
            this.Soundtab.Text = "Sound";
            // 
            // dataGridViewSound
            // 
            this.dataGridViewSound.AutoGenerateColumns = false;
            this.dataGridViewSound.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSound.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSound.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewSound.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn6,
            this.soundLevelDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn7});
            this.dataGridViewSound.DataSource = this.soundSensorDataBindingSource;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSound.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewSound.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewSound.Name = "dataGridViewSound";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSound.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewSound.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewSound.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn6
            // 
            this.iDDataGridViewTextBoxColumn6.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn6.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn6.Name = "iDDataGridViewTextBoxColumn6";
            this.iDDataGridViewTextBoxColumn6.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn6.Width = 50;
            // 
            // soundLevelDataGridViewTextBoxColumn
            // 
            this.soundLevelDataGridViewTextBoxColumn.DataPropertyName = "SoundLevel";
            this.soundLevelDataGridViewTextBoxColumn.HeaderText = "SoundLevel";
            this.soundLevelDataGridViewTextBoxColumn.Name = "soundLevelDataGridViewTextBoxColumn";
            this.soundLevelDataGridViewTextBoxColumn.Width = 112;
            // 
            // timestampDataGridViewTextBoxColumn7
            // 
            this.timestampDataGridViewTextBoxColumn7.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn7.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn7.Name = "timestampDataGridViewTextBoxColumn7";
            this.timestampDataGridViewTextBoxColumn7.Width = 106;
            // 
            // soundSensorDataBindingSource
            // 
            this.soundSensorDataBindingSource.DataMember = "SoundSensorData";
            this.soundSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshSound
            // 
            this.btnRefreshSound.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshSound.Name = "btnRefreshSound";
            this.btnRefreshSound.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshSound.TabIndex = 1;
            this.btnRefreshSound.Text = "Refresh";
            this.btnRefreshSound.Click += new System.EventHandler(this.btnRefreshSound_Click);
            // 
            // Temperaturetab
            // 
            this.Temperaturetab.Controls.Add(this.dataGridViewTemperature);
            this.Temperaturetab.Controls.Add(this.btnRefreshTemperature);
            this.Temperaturetab.Location = new System.Drawing.Point(4, 25);
            this.Temperaturetab.Name = "Temperaturetab";
            this.Temperaturetab.Size = new System.Drawing.Size(792, 571);
            this.Temperaturetab.TabIndex = 8;
            this.Temperaturetab.Text = "Temperature";
            // 
            // dataGridViewTemperature
            // 
            this.dataGridViewTemperature.AutoGenerateColumns = false;
            this.dataGridViewTemperature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTemperature.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTemperature.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTemperature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn7,
            this.temperatureDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn8});
            this.dataGridViewTemperature.DataSource = this.temperatureSensorDataBindingSource;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTemperature.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTemperature.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewTemperature.Name = "dataGridViewTemperature";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTemperature.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTemperature.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewTemperature.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn7
            // 
            this.iDDataGridViewTextBoxColumn7.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn7.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn7.Name = "iDDataGridViewTextBoxColumn7";
            this.iDDataGridViewTextBoxColumn7.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn7.Width = 50;
            // 
            // temperatureDataGridViewTextBoxColumn
            // 
            this.temperatureDataGridViewTextBoxColumn.DataPropertyName = "Temperature";
            this.temperatureDataGridViewTextBoxColumn.HeaderText = "Temperature";
            this.temperatureDataGridViewTextBoxColumn.Name = "temperatureDataGridViewTextBoxColumn";
            this.temperatureDataGridViewTextBoxColumn.Width = 119;
            // 
            // timestampDataGridViewTextBoxColumn8
            // 
            this.timestampDataGridViewTextBoxColumn8.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn8.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn8.Name = "timestampDataGridViewTextBoxColumn8";
            this.timestampDataGridViewTextBoxColumn8.Width = 106;
            // 
            // temperatureSensorDataBindingSource
            // 
            this.temperatureSensorDataBindingSource.DataMember = "TemperatureSensorData";
            this.temperatureSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshTemperature
            // 
            this.btnRefreshTemperature.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshTemperature.Name = "btnRefreshTemperature";
            this.btnRefreshTemperature.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshTemperature.TabIndex = 1;
            this.btnRefreshTemperature.Text = "Refresh";
            this.btnRefreshTemperature.Click += new System.EventHandler(this.btnRefreshTemperature_Click);
            // 
            // Ultrasonictab
            // 
            this.Ultrasonictab.Controls.Add(this.dataGridViewUltrasonic);
            this.Ultrasonictab.Controls.Add(this.btnRefreshUltrasonic);
            this.Ultrasonictab.Location = new System.Drawing.Point(4, 25);
            this.Ultrasonictab.Name = "Ultrasonictab";
            this.Ultrasonictab.Size = new System.Drawing.Size(792, 571);
            this.Ultrasonictab.TabIndex = 9;
            this.Ultrasonictab.Text = "Ultrasonic";
            // 
            // dataGridViewUltrasonic
            // 
            this.dataGridViewUltrasonic.AutoGenerateColumns = false;
            this.dataGridViewUltrasonic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewUltrasonic.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUltrasonic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewUltrasonic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn8,
            this.distanceDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn9});
            this.dataGridViewUltrasonic.DataSource = this.ultrasonicSensorDataBindingSource;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUltrasonic.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewUltrasonic.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewUltrasonic.Name = "dataGridViewUltrasonic";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUltrasonic.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewUltrasonic.Size = new System.Drawing.Size(750, 472);
            this.dataGridViewUltrasonic.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn8
            // 
            this.iDDataGridViewTextBoxColumn8.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn8.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn8.Name = "iDDataGridViewTextBoxColumn8";
            this.iDDataGridViewTextBoxColumn8.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn8.Width = 50;
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            this.distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            this.distanceDataGridViewTextBoxColumn.HeaderText = "Distance";
            this.distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            this.distanceDataGridViewTextBoxColumn.Width = 92;
            // 
            // timestampDataGridViewTextBoxColumn9
            // 
            this.timestampDataGridViewTextBoxColumn9.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn9.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn9.Name = "timestampDataGridViewTextBoxColumn9";
            this.timestampDataGridViewTextBoxColumn9.Width = 106;
            // 
            // ultrasonicSensorDataBindingSource
            // 
            this.ultrasonicSensorDataBindingSource.DataMember = "UltrasonicSensorData";
            this.ultrasonicSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // btnRefreshUltrasonic
            // 
            this.btnRefreshUltrasonic.Location = new System.Drawing.Point(20, 10);
            this.btnRefreshUltrasonic.Name = "btnRefreshUltrasonic";
            this.btnRefreshUltrasonic.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshUltrasonic.TabIndex = 1;
            this.btnRefreshUltrasonic.Text = "Refresh";
            this.btnRefreshUltrasonic.Click += new System.EventHandler(this.btnRefreshUltrasonic_Click);
            // 
            // lEDSensorDataBindingSource
            // 
            this.lEDSensorDataBindingSource.DataMember = "LEDSensorData";
            this.lEDSensorDataBindingSource.DataSource = this.hardwareDBDataSet;
            // 
            // buzzerSensorDataTableAdapter
            // 
            this.buzzerSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // buttonSensorDataTableAdapter
            // 
            this.buttonSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // pIRSensorDataTableAdapter
            // 
            this.pIRSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // rFIDAccessLogsTableAdapter
            // 
            this.rFIDAccessLogsTableAdapter.ClearBeforeFill = true;
            // 
            // waterSensorDataTableAdapter
            // 
            this.waterSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // rotaryAngleSensorDataTableAdapter
            // 
            this.rotaryAngleSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // soundSensorDataTableAdapter
            // 
            this.soundSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // temperatureSensorDataTableAdapter
            // 
            this.temperatureSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // ultrasonicSensorDataTableAdapter
            // 
            this.ultrasonicSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // lEDSensorDataTableAdapter
            // 
            this.lEDSensorDataTableAdapter.ClearBeforeFill = true;
            // 
            // hardwareDBDataSet1
            // 
            this.hardwareDBDataSet1.DataSetName = "HardwareDBDataSet";
            this.hardwareDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home,
            this.Logout,
            this.SensorData,
            this.Overview,
            this.Products,
            this.EventManagement,
            this.UserManagement});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(820, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Home
            // 
            this.Home.AccessibleName = "Home";
            this.Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(54, 24);
            this.Home.Text = "Home";
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Logout
            // 
            this.Logout.AccessibleName = "Logout";
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(60, 24);
            this.Logout.Text = "Logout";
            // 
            // SensorData
            // 
            this.SensorData.AccessibleName = "ManageRecords";
            this.SensorData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SensorData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SensorData.Image = ((System.Drawing.Image)(resources.GetObject("SensorData.Image")));
            this.SensorData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SensorData.Name = "SensorData";
            this.SensorData.Size = new System.Drawing.Size(93, 24);
            this.SensorData.Text = "Sensor Data";
            // 
            // Overview
            // 
            this.Overview.AccessibleName = "Overview";
            this.Overview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Overview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Overview.Image = ((System.Drawing.Image)(resources.GetObject("Overview.Image")));
            this.Overview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(74, 24);
            this.Overview.Text = "Overview";
            // 
            // Products
            // 
            this.Products.AccessibleName = "Products";
            this.Products.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Products.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Products.Image = ((System.Drawing.Image)(resources.GetObject("Products.Image")));
            this.Products.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(70, 24);
            this.Products.Text = "Products";
            // 
            // EventManagement
            // 
            this.EventManagement.AccessibleName = "EventManagement";
            this.EventManagement.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EventManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EventManagement.Image = ((System.Drawing.Image)(resources.GetObject("EventManagement.Image")));
            this.EventManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventManagement.Name = "EventManagement";
            this.EventManagement.Size = new System.Drawing.Size(51, 24);
            this.EventManagement.Text = "Alerts";
            // 
            // UserManagement
            // 
            this.UserManagement.AccessibleName = "UserManagement";
            this.UserManagement.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UserManagement.Image = ((System.Drawing.Image)(resources.GetObject("UserManagement.Image")));
            this.UserManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserManagement.Name = "UserManagement";
            this.UserManagement.Size = new System.Drawing.Size(106, 24);
            this.UserManagement.Text = "Manage Users";
            // 
            // DataViewJames
            // 
            this.ClientSize = new System.Drawing.Size(820, 713);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControlSensors);
            this.Name = "DataViewJames";
            this.Text = "Hardware Sensor Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlSensors.ResumeLayout(false);
            this.LEDtab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lEDSensorDataBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardwareDBDataSet)).EndInit();
            this.Buzzertab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuzzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buzzerSensorDataBindingSource)).EndInit();
            this.Buttontab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSensorDataBindingSource)).EndInit();
            this.PIRMotiontab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPIRMotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIRSensorDataBindingSource)).EndInit();
            this.RFIDtab.ResumeLayout(false);
            this.RFIDtab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRFID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFIDAccessLogsBindingSource)).EndInit();
            this.Watertab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterSensorDataBindingSource)).EndInit();
            this.RotaryAngletab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRotaryAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaryAngleSensorDataBindingSource)).EndInit();
            this.Soundtab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundSensorDataBindingSource)).EndInit();
            this.Temperaturetab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureSensorDataBindingSource)).EndInit();
            this.Ultrasonictab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUltrasonic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultrasonicSensorDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lEDSensorDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardwareDBDataSet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private HardwareDBDataSet hardwareDBDataSet;
        private System.Windows.Forms.BindingSource lEDSensorDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dutyCycleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voltageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource buzzerSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.BuzzerSensorDataTableAdapter buzzerSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn buzzerStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource buttonSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.ButtonSensorDataTableAdapter buttonSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pressedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource pIRSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.PIRSensorDataTableAdapter pIRSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn detectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource rFIDAccessLogsBindingSource;
        private HardwareDBDataSetTableAdapters.RFIDAccessLogsTableAdapter rFIDAccessLogsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn logIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFIDTagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource waterSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.WaterSensorDataTableAdapter waterSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn waterDetectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource rotaryAngleSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.RotaryAngleSensorDataTableAdapter rotaryAngleSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn angleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource soundSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.SoundSensorDataTableAdapter soundSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn soundLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource temperatureSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.TemperatureSensorDataTableAdapter temperatureSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn8;
        private System.Windows.Forms.BindingSource ultrasonicSensorDataBindingSource;
        private HardwareDBDataSetTableAdapters.UltrasonicSensorDataTableAdapter ultrasonicSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button btnsendredoff;
        private System.Windows.Forms.Button btnsendredon;
        private System.Windows.Forms.BindingSource lEDSensorDataBindingSource1;
        private HardwareDBDataSetTableAdapters.LEDSensorDataTableAdapter lEDSensorDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRFID;
        private HardwareDBDataSet hardwareDBDataSet1;
        private System.Windows.Forms.Button btnClearAllData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripButton Logout;
        private System.Windows.Forms.ToolStripButton SensorData;
        private System.Windows.Forms.ToolStripButton Overview;
        private System.Windows.Forms.ToolStripButton Products;
        private System.Windows.Forms.ToolStripButton EventManagement;
        private System.Windows.Forms.ToolStripButton UserManagement;
    }
}
