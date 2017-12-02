<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Weather
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LCity = New System.Windows.Forms.Label()
        Me.LNowTemp = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LDay = New System.Windows.Forms.Label()
        Me.LDayTemp = New System.Windows.Forms.Label()
        Me.LNightTemp = New System.Windows.Forms.Label()
        Me.LNight = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lpm25Value = New System.Windows.Forms.Label()
        Me.Lpm25 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LHumidity = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LWindData = New System.Windows.Forms.Label()
        Me.LWind = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LCloudData = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(18, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'LCity
        '
        Me.LCity.AutoSize = True
        Me.LCity.BackColor = System.Drawing.Color.Transparent
        Me.LCity.Font = New System.Drawing.Font("微软雅黑 Light", 12.0!)
        Me.LCity.ForeColor = System.Drawing.Color.White
        Me.LCity.Location = New System.Drawing.Point(124, 14)
        Me.LCity.Name = "LCity"
        Me.LCity.Size = New System.Drawing.Size(74, 21)
        Me.LCity.TabIndex = 4
        Me.LCity.Text = "未知城市"
        '
        'LNowTemp
        '
        Me.LNowTemp.AutoSize = True
        Me.LNowTemp.BackColor = System.Drawing.Color.Transparent
        Me.LNowTemp.Font = New System.Drawing.Font("微软雅黑 Light", 38.0!)
        Me.LNowTemp.ForeColor = System.Drawing.Color.White
        Me.LNowTemp.Location = New System.Drawing.Point(112, 37)
        Me.LNowTemp.Name = "LNowTemp"
        Me.LNowTemp.Size = New System.Drawing.Size(139, 66)
        Me.LNowTemp.TabIndex = 5
        Me.LNowTemp.Text = "30°C"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("宋体", 28.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(241, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 38)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "|"
        '
        'LDay
        '
        Me.LDay.AutoSize = True
        Me.LDay.BackColor = System.Drawing.Color.Transparent
        Me.LDay.Font = New System.Drawing.Font("微软雅黑 Light", 9.0!)
        Me.LDay.ForeColor = System.Drawing.Color.White
        Me.LDay.Location = New System.Drawing.Point(269, 9)
        Me.LDay.Name = "LDay"
        Me.LDay.Size = New System.Drawing.Size(56, 17)
        Me.LDay.TabIndex = 7
        Me.LDay.Text = "本地降雨"
        '
        'LDayTemp
        '
        Me.LDayTemp.AutoSize = True
        Me.LDayTemp.BackColor = System.Drawing.Color.Transparent
        Me.LDayTemp.Font = New System.Drawing.Font("微软雅黑 Light", 16.0!)
        Me.LDayTemp.ForeColor = System.Drawing.Color.White
        Me.LDayTemp.Location = New System.Drawing.Point(267, 26)
        Me.LDayTemp.Name = "LDayTemp"
        Me.LDayTemp.Size = New System.Drawing.Size(61, 30)
        Me.LDayTemp.TabIndex = 8
        Me.LDayTemp.Text = "30°C"
        '
        'LNightTemp
        '
        Me.LNightTemp.AutoSize = True
        Me.LNightTemp.BackColor = System.Drawing.Color.Transparent
        Me.LNightTemp.Font = New System.Drawing.Font("微软雅黑 Light", 16.0!)
        Me.LNightTemp.ForeColor = System.Drawing.Color.White
        Me.LNightTemp.Location = New System.Drawing.Point(398, 26)
        Me.LNightTemp.Name = "LNightTemp"
        Me.LNightTemp.Size = New System.Drawing.Size(61, 30)
        Me.LNightTemp.TabIndex = 11
        Me.LNightTemp.Text = "30°C"
        '
        'LNight
        '
        Me.LNight.AutoSize = True
        Me.LNight.BackColor = System.Drawing.Color.Transparent
        Me.LNight.Font = New System.Drawing.Font("微软雅黑 Light", 9.0!)
        Me.LNight.ForeColor = System.Drawing.Color.White
        Me.LNight.Location = New System.Drawing.Point(400, 9)
        Me.LNight.Name = "LNight"
        Me.LNight.Size = New System.Drawing.Size(56, 17)
        Me.LNight.TabIndex = 10
        Me.LNight.Text = "附近降雨"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("宋体", 28.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(372, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 38)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "|"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(690, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "●"
        '
        'Lpm25Value
        '
        Me.Lpm25Value.AutoSize = True
        Me.Lpm25Value.BackColor = System.Drawing.Color.Transparent
        Me.Lpm25Value.Font = New System.Drawing.Font("微软雅黑 Light", 16.0!)
        Me.Lpm25Value.ForeColor = System.Drawing.Color.White
        Me.Lpm25Value.Location = New System.Drawing.Point(525, 24)
        Me.Lpm25Value.Name = "Lpm25Value"
        Me.Lpm25Value.Size = New System.Drawing.Size(118, 30)
        Me.Lpm25Value.TabIndex = 28
        Me.Lpm25Value.Text = "30mg/cm³"
        '
        'Lpm25
        '
        Me.Lpm25.AutoSize = True
        Me.Lpm25.BackColor = System.Drawing.Color.Transparent
        Me.Lpm25.Font = New System.Drawing.Font("微软雅黑 Light", 9.0!)
        Me.Lpm25.ForeColor = System.Drawing.Color.White
        Me.Lpm25.Location = New System.Drawing.Point(527, 10)
        Me.Lpm25.Name = "Lpm25"
        Me.Lpm25.Size = New System.Drawing.Size(128, 17)
        Me.Lpm25.TabIndex = 27
        Me.Lpm25.Text = "PM2.5 - 空气重度污染"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("宋体", 28.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(498, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 38)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "|"
        '
        'LHumidity
        '
        Me.LHumidity.AutoSize = True
        Me.LHumidity.BackColor = System.Drawing.Color.Transparent
        Me.LHumidity.Font = New System.Drawing.Font("微软雅黑 Light", 16.0!)
        Me.LHumidity.ForeColor = System.Drawing.Color.White
        Me.LHumidity.Location = New System.Drawing.Point(267, 75)
        Me.LHumidity.Name = "LHumidity"
        Me.LHumidity.Size = New System.Drawing.Size(56, 30)
        Me.LHumidity.TabIndex = 31
        Me.LHumidity.Text = "50%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("微软雅黑 Light", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(269, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "空气湿度"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("宋体", 28.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(241, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 38)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "|"
        '
        'LWindData
        '
        Me.LWindData.AutoSize = True
        Me.LWindData.BackColor = System.Drawing.Color.Transparent
        Me.LWindData.Font = New System.Drawing.Font("微软雅黑 Light", 14.0!)
        Me.LWindData.ForeColor = System.Drawing.Color.White
        Me.LWindData.Location = New System.Drawing.Point(398, 75)
        Me.LWindData.Name = "LWindData"
        Me.LWindData.Size = New System.Drawing.Size(55, 25)
        Me.LWindData.TabIndex = 34
        Me.LWindData.Text = "30°C"
        '
        'LWind
        '
        Me.LWind.AutoSize = True
        Me.LWind.BackColor = System.Drawing.Color.Transparent
        Me.LWind.Font = New System.Drawing.Font("微软雅黑 Light", 9.0!)
        Me.LWind.ForeColor = System.Drawing.Color.White
        Me.LWind.Location = New System.Drawing.Point(400, 58)
        Me.LWind.Name = "LWind"
        Me.LWind.Size = New System.Drawing.Size(32, 17)
        Me.LWind.TabIndex = 33
        Me.LWind.Text = "风力"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("宋体", 28.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(372, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 38)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "|"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Teal
        Me.PictureBox2.Location = New System.Drawing.Point(653, 14)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'LCloudData
        '
        Me.LCloudData.AutoSize = True
        Me.LCloudData.BackColor = System.Drawing.Color.Transparent
        Me.LCloudData.Font = New System.Drawing.Font("微软雅黑 Light", 16.0!)
        Me.LCloudData.ForeColor = System.Drawing.Color.White
        Me.LCloudData.Location = New System.Drawing.Point(524, 73)
        Me.LCloudData.Name = "LCloudData"
        Me.LCloudData.Size = New System.Drawing.Size(56, 30)
        Me.LCloudData.TabIndex = 38
        Me.LCloudData.Text = "99%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("微软雅黑 Light", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(526, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 17)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "云量"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("宋体", 28.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(498, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 38)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "|"
        '
        'Weather
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.LCloudData)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LWindData)
        Me.Controls.Add(Me.LWind)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LHumidity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Lpm25Value)
        Me.Controls.Add(Me.Lpm25)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LNightTemp)
        Me.Controls.Add(Me.LNight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LDayTemp)
        Me.Controls.Add(Me.LDay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LCity)
        Me.Controls.Add(Me.LNowTemp)
        Me.Name = "Weather"
        Me.Size = New System.Drawing.Size(708, 113)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LCity As Label
    Friend WithEvents LNowTemp As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LDay As Label
    Friend WithEvents LDayTemp As Label
    Friend WithEvents LNightTemp As Label
    Friend WithEvents LNight As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Lpm25Value As Label
    Friend WithEvents Lpm25 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LHumidity As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LWindData As Label
    Friend WithEvents LWind As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LCloudData As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
End Class
