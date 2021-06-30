using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
    
namespace WPF_HS
{
    /// <summary>
    /// Logique d'interaction pour CourseDetail.xaml
    /// </summary>
    public partial class CourseDetail : Window
    {
        public CourseDetail(int id)
        {
            InitializeComponent();
            ShowCourseDetails(id);
        }

        public async Task ShowCourseDetails(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44321/api/CoursesApi/course/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var course = JsonConvert.DeserializeObject<Course>(content);
                CourseStudentsGrid.ItemsSource = course.Groups.Select(g=>g.Students);
            }
        }
    }
}
