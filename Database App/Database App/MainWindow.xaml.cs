using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using System.ComponentModel.Design.Serialization;

namespace Database_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionstring;
        SQLiteConnection connect;
        SQLiteCommand command;
        SQLiteDataReader reader;
        string querrytext;
        List<user> users;
        Task t;

        int deletingid;
        int updateid;
        string searchtext;
        bool rantocompletion;

        int clientid;
        string name;
        string surname;
        DateTime birthdate;
        string birthdatestring;
        int age;
        public MainWindow()
        {
            InitializeComponent();
            connectionstring = @"Data Source= ./res/myusersdb.db";
            t = new Task(validate_data);
        }

        //database interaction functions
        void loaddata()
        {

            connect = new SQLiteConnection(connectionstring);
            connect.Open();
            querrytext = @"SELECT * FROM userinfo";
            command = connect.CreateCommand();
            command.CommandText = querrytext;
            reader = command.ExecuteReader();
            users = new List<user>();
            while (reader.Read())
            {
                users.Add(new user()
                {
                    clientid = int.Parse(reader.GetValue(0).ToString()),
                    name = reader.GetValue(1).ToString(),
                    surname = reader.GetValue(2).ToString(),
                    id = int.Parse(reader.GetValue(3).ToString()),
                    birthdate = reader.GetValue(4).ToString(),
                    age = int.Parse(reader.GetValue(5).ToString())

                });


            }
            connect.Close();
        }
        void createdata(int clientid, string name, string sir_name, string birthdate, int years)

        {
            rantocompletion = false;
            try
            {
                connect = new SQLiteConnection(connectionstring);
                connect.Open();
                command = connect.CreateCommand();
                querrytext = @"INSERT INTO userinfo('clientid', 'name', 'surname', 'birthdate', 'age') VALUES('" + clientid + "','" + name + "','" + sir_name + "','" + birthdate + "','" + years + "')";
                command.CommandText = querrytext;
                command.ExecuteNonQuery();
                connect.Close();
                rantocompletion = true;
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Cannot Choose Client ID already in Database");
            }
           

        }
        void deletedata()
        {
                connect = new SQLiteConnection(connectionstring);
                connect.Open();
                command = connect.CreateCommand();
                querrytext = "DELETE FROM userinfo WHERE id = '" + deletingid + "'";
                command.CommandText = querrytext;
                command.ExecuteNonQuery();
                connect.Close();
        }
        void validate_data()
        {
            for (int i = 6000; i < 6500; i++)
            {

                createdata(i, "Odogwu" + i, "Anyasi" + (2 * i), i + "/06/" + i, 10);
            }
        }

        void updatedata(int clientid, string name, string sir_name, string birthdate, int years)
        {
            rantocompletion = false;
            try
            {
                connect = new SQLiteConnection(connectionstring);
                connect.Open();
                command = connect.CreateCommand();
                querrytext = string.Format("UPDATE userinfo SET clientid ='{0}', name ='{1}', surname= '{2}', birthdate = '{3}', age ='{4}' WHERE id = '{5}';", clientid, name, sir_name, birthdate, years, updateid);
                command.CommandText = querrytext;
                command.ExecuteNonQuery();
                connect.Close();
                rantocompletion = true;
            }
            catch (SQLiteException)
            {

                MessageBox.Show("Cannot Choose Client ID already in Database");
            }
        }

        void searchdata()
        {
            connect = new SQLiteConnection(connectionstring);
            connect.Open();
            querrytext = @"SELECT * FROM userinfo WHERE id = '"+searchtext+"' OR name = '"+searchtext+"'";
            command = connect.CreateCommand();
            command.CommandText = querrytext;
            reader = command.ExecuteReader();
            users = new List<user>();
            while (reader.Read())
            {
                users.Add(new user()
                {
                    clientid = int.Parse(reader.GetValue(0).ToString()),
                    name = reader.GetValue(1).ToString(),
                    surname = reader.GetValue(2).ToString(),
                    id = int.Parse(reader.GetValue(3).ToString()),
                    birthdate = reader.GetValue(4).ToString(),
                    age = int.Parse(reader.GetValue(5).ToString())

                });
            }
        }

        //functions that implement task queuing and multithreading
        void QueueforVisual(Action methodToRun)
        {
            if (datdbrecords.Cursor != Cursors.Wait)
            {
                if (t.Status == TaskStatus.Running)
                {
                    Task continuation = t.ContinueWith((t1) => methodToRun());
                    updateobjects(continuation);
                }
                else
                {
                    t = new Task(methodToRun);
                    t.Start();
                    updateobjects(t);
                }
              ;
            }
        }
        void Queue(Button senderB, Action methodToRun)
        {
            if (senderB.Cursor != Cursors.Wait)
            {
                if (t.Status == TaskStatus.Running)
                {
                    Task continuation = t.ContinueWith((t1) => methodToRun());
                    CheckQueue(continuation, senderB);
                }
                else
                {
                    t = new Task(methodToRun);
                    t.Start();
                    CheckQueue(t, senderB);
                }
              ;
            }
        }
        async void CheckQueue(Task runnig, Button sender)
        {
            sender.Cursor = Cursors.Wait;
            await runnig;
            sender.Cursor = Cursors.Arrow;
            if (rantocompletion)
            {
                MessageBox.Show("completed");
            }
            
        }
        async void updateobjects(Task running)
        {
            datdbrecords.Cursor = Cursors.Wait;
            await running;
            datdbrecords.ItemsSource = users;
            datdbrecords.Cursor = Cursors.Arrow;
            users = null;
        }

        //data validating functions

        bool  verifyintinput(string s)
        {
            bool isvalid = false;
            try
            {
                int a= int.Parse(s);
                isvalid = true;
            }
            catch (Exception)
            {

               
            }

            return isvalid;
        }

        bool verifystringinput(string s)
        {
            bool isvalid = false;
            if (!string.IsNullOrWhiteSpace(s))
            {
                isvalid = true;
            }
            return isvalid;
        }



        //app characteristics functions
        bool setvalues()
        {
            bool isset = false; 
            if (verifyintinput(txtclientid.Text)&&datebirthdate.SelectedDate!=null&& verifystringinput(txtname.Text)&&verifystringinput(txtsirname.Text))
            {
                clientid = int.Parse(txtclientid.Text);
                name = txtname.Text;
                surname = txtsirname.Text;
                birthdate = (DateTime)datebirthdate.SelectedDate;
                birthdatestring = birthdate.ToShortDateString();
                age = DateTime.Now.Year - birthdate.Year;
                isset = true;
            }
            else
            {
                MessageBox.Show("One or more inputs is invalid");
            }
            return isset;
        }

        void cleardefaulttext(TextBox sender, string defaulttext)
        {
            if (sender.Text == defaulttext)
            {
                sender.Clear();
            }
        }

        void restoredefaulttext(TextBox sender, string defaulttext)
        {
            if (string.IsNullOrWhiteSpace(sender.Text))
            {
                sender.Text = defaulttext;
            }
        }


        //button events
        private void btncreaterecord_Click(object sender, RoutedEventArgs e)
        {
            if (setvalues())
            {
                Queue(btncreaterecord, () => createdata(clientid, name, surname, birthdatestring, age));
            }
                      
        }

        private void btnupdaterecord_Click(object sender, RoutedEventArgs e)
        {
            if (setvalues())
            {
                if (verifyintinput(txtupdateid.Text) )
                {
                    updateid = int.Parse(txtupdateid.Text);
                    Queue(btnupdaterecord, () => updatedata(clientid, name, surname, birthdatestring, age));
                }
                else
                {
                    MessageBox.Show("Invalid ID Input");
                }

            }
          
        }

        private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            QueueforVisual(loaddata);   
        }

        private void btndeleteselected_Click(object sender, RoutedEventArgs e)
        {
            if (datdbrecords.SelectedItem!=null)
            {
                if (datdbrecords.SelectedItems.Count ==1)
                {
                    user u = datdbrecords.SelectedItem as user;
                    deletingid = u.id;
                    Queue(btndeleteselected, deletedata);
                    QueueforVisual(loaddata);
                } 
            }
        }

        private void btndeletebyid_Click(object sender, RoutedEventArgs e)
        {
            if (verifyintinput(txtdeletebyid.Text))
            {
                deletingid = int.Parse(txtdeletebyid.Text);
                Queue(btndeleteselected, deletedata);
                QueueforVisual(loaddata);
            }
            else
            {
                MessageBox.Show("Invalid ID Input");
            }
        }
        private void btnsearcdb_Click(object sender, RoutedEventArgs e)
        {
            searchtext = txtsearchdb.Text;
            QueueforVisual(searchdata);
        }


        //textbox events
        private void txtdeletebyid_GotFocus(object sender, RoutedEventArgs e)
        {
            cleardefaulttext(txtdeletebyid, "Enter ID");
        }

        private void txtdeletebyid_LostFocus(object sender, RoutedEventArgs e)
        {
            restoredefaulttext(txtdeletebyid, "Enter ID");
        }

        private void txtsearchdb_GotFocus(object sender, RoutedEventArgs e)
        {
            cleardefaulttext(txtsearchdb, "Search Records");
        }

        private void txtsearchdb_LostFocus(object sender, RoutedEventArgs e)
        {
            restoredefaulttext(txtsearchdb, "Search Records");
        }

        private void txtupdateid_GotFocus(object sender, RoutedEventArgs e)
        {
            cleardefaulttext(txtupdateid, "Enter ID");
        }

        private void txtupdateid_LostFocus(object sender, RoutedEventArgs e)
        {
            restoredefaulttext(txtupdateid, "Enter ID");
        }

        
    }

    class user
    {
        public int clientid { get; set; }
   
        public string name { get; set; }
        public string surname { get; set; }
        public int id { get; set; }
        public string birthdate { get; set; }
        public int age { get; set; }

        public user()
        {

        }
    }
}
