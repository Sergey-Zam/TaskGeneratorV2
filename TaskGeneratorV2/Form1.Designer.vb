<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.lblView = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbVariant4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbVariant3 = New System.Windows.Forms.PictureBox()
        Me.pbVariant2 = New System.Windows.Forms.PictureBox()
        Me.pbVariant1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbView = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudMinChangeValue = New System.Windows.Forms.NumericUpDown()
        Me.nudChangeStep = New System.Windows.Forms.NumericUpDown()
        Me.nudMaxChangeValue = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbShell = New System.Windows.Forms.RadioButton()
        Me.rbHole = New System.Windows.Forms.RadioButton()
        Me.rbFillet = New System.Windows.Forms.RadioButton()
        Me.rbChamfer = New System.Windows.Forms.RadioButton()
        Me.rbExtrude = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rbEmboss = New System.Windows.Forms.RadioButton()
        Me.rbRevolve = New System.Windows.Forms.RadioButton()
        Me.rbThicken = New System.Windows.Forms.RadioButton()
        Me.rbRib = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.pbTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFront, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pbVariant4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVariant3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVariant2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVariant1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.nudMinChangeValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudChangeStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxChangeValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
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
        Me.btnRun.Location = New System.Drawing.Point(388, 4)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(220, 64)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Сгенерировать новое задание"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "3. Сгенерируйте задание "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.pbTop)
        Me.Panel1.Controls.Add(Me.pbFront)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(12, 105)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 406)
        Me.Panel1.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 385)
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
        Me.pbTop.BackColor = System.Drawing.Color.Gray
        Me.pbTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbTop.Location = New System.Drawing.Point(3, 222)
        Me.pbTop.Name = "pbTop"
        Me.pbTop.Size = New System.Drawing.Size(390, 160)
        Me.pbTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTop.TabIndex = 2
        Me.pbTop.TabStop = False
        '
        'pbFront
        '
        Me.pbFront.BackColor = System.Drawing.Color.Gray
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
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Даны виды:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.Location = New System.Drawing.Point(3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(413, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Задание: выберите правильный вид на деталь"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblView)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.pbVariant4)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.pbVariant3)
        Me.Panel2.Controls.Add(Me.pbVariant2)
        Me.Panel2.Controls.Add(Me.pbVariant1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(419, 105)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(797, 406)
        Me.Panel2.TabIndex = 6
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblView.ForeColor = System.Drawing.Color.Teal
        Me.lblView.Location = New System.Drawing.Point(411, 5)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(108, 20)
        Me.lblView.TabIndex = 12
        Me.lblView.Text = "слева (Left)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(399, 385)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Вариант №4"
        '
        'pbVariant4
        '
        Me.pbVariant4.BackColor = System.Drawing.Color.Gray
        Me.pbVariant4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant4.Location = New System.Drawing.Point(399, 222)
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
        Me.Label9.Location = New System.Drawing.Point(0, 385)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Вариант №3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(399, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Вариант №2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Вариант №1"
        '
        'pbVariant3
        '
        Me.pbVariant3.BackColor = System.Drawing.Color.Gray
        Me.pbVariant3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant3.Location = New System.Drawing.Point(3, 222)
        Me.pbVariant3.Name = "pbVariant3"
        Me.pbVariant3.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant3.TabIndex = 7
        Me.pbVariant3.TabStop = False
        Me.pbVariant3.Tag = "3"
        '
        'pbVariant2
        '
        Me.pbVariant2.BackColor = System.Drawing.Color.Gray
        Me.pbVariant2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant2.Location = New System.Drawing.Point(399, 28)
        Me.pbVariant2.Name = "pbVariant2"
        Me.pbVariant2.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant2.TabIndex = 6
        Me.pbVariant2.TabStop = False
        Me.pbVariant2.Tag = "2"
        '
        'pbVariant1
        '
        Me.pbVariant1.BackColor = System.Drawing.Color.Gray
        Me.pbVariant1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbVariant1.Location = New System.Drawing.Point(3, 28)
        Me.pbVariant1.Name = "pbVariant1"
        Me.pbVariant1.Size = New System.Drawing.Size(390, 160)
        Me.pbVariant1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbVariant1.TabIndex = 5
        Me.pbVariant1.TabStop = False
        Me.pbVariant1.Tag = "1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(412, 98)
        Me.Panel3.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(12, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "4. Экспортируйте задание"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(12, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(270, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "2. При необходимости выберите нужные настройки"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(452, 70)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(156, 23)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Экспорт задания в PDF"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.cbView)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.nudMinChangeValue)
        Me.Panel4.Controls.Add(Me.nudChangeStep)
        Me.Panel4.Controls.Add(Me.nudMaxChangeValue)
        Me.Panel4.Controls.Add(Me.btnExport)
        Me.Panel4.Controls.Add(Me.btnRun)
        Me.Panel4.Location = New System.Drawing.Point(614, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(620, 98)
        Me.Panel4.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(147, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Сторона правильного вида:"
        '
        'cbView
        '
        Me.cbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbView.FormattingEnabled = True
        Me.cbView.Items.AddRange(New Object() {"слева (Left)", "справа (Right)", "сзади (Back)", "снизу (Bottom)"})
        Me.cbView.Location = New System.Drawing.Point(154, 69)
        Me.cbView.Name = "cbView"
        Me.cbView.Size = New System.Drawing.Size(223, 21)
        Me.cbView.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(54, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(323, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Шаг изменения параметра (мм) (не рекомендуется изменять)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(54, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(226, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Максимальное изменение параметра (мм)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(54, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(220, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Минимальное изменение параметра (мм)"
        '
        'nudMinChangeValue
        '
        Me.nudMinChangeValue.Location = New System.Drawing.Point(6, 4)
        Me.nudMinChangeValue.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudMinChangeValue.Name = "nudMinChangeValue"
        Me.nudMinChangeValue.Size = New System.Drawing.Size(45, 20)
        Me.nudMinChangeValue.TabIndex = 8
        Me.nudMinChangeValue.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'nudChangeStep
        '
        Me.nudChangeStep.Location = New System.Drawing.Point(6, 48)
        Me.nudChangeStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudChangeStep.Name = "nudChangeStep"
        Me.nudChangeStep.Size = New System.Drawing.Size(45, 20)
        Me.nudChangeStep.TabIndex = 7
        Me.nudChangeStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudMaxChangeValue
        '
        Me.nudMaxChangeValue.Location = New System.Drawing.Point(6, 26)
        Me.nudMaxChangeValue.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMaxChangeValue.Name = "nudMaxChangeValue"
        Me.nudMaxChangeValue.Size = New System.Drawing.Size(45, 20)
        Me.nudMaxChangeValue.TabIndex = 6
        Me.nudMaxChangeValue.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbRib)
        Me.GroupBox1.Controls.Add(Me.rbThicken)
        Me.GroupBox1.Controls.Add(Me.rbRevolve)
        Me.GroupBox1.Controls.Add(Me.rbEmboss)
        Me.GroupBox1.Controls.Add(Me.rbShell)
        Me.GroupBox1.Controls.Add(Me.rbHole)
        Me.GroupBox1.Controls.Add(Me.rbFillet)
        Me.GroupBox1.Controls.Add(Me.rbChamfer)
        Me.GroupBox1.Controls.Add(Me.rbExtrude)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(172, 231)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Какой тип feature будет изменён"
        '
        'rbShell
        '
        Me.rbShell.AutoSize = True
        Me.rbShell.Location = New System.Drawing.Point(6, 120)
        Me.rbShell.Name = "rbShell"
        Me.rbShell.Size = New System.Drawing.Size(92, 17)
        Me.rbShell.TabIndex = 4
        Me.rbShell.Text = "Shell (корпус)"
        Me.rbShell.UseVisualStyleBackColor = True
        '
        'rbHole
        '
        Me.rbHole.AutoSize = True
        Me.rbHole.Location = New System.Drawing.Point(6, 99)
        Me.rbHole.Name = "rbHole"
        Me.rbHole.Size = New System.Drawing.Size(108, 17)
        Me.rbHole.TabIndex = 3
        Me.rbHole.Text = "Hole (отверстие)"
        Me.rbHole.UseVisualStyleBackColor = True
        '
        'rbFillet
        '
        Me.rbFillet.AutoSize = True
        Me.rbFillet.Location = New System.Drawing.Point(6, 78)
        Me.rbFillet.Name = "rbFillet"
        Me.rbFillet.Size = New System.Drawing.Size(93, 17)
        Me.rbFillet.TabIndex = 2
        Me.rbFillet.Text = "Fillet (кромка)"
        Me.rbFillet.UseVisualStyleBackColor = True
        '
        'rbChamfer
        '
        Me.rbChamfer.AutoSize = True
        Me.rbChamfer.Location = New System.Drawing.Point(6, 56)
        Me.rbChamfer.Name = "rbChamfer"
        Me.rbChamfer.Size = New System.Drawing.Size(105, 17)
        Me.rbChamfer.TabIndex = 1
        Me.rbChamfer.Text = "Chamfer (фаска)"
        Me.rbChamfer.UseVisualStyleBackColor = True
        '
        'rbExtrude
        '
        Me.rbExtrude.AutoSize = True
        Me.rbExtrude.Checked = True
        Me.rbExtrude.Location = New System.Drawing.Point(6, 34)
        Me.rbExtrude.Name = "rbExtrude"
        Me.rbExtrude.Size = New System.Drawing.Size(144, 17)
        Me.rbExtrude.TabIndex = 0
        Me.rbExtrude.TabStop = True
        Me.rbExtrude.Text = "Extrude (выдавливание)"
        Me.rbExtrude.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.AutoScroll = True
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Location = New System.Drawing.Point(412, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(202, 98)
        Me.Panel5.TabIndex = 9
        '
        'rbEmboss
        '
        Me.rbEmboss.AutoSize = True
        Me.rbEmboss.Location = New System.Drawing.Point(6, 141)
        Me.rbEmboss.Name = "rbEmboss"
        Me.rbEmboss.Size = New System.Drawing.Size(117, 17)
        Me.rbEmboss.TabIndex = 5
        Me.rbEmboss.Text = "Emboss (чеканить)"
        Me.rbEmboss.UseVisualStyleBackColor = True
        '
        'rbRevolve
        '
        Me.rbRevolve.AutoSize = True
        Me.rbRevolve.Location = New System.Drawing.Point(6, 162)
        Me.rbRevolve.Name = "rbRevolve"
        Me.rbRevolve.Size = New System.Drawing.Size(118, 17)
        Me.rbRevolve.TabIndex = 6
        Me.rbRevolve.Text = "Revolve (вращать)"
        Me.rbRevolve.UseVisualStyleBackColor = True
        '
        'rbThicken
        '
        Me.rbThicken.AutoSize = True
        Me.rbThicken.Location = New System.Drawing.Point(6, 183)
        Me.rbThicken.Name = "rbThicken"
        Me.rbThicken.Size = New System.Drawing.Size(115, 17)
        Me.rbThicken.TabIndex = 7
        Me.rbThicken.Text = "Thicken (сгущать)"
        Me.rbThicken.UseVisualStyleBackColor = True
        '
        'rbRib
        '
        Me.rbRib.AutoSize = True
        Me.rbRib.Location = New System.Drawing.Point(6, 204)
        Me.rbRib.Name = "rbRib"
        Me.rbRib.Size = New System.Drawing.Size(80, 17)
        Me.rbRib.TabIndex = 8
        Me.rbRib.Text = "Rib (ребро)"
        Me.rbRib.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1228, 521)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
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
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.nudMinChangeValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudChangeStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxChangeValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
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
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbChamfer As RadioButton
    Friend WithEvents rbExtrude As RadioButton
    Friend WithEvents nudChangeStep As NumericUpDown
    Friend WithEvents nudMaxChangeValue As NumericUpDown
    Friend WithEvents nudMinChangeValue As NumericUpDown
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents rbFillet As RadioButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents rbHole As RadioButton
    Friend WithEvents rbShell As RadioButton
    Friend WithEvents lblView As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cbView As ComboBox
    Friend WithEvents rbEmboss As RadioButton
    Friend WithEvents rbRevolve As RadioButton
    Friend WithEvents rbThicken As RadioButton
    Friend WithEvents rbRib As RadioButton
End Class
