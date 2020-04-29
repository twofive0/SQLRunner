Option Strict On
Option Explicit On

Imports System
Imports System.Reflection

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Function getAssemblies(ByVal sender As Object, ByVal args As ResolveEventArgs) As System.Reflection.Assembly

            Dim oStream As System.IO.Stream
            Dim oStream1 As System.IO.Stream
            Dim oStream2 As System.IO.Stream
            Dim oStream3 As System.IO.Stream
            Dim oStream4 As System.IO.Stream

            Dim aName As String
            Dim exePath As String

            exePath = System.Reflection.Assembly.GetExecutingAssembly.Location()
            exePath = exePath.Replace("SQLRunner.exe", "")


            'open the executing assembly

            aName = "SQLRunner." + New AssemblyName(args.Name).Name + ".dll"

            oStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(aName)
            oStream1 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SQLRunner.sqlceme35.dll")
            oStream2 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SQLRunner.sqlcese35.dll")
            oStream3 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SQLRunner.sqlceqp35.dll")
            oStream4 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SQLRunner.sqlceer35EN.dll")


            Dim buffer1(CInt(oStream1.Length)) As Byte
            oStream.Read(buffer1, 0, buffer1.Length)
            Assembly.Load(buffer1)
            'System.IO.File.WriteAllBytes(exePath + "sqlceme35.dll", buffer1)
            Dim buffer2(CInt(oStream2.Length)) As Byte
            oStream.Read(buffer2, 0, buffer2.Length)
            Assembly.Load(buffer2)
            'System.IO.File.WriteAllBytes(exePath + "sqlcese35.dll", buffer2)
            Dim buffer3(CInt(oStream3.Length)) As Byte
            oStream.Read(buffer3, 0, buffer3.Length)
            Assembly.Load(buffer3)
            'System.IO.File.WriteAllBytes(exePath + "sqlceqp35.dll", buffer3)
            Dim buffer4(CInt(oStream4.Length)) As Byte
            oStream.Read(buffer4, 0, buffer4.Length)
            Assembly.Load(buffer4)
            'System.IO.File.WriteAllBytes(exePath + "sqlceer35EN.dll", buffer4)

            Dim buffer(CInt(oStream.Length)) As Byte
            oStream.Read(buffer, 0, buffer.Length)
            Return Assembly.Load(buffer)

        End Function

        Public Sub start_handler() Handles MyBase.Startup

            Dim currentDomain As AppDomain = AppDomain.CurrentDomain
            AddHandler currentDomain.AssemblyResolve, AddressOf getAssemblies

        End Sub

    End Class


End Namespace

