namespace CitasMedicas
{
    partial class CitasMedicasAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CitasMedicasAdministrador));
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCitas = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.msPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.citasToolStripMenuItem});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(1182, 30);
            this.msPrincipal.TabIndex = 0;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuario,
            this.modificarUsuarioToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // crearUsuario
            // 
            this.crearUsuario.Name = "crearUsuario";
            this.crearUsuario.Size = new System.Drawing.Size(224, 26);
            this.crearUsuario.Text = "Crear Usuario";
            this.crearUsuario.Click += new System.EventHandler(this.ventanaUsuario);
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.modificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.modificarUser);
            // 
            // citasToolStripMenuItem
            // 
            this.citasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCitas});
            this.citasToolStripMenuItem.Name = "citasToolStripMenuItem";
            this.citasToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.citasToolStripMenuItem.Text = "Citas";
            // 
            // verCitas
            // 
            this.verCitas.Name = "verCitas";
            this.verCitas.Size = new System.Drawing.Size(224, 26);
            this.verCitas.Text = "Ver citas";
            this.verCitas.Click += new System.EventHandler(this.verCitas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1182, 695);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CitasMedicasAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 721);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.msPrincipal;
            this.MaximizeBox = false;
            this.Name = "CitasMedicasAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CitasMedicasAdministrador";
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearUsuario;
        private System.Windows.Forms.ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCitas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}