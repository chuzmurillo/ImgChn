using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgChn
{
    public partial class Link : Form
    {
        Crawler crawler;
        public Link()
        {
            InitializeComponent();
            this.txt_folder.Text = Properties.Settings.Default.direccion_descarga;
            this.FormClosing += MyForm_FormClosing;
        }

        private void btnLinkAceptar_Click(object sender, EventArgs e)
        {
            int option = 0;
            int tipo = 0;

            this.lbl_estado.Text = "Estado: Ejecutando";
            this.lbl_estado.Update();

            if (this.rd_descargarImagenes.Checked == true)
            {
                option = 2;
                if (this.ch_primeraImagen.Checked == true)
                    tipo = 1;
                else if (this.ch_ultimaImagen.Checked == true)
                    tipo = 2;
                else 
                    tipo = 0;
            }
            else if (this.rd_descargarVideos.Checked == true)
            {
                option = 1;
            }
            crawler = new Crawler(tipo, this.txt_folder.Text);
            crawler.getAllData(this.txtLink.Text, option);

            Task.WaitAll(crawler.task1, crawler.task2, crawler.task3, crawler.task4, crawler.task5, crawler.task6);
            crawler.logFile();

            this.lbl_estado.Text = "Estado: Finalizado";
            this.lbl_estado.Update();
        }

        private void btnLinkCancelar_Click(object sender, EventArgs e)
        {
            this.txtLink.Text = string.Empty;
            Hide();
            System.Environment.Exit(1);
        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            System.Environment.Exit(1);
        }
        private void rd_descargarImagenes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rd_descargarImagenes.Checked == true)
            {
                this.rd_descargarVideos.Checked = false;
                this.ch_primeraImagen.Enabled = true;
                this.ch_ultimaImagen.Enabled = true;
            }
        }

        private void rd_descargarVideos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rd_descargarVideos.Checked == true)
            {
                this.rd_descargarImagenes.Checked = false;
                this.ch_primeraImagen.Enabled = false;
                this.ch_ultimaImagen.Enabled = false;
            }

        }

        private void ch_primeraImagen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ch_primeraImagen.Checked == true)
            {
                this.ch_ultimaImagen.Checked = false;
            }
        }

        private void ch_ultimaImagen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ch_ultimaImagen.Checked == true)
            {
                this.ch_primeraImagen.Checked = false;
            }

        }

        private void btn_cambiarDireccion_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Direccion de descarga";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                this.txt_folder.Text = sSelectedPath;
                Properties.Settings.Default.direccion_descarga = sSelectedPath;
                Properties.Settings.Default.Save();
            }

        }

        private void Link_Load(object sender, EventArgs e)
        {

        }

        private void Link_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
