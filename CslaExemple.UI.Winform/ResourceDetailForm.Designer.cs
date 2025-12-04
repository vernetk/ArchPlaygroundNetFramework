using System.Windows.Forms;

namespace CslaExemple.UI.Winform
{
    partial class ResourceDetailForm
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ResourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceVM = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRefresh1 = new Csla.Windows.BindingSourceRefresh(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.ResourceBindingSource;
            // 
            // txtFirstName
            // 
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ResourceBindingSource, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(91, 33);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ResourceBindingSource, "LastName", true));
            this.txtLastName.Location = new System.Drawing.Point(236, 33);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
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
            // ResourceBindingSource
            // 
            this.ResourceBindingSource.DataSource = typeof(CslaExemple.BLLNetStandard.ResourceEdit);
            this.bindingSourceRefresh1.SetReadValuesOnChange(this.ResourceBindingSource, true);
            // 
            // bindingSourceVM
            // 
            this.bindingSourceVM.DataSource = typeof(CslaExemple.UI.Winform.ResourceDetailViewModel);
            // 
            // ResourceDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "ResourceDetailForm";
            this.Text = "ResourceDetailForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private BindingSource bindingSourceVM;
        private BindingSource ResourceBindingSource;
        private Csla.Windows.BindingSourceRefresh bindingSourceRefresh1;
    }
}