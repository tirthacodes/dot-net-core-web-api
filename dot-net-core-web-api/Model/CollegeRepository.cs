namespace dot_net_core_web_api.Model
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student
            {
                Id = 1,
                StudentName = "Binay",
                Email = "binay@gmail.com",
                Address = "KTM"
            },
            new Student
            {
                Id = 2,
                StudentName = "Alex",
                Email = "alex@gmail.com",
                Address = "Baglung"
            }
        };
    }
}
