Imports System.Net
Imports System.Runtime.InteropServices

Imports Newtonsoft
Public Class Form1

#Region "shadows"
    Private dwmMargins As MetroUI_Form.Dwm.MARGINS
    Private _marginOk As Boolean
    Private _aeroEnabled As Boolean = False

#Region "Props"
    Public ReadOnly Property AeroEnabled() As Boolean
        Get
            Return _aeroEnabled
        End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Function LoWord(ByVal dwValue As Integer) As Integer
        Return dwValue And &HFFFF
    End Function

    Public Shared Function HiWord(ByVal dwValue As Integer) As Integer
        Return (dwValue >> 16) And &HFFFF
    End Function
#End Region


    Protected Overrides Sub WndProc(ByRef m As Message)
        Dim WM_NCCALCSIZE As Integer = &H83
        Dim WM_NCHITTEST As Integer = &H84
        Dim result As IntPtr = IntPtr.Zero

        Dim dwmHandled As Integer = MetroUI_Form.Dwm.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, result)

        If dwmHandled = 1 Then
            m.Result = result
            Return
        End If

        If m.Msg = WM_NCCALCSIZE AndAlso CType(m.WParam, Int32) = 1 Then
            Dim nccsp As MetroUI_Form.WinApi.NCCALCSIZE_PARAMS = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(MetroUI_Form.WinApi.NCCALCSIZE_PARAMS)), MetroUI_Form.WinApi.NCCALCSIZE_PARAMS)
            nccsp.rect0.Top += 0
            nccsp.rect0.Bottom += 0
            nccsp.rect0.Left += 0
            nccsp.rect0.Right += 0

            If Not _marginOk Then
                dwmMargins.cyTopHeight = 0
                dwmMargins.cxLeftWidth = 0
                dwmMargins.cyBottomHeight = 3
                dwmMargins.cxRightWidth = 0
                _marginOk = True
            End If

            Marshal.StructureToPtr(nccsp, m.LParam, False)

            m.Result = IntPtr.Zero
        ElseIf m.Msg = WM_NCHITTEST AndAlso CType(m.Result, Int32) = 0 Then
            m.Result = HitTestNCA(m.HWnd, m.WParam, m.LParam)
        Else
            MyBase.WndProc(m)
        End If
    End Sub
    Private Function HitTestNCA(ByVal hwnd As IntPtr, ByVal wparam As IntPtr, ByVal lparam As IntPtr) As IntPtr
        Dim HTNOWHERE As Integer = 0
        Dim HTCLIENT As Integer = 1
        Dim HTCAPTION As Integer = 2
        Dim HTGROWBOX As Integer = 4
        Dim HTSIZE As Integer = HTGROWBOX
        Dim HTMINBUTTON As Integer = 8
        Dim HTMAXBUTTON As Integer = 9
        Dim HTLEFT As Integer = 10
        Dim HTRIGHT As Integer = 11
        Dim HTTOP As Integer = 12
        Dim HTTOPLEFT As Integer = 13
        Dim HTTOPRIGHT As Integer = 14
        Dim HTBOTTOM As Integer = 15
        Dim HTBOTTOMLEFT As Integer = 16
        Dim HTBOTTOMRIGHT As Integer = 17
        Dim HTREDUCE As Integer = HTMINBUTTON
        Dim HTZOOM As Integer = HTMAXBUTTON
        Dim HTSIZEFIRST As Integer = HTLEFT
        Dim HTSIZELAST As Integer = HTBOTTOMRIGHT

        Dim p As New Point(LoWord(CType(lparam, Int32)), HiWord(CType(lparam, Int32)))
        Dim topleft As Rectangle = RectangleToScreen(New Rectangle(0, 0, dwmMargins.cxLeftWidth, dwmMargins.cxLeftWidth))

        If topleft.Contains(p) Then
            Return New IntPtr(HTTOPLEFT)
        End If

        Dim topright As Rectangle = RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, 0, dwmMargins.cxRightWidth, dwmMargins.cxRightWidth))

        If topright.Contains(p) Then
            Return New IntPtr(HTTOPRIGHT)
        End If

        Dim botleft As Rectangle = RectangleToScreen(New Rectangle(0, Height - dwmMargins.cyBottomHeight, dwmMargins.cxLeftWidth, dwmMargins.cyBottomHeight))

        If botleft.Contains(p) Then
            Return New IntPtr(HTBOTTOMLEFT)
        End If

        Dim botright As Rectangle = RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, Height - dwmMargins.cyBottomHeight, dwmMargins.cxRightWidth, dwmMargins.cyBottomHeight))

        If botright.Contains(p) Then
            Return New IntPtr(HTBOTTOMRIGHT)
        End If

        Dim top As Rectangle = RectangleToScreen(New Rectangle(0, 0, Width, dwmMargins.cxLeftWidth))

        If top.Contains(p) Then
            Return New IntPtr(HTTOP)
        End If

        Dim cap As Rectangle = RectangleToScreen(New Rectangle(0, dwmMargins.cxLeftWidth, Width, dwmMargins.cyTopHeight - dwmMargins.cxLeftWidth))

        If cap.Contains(p) Then
            Return New IntPtr(HTCAPTION)
        End If

        Dim left As Rectangle = RectangleToScreen(New Rectangle(0, 0, dwmMargins.cxLeftWidth, Height))

        If left.Contains(p) Then
            Return New IntPtr(HTLEFT)
        End If

        Dim right As Rectangle = RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, 0, dwmMargins.cxRightWidth, Height))

        If right.Contains(p) Then
            Return New IntPtr(HTRIGHT)
        End If

        Dim bottom As Rectangle = RectangleToScreen(New Rectangle(0, Height - dwmMargins.cyBottomHeight, Width, dwmMargins.cyBottomHeight))

        If bottom.Contains(p) Then
            Return New IntPtr(HTBOTTOM)
        End If

        Return New IntPtr(HTCLIENT)
    End Function
    Private Const BorderWidth As Integer = 16

    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
