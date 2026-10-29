using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        // Создаем переменную, которая представляет класс вашей модели базы данных Model1
        Model1 model = new Model1();

        public Form1()
        {
            InitializeComponent();
        }

        // В событие Формы Load() прописываем метод StartLoadData()
        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }

        // В событие Click() элемента DeleteItem прописываем метод SaveData()
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        // В событие Click() элемента SaveItem прописываем метод SaveData()
        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        // В событие bindingNavigatorAddNewItem_Click вставляем код, 
        // который выбирает в ComboBox RoleName первый (0) элемент
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }

        // При помощи метода StartLoadData() данные загружаются
        private void StartLoadData()
        {
            model.Users.Load();
            role_NameComboBox.DataSource = model.Roles.ToList();
            usersBindingSource.DataSource = model.Users.Local.ToBindingList();
        }

        // Метод сохранения изменений в базу данных
        private void SaveData()
        {
            try
            {
                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartLoadData();
            }
        }

        // Остальные пустые методы (если они созданы в дизайнере, оставляем их)
        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
