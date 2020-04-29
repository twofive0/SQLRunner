Public Class frmHelp

    Private Sub frmHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oStream As System.IO.Stream
        Dim sReader As System.IO.StreamReader
        Dim oAssembly As System.Reflection.Assembly

        'open the executing assembly

        oAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath)

        'create stream for image (icon) in assembly

        oStream = oAssembly.GetManifestResourceStream("SQLRunner.SQLRunnerManual.rtf")

        sReader = New System.IO.StreamReader(oStream)

        Me.RichTextBox1.Rtf = sReader.ReadToEnd

    End Sub
End Class