#End Region

    Public Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MetroUI_Form.Dwm.DwmExtendFrameIntoClientArea(Me.Handle, dwmMargins)
        Me.Size = New Point(867, 780)
    End Sub

    Dim nowIndex = 0
    Dim SatCloudURL As String = "http://szmb.gov.cn/data_cache/pictures/satPic/index.js"
    Dim SatImagePath As String = "http://szmb.gov.cn/data_cache/pictures/satPic"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Weather1.Init()
        'Weather1.InitOld()
        'Weather1.GetWeather_Caiyun()
        'MessageBox.Show(Net.GetHTML("http://www.pm25.in/guangzhou"))
        If Not My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", IO.Path.GetFileName(Application.ExecutablePath), 11000) = 11001 Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", IO.Path.GetFileName(Application.ExecutablePath), 11001)
            MessageBox.Show("位置信息已更新，请重新打开应用程序！")
            Me.Close()
            Me.Dispose()
            Form2.Dispose()
            Viewer.Dispose()
            Viewer_PastIMG_Support.Dispose()
            SplashScreen1.Dispose()
            End
        End If

        If My.Computer.Network.IsAvailable Then
            Me.CheckForIllegalCrossThreadCalls = False
            ListView1.Items.Item(0).Selected = True

            Update()
            UNow()
            WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))

        Else
            MessageBox.Show("无网络连接！")
            Me.Dispose()
        End If

        'Me.Location = New Point(Me.Location.X - 70, Me.Location.Y)
    End Sub
    Dim isloadFinished = False, isotherFinished = False
    Sub Update()

        Label2.Text = "FlyWeather - Pro 上次更新:" & Now.Hour & ":" & Now.Minute & ":" & Now.Second

        ' Weather1.GetWeather_Caiyun()
        isloadFinished = False

        UCloud()
        UTemp()
        URain()
        URadar()
        UThunder()

        isloadFinished = True
        If isotherFinished = True Then
            Form2.Hide()
        End If

    End Sub
    Sub UNow()

        Dim tr As New Threading.Thread(AddressOf UNow_Tr)
        Form2.Show()
        tr.Start()

    End Sub
    Delegate Sub asd(asd)

    Sub UNow_Tr()
        Try
            LoadWebImageToPictureBox(OtherPic, ListView1.SelectedItems.Item(0).Tag)
            Me.Invoke(New asd(AddressOf sendIMG), 0)

        Catch ex As Exception
        Finally
            Me.Invoke(New asd(AddressOf hidef2), 0)
        End Try
    End Sub
    Sub hidef2()
        If isloadFinished = True Then
            Form2.Hide()
        End If

    End Sub
    Sub sendIMG()
        If Viewer_PastIMG_Support.shown Or Viewer.shown Then
            Viewer_PastIMG_Support.Hide()
            Viewer.showIMG(OtherPic.Image, OtherPic)
            Viewer.Focus()
        End If

    End Sub
    Dim Cloud_PastIMG As New List(Of Bitmap)

    Sub UCloud()
        Dim Cloud_PastIMG_temp As New List(Of Bitmap)
        Dim Result As String = Net.GetHTML(SatCloudURL)
        Dim cut1() = Result.Split("{")
        For Each Str As String In cut1
            Try
                Dim url As String = TextProcessing.CutString(Str, """pic"":""satPic\", ".jpg")
                url = "http://szmb.gov.cn/data_cache/pictures/satPic" & Replace(url, "\", "") & ".jpg"
                'url = “http://t11.baidu.com/it/u=2363605270,2744285523&fm=76”
                Cloud_PastIMG_temp.Add(GetWebImage(url))
            Catch ex As Exception

            End Try

        Next
        Try
            PictureBox1.Image = Cloud_PastIMG_temp(0)
            Cloud_PastIMG = Cloud_PastIMG_temp

            ' If Viewer_PastIMG_Support.shown Then
            'Viewer_PastIMG_Support.showIMG(Cloud_PastIMG)
            ' End If
        Catch ex As Exception

        End Try
    End Sub

    Dim thunder_now, rain_now, radar_guangdong_now
    Dim thunder_img As New List(Of Bitmap), rain_img As New List(Of Bitmap), radar_guangdong_img As New List(Of Bitmap)

    Sub UTemp()

        Dim PicURL = "http://szmb.gov.cn/data_cache/pictures/distributed/temperatureLast1HourGif.gif"
        LoadWebImageToPictureBox(PictureBox2, PicURL)

    End Sub
    Sub URain()

        Dim PicURL = "http://wx.szmb.gov.cn/WeChat/data/mobile/rain/AWS_Shenzhen_R01H_%var%_.png"
        rain_img = New List(Of Bitmap)
        Dim EndNum = 9

        For i = 0 To EndNum
            Dim newUrl = PicURL.Replace("%var%", i)
            rain_img.Add(GetWebImage(newUrl))
        Next

    End Sub
    Sub URadar()

        Dim PicURL = "http://szmb.gov.cn/data_cache/szImages/radar/gd%var%.png"
        radar_guangdong_img = New List(Of Bitmap)
        Dim EndNum = 16

        For i = 1 To EndNum
            Dim newUrl = PicURL.Replace("%var%", i)
            radar_guangdong_img.Add(GetWebImage(newUrl))
        Next

        Console.WriteLine(radar_guangdong_img.Count)

    End Sub
    Sub UThunder()

        Dim PicURL = "http://szmb.gov.cn/data_cache/szImages/satellite/zh%var%.png"
        thunder_img = New List(Of Bitmap)
        Dim EndNum = 16

        For i = 0 To EndNum
            Dim newUrl = PicURL.Replace("%var%", i)
            thunder_img.Add(GetWebImage(newUrl))
        Next

    End Sub

    Function getUrl(showType, altitude, forecast)

        If showType = Nothing Then
            If forecast = Nothing Then
                Return "https://embed.windytv.com/?6," & altitude & "," & "message,ip,metric.wind.m/s"
            Else
                Return "https://embed.windytv.com/?6,in:" & forecast & "," & altitude & "," & "message,ip,metric.wind.m/s"
            End If
        Else
            If forecast = Nothing Then
                Return "https://embed.windytv.com/?6," & altitude & "," & showType & "," & "message,ip,metric.wind.m/s"
            Else
                Return "https://embed.windytv.com/?6,in:" & forecast & "," & altitude & "," & showType & "," & "message,ip,metric.wind.m/s"
            End If
        End If

    End Function

    Public Function LoadWebImageToPictureBox(ByVal pb As PictureBox, ByVal ImageURL As String) As Boolean
        Dim objImage As IO.MemoryStream
        Dim objwebClient As WebClient
        Dim sURL As String = Trim(ImageURL)
        Dim bAns As Boolean
        Try

            If Not sURL.ToLower().StartsWith("http://") _
                 Then sURL = "http://" & sURL
            objwebClient = New WebClient()

            objImage = New IO.MemoryStream(objwebClient.DownloadData(sURL))
            pb.Image = Image.FromStream(objImage)
            bAns = True

        Catch ex As Exception
            bAns = False
        End Try
        Return bAns
    End Function

    Function GetWebImage(URL As String)
        Dim objImage As IO.MemoryStream
        Dim objwebClient As WebClient

        Dim sURL As String = Trim(URL)

        Dim pb As Bitmap = Nothing
        Try
            If Not sURL.ToLower().StartsWith("http://") _
                 Then sURL = "http://" & sURL
            objwebClient = New WebClient()
            'objwebClient.DownloadFile(sURL, "E:\1212.jpg")
            objImage = New IO.MemoryStream(objwebClient.DownloadData(sURL))
            pb = Image.FromStream(objImage)
            'Image.FromStream(objImage).Save("E:\1212.jpg")
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
        Return pb
    End Function

    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Update()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Update()

    End Sub

    Dim DX, DY, isdown
    '___________________________窗体移动________________________________
    Private Sub p3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles background.MouseDown
        DX = e.X
        isdown = True
        DY = e.Y
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        End
        Me.Close()
        Me.Dispose()
        Form2.Dispose()
        Viewer.Dispose()
        Viewer_PastIMG_Support.Dispose()
        SplashScreen1.Dispose()
    End Sub

    Private Sub OtherPic_Click(sender As Object, e As EventArgs) Handles OtherPic.DoubleClick
        Viewer.showIMG(OtherPic.Image, OtherPic)
        Viewer_PastIMG_Support.Hide()
    End Sub
    Private Sub a_Click(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Viewer_PastIMG_Support.showIMG(Cloud_PastIMG)
        Viewer.shown = False
        Viewer.Close()
    End Sub
    Private Sub b_Click(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick
        Viewer.showIMG(PictureBox2.Image, PictureBox2)
        Viewer_PastIMG_Support.Hide()
    End Sub
    Private Sub c_Click(sender As Object, e As EventArgs) Handles PictureBox3.DoubleClick
        Viewer.showIMG(PictureBox3.Image, PictureBox3)
        Viewer_PastIMG_Support.Hide()
    End Sub
    Private Sub d_Click(sender As Object, e As EventArgs) Handles PictureBox4.DoubleClick
        Viewer.showIMG(PictureBox4.Image, PictureBox4)
        Viewer_PastIMG_Support.Hide()
    End Sub
    Private Sub eClick(sender As Object, e As EventArgs) Handles PictureBox5.DoubleClick
        Viewer.showIMG(PictureBox5.Image, PictureBox5)
        Viewer_PastIMG_Support.Hide()
    End Sub

    Dim typeA = "wind", altitude = "surface", forecast = Nothing

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim type = Nothing
        Select Case ComboBox2.SelectedIndex
            Case 0
                type = Nothing
            Case 1
                type = "temp"
            Case 2
                type = "clouds"
            Case 3
                type = "rain"
            Case 4
                type = "waves"
            Case 5
                type = "pressure"
        End Select
        typeA = type
        WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        forecast = "8"
        WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        forecast = "12"
        WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        forecast = "24"
        WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Weather1.changeSkin()
    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click
        Update()
    End Sub
    Dim nowi = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not Cloud_PastIMG.Count = 0 Then
            If Not nowi > Cloud_PastIMG.Count - 1 Then
                PictureBox1.Image = Cloud_PastIMG(nowi)
                nowi += 1
            Else
                nowi = 0
            End If
        End If

        If Not rain_img.Count = 0 Then
            If Not rain_now > rain_img.Count - 1 Then
                PictureBox3.Image = rain_img(rain_now)
                rain_now += 1
            Else
                rain_now = 0
            End If
        End If

        If Not radar_guangdong_img.Count = 0 Then
            If Not radar_guangdong_now > radar_guangdong_img.Count - 1 Then
                PictureBox4.Image = radar_guangdong_img(radar_guangdong_now)
                radar_guangdong_now += 1
            Else
                radar_guangdong_now = 0
            End If
        End If

        If Not thunder_img.Count = 0 Then
            If Not thunder_now > thunder_img.Count - 1 Then
                PictureBox5.Image = thunder_img(thunder_now)
                thunder_now += 1
            Else
                thunder_now = 0
            End If
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Weather1.Init()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        forecast = ""
        WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim alt = "surface"
        Select Case ComboBox1.SelectedIndex
            Case 0
                alt = "surface"
            Case 1
                alt = "150h"
            Case 2
                alt = "200h"
            Case 3
                alt = "300h"
            Case 4
                alt = "400h"
            Case 5
                alt = "500h"
            Case 6
                alt = "600h"
            Case 7
                alt = "700h"
            Case 8
                alt = "800h"
            Case 9
                alt = "850h"
            Case 10
                alt = "900h"
            Case 11
                alt = "925h"
            Case 12
                alt = "950h"
            Case 13
                alt = "100m"
        End Select
        altitude = alt
        WebBrowser2.Navigate(getUrl(typeA, altitude, forecast))
    End Sub

    Private Sub p3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles background.MouseMove
        If isdown = True Then
            Me.Location = New Point(System.Windows.Forms.Cursor.Position.X - DX, System.Windows.Forms.Cursor.Position.Y - DY)
        End If
    End Sub


    Private Sub p3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles background.MouseUp
        isdown = False
    End Sub

    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        Try
            nowIndex = ListView1.SelectedItems.Item(0).Index
            UNow()
        Catch ex As Exception
        End Try

    End Sub
End Class


Class TextProcessing
    Shared Function CutString(ResourceString As String, Head As String, Tail As String)
        Dim cutStart = InStr(ResourceString, Head) + Head.Length
        Dim cutLength = InStr(Start:=cutStart, String1:=ResourceString, String2:=Tail) - InStr(ResourceString, Head) - Head.Length
        Return (Mid(ResourceString, cutStart, cutLength))
    End Function
End Class
Class Net
    Shared Function GetHTML(URL As String)
        Dim rq As HttpWebRequest
        Try
            If InStr(URL, "http://") Then
                rq = WebRequest.Create(URL)
            Else
                rq = WebRequest.Create("http://" & URL)
            End If

            rq.Timeout = 1000
            Dim rp As HttpWebResponse = rq.GetResponse()

            Dim reader As IO.StreamReader = New IO.StreamReader(rp.GetResponseStream())
            Dim resourceString = reader.ReadToEnd
            Return resourceString
        Catch ex As Exception
            Return False
            Exit Function
        End Try
    End Function
End Class

