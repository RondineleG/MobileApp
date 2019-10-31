namespace PDA.MobileApp
{
    partial class frmPrincipal
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTexto = new System.Windows.Forms.Label();
            this.txtBuscaId = new System.Windows.Forms.TextBox();
            this.btnFormulario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWcf = new System.Windows.Forms.Button();
            this.rdbWebApi = new System.Windows.Forms.RadioButton();
            this.rdbWebService = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(133, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTexto
            // 
            this.lblTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTexto.Location = new System.Drawing.Point(12, 97);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(213, 134);
            this.lblTexto.Text = " ";
            // 
            // txtBuscaId
            // 
            this.txtBuscaId.Location = new System.Drawing.Point(12, 64);
            this.txtBuscaId.Name = "txtBuscaId";
            this.txtBuscaId.Size = new System.Drawing.Size(76, 21);
            this.txtBuscaId.TabIndex = 3;
            // 
            // btnFormulario
            // 
            this.btnFormulario.Location = new System.Drawing.Point(12, 245);
            this.btnFormulario.Name = "btnFormulario";
            this.btnFormulario.Size = new System.Drawing.Size(102, 23);
            this.btnFormulario.TabIndex = 2;
            this.btnFormulario.Text = "WebApi";
            this.btnFormulario.Click += new System.EventHandler(this.btnFormulario_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.Text = "Buscar ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, -194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(133, 46);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(82, 23);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, -192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(12, -213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.Text = "Buscar ID";
            // 
            // btnWcf
            // 
            this.btnWcf.Location = new System.Drawing.Point(133, 245);
            this.btnWcf.Name = "btnWcf";
            this.btnWcf.Size = new System.Drawing.Size(92, 23);
            this.btnWcf.TabIndex = 2;
            this.btnWcf.Text = "WebService";
            this.btnWcf.Click += new System.EventHandler(this.btnWcf_Click);
            // 
            // rdbWebApi
            // 
            this.rdbWebApi.Checked = true;
            this.rdbWebApi.Location = new System.Drawing.Point(12, 20);
            this.rdbWebApi.Name = "rdbWebApi";
            this.rdbWebApi.Size = new System.Drawing.Size(100, 20);
            this.rdbWebApi.TabIndex = 6;
            this.rdbWebApi.Text = "WebApi";
            // 
            // rdbWebService
            // 
            this.rdbWebService.Location = new System.Drawing.Point(125, 20);
            this.rdbWebService.Name = "rdbWebService";
            this.rdbWebService.Size = new System.Drawing.Size(100, 20);
            this.rdbWebService.TabIndex = 6;
            this.rdbWebService.Text = "WebService";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.rdbWebService);
            this.Controls.Add(this.rdbWebApi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtBuscaId);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.btnWcf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFormulario);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPrincipal";
            this.Text = "Consulta Dados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.TextBox txtBuscaId;
        private System.Windows.Forms.Button btnFormulario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWcf;
        private System.Windows.Forms.RadioButton rdbWebApi;
        private System.Windows.Forms.RadioButton rdbWebService;

    }
}

