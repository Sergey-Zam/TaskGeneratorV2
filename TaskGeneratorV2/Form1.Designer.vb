<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbTop = New System.Windows.Forms.PictureBox()
        Me.pbFront = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbVariant4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbVariant3 = New System.Windows.Forms.PictureBox()
        Me.pbVariant2 = New System.Windows.Forms.PictureBox()
        Me.pbVariant1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.pbTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pbVariant4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVariant3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVariant2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVariant1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "1. Откройте в Inventor деталь, для которой будет генерироваться задание"
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(611, 4)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(239, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Сгенерировать новое задание"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(465, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "2. Сгенерируйте задание: "
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.pbTop)
        Me.Panel1.Controls.Add(Me.pbFront)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(15, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(797, 213)
        Me.Panel1.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(396, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Вид сверху (Top)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Вид спереди (Front)"
        '
        'pbTop
        '
        Me.pbTop.BackColor = System.Drawing.Color.Silver
        Me.pbTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbTop.Location = New System.Drawing.Point(399, 28)
        Me.pbTop.Name = "pbTop"
        Me.pbTop.Size = New System.Drawing.Size(390, 160)
        Me.pbTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTop.TabIndex = 2
        Me.pbTop.TabStop = False
        '
        'pbFront
        '
        Me.pbFront.BackColor = System.Drawing.Color.Silver
        Me.pbFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFront.Location = New System.Drawing.Point(3, 28)
        Me.pbFront.Name = "pbFront"
        Me.pbFront.Size = New System.Drawing.Size(390, 160)
        Me.pbFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFront.TabIndex = 1
        Me.pbFront.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(-1, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Дано:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.Location = New System.Drawing.Point(-1, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(517, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Задание: выберите правильный вид слева (Left) на деталь"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.pbVariant4)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.pbVariant3)
        Me.Panel2.Controls.Add(Me.pbVariant2)
        Me.Panel2.Controls.Add(Me.pbVariant1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(15, 259)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1193, 406)
        Me.Panel2.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 383)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Вариант №4"
        '
        'pbVariant4
        '
        Me.pbVariant4.BackColor = System.Drawing.Color.Silver
        Me.pbVariant4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant4.Location = New System.Drawing.Point(3, 220)
        Me.pbVariant4.Name = "pbVariant4"
        Me.pbVariant4.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant4.TabIndex = 10
        Me.pbVariant4.TabStop = False
        Me.pbVariant4.Tag = "4"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(792, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Вариант №3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(396, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Вариант №2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Вариант №1"
        '
        'pbVariant3
        '
        Me.pbVariant3.BackColor = System.Drawing.Color.Silver
        Me.pbVariant3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant3.Location = New System.Drawing.Point(795, 32)
        Me.pbVariant3.Name = "pbVariant3"
        Me.pbVariant3.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant3.TabIndex = 7
        Me.pbVariant3.TabStop = False
        Me.pbVariant3.Tag = "3"
        '
        'pbVariant2
        '
        Me.pbVariant2.BackColor = System.Drawing.Color.Silver
        Me.pbVariant2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant2.Location = New System.Drawing.Point(399, 32)
        Me.pbVariant2.Name = "pbVariant2"
        Me.pbVariant2.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant2.TabIndex = 6
        Me.pbVariant2.TabStop = False
        Me.pbVariant2.Tag = "2"
        '
        'pbVariant1
        '
        Me.pbVariant1.BackColor = System.Drawing.Color.Silver
        Me.pbVariant1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant1.Location = New System.Drawing.Point(3, 32)
        Me.pbVariant1.Name = "pbVariant1"
        Me.pbVariant1.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant1.TabIndex = 5
        Me.pbVariant1.TabStop = False
        Me.pbVariant1.Tag = "1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Teal
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.btnRun)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1220, 34)
        Me.Panel3.TabIndex = 7
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(1052, 40)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(156, 23)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Экспорт задания в PDF"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1214, 671)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Task generator"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFront, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbVariant4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbVariant3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbVariant2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbVariant1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnRun As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pbTop As PictureBox
    Friend WithEvents pbFront As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pbVariant3 As PictureBox
    Friend WithEvents pbVariant2 As PictureBox
    Friend WithEvents pbVariant1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents pbVariant4 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnExport As Button
End Class
