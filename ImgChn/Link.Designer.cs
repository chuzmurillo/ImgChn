namespace ImgChn
{
    partial class Link
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lblLink = new System.Windows.Forms.Label();
            this.btnLinkAceptar = new System.Windows.Forms.Button();
            this.btnLinkCancelar = new System.Windows.Forms.Button();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.rd_descargarImagenes = new System.Windows.Forms.RadioButton();
            this.rd_descargarVideos = new System.Windows.Forms.RadioButton();
            this.ch_primeraImagen = new System.Windows.Forms.CheckBox();
            this.ch_ultimaImagen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.btn_cambiarDireccion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(14, 153);
            this.txtLink.Margin = new System.Windows.Forms.Padding(2);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(486, 20);
            this.txtLink.TabIndex = 0;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.Location = new System.Drawing.Point(11, 123);
            this.lblLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(290, 18);
            this.lblLink.TabIndex = 1;
            this.lblLink.Text = "Copie y pegue el link en el siguiente cuadro";
            // 
            // btnLinkAceptar
            // 
            this.btnLinkAceptar.Location = new System.Drawing.Point(401, 198);
            this.btnLinkAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLinkAceptar.Name = "btnLinkAceptar";
            this.btnLinkAceptar.Size = new System.Drawing.Size(99, 23);
            this.btnLinkAceptar.TabIndex = 2;
            this.btnLinkAceptar.Text = "Obtener Archivos";
            this.btnLinkAceptar.UseVisualStyleBackColor = true;
            this.btnLinkAceptar.Click += new System.EventHandler(this.btnLinkAceptar_Click);
            // 
            // btnLinkCancelar
            // 
            this.btnLinkCancelar.Location = new System.Drawing.Point(401, 224);
            this.btnLinkCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLinkCancelar.Name = "btnLinkCancelar";
            this.btnLinkCancelar.Size = new System.Drawing.Size(99, 23);
            this.btnLinkCancelar.TabIndex = 3;
            this.btnLinkCancelar.Text = "Cancelar";
            this.btnLinkCancelar.UseVisualStyleBackColor = true;
            this.btnLinkCancelar.Click += new System.EventHandler(this.btnLinkCancelar_Click);
            // 
            // lbl_estado
            // 
            this.lbl_estado.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.Location = new System.Drawing.Point(10, 262);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(490, 23);
            this.lbl_estado.TabIndex = 12;
            this.lbl_estado.Text = "Estado: No iniciado";
            // 
            // rd_descargarImagenes
            // 
            this.rd_descargarImagenes.AutoSize = true;
            this.rd_descargarImagenes.Checked = true;
            this.rd_descargarImagenes.Location = new System.Drawing.Point(14, 178);
            this.rd_descargarImagenes.Name = "rd_descargarImagenes";
            this.rd_descargarImagenes.Size = new System.Drawing.Size(123, 17);
            this.rd_descargarImagenes.TabIndex = 5;
            this.rd_descargarImagenes.TabStop = true;
            this.rd_descargarImagenes.Text = "Descargar Imagenes";
            this.rd_descargarImagenes.UseVisualStyleBackColor = true;
            this.rd_descargarImagenes.CheckedChanged += new System.EventHandler(this.rd_descargarImagenes_CheckedChanged);
            // 
            // rd_descargarVideos
            // 
            this.rd_descargarVideos.AutoSize = true;
            this.rd_descargarVideos.Location = new System.Drawing.Point(143, 178);
            this.rd_descargarVideos.Name = "rd_descargarVideos";
            this.rd_descargarVideos.Size = new System.Drawing.Size(109, 17);
            this.rd_descargarVideos.TabIndex = 6;
            this.rd_descargarVideos.Text = "Descargar Videos";
            this.rd_descargarVideos.UseVisualStyleBackColor = true;
            this.rd_descargarVideos.CheckedChanged += new System.EventHandler(this.rd_descargarVideos_CheckedChanged);
            // 
            // ch_primeraImagen
            // 
            this.ch_primeraImagen.AutoSize = true;
            this.ch_primeraImagen.Checked = true;
            this.ch_primeraImagen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_primeraImagen.Location = new System.Drawing.Point(14, 201);
            this.ch_primeraImagen.Name = "ch_primeraImagen";
            this.ch_primeraImagen.Size = new System.Drawing.Size(99, 17);
            this.ch_primeraImagen.TabIndex = 7;
            this.ch_primeraImagen.Text = "Primera Imagen";
            this.ch_primeraImagen.UseVisualStyleBackColor = true;
            this.ch_primeraImagen.CheckedChanged += new System.EventHandler(this.ch_primeraImagen_CheckedChanged);
            // 
            // ch_ultimaImagen
            // 
            this.ch_ultimaImagen.AutoSize = true;
            this.ch_ultimaImagen.Location = new System.Drawing.Point(14, 224);
            this.ch_ultimaImagen.Name = "ch_ultimaImagen";
            this.ch_ultimaImagen.Size = new System.Drawing.Size(93, 17);
            this.ch_ultimaImagen.TabIndex = 8;
            this.ch_ultimaImagen.Text = "Ultima Imagen";
            this.ch_ultimaImagen.UseVisualStyleBackColor = true;
            this.ch_ultimaImagen.CheckedChanged += new System.EventHandler(this.ch_ultimaImagen_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Folder de descarga";
            // 
            // txt_folder
            // 
            this.txt_folder.Enabled = false;
            this.txt_folder.Location = new System.Drawing.Point(14, 52);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(486, 20);
            this.txt_folder.TabIndex = 10;
            // 
            // btn_cambiarDireccion
            // 
            this.btn_cambiarDireccion.Location = new System.Drawing.Point(401, 78);
            this.btn_cambiarDireccion.Name = "btn_cambiarDireccion";
            this.btn_cambiarDireccion.Size = new System.Drawing.Size(99, 23);
            this.btn_cambiarDireccion.TabIndex = 11;
            this.btn_cambiarDireccion.Text = "Cambiar direccion";
            this.btn_cambiarDireccion.UseVisualStyleBackColor = true;
            this.btn_cambiarDireccion.Click += new System.EventHandler(this.btn_cambiarDireccion_Click);
            // 
            // Link
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 294);
            this.Controls.Add(this.btn_cambiarDireccion);
            this.Controls.Add(this.txt_folder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ch_ultimaImagen);
            this.Controls.Add(this.ch_primeraImagen);
            this.Controls.Add(this.rd_descargarVideos);
            this.Controls.Add(this.rd_descargarImagenes);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.btnLinkCancelar);
            this.Controls.Add(this.btnLinkAceptar);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.txtLink);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Link";
            this.Text = "Link";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Link_FormClosed);
            this.Load += new System.EventHandler(this.Link_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label lblLink;
        public System.Windows.Forms.Button btnLinkAceptar;
        public System.Windows.Forms.Button btnLinkCancelar;
        public System.Windows.Forms.Label lbl_estado;
        public System.Windows.Forms.RadioButton rd_descargarImagenes;
        public System.Windows.Forms.RadioButton rd_descargarVideos;
        public System.Windows.Forms.CheckBox ch_primeraImagen;
        public System.Windows.Forms.CheckBox ch_ultimaImagen;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Button btn_cambiarDireccion;
    }
}