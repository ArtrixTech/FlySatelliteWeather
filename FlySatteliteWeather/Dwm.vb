' VBConversions Note: VB project level imports
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Data
Imports System.Xml.Linq
Imports System.Collections
Imports System.Linq
' End of VB project level imports
'Download by http://www.codefans.net
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Drawing

Namespace MetroUI_Form
    Public Class Dwm
        <StructLayout(LayoutKind.Explicit)>
        Public Structure RECT
            ' Fields
            <FieldOffset(12)>
            Public bottom As Integer
            <FieldOffset(0)>
            Public left As Integer
            <FieldOffset(8)>
            Public right As Integer
            <FieldOffset(4)>
            Public top As Integer

            Public Sub New(ByVal rect__1 As Rectangle)
                Me.left = rect__1.Left
                Me.top = rect__1.Top
                Me.right = rect__1.Right
                Me.bottom = rect__1.Bottom
            End Sub

            Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
                Me.left = left
                Me.top = top
                Me.right = right
                Me.bottom = bottom
            End Sub

            Public Sub [Set]()
                Me.left = System.Convert.ToInt32(InlineAssignHelper(Me.top, InlineAssignHelper(Me.right, InlineAssignHelper(Me.bottom, 0))))
            End Sub

            Public Sub [Set](ByVal rect As Rectangle)
                Me.left = rect.Left
                Me.top = rect.Top
                Me.right = rect.Right
                Me.bottom = rect.Bottom
            End Sub

            Public Sub [Set](ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
                Me.left = left
                Me.top = top
                Me.right = right
                Me.bottom = bottom
            End Sub

            Public Function ToRectangle() As Rectangle
                Return New Rectangle(Me.left, Me.top, Me.right - Me.left, Me.bottom - Me.top)
            End Function

            ' Properties
            Public ReadOnly Property Height() As Integer
                Get
                    Return (Me.bottom - Me.top)
                End Get
            End Property

            Public ReadOnly Property Size() As Size
                Get
                    Return New Size(Me.Width, Me.Height)
                End Get
            End Property

            Public ReadOnly Property Width() As Integer
                Get
                    Return (Me.right - Me.left)
                End Get
            End Property
            Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
                target = value
                Return value
            End Function
        End Structure

        Public Const DWM_BB_BLURREGION As Integer = 2
        Public Const DWM_BB_ENABLE As Integer = 1
        Public Const DWM_BB_TRANSITIONONMAXIMIZED As Integer = 4
        Public Const DWM_COMPOSED_EVENT_BASE_NAME As String = "DwmComposedEvent_"
        Public Const DWM_COMPOSED_EVENT_NAME_FORMAT As String = "%s%d"
        Public Const DWM_COMPOSED_EVENT_NAME_MAX_LENGTH As Integer = &H40
        Public Const DWM_FRAME_DURATION_DEFAULT As Integer = -1
        Public Const DWM_TNP_OPACITY As Integer = 4
        Public Const DWM_TNP_RECTDESTINATION As Integer = 1
        Public Const DWM_TNP_RECTSOURCE As Integer = 2
        Public Const DWM_TNP_SOURCECLIENTAREAONLY As Integer = &H10
        Public Const DWM_TNP_VISIBLE As Integer = 8
        Public Shared ReadOnly DwmApiAvailable As Boolean = System.Convert.ToBoolean(Environment.OSVersion.Version.Major >= 6)
        Public Const WM_DWMCOMPOSITIONCHANGED As Integer = &H31E

        <DllImport("dwmapi.dll")>
        Public Shared Function DwmDefWindowProc(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, ByRef result As IntPtr) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmEnableComposition(ByVal fEnable As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmEnableMMCSS(ByVal fEnableMMCSS As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmExtendFrameIntoClientArea(ByVal hdc As IntPtr, ByRef marInset As MARGINS) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmGetColorizationColor(ByRef pcrColorization As Integer, ByRef pfOpaqueBlend As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmGetCompositionTimingInfo(ByVal hwnd As IntPtr, ByRef pTimingInfo As DWM_TIMING_INFO) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmGetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByVal pvAttribute As IntPtr, ByVal cbAttribute As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmModifyPreviousDxFrameDuration(ByVal hwnd As IntPtr, ByVal cRefreshes As Integer, ByVal fRelative As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmQueryThumbnailSourceSize(ByVal hThumbnail As IntPtr, ByRef pSize As Size) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmRegisterThumbnail(ByVal hwndDestination As IntPtr, ByVal hwndSource As IntPtr, ByRef pMinimizedSize As Size, ByRef phThumbnailId As IntPtr) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmSetDxFrameDuration(ByVal hwnd As IntPtr, ByVal cRefreshes As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmSetPresentParameters(ByVal hwnd As IntPtr, ByRef pPresentParams As DWM_PRESENT_PARAMETERS) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByVal pvAttribute As IntPtr, ByVal cbAttribute As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmUnregisterThumbnail(ByVal hThumbnailId As IntPtr) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmUpdateThumbnailProperties(ByVal hThumbnailId As IntPtr, ByRef ptnProperties As DWM_THUMBNAIL_PROPERTIES) As Integer
        End Function

        <StructLayout(LayoutKind.Sequential)>
        Public Structure DWM_BLURBEHIND
            Public dwFlags As Integer
            Public fEnable As Integer
            Public hRgnBlur As IntPtr
            Public fTransitionOnMaximized As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure DWM_PRESENT_PARAMETERS
            Public cbSize As Integer
            Public fQueue As Integer
            Public cRefreshStart As Long
            Public cBuffer As Integer
            Public fUseSourceRate As Integer
            Public rateSource As UNSIGNED_RATIO
            Public cRefreshesPerFrame As Integer
            Public eSampling As DWM_SOURCE_FRAME_SAMPLING
        End Structure

        Public Enum DWM_SOURCE_FRAME_SAMPLING
            DWM_SOURCE_FRAME_SAMPLING_POINT
            DWM_SOURCE_FRAME_SAMPLING_COVERAGE
            DWM_SOURCE_FRAME_SAMPLING_LAST
        End Enum

        <StructLayout(LayoutKind.Sequential)>
        Public Structure DWM_THUMBNAIL_PROPERTIES
            Public dwFlags As Integer
            Public rcDestination As RECT
            Public rcSource As RECT
            Public opacity As Byte
            Public fVisible As Integer
            Public fSourceClientAreaOnly As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure DWM_TIMING_INFO
            Public cbSize As Integer
            Public rateRefresh As UNSIGNED_RATIO
            Public rateCompose As UNSIGNED_RATIO
            Public qpcVBlank As Long
            Public cRefresh As Long
            Public qpcCompose As Long
            Public cFrame As Long
            Public cRefreshFrame As Long
            Public cRefreshConfirmed As Long
            Public cFlipsOutstanding As Integer
            Public cFrameCurrent As Long
            Public cFramesAvailable As Long
            Public cFrameCleared As Long
            Public cFramesReceived As Long
            Public cFramesDisplayed As Long
            Public cFramesDropped As Long
            Public cFramesMissed As Long
        End Structure

        Public Enum DWMNCRENDERINGPOLICY
            DWMNCRP_USEWINDOWSTYLE
            DWMNCRP_DISABLED
            DWMNCRP_ENABLED
        End Enum

        Public Enum DWMWINDOWATTRIBUTE
            DWMWA_ALLOW_NCPAINT = 4
            DWMWA_CAPTION_BUTTON_BOUNDS = 5
            DWMWA_FLIP3D_POLICY = 8
            DWMWA_FORCE_ICONIC_REPRESENTATION = 7
            DWMWA_LAST = 9
            DWMWA_NCRENDERING_ENABLED = 1
            DWMWA_NCRENDERING_POLICY = 2
            DWMWA_NONCLIENT_RTL_LAYOUT = 6
            DWMWA_TRANSITIONS_FORCEDISABLED = 3
        End Enum

        <StructLayout(LayoutKind.Sequential)>
        Public Structure UNSIGNED_RATIO
            Public uiNumerator As Integer
            Public uiDenominator As Integer
        End Structure



        <StructLayout(LayoutKind.Sequential)>
        Public Structure MARGINS
            Public cxLeftWidth As Integer
            Public cxRightWidth As Integer
            Public cyTopHeight As Integer
            Public cyBottomHeight As Integer
            Public Sub New(ByVal Left As Integer, ByVal Right As Integer, ByVal Top As Integer, ByVal Bottom As Integer)
                Me.cxLeftWidth = Left
                Me.cxRightWidth = Right
                Me.cyTopHeight = Top
                Me.cyBottomHeight = Bottom
            End Sub
        End Structure

        Public Shared WTNCA_NODRAWCAPTION As UInt32 = &H1
        Public Shared WTNCA_NODRAWICON As UInt32 = &H2
        Public Shared WTNCA_NOSYSMENU As UInt32 = &H4
        Public Shared WTNCA_NOMIRRORHELP As UInt32 = &H8

        <StructLayout(LayoutKind.Sequential)>
        Public Structure WTA_OPTIONS
            Public Flags As UInt32
            Public Mask As UInt32
        End Structure

        Public Enum WindowThemeAttributeType
            WTA_NONCLIENT = 1
        End Enum

        <DllImport("UxTheme.dll")>
        Public Shared Function SetWindowThemeAttribute(ByVal hWnd As IntPtr, ByVal wtype As WindowThemeAttributeType, ByRef attributes As WTA_OPTIONS, ByVal size As UInt32) As Integer
        End Function
    End Class

End Namespace
