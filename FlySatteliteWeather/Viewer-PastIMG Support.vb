﻿Imports System.Net

Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Public Class Viewer_PastIMG_Support


    Public shown = False


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
        Me.Size = New Point(871, 780)
    End Sub


    Dim DX, DY, isdown
    '___________________________窗体移动________________________________
    Private Sub p3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles background.MouseDown
        DX = e.X
        isdown = True
        DY = e.Y
    End Sub
    Private Sub p3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles background.MouseMove
        If isdown = True Then
            Me.Location = New Point(System.Windows.Forms.Cursor.Position.X - DX + 326, System.Windows.Forms.Cursor.Position.Y - DY)
            Form1.Location = New Point(System.Windows.Forms.Cursor.Position.X - DX + 168, System.Windows.Forms.Cursor.Position.Y - DY)
        End If
    End Sub


    Private Sub p3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles background.MouseUp
        isdown = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        MetroUI_Form.Dwm.DwmExtendFrameIntoClientArea(Me.Handle, dwmMargins)
        Me.Size = New Point(871, 780)
        If Not pastIMG.Count = 0 Then
            Try
                PictureBox1.Image = pastIMG(nowIndex)
            Catch ex As Exception

            End Try

        End If

    End Sub
    Dim inputPB As New PictureBox

    Dim pastIMG As New List(Of Bitmap)

    Dim nowIndex = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not nowIndex + 1 > pastIMG.Count - 1 Then nowIndex += 1
        Timer1.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not nowIndex - 1 < 0 Then nowIndex -= 1
        Timer1.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nowIndex = pastIMG.Count - 1
        Timer1.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nowIndex = 0
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not nowIndex - 1 < 0 Then
            nowIndex -= 1
        Else
            nowIndex = pastIMG.Count
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer1.Enabled = True

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer1.Enabled = False
    End Sub

    Sub showIMG(imgList As List(Of Bitmap))
        PictureBox1.Image = imgList(0)
        Me.Show()
        Me.Location = New Point(Form1.Location.X + 158, Form1.Location.Y)
        pastIMG = imgList
        shown = True
        Form1.Timer2.Enabled = False
        Me.Focus()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        shown = False
        Form1.Timer2.Enabled = True
    End Sub



    Private Sub Viewer_PastIMG_Support_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        shown = False
        Form1.Timer2.Enabled = True
    End Sub
End Class
