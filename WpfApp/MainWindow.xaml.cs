using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessLogicLayer.BLL;
using DataAccessLayer.Context;
using DataAccessLayer.Model;
using DTO.Model;
using MVC_App.Controllers;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private TidsregistreringBLL _tidsregistreringBLL;

        public MainWindow()
        {
            InitializeComponent();
            _tidsregistreringBLL = new TidsregistreringBLL();
            LoadAfdelinger();
            LoadMedarbejder();
            LoadTidsregistrering();
            LoadMedarbejderComboBox();
            LoadAfdelingComboBox(); // Add this line
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Initial" || textBox.Text == "Navn" || textBox.Text == "Cpr"))
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "InitialTextBox")
                {
                    textBox.Text = "Initial";
                }
                else if (textBox.Name == "NavnTextBox")
                {
                    textBox.Text = "Navn";
                }
                else if (textBox.Name == "CprTextBox")
                {
                    textBox.Text = "Cpr";
                }
            }
        }

        private void LoadTidsregistrering()
        {
            int selectedMedarbejderId = 2;
            var tidsregistreringer = _tidsregistreringBLL.GetTidsregistreringByMedarbejder(selectedMedarbejderId);
            var medarbejdere = _tidsregistreringBLL.GetAllMedarbejder();

            Console.WriteLine("Tidsregistreringer:");
            foreach (var t in tidsregistreringer)
            {
                Console.WriteLine(
                    $"ID: {t.TidsregistreringId}, MedarbejderID: {t.MedarbejderId}, Start: {t.StartTid}, Slut: {t.SlutTid}");
            }

            Console.WriteLine("Medarbejdere:");
            foreach (var m in medarbejdere)
            {
                Console.WriteLine($"ID: {m.MedarbejderId}, Navn: {m.Navn}, Initial: {m.Initial}");
            }

            // LINQ-Join
            var tidsregistreringOversigt = from t in tidsregistreringer
                join m in medarbejdere on t.MedarbejderId equals m.MedarbejderId
                select new
                {
                    MedarbejderNavn = m.Navn,
                    MedarbejderInitial = m.Initial,
                    TidsregistreringStart = t.StartTid,
                    TidsregistreringSlut = t.SlutTid
                };

            Console.WriteLine("Tidsregistrering Oversigt:");
            foreach (var item in tidsregistreringOversigt)
            {
                Console.WriteLine(
                    $"Navn: {item.MedarbejderNavn}, Initial: {item.MedarbejderInitial}, Start: {item.TidsregistreringStart}, Slut: {item.TidsregistreringSlut}");
            }

            TidsregistreringDataGrid.ItemsSource = tidsregistreringOversigt.ToList();
        }

        private void LoadMedarbejder()
        {
            var employees = _tidsregistreringBLL.GetAllMedarbejder();
            MedarbejderDataGrid.ItemsSource = employees;
        }

        private void LoadAfdelinger()
        {
            var departments = _tidsregistreringBLL.AllAfdeling();
            AfdelingDataGrid.ItemsSource = departments;
        }

        private void LoadMedarbejderComboBox()
        {
            var employees = _tidsregistreringBLL.GetAllMedarbejder();
            MedarbejderComboBox.ItemsSource = employees;
        }

        private void ShowTidsregistreringer_Click(object sender, RoutedEventArgs e)
        {
            if (MedarbejderComboBox.SelectedValue != null)
            {
                int selectedMedarbejderId = (int)MedarbejderComboBox.SelectedValue;
                var tidsregistreringer = _tidsregistreringBLL.GetTidsregistreringByMedarbejder(selectedMedarbejderId);
                var medarbejdere = _tidsregistreringBLL.GetAllMedarbejder();

                var tidsregistreringOversigt = from t in tidsregistreringer
                    join m in medarbejdere on t.MedarbejderId equals m.MedarbejderId
                    select new
                    {
                        MedarbejderNavn = m.Navn,
                        MedarbejderInitial = m.Initial,
                        TidsregistreringStart = t.StartTid,
                        TidsregistreringSlut = t.SlutTid
                    };

                TidsregistreringDataGrid.ItemsSource = tidsregistreringOversigt.ToList();
            }
        }

        private void AddMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            // Create a new employee object
            var newMedarbejder = new Medarbejder
            {
                Initial = InitialTextBox.Text,
                Navn = NavnTextBox.Text,
                Cpr = CprTextBox.Text
            };

            // Add the new employee to the database
            _tidsregistreringBLL.AddMedarbejder(newMedarbejder);

            // Refresh the DataGrid
            LoadMedarbejder();
            LoadMedarbejderComboBox();
        }

        private void AddMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            // Ensure that a valid AfdelingId is selected
            if (AfdelingComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid department.");
                return;
            }

            int selectedAfdelingId = (int)AfdelingComboBox.SelectedValue;

            // Create a new employee object
            var newMedarbejder = new Medarbejder
            {
                Initial = InitialTextBox.Text,
                Navn = NavnTextBox.Text,
                Cpr = CprTextBox.Text,
                AfdelingId = selectedAfdelingId // Set the valid AfdelingId
            };

            // Add the new employee to the database
            _tidsregistreringBLL.AddMedarbejder(newMedarbejder);

            // Refresh the DataGrid
            LoadMedarbejder();
            LoadMedarbejderComboBox();
        }

        private void LoadAfdelingComboBox()
        {
            var departments = _tidsregistreringBLL.AllAfdeling();
            AfdelingComboBox.ItemsSource = departments;
            AfdelingComboBox.DisplayMemberPath = "Navn";
            AfdelingComboBox.SelectedValuePath = "AfdelingId";
        }


        private void DeleteAfdeling_Click(object sender, RoutedEventArgs e)
        {
            var selectedDepartment = AfdelingDataGrid.SelectedItem as AfdelingOverview;
            if (selectedDepartment != null)
            {
                _tidsregistreringBLL.DeleteAfdeling(selectedDepartment.AfdelingId);
                LoadAfdelinger();
            }
        }

        private void DeleteMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = MedarbejderDataGrid.SelectedItem as Medarbejder;
            if (selectedEmployee != null)
            {
                _tidsregistreringBLL.DeleteMedarbejder(selectedEmployee.MedarbejderId);
                LoadMedarbejder();
                LoadMedarbejderComboBox();
            }
        }

        private void AddMedarbejderToAfdeling_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = MedarbejderDataGrid.SelectedItem as Medarbejder;
            var selectedDepartment = AfdelingDataGrid.SelectedItem as AfdelingOverview;
            if (selectedEmployee != null && selectedDepartment != null)
            {
                _tidsregistreringBLL.AddMedarbejderToAfdeling(selectedEmployee.MedarbejderId,
                    selectedDepartment.AfdelingId);
                LoadMedarbejder();
            }
        }

        private void AddAfdeling_Click(object sender, RoutedEventArgs e)
        {
            var newDepartment = new AfdelingOverview
            {
                Nummer = int.Parse(NummerTextBox.Text),
                Navn = NavnTextBox.Text
            };

            _tidsregistreringBLL.AddAfdeling(newDepartment);
            LoadAfdelinger();
            LoadAfdelingComboBox();
        }
    }
}