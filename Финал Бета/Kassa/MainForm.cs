using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Kassa.Bl;

namespace Kassa
{
    public interface IForm
    {
        int OrderOne { get; }
        int OrderTwo { get; }
        void InsertRows(int nomer, string name, int colMest, DateTime d);
        void ClearGridView();
        List<Train> GetDataFromDataGridView();
        event EventHandler SaveButClick;
        event EventHandler LoadButtonClick;
        event EventHandler OrderATicket;
        event EventHandler OrderTwoATicket;
        string FilePath { get; }

        void SetCounterTrains(int count);
        

        Dictionary<int, string> SaveData();
    }

    public class MainForm : Form, IForm
    {
        public int OrderOne { get { return int.Parse(textBox1.Text); }}
        public int OrderTwo { get { return int.Parse(textBox2.Text); } }

        private string fpath;
        public MainForm()
        {
            InitializeComponent();
            bt_Load.Click += bt_Load_Click;
            bt_Save.Click += bt_Save_Click;
            bt_Order.Click += bt_Order_Click;
            order2bt.Click += order2bt_Click;

        }

        void order2bt_Click(object sender, EventArgs e)
        {
            if (OrderTwoATicket != null)
                OrderTwoATicket(this, e);
        }

        void bt_Order_Click(object sender, EventArgs e)
        {
            if (OrderATicket != null)
            {
                OrderATicket(this, e);
            }
        }

        void bt_Save_Click(object sender, EventArgs e)
        {
            if (SaveButClick != null)
                SaveButClick(this, e);
        }

        private void bt_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Выберите файл",
                RestoreDirectory = true,
                Filter = @"Файлы данных .dat|*.dat|All Files|*.*",
                FilterIndex = 0
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                fpath = open.FileName;
                LoadButtonClick(this, e);
            }
        }


        public void InsertRows(int  nomer, string name, int colMest, DateTime d)
        {
            dataGridView2.Rows.Add(nomer, name, colMest, d);
        }

        public void ClearGridView()
        {
            dataGridView2.Rows.Clear();
        }

        public List<Train> GetDataFromDataGridView()
        {
            List<Train>l=new List<Train>();
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                int number =int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                string name = dataGridView2.Rows[i].Cells[1].Value.ToString();
                int mesta = int.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());
                DateTime dt = DateTime.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                l.Add(new Train(number,dt,mesta,name));
            }
            return l;
        }

        public event EventHandler SaveButClick;
        public event EventHandler LoadButtonClick;
        public event EventHandler OrderATicket;
        public event EventHandler OrderTwoATicket;


        public string FilePath { get { return fpath; } }

        public void SetCounterTrains(int count)
        {
            toolStripStatusLabel4.Text = count.ToString();
        }

        public Dictionary<int, string> SaveData()
        {
            Dictionary<int, string> dc=new Dictionary<int, string>();
            for (int i = 0; i < dataGridView2.RowCount-1; i++)
            {
                dc.Add(int.Parse( dataGridView2.Rows[i].Cells[0].Value.ToString()), dataGridView2.Rows[i].Cells[1].Value.ToString());
            }
            return dc;
        }


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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Traint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazvanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Load = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt_Save = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Order = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.order2bt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Traint,
            this.Nazvanie,
            this._Count,
            this.Column1});
            this.dataGridView2.Location = new System.Drawing.Point(12, 26);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(602, 318);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowValidated);
            // 
            // Traint
            // 
            this.Traint.HeaderText = "Поезд №";
            this.Traint.MaxInputLength = 10;
            this.Traint.MinimumWidth = 60;
            this.Traint.Name = "Traint";
            // 
            // Nazvanie
            // 
            this.Nazvanie.HeaderText = "Название";
            this.Nazvanie.Name = "Nazvanie";
            // 
            // _Count
            // 
            this._Count.HeaderText = "Количество мест";
            this._Count.Name = "_Count";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Дата отправления";
            this.Column1.Name = "Column1";
            // 
            // bt_Load
            // 
            this.bt_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Load.Location = new System.Drawing.Point(620, 55);
            this.bt_Load.Name = "bt_Load";
            this.bt_Load.Size = new System.Drawing.Size(75, 23);
            this.bt_Load.TabIndex = 6;
            this.bt_Load.Text = "Load";
            this.bt_Load.UseVisualStyleBackColor = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel1.Text = "Количество поездов:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel2.Text = "#";
            // 
            // bt_Save
            // 
            this.bt_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Save.Location = new System.Drawing.Point(620, 26);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 23);
            this.bt_Save.TabIndex = 8;
            this.bt_Save.Text = "Save ";
            this.bt_Save.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel3.Text = "Количество поездов:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel4.Text = "#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(35, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Кассир 1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 539);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "№поезда";
            // 
            // bt_Order
            // 
            this.bt_Order.Location = new System.Drawing.Point(179, 539);
            this.bt_Order.Name = "bt_Order";
            this.bt_Order.Size = new System.Drawing.Size(52, 23);
            this.bt_Order.TabIndex = 14;
            this.bt_Order.Text = "Order";
            this.bt_Order.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::Kassa.Properties.Resources.kasurwa;
            this.pictureBox1.Location = new System.Drawing.Point(12, 389);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Kassa.Properties.Resources.kasurwa2;
            this.pictureBox2.Location = new System.Drawing.Point(342, 389);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 138);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "№поезда";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(399, 541);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // order2bt
            // 
            this.order2bt.Location = new System.Drawing.Point(514, 539);
            this.order2bt.Name = "order2bt";
            this.order2bt.Size = new System.Drawing.Size(52, 23);
            this.order2bt.TabIndex = 18;
            this.order2bt.Text = "Order";
            this.order2bt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(338, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Типичный кассир";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 677);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.order2bt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.bt_Order);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.bt_Load);
            this.Controls.Add(this.dataGridView2);
            this.Name = "MainForm";
            this.Text = "  MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        #region controls
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button bt_Load;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Traint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazvanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Order;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button order2bt;
        private System.Windows.Forms.Label label4;
        #endregion

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetCounterTrains(dataGridView2.RowCount-1);
        }
    }
}
