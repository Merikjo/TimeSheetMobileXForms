using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace TimeSheetMobileXForms
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
            //BindingContext = new EmployeePage();
            employeeList.ItemsSource = new string[] { "" };
        }

        public async void LoadEmployees(object sender, EventArgs e)
        {
            try

            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://mobilebackendmvc-api.azurewebsites.net/");
                string json = await client.GetStringAsync("/api/employee");
                string[] employees = JsonConvert.DeserializeObject<string[]>(json);

                employeeList.ItemsSource = employees;
            }
            catch (Exception ex)

            {
                string errorMessage = ex.GetType().Name + ": " + ex.Message;

                employeeList.ItemsSource = new string[] { errorMessage };

            }

        }

        private async void ListWorkAssignments(object sender, EventArgs e)

        {
            string employee = employeeList.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(employee))
            {
                await DisplayAlert("List Work", "You must select employee first.", "OK");
            }
            else
            {
                Navigation.PushAsync(new WorkAssignmentPage());

            }
        }
    }
}
    