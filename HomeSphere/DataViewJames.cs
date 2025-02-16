using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

using System.Configuration;
using System.Data.SqlClient;


namespace HomeSphere
{
    public partial class DataViewJames : Form
    {
        private DataComms dataComms;
        private string strConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databases\IOTPRJ_Data.mdf;Integrated Security=True;";

        // 1) _fakeCurrentTime: the current "fake" timestamp to store in the DB.
        //    For example, start 1 month ago. You can adjust as you wish.
        private DateTime _fakeCurrentTime = DateTime.Now.AddMonths(-1);

        // 2) _fakeTimeStep: how much to advance fake time after each sensor reading.
        //    For example, 1 hour. You can set it to days, minutes, etc.
        private TimeSpan _fakeTimeStep = TimeSpan.FromHours(1);


        public DataViewJames()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hardwareDBDataSet.LEDSensorData' table. You can move, or remove it, as needed.
            Debug.WriteLine("WinForm application loaded successfully.");
            // Initialize communications
            InitComms();


            dataGridViewLED.DataSource = hardwareDBDataSet.LEDSensorData;
            dataGridViewBuzzer.DataSource = hardwareDBDataSet.BuzzerSensorData;
            dataGridViewButton.DataSource = hardwareDBDataSet.ButtonSensorData;
            dataGridViewPIRMotion.DataSource = hardwareDBDataSet.PIRSensorData;
            dataGridViewRFID.DataSource = hardwareDBDataSet.RFIDAccessLogs;
            dataGridViewWater.DataSource = hardwareDBDataSet.WaterSensorData;
            dataGridViewRotaryAngle.DataSource = hardwareDBDataSet.RotaryAngleSensorData;
            dataGridViewSound.DataSource = hardwareDBDataSet.SoundSensorData;
            dataGridViewTemperature.DataSource = hardwareDBDataSet.TemperatureSensorData;
            dataGridViewUltrasonic.DataSource = hardwareDBDataSet.UltrasonicSensorData;

