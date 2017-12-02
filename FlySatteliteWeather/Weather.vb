Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Runtime.Serialization
Public Class Weather

    Dim weatherURL As String = "http://api.ip138.com/weather/?code=%cc%&type=%days%&callback=find&token=19d7aa9aa777d09103dcc765c059e6e4"
    Dim caiyunURL As String = "api.caiyunapp.com/v2/HvnjGv=zeGeqWbpw/%lon%,%lat%/realtime"

    Structure LocationDataOld
        Dim Country
        Dim Province
        Dim City
        Dim IPAddress
    End Structure

    Structure LocationData
        Dim Country
        Dim Province
        Dim City
        Dim Longitude
        Dim Latitude
        Dim IPAddress
    End Structure
    Structure WeatherOld
        Dim cityCode

        Dim nowWeather
        Dim nowTemp
        Dim nowWind

        Dim dayWeather
        Dim dayTemp
        Dim dayWind

        Dim nightWeather
        Dim nightTemp
        Dim nightWind

        Dim pm25
        Dim Humidity
    End Structure

    Structure WeatherData
        Dim cityName

        Dim skyCon
        Dim temp
        Dim cloudRate
        Dim skyCon_Chinese

        Dim humidity
        Dim pm25
        Dim aqi

        Dim localRainIntensity

        Dim nearestRainIntensity
        Dim nearestRainDistance

        Dim windDirection
        Dim windSpeed

        Dim haveNear
    End Structure


    Structure SevenDayWeather
        Dim cityCode

        Dim Weather1
        Dim HIGHTemp1
        Dim LOWTemp1
        Dim Wind1

        Dim dayWeather
        Dim dayTemp
        Dim dayWind

        Dim nightWeather
        Dim nightTemp
        Dim nightWind

        Dim pm25
        Dim Humidity
    End Structure

    Sub InitOld()

        Dim cityData As LocationDataOld = getLocationOld()

        Dim weather As WeatherOld = getWeatherOld(cityData.City)

        Dim isNight = False


        If Not weather.nowWeather = Nothing Then
            LCity.Text = cityData.City & “ - ” & weather.nowWeather
        Else
            LCity.Text = cityData.City & “ - ” & "无数据"
        End If
        LNowTemp.Text = weather.nowTemp & "°C"
        LDay.Text = "白天 - " & weather.dayWeather
        LNight.Text = "夜间 - " & weather.nightWeather
        LDayTemp.Text = weather.dayTemp & "°C"
        LNightTemp.Text = weather.nightTemp & "°C"

        Dim pm25 = weather.pm25
        Lpm25Value.Text = pm25 & "mg/cm³"

        LHumidity.Text = weather.Humidity & "%"

        LWindData.Text = weather.nowWind

        'pm25 = 172

        If pm25 < 50 Then
            PictureBox2.BackColor = Color.Green
            Lpm25.Text = "PM2.5 - 空气质量优秀"
        End If
        If pm25 < 100 And pm25 >= 50 Then
            PictureBox2.BackColor = Color.Yellow
            Lpm25.Text = "PM2.5 - 空气质量良好"
        End If
        If pm25 < 150 And pm25 >= 100 Then
            PictureBox2.BackColor = Color.OrangeRed
            Lpm25.Text = "PM2.5 - 空气轻度污染"
        End If
        If pm25 < 200 And pm25 >= 150 Then
            PictureBox2.BackColor = Color.Crimson
            Lpm25.Text = "PM2.5 - 空气中度污染"
        End If
        If pm25 < 300 And pm25 >= 200 Then
            PictureBox2.BackColor = Color.DarkMagenta
            Lpm25.Text = "PM2.5 - 空气重度污染"
        End If
        If pm25 >= 300 Then
            PictureBox2.BackColor = Color.DarkRed
            Lpm25.Text = "PM2.5 - 空气严重污染"
        End If

        If Now.Hour > 18 Or Now.Hour < 6 Then
            changeSkin()
            isNight = True
        Else
            changeSkin()
            isNight = False
        End If

        If weather.nowWeather = "晴" Then
            If isNight Then
                PictureBox1.Image = My.Resources.晴_png
            Else
                PictureBox1.Image = My.Resources.晴_png
            End If

        End If

        If weather.nowWeather = "多云" Then
            If isNight Then
                PictureBox1.Image = My.Resources.多云_png
            Else
                PictureBox1.Image = My.Resources.多云_png
            End If
        End If

        If weather.nowWeather = "大雨" Then
            If isNight Then
                PictureBox1.Image = My.Resources.大雨_png
            Else
                PictureBox1.Image = My.Resources.大雨_png
            End If
        End If

        If weather.nowWeather = "中雨" Then
            If isNight Then
                PictureBox1.Image = My.Resources.中雨_png
            Else
                PictureBox1.Image = My.Resources.中雨_png
            End If
        End If

        If weather.nowWeather = "小雨" Then
            If isNight Then
                PictureBox1.Image = My.Resources.小雨_png
            Else
                PictureBox1.Image = My.Resources.小雨_png
            End If
        End If

        If weather.nowWeather = "阵雨" Then
            If isNight Then
                PictureBox1.Image = My.Resources.阵雨_png
            Else
                PictureBox1.Image = My.Resources.阵雨_png
            End If
        End If

        If weather.nowWeather = "雨" Then
            If isNight Then
                PictureBox1.Image = My.Resources.阵雨_png
            Else
                PictureBox1.Image = My.Resources.阵雨_png
            End If
        End If

    End Sub

    Sub Init()

        Dim cityData As LocationData = getLocation()

        Dim weather As WeatherData = GetWeather_Caiyun(cityData)

        Dim isNight = False

        LCity.Text = cityData.City & “ - ” & weather.skyCon_Chinese
        LNowTemp.Text = CInt(weather.temp) & "°C"

        'If Not weather.nearestRainIntensity = 0 Then
        'If weather.haveNear Then
        'LNight.Text = "最近降雨带 - 距离" & CInt(weather.nearestRainDistance) & "Km"
        'LNightTemp.Text = CInt(100 * weather.nearestRainIntensity) & "%"
        'Else
        'LNight.Text = "附近无降雨"
        'LNightTemp.Text = "0%"
        'End If
        'Else
        'LNight.Text = "附近无降雨"
        'LNightTemp.Text = "0%"
        'End If

        If CInt(100 * weather.localRainIntensity) < 1 Then
            If weather.nearestRainDistance > 500 Then
                LDay.Text = "无降雨"
                LDayTemp.Text = "0%"
            Else
                LDay.Text = "降雨 - 距您" & CInt(weather.nearestRainDistance) & "Km"
                LDayTemp.Text = CInt(100 * weather.nearestRainIntensity) & "%"
            End If
        Else
            LDay.Text = "本地降雨"
            LDayTemp.Text = CInt(100 * weather.localRainIntensity) & "%"
        End If

        LNight.Text = "空气质量指数"
        LNightTemp.Text = weather.aqi

        LCloudData.Text = CInt(weather.cloudRate * 100) & "%"

        Dim pm25 = weather.pm25
        Lpm25Value.Text = pm25 & "mg/cm³"

        LHumidity.Text = CInt(weather.humidity * 100) & "%"

        Dim windDirection = weather.windDirection
        Dim windDirection_Chinese = ""

        Select Case CInt(windDirection / 30)
            Case 0
                windDirection_Chinese = "N"
            Case 1
                windDirection_Chinese = "NE"
            Case 2
                windDirection_Chinese = "E"
            Case 3
                windDirection_Chinese = "E"
            Case 4
                windDirection_Chinese = "SE"
            Case 5
                windDirection_Chinese = "S"
            Case 6
                windDirection_Chinese = "S"
            Case 7
                windDirection_Chinese = "SW"
            Case 8
                windDirection_Chinese = "W"
            Case 9
                windDirection_Chinese = "W"
            Case 10
                windDirection_Chinese = "NW"
            Case 11
                windDirection_Chinese = "N"
        End Select

        LWind.Text = "风 - " & CInt(weather.windSpeed) & "Km/h"
        LWindData.Text = windDirection_Chinese & " - " & CInt(weather.windDirection) & "°"

        'pm25 = 172

        If pm25 < 50 Then
            PictureBox2.BackColor = Color.Green
            Lpm25.Text = "PM2.5 - 空气质量优秀"
        End If
        If pm25 < 100 And pm25 >= 50 Then
            PictureBox2.BackColor = Color.Yellow
            Lpm25.Text = "PM2.5 - 空气质量良好"
        End If
        If pm25 < 150 And pm25 >= 100 Then
            PictureBox2.BackColor = Color.OrangeRed
            Lpm25.Text = "PM2.5 - 空气轻度污染"
        End If
        If pm25 < 200 And pm25 >= 150 Then
            PictureBox2.BackColor = Color.Crimson
            Lpm25.Text = "PM2.5 - 空气中度污染"
        End If
        If pm25 < 300 And pm25 >= 200 Then
            PictureBox2.BackColor = Color.DarkMagenta
            Lpm25.Text = "PM2.5 - 空气重度污染"
        End If
        If pm25 >= 300 Then
            PictureBox2.BackColor = Color.DarkRed
            Lpm25.Text = "PM2.5 - 空气严重污染"
        End If

        If Now.Hour > 18 Or Now.Hour < 6 Then
            changeSkin()
            isNight = True
        Else
            changeSkin()
            isNight = False
        End If

        If weather.skyCon_Chinese = "晴天" Or weather.skyCon_Chinese = "晴夜" Then
            If isNight Then
                PictureBox1.Image = My.Resources.晴_png
            Else
                PictureBox1.Image = My.Resources.晴_png
            End If

        End If

        If weather.skyCon_Chinese = "多云" Then
            If isNight Then
                PictureBox1.Image = My.Resources.多云_png
            Else
                PictureBox1.Image = My.Resources.多云_png
            End If
        End If

        If weather.skyCon_Chinese = "雨" Then
            If isNight Then
                PictureBox1.Image = My.Resources.大雨_png
            Else
                PictureBox1.Image = My.Resources.大雨_png
            End If
        End If

        If weather.skyCon_Chinese = "雪" Then
            If isNight Then
                PictureBox1.Image = My.Resources.大雨_png
            Else
                PictureBox1.Image = My.Resources.大雨_png
            End If
        End If

        If weather.skyCon_Chinese = "阴" Then
            If isNight Then
                PictureBox1.Image = My.Resources.阴天_png
            Else
                PictureBox1.Image = My.Resources.阴天_png
            End If
        End If

        If weather.skyCon_Chinese = "风" Then
            If isNight Then
                PictureBox1.Image = My.Resources.强沙尘暴_png
            Else
                PictureBox1.Image = My.Resources.强沙尘暴_png
            End If
        End If

        If weather.skyCon_Chinese = "雾" Then
            If isNight Then
                PictureBox1.Image = My.Resources.雾_png
            Else
                PictureBox1.Image = My.Resources.雾_png
            End If
        End If

    End Sub

    Dim index = 0
    Sub changeSkin()

        Randomize()

        Dim nowR = CInt(Rnd() * 4)
        Do Until Not nowR = index
            nowR = CInt(Rnd() * 4)
        Loop

        index = nowR

        If index = 0 Then
            Me.BackgroundImage = My.Resources.night
        ElseIf index = 1 Then
            Me.BackgroundImage = My.Resources.night2
        ElseIf index = 2 Then
            Me.BackgroundImage = My.Resources.night3
        ElseIf index = 3 Then
            Me.BackgroundImage = My.Resources.night4
        Else
            Me.BackgroundImage = My.Resources.night3
        End If

    End Sub

    Function getWeatherOld(cityname As String, Optional isSevendays As Boolean = False) As WeatherOld

        Dim rt As New WeatherOld

        '________________________________________________________________

        'Get Citycode 
        Dim cityCode = "110000"

        For Each line In My.Resources.city.Split(vbNewLine)
            If InStr(line, cityname) > 0 Then
                cityCode = CutString(line, """", """")
                rt.cityCode = cityCode
            End If
        Next

        '________________________________________________________________

        If Not isSevendays Then

            Dim requestURL = Replace(weatherURL, "%cc%", cityCode)
            requestURL = Replace(requestURL, "%days%", 1)
            Dim response As String = GetHTML(requestURL)

            Dim allData() = response.Split(",")
            For Each d As String In allData

                If InStr(d, "dayWeather") > 0 Then
                    d = repAll(d)
                    rt.dayWeather = CutString(d, ":", "|")
                End If
                If InStr(d, "dayTemp") > 0 Then
                    d = repAll(d)
                    rt.dayTemp = CutString(d, ":", "|")
                End If
                If InStr(d, "dayWind") > 0 Then
                    d = repAll(d)
                    rt.dayWind = CutString(d, ":", "|")
                End If

                If InStr(d, "nightWeather") > 0 Then
                    d = repAll(d)
                    rt.nightWeather = CutString(d, ":", "|")
                End If
                If InStr(d, "nightTemp") > 0 Then
                    d = repAll(d)
                    rt.nightTemp = CutString(d, ":", "|")
                End If
                If InStr(d, "nightWind") > 0 Then
                    d = repAll(d)
                    rt.nightWind = CutString(d, ":", "|")
                End If

                If InStr(d, """weather") > 0 Then
                    d = repAll(d)
                    rt.nowWeather = CutString(d, ":", "|")
                End If
                If InStr(d, """temp") > 0 Then
                    d = repAll(d)
                    rt.nowTemp = CutString(d, ":", "|")
                End If
                If InStr(d, """wind") > 0 Then
                    d = repAll(d)
                    rt.nowWind = CutString(d, ":", "|")
                End If

                If InStr(d, "humidity") > 0 Then
                    d = repAll(d)
                    rt.Humidity = CutString(d, ":", "|")
                End If
                If InStr(d, "pm25") > 0 Then
                    d = repAll(d)
                    rt.pm25 = CutString(d, ":", "|")
                End If

            Next

        End If '

        Return rt

    End Function

    Function GetWeather_Caiyun(location As LocationData)

        Dim rtWeather As New WeatherData

        Dim url = caiyunURL
        url = Replace(url, "%lon%", location.Longitude)
        url = Replace(url, "%lat%", location.Latitude)
        Dim data As String = GetHTML(url)

        Dim nearestRainData As New List(Of String)
        If InStr(data, "nearest") Then
            nearestRainData = getSerializedData(CutString(data, "nearest", "local"))
            rtWeather.haveNear = True
        Else
            rtWeather.haveNear = False
        End If
        Dim localRainData As List(Of String) = getSerializedData(CutString(data, "local", "wind"))

        rtWeather.localRainIntensity = getDataByName(localRainData, "intensity")                    'get Rainning data
        If rtWeather.haveNear Then
            rtWeather.nearestRainIntensity = getDataByName(nearestRainData, "intensity")
            rtWeather.nearestRainDistance = getDataByName(nearestRainData, "distance")
        End If


        Dim otherData As List(Of String) = getSerializedData(data) 'get other data.
        'Debug.WriteLine(data)
        For Each t In otherData
            ' MessageBox.Show(t)
        Next
        rtWeather.pm25 = getDataByName(otherData, "pm25")
        rtWeather.windDirection = getDataByName(otherData, "direction")
        rtWeather.windSpeed = getDataByName(otherData, "speed")
        rtWeather.skyCon = getDataByName(otherData, "skycon")
        rtWeather.cloudRate = getDataByName(otherData, "cloudrate")
        rtWeather.humidity = getDataByName(otherData, "humidity")
        rtWeather.temp = getDataByName(otherData, "temperature")
        rtWeather.aqi = getDataByName(otherData, "aqi")

        For Each line In My.Resources.skyCon.Split(vbNewLine)
            If InStr(line, rtWeather.skyCon) Then
                rtWeather.skyCon_Chinese = CutString(line, ":", "|")
            End If
        Next

        Return rtWeather

    End Function
    Function getDataByName(data As List(Of String), name As String)
        For Each t As String In data
            If InStr(t, name) > 0 Then
                Return CutString(t, ":", "|")
            End If
        Next
        Return False
    End Function
    Function getSerializedData(data As String)
        Dim allData As New List(Of String)
        '\w*"":\w+.\w*
        Dim splitedDataNumbers = getRegex(data, "\w*"":\d+.\d*") 'Unsigned numbers
        Dim splitedDataSNumbers = getRegex(data, "\w*"":-\w+.\w+") 'signed numbers
        Dim splitedDataWords = getRegex(data, "\w*"":""\w+") 'words

        For Each t In splitedDataNumbers
            If Not allData.Contains(repAll(t.ToString)) Then
                allData.Add(repAll(t.ToString))
            End If
        Next
        For Each t In splitedDataSNumbers
            If Not allData.Contains(repAll(t.ToString)) Then
                allData.Add(repAll(t.ToString))
            End If
        Next
        For Each t In splitedDataWords
            If Not allData.Contains(repAll(t.ToString)) Then
                allData.Add(repAll(t.ToString))
            End If
        Next
        Return allData
    End Function
    Function getRegex(ByVal Str, regex)
        Dim re As New Regex(regex)
        Dim Contents As MatchCollection = re.Matches(Str)
        Dim links As String = Nothing
        Return Contents
    End Function

    Function getLocation() As LocationData

        Dim rt As New LocationData
        Dim IPurl = "http://api.ip138.com/query/?token=9d6b5758a12fca72681964dffd5fa9e4"
        Dim Response = GetHTML(IPurl)

        Dim ip As String = CutString(Response, "ip"":""", """") 'get city data and province data.
        rt.IPAddress = ip

        Dim country As String = "", province As String = "", city As String = "", ISP As String = ""

        Dim allData As String = CutString(Response, "data"":[""", "]")
        allData = Replace(allData, """", "")
        Dim split() As String = allData.Split(",")

        rt.Country = split(0)
        rt.Province = split(1)
        rt.City = split(2)

        'get City Longitude and latitude data.
        For Each line In My.Resources.CityLocation.Split(vbNewLine)
            If InStr(line, rt.City) > 0 Then
                rt.Longitude = CutString(line, ",", ",")
                rt.Latitude = CutString(line, rt.Longitude & ",", "|")
            End If
        Next

        Return rt
    End Function

    Function repAll(str As String)
        Dim d = str
        d = Replace(d, """", "")
        d = Replace(d, ",", "")
        d = Replace(d, "]", "")
        d = Replace(d, "}", "")
        d = Replace(d, "[", "")
        d = Replace(d, "{", "")
        d = Replace(d, "(", "")
        d = Replace(d, ")", "")
        d += "|"
        Return d
    End Function

    Function getLocationOld() As LocationDataOld

        Dim rt As New LocationDataOld
        Dim IPurl = "http://api.ip138.com/query/?token=9d6b5758a12fca72681964dffd5fa9e4"
        Dim Response = GetHTML(IPurl)

        Dim ip As String = CutString(Response, "ip"":""", """")
        rt.IPAddress = ip

        Dim country As String = "", province As String = "", city As String = "", ISP As String = ""

        Dim allData As String = CutString(Response, "data"":[""", "]")
        allData = Replace(allData, """", "")
        Dim split() As String = allData.Split(",")

        rt.Country = split(0)
        rt.Province = split(1)
        rt.City = split(2)

        Return rt

    End Function 'OLD

    Shared Function CutString(ResourceString As String, Head As String, Tail As String)
        Dim cutStart = InStr(ResourceString, Head) + Head.Length
        Dim cutLength = InStr(Start:=cutStart, String1:=ResourceString, String2:=Tail) - InStr(ResourceString, Head) - Head.Length
        Return (Mid(ResourceString, cutStart, cutLength))
    End Function

    Shared Function GetHTML(URL As String)
        Dim rq As HttpWebRequest
        Try
            If InStr(URL, "http://") Then
                rq = WebRequest.Create(URL)
            Else
                rq = WebRequest.Create("http://" & URL)
            End If
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Dim rp As HttpWebResponse = rq.GetResponse()
        Dim reader As IO.StreamReader = New IO.StreamReader(rp.GetResponseStream())
        Dim resourceString = reader.ReadToEnd
        Return resourceString
    End Function

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        changeSkin()
    End Sub

End Class


Public Class JSONAnal
    Public Function parse(jsonString As String)

        Using ms As New IO.MemoryStream(Text.Encoding.UTF8.GetBytes(jsonString))
            ' Return New JSON.DataContractJsonSerializer(TypeOf ()）.ReadObject(ms)
        End Using

    End Function

    Public Function stringlify(jsonObject As Object)
        Using ms As New IO.MemoryStream
            Dim a As New JSON.DataContractJsonSerializer(jsonObject.GetType())
            a.WriteObject(ms, jsonObject)
            Return Text.Encoding.UTF8.GetString(ms.ToArray())
        End Using
    End Function
End Class


Public NotInheritable Class JSONAnalyze

    Private Sub New()
    End Sub

    Public Shared Function parse(Of T)(jsonString As String) As T
        Using ms = New IO.MemoryStream(Text.Encoding.UTF8.GetBytes(jsonString))
            Return DirectCast(New Json.DataContractJsonSerializer(GetType(T)).ReadObject(ms), T)
        End Using
    End Function

    Public Shared Function stringify(jsonObject As Object) As String
        Using ms = New IO.MemoryStream()
            Dim a As New Json.DataContractJsonSerializer(jsonObject.[GetType]())
            a.WriteObject(ms, jsonObject)
            Return Text.Encoding.UTF8.GetString(ms.ToArray())
        End Using
    End Function
End Class
