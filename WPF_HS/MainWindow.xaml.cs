using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Net.Http;
using System.Net.Http.Headers;
using Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace WPF_HS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindCourses();
        }

        private async Task BindCourses()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://itschooldigi.azurewebsites.net/api/CoursesApi/courses");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var courses = JsonConvert.DeserializeObject<List<Course>>(content);
                CoursesGrid.ItemsSource = courses;
            }
        }

        private void CoursesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var course = (Course)CoursesGrid.SelectedItem;
            CourseDetail courseDetail = new CourseDetail(course.CourseID);
            courseDetail.Show();
        }
    }
}
