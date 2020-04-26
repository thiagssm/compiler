<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalise
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
        Me.txtAnalisar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRetornoToken = New System.Windows.Forms.TextBox()
        Me.btnAnalisar = New System.Windows.Forms.Button()
        Me.txtRetornoTabela = New System.Windows.Forms.TextBox()
        Me.Arquivos = New System.Windows.Forms.OpenFileDialog()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnGerarToken = New System.Windows.Forms.Button()
        Me.btnGerarTabela = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtAnalisar
        '
        Me.txtAnalisar.Location = New System.Drawing.Point(25, 25)
        Me.txtAnalisar.Multiline = True
        Me.txtAnalisar.Name = "txtAnalisar"
        Me.txtAnalisar.Size = New System.Drawing.Size(614, 100)
        Me.txtAnalisar.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Digite o que deseja analisar"
        '
        'txtRetornoToken
        '
        Me.txtRetornoToken.Enabled = False
        Me.txtRetornoToken.Location = New System.Drawing.Point(25, 156)
        Me.txtRetornoToken.Multiline = True
        Me.txtRetornoToken.Name = "txtRetornoToken"
        Me.txtRetornoToken.Size = New System.Drawing.Size(319, 253)
        Me.txtRetornoToken.TabIndex = 3
        '
        'btnAnalisar
        '
        Me.btnAnalisar.Location = New System.Drawing.Point(685, 102)
        Me.btnAnalisar.Name = "btnAnalisar"
        Me.btnAnalisar.Size = New System.Drawing.Size(75, 23)
        Me.btnAnalisar.TabIndex = 4
        Me.btnAnalisar.Text = "Analisar"
        Me.btnAnalisar.UseVisualStyleBackColor = True
        '
        'txtRetornoTabela
        '
        Me.txtRetornoTabela.Enabled = False
        Me.txtRetornoTabela.Location = New System.Drawing.Point(448, 156)
        Me.txtRetornoTabela.Multiline = True
        Me.txtRetornoTabela.Name = "txtRetornoTabela"
        Me.txtRetornoTabela.Size = New System.Drawing.Size(312, 253)
        Me.txtRetornoTabela.TabIndex = 5
        '
        'Arquivos
        '
        Me.Arquivos.FileName = "ofdInput"
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(685, 25)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 6
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnGerarToken
        '
        Me.btnGerarToken.Location = New System.Drawing.Point(99, 415)
        Me.btnGerarToken.Name = "btnGerarToken"
        Me.btnGerarToken.Size = New System.Drawing.Size(138, 23)
        Me.btnGerarToken.TabIndex = 7
        Me.btnGerarToken.Text = "Gerar Tokens"
        Me.btnGerarToken.UseVisualStyleBackColor = True
        '
        'btnGerarTabela
        '
        Me.btnGerarTabela.Location = New System.Drawing.Point(528, 415)
        Me.btnGerarTabela.Name = "btnGerarTabela"
        Me.btnGerarTabela.Size = New System.Drawing.Size(143, 23)
        Me.btnGerarTabela.TabIndex = 8
        Me.btnGerarTabela.Text = "Gerar Tabela"
        Me.btnGerarTabela.UseVisualStyleBackColor = True
        '
        'FormAnalise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGerarTabela)
        Me.Controls.Add(Me.btnGerarToken)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.txtRetornoTabela)
        Me.Controls.Add(Me.btnAnalisar)
        Me.Controls.Add(Me.txtRetornoToken)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAnalisar)
        Me.Name = "FormAnalise"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAnalisar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRetornoToken As TextBox
    Friend WithEvents btnAnalisar As Button
    Friend WithEvents txtRetornoTabela As TextBox
    Friend WithEvents Arquivos As OpenFileDialog
    Friend WithEvents btnUpload As Button
    Friend WithEvents btnGerarToken As Button
    Friend WithEvents btnGerarTabela As Button
End Class
