using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Library_MVP.Logic.Presenter;
using Library_MVP.Views.Interface;

namespace Library_MVP.Views.Forms
{
    public partial class FrmCategory : DevExpress.XtraEditors.XtraForm,ICategory
    {
        CategoryPresenter CatPresenter;

        public int ID { get =>Convert.ToInt32( TxtNo.Text); set => TxtNo.Text=value.ToString(); }
        public string CatName { get => TxtName.Text; set => TxtName.Text=value; }

        public FrmCategory()
        {
            InitializeComponent();
            CatPresenter = new CategoryPresenter(this);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
           bool Check= CatPresenter.CatInsert();
            if (Check == true)
            {
                XtraMessageBox.Show("تم االاظافة بنجاح", "رسالة تأکیید", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                XtraMessageBox.Show("حصل خطأ اثناء عملیة الحفظ", "رسالة تأکیید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
    }
}