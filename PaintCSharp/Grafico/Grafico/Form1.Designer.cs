namespace Grafico
{
    partial class frmGrafico
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stMensagem = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.dlgSalvar = new System.Windows.Forms.SaveFileDialog();
            this.pbAreaDesenho = new System.Windows.Forms.PictureBox();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.btnPonto = new System.Windows.Forms.ToolStripButton();
            this.btnReta = new System.Windows.Forms.ToolStripButton();
            this.btnCirculo = new System.Windows.Forms.ToolStripButton();
            this.btnElipse = new System.Windows.Forms.ToolStripButton();
            this.btnRetangulo = new System.Windows.Forms.ToolStripButton();
            this.btnPolilinha = new System.Windows.Forms.ToolStripButton();
            this.btnCor = new System.Windows.Forms.ToolStripButton();
            this.btnSelecionar = new System.Windows.Forms.ToolStripButton();
            this.btnDeletar = new System.Windows.Forms.ToolStripButton();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.cdPaleta = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.stMensagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAreaDesenho)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrir,
            this.btnSalvar,
            this.btnPonto,
            this.btnReta,
            this.btnCirculo,
            this.btnElipse,
            this.btnRetangulo,
            this.btnPolilinha,
            this.btnCor,
            this.btnSelecionar,
            this.btnDeletar,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(570, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stMensagem
            // 
            this.stMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.stMensagem.Location = new System.Drawing.Point(0, 392);
            this.stMensagem.Name = "stMensagem";
            this.stMensagem.Size = new System.Drawing.Size(570, 22);
            this.stMensagem.TabIndex = 1;
            this.stMensagem.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "Mensagem:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel2.Text = "sem mensagem";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel3.Text = "Coordenada:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(21, 17);
            this.toolStripStatusLabel4.Text = "x,y";
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // pbAreaDesenho
            // 
            this.pbAreaDesenho.Location = new System.Drawing.Point(0, 28);
            this.pbAreaDesenho.Name = "pbAreaDesenho";
            this.pbAreaDesenho.Size = new System.Drawing.Size(570, 361);
            this.pbAreaDesenho.TabIndex = 2;
            this.pbAreaDesenho.TabStop = false;            
            this.pbAreaDesenho.Click += new System.EventHandler(this.pbAreaDesenho_Click);
            this.pbAreaDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAreaDesenho_Paint);
            this.pbAreaDesenho.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbAreaDesenho_MouseClick);
            this.pbAreaDesenho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbAreaDesenho_MouseMove);
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackgroundImage = global::Grafico.Properties.Resources.abrir;
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = global::Grafico.Properties.Resources.abrir;
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(23, 22);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackgroundImage = global::Grafico.Properties.Resources.salvar;
            this.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalvar.Image = global::Grafico.Properties.Resources.salvar;
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(23, 22);
            this.btnSalvar.Text = "Salvar";
            // 
            // btnPonto
            // 
            this.btnPonto.BackgroundImage = global::Grafico.Properties.Resources.ponto;
            this.btnPonto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPonto.Image = global::Grafico.Properties.Resources.ponto;
            this.btnPonto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPonto.Name = "btnPonto";
            this.btnPonto.Size = new System.Drawing.Size(23, 22);
            this.btnPonto.Text = "Ponto";
            this.btnPonto.Click += new System.EventHandler(this.btnPonto_Click);
            // 
            // btnReta
            // 
            this.btnReta.BackgroundImage = global::Grafico.Properties.Resources.reta;
            this.btnReta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReta.Image = global::Grafico.Properties.Resources.reta;
            this.btnReta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReta.Name = "btnReta";
            this.btnReta.Size = new System.Drawing.Size(23, 22);
            this.btnReta.Text = "Reta";
            this.btnReta.Click += new System.EventHandler(this.btnReta_Click);
            // 
            // btnCirculo
            // 
            this.btnCirculo.BackgroundImage = global::Grafico.Properties.Resources.circulo;
            this.btnCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCirculo.Image = global::Grafico.Properties.Resources.circulo;
            this.btnCirculo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(23, 22);
            this.btnCirculo.Text = "Circulo";
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            // 
            // btnElipse
            // 
            this.btnElipse.BackgroundImage = global::Grafico.Properties.Resources.elipse;
            this.btnElipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElipse.Image = global::Grafico.Properties.Resources.elipse2;
            this.btnElipse.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnElipse.Name = "btnElipse";
            this.btnElipse.Size = new System.Drawing.Size(23, 22);
            this.btnElipse.Text = "Elipse";
            this.btnElipse.Click += new System.EventHandler(this.btnElipse_Click);
            // 
            // btnRetangulo
            // 
            this.btnRetangulo.BackgroundImage = global::Grafico.Properties.Resources.retangulo;
            this.btnRetangulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRetangulo.Image = global::Grafico.Properties.Resources.retangulo;
            this.btnRetangulo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnRetangulo.Name = "btnRetangulo";
            this.btnRetangulo.Size = new System.Drawing.Size(23, 22);
            this.btnRetangulo.Text = "Retangulo";
            this.btnRetangulo.Click += new System.EventHandler(this.btnRetangulo_Click);
            // 
            // btnPolilinha
            // 
            this.btnPolilinha.BackgroundImage = global::Grafico.Properties.Resources.polilinha;
            this.btnPolilinha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPolilinha.Image = global::Grafico.Properties.Resources.polilinha;
            this.btnPolilinha.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnPolilinha.Name = "btnPolilinha";
            this.btnPolilinha.Size = new System.Drawing.Size(23, 22);
            this.btnPolilinha.Text = "Polilinha";
            this.btnPolilinha.Click += new System.EventHandler(this.btnPolilinha_Click);
            // 
            // btnCor
            // 
            this.btnCor.BackgroundImage = global::Grafico.Properties.Resources.paleta;
            this.btnCor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCor.Image = global::Grafico.Properties.Resources.paleta;
            this.btnCor.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(23, 22);
            this.btnCor.Text = "Cor";
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackgroundImage = global::Grafico.Properties.Resources.selecionar;
            this.btnSelecionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelecionar.Image = global::Grafico.Properties.Resources.selecionar;
            this.btnSelecionar.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(23, 22);
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackgroundImage = global::Grafico.Properties.Resources.sair;
            this.btnDeletar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeletar.Image = global::Grafico.Properties.Resources.deletar;
            this.btnDeletar.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(23, 22);
            this.btnDeletar.Text = "Deletar";
            // 
            // btnSair
            // 
            this.btnSair.BackgroundImage = global::Grafico.Properties.Resources.sair;
            this.btnSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSair.Image = global::Grafico.Properties.Resources.sair;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(23, 22);
            this.btnSair.Text = "Sair";
            // 
            // frmGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 414);
            this.Controls.Add(this.pbAreaDesenho);
            this.Controls.Add(this.stMensagem);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmGrafico";
            this.Text = "Desenho Geométrico";
            this.AutoSizeChanged += new System.EventHandler(this.frmGrafico_AutoSizeChanged);           
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.stMensagem.ResumeLayout(false);
            this.stMensagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAreaDesenho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnPonto;
        private System.Windows.Forms.ToolStripButton btnReta;
        private System.Windows.Forms.ToolStripButton btnCirculo;
        private System.Windows.Forms.ToolStripButton btnElipse;
        private System.Windows.Forms.ToolStripButton btnRetangulo;
        private System.Windows.Forms.ToolStripButton btnPolilinha;
        private System.Windows.Forms.ToolStripButton btnCor;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.StatusStrip stMensagem;
        private System.Windows.Forms.PictureBox pbAreaDesenho;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.SaveFileDialog dlgSalvar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripButton btnSelecionar;
        private System.Windows.Forms.ToolStripButton btnDeletar;
        private System.Windows.Forms.ColorDialog cdPaleta;
    }
}