            // Load data into sensor tables
            try
            {
                this.lEDSensorDataTableAdapter.Fill(this.hardwareDBDataSet.LEDSensorData);
                this.buzzerSensorDataTableAdapter.Fill(this.hardwareDBDataSet.BuzzerSensorData);
                this.buttonSensorDataTableAdapter.Fill(this.hardwareDBDataSet.ButtonSensorData);
                this.pIRSensorDataTableAdapter.Fill(this.hardwareDBDataSet.PIRSensorData);
                this.rFIDAccessLogsTableAdapter.Fill(this.hardwareDBDataSet.RFIDAccessLogs);
                this.waterSensorDataTableAdapter.Fill(this.hardwareDBDataSet.WaterSensorData);
                this.rotaryAngleSensorDataTableAdapter.Fill(this.hardwareDBDataSet.RotaryAngleSensorData);
                this.soundSensorDataTableAdapter.Fill(this.hardwareDBDataSet.SoundSensorData);
                this.temperatureSensorDataTableAdapter.Fill(this.hardwareDBDataSet.TemperatureSensorData);
                this.ultrasonicSensorDataTableAdapter.Fill(this.hardwareDBDataSet.UltrasonicSensorData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime? lastTime = LoadLastFakeTimestamp();
            if (lastTime.HasValue)
            {
                // 2) If data exists, set _fakeCurrentTime to that timestamp 
                //    plus maybe a small offset if you want the next reading to be slightly after
                _fakeCurrentTime = lastTime.Value.AddHours(0.6);
                Debug.WriteLine($"Found existing data with last timestamp: {lastTime.Value}, " +
                                $"resuming fake time from: {_fakeCurrentTime}");
            }
            else
            {
               
                _fakeCurrentTime = DateTime.Now;
                Debug.WriteLine($"No existing sensor data. Starting from: {_fakeCurrentTime}");
            }
        }

        // Allowed cards set
        private readonly HashSet<string> _allowedRfidCards = new HashSet<string>
        {
            "6A003E69122F",
            "6A003E8565B4"
        };

        // Denied cards set
        private readonly HashSet<string> _deniedRfidCards = new HashSet<string>
        {
            "6A003E6E5369",
            "66006BF65DA6"
        };



        private void InitComms()
        {
            try
            {
                dataComms = new DataComms();
                dataComms.dataReceiveEvent += new DataComms.DataReceivedDelegate(CommsDataReceive);
                Debug.WriteLine("Comms initialized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing communication: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CommsDataReceive(string dataReceived)
        {
            Debug.WriteLine($"Data Received: {dataReceived}");

            // Handle known commands first
            if (dataReceived.Equals("PONG", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Received PONG from Raspberry Pi.", "Ping Test",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (IsRfidData(dataReceived))
            {
                // Show the RFID tag in the UI
                this.Invoke((MethodInvoker)(() =>
                {
                    textBoxRFID.Text = dataReceived;
                }));

                // Decide if the card is ALLOWED (GRANTED), DENIED, or "any other" => DENIED
                string accessStatus;
                if (_allowedRfidCards.Contains(dataReceived))
                {
                    accessStatus = "Granted";
                }
                else if (_deniedRfidCards.Contains(dataReceived))
                {
                    // explicitly known denied tags
                    accessStatus = "Denied";
                }
                else
                {
                    // any other unknown card is also denied
                    accessStatus = "Denied";
                }

                // Insert into the RFIDAccessLogs table with the fake timestamp
                InsertRFIDAccessLog(dataReceived, accessStatus, _fakeCurrentTime);

                // Advance your fake time so each RFID event appears an hour (or any interval) apart
                _fakeCurrentTime = _fakeCurrentTime.Add(_fakeTimeStep);

                return;
            }

            // === Check if it's sensor data ===
            if (dataReceived.Contains("TEMP:") && dataReceived.Contains("SOUND:"))
            {
                Debug.WriteLine("Sensor data received from Raspberry Pi.");

                // Parse into a Dictionary<string, string>
                var sensorDict = new Dictionary<string, string>();
                string[] sensorPairs = dataReceived.Split(';');
                foreach (var pair in sensorPairs)
                {
                    if (!string.IsNullOrWhiteSpace(pair) && pair.Contains(":"))
                    {
                        var kv = pair.Split(':');
                        if (kv.Length == 2)
                        {
                            sensorDict[kv[0]] = kv[1];
                        }
                    }
                }

                // Insert all sensor data (including Buzzer & Rotary) using a FAKE timestamp
                InsertSensorDataWithFakeTimestamp(sensorDict);

                // Advance the FAKE clock
                _fakeCurrentTime = _fakeCurrentTime.Add(_fakeTimeStep);

                return;
            }

            // If not recognized, just log it
            Debug.WriteLine($"Unknown data received: {dataReceived}");
        }

        private void InsertSensorDataWithFakeTimestamp(Dictionary<string, string> sensorValues)
        {
            try
            {
                // Extract real sensor readings from the Pi
                bool buttonPressed = bool.Parse(sensorValues["BUTTON"]);   // e.g. "True" / "False"
                bool motionDetected = bool.Parse(sensorValues["MOTION"]);   // PIR
                double soundLevel = double.Parse(sensorValues["SOUND"]);  // e.g. 300
                double temperature = double.Parse(sensorValues["TEMP"]);   // e.g. 23.45
                double distance = double.Parse(sensorValues["DIST"]);   // ultrasonic
                bool waterDetected = bool.Parse(sensorValues["WATER"]);
                string buzzerStatus = sensorValues["BUZZER"]; ;
                double rotaryAngle = double.Parse(sensorValues["ROTARY"]);
                string redLedString = sensorValues["REDLED"];    // "On" or "Off"
                int greenPwm = int.Parse(sensorValues["GREENPWM"]);

                if (distance < 0)
                {
                    distance = 0;
                    Debug.WriteLine("Distance < 0 detected; clamping to 0.");
                }

                if (sensorValues.ContainsKey("BUZZER"))
                {
                    buzzerStatus = sensorValues["BUZZER"];
                }
                else
                {
                    // fallback if not present
                    buzzerStatus = "Off";
                }

                if (sensorValues.ContainsKey("ROTARY"))
                {
                    rotaryAngle = double.Parse(sensorValues["ROTARY"]);
                }
                else
                {
                    rotaryAngle = 0.0;
                }
                // Use the "fake" timestamp
                DateTime fakeTs = _fakeCurrentTime;

                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();


                    // 1) Decide status
                    string redLedStatus = (redLedString.Equals("On", StringComparison.OrdinalIgnoreCase))
                                          ? "Red"
                                          : "Off";
                    // 2) Decide duty cycle (0 or 100)
                    double redDuty = redLedStatus == "Red" ? 100.0 : 0.0;

                    string sqlRedLed = @"
                INSERT INTO LEDSensorData (LEDName, [Status], DutyCycle, Timestamp)
                VALUES (@ledName, @status, @dutyCycle, @ts);
            ";
                    using (SqlCommand cmdRed = new SqlCommand(sqlRedLed, conn))
                    {
                        cmdRed.Parameters.AddWithValue("@ledName", "Red LED");
                        cmdRed.Parameters.AddWithValue("@status", redLedStatus);
                        cmdRed.Parameters.AddWithValue("@dutyCycle", redDuty);
                        cmdRed.Parameters.AddWithValue("@ts", fakeTs);

                        cmdRed.ExecuteNonQuery();
                    }

                    // === Insert LED data: GREEN LED ===
                    // 1) If greenPwm>0 => status="Green", else "Off"
                    string greenLedStatus = (greenPwm > 0) ? "Green" : "Off";

                    // 2) Convert 0..255 PWM => 0..100 duty cycle
                    double greenDuty = (greenPwm / 255.0) * 100.0;

                    string sqlGreenLed = @"
                INSERT INTO LEDSensorData (LEDName, [Status], DutyCycle, Timestamp)
                VALUES (@ledName, @status, @dutyCycle, @ts);
            ";
                    using (SqlCommand cmdGreen = new SqlCommand(sqlGreenLed, conn))
                    {
                        cmdGreen.Parameters.AddWithValue("@ledName", "Green LED");
                        cmdGreen.Parameters.AddWithValue("@status", greenLedStatus);
                        cmdGreen.Parameters.AddWithValue("@dutyCycle", greenDuty);
                        cmdGreen.Parameters.AddWithValue("@ts", fakeTs);

                        cmdGreen.ExecuteNonQuery();
                    }

                    // 1) Button table
                    string sqlButton = @"
                INSERT INTO ButtonSensorData (Pressed, Timestamp)
                VALUES (@pressed, @ts);
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlButton, conn))
                    {
                        cmd.Parameters.AddWithValue("@pressed", buttonPressed);
                        cmd.Parameters.AddWithValue("@ts", fakeTs);
                        cmd.ExecuteNonQuery();
                    }

                    // 2) PIR table
                    string sqlPIR = @"
                INSERT INTO PIRSensorData (Detected, Timestamp)
                VALUES (@detected, @ts);
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlPIR, conn))
                    {
                        cmd.Parameters.AddWithValue("@detected", motionDetected);
                        cmd.Parameters.AddWithValue("@ts", fakeTs);
                        cmd.ExecuteNonQuery();
                    }

                    // 3) Sound table
                    string sqlSound = @"
                INSERT INTO SoundSensorData (SoundLevel, Timestamp)
                VALUES (@soundLevel, @ts);
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlSound, conn))
                    {
                        cmd.Parameters.AddWithValue("@soundLevel", soundLevel);
                        cmd.Parameters.AddWithValue("@ts", fakeTs);
                        cmd.ExecuteNonQuery();
                    }

                    // 4) Temperature table
                    string sqlTemp = @"
                INSERT INTO TemperatureSensorData (Temperature, Timestamp)
                VALUES (@temperature, @ts);
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlTemp, conn))
                    {
                        cmd.Parameters.AddWithValue("@temperature", temperature);
                        cmd.Parameters.AddWithValue("@ts", fakeTs);
                        cmd.ExecuteNonQuery();
                    }

