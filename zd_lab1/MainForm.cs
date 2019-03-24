using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd_lab1
{

    public partial class MainForm : Form
    {
        private const string rsa = "RSA";
        private const string dsa = "DSA";
        private const string sha1 = "SHA1";
        private const string sha512 = "SHA512";

        public MainForm()
        {
            InitializeComponent();
            btnChangeUser.Focus();
            if (!Directory.Exists(Application.StartupPath + "\\PK"))
                Directory.CreateDirectory(Application.StartupPath + "\\PK");
        }

        private void tsmiCreate_Click(object sender, EventArgs e)
        {
            this.Text = "Подписанный документ";
            tbEditDocument.Text = "";
            tbEditDocument.Focus();
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            SignedDocument signedDocument = new SignedDocument(openFileDialog.FileName);

            PublicKey publicKey;
            try
            {
                publicKey = new PublicKey(Application.StartupPath + "\\PK\\" + signedDocument.userName + ".pk");
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Открытый ключ Автора не найден.");
                return;
            }

            if (!CryptEngine.CheckEds(publicKey.eds, publicKey.blob, sha512, rsa))
            {
                MessageBox.Show(this, "Электронная подпись открытого ключа автора документа не подтверждена.");
                return;
            }

            if (!CryptEngine.CheckEds(signedDocument.edsBlob, Encoding.Default.GetBytes(signedDocument.text), sha1, dsa, publicKey.blob))
            {
                MessageBox.Show(this, "Электронная подпись документа не подтверждена.");
                return;
            }

            this.Text = "Подписано - " + signedDocument.userName;
            tbEditDocument.Text = signedDocument.text;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            SignedDocument signedDocument = new SignedDocument();
            signedDocument.text = tbEditDocument.Text;
            signedDocument.userName = tbUserName.Text;
            signedDocument.edsBlob = CryptEngine.GetEds(Encoding.Default.GetBytes(signedDocument.text), sha1, dsa);
            signedDocument.SaveToFile(saveFileDialog.FileName);

            this.Text = "Подписано - " + signedDocument.userName;
        }

        private void tsmiExportPubKey_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            PublicKey publicKey = new PublicKey();
            publicKey.blob = CryptEngine.GetCurrentPublicKey();
            publicKey.ownerUserName = tbUserName.Text;
            publicKey.eds = null;
            publicKey.Save(saveFileDialog.FileName);
        }

        private void tsmiImportPubKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            PublicKey publicKey = new PublicKey(openFileDialog.FileName);
            publicKey.eds = CryptEngine.GetEds(publicKey.blob, sha512, rsa);   
            publicKey.Save(Application.StartupPath + "\\PK\\" + publicKey.ownerUserName + ".pk"); 
        }

        private void tsmiDelitPairKey_Click(object sender, EventArgs e)
        {
            CryptEngine.RemoveKeysByName(tbUserName.Text);
            tbUserName.Text = "";
            DisabledControlElements();
        }

        private void tsmiChangePrivKey_Click(object sender, EventArgs e)
        {
            tbUserName.Enabled = true;
            tbUserName.Text = "";
            tbUserName.Focus();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadDocument_Click(object sender, EventArgs e)
        {
            tsmiLoad_Click(sender, e);
        }

        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            tsmiSave_Click(sender, e);
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            tsmiChangePrivKey_Click(sender, e);
        }

        private void tbUserName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbUserName.Enabled = false;
                if (!CryptEngine.CspContainerExists(tbUserName.Text))   
                {
                    if (MessageBox.Show(this, "Пара ключей пользователя с таким именем не найдена. Создать новую пару?", "Ключи не найдены", MessageBoxButtons.YesNo) == DialogResult.Yes)            //  ask user about he want to create new user
                    {
                        CryptEngine.CreateCspContainerByName(tbUserName.Text); 
                        CryptEngine.SetExistingCspContainerByNameCurrent(tbUserName.Text);
                    }
                    else
                    {
                        tbUserName.Text = ""; 
                        DisabledControlElements();
                        return;
                    }
                }
                else
                {
                    CryptEngine.SetExistingCspContainerByNameCurrent(tbUserName.Text); 
                }
                EnabledControlElements();
            }
        }

        private void EnabledControlElements() {
            tsmiCreate.Enabled = true;
            tsmiLoad.Enabled = true;
            tsmiSave.Enabled = true;
            tsmiExportPubKey.Enabled = true;
            tsmiImportPubKey.Enabled = true;
            tsmiDelitPairKey.Enabled = true;
            btnLoadDocument.Enabled = true;
            btnSaveDocument.Enabled = true;
        }

        private void DisabledControlElements() {
            tsmiCreate.Enabled = false;
            tsmiLoad.Enabled = false;
            tsmiSave.Enabled = false;
            tsmiExportPubKey.Enabled = false;
            tsmiImportPubKey.Enabled = false;
            tsmiDelitPairKey.Enabled = false;
            btnLoadDocument.Enabled = false;
            btnSaveDocument.Enabled = false;
        }
    }
}
