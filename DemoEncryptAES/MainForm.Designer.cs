
namespace DemoEncryptAES
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtBox_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AbrirPath = new System.Windows.Forms.Button();
            this.imgList_Files = new System.Windows.Forms.ImageList(this.components);
            this.listBox_Files = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEncriptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_carpetaCifrados = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_desencriptar = new System.Windows.Forms.Button();
            this.txtBox_fechaCifrado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBox_Path
            // 
            this.txtBox_Path.Location = new System.Drawing.Point(176, 23);
            this.txtBox_Path.Name = "txtBox_Path";
            this.txtBox_Path.ReadOnly = true;
            this.txtBox_Path.Size = new System.Drawing.Size(370, 27);
            this.txtBox_Path.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selecciona ruta de \r\narchivos a encriptar:";
            // 
            // btn_AbrirPath
            // 
            this.btn_AbrirPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AbrirPath.Location = new System.Drawing.Point(581, 23);
            this.btn_AbrirPath.Name = "btn_AbrirPath";
            this.btn_AbrirPath.Size = new System.Drawing.Size(128, 29);
            this.btn_AbrirPath.TabIndex = 6;
            this.btn_AbrirPath.Text = "Seleccionar";
            this.btn_AbrirPath.UseVisualStyleBackColor = true;
            this.btn_AbrirPath.Click += new System.EventHandler(this.btn_AbrirPath_Click);
            // 
            // imgList_Files
            // 
            this.imgList_Files.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList_Files.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList_Files.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listBox_Files
            // 
            this.listBox_Files.FormattingEnabled = true;
            this.listBox_Files.ItemHeight = 20;
            this.listBox_Files.Location = new System.Drawing.Point(81, 119);
            this.listBox_Files.Name = "listBox_Files";
            this.listBox_Files.Size = new System.Drawing.Size(465, 144);
            this.listBox_Files.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista de archivos que se encriptarán:";
            // 
            // btnEncriptar
            // 
            this.btnEncriptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncriptar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncriptar.Location = new System.Drawing.Point(565, 137);
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Size = new System.Drawing.Size(163, 96);
            this.btnEncriptar.TabIndex = 10;
            this.btnEncriptar.Text = "Comenzar encriptado";
            this.btnEncriptar.UseVisualStyleBackColor = true;
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptar_Click_2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cifrados realizados:";
            // 
            // listBox_carpetaCifrados
            // 
            this.listBox_carpetaCifrados.FormattingEnabled = true;
            this.listBox_carpetaCifrados.ItemHeight = 20;
            this.listBox_carpetaCifrados.Location = new System.Drawing.Point(212, 331);
            this.listBox_carpetaCifrados.Name = "listBox_carpetaCifrados";
            this.listBox_carpetaCifrados.Size = new System.Drawing.Size(334, 144);
            this.listBox_carpetaCifrados.Sorted = true;
            this.listBox_carpetaCifrados.TabIndex = 12;
            this.listBox_carpetaCifrados.SelectedIndexChanged += new System.EventHandler(this.listBox_carpetaCifrados_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(190, 480);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(412, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Selecciona una carpeta de archivos que quieras descifrar";
            // 
            // btn_desencriptar
            // 
            this.btn_desencriptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_desencriptar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_desencriptar.Location = new System.Drawing.Point(566, 356);
            this.btn_desencriptar.Name = "btn_desencriptar";
            this.btn_desencriptar.Size = new System.Drawing.Size(163, 96);
            this.btn_desencriptar.TabIndex = 14;
            this.btn_desencriptar.Text = "Comenzar desencriptado";
            this.btn_desencriptar.UseVisualStyleBackColor = true;
            this.btn_desencriptar.Click += new System.EventHandler(this.btn_desencriptar_Click);
            // 
            // txtBox_fechaCifrado
            // 
            this.txtBox_fechaCifrado.AcceptsReturn = true;
            this.txtBox_fechaCifrado.Location = new System.Drawing.Point(38, 331);
            this.txtBox_fechaCifrado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBox_fechaCifrado.Multiline = true;
            this.txtBox_fechaCifrado.Name = "txtBox_fechaCifrado";
            this.txtBox_fechaCifrado.ReadOnly = true;
            this.txtBox_fechaCifrado.Size = new System.Drawing.Size(167, 144);
            this.txtBox_fechaCifrado.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fecha del cifrado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 523);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBox_fechaCifrado);
            this.Controls.Add(this.btn_desencriptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox_carpetaCifrados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Files);
            this.Controls.Add(this.btn_AbrirPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBox_Path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Fase 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBox_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AbrirPath;
        private System.Windows.Forms.ImageList imgList_Files;
        private System.Windows.Forms.ListBox listBox_Files;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEncriptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_carpetaCifrados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_desencriptar;
        private System.Windows.Forms.TextBox txtBox_fechaCifrado;
        private System.Windows.Forms.Label label5;
    }
}

