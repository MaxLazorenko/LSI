using LSI.Domain.Storage;

namespace LSI.Domain
{
    public class DataSeeder
    {
        private readonly ReportContext _reportContext;

        public DataSeeder(ReportContext context) => _reportContext = context;


        public void SeedData()
        {
            for (int i = 0; i < 5; i++)
            {
                _reportContext.Reports.Add(new Models.Report
                {
                    UserName = $"Test{i}",
                    NameOfRoom = $"Room{i}",
                    DateOfExport = System.DateTime.Now.AddDays(i + 1),
                    NameOfExport = $"Export{i}"
                });
            }

            _reportContext.SaveChanges();
        }
    }
}