                    // 5) Ultrasonic table
                    string sqlDist = @"
                INSERT INTO UltrasonicSensorData (Distance, Timestamp)
                VALUES (@distance, @ts);
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlDist, conn))
                    {
                        cmd.Parameters.AddWithValue("@distance", distance);
                        cmd.Parameters.AddWithValue("@ts", fakeTs);
                        cmd.ExecuteNonQuery();
                    }

                    // 6) Water table
                    string sqlWater = @"
                INSERT INTO WaterSensorData (WaterDetected, Timestamp)
                VALUES (@waterDetected, @ts);
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlWater, conn))
                    {
                        cmd.Parameters.AddWithValue("@waterDetected", waterDetected);
                        cmd.Parameters.AddWithValue("@ts", fakeTs);
                        cmd.ExecuteNonQuery();
                    }
                


                string sqlBuzzer = @"
                INSERT INTO BuzzerSensorData (BuzzerStatus, Timestamp)
                VALUES (@bzStatus, @ts);
            ";
                using (SqlCommand cmdBuzzer = new SqlCommand(sqlBuzzer, conn))
                {
                    cmdBuzzer.Parameters.AddWithValue("@bzStatus", buzzerStatus);
                    cmdBuzzer.Parameters.AddWithValue("@ts", fakeTs);
                    cmdBuzzer.ExecuteNonQuery();
                }

                // === Insert to RotaryAngleSensorData ===
                // The 'Angle' column must be between 0 and 360
                string sqlRotary = @"
                INSERT INTO RotaryAngleSensorData (Angle, Timestamp)
                VALUES (@angle, @ts);
            ";
                using (SqlCommand cmdRotary = new SqlCommand(sqlRotary, conn))
                {
                    cmdRotary.Parameters.AddWithValue("@angle", rotaryAngle);
                    cmdRotary.Parameters.AddWithValue("@ts", fakeTs);
                    cmdRotary.ExecuteNonQuery();
                }
            }

                Debug.WriteLine($"Inserted REAL sensor data with FAKE timestamp: {fakeTs}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting sensor data with fake timestamp: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InsertRFIDAccessLog(string rfidTag, string accessStatus, DateTime ts)
        {
            try
            {
                int nextId;

                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();

                    // 1) Compute the next available LogID
                    string maxIdSql = @"SELECT ISNULL(MAX(LogID), 0) + 1 FROM RFIDAccessLogs;";
                    using (SqlCommand cmdMax = new SqlCommand(maxIdSql, conn))
                    {
                        nextId = Convert.ToInt32(cmdMax.ExecuteScalar());
                    }

                    // 2) Insert new record
                    string insertSql = @"
                INSERT INTO RFIDAccessLogs (LogID, RFIDTag, AccessStatus, Timestamp)
                VALUES (@logID, @rfidTag, @status, @ts);
            ";
                    using (SqlCommand cmdInsert = new SqlCommand(insertSql, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@logID", nextId);
                        cmdInsert.Parameters.AddWithValue("@rfidTag", rfidTag);
                        cmdInsert.Parameters.AddWithValue("@status", accessStatus);
                        cmdInsert.Parameters.AddWithValue("@ts", ts);

                        cmdInsert.ExecuteNonQuery();
                    }
                }

                Debug.WriteLine($"RFID Log Inserted: Tag={rfidTag}, Status={accessStatus}, Time={ts}, LogID={nextId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting RFID data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime? LoadLastFakeTimestamp()
        {
            DateTime? maxTimestamp = null;
            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();

                // We'll check each sensor table’s MAX Timestamp
                // adjust these queries to reflect your actual table names:
                List<string> queries = new List<string>
        {
            "SELECT MAX(Timestamp) FROM TemperatureSensorData",
            "SELECT MAX(Timestamp) FROM SoundSensorData",
            "SELECT MAX(Timestamp) FROM WaterSensorData",
            "SELECT MAX(Timestamp) FROM UltrasonicSensorData",
            "SELECT MAX(Timestamp) FROM ButtonSensorData",
            "SELECT MAX(Timestamp) FROM PIRSensorData",
            "SELECT MAX(Timestamp) FROM RFIDAccessLogs",
            "SELECT MAX(Timestamp) FROM BuzzerSensorData",
            "SELECT MAX(Timestamp) FROM RotaryAngleSensorData",
            "SELECT MAX(Timestamp) FROM LEDSensorData"
        };

                foreach (var sql in queries)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            DateTime thisTableMax = Convert.ToDateTime(result);
                            if (maxTimestamp == null || thisTableMax > maxTimestamp.Value)
                            {
                                maxTimestamp = thisTableMax;
                            }
                        }
                    }
                }
            }

            return maxTimestamp; // will be null if no table has any rows
        }





        private bool IsRfidData(string data)
        {
            // Assuming RFID data is a hexadecimal string of a specific length, e.g., 12 characters
            return data.Length == 12 && data.All(c => "0123456789ABCDEF".Contains(c));
        }


        private void ProcessSensorData(string data, string timestamp)
        {
            try
            {
                if (data.Contains("REDON"))
                {
                    SaveLEDDataToDB("Red LED", "ON", timestamp);
                }
                else if (data.Contains("REDOFF"))
                {
                    SaveLEDDataToDB("Red LED", "OFF", timestamp);
                }

                // Log the received data
                Debug.WriteLine($"Processed Data: {data} at {timestamp}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveLEDDataToDB(string ledName, string status, string timestamp)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "INSERT INTO LEDSensorData (LEDName, Status, Timestamp) VALUES (@ledName, @status, @timestamp)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ledName", ledName);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@timestamp", timestamp);

                        connection.Open();
                        command.ExecuteNonQuery();
                        Debug.WriteLine("LED data saved successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendDataToRaspberryPi(string command)
        {
            try
            {
                dataComms.sendData(command);
                Debug.WriteLine($"Command Sent: {command}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSendRedOn_Click(object sender, EventArgs e)
        {
            // Send command to turn on the red LED
            SendDataToRaspberryPi("REDON");
            //SendCommandToRaspberryPi("REDON");
        }

        private void btnSendRedOff_Click(object sender, EventArgs e)
        {
            // Send command to turn off the red LED
            SendDataToRaspberryPi("REDOFF");
            //SendCommandToRaspberryPi("REDOFF");
        }

        private void btnRefreshLED_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.LEDSensorData.Clear();

                lEDSensorDataTableAdapter.Fill(hardwareDBDataSet.LEDSensorData);
                dataGridViewLED.DataSource = hardwareDBDataSet.LEDSensorData;
                dataGridViewLED.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing LED data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshBuzzer_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.BuzzerSensorData.Clear();
                buzzerSensorDataTableAdapter.Fill(hardwareDBDataSet.BuzzerSensorData);
                dataGridViewBuzzer.DataSource = hardwareDBDataSet.BuzzerSensorData;
                dataGridViewBuzzer.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Buzzer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.ButtonSensorData.Clear();
                buttonSensorDataTableAdapter.Fill(hardwareDBDataSet.ButtonSensorData);
                dataGridViewButton.DataSource = hardwareDBDataSet.ButtonSensorData;
                dataGridViewButton.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Button data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshPIRMotion_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.PIRSensorData.Clear();
                pIRSensorDataTableAdapter.Fill(hardwareDBDataSet.PIRSensorData);
                dataGridViewPIRMotion.DataSource = hardwareDBDataSet.PIRSensorData;
                dataGridViewPIRMotion.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing PIR Motion data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshRFID_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.RFIDAccessLogs.Clear();
                rFIDAccessLogsTableAdapter.Fill(hardwareDBDataSet.RFIDAccessLogs);
                dataGridViewRFID.DataSource = hardwareDBDataSet.RFIDAccessLogs;
                dataGridViewRFID.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing RFID data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshWater_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.WaterSensorData.Clear();
                waterSensorDataTableAdapter.Fill(hardwareDBDataSet.WaterSensorData);
                dataGridViewWater.DataSource = hardwareDBDataSet.WaterSensorData;
                dataGridViewWater.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Water data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshRotaryAngle_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Rotary Angle refresh button clicked.");
            try
            {
                hardwareDBDataSet.RotaryAngleSensorData.Clear();
                rotaryAngleSensorDataTableAdapter.Fill(hardwareDBDataSet.RotaryAngleSensorData);
                dataGridViewRotaryAngle.DataSource = hardwareDBDataSet.RotaryAngleSensorData;
                dataGridViewRotaryAngle.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Rotary Angle data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshSound_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.SoundSensorData.Clear();
                soundSensorDataTableAdapter.Fill(hardwareDBDataSet.SoundSensorData);
                dataGridViewSound.DataSource = hardwareDBDataSet.SoundSensorData;
                dataGridViewSound.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Sound data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTemperature_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.TemperatureSensorData.Clear();
                temperatureSensorDataTableAdapter.Fill(hardwareDBDataSet.TemperatureSensorData);
                dataGridViewTemperature.DataSource = hardwareDBDataSet.TemperatureSensorData;
                dataGridViewTemperature.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Temperature data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshUltrasonic_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareDBDataSet.UltrasonicSensorData.Clear();
                ultrasonicSensorDataTableAdapter.Fill(hardwareDBDataSet.UltrasonicSensorData);
                dataGridViewUltrasonic.DataSource = hardwareDBDataSet.UltrasonicSensorData;
                dataGridViewUltrasonic.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Ultrasonic data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {

            try
            {
                SendDataToRaspberryPi("PING");
                Debug.WriteLine("Test connection command sent.");
                MessageBox.Show("Ping sent to Raspberry Pi.", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error testing connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxRFID_TextChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"RFID Text Box Updated: {textBoxRFID.Text}");
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {
            GraphJames form2 = new GraphJames();
            form2.Show();
        }

        private void btnClearAllData_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
            "Are you sure you want to clear ALL sensor data? This cannot be undone.",
            "Confirm Clear All",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                ClearAllSensorData();

                
                _fakeCurrentTime = DateTime.Now;
                Debug.WriteLine($"All sensor data cleared. " +
                                $"Fake time has been reset to {DateTime.Now}.");

                MessageBox.Show("All sensor data has been cleared!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ClearAllSensorData()
        {
            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();

               
                {
                    string truncateRfid = "TRUNCATE TABLE RFIDAccessLogs;";
                    using (SqlCommand cmd = new SqlCommand(truncateRfid, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                
                List<string> identityTables = new List<string>
        {
            "ButtonSensorData",
            "BuzzerSensorData",
            "LEDSensorData",
            "PIRSensorData",
            "RotaryAngleSensorData",
            "SoundSensorData",
            "TemperatureSensorData",
            "UltrasonicSensorData",
            "WaterSensorData"
        };

                // 2a) DELETE
                foreach (var table in identityTables)
                {
                    string sqlDelete = $"DELETE FROM {table};";
                    using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // 2b) RESEED 
                foreach (var table in identityTables)
                {
                    string sqlReseed = $"DBCC CHECKIDENT('{table}', RESEED, 0);";
                    using (SqlCommand cmd = new SqlCommand(sqlReseed, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

    }
}