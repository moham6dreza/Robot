namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    partial class Mainform
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.astarbt = new System.Windows.Forms.Button();
            this.greedybt = new System.Windows.Forms.Button();
            this.ucsbt = new System.Windows.Forms.Button();
            this.bfsbt = new System.Windows.Forms.Button();
            this.dfsbt = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bmcosttb = new System.Windows.Forms.TextBox();
            this.dmcosttb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.euclideanchb = new System.Windows.Forms.CheckBox();
            this.manhattanchb = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathlentb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.goaltesttb = new System.Windows.Forms.TextBox();
            this.expansiontb = new System.Windows.Forms.TextBox();
            this.closebt = new System.Windows.Forms.Button();
            this.cltb = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.astarbt);
            this.groupBox4.Controls.Add(this.greedybt);
            this.groupBox4.Controls.Add(this.ucsbt);
            this.groupBox4.Controls.Add(this.bfsbt);
            this.groupBox4.Controls.Add(this.dfsbt);
            this.groupBox4.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox4.Location = new System.Drawing.Point(1041, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 225);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Strategy Selection";
            // 
            // astarbt
            // 
            this.astarbt.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.astarbt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.astarbt.Location = new System.Drawing.Point(43, 74);
            this.astarbt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.astarbt.Name = "astarbt";
            this.astarbt.Size = new System.Drawing.Size(87, 26);
            this.astarbt.TabIndex = 12;
            this.astarbt.Text = "ASTAR";
            this.astarbt.UseVisualStyleBackColor = true;
            this.astarbt.Click += new System.EventHandler(this.Astarbt_Click);
            // 
            // greedybt
            // 
            this.greedybt.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.greedybt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.greedybt.Location = new System.Drawing.Point(43, 40);
            this.greedybt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.greedybt.Name = "greedybt";
            this.greedybt.Size = new System.Drawing.Size(87, 26);
            this.greedybt.TabIndex = 13;
            this.greedybt.Text = "GREEDY";
            this.greedybt.UseVisualStyleBackColor = true;
            this.greedybt.Click += new System.EventHandler(this.Greedybt_Click);
            // 
            // ucsbt
            // 
            this.ucsbt.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ucsbt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ucsbt.Location = new System.Drawing.Point(43, 108);
            this.ucsbt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucsbt.Name = "ucsbt";
            this.ucsbt.Size = new System.Drawing.Size(87, 26);
            this.ucsbt.TabIndex = 14;
            this.ucsbt.Text = "UCS";
            this.ucsbt.UseVisualStyleBackColor = true;
            this.ucsbt.Click += new System.EventHandler(this.Ucsbt_Click);
            // 
            // bfsbt
            // 
            this.bfsbt.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bfsbt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bfsbt.Location = new System.Drawing.Point(43, 142);
            this.bfsbt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bfsbt.Name = "bfsbt";
            this.bfsbt.Size = new System.Drawing.Size(87, 26);
            this.bfsbt.TabIndex = 15;
            this.bfsbt.Text = "BFS";
            this.bfsbt.UseVisualStyleBackColor = true;
            this.bfsbt.Click += new System.EventHandler(this.Bfsbt_Click);
            // 
            // dfsbt
            // 
            this.dfsbt.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.dfsbt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dfsbt.Location = new System.Drawing.Point(43, 176);
            this.dfsbt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dfsbt.Name = "dfsbt";
            this.dfsbt.Size = new System.Drawing.Size(87, 26);
            this.dfsbt.TabIndex = 16;
            this.dfsbt.Text = "DFS";
            this.dfsbt.UseVisualStyleBackColor = true;
            this.dfsbt.Click += new System.EventHandler(this.Dfsbt_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(918, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "Coordinates";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(518, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 27);
            this.label6.TabIndex = 34;
            this.label6.Text = "Maze Map";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.bmcosttb);
            this.groupBox3.Controls.Add(this.dmcosttb);
            this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox3.Location = new System.Drawing.Point(35, 346);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 162);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cost Selection";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(15, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Basic Movement Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(15, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Diagnoal Moavement Cost ";
            // 
            // bmcosttb
            // 
            this.bmcosttb.Location = new System.Drawing.Point(64, 62);
            this.bmcosttb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bmcosttb.Name = "bmcosttb";
            this.bmcosttb.Size = new System.Drawing.Size(116, 26);
            this.bmcosttb.TabIndex = 10;
            // 
            // dmcosttb
            // 
            this.dmcosttb.Location = new System.Drawing.Point(64, 120);
            this.dmcosttb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dmcosttb.Name = "dmcosttb";
            this.dmcosttb.Size = new System.Drawing.Size(116, 26);
            this.dmcosttb.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox2.Controls.Add(this.euclideanchb);
            this.groupBox2.Controls.Add(this.manhattanchb);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox2.Location = new System.Drawing.Point(35, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 100);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Heuristic Selection";
            // 
            // euclideanchb
            // 
            this.euclideanchb.AutoSize = true;
            this.euclideanchb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.euclideanchb.Location = new System.Drawing.Point(38, 60);
            this.euclideanchb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.euclideanchb.Name = "euclideanchb";
            this.euclideanchb.Size = new System.Drawing.Size(146, 23);
            this.euclideanchb.TabIndex = 7;
            this.euclideanchb.Text = "Euclidean Distance";
            this.euclideanchb.UseVisualStyleBackColor = true;
            // 
            // manhattanchb
            // 
            this.manhattanchb.AutoSize = true;
            this.manhattanchb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.manhattanchb.Location = new System.Drawing.Point(38, 23);
            this.manhattanchb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.manhattanchb.Name = "manhattanchb";
            this.manhattanchb.Size = new System.Drawing.Size(153, 23);
            this.manhattanchb.TabIndex = 6;
            this.manhattanchb.Text = "Manhattan Distance";
            this.manhattanchb.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pathlentb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.goaltesttb);
            this.groupBox1.Controls.Add(this.expansiontb);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox1.Location = new System.Drawing.Point(35, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 186);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path Properties";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path Len";
            // 
            // pathlentb
            // 
            this.pathlentb.Location = new System.Drawing.Point(39, 39);
            this.pathlentb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathlentb.Name = "pathlentb";
            this.pathlentb.Size = new System.Drawing.Size(116, 26);
            this.pathlentb.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Goal Test";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expansion";
            // 
            // goaltesttb
            // 
            this.goaltesttb.Location = new System.Drawing.Point(39, 88);
            this.goaltesttb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.goaltesttb.Name = "goaltesttb";
            this.goaltesttb.Size = new System.Drawing.Size(116, 26);
            this.goaltesttb.TabIndex = 4;
            // 
            // expansiontb
            // 
            this.expansiontb.Location = new System.Drawing.Point(39, 139);
            this.expansiontb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.expansiontb.Name = "expansiontb";
            this.expansiontb.Size = new System.Drawing.Size(116, 26);
            this.expansiontb.TabIndex = 5;
            // 
            // closebt
            // 
            this.closebt.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.closebt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closebt.Location = new System.Drawing.Point(1071, 356);
            this.closebt.Name = "closebt";
            this.closebt.Size = new System.Drawing.Size(110, 27);
            this.closebt.TabIndex = 31;
            this.closebt.Text = "Close";
            this.closebt.UseVisualStyleBackColor = true;
            this.closebt.Click += new System.EventHandler(this.Closebt_Click);
            // 
            // cltb
            // 
            this.cltb.Font = new System.Drawing.Font("Comic Sans MS", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cltb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cltb.Location = new System.Drawing.Point(1084, 304);
            this.cltb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cltb.Name = "cltb";
            this.cltb.Size = new System.Drawing.Size(87, 45);
            this.cltb.TabIndex = 30;
            this.cltb.Text = "Clear";
            this.cltb.UseVisualStyleBackColor = true;
            this.cltb.Click += new System.EventHandler(this.Cltb_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox2.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 18;
            this.listBox2.Location = new System.Drawing.Point(250, 47);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(651, 472);
            this.listBox2.TabIndex = 29;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(922, 77);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(111, 403);
            this.listBox1.TabIndex = 28;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 566);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closebt);
            this.Controls.Add(this.cltb);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Name = "Mainform";
            this.Text = "Search Strategy";
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button astarbt;
        private System.Windows.Forms.Button greedybt;
        private System.Windows.Forms.Button ucsbt;
        private System.Windows.Forms.Button bfsbt;
        private System.Windows.Forms.Button dfsbt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bmcosttb;
        private System.Windows.Forms.TextBox dmcosttb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox euclideanchb;
        private System.Windows.Forms.CheckBox manhattanchb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathlentb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox goaltesttb;
        private System.Windows.Forms.TextBox expansiontb;
        private System.Windows.Forms.Button closebt;
        private System.Windows.Forms.Button cltb;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

