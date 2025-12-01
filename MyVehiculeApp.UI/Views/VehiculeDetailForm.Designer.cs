using System.Windows.Forms;

namespace MyVehiculeApp.UI.Views
{
    partial class VehiculeDetailForm
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.errorProvider.ContainerControl = this;

            this.errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            this.txtImmatriculation = new System.Windows.Forms.TextBox();
            this.txtMarque = new System.Windows.Forms.TextBox();
            this.txtModele = new System.Windows.Forms.TextBox();
            this.dtpDateEntree = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtImmatriculation
            // 
            this.txtImmatriculation.Location = new System.Drawing.Point(91, 33);
            this.txtImmatriculation.Name = "txtImmatriculation";
            this.txtImmatriculation.Size = new System.Drawing.Size(100, 20);
            this.txtImmatriculation.TabIndex = 0;
            // 
            // txtMarque
            // 
            this.txtMarque.Location = new System.Drawing.Point(236, 33);
            this.txtMarque.Name = "txtMarque";
            this.txtMarque.Size = new System.Drawing.Size(100, 20);
            this.txtMarque.TabIndex = 1;
            // 
            // txtModele
            // 
            this.txtModele.Location = new System.Drawing.Point(366, 33);
            this.txtModele.Name = "txtModele";
            this.txtModele.Size = new System.Drawing.Size(100, 20);
            this.txtModele.TabIndex = 2;
            // 
            // dtpDateEntree
            // 
            this.dtpDateEntree.Location = new System.Drawing.Point(91, 79);
            this.dtpDateEntree.Name = "dtpDateEntree";
            this.dtpDateEntree.Size = new System.Drawing.Size(200, 20);
            this.dtpDateEntree.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 169);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Sauvegarder";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // VehiculeDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDateEntree);
            this.Controls.Add(this.txtModele);
            this.Controls.Add(this.txtMarque);
            this.Controls.Add(this.txtImmatriculation);
            this.Name = "VehiculeDetailForm";
            this.Text = "VehiculeDetailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImmatriculation;
        private System.Windows.Forms.TextBox txtMarque;
        private System.Windows.Forms.TextBox txtModele;
        private System.Windows.Forms.DateTimePicker dtpDateEntree;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}